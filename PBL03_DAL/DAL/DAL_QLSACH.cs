using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DAL
{
    public class DAL_QLSACH
    {
        private static DAL_QLSACH _Instance;

        public static DAL_QLSACH Instance
        {
            get
            {

                if (_Instance == null)
                    _Instance = new DAL_QLSACH();
                return _Instance;
            }
            private set { }
        }
        public List<sach> GetAllSach()
        {
            using(QLNS db = new QLNS())
            {
                List<sach> dgs = new List<sach>();
                dgs = db.saches.ToList();
                return dgs;
            }
        }
        public List<nxb> GetAllNXB()
        {
            using(QLNS db = new QLNS())
            {
                List<nxb> nxbs = new List<nxb>();
                nxbs = db.nxbs.ToList();
                return nxbs;
            }    
        }

        public List<tacgia>GetAllTG()
        {
            using(QLNS db = new QLNS())
            {
                List<tacgia> tgs = new List<tacgia>();
                tgs = db.tacgias.ToList();
                return tgs;
            }
        }

        public List<theloai>GetAllTL()
        {
            using(QLNS db = new QLNS())
            {
                List<theloai> tls = new List<theloai>();
                tls = db.theloais.ToList();
                return tls;
            }
        }
        public bool DelSach(List<int> idsach)
        {
            using (QLNS db = new QLNS())
            {
                // Tìm danh sách đối tượng cần xóa trong cơ sở dữ liệu
                List<sach> dels = db.saches.Where(p => idsach.Contains(p.masach)).ToList();

                if (dels.Count > 0)
                {
                    // Xóa danh sách đối tượng khỏi cơ sở dữ liệu
                    db.saches.RemoveRange(dels);
                    db.SaveChanges();

                    // Thực hiện các hành động khác sau khi xóa thành công
                    // ...
                }
            }
            return true;
        }
    }
}
