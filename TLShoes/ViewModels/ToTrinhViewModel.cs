using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting.Native;
using TLShoes;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ToTrinhViewModel : BaseModel, IViewModel<ToTrinh>
    {
        public List<ToTrinh> GetList()
        {
            return DbContext.ToTrinhs.ToList();
        }

        public List<ToTrinh> GetList(long totrinhid)
        {
            return DbContext.ToTrinhs.Where(s => s.Id < totrinhid).ToList();
        }

        public ToTrinh GetDetail(long id)
        {
            return DbContext.ToTrinhs.Find(id);
        }

        public List<ToTrinh> GetList(DonDatHang donDatHang)
        {
            return DbContext.ToTrinhs.ToList().Where(s =>
                string.IsNullOrEmpty(s.DonDatHangList)
                || (donDatHang != null && s.DonDatHangFormatList.Contains(donDatHang.Id))).ToList();
        }

        public void GetDataSource(GridControl control, DonDatHang donDatHang)
        {
            control.DataSource = GetList(donDatHang);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.ToTrinhs.AddOrUpdate((ToTrinh)data);
            if (isCommit)
            {
                DbContext.SaveChanges();
            }
        }
    }
}

namespace TLShoes
{
    public partial class ToTrinh
    {
        public string Ten
        {
            get { return NguyenLieu != null ? NguyenLieu.Ten : ""; }
        }

        public List<long> DonDatHangFormatList
        {
            get
            {
                var result = new List<long>();
                if (DonDatHangList != null)
                {
                    result = DonDatHangList.Split(',').Select(s => PrimitiveConvert.StringToInt(s)).ToList();
                }
                return result;
            }
        }
    }
}
