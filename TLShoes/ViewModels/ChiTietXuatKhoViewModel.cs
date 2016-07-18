﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiTietXuatKhoViewModel : BaseModel, IViewModel<ChiTietXuatKho>
    {
        public List<ChiTietXuatKho> GetList()
        {
            return DbContext.ChiTietXuatKhoes.ToList();
        }

        public List<ChiTietXuatKho> GetListByXuatKho(long phieuXuatId)
        {
            return DbContext.ChiTietXuatKhoes.Where(s => s.PhieuXuatKhoId == phieuXuatId).ToList();
        }

        public List<ChiTietXuatKho> GetListByNguyenLieu(long nguyenLieuId)
        {
            return DbContext.ChiTietXuatKhoes.Where(s => s.NguyenLieuId == nguyenLieuId).ToList();
        }

        public ChiTietXuatKho GetDetail(long id)
        {
            return DbContext.ChiTietXuatKhoes.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void GetDataSource(long phieuXuatId, ref BindingList<ChiTietXuatKho> bindingData)
        {
            bindingData = new BindingList<ChiTietXuatKho>(GetListByXuatKho(phieuXuatId));
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.ChiTietXuatKhoes.Add((ChiTietXuatKho)data);
            }
            else
            {
                DbContext.ChiTietXuatKhoes.AddOrUpdate((ChiTietXuatKho)data);
            }
            DbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var removeItem = GetDetail(id);
            if (removeItem != null)
            {
                DbContext.ChiTietXuatKhoes.Remove(removeItem);
            }
        }
    }
}