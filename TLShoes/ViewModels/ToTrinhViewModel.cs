using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting.Native;
using TLShoes;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ToTrinhViewModel : BaseModel, IViewModel<ToTrinh>
    {
        public List<ToTrinh> GetList()
        {
            return DbContext.ToTrinhs.ToList();
        }

        public ToTrinh GetDetail(long id)
        {
            return DbContext.ToTrinhs.Find(id);
        }

        public TongHopToTrinh GetDetailTongHopToTrinh(long id)
        {
            return DbContext.TongHopToTrinhs.Find(id);
        }

        public List<ToTrinh> GetList(DonDatHang donDatHang)
        {
            return DbContext.ToTrinhs.ToList().Where(s =>
                string.IsNullOrEmpty(s.DonDatHangList)
                || (donDatHang != null && s.DonDatHangFormatList.Contains(donDatHang.Id))).ToList();
        }

        public void GetDataSource(GridControl control, DonDatHang donDatHang)
        {
            control.DataSource = GetList(donDatHang);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void Save(ToTrinh data, bool isCommit = true)
        {
            DbContext.ToTrinhs.AddOrUpdate(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }

        public void Save(TongHopToTrinh data, bool isCommit = true)
        {
            DbContext.TongHopToTrinhs.AddOrUpdate(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }

        public string GenerateSoPhieu()
        {
            var currentItemNum = DbContext.TongHopToTrinhs.Count();
            var currentTime = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
            return string.Format(Define.SO_PHIEU_TO_TRINH, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
        }
    }
}

namespace TLShoes
{
    public partial class ToTrinh
    {
        public List<long> DonDatHangFormatList
        {
            get
            {
                var result = new List<long>();
                if (DonDatHangList != null)
                {
                    result = DonDatHangList.Split(',').Select(s => PrimitiveConvert.StringToInt(s)).ToList();
                }
                return result;
            }
        }
    }

    public partial class TongHopToTrinh
    {
        public string NgayLapFormat
        {
            get
            {
                if (NgayLap.Year == 1) return string.Empty;
                return NgayLap.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string NgayDuyetFormat
        {
            get
            {
                if (NgayDuyet.Year == 1) return string.Empty;
                return NgayDuyet.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
