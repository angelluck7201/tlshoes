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
    
    public partial class ChiTietHuongDanDongGoi
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public Nullable<long> MauHuongDanDongGoiId { get; set; }
        public Nullable<long> DanhMucId { get; set; }
        public Nullable<long> DonViTinhId { get; set; }
        public string KichThuoc { get; set; }
        public Nullable<long> MauId { get; set; }
        public Nullable<long> NguyenLieuId { get; set; }
        public string CachSuDung { get; set; }
        public string ViTriSuDung { get; set; }
        public int SoLuong { get; set; }
        public string HinhMauDinhKem { get; set; }
        public string GhiChu { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual DanhMuc DonViTinh { get; set; }
        public virtual MauHuongDanDongGoi MauHuongDanDongGoi { get; set; }
        public virtual DanhMuc Mau { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
