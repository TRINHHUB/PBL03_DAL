using Guna.UI2.WinForms;
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
    public partial class FormAddSach : Form
    {
        public FormAddSach()
        {
            InitializeComponent();
        }


        private void btnexitaddS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnnewS_Click(object sender, EventArgs e)
        {
            txtaddmaS.Text = "";
            txtaddtenS.Text = "";
            txtaddnamxbS.Text = "";
            txtaddnxbS.Text = "";
            txtaddtheloaiS.Text = "";
            txtaddtacgiaS.Text = "";
            txtaddsoluongS.Text = "";
            txtaddghichuS.Text = "";
            txtKhusach.Text = "";
            txtgiatienS.Text = "";
            PictureBoxaddS.Image = null;
        }

        private void btnSelectS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Open Image";
            ofdlg.Filter = "Image file(*.PNG;*.JPG;*.GIF) |*.PNG;*.JPG;*.GIF";

            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                PictureBoxaddS.Image = Image.FromFile(ofdlg.FileName);
            }
        }

        private void btnokaddS_Click(object sender, EventArgs e)
        {
            Image pimg = PictureBoxaddS.Image;
            ImageConverter Converter = new ImageConverter();
            var ImageConver = Converter.ConvertTo(pimg, typeof(byte[]));

            QLNS qlns = new QLNS();
            sach s = new sach();
            s.masach = Convert.ToInt32(txtaddmaS.Text);
            s.tensach = txtaddtenS.Text;
            s.namxb = Convert.ToInt32(txtaddnamxbS.Text);
            s.manxb = Convert.ToInt32(txtaddnxbS.Text);
            s.matheloai = Convert.ToInt32(txtaddtheloaiS.Text);
            s.matacgia = Convert.ToInt32(txtaddtacgiaS.Text);
            s.soluong = Convert.ToInt32(txtaddsoluongS.Text);
            s.ghichu = txtaddghichuS.Text;
            s.khusach = txtKhusach.Text;
            s.giatien = Convert.ToInt32(txtgiatienS.Text);
            s.dataanh = (byte[])ImageConver;

            qlns.saches.Add(s);
            qlns.SaveChanges();
            MessageBox.Show("Thêm ảnh thành công!");
        }
    }
}
