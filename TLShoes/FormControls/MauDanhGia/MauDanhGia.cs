using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauDanhGia
{
    public partial class ucMauDanhGia : BaseUserControl
    {
        BindingList<ChiTietMauDanhGia> TieuChiList = new BindingList<ChiTietMauDanhGia>();
        private static MauDanhGiaViewModel _viewModel = SF.Get<MauDanhGiaViewModel>();
        private TLShoes.MauDanhGia _domainData;
        public ucMauDanhGia(TLShoes.MauDanhGia data = null)
        {
            InitializeComponent();

            Init(data);
            _domainData = data;
            if (data != null)
            {
                TieuChiList = new BindingList<ChiTietMauDanhGia>(data.ChiTietMauDanhGias.ToList());
            }

            gridTieuChi.DataSource = TieuChiList;

            SetRepositoryItem(TieuChiLookUp, SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.TIEU_CHI_QC), "Ten");

            btnDeleteTieuChi.Click += btnDeleteTieuChi_Click;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            var saveData = CRUD.GetFormObject(FormControls, _domainData);
            using (var transaction = new TransactionScope())
            {
                CRUD.DecorateSaveData(saveData, _domainData == null);
                _viewModel.Save(saveData);

                foreach (var nguyenlieu in TieuChiList)
                {
                    nguyenlieu.MauDanhGiaId = saveData.Id;
                    CRUD.DecorateSaveData(nguyenlieu);
                    _viewModel.Save(nguyenlieu);
                }

                // Delete not use data
                var listTieuChi = _viewModel.GetListTieuChi(saveData.Id);
                foreach (var tieuchi in listTieuChi)
                {
                    if (TieuChiList.All(s => s.Id != tieuchi.Id))
                    {
                        _viewModel.Delete(tieuchi);
                    }
                }
                transaction.Complete();
            }


            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void btnDeleteTieuChi_Click(object sender, EventArgs e)
        {
            gridViewTieuChi.DeleteRow(gridViewTieuChi.FocusedRowHandle);
        }
    }
}
