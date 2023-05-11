using Guna.UI2.WinForms;
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

namespace PBL03_DAL
{
    public partial class ThanhToanSach : Form
    {
        public ThanhToanSach()
        {
            InitializeComponent();
        }

        private void guna2Button2_BackColorChanged(object sender, EventArgs e)
        {
            

           

        }

        public void ContainPanel(Boolean x)
        {
            Guna2Panel pn = new Guna2Panel();
            pn.Size = new Size(185, 231);
            pn.BackColor = Color.FromArgb(147, 198, 184);
            pn.Location = new Point(40, 91);
            pn.Visible = x;

            Guna2HtmlLabel lb1 = new Guna2HtmlLabel();
            lb1.Size = new Size(51, 15);
            lb1.Location = new Point(13, 59);
            lb1.Text = "Thể Loại";

            pn.Controls.Add(lb1);
            this.Controls.Add(pn);
        }
        Guna2Panel pn = new Guna2Panel();
        private void guna2Button2_MouseHover(object sender, EventArgs e)
        {
            QLNS qlns = new QLNS();
            var soluong = qlns.saches.Select(p => p.soluong).ToArray();
            var giatien = qlns.saches.Select(p => p.giatien).ToArray();

            for (int i = 0; i < giatien.Length; i++)
            {
                pn.Size = new Size(250, 230);
                pn.BackColor = Color.FromArgb(147, 198, 184);
                pn.Location = new Point(40, 91);
                pn.Visible = true;

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
                lb8.Text = "";//nxb

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




                pn.Controls.Add(lb1);
                pn.Controls.Add(lb2);
                pn.Controls.Add(lb3);
                pn.Controls.Add(lb4);
                pn.Controls.Add(lb5);
                pn.Controls.Add(lb6);
                pn.Controls.Add(lb7);
                pn.Controls.Add(lb8);
                pn.Controls.Add(lb9);
                pn.Controls.Add(lb10);



                this.Controls.Add(pn);
                pn.BringToFront();

            }

        }
        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            pn.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
