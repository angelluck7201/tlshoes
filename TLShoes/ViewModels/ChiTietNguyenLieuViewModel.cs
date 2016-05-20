using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiTietNguyenLieuViewModel : BaseModel, IViewModel<ChiTietNguyenLieu>
    {
        public List<ChiTietNguyenLieu> GetList()
        {
            return DbContext.ChiTietNguyenLieux.ToList();
        }

        public ChiTietNguyenLieu GetDetail(long id)
        {
            return DbContext.ChiTietNguyenLieux.Find(id);
        }

        public void Delete(long id)
        {
            var removeItem = GetDetail(id);
            if (removeItem != null)
            {
                DbContext.ChiTietNguyenLieux.Remove(removeItem);                
            }
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.NguyenLieu.Ten,
                    s.GhiChu
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.ChiTietNguyenLieux.Add((ChiTietNguyenLieu)data);
            }
            else
            {
                DbContext.ChiTietNguyenLieux.AddOrUpdate((ChiTietNguyenLieu)data);
            }
            DbContext.SaveChanges();
        }
    }
}
