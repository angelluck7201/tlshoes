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

namespace TLShoes.FormControls.NhaCungCap
{
    public partial class ucNhaCungCap : BaseUserControl
    {
        private BindingList<NhaCungCapVatTu> ChiTietNguyenLieuList = new BindingList<NhaCungCapVatTu>();
        private static NhaCungCapViewModel _viewModel = SF.Get<NhaCungCapViewModel>();
        public ucNhaCungCap(TLShoes.NhaCungCap data = null)
        {
            InitializeComponent();
            Init(data);
            if (data != null)
            {
                ChiTietNguyenLieuList = new BindingList<NhaCungCapVatTu>(data.NhaCungCapVatTus.ToList());
            }

            gridNguyenLieu.DataSource = ChiTietNguyenLieuList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            DonViLookup.NullText = "";
            DonViLookup.Properties.DataSource = Define.ListString<Define.TienTe>();
            DonViLookup.PopulateColumns();
            DonViLookup.ShowHeader = false;
            DonViLookup.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            var saveData = CRUD.GetFormObject<TLShoes.NhaCungCap>(FormControls);
            _viewModel.Save(saveData, false);

            foreach (var nguyenlieu in ChiTietNguyenLieuList)
            {
                nguyenlieu.NhaCungCapId = saveData.Id;
                CRUD.DecorateSaveData(nguyenlieu);
                _viewModel.Save(nguyenlieu, false);
            }

            // Delete not use data
            var listVatTu = _viewModel.GetListVatTu(saveData.Id);
            foreach (var vattu in listVatTu)
            {
                if (ChiTietNguyenLieuList.All(s => s.Id != vattu.Id))
                {
                    _viewModel.Delete(vattu, false);
                }
            }

            BaseModel.Commit();

            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }


        #region Update total assessment

        private void UpdateTotalAssessment()
        {
            var updateData = new List<decimal>();
            if (NhaCungCap_DungThoiGian.Rating > 0)
            {
                updateData.Add(NhaCungCap_DungThoiGian.Rating);
            }
            if (NhaCungCap_DatTestHoa.Rating > 0)
            {
                updateData.Add(NhaCungCap_DatTestHoa.Rating);
            }
            if (NhaCungCap_DatTestLy.Rating > 0)
            {
                updateData.Add(NhaCungCap_DatTestLy.Rating);
            }
            if (NhaCungCap_DichVuGiaoHang.Rating > 0)
            {
                updateData.Add(NhaCungCap_DichVuGiaoHang.Rating);
            }
            if (NhaCungCap_DichVuHauMai.Rating > 0)
            {
                updateData.Add(NhaCungCap_DichVuHauMai.Rating);
            }
            if (NhaCungCap_DungMau.Rating > 0)
            {
                updateData.Add(NhaCungCap_DungMau.Rating);
            }
            if (NhaCungCap_DungYeuCauKyThuat.Rating > 0)
            {
                updateData.Add(NhaCungCap_DungYeuCauKyThuat.Rating);
            }
            if (NhaCungCap_Gia.Rating > 0)
            {
                updateData.Add(NhaCungCap_Gia.Rating);
            }
            if (NhaCungCap_Khac.Rating > 0)
            {
                updateData.Add(NhaCungCap_Khac.Rating);
            }

            DanhGiaTongThe.Rating = updateData.Average();
        }

        private void NhaCungCap_DungThoiGian_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DungMau_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DatTestLy_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DatTestHoa_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DungYeuCauKyThuat_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_Gia_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DichVuGiaoHang_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_DichVuHauMai_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void NhaCungCap_Khac_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }
        #endregion

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }
    }
}
