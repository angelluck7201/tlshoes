using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiLenhViewModel : BaseModel, IViewModel<ChiLenh>
    {
        public List<ChiLenh> GetList()
        {
            return DbContext.ChiLenhs.ToList();
        }

        public ChiLenh GetDetail(long id)
        {
            return DbContext.ChiLenhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    NguoiDuyet = s.UserAccount.TenNguoiDung,
                    NgayDuyetFormat = TimeHelper.TimestampToString(s.NgayDuyet),
                }).ToList();
        }

        public void Save(ChiLenh data, bool isCommit = true)
        {
            DbContext.ChiLenhs.AddOrUpdate(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }
    }
}
