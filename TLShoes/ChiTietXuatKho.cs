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
    
    public partial class ChiTietXuatKho
    {
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<long> PhieuXuatKhoId { get; set; }
        public Nullable<long> NguyenLieuId { get; set; }
        public Nullable<float> SoLuong { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public virtual PhieuXuatKho PhieuXuatKho { get; set; }
    }
}
