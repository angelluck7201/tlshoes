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

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.NguyenLieux.Add((NguyenLieu)data);
            }
            else
            {
                DbContext.NguyenLieux.AddOrUpdate((NguyenLieu)data);
            }
            DbContext.SaveChanges();
        }
    }
}
