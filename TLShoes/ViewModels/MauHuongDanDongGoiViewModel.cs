using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                s.GhiChu
            }).ToList();
        }

        public void Save(MauHuongDanDongGoi data)
        {
            // dynamic dynamicData = data;
            DbContext.MauHuongDanDongGois.AddOrUpdate(data);
            DbContext.SaveChanges();
        }

        public void Save(ChiTietHuongDanDongGoi data)
        {
            // dynamic dynamicData = data;
            DbContext.ChiTietHuongDanDongGois.AddOrUpdate(data);
            DbContext.SaveChanges();
        }

        public void Delete(ChiTietHuongDanDongGoi data)
        {
            DbContext.ChiTietHuongDanDongGois.Remove(data);
        }
    }
}
