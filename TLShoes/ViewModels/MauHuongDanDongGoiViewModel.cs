using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauHuongDanDongGoiViewModel : BaseModel, IViewModel<MauHuongDanDongGoi>
    {
        public List<MauHuongDanDongGoi> GetList()
        {
            return DbContext.MauHuongDanDongGois.ToList();
        }

        public List<MauHuongDanDongGoi> GetList(long khachHangId)
        {
            return DbContext.MauHuongDanDongGois.Where(s => s.KhachHangId == khachHangId).ToList();
        }

        public MauHuongDanDongGoi GetDetail(long id)
        {
            return DbContext.MauHuongDanDongGois.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.TenMau,
                KhachHang = s.KhachHang.TenCongTy,
                ApDungTuNgay = TimeHelper.TimestampToString(s.ApDungTuNgay, "d"),
                ApDungDenNgay = TimeHelper.TimestampToString(s.ApDungDenNgay, "d"),
                s.GhiChu,
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void Save(MauHuongDanDongGoi data, bool isCommit = true)
        {
            // dynamic dynamicData = data;
            DbContext.MauHuongDanDongGois.AddOrUpdate(data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Save(ChiTietHuongDanDongGoi data, bool isCommit = true)
        {
            DbContext.ChiTietHuongDanDongGois.AddOrUpdate(data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Delete(ChiTietHuongDanDongGoi data, bool isCommit = true)
        {
            DbContext.ChiTietHuongDanDongGois.Remove(data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}

namespace TLShoes
{
    public partial class ChiTietHuongDanDongGoi
    {
        private Image _hinhDinhKemFormat;
        public Image HinhMauDinhKemFormat
        {
            get
            {
                if (_hinhDinhKemFormat == null)
                {
                    _hinhDinhKemFormat = FileHelper.ImageFromFile(HinhMauDinhKem);
                }
                return _hinhDinhKemFormat;
            }
            set { _hinhDinhKemFormat = value; }
        }
    }
}
