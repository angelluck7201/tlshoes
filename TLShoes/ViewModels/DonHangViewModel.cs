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
                NgayNhanFormat = s.NgayNhan,
                NgayXuatFormat = s.NgayXuat,
                SoLuong = s.ChiTietDonHangs.Sum(d => d.SoLuong),
                Hinh = FileHelper.ImageFromFile(s.HinhAnh),
                s.UserAccount.LoaiNguoiDung
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
