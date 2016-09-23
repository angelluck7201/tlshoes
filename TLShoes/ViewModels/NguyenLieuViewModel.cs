using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class NguyenLieuViewModel : BaseModel, IViewModel<NguyenLieu>
    {
        public List<NguyenLieu> GetList()
        {
            return DbContext.NguyenLieux.ToList();
        }

        public NguyenLieu GetDetail(long id)
        {
            return DbContext.NguyenLieux.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    LoaiNguyenLieu = s.LoaiNguyenLieu != null ? s.LoaiNguyenLieu.Ten : "",
                    s.Ten,
                    s.MaNguyenLieu,
                    s.SoLuong
                }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.NguyenLieux.AddOrUpdate((NguyenLieu)data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}
