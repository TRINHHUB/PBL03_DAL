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

namespace PBL03_DAL.GUI
{
    public partial class FormEditSach : Form
    {
        private int idsach;
        public delegate void Mydel();
        public Mydel d { get; set; }
        public FormEditSach(int id )
        {
            InitializeComponent();
            idsach = id;
            this.StartPosition = FormStartPosition.CenterScreen;
            GetcbbNXB();
            GetcbbTL();
            GetcbbTG();
            
            setGUI();

        }
        public void GetcbbNXB()
        {
            cbb_NXB.Items.AddRange(BLL_QLSACH.Instance.GetcbbNXB().ToArray());
        }
        public void GetcbbTL()
        {
            cbbTL.Items.AddRange(BLL_QLSACH.Instance.GetcbbTheLoai().ToArray());

        }
        public void GetcbbTG()
        {
            //cbbTG.Items.AddRange(BLL_QLDG.Instance.Getcbbtacgia().ToArray());
            cbbTG.Items.AddRange(BLL_QLSACH.Instance.GetcbbTG().ToArray());
        }
        private void setGUI()
        {
            if(BLL_QLSACH.Instance.GetsachByidSach(idsach) != null)
            {
                txtIDSach.Text = idsach.ToString();
                txtnameS.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).tensach;
                txtNamXB.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).namxb.ToString();
                cbb_NXB.Text = BLL_QLSACH.Instance.GetNXBById(Convert.ToInt32(BLL_QLSACH.Instance.GetsachByidSach(idsach).manxb));
                cbbTL.Text = BLL_QLSACH.Instance.GetTheLoaiById(Convert.ToInt32(BLL_QLSACH.Instance.GetsachByidSach(idsach).matheloai));
                cbbTG.Text = BLL_QLSACH.Instance.GetTacGiaById(Convert.ToInt32(BLL_QLSACH.Instance.GetsachByidSach(idsach).matacgia));
                txtSoluong.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).soluong.ToString();
                txtGhiChu.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).ghichu;
                txtKhusach.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).khusach;
                txtgiatienS.Text = BLL_QLSACH.Instance.GetsachByidSach(idsach).giatien.ToString();
            }
        }



        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void getData()
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            sach sachedit = new sach
            {
                masach =Convert.ToInt32(txtIDSach.Text),
                tensach =txtnameS.Text,
                namxb=Convert.ToInt32(txtNamXB.Text),
                manxb  = ((cbbNXB)cbb_NXB.SelectedItem).ID,
                matheloai = ((cbbTheLoai)cbbTL.SelectedItem).ID,
                matacgia = ((cbbTacGia)cbbTG.SelectedItem).ID,
                soluong = Convert.ToInt32(txtSoluong.Text),
                ghichu = txtGhiChu.Text,
                khusach = txtKhusach.Text,
                giatien = Convert.ToInt32(txtgiatienS.Text),

            };
            BLL_QLSACH.Instance.Updatesach(sachedit);
            d();
            MessageBox.Show("Bạn đã sửa thành công thông tin sách!");
            this.Dispose();
        }
    }
}
