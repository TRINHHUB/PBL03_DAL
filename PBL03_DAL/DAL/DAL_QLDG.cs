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

        public List<docgia> GetDG()
        {
            using (QLNS db = new QLNS())
            {
                List<docgia> dgs = new List<docgia>();
                dgs = db.docgias.ToList();
                return dgs;               
            }
        }
    }
}
