using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DTO
{
    public class ShowGioHang
    {
        public int ID_User { get; set; }
        public int MaSach { get; set; }
        public int? MaDocGia = null;
        public string TenSach { get; set; }
        public int GiaTien { get; set; }
        public byte[] DataAnh { get; set; }


    }
}
