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
    
    public partial class MauTest
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<long> DonHangId { get; set; }
        public Nullable<long> NgayGuiMau { get; set; }
        public Nullable<long> NgayKetquaTestLy { get; set; }
        public string KetQuaTestLy { get; set; }
        public Nullable<long> PhanLoaiTestLyId { get; set; }
        public Nullable<long> NgayKetquaTestHoa { get; set; }
        public string KetQuaTestHoa { get; set; }
        public Nullable<long> PhanLoaiTestHoaId { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual DanhMuc DanhMuc1 { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
