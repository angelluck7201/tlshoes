using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class BaoCaoPhanXuongViewModel : BaseModel, IViewModel<BaoCaoPhanXuong>
    {
        public List<BaoCaoPhanXuong> GetList()
        {
            return DbContext.BaoCaoPhanXuongs.OrderByDescending(s => s.BaoCaoNgay).ToList();
        }

        /// <summary>
        /// Get list luy ke 
        /// </summary>
        /// <param name="phanXuongId"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<BaoCaoPhanXuong> GetList(long phanXuongId, long toDate)
        {
            return DbContext.BaoCaoPhanXuongs.Where(s => s.BaoCaoNgay < toDate && s.PhanXuongId == phanXuongId).ToList();
        }

        public BaoCaoPhanXuong GetDetail(long id)
        {
            return DbContext.BaoCaoPhanXuongs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    s.DonHang.OrderNo,
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh),
                    s.DanhMuc.Ten,
                    s.SanLuongThucHien,
                    s.SanLuongKhoan,
                    LuyKe = GetList((long)s.PhanXuongId, (long)s.BaoCaoNgay).Sum(l => l.SanLuongThucHien),
                    SoLuongDonHang = s.DonHang.ChiTietDonHangs.Sum(a => a.SoLuong),
                    BaoCaoNgayFormat = TimeHelper.TimeStampToDateTime(s.BaoCaoNgay, "d"),
                    s.GhiChu
                }).ToList();
        }

        public void GetDataSummarySource(GridControl control)
        {
            var listData = new List<SummaryBaoCao>();
            var groupBaoCao = GetList().GroupBy(s => s.DonHang);
            foreach (var group in groupBaoCao)
            {
                var groupSort = group.OrderBy(s => s.BaoCaoNgay);
                var groupPhanXuong = group.GroupBy(s => s.DanhMuc);
                foreach (var phanxuong in groupPhanXuong)
                {
                    var item = new SummaryBaoCao();
                    item.Id = group.Key.Id;
                    //item.Hinh = FileHelper.ImageFromFile(group.Key.HinhAnh);
                    item.MaHang = group.Key.MaHang;
                    item.SoDH = group.Key.OrderNo;
                    item.SoLuong = (int)group.Key.ChiTietDonHangs.Sum(s => s.SoLuong);
                    item.BoPhan = phanxuong.Key.Ten;
                    item.Khoan = (int)phanxuong.Sum(s => s.SanLuongKhoan);
                    item.ThucHien = (int)phanxuong.Sum(s => s.SanLuongThucHien);
                    item.Ton = item.ThucHien - item.Khoan;
                    item.BaoCaoTuNgay = TimeHelper.TimeStampToDateTime(groupSort.First().BaoCaoNgay);
                    item.BaoCaoDenNgay = TimeHelper.TimeStampToDateTime(groupSort.Last().BaoCaoNgay);
                    listData.Add(item);
                }
            }

            control.DataSource = listData;

        }

        public void Save(object data)
        {
            DbContext.BaoCaoPhanXuongs.AddOrUpdate((BaoCaoPhanXuong)data);
            DbContext.SaveChanges();
        }

        public class SummaryBaoCao
        {
            public long Id { get; set; }
            public string MaHang { get; set; }
            public string SoDH { get; set; }
            public int SoLuong { get; set; }
            public object Hinh { get; set; }
            public string BoPhan { get; set; }
            public int ThucHien { get; set; }
            public int Ton { get; set; }
            public int Khoan { get; set; }
            public DateTime BaoCaoTuNgay { get; set; }
            public DateTime BaoCaoDenNgay { get; set; }

        }
    }
}
