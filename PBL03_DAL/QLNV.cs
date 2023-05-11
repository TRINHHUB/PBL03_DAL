using PBL03_DAL.DTO;
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
    public partial class QLNV : Form
    {
        public QLNV()
        {
            InitializeComponent();
        }

        private void btnexitNV_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }
        private void showdata()
        { 
            using(QLNS db = new QLNS ())
            {
                dgrNV.DataSource = db.nhanviens.Select(p => new { 
                    p.manhanvien,
                    p.tennhanvien, 
                    p.diachi,
                    p.sdt, 
                    gioitinh = p.gioitinh == true ? "Nam" :(p.gioitinh == false ? "Nữ" : "Không xác định")  }).ToList();                   
            }

        }
        private void dgrNV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dgrNV.CurrentRow.Index;
            txt_nameNV.Text = dgrNV.Rows[i].Cells["tennhanvien"].Value.ToString();
            txt_addressNV.Text = dgrNV.Rows[i].Cells["diachi"].Value.ToString();
            txt_sdtNV.Text = dgrNV.Rows[i].Cells["sdt"].Value.ToString();
            if (dgrNV.Rows[i].Cells["gioitinh"].Value.ToString() == "Nam") radioButton1.Checked = true;
            else radioButton1.Checked = false;
        }
        private void btnviewNV_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            nhanvien s = new nhanvien();
            using (QLNS db = new QLNS ())
            {
                s.tennhanvien = txt_nameNV.Text;
                s.diachi = txt_addressNV.Text;
                s.sdt = txt_sdtNV.Text;
                s.gioitinh = radioButton1.Checked;
                db.nhanviens.Add(s);
                db.SaveChanges();
            }
            showdata();         
        }

        private void btnxoaNV_Click(object sender, EventArgs e)
        {
            if(dgrNV.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dgrNV.SelectedRows)
                {
                    using(QLNS db = new QLNS())
                    {
                        int m = Convert.ToInt32(i.Cells["manhanvien"].Value.ToString());
                        nhanvien s = db.nhanviens.Find(m);
                        db.nhanviens.Remove(s);
                        db.SaveChanges();
                        showdata();
                    }
                }
            }
        }

        private void btntimkiemNV_Click(object sender, EventArgs e)
        {
            using(QLNS db = new QLNS())
            {
                dgrNV.DataSource = db.nhanviens.Where(p => p.tennhanvien.Contains(txttimkiemNV.Text))
                    .Select(p => new {
                        p.manhanvien,
                        p.tennhanvien,
                        p.diachi,
                        p.sdt,
                        gioitinh = p.gioitinh == true ? "Nam" : (p.gioitinh == false ? "Nữ" : "Không xác định")
                    }).ToList();
            }
        
        }

       
    }
}
