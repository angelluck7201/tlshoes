//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TLShoes
{
    using System;
    using System.Collections.Generic;
    
    public partial class MauDoiHinh
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public Nullable<long> MauDoiId { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
    
        public virtual MauDoi MauDoi { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
