namespace TLShoes.ViewModels
{
    //public class BangThongSoViewModel : BaseModel, IViewModel<BangThongSo>
    //{
    //    public List<BangThongSo> GetList()
    //    {
    //        return DbContext.BangThongSoes.ToList();
    //    }
    //    public BangThongSo GetDetail(long id)
    //    {
    //        return DbContext.BangThongSoes.Find(id);
    //    }

    //    public void GetDataSource(GridControl control)
    //    {
    //        control.DataSource = GetList()
    //            .Select(s => new
    //            {
    //                s.Id,
    //                s.DonHang.MaHang,
    //                PhanXuong = s.DanhMuc.Ten,
    //                MaPhom = s.NguyenLieu.Ten,
    //                NgayKyFormat = TimeHelper.TimestampToString(s.NgayKy),
    //                NgayXacNhanFormat = TimeHelper.TimestampToString(s.NgayXacNhan),

    //            }).ToList();
    //    }

    //    public void Save(object data)
    //    {
    //        dynamic dynamicData = data;
    //        if (dynamicData.Id == 0)
    //        {
    //            DbContext.BangThongSoes.Add((BangThongSo)data);
    //        }
    //        else
    //        {
    //            DbContext.BangThongSoes.AddOrUpdate((BangThongSo)data);
    //        }
    //        DbContext.SaveChanges();
    //    }
    //}
}
