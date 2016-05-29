using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

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
                    s.PhanXuongId,
                    PhanXuong = s.PhanXuong.Ten,
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
                listShowData.Add(new ShowData()
                {
                    Id = item.Id,
                    PhanXuongId = item.PhanXuongId,
                    PhanXuong = item.PhanXuong.Ten,
                    MauId = item.MauId,
                    Mau = item.Mau.Ten,
                    QuyCach = item.QuyCach,
                    ChiTietId = item.ChiTietId,
                    ChiTiet = item.ChiTiet.Ten,
                    DinhMucChuan = (float)item.DinhMucChuan,
                    DinhMucThuc = (float)item.DinhMucThuc,
                    NguyenLieu = NguyenLieuFormat(item.ChiTietNguyenLieux.ToList()),
                    ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(item.ChiTietNguyenLieux.ToList()),
                });
            }
            data = new BindingList<ShowData>(listShowData);
        }


        public string NguyenLieuFormat(List<ChiTietNguyenLieu> data)
        {
            var tenNguyenLieu = "";
            foreach (var nguyenlieu in data)
            {
                var nguyenLieuInfo = SF.Get<NguyenLieuViewModel>().GetDetail((long)nguyenlieu.ChiTietNguyenLieuId);
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
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.NguyenLieuChiLenhs.Add((NguyenLieuChiLenh)data);
            }
            else
            {
                DbContext.NguyenLieuChiLenhs.AddOrUpdate((NguyenLieuChiLenh)data);
            }

            if (isSubmit)
            {
                DbContext.SaveChanges();
            }
        }

        public class ShowData : NguyenLieuChiLenh
        {
            public long Id { get; set; }
            public string PhanXuong { get; set; }
            public string QuyCach { get; set; }
            public string NguyenLieu { get; set; }
            public string Mau { get; set; }
            public string ChiTiet { get; set; }
            public float DinhMucChuan { get; set; }
            public float DinhMucThuc { get; set; }
            public BindingList<ChiTietNguyenLieu> ChiTietNguyenLieuList { get; set; }
        }
    }
}
