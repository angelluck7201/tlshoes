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
    
    public partial class HuongDanDongGoi
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<long> DonHangId { get; set; }
        public string CachDong { get; set; }
        public string DongAssorment { get; set; }
        public Nullable<int> SoDoi { get; set; }
        public string GhiChu { get; set; }
        public Nullable<long> MauDongGoiId { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual DonHang DonHang { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual MauHuongDanDongGoi MauHuongDanDongGoi { get; set; }
    }
}