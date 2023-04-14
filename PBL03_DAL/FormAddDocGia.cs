﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03_DAL
{
    public partial class FormAddDocGia : Form
    {
        public FormAddDocGia()
        {
            InitializeComponent();
        }

        private void btnexitaddDG_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnokaddDG_Click(object sender, EventArgs e)
        {
            QLNS qlns = new QLNS();
            docgia s = new docgia();

            s.madocgia = Convert.ToInt32(txtaddmaDG.Text);
            s.hoten = txtaddtenDG.Text;
            s.ngaysinh = dtpickerDG.Value;
            s.gioitinh = rd1DG.Checked;
            s.diachi = txtadddiachiDG.Text;
            s.sdt = txtaddsdtDG.Text;

            qlns.docgias.Add(s);
            qlns.SaveChanges();
            if (MessageBox.Show("Thêm độc giả thành công!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();

            }
            
            
                
            

        }
    }
}
