using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class PhanQuyenNguoiDungViewModel : BaseModel, IViewModel<PhanQuyenNguoiDung>
    {
        public List<PhanQuyenNguoiDung> GetList()
        {
            return DbContext.PhanQuyenNguoiDungs.ToList();
        }

        public List<PhanQuyenNguoiDung> GetList(Define.LoaiNguoiDung loaiNguoiDung)
        {
            return GetList().Where(s => s.LoaiNguoiDung == loaiNguoiDung.ToString()).ToList();
        }

        public PhanQuyenNguoiDung GetDetail(long id)
        {
            return DbContext.PhanQuyenNguoiDungs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void Save(object data)
        {
            DbContext.PhanQuyenNguoiDungs.AddOrUpdate((PhanQuyenNguoiDung)data);
            DbContext.SaveChanges();
        }

        public void Delete(Define.LoaiNguoiDung loaiNguoiDung)
        {
            var lstDelete = GetList(loaiNguoiDung);
            foreach (var phanQuyenNguoiDung in lstDelete)
            {
                DbContext.PhanQuyenNguoiDungs.Remove(phanQuyenNguoiDung);
            }
            DbContext.SaveChanges();
        }
    }
}
