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
            control.DataSource = GetList();
        }

        public void Save(object data)
        {
            DbContext.UserAccounts.AddOrUpdate((UserAccount)data);
            DbContext.SaveChanges();
        }

        public bool CheckDuplicate(string tenNguoiDung, long id)
        {
            return DbContext.UserAccounts.Any(s => s.Id != id && s.TenNguoiDung == tenNguoiDung);
        }
    }
}
