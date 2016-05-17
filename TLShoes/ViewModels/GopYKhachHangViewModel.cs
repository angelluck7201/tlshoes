using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    //public class GopYKhachHangViewModel : BaseModel, IViewModel<GopYKhachHang>
    //{
    //    public List<GopYKhachHang> GetList()
    //    {
    //        return DbContext.GopYKhachHangs.ToList();
    //    }
    //    public GopYKhachHang GetDetail(long id)
    //    {
    //        return DbContext.GopYKhachHangs.FirstOrDefault(s => s.DonHangId == id);
    //    }

    //    public void GetDataSource(GridControl control)
    //    {
    //        //control.DataSource = GetList().Select(s => new { s.Id, s.MaHang, s.OrderNo, s.KhachHang.TenCongTy, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat) }).ToList();
    //    }

    //    public void Save(object data)
    //    {
    //        DbContext.GopYKhachHangs.AddOrUpdate((GopYKhachHang)data);
    //        DbContext.SaveChanges();
    //    }
    //}
}
