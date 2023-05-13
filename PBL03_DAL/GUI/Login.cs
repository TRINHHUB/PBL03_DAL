﻿using PBL03_DAL.BLL;
using PBL03_DAL.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                if (data.MatKhau.Equals(password)) { 
                    MessageBox.Show("Đăng nhập thành công!");
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


           

            //// kiểm tra xem tài khoản có tồn tại trong cơ sở dữ liệu hay không
            //if(user.Count() > 0)
            //{
            //    // tồn tại,tiếp theo kiểm tra xem mật khẩu có đúng hay không ?
            //    // do user là 1 collection( ở trên đã ToList() ) nên chỉ lấy bản ghi đầu tiên để kiểm tra
            //    if (user[0].MatKhau.Equals(password))
            //    {
            //        //khớp
            //        MessageBox.Show("Đăng nhập thành công!");
            //        if (user[0].ID_Position == 1)
            //        {
            //            MainForm mf = new MainForm();
            //            this.Hide();
            //            mf.Show();
            //        }
            //        else
            //        {
            //            FormDocGia fgd = new FormDocGia();
            //            this.Hide();
            //            fgd.Show();
            //        }
            //        CurrentUser.ID_User = user[0].ID_User;
            //    }
            //    else
            //    {
            //        //không khớp
            //        MessageBox.Show("Mật khẩu không đúng,vui lòng nhập lại");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Tài khoản không tồn tại trong hệ thống");
            //}
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
    }
}
