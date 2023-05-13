using PBL03_DAL.BLL;
using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using PBL03_DAL.GUI;
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
            dgrDG.DataSource = BLL_QLDG.Instance.getalldg();
        }

        private void btneditDG_Click(object sender, EventArgs e)
        {

            if (dgrDG.SelectedRows.Count == 1)
            {
                int iddocgia = Convert.ToInt32(dgrDG.SelectedRows[0].Cells["MaDG"].Value);
                FormEditDocGia form = new FormEditDocGia(iddocgia);
                form.d += new FormEditDocGia.Mydel(showDGVDG);
                form.Show();

            }
        }

        private void btnTKDG_Click(object sender, EventArgs e)
        {
            //QLNS db = new QLNS();
            //dgrDG.DataSource = db.docgias.Where(p => p.hoten.Contains(txtTKDG.Text))
            //    .Select(p => new
            //    {
            //        p.madocgia,
            //        p.hoten,
            //        p.ngaysinh,
            //        p.diachi,
            //        p.sdt,
            //        gioitinh = p.gioitinh == true ? "Nam" : (p.gioitinh == false ? "Nữ" : "Không xác định")
            //    }).ToList();
        }

        private void btnxoaDG_Click(object sender, EventArgs e)
        {
            if (dgrDG.SelectedRows.Count > 0)
            {
                List<int> madel = new List<int>();
                foreach (DataGridViewRow i in dgrDG.SelectedRows)
                {
                    if (i.Cells["MaDG"].Value != null)
                        {
                        madel.Add(Convert.ToInt32(i.Cells["MaDG"].Value));
                        BLL_QLDG.Instance.DelDocgia(madel);
                        MessageBox.Show("Bạn đã xóa thành công độc giả này");
                        showDGVDG();
                        }
                        else
                        {
                            MessageBox.Show("Chon dong can xoa");
                        }

                    }

            }
           
        }


        }
    }

