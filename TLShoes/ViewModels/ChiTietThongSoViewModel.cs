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
    public class ChiTietThongSoViewModel : BaseModel, IViewModel<ChiTietThongSo>
    {
        public List<ChiTietThongSo> GetList()
        {
            return DbContext.ChiTietThongSoes.ToList();
        }

        public List<ChiTietThongSo> GetList(long thongSoId)
        {
            return DbContext.ChiTietThongSoes.Where(s => s.BangThongSoId == thongSoId).ToList();
        }

        public ChiTietThongSo GetDetail(long id)
        {
            return DbContext.ChiTietThongSoes.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            //control.DataSource = GetList().Select(s => new { s.Id, s.MaHang, s.OrderNo, s.KhachHang.TenCongTy, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat) }).ToList();
        }

        public void Save(object data)
        {
            DbContext.ChiTietThongSoes.AddOrUpdate((ChiTietThongSo)data);
            DbContext.SaveChanges();
        }
    }
}
