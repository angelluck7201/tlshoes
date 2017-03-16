using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;
using TLShoes.ViewModels;

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
        /// <param name="donHangId"></param>
        /// <param name="phanXuong"></param>
        /// <param name="toDate"></param>
        /// <param name="isOldBaoCao"></param>
        /// <returns></returns>
        public List<BaoCaoPhanXuong> GetList(long donHangId, string phanXuong, DateTime toDate, bool isOldBaoCao = true)
        {
            if (isOldBaoCao)
            {
                return DbContext.BaoCaoPhanXuongs.Where(s => s.DonHangId == donHangId && s.BaoCaoNgay < toDate && s.PhanXuong == phanXuong).ToList();
            }
            return DbContext.BaoCaoPhanXuongs.Where(s => s.DonHangId == donHangId && s.BaoCaoNgay >= toDate && s.PhanXuong == phanXuong).ToList();
        }

        public BaoCaoPhanXuong GetDetail(long id)
        {
            return DbContext.BaoCaoPhanXuongs.Find(id);
        }

        public bool IsDulicateReportInDate(long donHangId, string phanXuong, string shortDate)
        {
            var lstBaoCaoPx = DbContext.BaoCaoPhanXuongs.Where(s => s.DonHangId == donHangId && s.PhanXuong == phanXuong).ToList();
            return lstBaoCaoPx.Any(s => s.BaoCaoNgay.ToShortDateString() == shortDate);
        }


        public void GetDataSummarySource(GridControl control)
        {
            var listData = new List<SummaryBaoCao>();
            var groupBaoCao = GetList().GroupBy(s => s.DonHang);
            foreach (var group in groupBaoCao)
            {
                var groupSort = group.OrderBy(s => s.BaoCaoNgay);
                var groupPhanXuong = group.GroupBy(s => s.PhanXuong);
                foreach (var phanxuong in groupPhanXuong)
                {
                    var item = new SummaryBaoCao();
                    item.Id = group.Key.Id;
                    //item.Hinh = FileHelper.ImageFromFile(group.Key.HinhAnh);
                    item.MaHang = group.Key.MaHang;
                    item.SoDH = group.Key.OrderNo;
                    item.SoLuong = (int)group.Key.ChiTietDonHangs.Sum(s => s.SoLuong);
                    item.BoPhan = phanxuong.Key;
                    item.Khoan = (int)phanxuong.Sum(s => s.SanLuongKhoan);
                    item.ThucHien = (int)phanxuong.Sum(s => s.SanLuongThucHien);
                    item.Ton = item.ThucHien - item.Khoan;
                    item.BaoCaoTuNgay = groupSort.First().BaoCaoNgay;
                    item.BaoCaoDenNgay = groupSort.Last().BaoCaoNgay;
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

