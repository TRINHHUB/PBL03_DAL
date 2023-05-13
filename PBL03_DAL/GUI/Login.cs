using PBL03_DAL.BLL;
using PBL03_DAL.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace PBL03_DAL
{//trua 1/5
    public partial class Login : Form
    {
        private QLNS qlns = new QLNS();
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true; //Để bắt sự kiện nhấn phím
            this.KeyDown += new KeyEventHandler(Login_KeyDown); 
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Enter))
            {
                btnLogin.PerformClick(); //Kich hoat nut Login
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SignUp sgu = new SignUp();
            this.Hide();
            sgu.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            string username = txtTK.Text;
            string password = txtMK.Text;
            CheckLogin(username,password);

        }
        public void CheckLogin(string username, string password)
        {
            if (BLL_LOGIN.Instance.GetAccountByUserName(username) != null)
            {
                accountt data = BLL_LOGIN.Instance.GetAccountByUserName(username);
                string hashPassWord = HashPassword(password, data.Salt);

                if (data.MatKhau.Equals(hashPassWord)) { 
                    if (data.ID_Position == 1)
                    {
                        MainForm mf = new MainForm();
                        this.Hide();
                        mf.Show();
                    }
                    else
                    {
                        FormDocGia fgd = new FormDocGia();
                        this.Hide();
                        fgd.Show();
                    }
                    CurrentUser.ID_User = data.ID_User;
                  }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng,vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại trong hệ thống");
            }
        }

        private void hideMK_CheckedChanged(object sender, EventArgs e)
        {
            if (hideMK.Checked.Equals(false))
            {
                txtMK.PasswordChar = '*';
            }
            else
            {
                txtMK.PasswordChar = '\0';
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

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
