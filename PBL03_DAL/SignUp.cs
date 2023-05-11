using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PBL03_DAL.DTO;

namespace PBL03_DAL
{
    public partial class SignUp : Form
    {       
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();  
        }
        public bool CheckAccount(string ac) // check tk mk
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool CheckEmail(string em)
        {
            /*return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");*/
            return Regex.IsMatch(em, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string username = txtTKres.Text;
            string password = txtMKres.Text;
            string repassword = txtMKresagain.Text;
            string gmail = txtGMres.Text;
            if (!CheckAccount(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 kí tự, với các chữ số, chữ hoa và chữ thường");
                return;
            }

            if (!CheckAccount(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 kí tự, với các chữ số, chữ hoa và chữ thường");
                return;
            }

            if (!CheckAccount(repassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận dài 6-24 kí tự, với các chữ số, chữ hoa và chữ thường");
                return;
            }

            if (!CheckEmail(gmail))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng");
                return;
            }
            if (password != repassword)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu chính xác");
                return;
            }

            try
            {
                QLNS qlns = new QLNS();
                acountt ac = new acountt();

                ac.TaiKhoan = txtTKres.Text;
                ac.MatKhau = txtMKres.Text;
                ac.Gmail = txtGMres.Text;
                var signup = qlns.acountts.Add(ac);
                qlns.SaveChanges();

                if (MessageBox.Show("Đăng kí thành công ! Bạn có muốn đăng nhập luôn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }


    }
}
