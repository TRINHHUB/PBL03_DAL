using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Guna.UI2.WinForms;
using System.Runtime.Remoting.Contexts;
using System.Management;
using System.Windows.Documents;
using System.Security.Cryptography.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using PBL03_DAL.DTO;

namespace PBL03_DAL
{
    public partial class ThongTinSach : Form
    {
        private Point mouseDownLocation;
        public ThongTinSach()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(guna2GroupBox1_MouseDown);
            this.MouseMove += new MouseEventHandler(guna2GroupBox1_MouseMove);
        }

        private void LoadUserControl()
        {
            QLNS qlns = new QLNS();
            sach s = new sach();
            // load anh
            var image = qlns.saches.Select(p => p.dataanh).ToArray();
            var tensach = qlns.saches.Select(p => p.tensach).ToArray();

            int x = 20, y = 71;
            int count = 0;


            for (int i = 0; i < image.Length; i++)
            {
                Guna2Panel pn = new Guna2Panel();
                pn.Size = new Size(189, 285);
                pn.Location = new Point(x, y);

                Guna2PictureBox ptb = new Guna2PictureBox();
                ptb.Size = new Size(155, 200);
                ptb.Location = new Point(12, 5);
                ptb.Image = Image.FromStream(new MemoryStream(image[i]));
                ptb.SizeMode = PictureBoxSizeMode.Zoom;

                Guna2HtmlLabel lb = new Guna2HtmlLabel();
                lb.Location = new Point(0, 215);
                lb.Size = new Size(101, 17);
                lb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb.Text = tensach[i].ToString();
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
                btn1.Text = "Thêm";
                btn1.FillColor = Color.FromArgb(94, 148, 255);
                btn1.ForeColor = Color.White;
                btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btn1.Cursor = Cursors.Hand;
                btn1.Name = lb.Text;






                pn.Controls.Add(btn);
                pn.Controls.Add(btn1);
                pn.Controls.Add(lb);
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
                    if (count == 4)
                    {
                        x = 20;
                        y += 300;
                    }
                }

                guna2GroupBox1.Controls.Add(pn);
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
                QLNS qlns = new QLNS();
                string lbContainNameSachMua = ((Guna2Button)sender).Name;
                int currentUserID = CurrentUser.ID_User;
                CurrentNameSach.currentNameSach = lbContainNameSachMua;

                var thanhtoan = qlns.saches.Join(
                    qlns.connects,
                    s => s.masach,
                    con => con.masach,
                    (s, con) => new
                    {
                        s.tensach,
                        s.masach,
                        s.soluong,
                        con.madocgia,
                        con.ID_User
                    }
                    );
                //var thanhtoancheckUser = qlns.accountts.Where(p => p.ID_User == currentUserID).Select(p => p.ID_User).FirstOrDefault();
                var SelectMaSachToThanhToan = thanhtoan.Where(p => p.tensach == lbContainNameSachMua).Select(p => p.masach).FirstOrDefault();
                //var ThanhtoanFull = qlns.connects.Where(con => con.masach == SelectMaSachToThanhToan).Select(con => new { con.manhanvien, con.madocgia, con.ID_User }).FirstOrDefault();
                var getMadocgiaThanhToan = qlns.docgias.Where(p => p.ID_User == currentUserID).Select(p => p.madocgia).FirstOrDefault();


                if(true)
                {
                    connect c = new connect();
                    c.ID_User = currentUserID;
                    c.masach = SelectMaSachToThanhToan;
                    c.madocgia = getMadocgiaThanhToan;
                    c.thoigiangiaodich = DateTime.Now;

                    qlns.connects.Add(c);
                    qlns.SaveChanges();

                }

                FormMuaSach fms = new FormMuaSach();
                this.Hide();
                fms.Show();
            }



        }
        private void btn1_Click(object sender, EventArgs e)
        {
            // Xử lý khi button được click
            DialogResult result = MessageBox.Show("Bạn có muốn thêm sách vào giỏ hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý kết quả từ người dùng
            if (result == DialogResult.Yes)
            {
                Guna2Button btn1 = sender as Guna2Button;
                QLNS qlns = new QLNS();
                //Lấy tên sách từ tên nút được chọn
                string lbContainNameSach = ((Guna2Button)sender).Name;
                int currentUserID = CurrentUser.ID_User;

                var gioHang = qlns.saches.Where(s => s.tensach == lbContainNameSach).Select(p => p.masach).FirstOrDefault();
                var gioHangcheckUser = qlns.accountts.Where(p => p.ID_User == currentUserID).Select(p => p.ID_User).FirstOrDefault();
                var checkExistGioHang = qlns.connects.Where(p => p.ID_User == currentUserID && p.madocgia == null).Select(p => p.masach).FirstOrDefault();
                
                if(gioHang != checkExistGioHang)
                {
                    connect con = new connect();
                    con.masach = gioHang;
                    con.ID_User = gioHangcheckUser;
                    qlns.connects.Add(con);
                    qlns.SaveChanges();
                    MessageBox.Show("Sách đã được thêm vào giỏ hàng");
                }
            }
                else
                {
                    MessageBox.Show("Sách này đã có trong giỏ hàng!");
                }
                

        }
        Guna2Panel pn1 = new Guna2Panel();






        private void ThongTinSach_Load(object sender, EventArgs e)
        {

            LoadUserControl();
            guna2GroupBox1.AutoScroll = true;
            // Tùy chỉnh thanh cuộn ngang
            guna2GroupBox1.HorizontalScroll.Enabled = false; // Tắt tính năng cuộn ngang
            guna2GroupBox1.HorizontalScroll.Visible = false; // Ẩn thanh cuộn ngang
            guna2GroupBox1.HorizontalScroll.Maximum = 0; // Đặt giá trị tối đa của thanh cuộn ngang

            // Tùy chỉnh thanh cuộn dọc
            guna2GroupBox1.VerticalScroll.Enabled = true; // Kích hoạt tính năng cuộn dọc
            guna2GroupBox1.VerticalScroll.Visible = true; // Hiển thị thanh cuộn dọc
            guna2GroupBox1.VerticalScroll.Maximum = 10000; // Đặt giá trị tối đa của thanh cuộn dọc


        }

        private void guna2GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new Point(e.X, e.Y);
        }

        private void guna2GroupBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the new form location based on the mouse movement
                int newX = this.Location.X + e.X - mouseDownLocation.X;
                int newY = this.Location.Y + e.Y - mouseDownLocation.Y;

                // Set the new form location
                this.SetDesktopLocation(newX, newY);
            }
        }

        private void btnThoatTTS_Click(object sender, EventArgs e)
        {
            FormDocGia fdg = new FormDocGia();
            this.Hide();
            fdg.Show();
        }

        private void btnexitViewSachDocGia_Click(object sender, EventArgs e)
        {

        }
    }
}
