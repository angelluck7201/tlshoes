using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauSanXuatViewModel : BaseModel, IViewModel<MauSanXuat>
    {
        public List<MauSanXuat> GetList()
        {
            return DbContext.MauSanXuats.ToList();
        }

        public List<MauSanXuat> GetList(long donHangId)
        {
            return
                DbContext.MauSanXuats.Where(s => s.DonHangId == donHangId).OrderByDescending(s => s.NgayKetqua).ToList();
        } 
        public MauSanXuat GetDetail(long id)
        {
            return DbContext.MauSanXuats.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    NgayGuiMauFormat = TimeHelper.TimestampToString(s.NgayGuiMau, "d"),
                    NgayKetQuaFormat = TimeHelper.TimestampToString(s.NgayKetqua, "d"),
                    PhanLoaiKetQua = s.DanhMuc.Ten,
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh),
                    s.UserAccount.LoaiNguoiDung
                }).ToList();
        }

        public void GetDataSource(GridControl control, long donHangId)
        {
            control.DataSource = GetList(donHangId)
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    NgayGuiMauFormat = TimeHelper.TimestampToString(s.NgayGuiMau, "d"),
                    NgayKetQuaFormat = TimeHelper.TimestampToString(s.NgayKetqua, "d"),
                    PhanLoaiKetQua = s.DanhMuc.Ten,
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh)
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauSanXuats.Add((MauSanXuat)data);
            }
            else
            {
                DbContext.MauSanXuats.AddOrUpdate((MauSanXuat)data);
            }
            DbContext.SaveChanges();
        }
    }
}
