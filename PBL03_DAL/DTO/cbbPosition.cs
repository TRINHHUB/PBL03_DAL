﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL03_DAL.DTO
{
    public class cbbPosition
    {
        public int id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
