using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DonDatHangViewModel : BaseModel, IViewModel<DonDatHang>
    {
        public List<DonDatHang> GetList()
        {
            return DbContext.DonDatHangs.ToList();
        }

        public List<DonDatHang> GetListByNhaCungCap(long nhaCungCapId)
        {
            return DbContext.DonDatHangs.Where(s => s.NhaCungCapId == nhaCungCapId).ToList();
        }

        public List<ChiTietDonDatHang> GetList(long donDatHangId)
        {
            return GetDetail(donDatHangId).ChiTietDonDatHangs.ToList();
        }

        public DonDatHang GetDetail(long id)
        {
            return DbContext.DonDatHangs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                SoDonDH = s.SoDH,
                NhaCungCap = s.NhaCungCap.TenCongTy,
                s.NgayDatHang,
                s.NgayGiaoHang,
                SoLuong = s.ChiTietDonDatHangs.Sum(a => a.SoLuong),
                SoLuongThuc = s.ChiTietDonDatHangs.Sum(a => a.SoLuongThuc),
                DanhGia = (new List<int?>() { s.Gia, s.DichVuGiaoHang, s.DatTestHoa, s.DatTestLy, s.DichVuHauMai, s.DungThoiGian, s.DichVuHauMai, s.DungYeuCauKyThuat, s.Khac }.Where(a => a > 0).Average()),
                s.UserAccount.LoaiNguoiDung

            }).ToList();
        }

        public void GetChiTietDatHang(DonDatHang donDatHang, ref BindingList<VatTuDonGia> bindingList)
        {
            bindingList.Clear();
            foreach (var dongia in donDatHang.ChiTietDonDatHangs)
            {
                var vattu = new VatTuDonGia();
                var nhaCungcap = dongia.NhaCungCap;
                if (nhaCungcap == null) continue;

                var donGiaNhaCungCap = dongia.NhaCungCap.NhaCungCapVatTus.FirstOrDefault(s => s.NguyenLieuId == dongia.NguyenLieuId);
                if (donGiaNhaCungCap != null)
                {
                    vattu.DonGia = (float)donGiaNhaCungCap.DonGia;
                    vattu.DonViTinh = donGiaNhaCungCap.NguyenLieu.DVT.Ten;
                    vattu.DonViTien = donGiaNhaCungCap.DonVi;
                }
                vattu.Id = dongia.Id;
                vattu.NguyenLieuId = dongia.NguyenLieuId;
                vattu.NhaCungCapId = dongia.NhaCungCapId;
                vattu.SoLuong = dongia.SoLuong;
                vattu.SoLuongThuc = dongia.SoLuongThuc;
                vattu.DonDatHangId = dongia.DonDatHangId;
                vattu.GhiChu = dongia.GhiChu;
                bindingList.Add(vattu);
            }
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.DonDatHangs.AddOrUpdate((DonDatHang)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Save(ChiTietDonDatHang data, bool isCommit = true)
        {
            DbContext.ChiTietDonDatHangs.AddOrUpdate(data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Delete(ChiTietDonDatHang data, bool isCommit = true)
        {
            DbContext.ChiTietDonDatHangs.Remove(data);
            if (isCommit)
            {
                Commit();
            }
        }

        public string GenerateSoPhieu()
        {
            var currentItemNum = DbContext.DonDatHangs.Count();
            var currentTime = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
            return string.Format(Define.SO_PHIEU_DON_DAT_HANG, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
        }

        public class VatTuDonGia : ChiTietDonDatHang
        {
            public float DonGia { get; set; }
            public string DonViTinh { get; set; }
            public string DonViTien { get; set; }
            public long ToTrinhId { get; set; }

            public float ThanhTien
            {
                get
                {
                    var soLuong = 0f;
                    if (SoLuong != null)
                    {
                        soLuong = (float)SoLuong;
                    }
                    return (float)soLuong * DonGia;
                }
            }
        }
    }
}

namespace TLShoes
{
    public partial class DonDatHang
    {
        public float DanhGia
        {
            get
            {
                return (DatTestHoa + DatTestHoa + DichVuGiaoHang + DichVuHauMai + DungMau + DungThoiGian + DungYeuCauKyThuat + Gia + Khac) / 9f;
            }
        }
    }
}
