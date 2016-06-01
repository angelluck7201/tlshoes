using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class UserAccountViewModel : BaseModel, IViewModel<UserAccount>
    {

        public List<UserAccount> GetList()
        {
            return DbContext.UserAccounts.ToList();
        }

        public UserAccount GetDetail(long id)
        {
            return DbContext.UserAccounts.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            //control.DataSource = GetList().Select(s => new { s.Id, s.Loai, s.Ten, s.GhiChu }).ToList();
        }

        public void Save(object data)
        {
            DbContext.UserAccounts.AddOrUpdate((UserAccount)data);
            DbContext.SaveChanges();
        }
    }
}
