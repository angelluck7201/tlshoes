using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class PhieuNhapKhoViewModel : BaseModel, IViewModel<PhieuNhapKho>
    {
        public List<PhieuNhapKho> GetList()
        {
            return DbContext.PhieuNhapKhoes.ToList();
        }

        public PhieuNhapKho GetDetail(long id)
        {
            return DbContext.PhieuNhapKhoes.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.NguoiGiao,
                s.DiaChi,
                s.LyDo,
                Kho = Define.KhoDic[PrimitiveConvert.StringToEnum<Define.Kho>(s.Kho)],
                NgayNhapFormat = TimeHelper.TimestampToString(s.NgayNhap, "d"),
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.PhieuNhapKhoes.AddOrUpdate((PhieuNhapKho)data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}
