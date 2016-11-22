using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using DevExpress.CodeParser;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.QuanLyNguoiDung
{
    public partial class ucPhanQuyen : BaseUserControl
    {
        private BindingList<PhanQuyenNguoiDung> _phanQuyenNguoiDungs = new BindingList<PhanQuyenNguoiDung>();
        private Define.LoaiNguoiDung _loaiNguoiDung;
        public ucPhanQuyen(Define.LoaiNguoiDung loaiNguoiDung)
        {
            InitializeComponent();
            _loaiNguoiDung = loaiNguoiDung;
            Init();

            InitPhanQuyen(loaiNguoiDung);
        }

        public void InitPhanQuyen(Define.LoaiNguoiDung loaiNguoiDung)
        {
            var lstPhanQuyen = SF.Get<PhanQuyenNguoiDungViewModel>().GetList(loaiNguoiDung);
            foreach (var feature in Authorization.AuthentDict)
            {
                if (lstPhanQuyen.Any(s => s.Feature == feature.ToString()))
                {
                    continue;
                }

                for (int i = 0; i < Enum.GetValues(typeof(Define.Authorization)).Length; i++)
                {
                    var newFeaturePermission = new PhanQuyenNguoiDung();
                    newFeaturePermission.Feature = feature.Key;
                    newFeaturePermission.LoaiNguoiDung = loaiNguoiDung.ToString();
                    lstPhanQuyen.Add(newFeaturePermission);
                }

            }

            var groupByFeature = lstPhanQuyen.GroupBy(s => s.Feature);
            foreach (var feature in groupByFeature)
            {
                var featurePermission = new PhanQuyenNguoiDung();
                featurePermission.Feature = feature.Key;
                featurePermission.LoaiNguoiDung = loaiNguoiDung.ToString();
                featurePermission.IsView = feature.Any(s => s.Permission == Define.Authorization.VIEW.ToString());
                featurePermission.IsWrite = feature.Any(s => s.Permission == Define.Authorization.WRITE.ToString());
                featurePermission.IsVerify = feature.Any(s => s.Permission == Define.Authorization.VERIFY.ToString());
                _phanQuyenNguoiDungs.Add(featurePermission);
            }
            gridControl.DataSource = new BindingList<PhanQuyenNguoiDung>(_phanQuyenNguoiDungs);
        }

        public override bool SaveData()
        {
            using (var scope = new TransactionScope())
            {
                SF.Get<PhanQuyenNguoiDungViewModel>().Delete(_loaiNguoiDung);

                foreach (var phanQuyenNguoiDung in _phanQuyenNguoiDungs)
                {
                    if (phanQuyenNguoiDung.IsView)
                    {
                        var phanquyen = phanQuyenNguoiDung.Clone();
                        CRUD.DecorateSaveData(phanquyen);
                        phanquyen.Permission = Define.Authorization.VIEW.ToString();
                        SF.Get<PhanQuyenNguoiDungViewModel>().Save(phanquyen);
                    }

                    if (phanQuyenNguoiDung.IsWrite)
                    {
                        var phanquyen = phanQuyenNguoiDung.Clone();
                        CRUD.DecorateSaveData(phanquyen);
                        phanquyen.Permission = Define.Authorization.WRITE.ToString();
                        SF.Get<PhanQuyenNguoiDungViewModel>().Save(phanquyen);
                    }

                    if (phanQuyenNguoiDung.IsVerify)
                    {
                        var phanquyen = phanQuyenNguoiDung.Clone();
                        CRUD.DecorateSaveData(phanquyen);
                        phanquyen.Permission = Define.Authorization.VERIFY.ToString();
                        SF.Get<PhanQuyenNguoiDungViewModel>().Save(phanquyen);
                    }
                }
                scope.Complete();
            }
            return true;
        }
    }
}

namespace TLShoes
{
    public partial class PhanQuyenNguoiDung
    {
        public bool IsView { get; set; }
        public bool IsWrite { get; set; }
        public bool IsVerify { get; set; }

        public PhanQuyenNguoiDung Clone()
        {
            return this.MemberwiseClone() as PhanQuyenNguoiDung;
        }
    }

}
