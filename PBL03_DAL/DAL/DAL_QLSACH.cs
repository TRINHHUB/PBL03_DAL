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
       
    }
}


