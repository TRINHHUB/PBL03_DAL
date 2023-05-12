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
    public partial class FormEditDocGia : Form
    {
        private int iddocgia;
        public delegate void Mydel();
        public Mydel d { get; set; }
        public FormEditDocGia(int id)
        {
            InitializeComponent();
            iddocgia = id;
            setGUI();
        }
        private void setGUI()
        {
            if (BLL_QLDG.Instance.GetdocgiaByid(iddocgia) != null)
            {
                txteditmaDG.Text = iddocgia.ToString();
                txtedittenDG.Text = BLL_QLDG.Instance.GetdocgiaByid(iddocgia).hoten.ToString();
                dtpickereditDG.Text = BLL_QLDG.Instance.GetdocgiaByid(iddocgia).ngaysinh.ToString();
                rd1DGedit.Checked = BLL_QLDG.Instance.GetdocgiaByid(iddocgia).gioitinh.Value;
                txteditdiachiDG.Text = BLL_QLDG.Instance.GetdocgiaByid(iddocgia).diachi.ToString();
                txteditsdtDG.Text = BLL_QLDG.Instance.GetdocgiaByid(iddocgia).sdt.ToString();
 }
        }
        private void btnokeditDG_Click(object sender, EventArgs e)
        {
            docgia docgiaedit = new docgia
            {
                madocgia = Convert.ToInt32(txteditmaDG.Text),
                hoten = txtedittenDG.Text,
                ngaysinh = Convert.ToDateTime(dtpickereditDG.Value),
                gioitinh = rd1DGedit.Checked,
                diachi = txteditdiachiDG.Text,
                sdt = txteditsdtDG.Text
            

            };
            BLL_QLDG.Instance.Updatedocgia(docgiaedit);
            d();
            MessageBox.Show("Bạn đã sửa thành công thông tin sách!");
            this.Dispose();
        }

        private void btnexiteditDG_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
