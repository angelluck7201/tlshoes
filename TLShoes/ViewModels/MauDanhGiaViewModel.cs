using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauDanhGiaViewModel : BaseModel, IViewModel<MauDanhGia>
    {
        public List<MauDanhGia> GetList()
        {
            return DbContext.MauDanhGias.ToList();
        }

        public List<ChiTietMauDanhGia> GetListTieuChi(long mauDanhGiaId)
        {
            return DbContext.ChiTietMauDanhGias.Where(s => s.MauDanhGiaId == mauDanhGiaId).ToList();
        }
        public MauDanhGia GetDetail(long id)
        {
            return DbContext.MauDanhGias.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauDanhGias.Add((MauDanhGia)data);
            }
            else
            {
                DbContext.MauDanhGias.AddOrUpdate((MauDanhGia)data);
            }
            DbContext.SaveChanges();
        }

        public void Save(ChiTietMauDanhGia data)
        {

            try
            {
                if (data.Id == 0)
                {
                    DbContext.ChiTietMauDanhGias.Add(data);
                }
                else
                {
                    DbContext.ChiTietMauDanhGias.AddOrUpdate(data);
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

        public void Delete(ChiTietMauDanhGia data)
        {
            DbContext.ChiTietMauDanhGias.Remove(data);
        }

        public void Delete(long mauDanhGiaId)
        {
            var mauDanhGia = GetDetail(mauDanhGiaId);
            if (mauDanhGia != null)
            {
                DbContext.MauDanhGias.Remove(mauDanhGia);
            }
        }
    }
}
