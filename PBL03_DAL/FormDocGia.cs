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
    }
}
