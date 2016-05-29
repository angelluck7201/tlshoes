using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.Native;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
                NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan, "d"),
                NgayXuatFormat = TimeHelper.TimestampToString(s.NgayXuat, "d"),
                SoLuong = s.ChiTietDonHangs.Sum(d => d.SoLuong),
                Hinh = FileHelper.ImageFromFile(s.HinhAnh)
            }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.DonHangs.Add((DonHang)data);
            }
            else
            {
                DbContext.DonHangs.AddOrUpdate((DonHang)data);
            }
            DbContext.SaveChanges();
        }
    }
}
