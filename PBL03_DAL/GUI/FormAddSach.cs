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
            cbb_NXB.Items.AddRange(DAL_QLSACH.Instance.GetcbbNXB().ToArray());
        }
        public void GetcbbTL()
        {
            cbbTL.Items.AddRange(DAL_QLSACH.Instance.GetcbbTheLoai().ToArray());

        }
        public void GetcbbTG()
        {
            //cbbTG.Items.AddRange(BLL_QLDG.Instance.Getcbbtacgia().ToArray());
            cbbTG.Items.AddRange(DAL_QLSACH.Instance.GetcbbTG().ToArray());
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
            sach s = new sach
            {
                tensach = txtaddtenS.Text,
                namxb = Convert.ToInt32(txtaddnamxbS.Text),
                manxb = ((cbbNXB)cbb_NXB.SelectedItem).ID,
                matheloai = ((cbbTheLoai)cbbTL.SelectedItem).ID,
                matacgia = ((cbbTacGia)cbbTG.SelectedItem).ID,
                soluong = Convert.ToInt32(txtaddsoluongS.Text),
                ghichu = txtaddghichuS.Text,
                khusach = txtKhusach.Text,
                giatien = Convert.ToInt32(txtgiatienS.Text),
                dataanh = (byte[])ImageConver
            };
            BLL_QLSACH.Instance.addsach(s);
            this.Dispose();

        }
    }
}

        //string tentl = cbbtl.text;
        //int matl = qlns.theloais.where(p => p.tentheloai == tentl).select(p => p.matheloai).firstordefault();

        //string tennxbget = cbbnxb.text;
        //int manxb = qlns.nxbs.where(p => p.tennxb == tennxbget).select(p => p.manxb).firstordefault();


        //string tentg = cbbtg.text;
        //int matg = qlns.tacgias.where(p => p.tentacgia == tentg).select(p => p.matacgia).firstordefault();


        //try
        //{
        //    Image pimg = PictureBoxaddS.Image;
        //    ImageConverter Converter = new ImageConverter();
        //    var ImageConver = Converter.ConvertTo(pimg, typeof(byte[]));

        //    s.tensach = txtaddtenS.Text;
        //    s.namxb = Convert.ToInt32(txtaddnamxbS.Text);
        //    s.manxb = maNXB;
        //    s.matheloai = matl;
        //    s.matacgia = matg;
        //    s.soluong = Convert.ToInt32(txtaddsoluongS.Text);
        //    s.ghichu = txtaddghichuS.Text;
        //    s.khusach = txtKhusach.Text;
        //    s.giatien = Convert.ToInt32(txtgiatienS.Text);
        //    s.dataanh = (byte[])ImageConver;


        //    qlns.saches.Add(s);
        //    qlns.SaveChanges();
        //    MessageBox.Show("Thêm sách thành công!");
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.ToString());
        //}
 //   }

        //private void FormAddSach_Load(object sender, EventArgs e)
        //{
            
        //}
    


