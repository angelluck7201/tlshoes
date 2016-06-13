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
                    NgayKetQuaTestLyFormat = TimeHelper.TimestampToString(s.NgayKetquaTestLy, "d"),
                    PhanLoaiTestLy = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestLyId).Ten,
                    NgayKetQuaTestHoaFormat = TimeHelper.TimestampToString(s.NgayKetquaTestHoa, "d"),
                    PhanLoaiTestHoa = SF.Get<DanhMucViewModel>().GetDetail((long)s.PhanLoaiTestHoaId).Ten,
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
