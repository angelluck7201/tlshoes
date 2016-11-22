using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DanhGiaViewModel : BaseModel, IViewModel<DanhGia>
    {
        public List<DanhGia> GetList()
        {
            return DbContext.DanhGias.ToList();
        }

        public List<ChiTietDanhGia> GetListTieuChi(long DanhGiaId)
        {
            return DbContext.ChiTietDanhGias.Where(s => s.DanhGiaId == DanhGiaId).ToList();
        }
        public DanhGia GetDetail(long id)
        {
            return DbContext.DanhGias.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.DonDatHang.SoDH,
                SoLuongDat = s.DonDatHang.ChiTietDonDatHangs.Sum(a => a.SoLuong),
                s.SoLuongKiem,
                s.MauDanhGia.TenMau,
                TiLeKiem = Math.Round((double)(s.SoLuongKiem / s.DonDatHang.ChiTietDonDatHangs.Sum(a => a.SoLuong)), 2) * 100,
                SoLuongKem = s.ChiTietDanhGias.Sum(a => a.SoLuongKem),
                NgayKiem = TimeHelper.TimeStampToDateTime(s.NgayKiem, "d"),
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.DanhGias.AddOrUpdate((DanhGia)data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }

        public void Save(ChiTietDanhGia data, bool isCommit = true)
        {
            DbContext.ChiTietDanhGias.AddOrUpdate(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }

        public void Delete(ChiTietDanhGia data, bool isCommit = true)
        {
            DbContext.ChiTietDanhGias.Remove(data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }

        public void Delete(long danhGiaId, bool isCommit = true)
        {
            var danhGia = GetDetail(danhGiaId);
            if (danhGia != null)
            {
                DbContext.DanhGias.Remove(danhGia);
                if (isCommit)
                {
                    Commit();
                }
            }
        }
    }
}
