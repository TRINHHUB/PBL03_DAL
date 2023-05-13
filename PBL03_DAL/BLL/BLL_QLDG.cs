using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.BLL
{
    public class BLL_QLDG
    {
        private static BLL_QLDG _Instance;

        public static BLL_QLDG Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLDG();
                return _Instance;

            }
            private set { }
        }

       
        private BLL_QLDG() { }


        //public List<DGSHOW> getdg()
        //{
        //    using (QLNS db = new QLNS()) {
        //        List<DGSHOW> dg = new List<DGSHOW>();
        //        dg = db.docgias.ToList().Select(p => new DGSHOW
        //        {
        //            id = p.madocgia,
        //            name = p.hoten,
        //            ngay = (DateTime)p.ngaysinh,
        //            address = p.diachi,
        //            dt = p.sdt,
        //            gender = Convert.ToBoolean(p.gioitinh)
        //        }).ToList();
        //        return dg;
        //    }
        //}
        public dynamic getalldg()
        {
            using (QLNS db = new QLNS())
            {
                return (from p in db.docgias
                        let Gioitinh = (p.gioitinh == true) ? "Nam" : "Nữ"
                        select new
                        {
                            p.madocgia,
                            p.hoten,
                            p.ngaysinh,
                            p.diachi,
                            p.sdt,
                            Gioitinh,                    
                        }).ToList();

            }
        }
        public void addDocGia(docgia Docgiaadd)
        {
            using (QLNS db = new QLNS())
            {
                db.docgias.Add(Docgiaadd);
                db.SaveChanges();
            }
        }
        public bool DelDocgia(List<int> iddg)
        {
            //DAL_QLDG.Instance.DelDocGia(iddg);
            using (QLNS db = new QLNS())
            {
                List<docgia> deldg = db.docgias.Where(p => iddg.Contains(p.madocgia)).ToList();

                if (deldg.Count > 0)
                {
                    db.docgias.RemoveRange(deldg);
                    db.SaveChanges();
                }
            }
            return true;

        }
        public void Updatedocgia(docgia editdocgia)
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

        public docgia GetdocgiaByid(int id)
        {
            using (QLNS db = new QLNS()) {
                docgia dg = new docgia();
                foreach (docgia i in db.docgias )
                {
                    if (id == i.madocgia)
                    {
                        dg = i;
                    }
                }
                return dg;
            }
        }
        //public List<docgia> FindDocGia(String txt, String type)
        //{
        //    List<docgia> li = new List<docgia>();
        //    using(QLNS db = new QLNS())
        //    {
        //        if (txt == "" && type =="All")
        //        {
        //            li = getalldg();
        //        }
        //        else if()
        //        {
        //            li = db.docgias.Where(p => p.hoten.Contains(txt)).Select(p => new DGSHOW
        //            {
        //                id = p.madocgia,
        //                name = p.hoten,
        //                ngay = (DateTime)p.ngaysinh,
        //                address = p.diachi,
        //                dt = p.sdt,
        //                gender = Convert.ToBoolean(p.gioitinh)
        //            }).ToList();
        //        }).ToList();
        //        else if()
        //        {

        //        }
        //        else if()
        //        {

        //        }
        //        return li;
        //    }
            
        //}       
    }
}