using Guna.UI2.WinForms;
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

namespace PBL03_DAL
{
    public partial class MuaSach : Form
    {
        private static List<object> selectedRows;
        public MuaSach()
        {
            InitializeComponent();
            selectedRows = new List<object>();
        }

     /*   private void btnMua_Click(object sender, EventArgs e)
        {
           
            using (QLNS qlns = new QLNS())
            {
                if(dgvSmua.SelectedRows.Count > 0)
                {
                    int id = (int)dgvSmua.SelectedRows[0].Cells["masach"].Value;
                    var l = qlns.saches.Where(p => p.masach == id).Select(p => new
                    {
                        p.tensach,
                        p.namxb,
                        p.nxb.tennxb,
                        p.tacgia.tentacgia,
                        p.theloai.tentheloai,
                        p.ghichu,
                        p.giatien,
                        p.khusach
                    }).ToList();
                    selectedRows.AddRange(new object[] {l}) ;         
                    sach s = qlns.saches.Find(id);
                    s.soluong -= 1;
                    dgvSdamua.DataSource = selectedRows;
                    qlns.SaveChanges();


                }
                
            }
        }*/

        private void MuaSach_Load(object sender, EventArgs e)
        {
            /*ShowDGV();*/
            Guna2Panel pn = new Guna2Panel();
            pn.Size = new Size(189, 285);
            pn.Location = new Point(20, 71);

            Guna2PictureBox ptb = new Guna2PictureBox();
            ptb.Size = new Size(155, 200);
            ptb.Location = new Point(18, 5);
            ptb.SizeMode = PictureBoxSizeMode.Zoom;

            Guna2HtmlLabel lb = new Guna2HtmlLabel();
            lb.Location = new Point(0, 215);
            lb.Size = new Size(101, 17);
            lb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lb.Text ="ABC";
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



            Guna2Button btn1 = new Guna2Button();
            btn1.Location = new Point(110, 250);
            btn1.Size = new Size(61, 25);
            btn1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn1.Text = "Thêm";
            btn1.FillColor = Color.FromArgb(94, 148, 255);
            btn1.ForeColor = Color.White;
            btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;





            pn.Controls.Add(btn);
            pn.Controls.Add(btn1);
            pn.Controls.Add(lb);
            pn.Controls.Add(ptb);
            

            guna2GroupBox1.Controls.Add(pn);
        }
        /*public void ShowDGV()
        {
            QLNS qlns = new QLNS();
            dgvSmua.DataSource = qlns.saches
            .Select(p => new
            {
                p.masach,
                p.tensach,
                p.namxb,
                p.nxb.tennxb,
                p.tacgia.tentacgia,
                p.theloai.tentheloai,
                p.soluong,
                p.ghichu,
                p.khusach,
                p.giatien
            }).ToList();
        }*/
    }
}
