using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauThuDaoViewModel : BaseModel, IViewModel<MauThuDao>
    {
        public List<MauThuDao> GetList()
        {
            return DbContext.MauThuDaos.ToList();
        }

        public List<MauThuDao> GetList(long donHangId)
        {
            return
                DbContext.MauThuDaos.Where(s => s.DonHangId == donHangId)
                    .ToList();
        }

        public MauThuDao GetDetail(long id)
        {
            return DbContext.MauThuDaos.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    NgayBatDauFormat = TimeHelper.TimestampToString(s.NgayBatDau, "d"),
                    NgayHoanThanhFormat = TimeHelper.TimestampToString(s.NgayHoanThanh, "d"),
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh),
                    s.UserAccount.LoaiNguoiDung
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauThuDaos.Add((MauThuDao)data);
            }
            else
            {
                DbContext.MauThuDaos.AddOrUpdate((MauThuDao)data);
            }
            DbContext.SaveChanges();
        }
    }
}
