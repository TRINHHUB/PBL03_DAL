using System;
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
    public partial class QLDocGia : Form
    {
        public QLDocGia()
        {
            InitializeComponent();
        }

        private void btnExitDG_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }

        private void btnthemDG_Click(object sender, EventArgs e)
        {
            FormAddDocGia fdg = new FormAddDocGia();
            fdg.Show();        
        }

        private void btnviewDG_Click(object sender, EventArgs e)
        {
            showDGVDG();

        }
        public void showDGVDG()
        {
            QLNS qlns = new QLNS();
            dgrDG.DataSource = qlns.docgias
                .Select(p => new
                {
                    p.madocgia,
                    p.hoten,
                    p.ngaysinh,
                    p.diachi,
                    p.sdt,
                    gioitinh = p.gioitinh == true ? "Nam" : (p.gioitinh == false ? "Nữ" : "Không xác định")
                }).ToList();
            dgrDG.Refresh();
        }

        private void btneditDG_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTKDG_Click(object sender, EventArgs e)
        {
            QLNS db = new QLNS();
            dgrDG.DataSource = db.docgias.Where(p => p.hoten.Contains(txtTKDG.Text))
                .Select(p => new
                {
                    p.madocgia,
                    p.hoten,
                    p.ngaysinh,
                    p.diachi,
                    p.sdt,
                    gioitinh = p.gioitinh == true ? "Nam" : (p.gioitinh == false ? "Nữ" : "Không xác định")
                }).ToList();
        }

        private void btnxoaDG_Click(object sender, EventArgs e)
        {
           if(dgrDG.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dgrDG.SelectedRows)
                {
                    using(QLNS db = new QLNS())
                    {
                        int m = Convert.ToInt32(i.Cells[0].Value.ToString());
                        docgia s = db.docgias.Find(m);
                        db.docgias.Remove(s);
                        db.SaveChanges();
                        MessageBox.Show("Ban da xoa thanh cong doc gia nay");
                        dgrDG.DataSource = db.docgias.Where(p => p.hoten.Contains(txtTKDG.Text))
                .Select(p => new
                {
                    p.madocgia,
                    p.hoten,
                    p.ngaysinh,
                    p.diachi,
                    p.sdt,
                    gioitinh = p.gioitinh == true ? "Nam" : (p.gioitinh == false ? "Nữ" : "Không xác định")
                }).ToList();
                    }
                }
            }    


        }
    }
}
