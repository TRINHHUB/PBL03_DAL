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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            QLSach f2 = new QLSach();
            this.Hide();
            f2.Show();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            QLDocGia qldg = new QLDocGia();
            this.Hide();
            qldg.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            QLNV qlnv = new QLNV();
            this.Hide();
            qlnv.Show();    
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            QLMuonTra qlmt = new QLMuonTra();
            this.Hide();
            qlmt.Show();

        }
    }
}
