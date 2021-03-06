﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class NguyenLieuChiLenhViewModel : BaseModel, IViewModel<NguyenLieuChiLenh>
    {

        public List<NguyenLieuChiLenh> GetList()
        {
            return DbContext.NguyenLieuChiLenhs.ToList();
        }

        public List<NguyenLieuChiLenh> GetList(long chilenhId)
        {
            return DbContext.NguyenLieuChiLenhs.Where(s => s.ChiLenhId == chilenhId).ToList();
        }

        public NguyenLieuChiLenh GetDetail(long id)
        {
            return DbContext.NguyenLieuChiLenhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
//                    s.PhanXuongId,
//                    PhanXuong = s.PhanXuong.Ten,
                    s.MauId,
                    Mau = s.Mau.Ten,
                    s.QuyCach,
                    s.ChiTietId,
                    ChiTiet = s.ChiTiet.Ten,
                    s.DinhMucThuc,
                    s.DinhMucChuan,
                    NguyenLieu = NguyenLieuFormat(s.ChiTietNguyenLieux.ToList()),
                    ChiTietNguyenLieuList = s.ChiTietNguyenLieux,
                }).ToList();
        }

        public void GetDataSource(long chilenhId, ref BindingList<ShowData> data)
        {
            var listData = GetList(chilenhId);
            var listShowData = new List<ShowData>();
            foreach (var item in listData)
            {
                var chiTietNguyenLieu = new List<ChiTietNguyenLieu>();
                if (item.ChiTietNguyenLieux != null)
                {
                    chiTietNguyenLieu = item.ChiTietNguyenLieux.ToList();
                }
                listShowData.Add(new ShowData()
                {
                    Id = item.Id,
                    PhanXuong = item.PhanXuong,
                    MauId = item.MauId,
                    Mau = item.Mau != null ? item.Mau.Ten : "",
                    QuyCach = item.QuyCach,
                    ChiTietId = item.ChiTietId,
                    ChiTiet = item.ChiTiet != null ? item.ChiTiet.Ten : "",
                    DinhMucChuan = item.DinhMucChuan,
                    DinhMucThuc = item.DinhMucThuc,
                    NguyenLieu = NguyenLieuFormat(chiTietNguyenLieu),
                    ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(chiTietNguyenLieu.ToList()),
                });
            }
            data = new BindingList<ShowData>(listShowData);
        }


        public string NguyenLieuFormat(List<ChiTietNguyenLieu> data)
        {
            var tenNguyenLieu = "";
            foreach (var nguyenlieu in data)
            {
                var nguyenLieuInfo = SF.Get<NguyenLieuViewModel>().GetDetail(nguyenlieu.ChiTietNguyenLieuId.GetValueOrDefault());
                if (nguyenLieuInfo != null)
                {
                    if (string.IsNullOrEmpty(tenNguyenLieu))
                    {
                        tenNguyenLieu = nguyenLieuInfo.Ten;
                    }
                    else
                    {
                        tenNguyenLieu = string.Format("{0} - {1}", tenNguyenLieu, nguyenLieuInfo.Ten);
                    }

                    if (!string.IsNullOrEmpty(nguyenlieu.GhiChu))
                    {
                        tenNguyenLieu = string.Format("{0} ({1})", tenNguyenLieu, nguyenlieu.GhiChu);
                    }
                }
            }
            return tenNguyenLieu;
        }

        public void Save(object data, bool isSubmit = true)
        {
            DbContext.NguyenLieuChiLenhs.AddOrUpdate((NguyenLieuChiLenh)data);
            if (isSubmit)
            {
                DbContext.SaveChanges();
            }
        }

        public class ShowData : NguyenLieuChiLenh
        {
            public string Mau { get; set; }
            public string ChiTiet { get; set; }
            public string NguyenLieu { get; set; }
            public BindingList<ChiTietNguyenLieu> ChiTietNguyenLieuList { get; set; }
        }
    }
}
