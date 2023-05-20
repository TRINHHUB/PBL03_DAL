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

namespace PBL03_DAL.GUI
{
    public partial class FormGoiY : Form
    {
        public FormGoiY()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ShowTTGoiy();
        }

        public void ShowTTGoiy()
        {
            if(cbbGoiY.SelectedIndex == 0)
            {
                try
                {
                    List<ShowGoiYMax> list = new List<ShowGoiYMax>();
                    list = BLL_QLSACH.Instance.getGoiYMax();
                    dgvGOIY.DataSource = list;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    dgvGOIY.DataSource = BLL_QLSACH.Instance.FindsachGoiY(txtGoiY.Text, cbbTKtheoYC.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.ToString());
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormDocGia fdg = new FormDocGia();
            this.Hide();
            fdg.Show();
        }

        private void FormGoiY_Load(object sender, EventArgs e)
        {
            List<string> li = new List<string>();
            li.Add("Sách được mua nhiều nhất");
            li.Add("Tìm sách theo yêu cầu");
            foreach(var i in li)
            {
                cbbGoiY.Items.Add(i);
            }
        }
    }

}
