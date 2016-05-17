using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauSanXuatViewModel : BaseModel, IViewModel<MauSanXuat>
    {
        public List<MauSanXuat> GetList()
        {
            return DbContext.MauSanXuats.ToList();
        }
        public MauSanXuat GetDetail(long id)
        {
            return DbContext.MauSanXuats.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    s.DonHang.MaHang,
                    NgayGuiMauFormat = TimeHelper.TimestampToString(s.NgayGuiMau, "d"),
                    NgayKetQuaFormat = TimeHelper.TimestampToString(s.NgayKetqua, "d"),
                    PhanLoaiKetQua = s.DanhMuc.Ten,
                }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauSanXuats.Add((MauSanXuat)data);
            }
            else
            {
                DbContext.MauSanXuats.AddOrUpdate((MauSanXuat)data);
            }
            DbContext.SaveChanges();
        }
    }
}
