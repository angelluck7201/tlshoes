using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class NguyenLieuViewModel : BaseModel, IViewModel<NguyenLieu>
    {
        /// <summary>
        /// Get list nguyen lieu cua 
        /// - Cac don hang chua hoan thanh
        /// - Chua duoc su dung trong to trinh nao
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="totrinhId"></param>
        /// <returns></returns>
        public List<NguyenLieu> GetListNguyenLieuToTrinh(GiayTLEntities dbContext)
        {
            var duyetChiLenhStatus = Define.TrangThai.DUYET_PKT.ToString();
            var doneStatus = Define.TrangThai.DONE.ToString();

            return dbContext.DonHangs.Where(s => s.TrangThai != doneStatus)
                .SelectMany(s => s.ChiLenhs).Where(s => s.TrangThai == duyetChiLenhStatus)
                .SelectMany(s => s.NguyenLieuChiLenhs)
                .SelectMany(s => s.ChiTietNguyenLieux).Where(s => !s.ChiTietToTrinhs.Any())
                .Select(s => s.NguyenLieu).Distinct().ToList();
        }


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
