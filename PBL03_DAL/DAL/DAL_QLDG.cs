using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PBL03_DAL.DAL
{
    public class DAL_QLDG
    {
        private static DAL_QLDG _Instance;

        public static DAL_QLDG Instance
        {
            get
            {

                if (_Instance == null)
                    _Instance = new DAL_QLDG();
                return _Instance;
            }
            private set { }
        }

       
        public List<docgia> GetDG()
        {
            using (QLNS db = new QLNS())
            {
                List<docgia> dgs = new List<docgia>();
                dgs = db.docgias.ToList();
                return dgs;               
            }
        }
        public void AddDocGia(docgia docgiaAdd)
        {
            using (QLNS db = new QLNS())
            {
                db.docgias.Add(docgiaAdd);
                db.SaveChanges();
            }

        }
        public bool DelDocGia(List<int> iddocgia)
        {
            using (QLNS db = new QLNS())
            {
                List<docgia> deldg = db.docgias.Where(p => iddocgia.Contains(p.madocgia)).ToList();

                if (deldg.Count > 0)
                {
                    db.docgias.RemoveRange(deldg);
                    db.SaveChanges();
                }
            }
            return true;
        }
        public void UpdateDocGia(docgia editdocgia)
        {
            using (QLNS db = new QLNS())
            {
               
                docgia DocgianeedtoEdit = db.docgias.FirstOrDefault(p => p.madocgia == editdocgia.madocgia);

                if (DocgianeedtoEdit != null)
                {

                    DocgianeedtoEdit.madocgia = editdocgia.madocgia;
                    DocgianeedtoEdit.hoten = editdocgia.hoten;
                    DocgianeedtoEdit.ngaysinh = editdocgia.ngaysinh;
                    DocgianeedtoEdit.gioitinh = editdocgia.gioitinh;
                    DocgianeedtoEdit.diachi = editdocgia.diachi;
                    DocgianeedtoEdit.sdt = editdocgia.sdt;

                    db.SaveChanges();


                }
            }
        }
    }
}
