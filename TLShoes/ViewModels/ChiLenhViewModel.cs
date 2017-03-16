using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiLenhViewModel : BaseModel, IViewModel<ChiLenh>
    {
        public List<ChiLenh> GetList()
        {
            return DbContext.ChiLenhs.ToList();
        }

        public ChiLenh GetDetail(long id)
        {
            return DbContext.ChiLenhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    SoDH = s.DonHang.OrderNo,
                    NguoiDuyet = s.UserAccount.TenNguoiDung,
                    NgayDuyetFormat = s.NgayDuyet,
                    s.UserAccount.LoaiNguoiDung
                }).ToList();
        }

        public bool IsDuplicate(long donHangId, long? chiLenhId)
        {
            return DbContext.ChiLenhs.Any(s => s.DonHangId == donHangId && s.Id != chiLenhId);
        }

        public string GenerateSoPhieu()
        {
            var currentItemNum = DbContext.ChiLenhs.Count(s => !string.IsNullOrEmpty(s.SoPhieu));
            var currentTime = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
            return string.Format(Define.SO_PHIEU_CHI_LENH, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
        }

        public void Save(ChiLenh data, bool isCommit = true)
        {
            DbContext.ChiLenhs.AddOrUpdate(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }
    }
}
