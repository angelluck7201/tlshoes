﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DonDatHangViewModel : BaseModel, IViewModel<DonDatHang>
    {
        public List<DonDatHang> GetList()
        {
            return DbContext.DonDatHangs.ToList();
        }

        public List<ChiTietDonDatHang> GetList(long donDatHangId)
        {
            return GetDetail(donDatHangId).ChiTietDonDatHangs.ToList();
        }

        public DonDatHang GetDetail(long id)
        {
            return DbContext.DonDatHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                NhaCungCap = s.NhaCungCap.TenCongTy,
                NgayDatHang = TimeHelper.TimestampToString(s.NgayDatHang, "d"),
                NgayGiaoHang = TimeHelper.TimestampToString(s.NgayGiaoHang, "d"),
                SoLuong = s.ChiTietDonDatHangs.Sum(a => a.SoLuong),
                SoLuongThuc = s.ChiTietDonDatHangs.Sum(a => a.SoLuongThuc),

            }).ToList();
        }

        public void GetChiTietDatHang(DonDatHang donDatHang, ref BindingList<VatTuDonGia> bindingList)
        {
            bindingList.Clear();
            foreach (var dongia in donDatHang.ChiTietDonDatHangs)
            {
                var vattu = new VatTuDonGia();
                var donGiaNhaCungCap = dongia.NhaCungCap.NhaCungCapVatTus.FirstOrDefault(s => s.NguyenLieuId == dongia.NguyenLieuId);
                if (donGiaNhaCungCap != null)
                {
                    vattu.DonGia = (float)donGiaNhaCungCap.DonGia;
                    vattu.DonViTinh = donGiaNhaCungCap.NguyenLieu.DanhMuc.Ten;
                    vattu.DonViTien = donGiaNhaCungCap.DonVi;
                }
                vattu.Id = dongia.Id;
                vattu.NguyenLieuId = dongia.NguyenLieuId;
                vattu.NhaCungCapId = dongia.NhaCungCapId;
                vattu.SoLuong = dongia.SoLuong;
                vattu.SoLuongThuc = dongia.SoLuongThuc;
                vattu.DonDatHangId = dongia.DonDatHangId;
                vattu.GhiChu = dongia.GhiChu;
                bindingList.Add(vattu);
            }
        }

        public void Save(object data)
        {
            DbContext.DonDatHangs.AddOrUpdate((DonDatHang)data);
            DbContext.SaveChanges();
        }

        public void Save(ChiTietDonDatHang data)
        {
            DbContext.ChiTietDonDatHangs.AddOrUpdate(data);
            DbContext.SaveChanges();
        }

        public void Delete(ChiTietDonDatHang data)
        {
            DbContext.ChiTietDonDatHangs.Remove(data);
        }

        public class VatTuDonGia : ChiTietDonDatHang
        {
            public float DonGia { get; set; }
            public string DonViTinh { get; set; }
            public string DonViTien { get; set; }

            public float ThanhTien
            {
                get
                {
                    var soLuong = 0f;
                    if (SoLuong != null)
                    {
                        soLuong = (float)SoLuong;
                    }
                    return (float)soLuong * DonGia;
                }
            }
        }
    }
}
