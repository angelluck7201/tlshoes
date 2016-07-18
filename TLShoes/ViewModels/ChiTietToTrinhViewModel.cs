using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiTietToTrinhViewModel : BaseModel, IViewModel<ChiTietToTrinh>
    {
        public List<ChiTietToTrinh> GetList()
        {
            return DbContext.ChiTietToTrinhs.ToList();
        }

        public ChiTietToTrinh GetDetail(long id)
        {
            return DbContext.ChiTietToTrinhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            //control.DataSource = GetList().Select(s => new
            //{
            //    s.Id,
            //    s.NguyenLieu.Ten,
            //    s.BoSung,
            //    s.ThuHoi,
            //    s.TonChiTietToTrinh,
            //    s.TonTheKho,
            //    s.TonThucTe,
            //    s.DuKien,
            //    s.HaoHut,
            //    s.GhiChu
            //}).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.ChiTietToTrinhs.Add((ChiTietToTrinh)data);
            }
            else
            {
                DbContext.ChiTietToTrinhs.AddOrUpdate((ChiTietToTrinh)data);
            }
            DbContext.SaveChanges();
        }
    }

}
