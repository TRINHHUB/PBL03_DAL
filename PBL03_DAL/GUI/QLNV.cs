using PBL03_DAL.BLL;
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
    public partial class QLNV : Form
    {
        public QLNV()
        {
            InitializeComponent();
        }

        private void btnexitNV_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }
        private void dgrNV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dgrNV.CurrentRow.Index;
            int id =Convert.ToInt32( dgrNV.Rows[i].Cells["manhanvien"].Value);
            //if(BLL_QLNV .Instance.GetNVByidNv(id) != null)
            //{
            //    txt_nameNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).tennhanvien;
            //    txt_addressNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).diachi;
            //    if (dgrNV.Rows[i].Cells["gioitinh"].Value.ToString() == "Nam") radioButton1.Checked = true;
            //    txt_sdtNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).sdt;

            //}
            //int i = dgrNV.CurrentRow.Index;
            txt_nameNV.Text = dgrNV.Rows[i].Cells["tennhanvien"].Value.ToString();
            txt_addressNV.Text = dgrNV.Rows[i].Cells["diachi"].Value.ToString();
            txt_sdtNV.Text = dgrNV.Rows[i].Cells["sdt"].Value.ToString();
            if (dgrNV.Rows[i].Cells["gioitinh"].Value.ToString() == "Nam") radioButton1.Checked = true;
            else radioButton1.Checked = false;
        }
        private void btnviewNV_Click(object sender, EventArgs e)
        {

            ShowDGV();
        }
        public void ShowDGV()
        {

            dgrNV.DataSource = BLL_QLNV.Instance.getallnv();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            nhanviennhasach s = new nhanviennhasach();
          
                s.tennhanvien = txt_nameNV.Text;
                s.diachi = txt_addressNV.Text;
                s.sdt = txt_sdtNV.Text;
                s.gioitinh = radioButton1.Checked;
            BLL_QLNV.Instance.addNv(s);
            ShowDGV();
               
              
        }

        private void btnxoaNV_Click(object sender, EventArgs e)
        {
            if(dgrNV.SelectedRows.Count > 0)
            {
                List<int> madel = new List<int>();
                foreach (DataGridViewRow i in dgrNV.SelectedRows)
                {


                    // madel.Add(Convert.ToInt32(i.Cells[0].Value));
                    if (i.Cells[0].Value != null)
                    {
                        madel.Add(Convert.ToInt32(i.Cells[0].Value));
                        BLL_QLNV.Instance.Delnv(madel);
                        MessageBox.Show("Bạn đã xóa thành công sách này");
                        ShowDGV();
                        
                    }
                    else
                    {
                        MessageBox.Show("Chon dong can xoa");
                    }

                }
            }
        }

        private void btntimkiemNV_Click(object sender, EventArgs e)
        {
           dgrNV.DataSource= BLL_QLNV.Instance.FindNV(txttimkiemNV.Text);
        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgrNV_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dgrNV.CurrentRow.Index;
            int id = Convert.ToInt32(dgrNV.Rows[i].Cells["manhanvien"].Value);
            if (BLL_QLNV.Instance.GetNVByidNv(id) != null)
            {
                txt_nameNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).tennhanvien;
                txt_addressNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).diachi;
                if (dgrNV.Rows[i].Cells["gioitinh"].Value.ToString() == "Nam") radioButton1.Checked = true;
                else radioButton2.Checked = true;
                txt_sdtNV.Text = BLL_QLNV.Instance.GetNVByidNv(id).sdt;
            }
 
        }

        private void btnsuaNV_Click(object sender, EventArgs e)
        {
            nhanviennhasach nv = new nhanviennhasach
            {
                tennhanvien = txt_nameNV.Text,
                diachi = txt_addressNV.Text,
                gioitinh = radioButton1.Checked,
                sdt = txt_sdtNV.Text,
            };
            BLL_QLNV.Instance.UpdateNV(nv);
            ShowDGV();
        }
    }
}
