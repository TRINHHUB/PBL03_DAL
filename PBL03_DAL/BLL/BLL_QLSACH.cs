using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                khu = p.khusach
            }).ToList();
            return dg;

        }
        public bool DelSach(List<int> ids)
        {
            DAL_QLSACH.Instance.DelSach(ids);
            return true;
        }
    }
}
