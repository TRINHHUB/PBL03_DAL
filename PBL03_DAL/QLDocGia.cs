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
    }
}
