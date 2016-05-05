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
    public class DonHangViewModel : BaseModel, IViewModel<DonHang>
    {
        public List<DonHang> GetList()
        {
            return DbContext.DonHangs.ToList();
        }
        public DonHang GetDetail(long id)
        {
            return DbContext.DonHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.MaHang, s.OrderNo, s.KhachHang.TenCongTy, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat) }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.DonHangs.Add((DonHang) data);
            }
            else
            {
                DbContext.DonHangs.AddOrUpdate((DonHang)data);
            }
            DbContext.SaveChanges();
        }
    }
}
