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
    public partial class ThongTinSach : Form
    {
        public ThongTinSach()
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
            image s = new image();

            s.masach = Convert.ToInt32(txtMSimage.Text);
            s.dataanh = (byte[])ImageConver;

            qlns.images.Add(s);
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
    }
}
