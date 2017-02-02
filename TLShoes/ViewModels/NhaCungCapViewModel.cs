using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class NhaCungCapViewModel : BaseModel, IViewModel<NhaCungCap>
    {
        public List<NhaCungCap> GetList()
        {
            return DbContext.NhaCungCaps.ToList();
        }

        public List<NhaCungCapVatTu> GetListVatTu(long nhaCungCapId)
        {
            return DbContext.NhaCungCapVatTus.Where(s => s.NhaCungCapId == nhaCungCapId).ToList();
        }
        public NhaCungCap GetDetail(long id)
        {
            return DbContext.NhaCungCaps.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = DbContext.NhaCungCaps.Select(s => new
            {
                s.Id,
                s.TenCongTy,
                s.TenNguoiDaiDien,
                s.Dienthoai,
                s.Fax,
                s.Email,
                s.MatHang,
                DanhGia = (new List<int?>() { s.Gia, s.DichVuGiaoHang, s.DatTestHoa, s.DatTestLy, s.DichVuHauMai, s.DungThoiGian, s.DichVuHauMai, s.DungYeuCauKyThuat, s.Khac }.Where(a => a > 0).Average()),
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void GetSummary(GridControl control)
        {
            control.DataSource = GetList().SelectMany(n => n.NhaCungCapVatTus).Select(s => new
          {
              Id = s.NhaCungCapId,
              NhaCungCap = s.NhaCungCap.TenCongTy,
//              GiaBanTuNgay = TimeHelper.TimeStampToDateTime(s.GiaBanTuNgay, "d"),
//              GiaBanDenNgay = TimeHelper.TimeStampToDateTime(s.GiaBanDenNgay, "d"),
              s.DonGia,
              NguyenLieu = s.NguyenLieu.Ten,
              DanhGia = (new List<int?>() { s.NhaCungCap.Gia, s.NhaCungCap.DichVuGiaoHang, s.NhaCungCap.DatTestHoa, s.NhaCungCap.DatTestLy, s.NhaCungCap.DichVuHauMai, s.NhaCungCap.DungThoiGian, s.NhaCungCap.DichVuHauMai, s.NhaCungCap.DungYeuCauKyThuat, s.NhaCungCap.Khac }.Where(a => a > 0).Average())
          }).ToList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.NhaCungCaps.AddOrUpdate((NhaCungCap)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Save(NhaCungCapVatTu data, bool isCommit = true)
        {
            DbContext.NhaCungCapVatTus.AddOrUpdate(data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Delete(NhaCungCapVatTu data, bool isCommit = true)
        {
            DbContext.NhaCungCapVatTus.Remove(data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}

namespace TLShoes
{
    public partial class NhaCungCapVatTu
    {


    }
}
