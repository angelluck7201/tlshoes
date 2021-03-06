﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class ChiTietNhapKhoViewModel : BaseModel, IViewModel<ChiTietNhapKho>
    {
        public List<ChiTietNhapKho> GetList()
        {
            return DbContext.ChiTietNhapKhoes.ToList();
        }

        public List<ChiTietNhapKho> GetListByNhapKho(long phieuNhapId)
        {
            return DbContext.ChiTietNhapKhoes.Where(s => s.PhieuNhapKhoId == phieuNhapId).ToList();
        }

        public List<ChiTietNhapKho> GetListByNguyenLieu(long nguyenLieuId)
        {
            return DbContext.ChiTietNhapKhoes.Where(s => s.NguyenLieuId == nguyenLieuId).ToList();
        }

        public ChiTietNhapKho GetDetail(long id)
        {
            return DbContext.ChiTietNhapKhoes.Find(id);
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList();
        }

        public void GetDataSource(long phieuNhapId, ref BindingList<ChiTietNhapKho> bindingData)
        {
            bindingData = new BindingList<ChiTietNhapKho>(GetListByNhapKho(phieuNhapId));
        }

        public void Save(object data, bool isCommit = true)
        {

            DbContext.ChiTietNhapKhoes.AddOrUpdate((ChiTietNhapKho)data);
            if (isCommit)
            {
                Commit();
            }
        }

        public void Delete(long id, bool isCommit = true)
        {
            var removeItem = GetDetail(id);
            if (removeItem != null)
            {
                DbContext.ChiTietNhapKhoes.Remove(removeItem);
                if (isCommit)
                {
                    Commit();
                }
            }
        }
    }
}
