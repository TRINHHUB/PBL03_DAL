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
    public partial class ThongTinNhanVien : Form
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            int CurrentId = CurrentUser.ID_User;
            nhanviennhasach s = BLL_QLDG.Instance.GetNhanVienByid(CurrentId);
            txtnameNV.Text = s.tennhanvien;
            txtdiachiNV.Text = s.diachi;
            txtsdtNV.Text = s.sdt;
            if (s.gioitinh.ToString() == "True")
            {
                txtsexS.Text = "Nam";
            }
            else
            {
                txtsexS.Text = "Nữ";
            }

        }
        private void btExitNV_Click(object sender, EventArgs e)
        {
            FormNhanVien form = new FormNhanVien();
            this.Dispose();
            form.Show();


        }

        private void btExitNV_Click_1(object sender, EventArgs e)
        {
            FormNhanVien fnv = new FormNhanVien();
            this.Hide();
            fnv.Show();
        }
    }
}