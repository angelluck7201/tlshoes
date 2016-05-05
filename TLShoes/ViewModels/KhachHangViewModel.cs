using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace TLShoes.ViewModels
{
    public class KhachHangViewModel : BaseModel, IViewModel<KhachHang>
    {
        public List<KhachHang> GetList()
        {
            return DbContext.KhachHangs.ToList();
        }
        public KhachHang GetDetail(long id)
        {
            return DbContext.KhachHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.TenCongTy, s.Dienthoai, s.DiaChi }).ToList();
        }

        public void Save(object data)
        {
            DbContext.KhachHangs.AddOrUpdate((KhachHang)data);
            DbContext.SaveChanges();
        }
    }
}
