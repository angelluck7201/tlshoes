using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace TLShoes.ViewModels
{
    public interface IViewModel<T>
    {
        List<T> GetList();
        void GetDataSource(GridControl control);
        T GetDetail(long id);

    }
}
