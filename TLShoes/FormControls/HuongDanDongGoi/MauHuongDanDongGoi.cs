using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucMauHuongDanDongGoi : BaseUserControl
    {
        BindingList<ChiTietHuongDanDongGoi> ChiTietHuongDanList = new BindingList<ChiTietHuongDanDongGoi>();
        private static MauHuongDanDongGoiViewModel _viewModel = SF.Get<MauHuongDanDongGoiViewModel>();

        public ucMauHuongDanDongGoi(MauHuongDanDongGoi data = null)
        {
            InitializeComponent();

            MauHuongDanDongGoi_KhachHangId.DisplayMember = "TenCongTy";
            MauHuongDanDongGoi_KhachHangId.ValueMember = "Id";
            MauHuongDanDongGoi_KhachHangId.DataSource = new BindingSource(SF.Get<KhachHangViewModel>().GetList(), null);


            Init(data);
            if (data != null)
            {
                ChiTietHuongDanList = new BindingList<ChiTietHuongDanDongGoi>(data.ChiTietHuongDanDongGois.ToList());
            }

            gridHuongDan.DataSource = ChiTietHuongDanList;

            DanhMucIdLookUp.NullText = "";
            DanhMucIdLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.CHI_TIET).Select(s => new { s.Ten, s.Id }).ToList();
            DanhMucIdLookUp.PopulateColumns();
            DanhMucIdLookUp.ShowHeader = false;
            DanhMucIdLookUp.Columns["Id"].Visible = false;
            DanhMucIdLookUp.Properties.DisplayMember = "Ten";
            DanhMucIdLookUp.Properties.ValueMember = "Id";
            DanhMucIdLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            DonViTinhIdLookUp.NullText = "";
            DonViTinhIdLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.DON_VI_TINH).Select(s => new { s.Ten, s.Id }).ToList();
            DonViTinhIdLookUp.PopulateColumns();
            DonViTinhIdLookUp.ShowHeader = false;
            DonViTinhIdLookUp.Columns["Id"].Visible = false;
            DonViTinhIdLookUp.Properties.DisplayMember = "Ten";
            DonViTinhIdLookUp.Properties.ValueMember = "Id";
            DonViTinhIdLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            MauIdLookUp.NullText = "";
            MauIdLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU).Select(s => new { s.Ten, s.Id }).ToList();
            MauIdLookUp.PopulateColumns();
            MauIdLookUp.ShowHeader = false;
            MauIdLookUp.Columns["Id"].Visible = false;
            MauIdLookUp.Properties.DisplayMember = "Ten";
            MauIdLookUp.Properties.ValueMember = "Id";
            MauIdLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            NguyenLieuIdLookUp.NullText = "";
            NguyenLieuIdLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuIdLookUp.PopulateColumns();
            NguyenLieuIdLookUp.ShowHeader = false;
            NguyenLieuIdLookUp.Columns["Id"].Visible = false;
            NguyenLieuIdLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuIdLookUp.Properties.ValueMember = "Id";
            NguyenLieuIdLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnDeleteHuongDan.Click += btnDeleteHuongDan_Click;

        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            var saveData = CRUD.GetFormObject<MauHuongDanDongGoi>(FormControls);
            _viewModel.Save(saveData, false);

            foreach (var chitiet in ChiTietHuongDanList)
            {
                chitiet.MauHuongDanDongGoiId = saveData.Id;
                chitiet.HinhMauDinhKem = FileHelper.ImageSave(chitiet.HinhMauDinhKemFormat);
                CRUD.DecorateSaveData(chitiet);
                _viewModel.Save(chitiet, false);
            }

            // Delete not use data
            var mauHuongDan = _viewModel.GetDetail(saveData.Id);
            if (mauHuongDan != null)
            {
                var chitietHuongDanDongGoi = mauHuongDan.ChiTietHuongDanDongGois.ToList();
                foreach (var chitiet in chitietHuongDanDongGoi)
                {
                    if (ChiTietHuongDanList.All(s => s.Id != chitiet.Id))
                    {
                        _viewModel.Delete(chitiet, false);
                    }
                }
            }

            BaseModel.Commit();

            return true;
        }


        public string ValidateInput()
        {
            return string.Empty;
        }

        private void btnDeleteHuongDan_Click(object sender, EventArgs e)
        {
            gridViewHuongDan.DeleteRow(gridViewHuongDan.FocusedRowHandle);
        }
    }
}
