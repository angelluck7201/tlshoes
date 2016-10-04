using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public class Authorization
    {
        public static UserAccount LoginUser;

        public bool CheckLogin(string userName, string passWord)
        {
            LoginUser = BaseModel.DbContext.UserAccounts.ToList().FirstOrDefault(s => s.TenNguoiDung.Equals(userName) && s.MatKhau.Equals(passWord));
            return LoginUser != null;
        }
    }
}
