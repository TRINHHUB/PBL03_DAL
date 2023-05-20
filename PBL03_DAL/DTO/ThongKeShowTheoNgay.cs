using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DTO
{
    public class ThongKeShowTheoNgay
    {
        public string TenSach { get; set; }
        public string TenNhanVien { get; set; }
        public string TenDocGia { get; set; }
        public DateTime ThoiGianGiaoDich { get; set; }
        public int SoLuongMua { get; set; }
        public int TongTien { get; set; }
    }
}
