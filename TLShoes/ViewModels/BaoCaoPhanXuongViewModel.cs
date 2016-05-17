using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class BaoCaoPhanXuongViewModel : BaseModel, IViewModel<BaoCaoPhanXuong>
    {
        public List<BaoCaoPhanXuong> GetList()
        {
            return DbContext.BaoCaoPhanXuongs.ToList();
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
                    s.DanhMuc.Ten,
                    s.SanLuongThucHien,
                    s.SanLuongKhoan,
                    SoLuongDonHang = s.DonHang.ChiTietDonHangs.Sum(a=>a.SoLuong),
                    BaoCaoNgayFormat = TimeHelper.TimestampToString(s.BaoCaoNgay,"d"),
                }).ToList();
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
    }
}
