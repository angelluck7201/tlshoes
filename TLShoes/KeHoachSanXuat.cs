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
    
    public partial class KeHoachSanXuat
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public Nullable<long> DonHangId { get; set; }
        public System.DateTime NgayKiemHang { get; set; }
        public System.DateTime NgayBatDauPxChat { get; set; }
        public System.DateTime NgayHoanThanhPxChat { get; set; }
        public System.DateTime NgayBatDauToPhuTro { get; set; }
        public System.DateTime NgayHoanThanhToPhuTro { get; set; }
        public System.DateTime NgayBatDauPxMay { get; set; }
        public System.DateTime NgayHoanThanhPxMay { get; set; }
        public System.DateTime NgayBatDauPxGo { get; set; }
        public System.DateTime NgayHoanThanhPxGo { get; set; }
        public System.DateTime NgayBatDauPxDe { get; set; }
        public System.DateTime NgayHoanThanhPxDe { get; set; }
        public System.DateTime NgayBatDauBpVatTu { get; set; }
        public System.DateTime NgayHoanThanhBpVatTu { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DonHang DonHang { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
