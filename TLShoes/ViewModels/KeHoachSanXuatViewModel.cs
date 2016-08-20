using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
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
                    s.DonHang.OrderNo,
                    SoLuong = s.DonHang.ChiTietDonHangs.Sum(a => a.SoLuong),
                    NgayKiemHangFormat = TimeHelper.TimestampToString(s.NgayKiemHang, "d"),
                    NgayBatDauPxChatFormat = TimeHelper.TimestampToString(s.NgayBatDauPxChat, "d"),
                    NgayHoanThanhPxChatFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxChat, "d"),
                    NgayBatDauToPhuTroFormat = TimeHelper.TimestampToString(s.NgayBatDauToPhuTro, "d"),
                    NgayHoanThanhToPhuTroFormat = TimeHelper.TimestampToString(s.NgayHoanThanhToPhuTro, "d"),
                    NgayBatDauPxMayFormat = TimeHelper.TimestampToString(s.NgayBatDauPxMay, "d"),
                    NgayHoanThanhPxMayFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxMay, "d"),
                    NgayBatDauPxGoFormat = TimeHelper.TimestampToString(s.NgayBatDauPxGo, "d"),
                    NgayHoanThanhPxGoFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxGo, "d"),
                    NgayBatDauPxDeFormat = TimeHelper.TimestampToString(s.NgayBatDauPxDe, "d"),
                    NgayHoanThanhPxDeFormat = TimeHelper.TimestampToString(s.NgayHoanThanhPxDe, "d"),
                    NgayBatDauBpVatTuFormat = TimeHelper.TimestampToString(s.NgayBatDauBpVatTu, "d"),
                    NgayHoanThanhBpVatTuFormat = TimeHelper.TimestampToString(s.NgayHoanThanhBpVatTu, "d"),
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh)
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
