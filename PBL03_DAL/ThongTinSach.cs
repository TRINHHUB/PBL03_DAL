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
                pn.Size = new Size(189 ,285);
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

                Guna2Button btn2 = new Guna2Button();
                btn2.Location = new Point(165, 10);
                btn2.Size = new Size(15, 15);
                btn2.Font = new Font("Tahoma", 8, FontStyle.Bold);
                btn2.Text = "+";
                btn2.TextAlign = HorizontalAlignment.Center;
                btn2.FillColor = Color.FromArgb(94, 148, 255);
                btn2.ForeColor = Color.Black;
                btn2.Cursor = Cursors.Hand;






                pn.Controls.Add(btn);
                pn.Controls.Add(btn1);
                pn.Controls.Add(btn2);
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
                btn2.MouseHover += new EventHandler(btn2_MouseHover);
                btn2.MouseLeave += new EventHandler(btn2_MouseLeave);

            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            // Xử lý khi button được click
            // mua,hiện form,xuất hiện đầy đủ các thông tin của sách,số dư ví,số lượng,....
            
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            // Xử lý khi button được click
            DialogResult result = MessageBox.Show("Bạn có muốn thêm sách vào giỏ hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý kết quả từ người dùng
            if (result == DialogResult.Yes)
            {
                Guna2Button btn = sender as Guna2Button;

                QLNS qlns = new QLNS();
                //Lấy tên sách từ tên nút được chọn
                string lbContainNameSach = ((Guna2Button)sender).Name;

                var gioHang = qlns.saches.Where(s => s.tensach == lbContainNameSach).Select(p => p.masach).FirstOrDefault();
                giohang ghDB = new giohang();
                ghDB.masach = gioHang;
                qlns.giohangs.Add(ghDB);
                qlns.SaveChanges();
                MessageBox.Show("Sách đã được thêm vào giỏ hàng");
            }

        }
        Guna2Panel pn1 = new Guna2Panel();
        private void btn2_MouseHover(object sender, EventArgs e)
        {
            QLNS qlns = new QLNS();
            string lbContainNameSach = ((Guna2Button)sender).Name;
            var getMaNXB = qlns.saches.Where( s => s.tensach == lbContainNameSach).Select(p => p.manxb).FirstOrDefault();
            
            var getNXBfromMa = qlns.nxbs.Where( nxb => nxb.manxb == getMaNXB ).Select( p => p.tennxb).ToArray();
            var soluong = qlns.saches.Select(p => p.soluong).ToArray();
            var giatien = qlns.saches.Select(p => p.giatien).ToArray();
            

            for (int i = 0; i < giatien.Length; i++)
            {
                pn1.Size = new Size(250, 230);
                pn1.BackColor = Color.FromArgb(147, 198, 184);
                pn1.Location = new Point(40, 91);
                pn1.Visible = true;

                Guna2HtmlLabel lb1 = new Guna2HtmlLabel();
                lb1.Size = new Size(51, 15);
                lb1.Location = new Point(13, 65);
                lb1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb1.Text = "Thể Loại:";

                Guna2HtmlLabel lb2 = new Guna2HtmlLabel();
                lb2.Size = new Size(47, 15);
                lb2.Location = new Point(13, 30);
                lb2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb2.Text = "Tác Giả:";

                Guna2HtmlLabel lb3 = new Guna2HtmlLabel();
                lb3.Size = new Size(47, 15);
                lb3.Location = new Point(13, 100);
                lb3.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb3.Text = "Nhà xuất bản:";

                Guna2HtmlLabel lb4 = new Guna2HtmlLabel();
                lb4.Size = new Size(47, 15);
                lb4.Location = new Point(13, 135);
                lb4.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb4.Text = "Số lượng còn:";

                Guna2HtmlLabel lb5 = new Guna2HtmlLabel();
                lb5.Size = new Size(47, 15);
                lb5.Location = new Point(13, 170);
                lb5.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb5.Text = "Giá bán:";

                Guna2HtmlLabel lb6 = new Guna2HtmlLabel();
                lb6.Size = new Size(47, 15);
                lb6.Location = new Point(65, 30);
                lb6.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb6.Text = ""; // tacgia

                Guna2HtmlLabel lb7 = new Guna2HtmlLabel();
                lb7.Size = new Size(47, 15);
                lb7.Location = new Point(65, 65);
                lb7.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb7.Text = ""; //theloai

                Guna2HtmlLabel lb8 = new Guna2HtmlLabel();
                lb8.Size = new Size(47, 15);
                lb8.Location = new Point(65, 100);
                lb8.Font = new Font("Segoe UI", 9, FontStyle.Bold);
/*              lb8.Text = getNXBfromMa[i].ToString();
*/
                Guna2HtmlLabel lb9 = new Guna2HtmlLabel();
                lb9.Size = new Size(47, 15);
                lb9.Location = new Point(65, 135);
                lb9.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb9.Text = soluong[i].ToString();

                Guna2HtmlLabel lb10 = new Guna2HtmlLabel();
                lb10.Size = new Size(47, 15);
                lb10.Location = new Point(65, 170);
                lb10.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lb10.Text = giatien[i].ToString();




                pn1.Controls.Add(lb1);
                pn1.Controls.Add(lb2);
                pn1.Controls.Add(lb3);
                pn1.Controls.Add(lb4);
                pn1.Controls.Add(lb5);
                pn1.Controls.Add(lb6);
                pn1.Controls.Add(lb7);
                pn1.Controls.Add(lb8);
                pn1.Controls.Add(lb9);
                pn1.Controls.Add(lb10);



                this.Controls.Add(pn1);
                pn1.BringToFront();


        }

        }
        private void btn2_MouseLeave(object sender, EventArgs e)
        {
            pn1.Visible = false;
        }






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
    }
}
