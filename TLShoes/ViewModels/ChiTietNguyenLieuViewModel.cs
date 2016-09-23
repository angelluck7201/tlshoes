using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

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

        public void Delete(long id, bool isCommit = true)
        {
            var removeItem = GetDetail(id);
            if (removeItem != null)
            {
                DbContext.ChiTietNguyenLieux.Remove(removeItem);
                if (isCommit)
                {
                    DbContext.SaveChanges();
                }
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

        public void Save(object data, bool isCommit = true)
        {
            DbContext.ChiTietNguyenLieux.AddOrUpdate((ChiTietNguyenLieu)data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }
    }
}
