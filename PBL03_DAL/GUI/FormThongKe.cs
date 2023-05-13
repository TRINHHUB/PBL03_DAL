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
                    using (QLNS qlns = new QLNS())
                    {
                        DateTime dt = dtpDoanhThu.Value;
                        DateTime dt2 = dtp2DoanhThu.Value;

                        var thongKe = qlns.connects
                            .Where(p => p.thoigiangiaodich >= dt && p.thoigiangiaodich <= dt2)
                            .Where(p => p.madocgia != null)
                            .Select(p => new
                            {
                                TenNhanVien = qlns.nhanviennhasaches.Where(n => n.manhanvien == p.manhanvien).Select(n => n.tennhanvien).FirstOrDefault(),
                                TenDocGia = qlns.docgias.Where(d => d.madocgia == p.madocgia).Select(d => d.hoten).FirstOrDefault(),
                                TenSach = qlns.saches.Where(s => s.masach == p.masach).Select(s => s.tensach).FirstOrDefault(),
                                ThoiGianGiaoDich = p.thoigiangiaodich,
                                SoLuongMua = p.soluongmua,
                                TongTien = p.tongtien,
                            }).ToList();
                        if (thongKe != null)
                        {
                            dgrDoanhThu.DataSource = thongKe;
                            int tongtien = 0;
                            foreach (var i in thongKe)
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

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.ToString());
                }
            }
            else
            {
                using (var qlns = new QLNS())
                {
                    var bestSellingBooks = qlns.connects
                    .GroupBy(c => c.masach)
                    .Select(g => new {
                        MaSach = g.Key,
                        TongSoLuongMua = g.Sum(c => c.soluongmua),
                        Tongtien = g.Sum(c => c.tongtien),

                    })
                    .OrderByDescending(b => b.TongSoLuongMua)
                    .ToList();                                                                  // toán tử null coalescing ??
                    int maxSoLuongMua = bestSellingBooks.FirstOrDefault()?.TongSoLuongMua ?? 0; // ? kiểm tra đối tượng trước có null hay không,nếu null trả  về null tránh lỗi NullReferenceExcpetion
                    var booksWithMaxSoLuongMua = bestSellingBooks.Where(b => b.TongSoLuongMua == maxSoLuongMua);

                    var getTenSachFromMa = from c in booksWithMaxSoLuongMua
                                           join s in qlns.saches on c.MaSach equals s.masach
                                           select new { TenSach = s.tensach, tongSoLuongMua = c.TongSoLuongMua, tongTien = c.Tongtien };


                    if (getTenSachFromMa != null)
                    {
                        dgrDoanhThu.DataSource = getTenSachFromMa.ToList(); ;
                        int tongtienBestSellingBooks = 0;
                        foreach (var i in booksWithMaxSoLuongMua)
                        {
                            tongtienBestSellingBooks += (int)i.Tongtien;
                        }
                        lbDoanhThu.Text = tongtienBestSellingBooks.ToString();
                    }

                }

            }
        }


        private void btnxemDoanhThu_Click(object sender, EventArgs e)
        {
            ShowThongKe();
        }
    }

}