
namespace UMS_IoT
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.COM_ComportBox = new System.Windows.Forms.ComboBox();
            this.COM_Connect_btn = new System.Windows.Forms.Button();
            this.exp2csv_btn = new System.Windows.Forms.Button();
            this.clear_tb_btn = new System.Windows.Forms.Button();
            this.rcv_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetSensor_button = new System.Windows.Forms.Button();
            this.BT_Stat_button = new System.Windows.Forms.Button();
            this.BuzzOn_button = new System.Windows.Forms.Button();
            this.Read_button = new System.Windows.Forms.Button();
            this.StopRead_button = new System.Windows.Forms.Button();
            this.BuzzOff_button = new System.Windows.Forms.Button();
            this.GetBatV_button = new System.Windows.Forms.Button();
            this.StartRead_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LowBat_lb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BatVol_lb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_stat_lb = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Lowlimit_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SetLimit_button = new System.Windows.Forms.Button();
            this.Uplimit_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TestState_lb = new System.Windows.Forms.Label();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.COM_ComportBox);
            this.groupBox10.Controls.Add(this.COM_Connect_btn);
            this.groupBox10.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox10.Location = new System.Drawing.Point(14, 13);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox10.Size = new System.Drawing.Size(420, 132);
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "COM";
            // 
            // COM_ComportBox
            // 
            this.COM_ComportBox.Font = new System.Drawing.Font("微軟正黑體", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.COM_ComportBox.FormattingEnabled = true;
            this.COM_ComportBox.IntegralHeight = false;
            this.COM_ComportBox.Location = new System.Drawing.Point(10, 53);
            this.COM_ComportBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.COM_ComportBox.Name = "COM_ComportBox";
            this.COM_ComportBox.Size = new System.Drawing.Size(213, 62);
            this.COM_ComportBox.TabIndex = 0;
            // 
            // COM_Connect_btn
            // 
            this.COM_Connect_btn.AutoSize = true;
            this.COM_Connect_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.COM_Connect_btn.Location = new System.Drawing.Point(233, 49);
            this.COM_Connect_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.COM_Connect_btn.Name = "COM_Connect_btn";
            this.COM_Connect_btn.Size = new System.Drawing.Size(175, 71);
            this.COM_Connect_btn.TabIndex = 4;
            this.COM_Connect_btn.Text = "開啟";
            this.COM_Connect_btn.UseVisualStyleBackColor = true;
            this.COM_Connect_btn.Click += new System.EventHandler(this.COM_Connect_btn_Click);
            // 
            // exp2csv_btn
            // 
            this.exp2csv_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exp2csv_btn.Location = new System.Drawing.Point(1001, 389);
            this.exp2csv_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.exp2csv_btn.Name = "exp2csv_btn";
            this.exp2csv_btn.Size = new System.Drawing.Size(459, 71);
            this.exp2csv_btn.TabIndex = 5;
            this.exp2csv_btn.Text = "匯出檔案";
            this.exp2csv_btn.UseVisualStyleBackColor = true;
            this.exp2csv_btn.Click += new System.EventHandler(this.exp2csv_btn_Click);
            // 
            // clear_tb_btn
            // 
            this.clear_tb_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clear_tb_btn.Location = new System.Drawing.Point(1001, 547);
            this.clear_tb_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clear_tb_btn.Name = "clear_tb_btn";
            this.clear_tb_btn.Size = new System.Drawing.Size(459, 71);
            this.clear_tb_btn.TabIndex = 50;
            this.clear_tb_btn.Text = "清除接收視窗";
            this.clear_tb_btn.UseVisualStyleBackColor = true;
            this.clear_tb_btn.Click += new System.EventHandler(this.clear_tb_btn_Click);
            // 
            // rcv_textBox
            // 
            this.rcv_textBox.BackColor = System.Drawing.SystemColors.Window;
            this.rcv_textBox.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rcv_textBox.Location = new System.Drawing.Point(12, 152);
            this.rcv_textBox.Multiline = true;
            this.rcv_textBox.Name = "rcv_textBox";
            this.rcv_textBox.ReadOnly = true;
            this.rcv_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rcv_textBox.Size = new System.Drawing.Size(974, 905);
            this.rcv_textBox.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetSensor_button);
            this.groupBox1.Controls.Add(this.BT_Stat_button);
            this.groupBox1.Controls.Add(this.BuzzOn_button);
            this.groupBox1.Controls.Add(this.Read_button);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(1002, 954);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(434, 71);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEBUG";
            this.groupBox1.Visible = false;
            // 
            // GetSensor_button
            // 
            this.GetSensor_button.AutoSize = true;
            this.GetSensor_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GetSensor_button.Location = new System.Drawing.Point(257, 58);
            this.GetSensor_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.GetSensor_button.Name = "GetSensor_button";
            this.GetSensor_button.Size = new System.Drawing.Size(210, 71);
            this.GetSensor_button.TabIndex = 4;
            this.GetSensor_button.Text = "讀取狀態";
            this.GetSensor_button.UseVisualStyleBackColor = true;
            this.GetSensor_button.Click += new System.EventHandler(this.GetSensor_button_Click);
            // 
            // BT_Stat_button
            // 
            this.BT_Stat_button.AutoSize = true;
            this.BT_Stat_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_Stat_button.Location = new System.Drawing.Point(257, 137);
            this.BT_Stat_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BT_Stat_button.Name = "BT_Stat_button";
            this.BT_Stat_button.Size = new System.Drawing.Size(210, 71);
            this.BT_Stat_button.TabIndex = 4;
            this.BT_Stat_button.Text = "藍牙狀態";
            this.BT_Stat_button.UseVisualStyleBackColor = true;
            this.BT_Stat_button.Click += new System.EventHandler(this.BT_Stat_button_Click);
            // 
            // BuzzOn_button
            // 
            this.BuzzOn_button.AutoSize = true;
            this.BuzzOn_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BuzzOn_button.Location = new System.Drawing.Point(21, 137);
            this.BuzzOn_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BuzzOn_button.Name = "BuzzOn_button";
            this.BuzzOn_button.Size = new System.Drawing.Size(210, 71);
            this.BuzzOn_button.TabIndex = 4;
            this.BuzzOn_button.Text = "開啟警示";
            this.BuzzOn_button.UseVisualStyleBackColor = true;
            this.BuzzOn_button.Click += new System.EventHandler(this.BuzzOn_button_Click);
            // 
            // Read_button
            // 
            this.Read_button.AutoSize = true;
            this.Read_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Read_button.Location = new System.Drawing.Point(21, 58);
            this.Read_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Read_button.Name = "Read_button";
            this.Read_button.Size = new System.Drawing.Size(210, 71);
            this.Read_button.TabIndex = 4;
            this.Read_button.Text = "單次量測";
            this.Read_button.UseVisualStyleBackColor = true;
            this.Read_button.Click += new System.EventHandler(this.Read_button_Click);
            // 
            // StopRead_button
            // 
            this.StopRead_button.AutoSize = true;
            this.StopRead_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StopRead_button.Location = new System.Drawing.Point(1001, 231);
            this.StopRead_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StopRead_button.Name = "StopRead_button";
            this.StopRead_button.Size = new System.Drawing.Size(460, 71);
            this.StopRead_button.TabIndex = 4;
            this.StopRead_button.Text = "停止量測";
            this.StopRead_button.UseVisualStyleBackColor = true;
            this.StopRead_button.Click += new System.EventHandler(this.StopRead_button_Click);
            // 
            // BuzzOff_button
            // 
            this.BuzzOff_button.AutoSize = true;
            this.BuzzOff_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BuzzOff_button.Location = new System.Drawing.Point(1001, 310);
            this.BuzzOff_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BuzzOff_button.Name = "BuzzOff_button";
            this.BuzzOff_button.Size = new System.Drawing.Size(459, 71);
            this.BuzzOff_button.TabIndex = 4;
            this.BuzzOff_button.Text = "關閉警示";
            this.BuzzOff_button.UseVisualStyleBackColor = true;
            this.BuzzOff_button.Click += new System.EventHandler(this.BuzzOff_button_Click);
            // 
            // GetBatV_button
            // 
            this.GetBatV_button.AutoSize = true;
            this.GetBatV_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GetBatV_button.Location = new System.Drawing.Point(1001, 468);
            this.GetBatV_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.GetBatV_button.Name = "GetBatV_button";
            this.GetBatV_button.Size = new System.Drawing.Size(459, 71);
            this.GetBatV_button.TabIndex = 4;
            this.GetBatV_button.Text = "更新電壓";
            this.GetBatV_button.UseVisualStyleBackColor = true;
            this.GetBatV_button.Click += new System.EventHandler(this.GetBatV_button_Click);
            // 
            // StartRead_button
            // 
            this.StartRead_button.AutoSize = true;
            this.StartRead_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartRead_button.Location = new System.Drawing.Point(1001, 152);
            this.StartRead_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StartRead_button.Name = "StartRead_button";
            this.StartRead_button.Size = new System.Drawing.Size(459, 71);
            this.StartRead_button.TabIndex = 4;
            this.StartRead_button.Text = "開始量測";
            this.StartRead_button.UseVisualStyleBackColor = true;
            this.StartRead_button.Click += new System.EventHandler(this.StartRead_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(462, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 47);
            this.label1.TabIndex = 52;
            this.label1.Text = "低電量";
            // 
            // LowBat_lb
            // 
            this.LowBat_lb.AutoSize = true;
            this.LowBat_lb.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LowBat_lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LowBat_lb.Location = new System.Drawing.Point(487, 69);
            this.LowBat_lb.Name = "LowBat_lb";
            this.LowBat_lb.Size = new System.Drawing.Size(82, 67);
            this.LowBat_lb.TabIndex = 52;
            this.LowBat_lb.Text = "●";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(624, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 47);
            this.label2.TabIndex = 52;
            this.label2.Text = "當前電壓";
            // 
            // BatVol_lb
            // 
            this.BatVol_lb.AutoSize = true;
            this.BatVol_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BatVol_lb.Location = new System.Drawing.Point(650, 78);
            this.BatVol_lb.Name = "BatVol_lb";
            this.BatVol_lb.Size = new System.Drawing.Size(117, 47);
            this.BatVol_lb.TabIndex = 52;
            this.BatVol_lb.Text = "0.00V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(818, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 47);
            this.label3.TabIndex = 52;
            this.label3.Text = "藍牙狀態";
            // 
            // BT_stat_lb
            // 
            this.BT_stat_lb.AutoSize = true;
            this.BT_stat_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BT_stat_lb.ForeColor = System.Drawing.Color.Red;
            this.BT_stat_lb.Location = new System.Drawing.Point(835, 75);
            this.BT_stat_lb.Name = "BT_stat_lb";
            this.BT_stat_lb.Size = new System.Drawing.Size(131, 47);
            this.BT_stat_lb.TabIndex = 52;
            this.BT_stat_lb.Text = "未連線";
            this.BT_stat_lb.Click += new System.EventHandler(this.BT_stat_lb_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Lowlimit_textBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SetLimit_button);
            this.groupBox2.Controls.Add(this.Uplimit_textBox);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(1001, 626);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(459, 305);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "上下限設置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(57, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 47);
            this.label6.TabIndex = 52;
            this.label6.Text = "(取至小數點後兩位)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(19, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 47);
            this.label5.TabIndex = 52;
            this.label5.Text = "下限";
            // 
            // Lowlimit_textBox
            // 
            this.Lowlimit_textBox.Location = new System.Drawing.Point(131, 161);
            this.Lowlimit_textBox.Name = "Lowlimit_textBox";
            this.Lowlimit_textBox.Size = new System.Drawing.Size(188, 57);
            this.Lowlimit_textBox.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(19, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 47);
            this.label4.TabIndex = 52;
            this.label4.Text = "上限";
            // 
            // SetLimit_button
            // 
            this.SetLimit_button.AutoSize = true;
            this.SetLimit_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetLimit_button.Location = new System.Drawing.Point(327, 77);
            this.SetLimit_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SetLimit_button.Name = "SetLimit_button";
            this.SetLimit_button.Size = new System.Drawing.Size(104, 151);
            this.SetLimit_button.TabIndex = 4;
            this.SetLimit_button.Text = "設定";
            this.SetLimit_button.UseVisualStyleBackColor = true;
            this.SetLimit_button.Click += new System.EventHandler(this.SetLimit_button_Click);
            // 
            // Uplimit_textBox
            // 
            this.Uplimit_textBox.Location = new System.Drawing.Point(131, 81);
            this.Uplimit_textBox.Name = "Uplimit_textBox";
            this.Uplimit_textBox.Size = new System.Drawing.Size(188, 57);
            this.Uplimit_textBox.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(1130, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 47);
            this.label7.TabIndex = 52;
            this.label7.Text = "量測狀態";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // TestState_lb
            // 
            this.TestState_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TestState_lb.Location = new System.Drawing.Point(994, 75);
            this.TestState_lb.Name = "TestState_lb";
            this.TestState_lb.Size = new System.Drawing.Size(459, 47);
            this.TestState_lb.TabIndex = 52;
            this.TestState_lb.Text = "未開始";
            this.TestState_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TestState_lb.Click += new System.EventHandler(this.label7_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1475, 1069);
            this.Controls.Add(this.LowBat_lb);
            this.Controls.Add(this.StopRead_button);
            this.Controls.Add(this.BuzzOff_button);
            this.Controls.Add(this.BatVol_lb);
            this.Controls.Add(this.GetBatV_button);
            this.Controls.Add(this.BT_stat_lb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TestState_lb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rcv_textBox);
            this.Controls.Add(this.StartRead_button);
            this.Controls.Add(this.clear_tb_btn);
            this.Controls.Add(this.exp2csv_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox10);
            this.Name = "Main";
            this.Text = "UMS圓盤檢測系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox COM_ComportBox;
        private System.Windows.Forms.Button COM_Connect_btn;
        private System.Windows.Forms.Button exp2csv_btn;
        private System.Windows.Forms.Button clear_tb_btn;
        private System.Windows.Forms.TextBox rcv_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopRead_button;
        private System.Windows.Forms.Button BuzzOff_button;
        private System.Windows.Forms.Button BuzzOn_button;
        private System.Windows.Forms.Button StartRead_button;
        private System.Windows.Forms.Button GetSensor_button;
        private System.Windows.Forms.Button Read_button;
        private System.Windows.Forms.Button GetBatV_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LowBat_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BatVol_lb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BT_stat_lb;
        private System.Windows.Forms.Button BT_Stat_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SetLimit_button;
        private System.Windows.Forms.TextBox Lowlimit_textBox;
        private System.Windows.Forms.TextBox Uplimit_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TestState_lb;
    }
}

