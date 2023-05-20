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
using PBL03_DAL.BLL;
using System.Security.Cryptography;

namespace PBL03_DAL
{
    public partial class SignUp : Form
    {       
        public SignUp()
        {
            InitializeComponent();
            LoadCBBPs();
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
            if (username == "" || password == "" || repassword == "" || gmail == "" )
            {
                MessageBox.Show(" Nhập đầy đủ thông tin cần thiết để đăng ký!");
            }
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

                // Tạo salt ngẫu nhiên
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);

                }
                string saltString = Convert.ToBase64String(salt);
                string saltAndHash = HashPassword(password, saltString);


                accountt ac = new accountt();

                if(cbbSignUp.SelectedIndex == 0)
                {
                    ac.ID_Position = 1;
                }
                if(cbbSignUp.SelectedIndex == 1)
                {
                    ac.ID_Position = 3;
                }
                else
                {
                    ac.ID_Position = 2;
                }
                ac.TaiKhoan = txtTKres.Text;
                ac.MatKhau = saltAndHash;
                ac.Salt = saltString;
                ac.Gmail = txtGMres.Text;
                BLL_LOGIN.Instance.addtk(ac);
                

                if (MessageBox.Show("Đăng kí thành công ! Bạn có muốn đăng nhập luôn không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Login login = new Login();
                    this.Close();
                    login.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

       public void LoadCBBPs()
        {
            List<cbbPosition> li = new List<cbbPosition>();
            li = BLL_LOGIN.Instance.GetcbbPs();
            cbbSignUp.Items.AddRange(li.ToArray());

        }
        private string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[saltBytes.Length + passwordBytes.Length];
            saltBytes.CopyTo(saltedPasswordBytes, 0);
            passwordBytes.CopyTo(saltedPasswordBytes, saltBytes.Length);

            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }

    }
}
