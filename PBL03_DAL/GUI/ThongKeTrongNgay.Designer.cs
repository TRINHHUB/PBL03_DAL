namespace PBL03_DAL.GUI
{
    partial class ThongKeTrongNgay
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbnow = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbstart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvTrongNgay = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThoatTrongNgay = new Guna.UI2.WinForms.Guna2Button();
            this.btnxemDoanhThuTrongNgay = new Guna.UI2.WinForms.Guna2Button();
            this.lbDoanhThuTrongNgay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrongNgay)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lbnow);
            this.guna2Panel1.Controls.Add(this.lbstart);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(798, 110);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lbnow
            // 
            this.lbnow.BackColor = System.Drawing.Color.Transparent;
            this.lbnow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnow.Location = new System.Drawing.Point(623, 70);
            this.lbnow.Name = "lbnow";
            this.lbnow.Size = new System.Drawing.Size(139, 23);
            this.lbnow.TabIndex = 4;
            this.lbnow.Text = "guna2HtmlLabel5";
            // 
            // lbstart
            // 
            this.lbstart.BackColor = System.Drawing.Color.Transparent;
            this.lbstart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstart.Location = new System.Drawing.Point(83, 67);
            this.lbstart.Name = "lbstart";
            this.lbstart.Size = new System.Drawing.Size(139, 23);
            this.lbstart.TabIndex = 3;
            this.lbstart.Text = "guna2HtmlLabel4";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(576, 70);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(38, 23);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Đến:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(56, 70);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(24, 19);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Từ:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(313, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(211, 32);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Thống kê trong ngày";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvTrongNgay
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTrongNgay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrongNgay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTrongNgay.ColumnHeadersHeight = 25;
            this.dgvTrongNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrongNgay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTrongNgay.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTrongNgay.Location = new System.Drawing.Point(1, 113);
            this.dgvTrongNgay.Name = "dgvTrongNgay";
            this.dgvTrongNgay.RowHeadersVisible = false;
            this.dgvTrongNgay.Size = new System.Drawing.Size(798, 321);
            this.dgvTrongNgay.TabIndex = 1;
            this.dgvTrongNgay.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTrongNgay.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTrongNgay.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTrongNgay.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTrongNgay.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTrongNgay.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTrongNgay.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTrongNgay.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvTrongNgay.ThemeStyle.ReadOnly = false;
            this.dgvTrongNgay.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTrongNgay.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTrongNgay.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTrongNgay.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTrongNgay.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTrongNgay.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTrongNgay.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnThoatTrongNgay);
            this.guna2Panel2.Controls.Add(this.btnxemDoanhThuTrongNgay);
            this.guna2Panel2.Controls.Add(this.lbDoanhThuTrongNgay);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel4);
            this.guna2Panel2.Location = new System.Drawing.Point(1, 447);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(800, 78);
            this.guna2Panel2.TabIndex = 3;
            // 
            // btnThoatTrongNgay
            // 
            this.btnThoatTrongNgay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoatTrongNgay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoatTrongNgay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoatTrongNgay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoatTrongNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatTrongNgay.ForeColor = System.Drawing.Color.White;
            this.btnThoatTrongNgay.Location = new System.Drawing.Point(604, 16);
            this.btnThoatTrongNgay.Name = "btnThoatTrongNgay";
            this.btnThoatTrongNgay.Size = new System.Drawing.Size(180, 43);
            this.btnThoatTrongNgay.TabIndex = 3;
            this.btnThoatTrongNgay.Text = "Thoát";
            this.btnThoatTrongNgay.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnxemDoanhThuTrongNgay
            // 
            this.btnxemDoanhThuTrongNgay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnxemDoanhThuTrongNgay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnxemDoanhThuTrongNgay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnxemDoanhThuTrongNgay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnxemDoanhThuTrongNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxemDoanhThuTrongNgay.ForeColor = System.Drawing.Color.White;
            this.btnxemDoanhThuTrongNgay.Location = new System.Drawing.Point(405, 16);
            this.btnxemDoanhThuTrongNgay.Name = "btnxemDoanhThuTrongNgay";
            this.btnxemDoanhThuTrongNgay.Size = new System.Drawing.Size(180, 43);
            this.btnxemDoanhThuTrongNgay.TabIndex = 2;
            this.btnxemDoanhThuTrongNgay.Text = "Xem";
            this.btnxemDoanhThuTrongNgay.Click += new System.EventHandler(this.btnxemDoanhThu_Click);
            // 
            // lbDoanhThuTrongNgay
            // 
            this.lbDoanhThuTrongNgay.BackColor = System.Drawing.Color.Transparent;
            this.lbDoanhThuTrongNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhThuTrongNgay.Location = new System.Drawing.Point(118, 27);
            this.lbDoanhThuTrongNgay.Name = "lbDoanhThuTrongNgay";
            this.lbDoanhThuTrongNgay.Size = new System.Drawing.Size(49, 23);
            this.lbDoanhThuTrongNgay.TabIndex = 1;
            this.lbDoanhThuTrongNgay.Text = "LABLE";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(13, 27);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(95, 23);
            this.guna2HtmlLabel4.TabIndex = 0;
            this.guna2HtmlLabel4.Text = "Doanh Thu :";
            // 
            // ThongKeTrongNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 526);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.dgvTrongNgay);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ThongKeTrongNgay";
            this.Text = "ThongKeTrongNgay";
            this.Load += new System.EventHandler(this.ThongKeTrongNgay_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrongNgay)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbnow;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbstart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTrongNgay;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnThoatTrongNgay;
        private Guna.UI2.WinForms.Guna2Button btnxemDoanhThuTrongNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbDoanhThuTrongNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
    }
}