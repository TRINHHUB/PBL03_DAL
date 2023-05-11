using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DTO
{
    public class cbbNXB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    
}
