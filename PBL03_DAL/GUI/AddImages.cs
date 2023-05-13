using PBL03_DAL.DTO;
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
    public partial class AddImages : Form
    {
        public AddImages()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /*guna2PictureBox1.Image = null;*/
            Image pimg = guna2PictureBox1.Image;
            ImageConverter Converter = new ImageConverter();
            var ImageConver = Converter.ConvertTo(pimg, typeof(byte[]));

           QLNS qlns = new QLNS();
            sach s = new sach();

            /*s.masach = Convert.ToInt32(txtMSimage.Text);*/
            s.dataanh = (byte[])ImageConver;

            qlns.saches.Add(s);
            qlns.SaveChanges();
            MessageBox.Show("Thêm ảnh thành công!");

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Open Image";
            ofdlg.Filter = "Image file(*.PNG;*.JPG;*.GIF) |*.PNG;*.JPG;*.GIF";

            if(ofdlg.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = Image.FromFile(ofdlg.FileName);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            QLNS qlns = new QLNS();

            var image = qlns.saches.FirstOrDefault( p => p.masach == 3);
            if(image != null)
            {
                var ms = new MemoryStream(image.dataanh);// đọc dữ liệu nhị phân
                guna2PictureBox2.Image = Image.FromStream(ms);
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            txtMSimage.Text = "";
            guna2PictureBox1.Image= null;
        }
    }
}
