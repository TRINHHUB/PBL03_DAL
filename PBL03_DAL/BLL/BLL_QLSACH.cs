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
        public List<sachshow> Getsach()
        {
            List<sachshow> dg = new List<sachshow>();
            dg = (DAL_QLSACH.Instance.GetAllSach()).Select(p => new sachshow
            {
                ma = p.masach,
                ten = p.tensach,
                nam = (int)p.namxb,
                tennxb = DAL_QLSACH.Instance.GetAllNXB().Where(n => n.manxb == p.manxb).Select(n => n.tennxb).FirstOrDefault(),
                tentacgia = DAL_QLSACH.Instance.GetAllTG().Where(n => n.matacgia == p.matacgia).Select(n => n.tentacgia).FirstOrDefault(),
                tentheloai = DAL_QLSACH.Instance.GetAllTL().Where(n => n.matheloai == p.matheloai).Select(n => n.tentheloai).FirstOrDefault(),
                sl = (int)p.soluong,
                note = p.ghichu,
                khu = p.khusach,
                gia = (int)p.giatien
            }).ToList();
            return dg;

        }
        public bool DelSach(List<int> ids)
        {
            DAL_QLSACH.Instance.DelSach(ids);
            return true;
        }
        public void addsach(sach sachadd)
        {

            DAL_QLSACH.Instance.AddSach(sachadd);
        }
        public void Updatesach(sach editsach)
        {
            DAL_QLSACH.Instance.Updatesach(editsach);
           
        }


        public sach GetsachByidSach(int id)
        {
            sach dg = new sach();
            foreach (sach i in DAL_QLSACH.Instance.GetAllSach())
            {
                if (id == i.masach)
                {
                    dg = i;


                }

            }
            return dg;
        }
        public string GetNXBById(int id)
        {
            string tennxb = DAL_QLSACH.Instance.GetAllNXB().Where(n => n.manxb == id).Select(n => n.tennxb).FirstOrDefault();
            return tennxb;
        }
        public string GetTacGiaById(int id)
        {
            string tentacgia = DAL_QLSACH.Instance.GetAllTG().Where(n => n.matacgia == id).Select(n => n.tentacgia).FirstOrDefault();
            return tentacgia;
        }
        public string GetTheLoaiById(int id)
        {
            string tentheloai = DAL_QLSACH.Instance.GetAllTL().Where(n => n.matheloai == id).Select(n => n.tentheloai).FirstOrDefault();
            return tentheloai;
        }
    }
}
   



