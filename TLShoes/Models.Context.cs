﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GiayTLEntities : DbContext
    {
        public GiayTLEntities()
            : base("name=GiayTLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaoCaoPhanXuong> BaoCaoPhanXuongs { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietNguyenLieu> ChiTietNguyenLieux { get; set; }
        public virtual DbSet<CongNgheSanXuat> CongNgheSanXuats { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KeHoachSanXuat> KeHoachSanXuats { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<MauDoi> MauDois { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<NguyenLieuChiLenh> NguyenLieuChiLenhs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<ChiTietToTrinh> ChiTietToTrinhs { get; set; }
        public virtual DbSet<ChiTietNhapKho> ChiTietNhapKhoes { get; set; }
        public virtual DbSet<ChiTietXuatKho> ChiTietXuatKhoes { get; set; }
        public virtual DbSet<MauSanXuat> MauSanXuats { get; set; }
        public virtual DbSet<MauTest> MauTests { get; set; }
        public virtual DbSet<MauThuDao> MauThuDaos { get; set; }
        public virtual DbSet<ChiTietDanhGia> ChiTietDanhGias { get; set; }
        public virtual DbSet<ChiTietMauDanhGia> ChiTietMauDanhGias { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<PhieuNhapKho> PhieuNhapKhoes { get; set; }
        public virtual DbSet<NhaCungCapVatTu> NhaCungCapVatTus { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<MauDanhGia> MauDanhGias { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ChiTietHuongDanDongGoi> ChiTietHuongDanDongGois { get; set; }
        public virtual DbSet<HuongDanDongGoi> HuongDanDongGois { get; set; }
        public virtual DbSet<MauHuongDanDongGoi> MauHuongDanDongGois { get; set; }
        public virtual DbSet<PhieuXuatKho> PhieuXuatKhoes { get; set; }
        public virtual DbSet<NhatKyThayDoi> NhatKyThayDois { get; set; }
        public virtual DbSet<MauDoiHinh> MauDoiHinhs { get; set; }
        public virtual DbSet<ChiLenh> ChiLenhs { get; set; }
        public virtual DbSet<TongHopToTrinh> TongHopToTrinhs { get; set; }
        public virtual DbSet<ToTrinh> ToTrinhs { get; set; }
        public virtual DbSet<NhatKyXuatKho> NhatKyXuatKhoes { get; set; }
        public virtual DbSet<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
    }
}
