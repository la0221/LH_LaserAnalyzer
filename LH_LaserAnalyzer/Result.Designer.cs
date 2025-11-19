namespace LH_LaserAnalyzer
{
    partial class Result
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Title_lb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Department_lb = new System.Windows.Forms.Label();
            this.Result_dgv = new System.Windows.Forms.DataGridView();
            this.Column_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TestTime_lb = new System.Windows.Forms.Label();
            this.ProjectNum_lb = new System.Windows.Forms.Label();
            this.StartPlace_lb = new System.Windows.Forms.Label();
            this.UpDownLimit_lb = new System.Windows.Forms.Label();
            this.LicensePlate_lb = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_lb
            // 
            this.Title_lb.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Title_lb.Location = new System.Drawing.Point(15, 11);
            this.Title_lb.Name = "Title_lb";
            this.Title_lb.Size = new System.Drawing.Size(3269, 148);
            this.Title_lb.TabIndex = 0;
            this.Title_lb.Text = "聯合電訊工程行";
            this.Title_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title_lb.Click += new System.EventHandler(this.Title_lb_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(1092, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 176);
            this.label5.TabIndex = 2;
            this.label5.Text = "上限值：\r\n下限值：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Department_lb
            // 
            this.Department_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Department_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Department_lb.Location = new System.Drawing.Point(366, 0);
            this.Department_lb.Name = "Department_lb";
            this.Department_lb.Size = new System.Drawing.Size(720, 87);
            this.Department_lb.TabIndex = 2;
            this.Department_lb.Text = "N/A";
            this.Department_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Result_dgv
            // 
            this.Result_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Result_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Result_dgv.ColumnHeadersHeight = 46;
            this.Result_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Section,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Result_dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.Result_dgv.Location = new System.Drawing.Point(15, 437);
            this.Result_dgv.Name = "Result_dgv";
            this.Result_dgv.ReadOnly = true;
            this.Result_dgv.RowHeadersVisible = false;
            this.Result_dgv.RowHeadersWidth = 82;
            this.Result_dgv.RowTemplate.Height = 38;
            this.Result_dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Result_dgv.Size = new System.Drawing.Size(3269, 1625);
            this.Result_dgv.TabIndex = 3;
            // 
            // Column_Section
            // 
            this.Column_Section.HeaderText = "感測區域";
            this.Column_Section.MinimumWidth = 10;
            this.Column_Section.Name = "Column_Section";
            this.Column_Section.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "圖示(單位mm)";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "測試結果";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "確認工程師";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TestTime_lb, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProjectNum_lb, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.StartPlace_lb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Department_lb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.UpDownLimit_lb, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.LicensePlate_lb, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 167);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(3269, 263);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(2181, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(357, 87);
            this.label12.TabIndex = 2;
            this.label12.Text = "工程文號：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(357, 87);
            this.label14.TabIndex = 2;
            this.label14.Text = "單位：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(2181, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(357, 176);
            this.label15.TabIndex = 2;
            this.label15.Text = "量測時間：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(3, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(357, 176);
            this.label16.TabIndex = 2;
            this.label16.Text = "測試起點：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestTime_lb
            // 
            this.TestTime_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestTime_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TestTime_lb.Location = new System.Drawing.Point(2544, 87);
            this.TestTime_lb.Name = "TestTime_lb";
            this.TestTime_lb.Size = new System.Drawing.Size(722, 176);
            this.TestTime_lb.TabIndex = 2;
            this.TestTime_lb.Text = "   N/A\r\n~N/A";
            this.TestTime_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectNum_lb
            // 
            this.ProjectNum_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectNum_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ProjectNum_lb.Location = new System.Drawing.Point(2544, 0);
            this.ProjectNum_lb.Name = "ProjectNum_lb";
            this.ProjectNum_lb.Size = new System.Drawing.Size(722, 87);
            this.ProjectNum_lb.TabIndex = 2;
            this.ProjectNum_lb.Text = "N/A";
            this.ProjectNum_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartPlace_lb
            // 
            this.StartPlace_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartPlace_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartPlace_lb.Location = new System.Drawing.Point(366, 87);
            this.StartPlace_lb.Name = "StartPlace_lb";
            this.StartPlace_lb.Size = new System.Drawing.Size(720, 176);
            this.StartPlace_lb.TabIndex = 2;
            this.StartPlace_lb.Text = "N/A";
            this.StartPlace_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpDownLimit_lb
            // 
            this.UpDownLimit_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDownLimit_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UpDownLimit_lb.Location = new System.Drawing.Point(1455, 87);
            this.UpDownLimit_lb.Name = "UpDownLimit_lb";
            this.UpDownLimit_lb.Size = new System.Drawing.Size(720, 176);
            this.UpDownLimit_lb.TabIndex = 2;
            this.UpDownLimit_lb.Text = "N/A mm\r\nN/A mm";
            this.UpDownLimit_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LicensePlate_lb
            // 
            this.LicensePlate_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LicensePlate_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LicensePlate_lb.Location = new System.Drawing.Point(1455, 0);
            this.LicensePlate_lb.Name = "LicensePlate_lb";
            this.LicensePlate_lb.Size = new System.Drawing.Size(720, 87);
            this.LicensePlate_lb.TabIndex = 2;
            this.LicensePlate_lb.Text = "N/A";
            this.LicensePlate_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(1092, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(357, 87);
            this.label13.TabIndex = 2;
            this.label13.Text = "車號：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Clear();
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));

            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Clear();
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F)); // 0：上排左/右
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F)); // 1：下排左/右
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F)); // 2：表頭
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F)); // 3：簽名空白

            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 1035);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1509, 500);
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;

            // ===== 2*2 文字表格 =========
            // textBox1 =>  檢查發現危害、分析危害因素
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Multiline = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("標楷體", 14F);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Text = "\r檢查發現危害、分析危害因素：";
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel2.SetColumnSpan(this.textBox1, 3);

            // textBox2 => 評估危害風險(嚴重性及可能性分析)
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Multiline = true;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("標楷體", 14F);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Text = "\r評估危害風險(嚴重性及可能性分析)：";
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanel2.SetColumnSpan(this.textBox2, 3);

            // textBox3 => 評估結果改善措施
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Multiline = true;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("標楷體", 14F);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Text = "\r評估結果改善措施：";
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 0, 1);
            this.tableLayoutPanel2.SetColumnSpan(this.textBox3, 3);

            // textBox4 => 檢討改善措施之合宜性
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Multiline = true;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("標楷體", 14F);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.Text = "\r檢討改善措施之合宜性：";
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 3, 1);
            this.tableLayoutPanel2.SetColumnSpan(this.textBox4, 3);

            // ===== 簽名表格 =========
            // 第 2 列 => column name
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("標楷體", 20F);
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Text = "檢查單位";
            this.tableLayoutPanel2.Controls.Add(this.label, 0, 2);
            this.tableLayoutPanel2.SetColumnSpan(this.label, 2);

            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("標楷體", 20F);
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Text = "檢查單位主管";
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 2);

            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("標楷體", 20F);
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Text = "檢查人員";
            this.tableLayoutPanel2.Controls.Add(this.label6, 4, 2);
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 2);

            // 第 3 列 => 簽名空白列
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.875F);
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Text = "";
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);

            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 13.875F);
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Text = "";
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel2.SetColumnSpan(this.label4, 2);

            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 13.875F);
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Text = "";
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 3);
            this.tableLayoutPanel2.SetColumnSpan(this.label7, 2);
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(2634, 1905);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Result_dgv);
            this.Controls.Add(this.Title_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(2664, 1980);
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "測試報告";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Result_FormClosing);
            this.Shown += new System.EventHandler(this.Result_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title_lb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Department_lb;
        private System.Windows.Forms.DataGridView Result_dgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label UpDownLimit_lb;
        private System.Windows.Forms.Label LicensePlate_lb;
        private System.Windows.Forms.Label TestTime_lb;
        private System.Windows.Forms.Label ProjectNum_lb;
        private System.Windows.Forms.Label StartPlace_lb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Section;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}