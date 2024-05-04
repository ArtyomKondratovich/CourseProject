namespace Temp
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.oneDay = new System.Windows.Forms.Button();
            this.fiveDays = new System.Windows.Forms.Button();
            this.oneMonth = new System.Windows.Forms.Button();
            this.threeMonth = new System.Windows.Forms.Button();
            this.sixMonth = new System.Windows.Forms.Button();
            this.currentYear = new System.Windows.Forms.Button();
            this.oneYear = new System.Windows.Forms.Button();
            this.twoYears = new System.Windows.Forms.Button();
            this.fiveYears = new System.Windows.Forms.Button();
            this.range = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.738516F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.26148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.59282F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.40717F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1153, 662);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.oneDay);
            this.flowLayoutPanel1.Controls.Add(this.fiveDays);
            this.flowLayoutPanel1.Controls.Add(this.oneMonth);
            this.flowLayoutPanel1.Controls.Add(this.threeMonth);
            this.flowLayoutPanel1.Controls.Add(this.sixMonth);
            this.flowLayoutPanel1.Controls.Add(this.currentYear);
            this.flowLayoutPanel1.Controls.Add(this.oneYear);
            this.flowLayoutPanel1.Controls.Add(this.twoYears);
            this.flowLayoutPanel1.Controls.Add(this.fiveYears);
            this.flowLayoutPanel1.Controls.Add(this.range);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 553);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(713, 23);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // oneDay
            // 
            this.oneDay.Location = new System.Drawing.Point(3, 3);
            this.oneDay.Name = "oneDay";
            this.oneDay.Size = new System.Drawing.Size(30, 20);
            this.oneDay.TabIndex = 0;
            this.oneDay.Text = "1D";
            this.oneDay.UseVisualStyleBackColor = true;
            this.oneDay.Click += new System.EventHandler(this.OneDay_Click);
            // 
            // fiveDays
            // 
            this.fiveDays.Location = new System.Drawing.Point(39, 3);
            this.fiveDays.Name = "fiveDays";
            this.fiveDays.Size = new System.Drawing.Size(30, 20);
            this.fiveDays.TabIndex = 1;
            this.fiveDays.Text = "5D";
            this.fiveDays.UseVisualStyleBackColor = true;
            this.fiveDays.Click += new System.EventHandler(this.FiveDays_Click);
            // 
            // oneMonth
            // 
            this.oneMonth.Location = new System.Drawing.Point(75, 3);
            this.oneMonth.Name = "oneMonth";
            this.oneMonth.Size = new System.Drawing.Size(30, 20);
            this.oneMonth.TabIndex = 2;
            this.oneMonth.Text = "1M";
            this.oneMonth.UseVisualStyleBackColor = true;
            this.oneMonth.Click += new System.EventHandler(this.OneMonth_Click);
            // 
            // threeMonth
            // 
            this.threeMonth.Location = new System.Drawing.Point(111, 3);
            this.threeMonth.Name = "threeMonth";
            this.threeMonth.Size = new System.Drawing.Size(30, 20);
            this.threeMonth.TabIndex = 3;
            this.threeMonth.Text = "3M";
            this.threeMonth.UseVisualStyleBackColor = true;
            this.threeMonth.Click += new System.EventHandler(this.ThreeMonth_Click);
            // 
            // sixMonth
            // 
            this.sixMonth.Location = new System.Drawing.Point(147, 3);
            this.sixMonth.Name = "sixMonth";
            this.sixMonth.Size = new System.Drawing.Size(30, 20);
            this.sixMonth.TabIndex = 4;
            this.sixMonth.Text = "6M";
            this.sixMonth.UseVisualStyleBackColor = true;
            this.sixMonth.Click += new System.EventHandler(this.SixMonth_Click);
            // 
            // currentYear
            // 
            this.currentYear.Location = new System.Drawing.Point(183, 3);
            this.currentYear.Name = "currentYear";
            this.currentYear.Size = new System.Drawing.Size(40, 20);
            this.currentYear.TabIndex = 5;
            this.currentYear.Text = "YTD";
            this.currentYear.UseVisualStyleBackColor = true;
            this.currentYear.Click += new System.EventHandler(this.CurrentYear_Click);
            // 
            // oneYear
            // 
            this.oneYear.Location = new System.Drawing.Point(229, 3);
            this.oneYear.Name = "oneYear";
            this.oneYear.Size = new System.Drawing.Size(30, 20);
            this.oneYear.TabIndex = 6;
            this.oneYear.Text = "1Y";
            this.oneYear.UseVisualStyleBackColor = true;
            this.oneYear.Click += new System.EventHandler(this.OneYear_Click);
            // 
            // twoYears
            // 
            this.twoYears.Location = new System.Drawing.Point(265, 3);
            this.twoYears.Name = "twoYears";
            this.twoYears.Size = new System.Drawing.Size(30, 20);
            this.twoYears.TabIndex = 7;
            this.twoYears.Text = "2Y";
            this.twoYears.UseVisualStyleBackColor = true;
            this.twoYears.Click += new System.EventHandler(this.TwoYears_Click);
            // 
            // fiveYears
            // 
            this.fiveYears.Location = new System.Drawing.Point(301, 3);
            this.fiveYears.Name = "fiveYears";
            this.fiveYears.Size = new System.Drawing.Size(30, 20);
            this.fiveYears.TabIndex = 8;
            this.fiveYears.Text = "5Y";
            this.fiveYears.UseVisualStyleBackColor = true;
            this.fiveYears.Click += new System.EventHandler(this.FiveYears_Click);
            // 
            // range
            // 
            this.range.Location = new System.Drawing.Point(337, 3);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(100, 20);
            this.range.TabIndex = 9;
            this.range.Text = "button2";
            this.range.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(23, 116);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(713, 431);
            this.webBrowser1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 660);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button oneDay;
        private System.Windows.Forms.Button fiveDays;
        private System.Windows.Forms.Button oneMonth;
        private System.Windows.Forms.Button threeMonth;
        private System.Windows.Forms.Button sixMonth;
        private System.Windows.Forms.Button currentYear;
        private System.Windows.Forms.Button oneYear;
        private System.Windows.Forms.Button twoYears;
        private System.Windows.Forms.Button fiveYears;
        private System.Windows.Forms.Button range;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

