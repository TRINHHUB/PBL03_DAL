using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PBL03_DAL.DAL
{
    public class DAL_QLSACH
    {
        private static DAL_QLSACH _Instance;
        public List<cbbTacGia> GetcbbTG()
        {
            List<cbbTacGia> list = new List<cbbTacGia>();
            using (QLNS db = new QLNS())
            {
                foreach (tacgia i in db.tacgias)
                {
                    list.Add(new cbbTacGia
                    {
                        ID = i.matacgia,
                        Name = i.tentacgia
                    });
                }
                return list;
            }

        }
        public List<cbbNXB> GetcbbNXB()
        {
            List<cbbNXB> list = new List<cbbNXB>();
            QLNS db = new QLNS();
            foreach (nxb i in db.nxbs)
            {
                list.Add(new cbbNXB
                {
                    ID = i.manxb,
                    Name = i.tennxb

                });


            }
            return list;
        }
        public List<cbbTheLoai> GetcbbTheLoai()
        {
            List<cbbTheLoai> list = new List<cbbTheLoai>();
            QLNS db = new QLNS();
            foreach (theloai i in db.theloais)
            {
                list.Add(new cbbTheLoai
                {
                    ID = i.matheloai,
                    Name = i.tentheloai

                });

            }
            return list;
        }

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
            using (QLNS db = new QLNS())
            {
                List<sach> dgs = new List<sach>();
                dgs = db.saches.ToList();
                return dgs;
            }
        }
        public List<nxb> GetAllNXB()
        {
            using (QLNS db = new QLNS())
            {
                List<nxb> nxbs = new List<nxb>();
                nxbs = db.nxbs.ToList();
                return nxbs;
            }
        }

        public List<tacgia> GetAllTG()
        {
            using (QLNS db = new QLNS())
            {
                List<tacgia> tgs = new List<tacgia>();
                tgs = db.tacgias.ToList();
                return tgs;
            }
        }

        public List<theloai> GetAllTL()
        {
            using (QLNS db = new QLNS())
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
        public void AddSach(sach sachadd)
        {
            using (QLNS db = new QLNS())
            {
                db.saches.Add(sachadd);
                db.SaveChanges();
            }

        }
        public void Updatesach(sach editsach)
        {
            using (QLNS db = new QLNS())
            {
                // Tìm đối tượng cần cập nhật trong cơ sở dữ liệu
                sach SachneedtoEdit = db.saches.FirstOrDefault(p => p.masach == editsach.masach);

                if (SachneedtoEdit != null)
                {

                    SachneedtoEdit.masach = editsach.masach;
                    SachneedtoEdit.tensach = editsach.tensach;
                    SachneedtoEdit.namxb = editsach.namxb;
                    SachneedtoEdit.manxb = editsach.manxb;
                    SachneedtoEdit.matheloai = editsach.matheloai;
                    SachneedtoEdit.matacgia = editsach.matacgia;
                    SachneedtoEdit.soluong = editsach.soluong;
                    SachneedtoEdit.ghichu = editsach.ghichu;
                    SachneedtoEdit.khusach = editsach.khusach;
                    SachneedtoEdit.giatien = editsach.giatien;
             
                    db.SaveChanges();

                  
                }
            }
        }
    }
}

