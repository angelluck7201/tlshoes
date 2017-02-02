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
            var data = GetList();
            control.DataSource = data;
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.PhieuNhapKhoes.AddOrUpdate((PhieuNhapKho)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public string GenerateSoPhieu(Define.Kho kho)
        {
            var currentItemNum = DbContext.PhieuNhapKhoes.Count();
            var currentTime = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
            var soPhieu = "";
            if (kho == Define.Kho.KHO_BAN_THANH_PHAM)
            {
                soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_BTP, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
            }
            if (kho == Define.Kho.KHO_THANH_PHAM)
            {
                soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_TP, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
            }
            if (kho == Define.Kho.KHO_VAT_TU)
            {
                soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_VT, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
            }
            return soPhieu;
        }

        public string GenerateSoPhieuDoiKho(string oldSoPhieu, Define.Kho kho)
        {
            var soPhieu = "";
            var oldSoPhieus = oldSoPhieu.Split('_');
            if (oldSoPhieus.Length > 0)
            {
                if (kho == Define.Kho.KHO_BAN_THANH_PHAM)
                {
                    soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_BTP_UPDATE, oldSoPhieus[1]);
                }
                if (kho == Define.Kho.KHO_THANH_PHAM)
                {
                    soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_TP_UPDATE, oldSoPhieus[1]);
                }
                if (kho == Define.Kho.KHO_VAT_TU)
                {
                    soPhieu = string.Format(Define.SO_PHIEU_NHAP_KHO_VT_UPDATE, oldSoPhieus[1]);
                }
            }

            return soPhieu;
        }
    }
}
