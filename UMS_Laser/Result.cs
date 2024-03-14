using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using static UMS_Laser.Result;
using System.Drawing.Imaging;
using System.Threading;

namespace UMS_Laser
{
    public partial class Result : Form
    {
        private float UpLimit = 0;
        private float DownLimit = 0;
        List<DateTime> DT1 = new List<DateTime>();
        List<DateTime> DT2 = new List<DateTime>();
        List<DateTime> DT3 = new List<DateTime>();
        List<DateTime> DT4 = new List<DateTime>();
        List<float> S1_value = new List<float>();
        List<float> S2_value = new List<float>();
        List<float> S3_value = new List<float>();
        List<float> S4_value = new List<float>();

        public Result(string dept, string lic_plate, string proj_number, string st_place, string up_limit, string down_limit, string data)
        {
            InitializeComponent();

            // Initialize test data
            Department_lb.Text = dept;
            LicensePlate_lb.Text = lic_plate;
            ProjectNum_lb.Text = proj_number;
            StartPlace_lb.Text = st_place;
            UpDownLimit_lb.Text = $"{up_limit} mm\r\n{down_limit} mm";
            UpLimit = float.Parse(up_limit);
            DownLimit = float.Parse(down_limit);

            Get_SectionData(data);  // 取得所有資料
            TestTime_lb.Text = $"{DT1[0]}\r\n~{DT4[DT4.Count - 1]}";// 填入量測時間

            // Initialize the DataGridView            
            Result_dgv.Rows.Add(3);
            Result_dgv.Rows[0].Cells[0].Value = "S1";
            Result_dgv.Rows[1].Cells[0].Value = "S2";
            Result_dgv.Rows[2].Cells[0].Value = "S3";
            Result_dgv.Rows[3].Cells[0].Value = "S4";

            // 產生圖表
            DrawChart(1, DT1, S1_value);
            DrawChart(2, DT2, S2_value);
            DrawChart(3, DT3, S3_value);
            DrawChart(4, DT4, S4_value);

            // 檢查測試結果
            CheckAll_OKNG();

            // Auto resize rows and columns of the DataGridView
            Result_dgv.AutoResizeRows();
            Result_dgv.AutoResizeColumns();

            //DemoChart(1, DT1, S1_value);
        }

        /// <summary>
        /// 解析Sensor1~4的資料
        /// </summary>
        /// <param name="data"></param>
        private void Get_SectionData(string data)
        {
            string[] RawSplit = data.Split('\n'); // 取出每行資料
            foreach (string line in RawSplit)
            {
                string[] Split = line.Split(','); // 取出每個欄位資料(時間,數值,感測器編號)
                Debug.Print(line + "\r\n");
                if (Split.Length == 3)
                {
                    DateTime date = DateTime.ParseExact(Split[0].Trim(), "MM-dd HH:mm:ss.fff", null);
                    string value = Split[1].Trim();
                    string sensor = Split[2].Trim();
                    if (sensor == "1")
                    {
                        DT1.Add(date);
                        S1_value.Add(float.Parse(value));
                    }
                    else if (sensor == "2")
                    {
                        DT2.Add(date);
                        S2_value.Add(float.Parse(value));
                    }
                    else if (sensor == "3")
                    {
                        DT3.Add(date);
                        S3_value.Add(float.Parse(value));
                    }
                    else if (sensor == "4")
                    {
                        DT4.Add(date);
                        S4_value.Add(float.Parse(value));
                    }
                }
            }
            Debug.Print($"DT1 Count: {DT1.Count}");
            Debug.Print($"S1 Value Count: {S1_value.Count}");
            Debug.Print($"DT2 Count: {DT2.Count}");
            Debug.Print($"S2 Value Count: {S2_value.Count}");
            Debug.Print($"DT3 Count: {DT3.Count}");
            Debug.Print($"S3 Value Count: {S3_value.Count}");
            Debug.Print($"DT4 Count: {DT4.Count}");
            Debug.Print($"S4 Value Count: {S4_value.Count}");
            Debug.Print("GetSectionData Done...\r\n");
        }

        private void DrawChart(int section, List<DateTime> DT, List<float> value)
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.Size = new Size(800, 150);
            chart.Series.Add(new Series());
            chart.ChartAreas.Add(new ChartArea());
            Series series = chart.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss.fff";
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Milliseconds;
            //chart.ChartAreas[0].AxisX.Interval = 1000;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart.ChartAreas[0].AxisX.Minimum = DT[0].ToOADate();                        // 設置X軸最小值
            chart.ChartAreas[0].AxisX.Maximum = DT[DT.Count - 1].ToOADate(); // 設置X軸最大值
            chart.Series[0].Points.DataBindXY(DT, value);

            // Draw Up Down Limit Line
            StripLine UPL = new StripLine();
            UPL.IntervalOffset = UpLimit;
            UPL.Interval = 0;
            UPL.StripWidth = 0.04;
            UPL.BackColor = Color.Red;
            UPL.BorderDashStyle = ChartDashStyle.DashDot;
            chart.ChartAreas[0].AxisY.StripLines.Add(UPL);

            StripLine DOWNL = new StripLine();
            DOWNL.IntervalOffset = DownLimit;
            DOWNL.Interval = 0;
            DOWNL.StripWidth = 0.04;
            DOWNL.BackColor = Color.Red;
            chart.ChartAreas[0].AxisY.StripLines.Add(DOWNL);

            // Create a bitmap with the same size as the chart
            Bitmap bitmap = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bitmap, new Rectangle(0, 0, chart.Width, chart.Height));

            // Set the bitmap as the value of a specific cell in the DataGridView
            Result_dgv.Rows[section - 1].Cells[1].Value = bitmap;
        }

        private bool CheckSingle_OKNG(List<float> value)
        {
            foreach (float v in value)
            {
                if (v > UpLimit)
                    return false;
                if (v < DownLimit)
                    return false;
            }
            return true;
        }

        private void CheckAll_OKNG()
        {
            Result_dgv.Rows[0].Cells[2].Value = CheckSingle_OKNG(S1_value) ? "OK" : "NG";
            Result_dgv.Rows[1].Cells[2].Value = CheckSingle_OKNG(S2_value) ? "OK" : "NG";
            Result_dgv.Rows[2].Cells[2].Value = CheckSingle_OKNG(S3_value) ? "OK" : "NG";
            Result_dgv.Rows[3].Cells[2].Value = CheckSingle_OKNG(S4_value) ? "OK" : "NG";
        }

        private void DemoChart(int section, List<DateTime> DT, List<float> value)
        {
            Chart chart_test = new Chart();
            chart_test.Series.Add(new Series());
            chart_test.ChartAreas.Add(new ChartArea());
            Series series = chart_test.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;

            chart_test.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss.fff";
            chart_test.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Milliseconds;
            chart_test.ChartAreas[0].AxisX.Interval = 1000;
            chart_test.ChartAreas[0].AxisX.Minimum = DT[0].ToOADate();                        // 設置X軸最小值
            chart_test.ChartAreas[0].AxisX.Maximum = DT[DT.Count - 1].ToOADate(); // 設置X軸最大值
            chart_test.Series[0].Points.DataBindXY(DT, value);

            StripLine stripLine = new StripLine();
            stripLine.IntervalOffset = UpLimit;
            stripLine.Interval = 0;
            stripLine.StripWidth = 0.05;
            stripLine.BackColor = Color.Red;
            stripLine.BorderDashStyle = ChartDashStyle.Dash;
            chart_test.ChartAreas[0].AxisY.StripLines.Add(stripLine);

            StripLine DOWNL = new StripLine();
            DOWNL.IntervalOffset = DownLimit;
            DOWNL.Interval = 0;
            DOWNL.StripWidth = 0.05;
            DOWNL.BackColor = Color.Red;
            DOWNL.BorderDashStyle = ChartDashStyle.Dash;
            chart_test.ChartAreas[0].AxisY.StripLines.Add(DOWNL);


            Debug.Print($"W:{chart_test.Width}, H{chart_test.Height}");
            // Create a bitmap with the same size as the chart
            //Bitmap bitmap = new Bitmap(chart_test.Width, chart_test.Height);
            //chart_test.DrawToBitmap(bitmap, new Rectangle(0, 0, chart_test.Width, chart_test.Height));

            //// Set the bitmap as the value of a specific cell in the DataGridView
            //Result_dgv.Rows[section - 1].Cells[1].Value = bitmap;
        }
        #region Screenshot(Not in use)
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        public Bitmap PrintWindow(IntPtr hwnd)
        {
            RECT rc;
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Right - rc.Left, rc.Bottom - rc.Top, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            PrintWindow(hwnd, hdcBitmap, 0);
            int wid = this.ClientSize.Width;
            int hgt = this.ClientSize.Height;
            Bitmap bmp2 = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(bmp, 0, 0, new Rectangle(rc.Right - rc.Left, rc.Bottom - rc.Top, wid, hgt),
                    GraphicsUnit.Pixel);
            }

            string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMdd")}{LicensePlate_lb.Text}.jpg";
            bmp2.Save(path);

            return bmp;
        }
        #endregion

        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }
        // Return the form's image without its borders and decorations.
        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            // Get the form's whole image.
            using (Bitmap whole_form = GetControlImage(frm))
            {
                // See how far the form's upper left corner is
                // from the upper left corner of its client area.
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                // Copy the client area into a new Bitmap.
                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }

                string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMdd")}{LicensePlate_lb.Text}.jpg";
                bm.Save(path);

                return bm;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            //SetForegroundWindow(this.Handle);
            //PrintWindow(GetForegroundWindow());
            GetFormImageWithoutBorders(this);
        }

        private void Result_Load(object sender, EventArgs e)
        {
            label1.Select();
        }
    }
}
