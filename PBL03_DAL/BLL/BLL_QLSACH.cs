using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    MaSach = p.masach,
                    TenSach = p.tensach,
                    NamXB = (int)p.namxb,
                    TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                    TenTG= db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                    TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                    Soluong = (int)p.soluong,
                    GhiChu = p.ghichu,
                    KhuSach = p.khusach,
                    GiaTien = (int)p.giatien
                }).ToList();
                return dg;
            }
        }
        public LoadSachMua GetTTSachMua(string currentNS)
        {
            using (QLNS qlns = new QLNS())
            {
                var Sach = qlns.saches.Where(p => p.tensach == currentNS).Select(p => new { p.manxb, p.matacgia, p.matheloai, p.soluong, p.khusach, p.giatien, p.tensach, p.dataanh }).FirstOrDefault();
                var getNXBfromMa = qlns.nxbs.Where(p => p.manxb == Sach.manxb).Select(p => p.tennxb).FirstOrDefault();
                var getTLfromMa = qlns.theloais.Where(p => p.matheloai == Sach.matheloai).Select(p => p.tentheloai).FirstOrDefault();
                var getTGfromMa = qlns.tacgias.Where(p => p.matacgia == Sach.manxb).Select(p => p.tentacgia).FirstOrDefault();

                LoadSachMua loadSachMua = new LoadSachMua
                {
                    TenSachMua = Sach.tensach,
                    KhuSach = Sach.khusach,
                    GiaTien = Sach.giatien,
                    TenNXB = getNXBfromMa.ToString(),
                    TenTheLoai = getTLfromMa.ToString(),
                    TenTacGia = getTGfromMa.ToString(),
                    DataAnh = Sach.dataanh
                };

                return loadSachMua;
            }
        }
        public List<ShowESach> ShowESach()
        {
            List<ShowESach> list = new List<ShowESach>();
            using(QLNS qlns = new QLNS())
            {
                list = qlns.saches.Select(p => new ShowESach {
                    TenSach = p.tensach,
                    DataAnh = (byte[])p.dataanh 
                }).ToList();
                return list;

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
        public void UpdateHistoryFirst(string currentNameS, int currentID)
        {
            using (QLNS qlns = new QLNS())
            {
                var thanhtoan = qlns.saches.Join(
                                qlns.connects,
                                s => s.masach,
                                con => con.masach,
                                (s, con) => new
                                 {
                                     s.tensach,
                                     s.masach,
                                     s.soluong,
                                     con.madocgia,
                                     con.ID_User
                                 });
                var SelectMaSachToThanhToan = thanhtoan.Where(p => p.tensach == currentNameS).Select(p => p.masach).FirstOrDefault();
                var getMadocgiaThanhToan = qlns.docgias.Where(p => p.ID_User == currentID).Select(p => p.madocgia).FirstOrDefault();


                if (SelectMaSachToThanhToan != 0 && getMadocgiaThanhToan != 0)
                {
                    connect c = new connect();
                    c.ID_User = currentID;
                    c.masach = SelectMaSachToThanhToan;
                    c.madocgia = getMadocgiaThanhToan;
                    c.thoigiangiaodich = DateTime.Now;

                    qlns.connects.Add(c);
                    qlns.SaveChanges();
                }
            }
        }
        public void UpdateConnectSecond(int soluongmua,string currentNS,int currentID,string TenNhanVienChon)
        {
            using( QLNS qlns = new QLNS())
            {
                var getMaNhanVien = qlns.nhanviennhasaches.Where(p => p.tennhanvien == TenNhanVienChon).Select(p => p.manhanvien).FirstOrDefault();//lay ma nhan vien 
                var Sach = qlns.saches.Where(p => p.tensach == currentNS).Select(p => new { p.masach, p.manxb, p.matacgia, p.matheloai, p.soluong, p.khusach, p.giatien, p.tensach, p.dataanh }).FirstOrDefault();//lay thong tin sach mua
                var getIDToUpdate = qlns.connects.Where(p => p.masach == Sach.masach && p.ID_User == currentID && p.madocgia != null).Select(p => p.ID_connect).FirstOrDefault();
                var updateConnect = qlns.connects.FirstOrDefault(p => p.ID_connect == getIDToUpdate);

                var UpdateSach = qlns.saches.FirstOrDefault(p => p.masach == Sach.masach);

                int MaNhanVien = Convert.ToInt32(getMaNhanVien);
                if (updateConnect != null && UpdateSach != null)
                {
                    updateConnect.manhanvien = MaNhanVien;
                    updateConnect.soluongmua = soluongmua;
                    updateConnect.tongtien = soluongmua * Sach.giatien;
                    UpdateSach.soluong -= soluongmua;
                    qlns.SaveChanges();
                    MessageBox.Show("Bạn đã mua thành công!");

                }
            }
        }
        public void AddGioHang(string currentNS,int currentID)
        {
            using (QLNS qlns = new QLNS())
            {
                var gioHang = qlns.saches.Where(s => s.tensach ==  currentNS).Select(p => p.masach).FirstOrDefault();
                var gioHangcheckUser = qlns.accountts.Where(p => p.ID_User == currentID).Select(p => p.ID_User).FirstOrDefault();

                //dùng Any tránh việc lúc check thì có 1 đơn hàng đang trong quá trình xử lí
                bool exists = qlns.connects.Any(p => p.ID_User == currentID && p.masach == gioHang && p.madocgia == null);
                if (exists)
                {
                    MessageBox.Show("Sách này đã có trong giỏ hàng!");
                }
                else
                {
                    connect con = new connect();
                    con.masach = gioHang;
                    con.ID_User = gioHangcheckUser;
                    qlns.connects.Add(con);
                    qlns.SaveChanges();

                    MessageBox.Show("Sách đã được thêm vào giỏ hàng");
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
        public List<ShowGioHang> dgvGioHang()
        {
            List<ShowGioHang> list = new List<ShowGioHang>();
            using(QLNS qlns = new QLNS())
            {
                list = qlns.connects
                .Join(
                qlns.saches,
                connect => connect.masach,
                sach => sach.masach,
                (connect, sach) => new ShowGioHang
                {
                    ID_User = (int)connect.ID_User,
                    MaSach = (int)connect.masach,
                    MaDocGia = (int?)connect.madocgia,
                    TenSach = sach.tensach,
                    DataAnh = (byte[]) sach.dataanh,
                    GiaTien = (int)sach.giatien
                }).ToList();
                return list;
            }
        }
        public void MuaSachFromGioHang(string currentNS,int currentID)
        {
            using(QLNS qlns = new QLNS())
            {
                var thanhtoan = qlns.saches.Join(
                                      qlns.connects,
                                      s => s.masach,
                                      con => con.masach,
                                      (s, con) => new
                                      {
                                          s.tensach,
                                          s.masach,
                                          s.soluong,
                                          con.madocgia,
                                          con.ID_User
                                      }
                                      );
                var SelectMaSachToThanhToan = thanhtoan.Where(p => p.tensach == currentNS);
                var getMasach = SelectMaSachToThanhToan.Select(p => p.masach).FirstOrDefault();
                var getMadocgiaThanhToan = qlns.docgias.Where(p => p.ID_User == currentID).Select(p => p.madocgia).FirstOrDefault();


                if (getMasach != 0 && getMadocgiaThanhToan != 0)
                {
                    connect c = new connect();
                    c.ID_User = currentID;
                    c.masach = getMasach;
                    c.madocgia = getMadocgiaThanhToan;
                    c.thoigiangiaodich = DateTime.Now;

                    qlns.connects.Add(c);
                    qlns.SaveChanges();

                    FormMuaSach fms = new FormMuaSach();
                    fms.Show();

                }
            }
        }
        public void DeleteGioHang(string lbcontainNameS,int currentID)
        {
            using (QLNS qlns = new QLNS())
            {
                var jointoDel = qlns.connects
            .Join(
            qlns.saches,
            connect => connect.masach,
            sach => sach.masach,
            (connect, sach) => new
            {
                connect.ID_connect,
                connect.masach,
                connect.ID_User,
                sach.tensach,
            });
                //Lấy tên sách từ tên nút được chọn
                var SelectMaSachToDel = jointoDel.Where(p => p.tensach == lbcontainNameS).Select(p => p.masach).FirstOrDefault();
                var giohangToDelete = qlns.connects.Where(con => con.masach == SelectMaSachToDel && con.ID_User == currentID).FirstOrDefault();

                if (giohangToDelete != null)
                {
                    qlns.connects.Remove(giohangToDelete);
                    qlns.SaveChanges();
                }

            }
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
                               TenSach = db.saches.Where(s => s.masach == p.masach).Select(s => s.tensach).FirstOrDefault(),
                               ThoiGianGiaoDich = (DateTime)p.thoigiangiaodich,
                               SoLuongMua = (int)p.soluongmua,
                               TongTien  = (int)p.tongtien
                           }).ToList();
                return list;
            }


        }
        public List<sachshow> Findsach(string txtfind, string typefind)
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
                        MaSach = p.masach,
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Soluong = (int)p.soluong,
                        GhiChu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Nhà xuất bản" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.nxb.tennxb.Contains(txtfind)).Select(p => new sachshow
                    {
                        MaSach = p.masach,
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Soluong = (int)p.soluong,
                        GhiChu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Tác giả" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.tacgia.tentacgia.Contains(txtfind)).Select(p => new sachshow
                    {
                        MaSach = p.masach,
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Soluong = (int)p.soluong,
                        GhiChu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Thể loại" && txtfind != null)
                {
                    li = (db.saches).Where(p => p.theloai.tentheloai.Contains(txtfind)).Select(p => new sachshow
                    {
                        MaSach = p.masach,
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Soluong = (int)p.soluong,
                        GhiChu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();
                }
                return li;
            }
        }

        public List<Sachshowgoiy> FindsachGoiY(string txtfind, string typefind)
        {
            List<Sachshowgoiy> lig = new List<Sachshowgoiy>();
            using (QLNS db = new QLNS())
            {
                 if (typefind == "Tên sách" && txtfind != null)
                    {
                    lig = (db.saches).Where(p => p.tensach.Contains(txtfind)).Select(p => new Sachshowgoiy
                    {
                        
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Ghichu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Nhà xuất bản" && txtfind != null)
                {
                    lig = (db.saches).Where(p => p.nxb.tennxb.Contains(txtfind)).Select(p => new Sachshowgoiy
                    {
                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Ghichu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Tác giả" && txtfind != null)
                {
                    lig = (db.saches).Where(p => p.tacgia.tentacgia.Contains(txtfind)).Select(p => new Sachshowgoiy
                    {

                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Ghichu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();

                }
                else if (typefind == "Thể loại" && txtfind != null)
                {
                    lig = (db.saches).Where(p => p.theloai.tentheloai.Contains(txtfind)).Select(p => new Sachshowgoiy
                    {

                        TenSach = p.tensach,
                        NamXB = (int)p.namxb,
                        TenNXB = db.nxbs.Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                        TenTG = db.tacgias.Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                        TenTL = db.theloais.Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                        Ghichu = p.ghichu,
                        KhuSach = p.khusach,
                        GiaTien = (int)p.giatien
                    }).ToList();
                }
                return lig;
            }
        }
        public List<ThongKeShowTheoNgay> getThongKeTheoNgay(DateTime dt,DateTime dt2)
        {
            List<ThongKeShowTheoNgay> list = new List<ThongKeShowTheoNgay>();
            using(QLNS qlns = new QLNS())
            {
                list = qlns.connects
                            .Where(p => p.thoigiangiaodich >= dt && p.thoigiangiaodich <= dt2)
                            .Where(p => p.madocgia != null)
                            .Select(p => new ThongKeShowTheoNgay
                            {
                                TenNhanVien = qlns.nhanviennhasaches.Where(n => n.manhanvien == p.manhanvien).Select(n => n.tennhanvien).FirstOrDefault(),
                                TenDocGia = qlns.docgias.Where(d => d.madocgia == p.madocgia).Select(d => d.hoten).FirstOrDefault(),
                                TenSach = qlns.saches.Where(s => s.masach == p.masach).Select(s => s.tensach).FirstOrDefault(),
                                ThoiGianGiaoDich = (DateTime)p.thoigiangiaodich,
                                SoLuongMua = (int)p.soluongmua,
                                TongTien = (int)p.tongtien,
                            }).ToList();
                return list;
            }
        }
        public List<ThongKeShow> getThongKeMax()
        {
            List<ThongKeShow> list = new List<ThongKeShow>();
            using(QLNS qlns = new QLNS())
            {
                var bestSellingBooks = qlns.connects
                    .GroupBy(c => c.masach)
                    .Select(g => new {
                        MaSach = g.Key,
                        TongSoLuongMua = g.Sum(c => c.soluongmua),
                        Tongtien = g.Sum(c => c.tongtien),

                    })
                    .OrderByDescending(b => b.TongSoLuongMua)
                    .ToList();                                                                 
                    int maxSoLuongMua = bestSellingBooks.FirstOrDefault()?.TongSoLuongMua ?? 0; 
                    var booksWithMaxSoLuongMua = bestSellingBooks.Where(b => b.TongSoLuongMua == maxSoLuongMua);

                    var getTenSachFromMa = from c in booksWithMaxSoLuongMua
                                           join s in qlns.saches on c.MaSach equals s.masach
                                           select new { TenSach = s.tensach, tongSoLuongMua = c.TongSoLuongMua, tongTien = c.Tongtien };
                list = getTenSachFromMa.Select(l => new ThongKeShow
                {
                    TongSoLuongMua = (int)l.tongSoLuongMua,
                    TenSach = l.TenSach,
                    TongTien = (int)l.tongTien,
                }).ToList();
                return list;
            }

        }
        public List<ShowGoiYMax> getGoiYMax()
        {
            List<ShowGoiYMax> list = new List<ShowGoiYMax>();
            using (QLNS qlns = new QLNS())
            {
                var bestSellingBooks = qlns.connects
                    .GroupBy(c => c.masach)
                    .Select(g => new {
                        MaSach = g.Key,
                        TongSoLuongMua = g.Sum(c => c.soluongmua),
                        Tongtien = g.Sum(c => c.tongtien),

                    })
                    .OrderByDescending(b => b.TongSoLuongMua)
                    .ToList();
                int maxSoLuongMua = bestSellingBooks.FirstOrDefault()?.TongSoLuongMua ?? 0;
                var booksWithMaxSoLuongMua = bestSellingBooks.Where(b => b.TongSoLuongMua == maxSoLuongMua);

                var getTenSachFromMa = from c in booksWithMaxSoLuongMua
                                       join s in qlns.saches on c.MaSach equals s.masach
                                       select new { 
                                           TenSach = s.tensach,
                                           tongSoLuongMua = c.TongSoLuongMua,
                                           tongTien = c.Tongtien,
                                           KhuSach = s.khusach,
                                           TenTheLoai = qlns.theloais.Where(p => p.matheloai == s.matheloai).Select(g => g.tentheloai).FirstOrDefault(),
                                           TenTacGia = qlns.tacgias.Where(p => p.matacgia == s.matacgia).Select(g => g.tentacgia).FirstOrDefault(),
                                           TenNXB = qlns.nxbs.Where(p => p.manxb == s.manxb).Select(g => g.tennxb).FirstOrDefault(),
                                       };
                list = getTenSachFromMa.Select(l => new ShowGoiYMax
                {
                    TenSach = l.TenSach,
                    TenTheLoai = l.TenTheLoai,
                    TenTacGia = l.TenTacGia,
                    TenNXB = l.TenNXB,
                    KhuSach = l.KhuSach,
                    TongSoLuongMua = (int)l.tongSoLuongMua,

                }).ToList();
                return list;
            }

        }

    }

    }

   



