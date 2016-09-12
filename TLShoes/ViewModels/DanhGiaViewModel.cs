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
            }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.DanhGias.Add((DanhGia)data);
            }
            else
            {
                DbContext.DanhGias.AddOrUpdate((DanhGia)data);
            }
            DbContext.SaveChanges();
        }

        public void Save(ChiTietDanhGia data)
        {

            try
            {
                if (data.Id == 0)
                {
                    DbContext.ChiTietDanhGias.Add(data);
                }
                else
                {
                    DbContext.ChiTietDanhGias.AddOrUpdate(data);
                }
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    ConsoleWriter.WriteLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ConsoleWriter.WriteLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw;
            }

        }

        public void Delete(ChiTietDanhGia data)
        {
            DbContext.ChiTietDanhGias.Remove(data);
        }

        public void Delete(long DanhGiaId)
        {
            var DanhGia = GetDetail(DanhGiaId);
            if (DanhGia != null)
            {
                DbContext.DanhGias.Remove(DanhGia);
            }
        }
    }
}
