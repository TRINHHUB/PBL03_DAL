using Guna.UI2.WinForms;
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
            QLNS qlns = new QLNS();
            // load anh
            var gioHangSach = qlns.giohangs
                .Join(
                qlns.saches,
                giohang => giohang.masach,
                sach => sach.masach,
                (giohang, sach) => new
                {
                    giohang.magiohang,
                    giohang.masach,
                    sach.tensach,
                    sach.dataanh,
                    sach.giatien
                });
            var image = gioHangSach.Select(p => p.dataanh).ToArray();
            var nameBook = gioHangSach.Select(p => p.tensach).ToArray();

  


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
            // mua
            // những thứ thay đổi: số lượng,tiền docgia,tiền admin, nếu số lượng  > 0,thì số lượng - theo lượng mua
            // join bảng adminS,docgia,sach;,lấy viadmin,vidocgia,dataanh,tensach,giatien,soluong...
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn mua sách này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý kết quả từ người dùng
            if (result == DialogResult.Yes)
            {
                Guna2Button btn = sender as Guna2Button;
                QLNS qlns = new QLNS();
                string lbContainNameSach = ((Guna2Button)sender).Name;
                var sachcanmua = qlns.saches.Select(p => new { p.masach,p.tensach, p.soluong, p.giatien, p.dataanh }).Where(p => p.tensach == lbContainNameSach).FirstOrDefault();

 //               var thongtinthanhtoan = from tt in qlns.sachmuas
 //                                       join dg in qlns.docgias on tt.madocgia equals dg.madocgia
//                                        join ad in qlns.admin on tt.maadmin equals ad.maadmin
 //                                       where tt.masach == sachcanmua.masach
 //                                       select new { dg.walletdocgia, ad.walletadmin };

                ThanhToanSach tts = new ThanhToanSach();
                this.Hide();
                tts.Show();



            }

        }
        private void btn1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa Sách khỏi giỏ hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý kết quả từ người dùng
            if (result == DialogResult.Yes)
            {
                Guna2Button btn1 = sender as Guna2Button;

                QLNS qlns = new QLNS();
                var jointoDel = qlns.giohangs
                .Join(
                qlns.saches,
                giohang => giohang.masach,
                sach => sach.masach,
                (giohang, sach) => new
                {
                    giohang.magiohang,
                    giohang.masach,
                    sach.tensach,
                });
                //Lấy tên sách từ tên nút được chọn
                string lbContainNameSach = ((Guna2Button)sender).Name;
                var SelectMaSachToDel = jointoDel.Where(p => p.tensach == lbContainNameSach).Select(p => p.masach).FirstOrDefault();
                var giohangToDelete = qlns.giohangs.Where(gh => gh.masach == SelectMaSachToDel).FirstOrDefault();

                if(giohangToDelete != null)
                {
                    qlns.giohangs.Remove(giohangToDelete);
                    qlns.SaveChanges();
                }
                grbGioHang.Controls.Clear();
                LoadUserControl();
            }
        }
    }
}
