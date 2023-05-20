using PBL03_DAL.BLL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03_DAL
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            List<string> li = new List<string>();
            li.Add("Thống kê theo ngày");
            li.Add("Sách bạn chạy nhất");
            foreach (string i in li)
            {
                cbbDoanhThu.Items.Add(i);
            }
        }
        public void ShowThongKe()
        {
            if (cbbDoanhThu.SelectedIndex == 0)
            {
                try
                {
                    
                        DateTime dt = dtpDoanhThu.Value;
                        DateTime dt2 = dtp2DoanhThu.Value;
                        List<ThongKeShowTheoNgay> list = new List<ThongKeShowTheoNgay>();
                        list = BLL_QLSACH.Instance.getThongKeTheoNgay(dt, dt2);

                        if (list != null)
                        {
                            dgrDoanhThu.DataSource = list;
                            int tongtien = 0;
                            foreach (var i in list)
                            {
                                tongtien += (int)i.TongTien;
                            }
                            lbDoanhThu.Text = tongtien.ToString();
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
            else
            {
                try
                {
                    int tongtienBestSellingBooks = 0;
                    List<ThongKeShow> list = new List<ThongKeShow>();
                    list = BLL_QLSACH.Instance.getThongKeMax();
                    foreach (ThongKeShow i in list)
                    {
                        tongtienBestSellingBooks += (int)i.TongTien;
                        

                    }

                    if (list != null)
                    {
                        dgrDoanhThu.DataSource = list;
                        lbDoanhThu.Text = tongtienBestSellingBooks.ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.ToString());
                }

            }
        }


        private void btnxemDoanhThu_Click(object sender, EventArgs e)
        {
            ShowThongKe();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            this.Close();
            mf.Show();
        }
    }

}