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
    
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            this.BaoCaoPhanXuongs = new HashSet<BaoCaoPhanXuong>();
            this.ChiLenhs = new HashSet<ChiLenh>();
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.HuongDanDongGois = new HashSet<HuongDanDongGoi>();
            this.KeHoachSanXuats = new HashSet<KeHoachSanXuat>();
            this.MauDois = new HashSet<MauDoi>();
            this.MauSanXuats = new HashSet<MauSanXuat>();
            this.MauTests = new HashSet<MauTest>();
            this.PhieuXuatKhoes = new HashSet<PhieuXuatKho>();
            this.CongNgheSanXuats = new HashSet<CongNgheSanXuat>();
            this.MauThuDaos = new HashSet<MauThuDao>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public Nullable<long> MaPhomId { get; set; }
        public Nullable<long> MuId { get; set; }
        public Nullable<long> LotId { get; set; }
        public Nullable<long> DaLotTayId { get; set; }
        public Nullable<long> DeId { get; set; }
        public string MaHang { get; set; }
        public Nullable<long> KhachHangId { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime NgayNhan { get; set; }
        public System.DateTime NgayXuat { get; set; }
        public string HinhAnh { get; set; }
        public string GopYVatTu { get; set; }
        public string GopYXuongChat { get; set; }
        public string GopYXuongMay { get; set; }
        public string GopYXuongDe { get; set; }
        public string GopYXuongGo { get; set; }
        public string GopYQc { get; set; }
        public string GopYCongNghe { get; set; }
        public string GopYMau { get; set; }
        public string GopYKhoVatTu { get; set; }
        public string GopYPhuTro { get; set; }
        public string GopYKhoThanhPham { get; set; }
        public int DungYeuCauKyThuat { get; set; }
        public int DungThoiGian { get; set; }
        public int DungMau { get; set; }
        public int DatTestLy { get; set; }
        public int DatTestHoa { get; set; }
        public int Gia { get; set; }
        public int DichVuGiaoHang { get; set; }
        public int DichVuHauMai { get; set; }
        public int Khac { get; set; }
        public int SoLuong { get; set; }
        public string MaGiay { get; set; }
        public string TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCaoPhanXuong> BaoCaoPhanXuongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiLenh> ChiLenhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HuongDanDongGoi> HuongDanDongGois { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KeHoachSanXuat> KeHoachSanXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauDoi> MauDois { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauSanXuat> MauSanXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauTest> MauTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatKho> PhieuXuatKhoes { get; set; }
        public virtual NguyenLieu DaLotTay { get; set; }
        public virtual NguyenLieu De { get; set; }
        public virtual NguyenLieu Lot { get; set; }
        public virtual NguyenLieu Phom { get; set; }
        public virtual NguyenLieu Mu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNgheSanXuat> CongNgheSanXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauThuDao> MauThuDaos { get; set; }
    }
}
