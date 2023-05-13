using PBL03_DAL.BLL;
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
    public partial class FormLichSuGiaoDich : Form
    {
        public FormLichSuGiaoDich()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int tongtien = 0;
            int currentUserID = CurrentUser.ID_User;
            List<Lichsugiaodich> list = new List<Lichsugiaodich>();
            list = BLL_QLSACH.Instance.history(currentUserID);

            foreach (Lichsugiaodich i in list)
            {
                tongtien += (int)i.sum;
            }

            if (list != null)
            {
                dgvLSGD.DataSource = list;
                lbLSGD.Text = tongtien.ToString();

            }
            else
            {
                MessageBox.Show("Không có giao dịch nào được thực hiện");
            }
        }
 
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            FormDocGia fdg = new FormDocGia();
            this.Hide();
            fdg.Show();

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}