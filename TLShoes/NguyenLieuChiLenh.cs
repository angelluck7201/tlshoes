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
    
    public partial class NguyenLieuChiLenh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguyenLieuChiLenh()
        {
            this.ChiTietNguyenLieux = new HashSet<ChiTietNguyenLieu>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<long> PhanXuongId { get; set; }
        public Nullable<long> ChiLenhId { get; set; }
        public Nullable<long> ChiTietId { get; set; }
        public string QuyCach { get; set; }
        public Nullable<long> MauId { get; set; }
        public Nullable<float> DinhMucChuan { get; set; }
        public Nullable<float> DinhMucThuc { get; set; }
    
        public virtual ChiLenh ChiLenh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNguyenLieu> ChiTietNguyenLieux { get; set; }
        public virtual DanhMuc ChiTiet { get; set; }
        public virtual DanhMuc Mau { get; set; }
        public virtual DanhMuc PhanXuong { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
