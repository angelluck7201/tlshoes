
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.XuatKho
{
    public partial class ucXuatKho : BaseUserControl
    {
        private BindingList<ChiTietXuatKho> ChiTietXuatKhoList = new BindingList<ChiTietXuatKho>();

        public ucXuatKho(PhieuXuatKho data = null)
        {
            InitializeComponent();

            PhieuXuatKho_DonHangId.DisplayMember = "MaHang";
            PhieuXuatKho_DonHangId.ValueMember = "Id";
            PhieuXuatKho_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            PhieuXuatKho_Kho.DisplayMember = "Value";
            PhieuXuatKho_Kho.ValueMember = "Key";
            PhieuXuatKho_Kho.DataSource = new BindingSource(Define.KhoDic, null);

            PhieuXuatKho_LoaiXuat.DisplayMember = "Value";
            PhieuXuatKho_LoaiXuat.ValueMember = "Key";
            PhieuXuatKho_LoaiXuat.DataSource = new BindingSource(Define.LoaiXuatDic, null);

            Init(data);

            if (data != null)
            {
                SF.Get<ChiTietXuatKhoViewModel>().GetDataSource(data.Id, ref ChiTietXuatKhoList);
                PhieuXuatKho_Kho.SelectedValue = PrimitiveConvert.StringToEnum<Define.Kho>(data.Kho);
                PhieuXuatKho_LoaiXuat.SelectedValue = PrimitiveConvert.StringToEnum<Define.LoaiXuat>(data.LoaiXuat);
                DonHangChange((long)data.DonHangId);
            }

            gridNguyenLieu.DataSource = ChiTietXuatKhoList;

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

            // Validate Xuat Kho
            var donHangId = PhieuXuatKho_DonHangId.SelectedValue;
            if (donHangId != null)
            {
                var validateMessage = "";
                var chiLenhInfo = SF.Get<DonHangViewModel>().GetDetail((long)donHangId).ChiLenhs.FirstOrDefault();
                if (chiLenhInfo != null)
                {
                    foreach (var chitiet in ChiTietXuatKhoList)
                    {
                        bool isOk = chiLenhInfo.NguyenLieuChiLenhs.Any(s => s.DinhMucThuc >= chitiet.SoLuong && s.ChiTietNguyenLieux.Any(a => a.NguyenLieu.Id == chitiet.NguyenLieuId));

                        if (!isOk && chitiet.NguyenLieuId != null)
                        {
                            var nguyenLieu = SF.Get<NguyenLieuViewModel>().GetDetail((long)chitiet.NguyenLieuId);
                            if (nguyenLieu != null)
                            {
                                validateMessage += string.Format("{0} không phù hợp với chỉ lệnh \r\n", nguyenLieu.Ten);
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(validateMessage))
                {
                    var confirmResult = MessageBox.Show(validateMessage, "Bạn có muốn chắc tiếp tục xuất kho", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.No)
                        return false;
                }
            }

            var saveData = CRUD.GetFormObject<PhieuXuatKho>(FormControls);
            SF.Get<PhieuXuatKhoViewModel>().Save(saveData, false);


            // Save chi teit xuat kho
            var currentItem = new List<long>();
            foreach (var chitiet in ChiTietXuatKhoList)
            {
                if (chitiet.IsUpdateKho == null || chitiet.IsUpdateKho == false)
                {
                    var nguyenLieu = chitiet.NguyenLieu;
                    nguyenLieu.SoLuong -= chitiet.SoLuong;
                    SF.Get<NguyenLieuViewModel>().Save(nguyenLieu, false);
                }
                chitiet.PhieuXuatKhoId = saveData.Id;
                chitiet.IsUpdateKho = true;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietXuatKhoViewModel>().Save(chitiet, false);
                currentItem.Add(chitiet.Id);
            }

            // Clear data
            var listChiTietDelete = SF.Get<ChiTietXuatKhoViewModel>().GetList().Where(s => s.PhieuXuatKhoId == saveData.Id);
            foreach (var deleteItem in listChiTietDelete)
            {
                if (!currentItem.Contains(deleteItem.Id))
                {
                    SF.Get<ChiTietXuatKhoViewModel>().Delete(deleteItem.Id, false);
                }
            }
            BaseModel.Commit();

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

        private void PhieuXuatKho_DonHangId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var donHangobj = PhieuXuatKho_DonHangId.SelectedValue;
            if (donHangobj != null)
            {
                DonHangChange((long)donHangobj);
            }
        }

        private void DonHangChange(long donHangId)
        {
            var donHangInfo = SF.Get<DonHangViewModel>().GetDetail(donHangId);
            SoDH.Text = donHangInfo.OrderNo;
        }
    }


}
