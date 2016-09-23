using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DonHangViewModel : BaseModel, IViewModel<DonHang>
    {
        public List<DonHang> GetList()
        {
            var listDonHang = DbContext.DonHangs.ToList();
            foreach (var donhang in listDonHang)
            {
                if (!donhang.MaHang.Contains("-"))
                {
                    donhang.MaHang = string.Format("{0}-{1}", donhang.NguyenLieu.MaNguyenLieu, donhang.MaHang);
                }
            }
            return listDonHang;
        }

        public DonHang GetDetail(long id)
        {
            return DbContext.DonHangs.Find(id);
        }

        public int TongDonHang(long id)
        {
            var result = 0;
            var donhang = GetDetail(id);
            if (donhang != null && donhang.ChiTietDonHangs != null)
            {
                result = (int)donhang.ChiTietDonHangs.Sum(s => s.SoLuong);
            }
            return result;
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.MaHang,
                s.OrderNo,
                s.KhachHang.TenCongTy,
                NgayNhanFormat = TimeHelper.TimeStampToDateTime(s.NgayNhan, "d"),
                NgayXuatFormat = TimeHelper.TimeStampToDateTime(s.NgayXuat, "d"),
                SoLuong = s.ChiTietDonHangs.Sum(d => d.SoLuong),
                Hinh = FileHelper.ImageFromFile(s.HinhAnh)
            }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.DonHangs.AddOrUpdate((DonHang)data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}
