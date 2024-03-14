
namespace UMS_Laser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.COM_cb = new System.Windows.Forms.ComboBox();
            this.COM_Connect_btn = new System.Windows.Forms.Button();
            this.exp2csv_btn = new System.Windows.Forms.Button();
            this.clear_tb_btn = new System.Windows.Forms.Button();
            this.rcv_tb = new System.Windows.Forms.TextBox();
            this.debug_gb = new System.Windows.Forms.GroupBox();
            this.GetSensor_button = new System.Windows.Forms.Button();
            this.BuzzOn_button = new System.Windows.Forms.Button();
            this.Read_button = new System.Windows.Forms.Button();
            this.StopRead_button = new System.Windows.Forms.Button();
            this.BuzzOff_button = new System.Windows.Forms.Button();
            this.StartRead_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Downlimit_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SetLimit_button = new System.Windows.Forms.Button();
            this.Uplimit_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TestState_lb = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Department_tb = new System.Windows.Forms.TextBox();
            this.LicensePlate_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectNo_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StartPlace_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DebugResult_btn = new System.Windows.Forms.Button();
            this.groupBox10.SuspendLayout();
            this.debug_gb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.COM_cb);
            this.groupBox10.Controls.Add(this.COM_Connect_btn);
            this.groupBox10.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox10.Location = new System.Drawing.Point(14, 13);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox10.Size = new System.Drawing.Size(507, 132);
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "COM";
            // 
            // COM_cb
            // 
            this.COM_cb.Font = new System.Drawing.Font("微軟正黑體", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.COM_cb.FormattingEnabled = true;
            this.COM_cb.IntegralHeight = false;
            this.COM_cb.Location = new System.Drawing.Point(27, 52);
            this.COM_cb.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.COM_cb.Name = "COM_cb";
            this.COM_cb.Size = new System.Drawing.Size(268, 62);
            this.COM_cb.TabIndex = 0;
            // 
            // COM_Connect_btn
            // 
            this.COM_Connect_btn.AutoSize = true;
            this.COM_Connect_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.COM_Connect_btn.Location = new System.Drawing.Point(316, 50);
            this.COM_Connect_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.COM_Connect_btn.Name = "COM_Connect_btn";
            this.COM_Connect_btn.Size = new System.Drawing.Size(167, 71);
            this.COM_Connect_btn.TabIndex = 4;
            this.COM_Connect_btn.Text = "開啟";
            this.COM_Connect_btn.UseVisualStyleBackColor = true;
            this.COM_Connect_btn.Click += new System.EventHandler(this.COM_Connect_btn_Click);
            // 
            // exp2csv_btn
            // 
            this.exp2csv_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exp2csv_btn.Location = new System.Drawing.Point(14, 390);
            this.exp2csv_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.exp2csv_btn.Name = "exp2csv_btn";
            this.exp2csv_btn.Size = new System.Drawing.Size(507, 71);
            this.exp2csv_btn.TabIndex = 5;
            this.exp2csv_btn.Text = "匯出檔案";
            this.exp2csv_btn.UseVisualStyleBackColor = true;
            this.exp2csv_btn.Click += new System.EventHandler(this.exp2csv_btn_Click);
            // 
            // clear_tb_btn
            // 
            this.clear_tb_btn.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clear_tb_btn.Location = new System.Drawing.Point(14, 469);
            this.clear_tb_btn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clear_tb_btn.Name = "clear_tb_btn";
            this.clear_tb_btn.Size = new System.Drawing.Size(507, 71);
            this.clear_tb_btn.TabIndex = 50;
            this.clear_tb_btn.Text = "清除接收視窗";
            this.clear_tb_btn.UseVisualStyleBackColor = true;
            this.clear_tb_btn.Click += new System.EventHandler(this.clear_tb_btn_Click);
            // 
            // rcv_tb
            // 
            this.rcv_tb.BackColor = System.Drawing.SystemColors.Window;
            this.rcv_tb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rcv_tb.Location = new System.Drawing.Point(529, 153);
            this.rcv_tb.Multiline = true;
            this.rcv_tb.Name = "rcv_tb";
            this.rcv_tb.ReadOnly = true;
            this.rcv_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rcv_tb.Size = new System.Drawing.Size(631, 700);
            this.rcv_tb.TabIndex = 51;
            this.rcv_tb.Text = resources.GetString("rcv_tb.Text");
            // 
            // debug_gb
            // 
            this.debug_gb.Controls.Add(this.DebugResult_btn);
            this.debug_gb.Controls.Add(this.GetSensor_button);
            this.debug_gb.Controls.Add(this.BuzzOn_button);
            this.debug_gb.Controls.Add(this.Read_button);
            this.debug_gb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.debug_gb.Location = new System.Drawing.Point(1174, 397);
            this.debug_gb.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.debug_gb.Name = "debug_gb";
            this.debug_gb.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.debug_gb.Size = new System.Drawing.Size(244, 378);
            this.debug_gb.TabIndex = 49;
            this.debug_gb.TabStop = false;
            this.debug_gb.Text = "DEBUG";
            this.debug_gb.Visible = false;
            // 
            // GetSensor_button
            // 
            this.GetSensor_button.AutoSize = true;
            this.GetSensor_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GetSensor_button.Location = new System.Drawing.Point(21, 216);
            this.GetSensor_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.GetSensor_button.Name = "GetSensor_button";
            this.GetSensor_button.Size = new System.Drawing.Size(210, 71);
            this.GetSensor_button.TabIndex = 4;
            this.GetSensor_button.Text = "讀取狀態";
            this.GetSensor_button.UseVisualStyleBackColor = true;
            this.GetSensor_button.Click += new System.EventHandler(this.GetSensor_button_Click);
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
            this.StopRead_button.Location = new System.Drawing.Point(14, 232);
            this.StopRead_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StopRead_button.Name = "StopRead_button";
            this.StopRead_button.Size = new System.Drawing.Size(508, 71);
            this.StopRead_button.TabIndex = 4;
            this.StopRead_button.Text = "停止量測";
            this.StopRead_button.UseVisualStyleBackColor = true;
            this.StopRead_button.Click += new System.EventHandler(this.StopRead_button_Click);
            // 
            // BuzzOff_button
            // 
            this.BuzzOff_button.AutoSize = true;
            this.BuzzOff_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BuzzOff_button.Location = new System.Drawing.Point(14, 311);
            this.BuzzOff_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BuzzOff_button.Name = "BuzzOff_button";
            this.BuzzOff_button.Size = new System.Drawing.Size(507, 71);
            this.BuzzOff_button.TabIndex = 4;
            this.BuzzOff_button.Text = "關閉警示";
            this.BuzzOff_button.UseVisualStyleBackColor = true;
            this.BuzzOff_button.Click += new System.EventHandler(this.BuzzOff_button_Click);
            // 
            // StartRead_button
            // 
            this.StartRead_button.AutoSize = true;
            this.StartRead_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartRead_button.Location = new System.Drawing.Point(14, 153);
            this.StartRead_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StartRead_button.Name = "StartRead_button";
            this.StartRead_button.Size = new System.Drawing.Size(507, 71);
            this.StartRead_button.TabIndex = 4;
            this.StartRead_button.Text = "開始量測";
            this.StartRead_button.UseVisualStyleBackColor = true;
            this.StartRead_button.Click += new System.EventHandler(this.StartRead_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Downlimit_tb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SetLimit_button);
            this.groupBox2.Controls.Add(this.Uplimit_tb);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(14, 552);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(507, 305);
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
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 47);
            this.label5.TabIndex = 52;
            this.label5.Text = "下限";
            // 
            // Downlimit_tb
            // 
            this.Downlimit_tb.Location = new System.Drawing.Point(118, 161);
            this.Downlimit_tb.Name = "Downlimit_tb";
            this.Downlimit_tb.Size = new System.Drawing.Size(149, 57);
            this.Downlimit_tb.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(273, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 47);
            this.label9.TabIndex = 52;
            this.label9.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(273, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 47);
            this.label8.TabIndex = 52;
            this.label8.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 47);
            this.label4.TabIndex = 52;
            this.label4.Text = "上限";
            // 
            // SetLimit_button
            // 
            this.SetLimit_button.AutoSize = true;
            this.SetLimit_button.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetLimit_button.Location = new System.Drawing.Point(378, 72);
            this.SetLimit_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SetLimit_button.Name = "SetLimit_button";
            this.SetLimit_button.Size = new System.Drawing.Size(93, 151);
            this.SetLimit_button.TabIndex = 4;
            this.SetLimit_button.Text = "設\r\n定";
            this.SetLimit_button.UseVisualStyleBackColor = true;
            this.SetLimit_button.Click += new System.EventHandler(this.SetLimit_button_Click);
            // 
            // Uplimit_tb
            // 
            this.Uplimit_tb.Location = new System.Drawing.Point(118, 81);
            this.Uplimit_tb.Name = "Uplimit_tb";
            this.Uplimit_tb.Size = new System.Drawing.Size(149, 57);
            this.Uplimit_tb.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(529, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(631, 47);
            this.label7.TabIndex = 52;
            this.label7.Text = "量測狀態";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestState_lb
            // 
            this.TestState_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TestState_lb.Location = new System.Drawing.Point(529, 98);
            this.TestState_lb.Name = "TestState_lb";
            this.TestState_lb.Size = new System.Drawing.Size(631, 47);
            this.TestState_lb.TabIndex = 52;
            this.TestState_lb.Text = "未開始";
            this.TestState_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.StartPlace_tb);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.LicensePlate_tb);
            this.groupBox4.Controls.Add(this.ProjectNo_tb);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.Department_tb);
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(1168, 13);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Size = new System.Drawing.Size(674, 376);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "報表設定";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(8, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(242, 47);
            this.label11.TabIndex = 52;
            this.label11.Text = "單位：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Department_tb
            // 
            this.Department_tb.Location = new System.Drawing.Point(256, 81);
            this.Department_tb.Name = "Department_tb";
            this.Department_tb.Size = new System.Drawing.Size(392, 57);
            this.Department_tb.TabIndex = 53;
            // 
            // LicensePlate_tb
            // 
            this.LicensePlate_tb.Location = new System.Drawing.Point(256, 154);
            this.LicensePlate_tb.Name = "LicensePlate_tb";
            this.LicensePlate_tb.Size = new System.Drawing.Size(392, 57);
            this.LicensePlate_tb.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 47);
            this.label1.TabIndex = 52;
            this.label1.Text = "車號：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectNo_tb
            // 
            this.ProjectNo_tb.Location = new System.Drawing.Point(256, 229);
            this.ProjectNo_tb.Name = "ProjectNo_tb";
            this.ProjectNo_tb.Size = new System.Drawing.Size(392, 57);
            this.ProjectNo_tb.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 47);
            this.label2.TabIndex = 52;
            this.label2.Text = "工程文號：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartPlace_tb
            // 
            this.StartPlace_tb.Location = new System.Drawing.Point(256, 302);
            this.StartPlace_tb.Name = "StartPlace_tb";
            this.StartPlace_tb.Size = new System.Drawing.Size(392, 57);
            this.StartPlace_tb.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(8, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 47);
            this.label3.TabIndex = 52;
            this.label3.Text = "量測起點：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebugResult_btn
            // 
            this.DebugResult_btn.Location = new System.Drawing.Point(21, 294);
            this.DebugResult_btn.Name = "DebugResult_btn";
            this.DebugResult_btn.Size = new System.Drawing.Size(210, 60);
            this.DebugResult_btn.TabIndex = 53;
            this.DebugResult_btn.Text = "量測結果";
            this.DebugResult_btn.UseVisualStyleBackColor = true;
            this.DebugResult_btn.Click += new System.EventHandler(this.DebugResult_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2085, 866);
            this.Controls.Add(this.StopRead_button);
            this.Controls.Add(this.BuzzOff_button);
            this.Controls.Add(this.debug_gb);
            this.Controls.Add(this.TestState_lb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rcv_tb);
            this.Controls.Add(this.StartRead_button);
            this.Controls.Add(this.clear_tb_btn);
            this.Controls.Add(this.exp2csv_btn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.debug_gb.ResumeLayout(false);
            this.debug_gb.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox COM_cb;
        private System.Windows.Forms.Button COM_Connect_btn;
        private System.Windows.Forms.Button exp2csv_btn;
        private System.Windows.Forms.Button clear_tb_btn;
        private System.Windows.Forms.TextBox rcv_tb;
        private System.Windows.Forms.GroupBox debug_gb;
        private System.Windows.Forms.Button StopRead_button;
        private System.Windows.Forms.Button BuzzOff_button;
        private System.Windows.Forms.Button BuzzOn_button;
        private System.Windows.Forms.Button StartRead_button;
        private System.Windows.Forms.Button GetSensor_button;
        private System.Windows.Forms.Button Read_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SetLimit_button;
        private System.Windows.Forms.TextBox Downlimit_tb;
        private System.Windows.Forms.TextBox Uplimit_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TestState_lb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Department_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StartPlace_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LicensePlate_tb;
        private System.Windows.Forms.TextBox ProjectNo_tb;
        private System.Windows.Forms.Button DebugResult_btn;
    }
}

