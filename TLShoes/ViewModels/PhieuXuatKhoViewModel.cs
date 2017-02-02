using System;
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
            control.DataSource = GetList();
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

        public string GenerateSoPhieu()
        {
            var currentItemNum = DbContext.PhieuXuatKhoes.Count();
            var currentTime = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
            return string.Format(Define.SO_PHIEU_XUAT_KHO, currentItemNum + 1, currentTime.Month.ToString("00"), currentTime.Year);
        }
    }
}

namespace TLShoes
{
    public partial class NhatKyXuatKho
    {
        
    }
}
