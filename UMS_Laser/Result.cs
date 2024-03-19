using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace UMS_Laser
{
    public partial class Result : Form
    {
        private float UpLimit = 0;
        private float DownLimit = 0;
        private DateTime st_time, ed_time;
        private iTextSharp.text.Image[] img = new iTextSharp.text.Image[4];
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

            // 填入量測時間
            TestTime_lb.Text = $"{st_time}\r\n~{ed_time}";
            //if (DT4.Count != 0)
            //    TestTime_lb.Text = $"{DT1[0]}\r\n~{DT4[DT4.Count - 1]}";
            //else if(DT3.Count != 0)
            //    TestTime_lb.Text = $"{DT1[0]}\r\n~{DT3[DT3.Count - 1]}";
            //else if(DT2.Count != 0)
            //    TestTime_lb.Text = $"{DT1[0]}\r\n~{DT2[DT2.Count - 1]}";
            //else
            //    TestTime_lb.Text = $"{DT1[0]}\r\n~{DT1[DT1.Count - 1]}";

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

            //GetFormImageWithoutBorders(this);
        }

        /// <summary>
        /// 解析Sensor1~4的資料
        /// </summary>
        /// <param name="data"></param>
        private void Get_SectionData(string data)
        {
            string[] RawSplit = data.Split('\n'); // 取出每行資料
            st_time = DateTime.ParseExact(RawSplit[0].Split(',')[0].Trim(), "MM-dd HH:mm:ss.fff", null);
            ed_time = DateTime.ParseExact(RawSplit[RawSplit.Length-2].Split(',')[0].Trim(), "MM-dd HH:mm:ss.fff", null);
            foreach (string line in RawSplit)
            {
                string[] Split = line.Split(','); // 取出每個欄位資料(時間,數值,感測器編號)
                Debug.Print(line + "\r\n");
                if (Split.Length == 3)
                {
                    try
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
                        else
                        {

                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Get_SectionData(): " + e.Message);
                        Debug.Print(e.Message);
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

        private Chart DrawChart(int section, List<DateTime> DT, List<float> value)
        {
            if(DT.Count == 0 || value.Count == 0)
            {
                Result_dgv.Rows[section - 1].Cells[1].Value = new Bitmap(1, 1);
                return new Chart();
            }

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.Size = new Size(800, 150);
            chart.Series.Add(new Series());
            chart.ChartAreas.Add(new ChartArea());
            Series series = chart.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;
            
            // X軸設定
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss.fff";
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Milliseconds;
            //chart.ChartAreas[0].AxisX.Interval = 1000;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart.ChartAreas[0].AxisX.Minimum = DT[0].ToOADate();                        // 設置X軸最小值
            chart.ChartAreas[0].AxisX.Maximum = DT[DT.Count - 1].ToOADate(); // 設置X軸最大值
            chart.ChartAreas[0].AxisX.Maximum = DT[DT.Count - 1].ToOADate(); // 設置X軸最大值
            //chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;

            // Y軸設定
            chart.ChartAreas[0].AxisY.Maximum = 30;
            chart.ChartAreas[0].AxisY.Minimum = -30;


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

            MemoryStream memory = new MemoryStream();
            chart.SaveImage(memory, ChartImageFormat.Png);

            // Create a bitmap with the same size as the chart
            Bitmap bitmap = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, chart.Width, chart.Height));

            // Set the bitmap as the value of a specific cell in the DataGridView
            //Result_dgv.Rows[section - 1].Cells[1].Value = bitmap;
            Result_dgv.Rows[section - 1].Cells[1].Value = memory.GetBuffer();
            img[section - 1] = iTextSharp.text.Image.GetInstance(memory.GetBuffer());

            return chart;
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
            Result_dgv.Rows[0].Cells[2].Value = S1_value.Count > 0 ? CheckSingle_OKNG(S1_value) ? "OK" : "NG" : "NA";
            Result_dgv.Rows[1].Cells[2].Value = S2_value.Count > 0 ? CheckSingle_OKNG(S2_value) ? "OK" : "NG" : "NA";
            Result_dgv.Rows[2].Cells[2].Value = S3_value.Count > 0 ? CheckSingle_OKNG(S3_value) ? "OK" : "NG" : "NA";
            Result_dgv.Rows[3].Cells[2].Value = S4_value.Count > 0 ? CheckSingle_OKNG(S4_value) ? "OK" : "NG" : "NA";
        }

        #region ScreenShot to PDF

        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new System.Drawing.Rectangle(0, 0, ctl.Width, ctl.Height));
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
                        new System.Drawing.Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }

                //string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMdd")}{LicensePlate_lb.Text}.jpg";
                //bm.Save(path);

                return bm;
            }
        }

        private void Title_lb_Click(object sender, EventArgs e)
        {
            //GetFormImageWithoutBorders(this);
        }

        private void Result_Shown(object sender, EventArgs e)
        {
            //jpg2pdf(GetFormImageWithoutBorders(this));
            CreatePDF();
        }

        private void jpg2pdf(Bitmap bmp)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromFile("Your image file path");
            string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMddHHmm")}_{LicensePlate_lb.Text}.pdf";
            System.Drawing.Image image = bmp;
            Document doc = new Document(new iTextSharp.text.Rectangle(image.Width, image.Height));
            //Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
            pdfImage.SetAbsolutePosition(0, 0);
            pdfImage.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
            doc.Add(pdfImage);
            doc.Close();
        }

        #endregion

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
                gr.DrawImage(bmp, 0, 0, new System.Drawing.Rectangle(rc.Right - rc.Left, rc.Bottom - rc.Top, wid, hgt),
                    GraphicsUnit.Pixel);
            }

            string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMdd")}_{LicensePlate_lb.Text}.jpg";
            bmp2.Save(path);

            return bmp;
        }
        #endregion

        private void Result_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void CreatePDF()
        {
            var doc = new Document(PageSize.A4, 0, 0 ,0 , 0); // size, left, right, top, bottom
            string path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMddHHmm")}_ {LicensePlate_lb.Text}.pdf";

            // 檢查是否有想同檔名檔案
            int cnt = 1;
            while(File.Exists(path))
            {
                path = $@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("MMddHHmm")}_{LicensePlate_lb.Text}_{cnt}.pdf";
                cnt++;
            }

            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create)); // 建立PDF檔案

            // 字體設定
            BaseFont  ChBf = BaseFont.CreateFont(@"C:\Windows\Fonts\msjh.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); // 微軟正黑體
            iTextSharp.text.Font Ch_Title = new iTextSharp.text.Font(ChBf, 36, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font Ch_Content = new iTextSharp.text.Font(ChBf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();
            // 標題
            Paragraph Title_pa = new Paragraph("聯合電訊工程行", Ch_Title);
            Title_pa.Alignment = Element.ALIGN_CENTER;

            // 內容
            Paragraph Content_pa = new Paragraph();
            // 測試資訊(單位, 車號, 工程文號, 測試起點, 上下限值, 量測時間)
            PdfPTable TestConent_tb = new PdfPTable(new float[] { 0.8f, 2, 0.8f, 2, 0.8f, 2 });
            TestConent_tb.LockedWidth = true;
            TestConent_tb.TotalWidth = 580f;
            TestConent_tb.HorizontalAlignment = Element.ALIGN_CENTER;
            //TestConent_tb.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell Dep = new PdfPCell(new Phrase("單位：", Ch_Content));
            PdfPCell _Dep = new PdfPCell(new Phrase(Department_lb.Text, Ch_Content));
            PdfPCell Lic_Plate = new PdfPCell(new Phrase("車號：", Ch_Content));
            PdfPCell _Lic_Plate = new PdfPCell(new Phrase(LicensePlate_lb.Text, Ch_Content));
            PdfPCell ProjNo= new PdfPCell(new Phrase("工程文號：", Ch_Content));
            PdfPCell _ProjNo= new PdfPCell(new Phrase(ProjectNum_lb.Text, Ch_Content));
            PdfPCell Test_St = new PdfPCell(new Phrase("測試起點：", Ch_Content));
            PdfPCell _Test_St = new PdfPCell(new Phrase(StartPlace_lb.Text, Ch_Content));
            PdfPCell UD_Li = new PdfPCell(new Phrase("上限值：\r\n下限值：", Ch_Content));
            PdfPCell _UD_Li = new PdfPCell(new Phrase(UpDownLimit_lb.Text, Ch_Content));
            PdfPCell Test_ti = new PdfPCell(new Phrase("量測時間：", Ch_Content));
            PdfPCell _Test_ti = new PdfPCell(new Phrase(TestTime_lb.Text, Ch_Content));
            Dep.HorizontalAlignment = Element.ALIGN_CENTER;
            _Dep.HorizontalAlignment = Element.ALIGN_CENTER;
            Lic_Plate.HorizontalAlignment = Element.ALIGN_CENTER;
            _Lic_Plate.HorizontalAlignment = Element.ALIGN_CENTER;
            ProjNo.HorizontalAlignment = Element.ALIGN_CENTER;
            _ProjNo.HorizontalAlignment = Element.ALIGN_CENTER;
            Test_St.HorizontalAlignment = Element.ALIGN_CENTER;
            _Test_St.HorizontalAlignment = Element.ALIGN_CENTER;
            UD_Li.HorizontalAlignment = Element.ALIGN_CENTER;
            _UD_Li.HorizontalAlignment = Element.ALIGN_CENTER;
            Test_ti.HorizontalAlignment = Element.ALIGN_CENTER;
            _Test_ti.HorizontalAlignment = Element.ALIGN_CENTER;
            Dep.VerticalAlignment = Element.ALIGN_MIDDLE;
            _Dep.VerticalAlignment = Element.ALIGN_MIDDLE;
            Lic_Plate.VerticalAlignment = Element.ALIGN_MIDDLE;
            _Lic_Plate.VerticalAlignment = Element.ALIGN_MIDDLE;                
            ProjNo.VerticalAlignment = Element.ALIGN_MIDDLE;
            _ProjNo.VerticalAlignment = Element.ALIGN_MIDDLE;
            Test_St.VerticalAlignment = Element.ALIGN_MIDDLE;
            _Test_St.VerticalAlignment = Element.ALIGN_MIDDLE;
            UD_Li.VerticalAlignment = Element.ALIGN_MIDDLE;
            _UD_Li.VerticalAlignment = Element.ALIGN_MIDDLE;
            Test_ti.VerticalAlignment = Element.ALIGN_MIDDLE;
            _Test_ti.VerticalAlignment = Element.ALIGN_MIDDLE;

            //Dep.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_Dep.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //Lic_Plate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_Lic_Plate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //ProjNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_ProjNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //Test_St.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_Test_St.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //UD_Li.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_UD_Li.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //Test_ti.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //_Test_ti.Border = iTextSharp.text.Rectangle.NO_BORDER;

            TestConent_tb.AddCell(Dep);
            TestConent_tb.AddCell(_Dep);
            TestConent_tb.AddCell(Lic_Plate);
            TestConent_tb.AddCell(_Lic_Plate);
            TestConent_tb.AddCell(ProjNo);
            TestConent_tb.AddCell(_ProjNo);
            TestConent_tb.AddCell(Test_St);
            TestConent_tb.AddCell(_Test_St);
            TestConent_tb.AddCell(UD_Li);
            TestConent_tb.AddCell(_UD_Li);
            TestConent_tb.AddCell(Test_ti);
            TestConent_tb.AddCell(_Test_ti);
                        
            // 測試結果
            PdfPTable Result_tb = new PdfPTable(new float[] { 1.2f, 10, 1.2f, 2 });
            Result_tb.LockedWidth = true;
            Result_tb.TotalWidth = 580f;
            Result_tb.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell C1 = new PdfPCell(new Phrase("感測區域", Ch_Content));
            PdfPCell C2 =new PdfPCell(new Phrase("圖示(單位mm)", Ch_Content));
            PdfPCell C3 = new PdfPCell(new Phrase("測試結果", Ch_Content));
            PdfPCell C4 = new PdfPCell(new Phrase("確認工程師", Ch_Content));
            PdfPCell S1 = new PdfPCell(new Phrase("S1", Ch_Content));
            PdfPCell S2 = new PdfPCell(new Phrase("S2", Ch_Content));
            PdfPCell S3 = new PdfPCell(new Phrase("S3", Ch_Content));
            PdfPCell S4 = new PdfPCell(new Phrase("S4", Ch_Content));

            PdfPCell P1 = new PdfPCell(img[0], true);
            PdfPCell P2 = new PdfPCell(img[1], true);
            PdfPCell P3 = new PdfPCell(img[2], true);
            PdfPCell P4 = new PdfPCell(img[3], true);
            PdfPCell R1 = new PdfPCell(new Phrase(Result_dgv.Rows[0].Cells[2].Value.ToString(), Ch_Content));
            PdfPCell R2 = new PdfPCell(new Phrase(Result_dgv.Rows[1].Cells[2].Value.ToString(), Ch_Content));
            PdfPCell R3 = new PdfPCell(new Phrase(Result_dgv.Rows[2].Cells[2].Value.ToString(), Ch_Content));
            PdfPCell R4 = new PdfPCell(new Phrase(Result_dgv.Rows[3].Cells[2].Value.ToString(), Ch_Content));
            C1.HorizontalAlignment = Element.ALIGN_CENTER;
            C2.HorizontalAlignment = Element.ALIGN_CENTER;
            C3.HorizontalAlignment = Element.ALIGN_CENTER;
            C4.HorizontalAlignment = Element.ALIGN_CENTER;
            S1.HorizontalAlignment = Element.ALIGN_CENTER;
            S2.HorizontalAlignment = Element.ALIGN_CENTER;
            S3.HorizontalAlignment = Element.ALIGN_CENTER;
            S4.HorizontalAlignment = Element.ALIGN_CENTER;
            P1.HorizontalAlignment = Element.ALIGN_CENTER;
            P2.HorizontalAlignment = Element.ALIGN_CENTER;
            P3.HorizontalAlignment = Element.ALIGN_CENTER;
            P4.HorizontalAlignment = Element.ALIGN_CENTER;
            R1.HorizontalAlignment = Element.ALIGN_CENTER;
            R2.HorizontalAlignment = Element.ALIGN_CENTER;
            R3.HorizontalAlignment = Element.ALIGN_CENTER;
            R4.HorizontalAlignment = Element.ALIGN_CENTER;
            C1.VerticalAlignment = Element.ALIGN_MIDDLE;
            C2.VerticalAlignment = Element.ALIGN_MIDDLE;
            C3.VerticalAlignment = Element.ALIGN_MIDDLE;
            C4.VerticalAlignment = Element.ALIGN_MIDDLE;
            S1.VerticalAlignment = Element.ALIGN_MIDDLE;
            S2.VerticalAlignment = Element.ALIGN_MIDDLE;
            S3.VerticalAlignment = Element.ALIGN_MIDDLE;
            S4.VerticalAlignment = Element.ALIGN_MIDDLE;
            P1.VerticalAlignment = Element.ALIGN_MIDDLE;
            P2.VerticalAlignment = Element.ALIGN_MIDDLE;
            P3.VerticalAlignment = Element.ALIGN_MIDDLE;
            P4.VerticalAlignment = Element.ALIGN_MIDDLE;
            R1.VerticalAlignment = Element.ALIGN_MIDDLE;
            R2.VerticalAlignment = Element.ALIGN_MIDDLE;
            R3.VerticalAlignment = Element.ALIGN_MIDDLE;
            R4.VerticalAlignment = Element.ALIGN_MIDDLE;

            Result_tb.AddCell(C1);
            Result_tb.AddCell(C2);
            Result_tb.AddCell(C3);
            Result_tb.AddCell(C4);
            Result_tb.AddCell(S1);
            Result_tb.AddCell(P1);
            Result_tb.AddCell(R1);
            Result_tb.AddCell(" ");
            Result_tb.AddCell(S2);
            Result_tb.AddCell(P2);
            Result_tb.AddCell(R2);                
            Result_tb.AddCell(" ");
            Result_tb.AddCell(S3);
            Result_tb.AddCell(P3);
            Result_tb.AddCell(R3);
            Result_tb.AddCell(" ");
            Result_tb.AddCell(S4);
            Result_tb.AddCell(P4);
            Result_tb.AddCell(R4);
            Result_tb.AddCell(" ");

            // 測試人員簽名
            PdfPTable Sign_tb =new PdfPTable(6);
            Sign_tb.LockedWidth = true;
            Sign_tb.TotalWidth = 580f;
            PdfPCell testreport = new PdfPCell(new Phrase("測試報告：\n\n\n\n\n", Ch_Content));
            testreport.Colspan = 6;
            testreport.Rowspan = 5;
            testreport.HorizontalAlignment = Element.ALIGN_LEFT;
            testreport.VerticalAlignment = Element.ALIGN_TOP;
            PdfPCell approve = new PdfPCell(new Phrase("核准：", Ch_Content));
            PdfPCell super_sign = new PdfPCell(new Phrase("主管簽核：", Ch_Content));
            PdfPCell tester = new PdfPCell(new Phrase("測試人員：", Ch_Content));
            approve.HorizontalAlignment = Element.ALIGN_CENTER;
            super_sign.HorizontalAlignment = Element.ALIGN_CENTER;
            tester.HorizontalAlignment = Element.ALIGN_CENTER;
            Sign_tb.AddCell(testreport);            
            Sign_tb.AddCell(approve);
            Sign_tb.AddCell(" ");
            Sign_tb.AddCell(super_sign);
            Sign_tb.AddCell(" ");
            Sign_tb.AddCell(tester);
            Sign_tb.AddCell(" ");

            // 將所有表格加入內容
            Content_pa.Add("\r\n");
            Content_pa.Add(TestConent_tb);
            Content_pa.Add("\r\n");
            Content_pa.Add(Result_tb);
            Content_pa.Add("\r\n");
            Content_pa.Add(Sign_tb);

            // 文件內容
            doc.AddTitle(LicensePlate_lb.Text + "雷射圓盤檢測報告"); 
            doc.AddAuthor("聯合電訊工程行");
            doc.AddCreationDate();

            doc.Add(Title_pa);
            doc.Add(Content_pa);
            doc.Close();
        }

        //private PdfPCell CreateCell()
        //{
            
        //}
    }
}
