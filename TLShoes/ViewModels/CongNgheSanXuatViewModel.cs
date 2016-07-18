using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class CongNgheSanXuatViewModel : BaseModel, IViewModel<CongNgheSanXuat>
    {
        public List<CongNgheSanXuat> GetList()
        {
            return DbContext.CongNgheSanXuats.ToList();
        }
        public CongNgheSanXuat GetDetail(long id)
        {
            return DbContext.CongNgheSanXuats.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    MauDoiNgayFormat = TimeHelper.TimestampToString(s.MauDoi.MauNgay, "d"),
                    PhanLoaiThuRap = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiThuRapId).Ten,
                    PhanLoaiThuDao = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiThuDao).Ten,
                    NgayDuyetFormat = TimeHelper.TimestampToString(s.NgayDuyet),
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.CongNgheSanXuats.Add((CongNgheSanXuat)data);
            }
            else
            {
                DbContext.CongNgheSanXuats.AddOrUpdate((CongNgheSanXuat)data);
            }
            DbContext.SaveChanges();
        }
    }
}
