
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NhapKho
{
    public partial class ucNhapKho : BaseUserControl
    {
        private BindingList<ChiTietNhapKho> ChiTietNhapKhoList = new BindingList<ChiTietNhapKho>();

        public ucNhapKho(PhieuNhapKho data = null)
        {
            InitializeComponent();
            Init(data);

            PhieuNhapKho_Kho.DataSource = new BindingSource(Define.KhoDic, null);
            PhieuNhapKho_Kho.DisplayMember = "Value";
            PhieuNhapKho_Kho.ValueMember = "Key";

            if (data != null)
            {
                SF.Get<ChiTietNhapKhoViewModel>().GetDataSource(data.Id, ref ChiTietNhapKhoList);
                Define.Kho selectedKho = Define.Kho.KHO_BAN_THANH_PHAM;
                Enum.TryParse<Define.Kho>(data.Kho, out selectedKho);
                PhieuNhapKho_Kho.SelectedValue = selectedKho;
            }

            gridNguyenLieu.DataSource = ChiTietNhapKhoList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

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
            var saveData = CRUD.GetFormObject<PhieuNhapKho>(FormControls);
            SF.Get<PhieuNhapKhoViewModel>().Save(saveData);

            // Save chi teit Nhap kho
            var currentItem = new List<long>();
            foreach (var chitiet in ChiTietNhapKhoList)
            {
                chitiet.PhieuNhapKhoId = saveData.Id;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietNhapKhoViewModel>().Save(chitiet);
                currentItem.Add(chitiet.Id);
            }

            // Clear data
            var listChiTietDelete = SF.Get<ChiTietNhapKhoViewModel>().GetList().Where(s => s.PhieuNhapKhoId == saveData.Id);
            foreach (var deleteItem in listChiTietDelete)
            {
                if (!currentItem.Contains(deleteItem.Id))
                {
                    SF.Get<ChiTietNhapKhoViewModel>().Delete(deleteItem.Id);
                }
            }

            return true;
        }

        public string ValidateInput()
        {

            return string.Empty;
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }
    }


}
