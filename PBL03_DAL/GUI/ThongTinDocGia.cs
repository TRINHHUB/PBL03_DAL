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
    public partial class ThongTinDocGia : Form
    {
        public ThongTinDocGia()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            int CurrentId = CurrentUser.ID_User;
            docgia s = BLL_QLDG.Instance.GetdocgiaByidUer(CurrentId);
            txtname.Text = s.hoten;
            txtdiachi.Text = s.diachi;
            txtngaysinh.Text = s.ngaysinh.Value.ToString("dd/MM/yyyy");
            txtsdt.Text = s.sdt;
            if (s.gioitinh.ToString() == "True")
            {
                txtsex.Text = "Nam";
            }
            else
            {
                txtsex.Text = "Nữ";
            }

        }
        private void btExit_Click(object sender, EventArgs e)
        {
            FormDocGia form = new FormDocGia();
            this.Dispose();
            form.Show();


        }
    }
}