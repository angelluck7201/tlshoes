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

        public void GetDataSource(GridControl control, long donHangId)
        {
            control.DataSource = GetList(donHangId)
               .Select(s => new
               {
                   s.Id,
                   s.DonHang.MaHang,
                   s.DonHang.OrderNo,
                   s.NgayKetquaTestLy,
                   KetQuaTestLy = s.PhanLoaiTestLy.Ten,
                   s.NgayKetquaTestHoa,
                   KetQuaTestHoa = s.PhanLoaiTestHoa.Ten,
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
