﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03_DAL.GUI
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void btnXemSach_Click(object sender, EventArgs e)
        {
            ThongKeTrongNgay tktn = new ThongKeTrongNgay();
            this.Hide();
            tktn.Show();
        }

        private void btnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien ttnv = new ThongTinNhanVien();
            this.Hide();
            ttnv.Show();
        }
    }
}
