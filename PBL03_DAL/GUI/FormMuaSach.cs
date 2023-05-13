using PBL03_DAL.BLL;
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
    public partial class FormMuaSach : Form
    {
        public FormMuaSach()
        {
            InitializeComponent();
            GetcbbNV();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int soluongmua = Convert.ToInt32(txtSLMua.Text);
            int currentUserID = CurrentUser.ID_User;
            string currentNS = CurrentNameSach.currentNameSach;
            string TenNhanVienChon = cbbNVmua.SelectedItem.ToString();
            using (QLNS qlns = new QLNS())
            {
                var getMaNhanVien = qlns.nhanviennhasaches.Where(p => p.tennhanvien == TenNhanVienChon).Select(p => p.manhanvien).FirstOrDefault();//lay ma nhan vien 
                var thanhtoancheckUser = qlns.accountts.Where(p => p.ID_User == currentUserID).Select(p => p.ID_User).FirstOrDefault();
                var SelectMaSachToThanhToan = qlns.saches.Where(p => p.tensach == currentNS).Select(p => p.masach).FirstOrDefault();//thanh toan
                var Sach = qlns.saches.Where(p => p.tensach == currentNS).Select(p => new { p.manxb, p.matacgia, p.matheloai, p.soluong, p.khusach, p.giatien, p.tensach, p.dataanh }).FirstOrDefault();//lay thong tin sach mua
                var getIDToUpdate = qlns.connects.Where(p => p.masach == SelectMaSachToThanhToan && p.ID_User == currentUserID && p.madocgia != null).Select(p => p.ID_connect).FirstOrDefault();
                var updateConnect = qlns.connects.FirstOrDefault(p => p.ID_connect == getIDToUpdate);

                var getMasachUpdate = qlns.saches.Where(p => p.tensach == currentNS).Select(p => p.masach).FirstOrDefault();
                var UpdateSach = qlns.saches.FirstOrDefault(p => p.masach == getMasachUpdate);

                int MaNhanVien = Convert.ToInt32(getMaNhanVien);
                if (updateConnect != null)
                {
                    updateConnect.manhanvien = MaNhanVien;
                    updateConnect.soluongmua = soluongmua;
                    updateConnect.tongtien = soluongmua * Sach.giatien;
                }

                if (UpdateSach != null)
                {
                    UpdateSach.soluong -= soluongmua;
                    
                }
                qlns.SaveChanges();
            }

         
            MessageBox.Show("Bạn đã mua thành công!");


        }
        public void GetcbbNV()
        {
            cbbNVmua.Items.AddRange(BLL_QLNV.Instance.GetcbbNV().ToArray());
        }

        private void FormMuaSach_Load(object sender, EventArgs e)
        {
            using (QLNS qlns = new QLNS())
            {
                string currentNS = CurrentNameSach.currentNameSach;
                var Sach = qlns.saches.Where(p => p.tensach == currentNS).Select(p => new { p.manxb, p.matacgia, p.matheloai, p.soluong, p.khusach, p.giatien, p.tensach, p.dataanh }).FirstOrDefault();
                var getNXBfromMa = qlns.nxbs.Where(p => p.manxb == Sach.manxb).Select(p => p.tennxb).FirstOrDefault();
                var getTLfromMa = qlns.theloais.Where(p => p.matheloai == Sach.matheloai).Select(p => p.tentheloai).FirstOrDefault();
                var getTGfromMa = qlns.tacgias.Where(p => p.matacgia == Sach.manxb).Select(p => p.tentacgia).FirstOrDefault();

                lbTLmua.Text = getTLfromMa.ToString();
                lbTGmua.Text = getTGfromMa.ToString();
                lbNXBmua.Text = getNXBfromMa.ToString();
                lbKSmua.Text = Sach.khusach;
                lbTienmua.Text = Sach.giatien.ToString();
                ptbMua.Image = Image.FromStream(new MemoryStream(Sach.dataanh));
                lbTSmua.Text = Sach.tensach;


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ThongTinSach tts = new ThongTinSach();
            this.Hide();
            tts.Show();
        }

        // da lay duoc sach can mua,gan thong tin cho view
        // update sach do them manhanvien tu cbb ( neu du dieu kien masach = masachmua && currentID = current && madocgia != null)
        // 
    }
}