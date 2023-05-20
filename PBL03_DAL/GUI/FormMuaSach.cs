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
                try
                {
                    BLL_QLSACH.Instance.UpdateConnectSecond(soluongmua, currentNS, currentUserID, TenNhanVienChon);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            } 


        }
        public void GetcbbNV()
        {
            cbbNVmua.Items.AddRange(BLL_QLNV.Instance.GetcbbNV().ToArray());
        }

        private void FormMuaSach_Load(object sender, EventArgs e)
        {
           
                string currentNS = CurrentNameSach.currentNameSach;
                try
                {

                LoadSachMua loadSachMua = BLL_QLSACH.Instance.GetTTSachMua(currentNS);

                lbTLmua.Text = loadSachMua.TenTheLoai;
                lbTGmua.Text = loadSachMua.TenTacGia;
                lbNXBmua.Text = loadSachMua.TenNXB;
                lbKSmua.Text = loadSachMua.KhuSach;
                lbTienmua.Text = loadSachMua.GiaTien.ToString();
                ptbMua.Image = Image.FromStream(new MemoryStream(loadSachMua.DataAnh));
                lbTSmua.Text = loadSachMua.TenSachMua;


            }

            catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

               

            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}