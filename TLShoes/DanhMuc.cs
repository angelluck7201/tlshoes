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
    
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            this.BaoCaoPhanXuongs = new HashSet<BaoCaoPhanXuong>();
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.CongNgheSanXuats = new HashSet<CongNgheSanXuat>();
            this.CongNgheSanXuats1 = new HashSet<CongNgheSanXuat>();
            this.NguyenLieux = new HashSet<NguyenLieu>();
            this.NguyenLieux1 = new HashSet<NguyenLieu>();
            this.NguyenLieuChiLenhs = new HashSet<NguyenLieuChiLenh>();
            this.NguyenLieuChiLenhs1 = new HashSet<NguyenLieuChiLenh>();
            this.NguyenLieuChiLenhs2 = new HashSet<NguyenLieuChiLenh>();
            this.MauSanXuats = new HashSet<MauSanXuat>();
            this.MauTests = new HashSet<MauTest>();
            this.MauTests1 = new HashSet<MauTest>();
            this.ChiTietDanhGias = new HashSet<ChiTietDanhGia>();
            this.ChiTietMauDanhGias = new HashSet<ChiTietMauDanhGia>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCaoPhanXuong> BaoCaoPhanXuongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNgheSanXuat> CongNgheSanXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNgheSanXuat> CongNgheSanXuats1 { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuChiLenh> NguyenLieuChiLenhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuChiLenh> NguyenLieuChiLenhs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieuChiLenh> NguyenLieuChiLenhs2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauSanXuat> MauSanXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauTest> MauTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauTest> MauTests1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDanhGia> ChiTietDanhGias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMauDanhGia> ChiTietMauDanhGias { get; set; }
    }
}
