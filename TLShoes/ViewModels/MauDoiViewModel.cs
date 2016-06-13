using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauDoiViewModel : BaseModel, IViewModel<MauDoi>
    {
        public List<MauDoi> GetList()
        {
            return DbContext.MauDois.ToList();
        }

        public List<MauDoi> GetList(long donHangId)
        {
            return DbContext.MauDois.Where(s => s.DonHangId == donHangId).ToList();
        }

        public MauDoi GetDetail(long id)
        {
            return DbContext.MauDois.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.DonHang.MaHang, NgayNhanFormat = TimeHelper.TimestampToString(s.NgayNhan, "d"), MauNgayFormat = TimeHelper.TimestampToString(s.MauNgay, "d") }).ToList();
        }

        public void GetDataSummarySource(GridControl control)
        {
            var listResult = new List<SummaryTest>();
            foreach (var maudoi in GetList())
            {
                var item = new SummaryTest();
                item.MaHang = maudoi.DonHang.MaHang;
                item.NgayNhan = TimeHelper.TimestampToString(maudoi.NgayNhan, "d");
                var mauTest = SF.Get<MauTestViewModel>().GetList().FirstOrDefault(s => s.DonHangId == maudoi.DonHangId);
                if (mauTest != null)
                {
                    item.TestLy = mauTest.DanhMuc.Ten;
                    item.TestHoa = mauTest.DanhMuc1.Ten;
                }

                var mauSanXuat = SF.Get<MauSanXuatViewModel>().GetList().FirstOrDefault(s => s.DonHangId == maudoi.DonHangId);
                if (mauSanXuat != null)
                {
                    item.MauSanXuat = mauSanXuat.DanhMuc.Ten;
                }

                var mauThuDao = SF.Get<MauThuDaoViewModel>().GetList().FirstOrDefault(s => s.DonHangId == maudoi.DonHangId);
                if (mauThuDao != null)
                {
                    item.MauThuDao = TimeHelper.TimestampToString(mauThuDao.NgayHoanThanh, "d");
                }
                listResult.Add(item);
            }
            control.DataSource = listResult;
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauDois.Add((MauDoi)data);
            }
            else
            {
                DbContext.MauDois.AddOrUpdate((MauDoi)data);
            }
            DbContext.SaveChanges();
        }

        public class SummaryTest
        {
            public string MaHang { get; set; }
            public string NgayNhan { get; set; }
            public string TestLy { get; set; }
            public string TestHoa { get; set; }
            public string MauSanXuat { get; set; }
            public string MauThuDao { get; set; }
        }
    }
}
