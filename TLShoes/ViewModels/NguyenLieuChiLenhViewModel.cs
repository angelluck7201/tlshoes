using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class NguyenLieuChiLenhViewModel : BaseModel, IViewModel<NguyenLieuChiLenh>
    {

        public List<NguyenLieuChiLenh> GetList()
        {
            return DbContext.NguyenLieuChiLenhs.ToList();
        }

        public NguyenLieuChiLenh GetDetail(long id)
        {
            return DbContext.NguyenLieuChiLenhs.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList()
                .Select(s => new
                {
                    s.Id,
                    PhanXuong = s.PhanXuong.Ten,
                    Mau = s.Mau.Ten,
                    s.QuyCach,
                    NguyenLieu = NguyenLieuFormat(s.ChiTietNguyenLieux.ToList()),
                }).ToList();
        }

        public void GetDataSource(BindingList<ShowData> data)
        {
            var listData = GetList();
            var listShowData = new List<ShowData>();
            foreach (var item in listData)
            {
                listShowData.Add(new ShowData()
                {
                    Id = item.Id,
                    PhanXuong = item.PhanXuong.Ten,
                    Mau = item.Mau.Ten,
                    QuyCach = item.QuyCach,
                    NguyenLieu = NguyenLieuFormat(item.ChiTietNguyenLieux.ToList())
                });
            }
            data = new BindingList<ShowData>(listShowData);
        }


        public string NguyenLieuFormat(List<ChiTietNguyenLieu> data)
        {
            var result = new StringBuilder();
            foreach (var item in data)
            {
                if (item.NguyenLieu != null)
                {
                    result.Append(string.Format("{0} {1}", item.NguyenLieu.Ten, item.GhiChu));
                    result.AppendLine();
                }
            }
            return result.ToString();
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.NguyenLieuChiLenhs.Add((NguyenLieuChiLenh)data);
            }
            else
            {
                DbContext.NguyenLieuChiLenhs.AddOrUpdate((NguyenLieuChiLenh)data);
            }
            DbContext.SaveChanges();
        }

        public class ShowData
        {
            public long Id { get; set; }
            public string PhanXuong { get; set; }
            public string QuyCach { get; set; }
            public string NguyenLieu { get; set; }
            public string Mau { get; set; } 
        }
    }
}
