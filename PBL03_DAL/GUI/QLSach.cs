using PBL03_DAL.BLL;
using PBL03_DAL.DTO;
using PBL03_DAL.GUI;
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
    public partial class QLSach : Form
    {
        public QLSach()
        {
            InitializeComponent();
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Hide();
            mf.Show();
        }

        private void btnthemS_Click(object sender, EventArgs e)
        {
            FormAddSach fas = new FormAddSach();
            fas.Show();
        }

        private void btnviewS_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }
        public void ShowDGV()
        {

            dgrS.DataSource = BLL_QLSACH.Instance.Getsach().ToList();
        }

        private void btnxoaS_Click(object sender, EventArgs e)
        {
            if (dgrS.SelectedRows.Count > 0)
            {
                List<int> madel = new List<int>();
                foreach (DataGridViewRow i in dgrS.SelectedRows)
                {
                   
                    
                       // madel.Add(Convert.ToInt32(i.Cells[0].Value));
                        if (i.Cells[0].Value != null)
                        {
                            madel.Add(Convert.ToInt32(i.Cells[0].Value));
                            BLL_QLSACH.Instance.DelSach(madel);
                            MessageBox.Show("Bạn đã xóa thành công sách này");
                            ShowDGV();
                        } 
                        else
                        {
                            MessageBox.Show("Chọn dòng cần xóa");
                        }
                    
                }
            }
        }

        private void btneditS_Click(object sender, EventArgs e)
        {
            if(dgrS.SelectedRows.Count == 1)
            {
                int idsach =Convert.ToInt32( dgrS.SelectedRows[0].Cells[0].Value);
                FormEditSach form = new FormEditSach(idsach);
                form.d += new FormEditSach.Mydel(ShowDGV);
                form.Show();

            }
          
                
        }

        private void btntkS_Click(object sender, EventArgs e)
        {
           dgrS.DataSource= BLL_QLSACH.Instance.Findsach(txttimkiemS.Text, cbb_typefind.SelectedItem.ToString());
        }
       
    }
}
