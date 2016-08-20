using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ToTrinhViewModel : BaseModel, IViewModel<ToTrinh>
    {
        public List<ToTrinh> GetList()
        {
            return DbContext.ToTrinhs.ToList();
        }

        public List<ToTrinh> GetList(long totrinhid)
        {
            return DbContext.ToTrinhs.Where(s => s.Id < totrinhid).ToList();
        } 

        public ToTrinh GetDetail(long id)
        {
            return DbContext.ToTrinhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.NguyenLieuId,
                s.NguyenLieu.Ten,
                s.BoSung,
                s.ThuHoi,
                s.TonToTrinh,
                s.TonTheKho,
                s.TonThucTe,
                s.DuKien,
                s.HaoHut,
                s.GhiChu
            }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.ToTrinhs.Add((ToTrinh)data);
            }
            else
            {
                DbContext.ToTrinhs.AddOrUpdate((ToTrinh)data);
            }
            DbContext.SaveChanges();
        }
    }
}
