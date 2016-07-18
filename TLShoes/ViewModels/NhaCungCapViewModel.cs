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
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.TenCongTy,
                s.TenNguoiDaiDien,
                s.Dienthoai,
                s.Fax,
                s.Email,
                s.MatHang,
                DanhGia = (new List<int?>() { s.Gia, s.DichVuGiaoHang, s.DatTestHoa, s.DatTestLy, s.DichVuHauMai, s.DungThoiGian, s.DichVuHauMai, s.DungYeuCauKyThuat, s.Khac }.Where(a => a > 0).Average())
            }).ToList();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.NhaCungCaps.Add((NhaCungCap)data);
            }
            else
            {
                DbContext.NhaCungCaps.AddOrUpdate((NhaCungCap)data);
            }
            DbContext.SaveChanges();
        }

        public void Save(NhaCungCapVatTu data)
        {

            try
            {
                if (data.Id == 0)
                {
                    DbContext.NhaCungCapVatTus.Add(data);
                }
                else
                {
                    DbContext.NhaCungCapVatTus.AddOrUpdate(data);
                }
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    ConsoleWriter.WriteLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ConsoleWriter.WriteLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw;
            }

        }

        public void Delete(NhaCungCapVatTu data)
        {
            DbContext.NhaCungCapVatTus.Remove(data);
        }
    }
}
