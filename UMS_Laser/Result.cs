using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UMS_Laser
{
    public partial class Result : Form
    {
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

            Get_SectionData(data);
            
            //for (int i = 0; i < S1_value.Count; i++)
            //{
            //    Debug.Print($"S1_value[{i}]:{S1_value[i]}\r\n");
            //}
            //DemoChart();

            // Auto resize rows and columns of the DataGridView
            Result_dgv.AutoResizeRows();
            Result_dgv.AutoResizeColumns();
        }

        /// <summary>
        /// 解析Sensor1~4的資料
        /// </summary>
        /// <param name="data"></param>
        private void Get_SectionData(string data)
        {
            string[] RawSplit = data.Split('\n'); // 取出每行資料
            foreach(string line in RawSplit)
            {
                string[] Split = line.Split(','); // 取出每個欄位資料(時間,數值,感測器編號)
                Debug.Print(line+"\r\n");
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

        private void DemoChart()
        {
            // Create a chart
            Chart chart = new Chart();
            chart.Width = 400;
            chart.Height = 400;
            
            // Create a series for the chart
            chart.ChartAreas.Add(new ChartArea());
            chart.Series.Add(new Series());
            Series series = chart.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Red;

            // Add data points to the series
            series.Points.AddXY(1, 10);
            series.Points.AddXY(2, 20);
            series.Points.AddXY(3, 15);
            series.Points.AddXY(4, 25);
            series.Points.AddXY(5, 30);

            // Add the series to the chart
            ChartArea ca = chart.ChartAreas[0];
            ca.AxisX.Title = "X Axis";
            ca.AxisY.Title = "Y Axis";
            ca.AxisX.Minimum = 0;
            ca.AxisX.Maximum = 6;
            ca.AxisY.Minimum = 0;
            ca.AxisY.Maximum = 35;

            // Create a bitmap with the same size as the chart
            Bitmap bitmap = new Bitmap(chart.Width, chart.Height);

            // Draw the chart onto the bitmap
            chart.DrawToBitmap(bitmap, new Rectangle(0, 0, chart.Width, chart.Height));

            // Set the bitmap as the value of a specific cell in the DataGridView
            Result_dgv.Rows[0].Cells[1].Value = bitmap;

        }
    }
}
