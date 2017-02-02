using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class ChiTietDonHangViewModel : BaseModel, IViewModel<ChiTietDonHang>
    {
        public List<ChiTietDonHang> GetList()
        {
            return DbContext.ChiTietDonHangs.ToList();
        }

        public List<ChiTietDonHang> GetList(long donHangId)
        {
            return DbContext.ChiTietDonHangs.Where(s => s.DonHangId == donHangId).ToList();
        }

        public ChiTietDonHang GetDetail(long id)
        {
            return DbContext.ChiTietDonHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            //control.DataSource = GetList().Select(s => new { s.Id, s.MaHang, s.OrderNo, s.KhachHang.TenCongTy, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan), NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat) }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.ChiTietDonHangs.AddOrUpdate((ChiTietDonHang)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Delete(ChiTietDonHang chiTietDonHang)
        {
            DbContext.ChiTietDonHangs.Remove(chiTietDonHang);
            DbContext.SaveChanges();
        }

        public void Delete(List<ChiTietDonHang> chiTietDonHangs)
        {
            foreach (var chiTietDonHang in chiTietDonHangs)
            {
                DbContext.ChiTietDonHangs.Remove(chiTietDonHang);
            }
            DbContext.SaveChanges();
        }
    }
}
