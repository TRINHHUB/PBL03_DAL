using Guna.UI2.WinForms;
using PBL03_DAL.BLL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03_DAL
{
    public partial class GioHangDocGia : Form
    {
        public GioHangDocGia()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát không");
            FormDocGia fdg = new FormDocGia();
            this.Hide();
            fdg.Show();
        }

        private void GioHangDocGia_Load(object sender, EventArgs e)
        {
            LoadUserControl();
        }
        private void LoadUserControl()
        {
            // load anh
            int currentUserID = CurrentUser.ID_User;
            List<ShowGioHang> list = new List<ShowGioHang>();
            list =  BLL_QLSACH.Instance.dgvGioHang();
            var image = list.Where(p => p.ID_User == currentUserID && p.MaDocGia == null ).Select(p => p.DataAnh).ToArray();
            var nameBook = list.Where(p => p.ID_User == currentUserID && p.MaDocGia == null ).Select(p => p.TenSach).ToArray();




            int x = 20, y = 71;
            int count = 0;


            for (int i = 0; i < image.Length; i++)
            {
                Guna2Panel pn = new Guna2Panel();
                pn.Size = new Size(189, 285);
                pn.Location = new Point(x, y);

                Guna2PictureBox ptb = new Guna2PictureBox();
                ptb.Size = new Size(155, 200);
                ptb.Location = new Point(18, 5);
                ptb.Image = Image.FromStream(new MemoryStream(image[i]));
                ptb.SizeMode = PictureBoxSizeMode.Zoom;

                Guna2HtmlLabel lb = new Guna2HtmlLabel();
                lb.Location = new Point(0, 215);
                lb.Size = new Size(101, 17);
                lb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb.Text = nameBook[i].ToString();
                lb.Anchor = AnchorStyles.None;
                lb.TextAlignment = ContentAlignment.MiddleCenter;
                pn.AutoScroll = false;
                lb.AutoSize = false;
                lb.Size = pn.Size;

                Guna2Button btn = new Guna2Button();
                btn.Location = new Point(20, 250);
                btn.Size = new Size(61, 25);
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Text = "Mua";
                btn.FillColor = Color.FromArgb(94, 148, 255);
                btn.ForeColor = Color.White;
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                btn.Cursor = Cursors.Hand;
                btn.Name = lb.Text;




                Guna2Button btn1 = new Guna2Button();
                btn1.Location = new Point(110, 250);
                btn1.Size = new Size(61, 25);
                btn1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn1.Text = "Xóa";
                btn1.FillColor = Color.FromArgb(94, 148, 255);
                btn1.ForeColor = Color.White;
                btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btn1.Cursor = Cursors.Hand;
                btn1.Name = lb.Text;





                pn.Controls.Add(btn);
                pn.Controls.Add(btn1);
                pn.Controls.Add(ptb);


                count++;
                if (count == 4)
                {
                    count = 0;
                    x = 20;
                    y += 300;
                }
                else
                {
                    x += 231;
                }

                grbGioHang.Controls.Add(pn);
                btn.Click += new EventHandler(btn_Click);
                btn1.Click += new EventHandler(btn1_Click);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            // Xử lý khi button được click
            DialogResult result = MessageBox.Show("Bạn có muốn mua sách này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Guna2Button btn = sender as Guna2Button;
                string lbContainNameSachMua = ((Guna2Button)sender).Name;
                int currentUserID = CurrentUser.ID_User;
                CurrentNameSach.currentNameSach = lbContainNameSachMua;

                try
                {
                    BLL_QLSACH.Instance.MuaSachFromGioHang(lbContainNameSachMua, currentUserID);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa Sách khỏi giỏ hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý kết quả từ người dùng
            if (result == DialogResult.Yes)
            {
                int currentUserID = CurrentUser.ID_User;
                string lbContainNameSach = ((Guna2Button)sender).Name;
                Guna2Button btn1 = sender as Guna2Button;

                try
                {
                    BLL_QLSACH.Instance.DeleteGioHang(lbContainNameSach,currentUserID);
                    grbGioHang.Controls.Clear();
                    LoadUserControl();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }
    }
}