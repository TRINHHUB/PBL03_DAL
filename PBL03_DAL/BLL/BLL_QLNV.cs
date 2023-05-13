using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.BLL
{
    public class BLL_QLNV
    {
        private static BLL_QLNV _Instance;

        public static BLL_QLNV Instance {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLNV();
                return _Instance;

            }
            private set { }
        }
        private BLL_QLNV() {}
        public dynamic getallnv()
        {
            using (QLNS db = new QLNS())
            {
                return (from p in db.nhanviennhasaches
                        let Gioitinh = (p.gioitinh == true) ? "Nam" : "Nữ"
                        select new
                        {
                            p.manhanvien,
                            p.tennhanvien,
                            Gioitinh,
                            p.diachi,
                            p.sdt
                        }).ToList();
            }
        }
        public bool Delnv(List<int> idNV)
        {
            using (QLNS db = new QLNS())
            {
                List<nhanviennhasach> delnv = db.nhanviennhasaches.Where(p => idNV.Contains(p.manhanvien)).ToList();


                if (delnv.Count > 0)
                {
                    db.nhanviennhasaches.RemoveRange(delnv);
                    db.SaveChanges();
                }
            }
            return true;
        }
        public void addNv(nhanviennhasach nvadd)
        {
            using (QLNS db = new QLNS())
            {
                db.nhanviennhasaches.Add(nvadd);
                db.SaveChanges();
            }
        }
        public List<cbbNV> GetcbbNV()
        {
            List<cbbNV> list = new List<cbbNV>();
            using (QLNS db = new QLNS())
            {
                foreach (nhanviennhasach i in db.nhanviennhasaches)
                {
                    list.Add(new cbbNV
                    {
                        id = i.manhanvien,
                        name = i.tennhanvien

                    });

                }
            }
            return list;
        }
        public nhanviennhasach GetNVByidNv(int id)
        {
            using (QLNS db = new QLNS())
            {
                nhanviennhasach   nv = new nhanviennhasach();
                foreach (nhanviennhasach i in db.nhanviennhasaches)
                {
                    if (id == i.manhanvien)
                    {
                        nv = i;
                    }
                }
                return nv;
            }
        }
        public void UpdateNV(nhanviennhasach editnv)
        {
            using (QLNS db = new QLNS())
            {
                nhanviennhasach nvneedtoEdit = db.nhanviennhasaches.FirstOrDefault(p => p.manhanvien == editnv.manhanvien);
                if (nvneedtoEdit != null)
                {
                   // nvneedtoEdit.manhanvien = editnv.manhanvien;
                    nvneedtoEdit.tennhanvien = editnv.tennhanvien;
                    nvneedtoEdit.diachi = editnv.diachi;
                    nvneedtoEdit.gioitinh = editnv.gioitinh;
                    nvneedtoEdit.sdt = editnv.sdt;
                    db.SaveChanges();
                }
            }
        }
        public dynamic FindNV(String txtfind)
        {
            using (QLNS db = new QLNS())
            {
                return (from p in db.nhanviennhasaches
                        where p.tennhanvien.Contains(txtfind)
                        let Gioitinh = (p.gioitinh == true) ? "Nam" : "Nữ"
                        select new
                        {
                            p.manhanvien,
                            p.tennhanvien,
                            Gioitinh,
                            p.diachi,
                            p.sdt
                        }).ToList();
            }
        }
    }


}

