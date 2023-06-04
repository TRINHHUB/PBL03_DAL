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
    public partial class FormDocGia : Form
    {
        public FormDocGia()
        {
            InitializeComponent();
        }

        private void btnXemSach_Click(object sender, EventArgs e)
        {
            ThongTinSach tts = new ThongTinSach();
            this.Hide();
            tts.Show();
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            GioHangDocGia ghdg = new GioHangDocGia();
            this.Hide();
            ghdg.Show();
        }

        private void btnexitDocGia_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            this.Hide();
            form.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormLichSuGiaoDich lsgd = new FormLichSuGiaoDich();
            this.Hide();
            lsgd.Show();
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            FormGoiY fgy = new FormGoiY();
            this.Hide();
            fgy.Show();
        }

        private void btnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            ThongTinDocGia ttdg = new ThongTinDocGia();
            this.Hide();
            ttdg.Show();
        }

    }
}
