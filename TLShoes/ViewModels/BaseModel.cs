using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace TLShoes.ViewModels
{
    public class BaseModel
    {
        private static GiayTLEntities _dbContext;
        public static GiayTLEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new GiayTLEntities();
                return _dbContext;
            }
        }

        public static void DisposeDb()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        public void FieldMapper(GridView view, Dictionary<string, string> fieldMapper)
        {
            for (int i = 0; i < view.Columns.Count; i++)
            {
                var column = view.Columns[i];
                var fieldName = column.FieldName;
                if (!string.IsNullOrEmpty(fieldName)
                    && fieldMapper.ContainsKey(column.FieldName))
                    column.Caption = fieldMapper[column.FieldName];
            }
        }

        public static void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
