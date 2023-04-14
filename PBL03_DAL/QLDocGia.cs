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
            if(dgrDG.SelectedRows.Count == 1)
            {
                using( QLNS qlns = new QLNS())
                {
                    int m = Convert.ToInt32(dgrDG.CurrentRow.Cells["madocgia"].Value.ToString());
                    docgia s = qlns.docgias.Find(m);

                    
                }
            }
        }
    }
}
