using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using static iTextSharp.text.pdf.events.IndexEvents;

#region Design
// 1. 量測結束後自動彈出「測試報告」視窗 (OK)
// 2. 上下限值儲存在設備中，開啟程式時自動讀取 (OK)
// 3. 可單獨匯入CSV產出報表 (OK)
// 4. 第一頁面直接輸入數據，測試報告不開放修改 (OK)
// 5. 量測結束自動匯出CSV並產生報表 (OK)

// 已知Bug
// 1. 上下限值設定未過濾(上下不得小於下限，非數字) (OK)
// 2. 

// 當前設計
/* 
 * 1. 量測完成時自動產出報表並儲存為pdf
 * 2. 成功匯入csv後自動產出報表並儲存為pdf
 * 3. 量測中止時不產出報表
 * 4. 
 * 
*/
#endregion

namespace LH_LaserAnalyzer
{
    public partial class Main : Form
    {
        SerialPort LaserDevice_Port = new SerialPort();
        private int PreSensorState = -1;
        private int SensorState = -1;
        private int StartSensor = 0;
        private int SensorProcess_idx = -2;
        private bool CheckUpdate_Up = false;
        private bool CheckUpdate_Low = false;
        private bool UpdateCompleteUp = false;
        private bool UpdateCompleteLow = false;
        private Form result = null; // Not in use

        // 雷射校正
        private int Cali_idx = 0;
        private const int CALI_FAIL = -1;
        private const int CALI_START = 0;
        private const int CALI_WAIT = 1;
        private const int CALI_MIN = 2;
        private const int CALI_MAX = 3;
        private const int CALI_DONE = 4;
        public Main()
        {
            string folderPath = $@"{Environment.CurrentDirectory}\Result";
            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();  
            GetComPort();
            mainProcess_Action();

            //debug_gb.Visible = true;
        }

        private void mainProcess_Action() 
        { 
            //mainProcess.SerialSend = (data) => { SerialSend(LaserDevice_Port, data); };
        }

        private void COM_Connect_btn_Click(object sender, EventArgs e)
        {
            if (COM_cb.Text == "Cali")
            {
                if (!LaserDevice_Port.IsOpen)
                {
                    MessageBox.Show("設備尚未連接", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (SensorProcess_idx != -2)
                {
                    MessageBox.Show("請先停止量測再進行校正", "雷射感測器校正", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DialogResult result = MessageBox.Show("是否執行雷射感測器校正？", "雷射感測器校正", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Thread Cali_Thread = new Thread(delegate ()
                    {
                        CalibrationProcess();
                    });
                    Cali_Thread.Start();
                }
                return;
            }

            if (COM_cb.Text == "Result")
            {
                Form result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                result.Show();
                return;
            }

            if (LaserDevice_Port.IsOpen)
            {
                try
                {
                    LaserDevice_Port.Close();
                    COM_Connect_btn.BackColor = Control.DefaultBackColor;
                    COM_Connect_btn.Text = "開啟";
                    LaserDevice_Port.DataReceived -= new SerialDataReceivedEventHandler(LaserDevice_DataReceived);
                    State_init();
                    return;
                }
                catch (Exception disconn)
                {
                    MessageBox.Show(disconn.ToString());
                }
            }
            else if (!string.IsNullOrEmpty(COM_cb.Text) && !LaserDevice_Port.IsOpen)
            {
                try
                {
                    //ComPort設定
                    LaserDevice_Port.PortName = COM_cb.Text;
                    LaserDevice_Port.BaudRate = 9600;
                    LaserDevice_Port.StopBits = StopBits.One;
                    LaserDevice_Port.Parity = Parity.None;
                    LaserDevice_Port.ReadTimeout = 300;
                    LaserDevice_Port.Handshake = Handshake.None;
                    // 新版
                    LaserDevice_Port.DtrEnable = true;
                    LaserDevice_Port.RtsEnable = true;
                    // 新版
                    LaserDevice_Port.Open();
                    LaserDevice_Port.DataReceived += new SerialDataReceivedEventHandler(LaserDevice_DataReceived);
                    COM_Connect_btn.BackColor = Color.LightGreen;
                    COM_Connect_btn.Text = "關閉";

                    Thread.Sleep(100);
                    SerialSend(LaserDevice_Port, "uplimit");   // 取得上限
                    Thread.Sleep(200);
                    SerialSend(LaserDevice_Port, "lowlimit");   // 取得下限
                }
                catch (Exception conn)
                {
                    MessageBox.Show(conn.ToString());
                }
            }
        }

        private void LaserDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10);  //（毫秒）等待一定時間，確保資料的完整性 int len      
            if (LaserDevice_Port.IsOpen)
            {
                int len = LaserDevice_Port.BytesToRead;
                string rcv = string.Empty;
                float rawdist = 0;
                if (len != 0)
                {
                    //byte[] buff = new byte[len];
                    //IoT_Device_Port.Read(buff, 0, len);
                    //string rcv = Encoding.Default.GetString(buff);
                    //Debug.WriteLine(DateTime.Now.ToString("MM-dd hh:mm:ss.fff") + ", " + rcv + "\r\n");
                    try
                    {
                        rcv = LaserDevice_Port.ReadLine();
                    }
                    catch
                    {
                        Debug.WriteLine("未發現換行");
                        LaserDevice_Port.DiscardInBuffer();
                    }
                    Debug.WriteLine("Receive: " + rcv.Trim());
                    
                    if(rcv.Contains("Uplimit"))
                    {
                        // 未設定上限值時為NAN
                        if(rcv.Contains("NAN"))
                        {
                            Uplimit_tb.Text = "NAN";
                            return;
                        }

                        if (CheckUpdate_Up)
                        {
                            Debug.WriteLine("Check Update Up");
                            Debug.WriteLine(float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.00"));
                            if (float.Parse(Uplimit_tb.Text) == float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()))
                            {                             
                                UpdateCompleteUp = true;
                            }
                            CheckUpdate_Up = false;
                        }
                        else
                            Uplimit_tb.Text = float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.00");
                    }   

                    else if(rcv.Contains("Lowlimit"))
                    {
                        // 未設定下限值時為NAN
                        if(rcv.Contains("NAN"))
                        {
                            Downlimit_tb.Text = "NAN";
                            return;
                        }

                        if(CheckUpdate_Low)
                        {
                            Debug.WriteLine("Check Update Low");
                            Debug.WriteLine(float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.00")); 
                            if (float.Parse(Downlimit_tb.Text) == float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()))
                            {
                                UpdateCompleteLow = true;
                            }
                            CheckUpdate_Low = false;
                        }
                        else
                            Downlimit_tb.Text = float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.00");
                    }

                    else if(rcv.Contains("TEST STOP"))
                    {
                        SensorProcess_idx = 2;
                        SensorProcess(0);
                    }
                    
                    else if(rcv.Contains("TEST START"))
                    {
                        rcv_tb.Clear();
                        SensorProcess_idx = -1;
                        SensorProcess(0);
                    }

                    else if(rcv.Contains("Sensor"))
                    {
                        return;
                    }

                    // 雷射校正 最小值
                    else if(rcv.Contains("Please put the sensor on the min distance and enter the number on laser display"))
                    {
                        Debug.WriteLine("LaserDevice_DataReceived: Cali_idx = CALI_MIN");
                        Cali_idx = CALI_MIN;
                    }

                    // 雷射校正 最大值
                    else if (rcv.Contains("Please put the sensor on the max distance and enter the number on laser display"))
                    {
                        Debug.WriteLine("LaserDevice_DataReceived: Cali_idx = CALI_MAX");
                        Cali_idx = CALI_MAX;
                    }

                    // 雷射校正完成
                    else if(rcv.Contains("min_distance:") && rcv.Contains("max_distance:"))
                    {
                        Debug.WriteLine("LaserDevice_DataReceived: Cali_idx = CALI_DONE");
                        Cali_idx = CALI_DONE;
                    }

                    // 雷射距離數據
                    else if (rcv.Contains(',') && rcv.Split(',')[1].Contains("-1"))  // sensor尚未偵測
                    {
                        SensorState = -1;
                        SensorProcess(rawdist);    // 判斷Sensor狀態及確認offset值
                    }

                    else if(rcv.Contains(","))
                    {
                        try
                        {
                            rawdist = float.Parse(rcv.Split(',')[0]);
                            SensorState = int.Parse(rcv.Split(',')[1]);
                            SensorProcess(rawdist);    // 判斷Sensor狀態及確認offset值
                            if (SensorProcess_idx != -2 && SensorProcess_idx != 2)
                                rcv_tb.AppendText(DateTime.Now.ToString("MM-dd hh:mm:ss.fff") + $", {rawdist.ToString("##0.00")}, {SensorState}\r\n");
                        }
                        catch
                        {
                            Debug.WriteLine("Error: " + rcv);
                        }
                    }
                    //SensorProcess(rawdist);    // 判斷Sensor狀態及確認offset值
                    PreSensorState = SensorState;
                }
            }
        }

        private void SensorProcess(float dist)
        {
            switch (SensorProcess_idx)
            {
                case -2:    //  Standby
                    Debug.WriteLine("SensorProcess(): Standby");
                    break;

                case -1:    //  偵測到第一Sensor
                    TestState_lb.Text = "量測中：等待起始位置";
                    Debug.WriteLine("SensorProcess(): Waiting for first sensor");
                    if (PreSensorState == -1 && SensorState != -1)      //  偵測到第一Sensor
                    {
                        Debug.WriteLine("SensorProcess(): First Sensor Dectected");
                        StartSensor = SensorState;                                       //   記憶起始Sensor
                        TestState_lb.Text = "量測開始";
                        SensorProcess_idx++;
                    }
                    break;

                case 0:     //   脫離起始Sensor
                    Debug.WriteLine("SensorProcess(): Leave First Sensor");
                    if (SensorState != StartSensor)                             //   脫離起始Sensor
                    {
                        SensorProcess_idx++;
                    }
                    break;

                case 1:    //   等待回到起始Sensor
                    Debug.WriteLine("SensorProcess(): Waiting for going to first sensor");
                    if (SensorState == StartSensor)
                    {
                        Debug.WriteLine("SensorProcess(): Testing over");
                        SerialSend(LaserDevice_Port, "stop");                        //    傳送停止量測
                        PreSensorState = -1;
                        SensorState = -1;
                        SensorProcess_idx = -2;
                        TestState_lb.Text = "量測結束";
                    }
                    break;

                case 2:
                    Debug.WriteLine("SensorProcess(): Testing terminate");
                    PreSensorState = -1;
                    SensorState = -1;
                    SensorProcess_idx = -2;
                    TestState_lb.Text = "量測中止";
                    break;
            }
        }

        private void CalibrationProcess()
        {
            Cali_idx = CALI_START;
            while (true)
            {
                switch (Cali_idx)
                {
                    case CALI_FAIL:
                        Debug.WriteLine("Calibration Process: CALI_FAIL");
                        TestState_lb.Text = "雷射感測器校正失敗";
                        MessageBox.Show("雷射感測器校正失敗，請重啟設備後再進行校正", "雷射感測器校正", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    case CALI_START:
                        Debug.WriteLine("Calibration Process: CALI_START");
                        TestState_lb.Text = "雷射感測器校正中";
                        SerialSend(LaserDevice_Port, "cali");
                        Cali_idx = CALI_WAIT;
                        break;

                    //  等待進入最小/大值
                    case CALI_WAIT:
                        Debug.WriteLine("Calibration Process: CALI_WAIT");
                        Stopwatch sw = new Stopwatch();
                        sw.Reset();
                        sw.Start();
                        for (int i = 0; i < 100000000; i++) // nEntries is typically more than 500,000  
                        {
                            if(Cali_idx != CALI_WAIT)
                            {
                                break;
                            }

                            //Debug.WriteLine("等待回應");
                            if (sw.ElapsedMilliseconds > 2000) // 2秒內未回應則跳出
                            {
                                Cali_idx = -1;
                                break;
                            }
                        }
                        break;

                    // 雷射校正 最小值
                    case CALI_MIN:
                        Debug.WriteLine("Calibration Process: CALI_MIN");
                        string Min = Interaction.InputBox("請將雷射感測器移動至顯示小於0之位置，待穩定後輸入感測器上顯示之數值", "雷射感測器校正", "0", -1, -1);
                        TestState_lb.Text = "雷射感測器負值校正中";

                        if(Min.Length <= 0)
                        {
                            Debug.WriteLine("Cancel");
                            Cali_idx = CALI_FAIL;
                            break;
                        }

                        if (float.TryParse(Min, out float min) && min < 0 && min > -15.5)
                        {   
                            string min_v = min.ToString("F2");
                            Debug.WriteLine($"校正負值: {min_v}");
                            rcv_tb.AppendText($"校正負值: {min_v}\r\n");
                            SerialSend(LaserDevice_Port, min_v);
                            Cali_idx = CALI_WAIT;
                        }
                        else
                        {
                            MessageBox.Show("輸入數值錯誤，請重新輸入\r\n注意：數值需小於0且大於-15.5，", "雷射感測器校正", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        break;

                    // 雷射校正 最大值
                    case CALI_MAX:
                        Debug.WriteLine("Calibration Process: CALI_MAX");
                        string Max = Interaction.InputBox("請將雷射感測器移動至顯示大於0之位置，待穩定後輸入感測器上顯示之數值", "雷射感測器校正", "0", -1, -1);
                        TestState_lb.Text = "雷射感測器正值校正中";

                        if (Max.Length <= 0)
                        {
                            Debug.WriteLine("Cancel");
                            Cali_idx = CALI_FAIL;
                            break;
                        }

                        if (float.TryParse(Max, out float max) && max > 0 && max < 15.5)
                        {
                            string max_v = max.ToString("F2");
                            Debug.WriteLine($"校正正值: {max_v}");
                            rcv_tb.AppendText($"校正正值: {max}\r\n");
                            SerialSend(LaserDevice_Port, max_v);
                            Cali_idx = CALI_WAIT;
                        }
                        else
                        {
                            MessageBox.Show("輸入錯誤，請重新輸入\r\n注意：數值需大於0且小於15.5", "雷射感測器校正", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    
                    case CALI_DONE:
                        Debug.WriteLine("Calibration Process: CALI_DONE");
                        MessageBox.Show("雷射感測器校正完成", "雷射感測器校正", MessageBoxButtons.OK);
                        TestState_lb.Text = "雷射感測器校正完成";
                        return;
                }
            }
        }

        private void exp2csv_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rcv_tb.Text))
            {
                MessageBox.Show("量測資料為空", "匯出錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fn = $"{LicensePlate_tb.Text}_{DateTime.Now.ToString("MMddHHmm")}.csv";
            SaveFileDialog saveCSV = new SaveFileDialog();
            //saveCSV.Filter = "Textfile|*.txt|Comma-Separated Values|*.csv";
            saveCSV.Filter = "Comma-Separated Values|*.csv";
            saveCSV.Title = "匯出";
            //saveCSV.InitialDirectory = $@"{Environment.CurrentDirectory}\Result\";
            saveCSV.FileName = fn;
            saveCSV.AddExtension = true;
            saveCSV.CheckPathExists = true;
            //saveCSV.ShowDialog();
            if (saveCSV.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveCSV.FileName);
                switch (saveCSV.FilterIndex)
                {
                    case 1:
                        //Debug.WriteLine("txt"); 
                        streamWriter.Write(rcv_tb.Text);
                        break;

                    case 2:
                        //Debug.WriteLine("csv");
                        streamWriter.Write(rcv_tb.Text);
                        break;
                }
                streamWriter.Close();
            }
            else
                Debug.WriteLine("Save File Cancel");
        }

        #region Serial Function
        private void GetComPort()
        {
            string[] names = SerialPort.GetPortNames();
            COM_cb.Items.Clear();
            COM_cb.Text = string.Empty;
            foreach (string s in names)
            {
                COM_cb.Items.Add(s);
            }

            if (names.Length > 0)
            {
                COM_cb.SelectedIndex = 0;
            }

            if (LaserDevice_Port.IsOpen)
            {
                COM_cb.Text = LaserDevice_Port.PortName;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_DEVICECHANGE = 0x219; //設備改變
            const int DBT_DEVICEARRIVAL = 0x8000; //檢測到新設備
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //移除設備
            //const int DBT_DEVTYP_CommonPort = 0x00000003;
            base.WndProc(ref m);//調用父類方法，以確保其他功能正常
            switch (m.Msg)
            {
                case WM_DEVICECHANGE://設備改變事件
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            //int dbccSize = Marshal.ReadInt32(m.LParam, 0);
                            //int devType = Marshal.ReadInt32(m.LParam, 4);                            
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            if (!LaserDevice_Port.IsOpen)
                            {
                                LaserDevice_Port.Close();
                                LaserDevice_Port.DataReceived -= new SerialDataReceivedEventHandler(LaserDevice_DataReceived);
                                COM_Connect_btn.BackColor = Control.DefaultBackColor;
                                COM_Connect_btn.Text = "開啟";
                                State_init();
                            }
                            break;
                    }
                    //刷新串口設備
                    GetComPort();
                    break;
            }
        }

        public void SerialSend(SerialPort Port, string message)
        {
            if (Port.IsOpen)
            {
                Thread SendData = new Thread(
                    delegate ()
                    {
                        Port.Write(message + "\r\n");
                    });
                SendData.Start();
            }
            else 
                return;
        }
        #endregion

        private void clear_tb_btn_Click(object sender, EventArgs e)
        {
            rcv_tb.Clear();
        }

        private void SetLimit_button_Click(object sender, EventArgs e)
        {
            Thread SetLimit = new Thread(
            delegate ()
            {
                float u, l;
                if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                {
                    if (u <= l)
                    {
                        MessageBox.Show("上限值不可小於或等於下限值", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Uplimit_tb.Text = u.ToString("##0.00");
                    Downlimit_tb.Text = l.ToString("##0.00");
                    SerialSend(LaserDevice_Port, "uplimit " + u.ToString("##0.00"));
                    CheckUpdate_Up = true;
                    Thread.Sleep(200);
                    SerialSend(LaserDevice_Port, "lowlimit " + l.ToString("##0.00"));
                    CheckUpdate_Low = true;

                    if(CheckLimitUpdate())
                        MessageBox.Show("設定完成", "上下限設置");
                    else
                        MessageBox.Show("設定失敗，請確認設定值後再試一次", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("上下限值錯誤，請確認輸入為數字", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            });
            SetLimit.Start();                        
        }

        private bool CheckLimitUpdate()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000000; i++) // nEntries is typically more than 500,000
            {
                //Debug.WriteLine("等待回應");
                if (UpdateCompleteLow && UpdateCompleteUp)
                {
                    UpdateCompleteUp = false;
                    UpdateCompleteLow = false;
                    return true;
                }

                if (sw.ElapsedMilliseconds > 2000)
                {
                    break;
                }
            }
            return false;
        }

        private void State_init()
        {
            TestState_lb.Text = "未開始";
            Uplimit_tb.Text = string.Empty;
            Downlimit_tb.Text = string.Empty;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ImportCSV_btn_Click(object sender, EventArgs e)
        {
            float u, l;
            if (string.IsNullOrEmpty(Uplimit_tb.Text) || string.IsNullOrEmpty(Downlimit_tb.Text))
            {
                MessageBox.Show("上下限值不可為空", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                {
                    if (u <= l)
                    {
                        MessageBox.Show("上限值不可小於或等於下限值", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("上下限值輸入錯誤", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            rcv_tb.Clear();
            // 建立一個OpenFileDialog物件
            OpenFileDialog OFD = new OpenFileDialog();

            // 設定OpenFileDialog屬性
            OFD.Title = "選擇要開啟的CSV檔案";
            //OFD.InitialDirectory = $@"{Environment.CurrentDirectory}\Result\";
            OFD.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            OFD.FilterIndex = 1;
            OFD.Multiselect = true;

            // 喚用ShowDialog方法，打開對話方塊

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string theFile = OFD.FileName; //取得檔名
                                                   //Encoding enc = Encoding.GetEncoding("big5"); //設定檔案的編碼
                    string[] readText = System.IO.File.ReadAllLines(theFile, Encoding.Default); //以指定的編碼方式讀取檔案
                    foreach (string s in readText)
                    {
                        rcv_tb.AppendText(s + "\r\n");
                    }

                    if (result == null || result.IsDisposed)
                    {
                        //result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                        //result.Show();

                        // 更改為直接輸出pdf後開啟
                        Result r = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                        r.CreatePDF_WithoutForm();
                    }
                }
                catch (Exception ex)
                {
                    rcv_tb.Clear();
                    MessageBox.Show("匯入失敗，請確認檔案格式正確", "匯入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void NewResult_btn_Click(object sender, EventArgs e)
        {
            if (SensorProcess_idx ==-1 || SensorProcess_idx == 0 || SensorProcess_idx == 1)
            {
                MessageBox.Show("量測中，請先停止量測", "量測結果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float u, l;
            if (string.IsNullOrEmpty(rcv_tb.Text))
            {
                MessageBox.Show("量測資料為空", "量測結果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(Uplimit_tb.Text) || string.IsNullOrEmpty(Downlimit_tb.Text))
            {
                MessageBox.Show("上下限值不可為空", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                {
                    if (u <= l)
                    {
                        MessageBox.Show("上限值不可小於或等於下限值", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("上下限值輸入錯誤", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (result == null || result.IsDisposed)
            {
                //result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                //result.Show();

                // 更改為直接輸出pdf後開啟
                Result r = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                r.CreatePDF_WithoutForm();
            }
            return;
        }

        #region Debug

        private void StartRead_button_Click(object sender, EventArgs e)
        {
            float u, l;
            if(!LaserDevice_Port.IsOpen)
            {
                MessageBox.Show("設備尚未連接", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
            {
                if(u <= l)
                {
                    MessageBox.Show("上限值不可小於或等於下限值", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
            }
            else
            {
                MessageBox.Show("上下限值輸入錯誤", "上下限值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (SensorProcess_idx == -2 || SensorProcess_idx == 2)
            {
                rcv_tb.Clear();
                SensorProcess_idx = -1;
                SerialSend(LaserDevice_Port, "start");
            }
        }

        private void StopRead_button_Click(object sender, EventArgs e)
        {
            if (!LaserDevice_Port.IsOpen)
            {
                MessageBox.Show("設備尚未連接", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SensorProcess_idx = 2;
            SerialSend(LaserDevice_Port, "stop");
        }

        private void GetSensor_button_Click(object sender, EventArgs e)
        {
            SerialSend(LaserDevice_Port, "getsensor");
        }

        private void Read_button_Click(object sender, EventArgs e)
        {
            SerialSend(LaserDevice_Port, "R");
        }

        private void BuzzOn_button_Click(object sender, EventArgs e)
        {
            SerialSend(LaserDevice_Port, "alarm 1");
        }

        private void BuzzOff_button_Click(object sender, EventArgs e)
        {
            if (!LaserDevice_Port.IsOpen)
            {
                MessageBox.Show("設備尚未連接", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SerialSend(LaserDevice_Port, "alarm 0");
        }

        #endregion

        private void Limit_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Thread SetLimit = new Thread(
                delegate ()
                {
                    float u, l;
                    if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                    {
                        if(u <= l)
                        {
                            MessageBox.Show("上限值不可小於或等於下限值", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Uplimit_tb.Text = u.ToString("##0.00");
                        Downlimit_tb.Text = l.ToString("##0.00");
                        SerialSend(LaserDevice_Port, "uplimit " + u.ToString("##0.00"));
                        CheckUpdate_Up = true;
                        Thread.Sleep(200);
                        SerialSend(LaserDevice_Port, "lowlimit " + l.ToString("##0.00"));
                        CheckUpdate_Low = true;

                        if (CheckLimitUpdate())
                            MessageBox.Show("設定完成", "上下限設置");
                        else
                            MessageBox.Show("設定失敗，請確認設定值後再試一次", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("上下限值錯誤，請確認輸入為數字", "上下限設置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                });
                SetLimit.Start();
            }
        }

        private void LaserCali_btn_Click(object sender, EventArgs e)
        {
            // 若當前為未量測狀態
            if (SensorProcess_idx != -2)
            {
                MessageBox.Show("請先停止量測再進行校正", "雷射感測器校正", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { 
                if (!LaserDevice_Port.IsOpen)
                {
                    MessageBox.Show("設備尚未連接", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("是否執行雷射感測器校正？", "雷射感測器校正", buttons);
                if (result == DialogResult.Yes)
                {
                    Thread Cali_Thread = new Thread(delegate ()
                    {
                        CalibrationProcess();
                    });
                    Cali_Thread.Start();
                }
                return;
            }
        }
    }
}
