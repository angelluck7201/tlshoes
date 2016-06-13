using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;

namespace TLShoes.ViewModels
{
    public class DanhMucViewModel : BaseModel, IViewModel<DanhMuc>
    {

        public enum LoaiDanhMuc
        {
            MAU,
            PHAN_LOAI_TEST,
            CHI_TIET,
            DON_VI_TINH,
            PHAN_XUONG,
            LOAI_NGUYEN_LIEU,
        }

        public static Dictionary<LoaiDanhMuc, string> LoaiDanhMucDic = new Dictionary<LoaiDanhMuc, string>()
       {
           {LoaiDanhMuc.MAU, "MÀU"},
           {LoaiDanhMuc.PHAN_LOAI_TEST, "PHÂN LOẠI TEST"},
           {LoaiDanhMuc.CHI_TIET, "CHI TIẾT"},
           {LoaiDanhMuc.DON_VI_TINH, "ĐƠN VỊ TÍNH"},
           {LoaiDanhMuc.PHAN_XUONG, "PHÂN XƯỞNG"},
           {LoaiDanhMuc.LOAI_NGUYEN_LIEU, "LOẠI NGUYÊN LIỆU"},
       };

        public List<DanhMuc> GetList()
        {
            return DbContext.DanhMucs.ToList();
        }

        public List<DanhMuc> GetList(LoaiDanhMuc loai)
        {
            return DbContext.DanhMucs.Where(s => s.Loai == loai.ToString()).ToList();
        }

        public DanhMuc GetDetail(long id)
        {
            return DbContext.DanhMucs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new { s.Id, s.Loai, s.Ten, s.GhiChu }).ToList();
        }

        public void Save(object data)
        {
            DbContext.DanhMucs.AddOrUpdate((DanhMuc)data);
            DbContext.SaveChanges();
        }
    }
}
