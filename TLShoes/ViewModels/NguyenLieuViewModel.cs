using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class NguyenLieuViewModel : BaseModel, IViewModel<NguyenLieu>
    {
        public List<NguyenLieu> GetList()
        {
            return DbContext.NguyenLieux.ToList();
        }

        public NguyenLieu GetDetail(long id)
        {
            return DbContext.NguyenLieux.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    LoaiNguyenLieu = s.LoaiNguyenLieu != null ? s.LoaiNguyenLieu.Ten : "",
                    s.Ten,
                    s.MaNguyenLieu,
                    s.SoLuong
                }).ToList();
        }

        public void UpdateNguyenLieuXuatKho(PhieuXuatKho phieuXuatKho, bool isCancel = false)
        {
            var incrOrDesc = isCancel ? 1 : -1;
            foreach (var chiTietXuatKho in phieuXuatKho.ChiTietXuatKhoes)
            {
                var soLuong = incrOrDesc*chiTietXuatKho.SoLuong;
                UpdateSoLuongNguyenLieu(chiTietXuatKho.NguyenLieu, soLuong);
            }
            DbContext.SaveChanges();
        }

        public void UpdateNguyenLieuNhapKho(PhieuNhapKho phieuNhapKho, bool isCancel = false)
        {
            var incrOrDesc = isCancel ? -1 : 1;
            foreach (var nhapKho in phieuNhapKho.ChiTietNhapKhoes)
            {
                var soLuong = incrOrDesc * nhapKho.SoLuong;
                UpdateSoLuongNguyenLieu(nhapKho.NguyenLieu, soLuong);
            }
            DbContext.SaveChanges();
        }

        private void UpdateSoLuongNguyenLieu(NguyenLieu nguyenLieu, float soLuong)
        {
            nguyenLieu.SoLuong += soLuong;
            nguyenLieu.SoLuong = Math.Max(0, nguyenLieu.SoLuong);
            DbContext.NguyenLieux.AddOrUpdate(nguyenLieu);
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.NguyenLieux.AddOrUpdate((NguyenLieu)data);
            if (isCommit)
            {
                Commit();
            }
        }
    }
}
