using PBL03_DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace PBL03_DAL.BLL
{
    public class BLL_LOGIN
    {
        private static BLL_LOGIN _Instance;

        public static BLL_LOGIN Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_LOGIN();
                return _Instance;

            }
            private set { }
        }


        private BLL_LOGIN() { }
        public accountt GetAccountByUserName(String Username)
        {
            using (QLNS db = new QLNS())
                foreach (accountt a in db.accountts)
                {
                    if (Username == a.TaiKhoan)
                    {
                        return a;
                    }
                }
            
            return null;
        }
        public List<cbbPosition> GetcbbPs()
        {
            List<cbbPosition> list = new List<cbbPosition>();
            using (QLNS db = new QLNS())
            {
                foreach (Position i in db.Positions)
                {
                    list.Add(new cbbPosition
                    {
                        id = i.ID_Position,
                        name = i.Name
                    });

                }
            }
            return list;
        }
        public void addtk(accountt tkadd)
        {
            using (QLNS db = new QLNS())
            {
                db.accountts.Add(tkadd);
                db.SaveChanges();
            }
        }
    }
}
