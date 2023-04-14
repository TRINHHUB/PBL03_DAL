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
            AddColumn();
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
                p.khusach
            }).ToList();
        }
        public void AddColumn()
        {
            var newColumn = new DataGridViewTextBoxColumn();
            newColumn.Name = "NewColumn";
            newColumn.HeaderText = "New Column Header";
        }
    }
}
