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
    public class KeHoachSanXuatViewModel : BaseModel, IViewModel<KeHoachSanXuat>
    {
        public List<KeHoachSanXuat> GetList()
        {
            return DbContext.KeHoachSanXuats.ToList();
        }

        public KeHoachSanXuat GetDetail(long id)
        {
            return DbContext.KeHoachSanXuats.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    NgayKiemHangFormat = TimeHelper.TimestampToString(s.NgayKiemHang),
                    NgayBatDauPxChatFormat = TimeHelper.TimestampToString(s.NgayBatDauPxChat),
                    NgayHoanThanhPxChatFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxChat),
                    NgayBatDauToPhuTroFormat = TimeHelper.TimestampToString(s.NgayBatDauToPhuTro),
                    NgayHoanThanhToPhuTroFormat = TimeHelper.TimestampToString(s.NgayHoanThanhToPhuTro),
                    NgayBatDauPxMayFormat = TimeHelper.TimestampToString(s.NgayBatDauPxMay),
                    NgayHoanThanhPxMayFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxMay),
                    NgayBatDauPxGoFormat = TimeHelper.TimestampToString(s.NgayBatDauPxGo),
                    NgayHoanThanhPxGoFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxGo),
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.KeHoachSanXuats.Add((KeHoachSanXuat)data);
            }
            else
            {
                DbContext.KeHoachSanXuats.AddOrUpdate((KeHoachSanXuat)data);
            }
            DbContext.SaveChanges();
        }
    }
}
