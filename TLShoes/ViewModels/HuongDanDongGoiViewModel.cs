using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class HuongDanDongGoiViewModel : BaseModel, IViewModel<HuongDanDongGoi>
    {
        public List<HuongDanDongGoi> GetList()
        {
            return DbContext.HuongDanDongGois.ToList();
        }

        public HuongDanDongGoi GetDetail(long id)
        {
            return DbContext.HuongDanDongGois.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.DonHang.KhachHang.TenCongTy,
                s.DonHang.MaHang,
                s.SoLuong,
                SoLuongDonHang = s.DonHang.ChiTietDonHangs.Sum(d => d.SoLuong),
                SoDH = s.DonHang.OrderNo,
                s.CachDong,
                s.DongAssorment,
                SoThung = s.DonHang.ChiTietDonHangs.Sum(d => d.SoLuong) / s.SoDoi,
                Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh),
                DoiThung = s.SoDoi,
            }).ToList();
        }

        public void Save(object data)
        {
            // dynamic dynamicData = data;
            DbContext.HuongDanDongGois.AddOrUpdate((HuongDanDongGoi)data);
            DbContext.SaveChanges();
        }
    }
}
