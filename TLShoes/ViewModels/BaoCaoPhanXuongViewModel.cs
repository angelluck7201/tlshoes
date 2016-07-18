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
            return DbContext.BaoCaoPhanXuongs.ToList();
        }

        /// <summary>
        /// Get list luy ke 
        /// </summary>
        /// <param name="phanXuongId"></param>
        /// <param name="selfId"></param>
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
                    BaoCaoNgayFormat = TimeHelper.TimestampToString(s.BaoCaoNgay, "d"),
                }).ToList();
        }

        public void GetDataSummarySource(GridControl control)
        {
            var listData = new List<SummaryBaoCao>();
            var groupBaoCao = GetList().GroupBy(s => s.DonHang);
            foreach (var group in groupBaoCao)
            {
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
                    item.Ton = item.Khoan - item.ThucHien;
                    listData.Add(item);
                }
            }

            control.DataSource = listData;

        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.BaoCaoPhanXuongs.Add((BaoCaoPhanXuong)data);
            }
            else
            {
                DbContext.BaoCaoPhanXuongs.AddOrUpdate((BaoCaoPhanXuong)data);
            }
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
        }
    }
}
