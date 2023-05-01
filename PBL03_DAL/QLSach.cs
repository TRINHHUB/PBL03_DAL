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
    public partial class QLSach : Form
    {
        public QLSach()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }

        private void btnthemS_Click(object sender, EventArgs e)
        {
            FormAddSach fas = new FormAddSach();
            fas.Show();
        }

        private void btnviewS_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }
        public void ShowDGV()
        {
            QLNS qlns = new QLNS();
            dgrS.DataSource = qlns.saches
            .Select(p => new
            {
                p.masach,
                p.tensach,
                p.namxb,
                p.nxb.tennxb,
                p.tacgia.tentacgia,
                p.theloai.tentheloai,
                p.soluong,
                p.ghichu,
                p.khusach,
                p.giatien,
                p.dataanh
            }).ToList();
        }

        private void btnxoaS_Click(object sender, EventArgs e)
        {
            if(dgrS.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dgrS.SelectedRows)
                {
                    using(QLNS db = new QLNS())
                    {
                        int m = Convert.ToInt32(i.Cells[0].Value.ToString());
                        sach s = db.saches.Find(m);
                        db.saches.Remove(s);
                        db.SaveChanges();
                        MessageBox.Show("Bạn đã xóa thành công sách này");
                   }
                }
            }
        }
    }
}
