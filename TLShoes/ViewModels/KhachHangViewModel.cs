using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class KhachHangViewModel : BaseModel, IViewModel<KhachHang>
    {
        public List<KhachHang> GetList()
        {
            return DbContext.KhachHangs.ToList();
        }
        public KhachHang GetDetail(long id)
        {
            return DbContext.KhachHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.TenCongTy,
                s.TenNguoiDaiDien,
                s.Dienthoai,
                s.Fax,
                s.Email,
                s.MatHang,
                DanhGia = (new List<int?>() { s.Gia, s.DichVuGiaoHang, s.DatTestHoa, s.DatTestLy, s.DichVuHauMai, s.DungThoiGian, s.DichVuHauMai, s.DungYeuCauKyThuat, s.Khac }.Where(a => a > 0).Average())
            }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.KhachHangs.Add((KhachHang)data);
            }
            else
            {
                DbContext.KhachHangs.AddOrUpdate((KhachHang)data);
            }
            DbContext.SaveChanges();
        }
    }
}
