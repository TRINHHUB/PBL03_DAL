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
        
    }
}
