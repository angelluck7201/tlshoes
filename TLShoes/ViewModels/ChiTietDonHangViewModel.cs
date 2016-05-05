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
    public class ChiTietDonHangViewModel : BaseModel, IViewModel<ChiTietDonHang>
    {
        public List<ChiTietDonHang> GetList()
        {
            return DbContext.ChiTietDonHangs.ToList();
        }

        public List<ChiTietDonHang> GetList(long donHangId)
        {
            return DbContext.ChiTietDonHangs.Where(s => s.DonHangId == donHangId).ToList();
        }

        public ChiTietDonHang GetDetail(long id)
        {
            return DbContext.ChiTietDonHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            //control.DataSource = GetList().Select(s => new { s.Id, s.MaHang, s.OrderNo, s.KhachHang.TenCongTy, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat) }).ToList();
        }

        public void Save(object data)
        {
            DbContext.ChiTietDonHangs.AddOrUpdate((ChiTietDonHang)data);
            DbContext.SaveChanges();
        }
    }
}
