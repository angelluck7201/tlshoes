using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;
using TLShoes.Form;

namespace TLShoes.ViewModels
{
    public class NhatKyThayDoiViewModel : BaseModel, IViewModel<NhatKyThayDoi>
    {
        public List<NhatKyThayDoi> GetList()
        {
            return DbContext.NhatKyThayDois.ToList();
        }


        public List<NhatKyThayDoi> GetList(Define.ModelType model, long itemId)
        {
            return DbContext.NhatKyThayDois.Where(s => s.ItemId == itemId && s.ModelName == model.ToString()).OrderByDescending(s => s.CreatedDate).ToList();
        }


        public NhatKyThayDoi GetDetail(long id)
        {
            return DbContext.NhatKyThayDois.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void GetDataSource(GridControl control, Define.ModelType model, long itemId)
        {
            control.DataSource = GetList(model, itemId);
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.NhatKyThayDois.AddOrUpdate((NhatKyThayDoi)data);

            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }
    }
}
