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
    
    public partial class ChiTietDonDatHang
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public Nullable<long> DonDatHangId { get; set; }
        public Nullable<long> NhaCungCapId { get; set; }
        public Nullable<long> NguyenLieuId { get; set; }
        public double DonGia { get; set; }
        public double SoLuong { get; set; }
        public double SoLuongThuc { get; set; }
        public string GhiChu { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
