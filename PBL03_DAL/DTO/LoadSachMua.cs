using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DTO
{
    public class LoadSachMua
    {
        public string TenTheLoai { get; set; }
        public string TenNXB { get; set; }
        public string TenTacGia { get; set; }
        public string KhuSach { get; set; }
        public int GiaTien { get; set; }
        public byte[] DataAnh { get; set; }
        public string TenSachMua { get; set; }
    }
}
