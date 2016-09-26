using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DanhMucViewModel : BaseModel, IViewModel<DanhMuc>
    {
        public List<DanhMuc> GetList()
        {
            return DbContext.DanhMucs.ToList();
        }

        public List<DanhMuc> GetList(Define.LoaiDanhMuc loai)
        {
            return DbContext.DanhMucs.Where(s => s.Loai == loai.ToString()).ToList();
        }

        public DanhMuc GetDetail(long id)
        {
            return DbContext.DanhMucs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.Loai, s.Ten, s.GhiChu }).ToList();
        }

        public void Save(object data)
        {
            DbContext.DanhMucs.AddOrUpdate((DanhMuc)data);
            DbContext.SaveChanges();
        }

        #region Validate

        public bool CheckDuplicate(long id, string loai, string data)
        {
            return DbContext.DanhMucs.Where(s => s.Loai == loai).Any(s => s.Id != id && s.Ten == data);
        }
        #endregion
    }
}
