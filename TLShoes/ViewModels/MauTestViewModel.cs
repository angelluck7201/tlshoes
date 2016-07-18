using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauTestViewModel : BaseModel, IViewModel<MauTest>
    {
        public List<MauTest> GetList()
        {
            return DbContext.MauTests.ToList();
        }

        public List<MauTest> GetList(long donHangId)
        {
            return DbContext.MauTests.Where(s => s.DonHangId == donHangId).OrderBy(s => s.NgayGuiMau).ToList();
        }
        public MauTest GetDetail(long id)
        {
            return DbContext.MauTests.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    NgayKetQuaTestLyFormat = TimeHelper.TimestampToString(s.NgayKetquaTestLy, "d"),
                    PhanLoaiTestLy = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestLyId).Ten,
                    NgayKetQuaTestHoaFormat = TimeHelper.TimestampToString(s.NgayKetquaTestHoa, "d"),
                    PhanLoaiTestHoa = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestHoaId).Ten,
                    Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh)
                }).ToList();
        }

        public void GetDataSource(GridControl control, long donHangId)
        {
            control.DataSource = GetList(donHangId)
               .Select(s => new
               {
                   s.Id,
                   s.DonHang.MaHang,
                   SoDH = s.DonHang.OrderNo,
                   NgayKetQuaTestLyFormat = TimeHelper.TimestampToString(s.NgayKetquaTestLy, "d"),
                   PhanLoaiTestLy = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestLyId).Ten,
                   NgayKetQuaTestHoaFormat = TimeHelper.TimestampToString(s.NgayKetquaTestHoa, "d"),
                   PhanLoaiTestHoa = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestHoaId).Ten,
                   Hinh = FileHelper.ImageFromFile(s.DonHang.HinhAnh)
               }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauTests.Add((MauTest)data);
            }
            else
            {
                DbContext.MauTests.AddOrUpdate((MauTest)data);
            }
            DbContext.SaveChanges();
        }
    }
}
