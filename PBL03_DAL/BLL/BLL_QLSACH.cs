using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL03_DAL.BLL
{
    public class BLL_QLSACH
    {
        private static BLL_QLSACH _Instance;

        public static BLL_QLSACH Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLSACH();
                return _Instance;

            }
            private set { }
        }
        private BLL_QLSACH() { }
        public List<sachshow> Getsach()
        {
            List<sachshow> dg = new List<sachshow>();
            using (QLNS db = new QLNS())
            {
                dg = (db.saches).Select(p => new sachshow
                {
                    ma = p.masach,
                    ten = p.tensach,
                    nam = (int)p.namxb,
                    tennxb = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                    tentacgia = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                    tentheloai = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                    sl = (int)p.soluong,
                    note = p.ghichu,
                    khu = p.khusach,
                    gia = (int)p.giatien
                }).ToList();
                return dg;
            }
        }
        public bool DelSach(List<int> ids)
        {
            using (QLNS db = new QLNS())
            {
                List<sach> dels = db.saches.Where(p => ids.Contains(p.masach)).ToList();


                if (dels.Count > 0)
                {
                    db.saches.RemoveRange(dels);
                    db.SaveChanges();
                }
            }
            return true;
        }
        public void addsach(sach sachadd)
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


        public sach GetsachByidSach(int id)
        {
            using (QLNS db = new QLNS())
            {
                sach dg = new sach();
                foreach (sach i in db.saches)
                {
                    if (id == i.masach)
                    {
                        dg = i;
                    }
                }
                return dg;
            }
        }
        public string GetNXBById(int id)
        {
            using (QLNS db = new QLNS())
            {
                string tennxb = db.nxbs.Where(n => n.manxb == id).Select(n => n.tennxb).FirstOrDefault();
                return tennxb;
            }
        }
        public string GetTacGiaById(int id)
        {
            using (QLNS db = new QLNS())
            {
                string tentacgia = db.tacgias.Where(n => n.matacgia == id).Select(n => n.tentacgia).FirstOrDefault();
                return tentacgia;
            }
        }
        public string GetTheLoaiById(int id)
        {
            using (QLNS db = new QLNS())
            {
                string tentheloai = db.theloais.Where(n => n.matheloai == id).Select(n => n.tentheloai).FirstOrDefault();
                return tentheloai;
            }
        }
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
        public List<Lichsugiaodich> history(int Idps)
        {
            List<Lichsugiaodich> list = new List<Lichsugiaodich>();
            using(QLNS db = new QLNS())
            {
                list = db.connects
                           .Where(p => p.ID_User == Idps)
                           .Where(p => p.madocgia != null)
                           .Select(p => new Lichsugiaodich
                           {
                               Name = db.saches.Where(s => s.masach == p.masach).Select(s => s.tensach).FirstOrDefault(),
                               dt = (DateTime)p.thoigiangiaodich,
                               sl = (int)p.soluongmua,
                               sum  = p.tongtien == null ? 0 : (int)p.tongtien
                           }).ToList();
                return list;
            }


        }
        public List<sachshow> Findsach(String txtfind, String typefind)
        {
            List<sachshow> li = new List<sachshow>();
            using (QLNS db = new QLNS())
            {
                if (txtfind == "" && typefind == "All")
                {
                    li = Getsach();
                } 
                    
                 else if (typefind == "Tên sách" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.tensach.Contains(txtfind)).Select(p => new sachshow
                    {
                        ma = p.masach,
                        ten = p.tensach,
                        nam = (int)p.namxb,
                        tennxb = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        tentacgia = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        tentheloai = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        sl = (int)p.soluong,
                        note = p.ghichu,
                        khu = p.khusach,
                        gia = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Nhà xuất bản" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.nxb.tennxb.Contains(txtfind)).Select(p => new sachshow
                    {
                        ma = p.masach,
                        ten = p.tensach,
                        nam = (int)p.namxb,
                        tennxb = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        tentacgia = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        tentheloai = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        sl = (int)p.soluong,
                        note = p.ghichu,
                        khu = p.khusach,
                        gia = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Tác giả" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.tacgia.tentacgia.Contains(txtfind)).Select(p => new sachshow
                    {
                        ma = p.masach,
                        ten = p.tensach,
                        nam = (int)p.namxb,
                        tennxb = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        tentacgia = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        tentheloai = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        sl = (int)p.soluong,
                        note = p.ghichu,
                        khu = p.khusach,
                        gia = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Thể loại" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.theloai.tentheloai.Contains(txtfind)).Select(p => new sachshow
                    {
                        ma = p.masach,
                        ten = p.tensach,
                        nam = (int)p.namxb,
                        tennxb = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        tentacgia = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        tentheloai = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        sl = (int)p.soluong,
                        note = p.ghichu,
                        khu = p.khusach,
                        gia = (int)p.giatien
                    }).ToList();
                }
                return li;
            }
        }  
        }

    }

   



