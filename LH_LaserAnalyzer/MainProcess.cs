using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LH_LaserAnalyzer
{
    internal class MainProcess
    {
        private int PreSensorState = -1;
        private int SensorState = -1;
        private int StartSensor = 0;
        private int ZeroOffset = 0;
        private int SensorProcess_idx = -2;
        private bool CheckUpdate_Up = false;
        private bool CheckUpdate_Low = false;
        private bool UpdateCompleteUp = false;
        private bool UpdateCompleteLow = false;

        #region BoardAction
        public Action<string> SerialSend = (data) => { };
        #endregion

        //String GetRcv(string rcv)
        //{
        //    if (rcv.Contains("BTC")) // 取得上下限
        //    {
        //        Thread.Sleep(200);
        //        SerialSend("U");   // 取得上限
        //        Thread.Sleep(200);
        //        SerialSend("D");   // 取得下限
        //    }

        //    else if (rcv.Contains("Uplimit"))
        //    {
        //        if (CheckUpdate_Up)
        //        {
        //            Debug.WriteLine("Check Update Up");
        //            Debug.WriteLine(float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.0"));
        //            if (float.Parse(Uplimit_textBox.Text) == float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()))
        //            {
        //                UpdateCompleteUp = true;
        //            }
        //            CheckUpdate_Up = false;
        //        }
        //        else
        //            Uplimit_textBox.Text = float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.0");
        //    }

        //    else if (rcv.Contains("Lowlimit"))
        //    {
        //        if (CheckUpdate_Low)
        //        {
        //            Debug.WriteLine("Check Update Low");
        //            Debug.WriteLine(float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.0"));
        //            if (float.Parse(Lowlimit_textBox.Text) == float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()))
        //            {
        //                UpdateCompleteLow = true;
        //            }
        //            CheckUpdate_Low = false;
        //        }
        //        else
        //            Lowlimit_textBox.Text = float.Parse(rcv.Substring(rcv.IndexOf(":") + 1).Trim()).ToString("##0.0");
        //    }

        //    else if (rcv.Contains("TEST STOP"))
        //    {
        //        SensorProcess_idx = 2;
        //    }

        //    else if (rcv.Contains("TEST START"))
        //    {
        //        SensorProcess_idx = -1;
        //    }

        //    else if (rcv.Contains("Sensor"))
        //    {
        //        return;
        //    }

        //    // 千分表數據
        //    else if (rcv.Contains(',') && rcv.Split(',')[1].Contains("-1"))  // sensor尚未偵測
        //    {
        //        SensorState = -1;
        //    }
        //    else if (rcv.Contains(","))
        //    {
        //        SensorProcess(int.Parse(rcv.Split(',')[0]));
        //        SensorState = int.Parse(rcv.Split(',')[1]);
        //        rcv_textBox.AppendText(DateTime.Now.ToString("MM-dd hh:mm:ss.fff") + ", " + rcv + "\r\n");
        //    }

        //    PreSensorState = SensorState;
        //}
    }
}