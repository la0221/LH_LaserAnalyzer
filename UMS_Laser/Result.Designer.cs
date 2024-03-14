namespace UMS_Laser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Department_lb = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result_dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.UpDownLimit_lb = new System.Windows.Forms.Label();
            this.LicensePlate_lb = new System.Windows.Forms.Label();
            this.StartPlace_lb = new System.Windows.Forms.Label();
            this.ProjectNum_lb = new System.Windows.Forms.Label();
            this.TestTime_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2363, 118);
            this.label1.TabIndex = 0;
            this.label1.Text = "聯合電訊工程行";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(790, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 140);
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
            this.Department_lb.Location = new System.Drawing.Point(265, 0);
            this.Department_lb.Name = "Department_lb";
            this.Department_lb.Size = new System.Drawing.Size(519, 70);
            this.Department_lb.TabIndex = 2;
            this.Department_lb.Text = "N/A";
            this.Department_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "確認工程師";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "測試結果";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "圖示(單位mm)";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_Section
            // 
            this.Column_Section.HeaderText = "感測區域";
            this.Column_Section.MinimumWidth = 10;
            this.Column_Section.Name = "Column_Section";
            this.Column_Section.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Result_dgv
            // 
            this.Result_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Result_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Result_dgv.ColumnHeadersHeight = 46;
            this.Result_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Section,
            this.Column2,
            this.Column3,
            this.Column4});
            this.Result_dgv.Location = new System.Drawing.Point(48, 350);
            this.Result_dgv.Name = "Result_dgv";
            this.Result_dgv.RowHeadersVisible = false;
            this.Result_dgv.RowHeadersWidth = 82;
            this.Result_dgv.RowTemplate.Height = 38;
            this.Result_dgv.Size = new System.Drawing.Size(2363, 818);
            this.Result_dgv.TabIndex = 3;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 134);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2363, 210);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(1577, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(256, 70);
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
            this.label14.Size = new System.Drawing.Size(256, 70);
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
            this.label15.Location = new System.Drawing.Point(1577, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(256, 140);
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
            this.label16.Location = new System.Drawing.Point(3, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(256, 140);
            this.label16.TabIndex = 2;
            this.label16.Text = "測試起點：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(790, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(256, 70);
            this.label13.TabIndex = 2;
            this.label13.Text = "車號：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpDownLimit_lb
            // 
            this.UpDownLimit_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDownLimit_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UpDownLimit_lb.Location = new System.Drawing.Point(1052, 70);
            this.UpDownLimit_lb.Name = "UpDownLimit_lb";
            this.UpDownLimit_lb.Size = new System.Drawing.Size(519, 140);
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
            this.LicensePlate_lb.Location = new System.Drawing.Point(1052, 0);
            this.LicensePlate_lb.Name = "LicensePlate_lb";
            this.LicensePlate_lb.Size = new System.Drawing.Size(519, 70);
            this.LicensePlate_lb.TabIndex = 2;
            this.LicensePlate_lb.Text = "N/A";
            this.LicensePlate_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartPlace_lb
            // 
            this.StartPlace_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartPlace_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartPlace_lb.Location = new System.Drawing.Point(265, 70);
            this.StartPlace_lb.Name = "StartPlace_lb";
            this.StartPlace_lb.Size = new System.Drawing.Size(519, 140);
            this.StartPlace_lb.TabIndex = 2;
            this.StartPlace_lb.Text = "N/A";
            this.StartPlace_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectNum_lb
            // 
            this.ProjectNum_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectNum_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ProjectNum_lb.Location = new System.Drawing.Point(1839, 0);
            this.ProjectNum_lb.Name = "ProjectNum_lb";
            this.ProjectNum_lb.Size = new System.Drawing.Size(521, 70);
            this.ProjectNum_lb.TabIndex = 2;
            this.ProjectNum_lb.Text = "N/A";
            this.ProjectNum_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestTime_lb
            // 
            this.TestTime_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestTime_lb.Font = new System.Drawing.Font("微軟正黑體", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TestTime_lb.Location = new System.Drawing.Point(1839, 70);
            this.TestTime_lb.Name = "TestTime_lb";
            this.TestTime_lb.Size = new System.Drawing.Size(521, 140);
            this.TestTime_lb.TabIndex = 2;
            this.TestTime_lb.Text = "   N/A\r\n~N/A";
            this.TestTime_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2455, 1214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Result_dgv);
            this.Controls.Add(this.label1);
            this.Name = "Result";
            this.Text = "測試報告";
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Department_lb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Section;
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
    }
}