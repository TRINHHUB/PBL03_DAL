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

namespace PBL03_DAL.GUI
{
    public partial class ThongKeTrongNgay : Form
    {
        public ThongKeTrongNgay()
        {
            InitializeComponent();
        }
        

        private void ThongKeTrongNgay_Load(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Today + new TimeSpan(0, 0, 0);
            lbstart.Text = startTime.ToString();/*ToString("dd/MM/yyyy HH:mm:ss");*/
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // Cập nhật thời gian sau mỗi 1 giây
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lbnow.Text = now.ToString();

        }

        private void btnxemDoanhThu_Click(object sender, EventArgs e)
        {
            ShowThongKeTrongNgay();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormNhanVien fnv = new FormNhanVien();
            this.Hide();
            fnv.Show();
        }
        private void ShowThongKeTrongNgay()
        {
            try
            {

                DateTime startTime = DateTime.Today + new TimeSpan(0, 0, 0);
                DateTime dt = startTime;
                DateTime dt2 = DateTime.Now;
                List<ThongKeShowTheoNgay> list = new List<ThongKeShowTheoNgay>();
                list = BLL_QLSACH.Instance.getThongKeTheoNgay(dt, dt2);

                if (list != null)
                {
                    dgvTrongNgay.DataSource = list;
                    int tongtien = 0;
                    foreach (var i in list)
                    {
                        tongtien += (int)i.TongTien;
                    }
                    lbDoanhThuTrongNgay.Text = tongtien.ToString();
                }
                else
                {
                    MessageBox.Show("Không có giao dịch trong thời gian này");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.ToString());
            }
        }
    }
}
