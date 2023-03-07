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

namespace UMS_IoT
{
    public partial class Main : Form
    {
        private Queue<double> dataQueue = new Queue<double>(100);
        SerialPort IoT_Device_Port = new SerialPort();
        Thread GetBatVoltage_thread;
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();  
            GetComPort();
            GetBatVoltage_thread = new Thread(new ThreadStart(GetBatVoltage));
            GetBatVoltage_thread.Start();
        }

        void GetBatVoltage()
        {
            while (true)
            {
                if (IoT_Device_Port.IsOpen)
                {
                    //Debug.WriteLine("Get Bat Voltage");
                    SerialSend(IoT_Device_Port, "V");
                    Thread.Sleep(30000);
                }
            }
        }

        private void COM_Connect_btn_Click(object sender, EventArgs e)
        {
            if (IoT_Device_Port.IsOpen)
            {
                try
                {
                    IoT_Device_Port.Close();
                    COM_Connect_btn.BackColor = Control.DefaultBackColor;
                    COM_Connect_btn.Text = "開啟";
                    IoT_Device_Port.DataReceived -= new SerialDataReceivedEventHandler(IoT_Device_DataReceived);
                    return;
                }
                catch (Exception disconn)
                {
                    MessageBox.Show(disconn.ToString());
                }
            }
            else if (!string.IsNullOrEmpty(COM_ComportBox.Text) && !IoT_Device_Port.IsOpen)
            {
                try
                {
                    //ComPort設定
                    IoT_Device_Port.PortName = COM_ComportBox.Text;
                    IoT_Device_Port.BaudRate = 9600;
                    IoT_Device_Port.StopBits = StopBits.One;
                    IoT_Device_Port.Parity = Parity.None;
                    IoT_Device_Port.ReadTimeout = 300;
                    IoT_Device_Port.Handshake = Handshake.None;
                    IoT_Device_Port.Open();
                    IoT_Device_Port.DataReceived += new SerialDataReceivedEventHandler(IoT_Device_DataReceived);
                    COM_Connect_btn.BackColor = Color.LightGreen;
                    COM_Connect_btn.Text = "關閉";

                    Thread.Sleep(100);
                    SerialSend(IoT_Device_Port, "T");
                }
                catch (Exception conn)
                {
                    MessageBox.Show(conn.ToString());
                }
            }
        }

        private void IoT_Device_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10);  //（毫秒）等待一定時間，確保資料的完整性 int len      
            if (IoT_Device_Port.IsOpen)
            {
                int len = IoT_Device_Port.BytesToRead;
                if (len != 0)
                {
                    byte[] buff = new byte[len];
                    IoT_Device_Port.Read(buff, 0, len);
                    string rcv = Encoding.Default.GetString(buff);
                    Debug.WriteLine("Receive: " + rcv.Trim());
                    // 指令、電量回傳
                    if(rcv.Contains("BTNC"))
                    {
                        BT_stat_lb.ForeColor = Color.Red;
                        BT_stat_lb.Text = "未連線";
                    }

                    else if (rcv.Contains("BTC"))
                    {
                        BT_stat_lb.ForeColor = Color.LimeGreen;
                        BT_stat_lb.Text = "已連線";
                    }

                    else if(rcv.Contains("BV"))
                    {
                        BatVol_lb.Text = rcv.Trim().Remove(0, 2) + "V"; 
                    }

                    // 千分表數據
                    else if(rcv.Contains(',') && rcv.Split(',')[1].Contains("-1")) // sensor尚未偵測
                        return;
                    else
                        rcv_textBox.AppendText(DateTime.Now.ToString("MM-dd hh:mm:ss.fff") + ", " + rcv);
                }
            }
        }

        private void GetComPort()
        {
            string[] names = SerialPort.GetPortNames();
            COM_ComportBox.Items.Clear();
            COM_ComportBox.Text = string.Empty;
            foreach (string s in names)
            {
                COM_ComportBox.Items.Add(s);
            }

            if (names.Length > 0)
            {
                COM_ComportBox.SelectedIndex = 0;
            }

            if (IoT_Device_Port.IsOpen)
            {
                COM_ComportBox.Text = IoT_Device_Port.PortName;
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
                            if (!IoT_Device_Port.IsOpen)
                            {
                                IoT_Device_Port.Close();
                                IoT_Device_Port.DataReceived -= new SerialDataReceivedEventHandler(IoT_Device_DataReceived);
                                COM_Connect_btn.BackColor = Control.DefaultBackColor;
                                COM_Connect_btn.Text = "開啟";
                            }
                            break;
                    }
                    //刷新串口設備
                    GetComPort();
                    break;
            }
        }

        private void exp2csv_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCSV = new SaveFileDialog();
            saveCSV.Filter = "Textfile|*.txt|Comma-Separated Values|*.csv";
            saveCSV.Title = "Save Data";
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
                        streamWriter.Write(rcv_textBox.Text);
                        break;

                    case 2:
                        //Debug.WriteLine("csv");
                        streamWriter.Write(rcv_textBox.Text);
                        break;
                }
                streamWriter.Close();
            }
            else
                Debug.WriteLine("Save File Cancel");
        }

        public void SerialSend(SerialPort Port, string message)
        {
            if (Port.IsOpen)
            {
                Thread SendData = new Thread(
                    delegate ()
                    {
                        Port.Write(message+"\r\n");
                    });
                SendData.Start();
            }
            else return;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
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

        private void clear_tb_btn_Click(object sender, EventArgs e)
        {
            rcv_textBox.Clear();
        }

        private void StartRead_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "K");
        }

        private void StopRead_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "S");
        }

        private void GetBatV_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "V");
        }

        private void GetSensor_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "G");
        }

        private void Read_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "R");
        }

        private void BuzzOn_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "A1");
        }

        private void BuzzOff_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "A0");
        }

        private void BT_Stat_button_Click(object sender, EventArgs e)
        {
            SerialSend(IoT_Device_Port, "T");
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
