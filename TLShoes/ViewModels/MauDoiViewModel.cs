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
    public class MauDoiViewModel : BaseModel, IViewModel<MauDoi>
    {
        public List<MauDoi> GetList()
        {
            return DbContext.MauDois.ToList();
        }

        public List<MauDoi> GetList(long donHangId)
        {
            return DbContext.MauDois.Where(s => s.DonHangId == donHangId).ToList();
        }

        public MauDoi GetDetail(long id)
        {
            return DbContext.MauDois.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.DonHang.MaHang, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), MauNgayFormat = TimeHelper.TimestampToString(s.MauNgay) }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauDois.Add((MauDoi)data);
            }
            else
            {
                DbContext.MauDois.AddOrUpdate((MauDoi)data);
            }
            DbContext.SaveChanges();
        }
    }
}
