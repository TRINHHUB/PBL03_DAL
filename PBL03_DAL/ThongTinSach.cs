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

        //private void LoadUserControl(string TenAnh, byte Anh,)

        private void ThongTinSach_Load(object sender, EventArgs e)
        {
            QLNS qlns = new QLNS();
            // load anh
            var image = qlns.saches.Select(p => p.dataanh).ToArray();
                var ms = new MemoryStream(image[0]);
                
            Guna2Panel pn = new Guna2Panel();
            pn.Size = new Size(189, 255);
            pn.Location = new Point(20, 71);

            Guna2PictureBox ptb = new Guna2PictureBox();
            ptb.Size = new Size(155, 200);
            ptb.Location = new Point(18, 5);
            ptb.Image = Image.FromStream(new MemoryStream(image[0]));
            ptb.SizeMode = PictureBoxSizeMode.Zoom;

            Guna2HtmlLabel lb = new Guna2HtmlLabel();
            lb.Location = new Point(51, 215);
            lb.Size = new Size(101, 17);
            lb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            //lb.Text = qlns.saches.Select(p => p.tensach.Where().ToString();

            pn.Controls.Add(lb);
            pn.Controls.Add(ptb);

            guna2GroupBox1.Controls.Add(pn);

            /* var query = from i in qlns.images
                         join s in qlns.saches on i.masach equals s.masach
                         select new { i.dataanh, s.tensach, s.masach };*/


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
    }
}
