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


        public void GetDataSource(GridControl control, long donHangId)
        {
            control.DataSource = GetList(donHangId)
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    s.DonHang.OrderNo,
                    s.NgayGuiMau,
                    s.NgayKetqua,
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
