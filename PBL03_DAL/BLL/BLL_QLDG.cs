using PBL03_DAL.DAL;
using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
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

        private DAL_QLDG docgiaDAL;
        private BLL_QLDG()
        {
            docgiaDAL = new DAL_QLDG();
        }


        public List<DGSHOW> getdg()
        {
            List<DGSHOW> dg = new List<DGSHOW>();
            dg = (DAL_QLDG.Instance.GetDG()).Select(p => new DGSHOW
            {
                id = p.madocgia,
                name = p.hoten,
                ngay = (DateTime)p.ngaysinh,
                address = p.diachi,
                dt = p.sdt,
               // gender = p.gioitinh
            }).ToList();
            return dg;
        }
        public void addDocGia(docgia Docgiaadd)
        {
           DAL_QLDG.Instance.AddDocGia(Docgiaadd);
        }
        public bool DelDocgia(List<int> iddg)
        {
            DAL_QLDG.Instance.DelDocGia(iddg);
            return true;

        }
        public void Updatedocgia(docgia editdocgia)
        {
            DAL_QLDG.Instance.UpdateDocGia(editdocgia);

        }

        public docgia GetdocgiaByid(int id)
        {
            docgia dg = new docgia();
            foreach (docgia i in DAL_QLDG.Instance.GetDG())
            {
                if (id == i.madocgia)
                {
                    dg = i;
                }

            }
            return dg;
        }





    }
}