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
                    NgayKiemHangFormat = TimeHelper.TimeStampToDateTime(s.NgayKiemHang, "d"),
                    NgayBatDauPxChatFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauPxChat, "d"),
                    NgayHoanThanhPxChatFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhPxChat, "d"),
                    NgayBatDauToPhuTroFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauToPhuTro, "d"),
                    NgayHoanThanhToPhuTroFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhToPhuTro, "d"),
                    NgayBatDauPxMayFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauPxMay, "d"),
                    NgayHoanThanhPxMayFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhPxMay, "d"),
                    NgayBatDauPxGoFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauPxGo, "d"),
                    NgayHoanThanhPxGoFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhPxGo, "d"),
                    NgayBatDauPxDeFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauPxDe, "d"),
                    NgayHoanThanhPxDeFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhPxDe, "d"),
                    NgayBatDauBpVatTuFormat = TimeHelper.TimeStampToDateTime(s.NgayBatDauBpVatTu, "d"),
                    NgayHoanThanhBpVatTuFormat = TimeHelper.TimeStampToDateTime(s.NgayHoanThanhBpVatTu, "d"),
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
