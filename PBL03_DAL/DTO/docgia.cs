//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL03_DAL.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class docgia
    {
        public int madocgia { get; set; }
        public string hoten { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string diachi { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string sdt { get; set; }
        public Nullable<int> ID_User { get; set; }
    
        public virtual accountt accountt { get; set; }
    }
}
