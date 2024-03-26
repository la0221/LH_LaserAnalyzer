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
        MainProcess mainProcess = new MainProcess();
        private int PreSensorState = -1;
        private int SensorState = -1;
        private int StartSensor = 0;
        private int SensorProcess_idx = -2;
        private bool CheckUpdate_Up = false;
        private bool CheckUpdate_Low = false;
        private bool UpdateCompleteUp = false;
        private bool UpdateCompleteLow = false;
        private bool TestDone = false;
        private Form result = null;
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
            if(COM_cb.Text == "Result")
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
                    //if (TestDone)
                    //{
                    //    Thread GetResult = new Thread(delegate ()
                    //    {
                    //        result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                    //        result.Show();
                    //    });
                    //    GetResult.SetApartmentState(ApartmentState.STA);
                    //    GetResult.Start();
                    //}
                    //SensorProcess_idx 
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

                        TestDone = true;                        
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

        private void exp2csv_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rcv_tb.Text))
            {
                MessageBox.Show("量測資料為空", "錯誤");
                return;
            }

            string fn = $"{LicensePlate_tb.Text}_{DateTime.Now.ToString("yyyyMMdd")}.csv";
            SaveFileDialog saveCSV = new SaveFileDialog();
            //saveCSV.Filter = "Textfile|*.txt|Comma-Separated Values|*.csv";
            saveCSV.Filter = "Comma-Separated Values|*.csv";
            saveCSV.Title = "匯出";
            saveCSV.FileName = fn;
            saveCSV.AddExtension = true;
            saveCSV.CheckPathExists = true;
            //saveCSV.ShowDialog();
            if (saveCSV.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveCSV.FileName);
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
                    if (u < l)
                    {
                        MessageBox.Show("上限值不可小於下限值", "錯誤");
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
                        MessageBox.Show("設定完成");
                    else
                        MessageBox.Show("設定失敗，請確認設定值後再試一次");
                }
                else
                {
                    MessageBox.Show("參數錯誤，請確認輸入");
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
                MessageBox.Show("上下限值不可為空", "錯誤");
                return;
            }
            else
            {
                if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                {
                    if (u < l)
                    {
                        MessageBox.Show("上限值不可小於下限值", "錯誤");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("上下限值輸入錯誤", "錯誤");
                    return;
                }
            }

            rcv_tb.Clear();
            // 建立一個OpenFileDialog物件
            OpenFileDialog OFD = new OpenFileDialog();

            // 設定OpenFileDialog屬性
            OFD.Title = "選擇要開啟的CSV檔案";
            OFD.InitialDirectory = $@"{Environment.CurrentDirectory}\Result\";
            OFD.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            OFD.FilterIndex = 1;
            OFD.Multiselect = true;

            // 喚用ShowDialog方法，打開對話方塊

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                    result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                    result.Show();
                }
            }
        }

        private void NewResult_btn_Click(object sender, EventArgs e)
        {
            //result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, "2.05", "0.5", rcv_tb.Text);
            //result.Show();
            //return;

            if (SensorProcess_idx ==-1 || SensorProcess_idx == 0 || SensorProcess_idx == 1)
            {
                MessageBox.Show("量測中，請先停止量測", "錯誤");
                return;
            }

            float u, l;
            if (string.IsNullOrEmpty(rcv_tb.Text))
            {
                MessageBox.Show("量測資料為空", "錯誤");
                return;
            }
            else if (string.IsNullOrEmpty(Uplimit_tb.Text) || string.IsNullOrEmpty(Downlimit_tb.Text))
            {
                MessageBox.Show("上下限值不可為空", "錯誤");
                return;
            }
            else 
            {
                if (float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
                {
                    if (u < l)
                    {
                        MessageBox.Show("上限值不可小於下限值", "錯誤");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("上下限值輸入錯誤", "錯誤");
                    return;
                }
            }

            if (result == null || result.IsDisposed)
            {
                result = new Result(Department_tb.Text, LicensePlate_tb.Text, ProjectNo_tb.Text, StartPlace_tb.Text, Uplimit_tb.Text, Downlimit_tb.Text, rcv_tb.Text);
                result.Show();
            }
            return;
        }

        #region 即時繪置折線圖

        /// <summary>
        /// 初始化圖表
        /// </summary>
        //private void InitChart()
        //{
        //    //定義圖表區域
        //    this.Result_chart.ChartAreas.Clear();
        //    ChartArea chartArea1 = new ChartArea("C1");
        //    this.Result_chart.ChartAreas.Add(chartArea1);
        //    //定義存儲和顯示點的容器
        //    this.Result_chart.Series.Clear();
        //    Series series1 = new Series("S1");
        //    series1.ChartArea = "C1";
        //    series1.MarkerStyle = MarkerStyle.Circle;
        //    this.Result_chart.Series.Add(series1);
        //    //設置圖表顯示樣式
        //    this.Result_chart.ChartAreas[0].AxisY.Minimum = 0;
        //    this.Result_chart.ChartAreas[0].AxisY.Maximum = 100;
        //    this.Result_chart.ChartAreas[0].AxisX.Interval = 5;
        //    this.Result_chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
        //    this.Result_chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
        //    //設置標題
        //    this.Result_chart.Titles.Clear();
        //    this.Result_chart.Titles.Add("S01");
        //    this.Result_chart.Titles[0].Text = "XXX顯示";
        //    this.Result_chart.Titles[0].ForeColor = Color.RoyalBlue;
        //    this.Result_chart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
        //    //設置圖表顯示樣式
        //    this.Result_chart.Series[0].Color = Color.Red;
        //    if (true)
        //    {
        //        this.Result_chart.Titles[0].Text = "折線圖";
        //        this.Result_chart.Series[0].ChartType = SeriesChartType.Line;
        //    }
        //    this.Result_chart.Series[0].Points.Clear();
        //}

        ////更新隊列中的值
        //private void UpdateQueueValue(double v)
        //{

        //}

        //private void UpdateChart(double v)
        //{
        //    this.Result_chart.Series[0].Points.AddXY(0, v);
        //}

        //private void Result_chart_MouseMove(object sender, MouseEventArgs e)
        //{
        //    HitTestResult mytestresult = Result_chart.HitTest(e.X, e.Y);
        //    if (true/*e.Button == MouseButtons.Left*/)//判断是否是鼠标左键点击
        //    {
        //        if (mytestresult.ChartElementType == ChartElementType.DataPoint)//判断我们点击这个返回集是否是chart的数据点的类型
        //        {
        //            toolTip1.AutoPopDelay = 5000;//表示tooltip在这个控件中保留展示的时间
        //            toolTip1.InitialDelay = 1000;//表示鼠标指针必须在这里静止的时间
        //            toolTip1.ReshowDelay = 500;//可以缩短或延长在显示上一个工具提示窗口后显示工具提示窗口之前等待的时间tooltip
        //            toolTip1.ShowAlways = true;//获取或设置一个值，该值指示是否显示工具提示窗口，甚至是在其父控件不活动的时候。

        //            try
        //            {
        //                toolTip1.SetToolTip(Result_chart, "名稱：" + mytestresult.Series.Name + "\r\n" + "值：" + Result_chart.Series[0].Points[mytestresult.PointIndex]);//设置ToolTip展示的值的内容，mytestresult.Series.Name表示折线的名字，chart1.Series[0].Points[mytestresult.PointIndex]表示chart图表中的第0（从0开始也就是第一条）条折线的数据点的第多少个，
        //                                                                                                                                                             //也可以设置chart1.Series[0].Points[mytestresult.PointIndex].XValue;这个代表你点击这个点的x轴的值，chart1.Series[0].Points[mytestresult.PointIndex].YValues[0];这个代表你点击的点Y轴的值
        //            }
        //            catch (Exception)
        //            {

        //            }
        //        }
        //    }
        //}
        #endregion

        #region Debug

        private void StartRead_button_Click(object sender, EventArgs e)
        {
            float u, l;
            if(!LaserDevice_Port.IsOpen)
            {
                MessageBox.Show("設備尚未連接", "連線錯誤");
                return;
            }
            if(float.TryParse(Uplimit_tb.Text, out u) && float.TryParse(Downlimit_tb.Text, out l))
            {
                if(u < l)
                {
                    MessageBox.Show("上限值不可小於下限值", "錯誤");
                    return;
                }                
            }
            else
            {
                MessageBox.Show("上下限值輸入錯誤", "錯誤");
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
                MessageBox.Show("設備尚未連接", "連線錯誤");
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
                MessageBox.Show("設備尚未連接", "連線錯誤");
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
                        if(u<l)
                        {
                            MessageBox.Show("上限值不可小於下限值", "錯誤");
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
                            MessageBox.Show("設定完成");
                        else
                            MessageBox.Show("設定失敗，請確認設定值後再試一次");
                    }
                    else
                    {
                        MessageBox.Show("參數錯誤，請確認輸入");
                        return;
                    }
                });
                SetLimit.Start();
            }
        }
    }
}
