using Guna.UI2.WinForms;
using PBL03_DAL.BLL;
using PBL03_DAL.DAL;
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
    public partial class FormAddSach : Form
    {
        public FormAddSach()
        {
            InitializeComponent();
            GetcbbNXB();
            GetcbbTL();
            GetcbbTG();
        }


        private void btnexitaddS_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnnewS_Click(object sender, EventArgs e)
        {
            txtaddtenS.Text = "";
            txtaddnamxbS.Text = "";
            txtaddsoluongS.Text = "";
            txtaddghichuS.Text = "";
            txtKhusach.Text = "";
            txtgiatienS.Text = "";
            PictureBoxaddS.Image = null;
        }
        public void GetcbbNXB()
        {
            cbbNXB.Items.AddRange(DAL_QLDG.Instance.GetcbbNXB().ToArray());
        }
        public void GetcbbTL()
        {
            cbbTL.Items.AddRange(DAL_QLDG.Instance.GetcbbTheLoai().ToArray());

        }
        public void GetcbbTG()
        {
            //cbbTG.Items.AddRange(BLL_QLDG.Instance.Getcbbtacgia().ToArray());
            cbbTG.Items.AddRange(DAL_QLDG.Instance.GetcbbTG().ToArray());
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
            QLNS qlns  = new QLNS ();          
            sach s = new sach();

            string tentl = cbbTL.Text;
             int matl = qlns.theloais.Where(p => p.tentheloai == tentl).Select(p => p.matheloai).FirstOrDefault();

            string tennxbget = cbbNXB.Text;
            int maNXB = qlns.nxbs.Where(p => p.tennxb == tennxbget).Select(p => p.manxb).FirstOrDefault();


            string tentg = cbbTG.Text;
            int matg = qlns.tacgias.Where(p => p.tentacgia == tentg).Select(p => p.matacgia).FirstOrDefault();

          
            try
            {
                Image pimg = PictureBoxaddS.Image;
                ImageConverter Converter = new ImageConverter();
                var ImageConver = Converter.ConvertTo(pimg, typeof(byte[]));
                
                s.tensach = txtaddtenS.Text;
                s.namxb = Convert.ToInt32(txtaddnamxbS.Text);
                s.manxb = maNXB;
                s.matheloai = matl;
                s.matacgia = matg;
                s.soluong = Convert.ToInt32(txtaddsoluongS.Text);
                s.ghichu = txtaddghichuS.Text;
                s.khusach = txtKhusach.Text;
                s.giatien = Convert.ToInt32(txtgiatienS.Text);
                s.dataanh = (byte[])ImageConver;
                

                qlns.saches.Add(s);
                qlns.SaveChanges();
                MessageBox.Show("Thêm sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAddSach_Load(object sender, EventArgs e)
        {
            
        }
    }
}
