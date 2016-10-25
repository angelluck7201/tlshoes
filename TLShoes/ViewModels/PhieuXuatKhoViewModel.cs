using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class PhieuXuatKhoViewModel : BaseModel, IViewModel<PhieuXuatKho>
    {
        public List<PhieuXuatKho> GetList()
        {
            return DbContext.PhieuXuatKhoes.ToList();
        }

        public PhieuXuatKho GetDetail(long id)
        {
            return DbContext.PhieuXuatKhoes.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.DonHang.MaHang,
                s.DiaChi,
                s.NguoiNhan,
                s.BoPhan,
                s.LyDo,
                Kho = Define.KhoDic[PrimitiveConvert.StringToEnum<Define.Kho>(s.Kho)],
                LoaiXuat = Define.LoaiXuatDic[PrimitiveConvert.StringToEnum<Define.LoaiXuat>(s.LoaiXuat)],
                NgayXuatFormat = TimeHelper.TimeStampToDateTime(s.NgayXuat, "d"),
            }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.PhieuXuatKhoes.AddOrUpdate((PhieuXuatKho)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Save(NhatKyXuatKho data)
        {
            DbContext.NhatKyXuatKhoes.AddOrUpdate(data);
            Commit();
        }
    }
}
