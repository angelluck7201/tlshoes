using System.Collections.Generic;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public interface IViewModel<T>
    {
        List<T> GetList();
        void GetDataSource(GridControl control);
        T GetDetail(long id);

    }
}
