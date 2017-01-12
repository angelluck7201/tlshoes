using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Core;
using TLShoes.Form;


namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiLenh : BaseUserControl
    {
        private BindingList<NguyenLieuChiLenhViewModel.ShowData> NguyenLieuChiLenhList = new BindingList<NguyenLieuChiLenhViewModel.ShowData>();
        private BindingList<ChiTietNguyenLieu> ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>();
        private int TongDonHang = 0;
        private TLShoes.ChiLenh _chiLenh;

        public ucChiLenh(TLShoes.ChiLenh data = null)
        {
            InitializeComponent();

            ChiLenh_DonHangId.DisplayMember = "MaHang";
            ChiLenh_DonHangId.ValueMember = "Id";
            ChiLenh_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            NguyenLieuChiLenh_PhanXuongId.DisplayMember = "Ten";
            NguyenLieuChiLenh_PhanXuongId.ValueMember = "Id";
            NguyenLieuChiLenh_PhanXuongId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_XUONG), null);

            NguyenLieuChiLenh_MauId.DisplayMember = "Ten";
            NguyenLieuChiLenh_MauId.ValueMember = "Id";
            NguyenLieuChiLenh_MauId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU), null);

            NguyenLieuChiLenh_ChiTietId.DisplayMember = "Ten";
            NguyenLieuChiLenh_ChiTietId.ValueMember = "Id";
            NguyenLieuChiLenh_ChiTietId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.CHI_TIET), null);

            Init(data);

            if (data != null)
            {
                SF.Get<NguyenLieuChiLenhViewModel>().GetDataSource(data.Id, ref NguyenLieuChiLenhList);
                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.CHILENH, data.Id);
                _chiLenh = data;
            }

            gridControl.DataSource = NguyenLieuChiLenhList;
            gridNguyenLieu.DataSource = ChiTietNguyenLieuList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.DisplayMember = "Ten";
            NguyenLieuLookUp.ValueMember = "Id";
            NguyenLieuLookUp.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;

            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

            if (_chiLenh != null)
            {
                lblSoPhieu.Text = string.Format("Số Chỉ Lệnh: {0}", _chiLenh.SoPhieu);
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_chiLenh.TrangThai);

                if (trangThai <= Define.TrangThai.HUY)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.TRUONG_PKT.ToString())
                    {
                        btnDuyet.Visible = true;
                    }
                }

                // Check verify authorize
                if (trangThai == Define.TrangThai.DUYET)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.GDKT.ToString())
                    {
                        btnDuyet.Visible = true;
                        btnCancel.Enabled = true;
                    }
                }

                // Can't save if verified
                if (trangThai > Define.TrangThai.HUY)
                {
                    btnSave.Enabled = false;
                }

                // Allow export after final verify
                if (trangThai == Define.TrangThai.DUYET_PKT)
                {
                    btnExport.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                }

                var verifyAuthorize = Authorization.CheckAuthorization("ChiLenh", Define.Authorization.VERIFY);
                btnDuyet.Visible &= verifyAuthorize;
            }
        }


        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            // Save Don hang
            using (var transaction = new TransactionScope())
            {
                var saveData = CRUD.GetFormObject(FormControls, _chiLenh);
                CRUD.DecorateSaveData(saveData, _chiLenh == null);
                SF.Get<ChiLenhViewModel>().Save(saveData);

                // Save nguyen lieu chi lenh
                foreach (var nguyenlieu in NguyenLieuChiLenhList)
                {
                    var nguyenlieuChiLenh = new NguyenLieuChiLenh();
                    nguyenlieuChiLenh.Id = nguyenlieu.Id;
                    nguyenlieuChiLenh.PhanXuongId = nguyenlieu.PhanXuongId;
                    nguyenlieuChiLenh.ChiLenhId = saveData.Id;
                    nguyenlieuChiLenh.ChiTietId = nguyenlieu.ChiTietId;
                    nguyenlieuChiLenh.QuyCach = nguyenlieu.QuyCach;
                    nguyenlieuChiLenh.MauId = nguyenlieu.MauId;
                    nguyenlieuChiLenh.DinhMucChuan = nguyenlieu.DinhMucChuan;
                    nguyenlieuChiLenh.DinhMucThuc = nguyenlieu.DinhMucThuc;

                    CRUD.DecorateSaveData(nguyenlieuChiLenh);
                    SF.Get<NguyenLieuChiLenhViewModel>().Save(nguyenlieuChiLenh);

                    // Save chi tiet nguyen lieu
                    if (nguyenlieu.ChiTietNguyenLieuList == null) continue;
                    var currentItem = new List<long>();
                    foreach (var chitiet in nguyenlieu.ChiTietNguyenLieuList)
                    {
                        var chitietNguyenLieu = new ChiTietNguyenLieu();
                        chitietNguyenLieu.Id = chitiet.Id;
                        chitietNguyenLieu.ChiTietNguyenLieuId = chitiet.ChiTietNguyenLieuId;
                        chitietNguyenLieu.NguyenLieuChiLenhId = nguyenlieuChiLenh.Id;
                        chitietNguyenLieu.GhiChu = chitiet.GhiChu;
                        CRUD.DecorateSaveData(chitietNguyenLieu);
                        SF.Get<ChiTietNguyenLieuViewModel>().Save(chitietNguyenLieu);
                        currentItem.Add(chitietNguyenLieu.Id);
                    }

                    // Clear deleted data
                    var listChiTietDelete = SF.Get<ChiTietNguyenLieuViewModel>().GetList().Where(s => s.NguyenLieuChiLenhId == nguyenlieuChiLenh.Id);
                    foreach (var deleteItem in listChiTietDelete)
                    {
                        if (!currentItem.Contains(deleteItem.Id))
                        {
                            SF.Get<ChiTietNguyenLieuViewModel>().Delete(deleteItem.Id);
                        }
                    }
                }

                var nhatKyThayDoi = new NhatKyThayDoi();
                nhatKyThayDoi.GhiChu = LyDoThayDoi.Text;
                nhatKyThayDoi.ModelName = Define.ModelType.CHILENH.ToString();
                nhatKyThayDoi.ItemId = saveData.Id;
                CRUD.DecorateSaveData(nhatKyThayDoi);
                SF.Get<NhatKyThayDoiViewModel>().Save(nhatKyThayDoi);
                BaseModel.Commit();

                transaction.Complete();
            }


            return true;
        }

        public string ValidateInput()
        {
            if (_chiLenh != null)
            {
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_chiLenh.TrangThai);
                if (trangThai > Define.TrangThai.MOI)
                {
                    return "Chỉ lệnh đã được duyệt nên không thể thay đổi!";
                }
                if (string.IsNullOrEmpty(LyDoThayDoi.Text))
                {
                    return "Không được phép để trống lý do thay đổi!";
                }
            }
            return string.Empty;
        }

        private void gridView_Click(object sender, EventArgs e)
        {
            var data = gridView.GetRow(gridView.FocusedRowHandle) as NguyenLieuChiLenhViewModel.ShowData;
            if (data.ChiTietId != null) NguyenLieuChiLenh_ChiTietId.SelectedValue = data.ChiTietId;
            NguyenLieuChiLenh_DinhMucChuan.Text = data.DinhMucChuan.ToString();
            NguyenLieuChiLenh_DinhMucThuc.Text = data.DinhMucThuc.ToString();
            if (data.MauId != null) NguyenLieuChiLenh_MauId.SelectedValue = data.MauId;
            NguyenLieuChiLenh_QuyCach.Text = data.QuyCach;
            NguyenLieuChiLenh_PhanXuongId.SelectedValue = data.PhanXuongId;
            if (data.ChiTietNguyenLieuList != null) ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(data.ChiTietNguyenLieuList.ToList());

            gridNguyenLieu.DataSource = ChiTietNguyenLieuList;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var saveData = CRUD.GetFormObject<NguyenLieuChiLenh>(FormControls);
            var tenNguyenLieu = SF.Get<NguyenLieuChiLenhViewModel>().NguyenLieuFormat(ChiTietNguyenLieuList.ToList());

            var chitiet = NguyenLieuChiLenhList.FirstOrDefault(s => s.ChiTietId == saveData.ChiTietId);
            if (chitiet == null)
            {
                chitiet = new NguyenLieuChiLenhViewModel.ShowData();
                NguyenLieuChiLenhList.Add(chitiet);
            }

            chitiet.ChiTiet = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.ChiTietId).Ten;
            chitiet.PhanXuong = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.PhanXuongId).Ten;
            chitiet.Mau = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.MauId).Ten;
            chitiet.NguyenLieu = tenNguyenLieu;
            chitiet.QuyCach = saveData.QuyCach;
            chitiet.DinhMucChuan = (float)saveData.DinhMucChuan;
            chitiet.DinhMucThuc = (float)saveData.DinhMucThuc;
            chitiet.ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(ChiTietNguyenLieuList.ToList());
            chitiet.ChiTietId = saveData.ChiTietId;
            chitiet.PhanXuongId = saveData.PhanXuongId;
            chitiet.MauId = saveData.MauId;

            gridControl.RefreshDataSource();

            ChiTietNguyenLieuList.Clear();
            ClearData("NguyenLieuChiLenh");
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void NguyenLieuChiLenh_DinhMucChuan_TextChanged(object sender, EventArgs e)
        {
            var editDinhMucChuan = PrimitiveConvert.StringToFloat(NguyenLieuChiLenh_DinhMucChuan.Text);
            NguyenLieuChiLenh_DinhMucThuc.Text = (TongDonHang * editDinhMucChuan / 1000f).ToString();
        }

        private void ChiLenh_DonHangId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ChiLenh_DonHangId.SelectedValue != null)
            {
                TongDonHang = SF.Get<DonHangViewModel>().TongDonHang((long)ChiLenh_DonHangId.SelectedValue);
                lblDinhMucThuc.Text = string.Format("{0} {1}", "Định Mức", TongDonHang);
                gridView.Columns[7].Caption = lblDinhMucThuc.Text;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_CHI_LENH));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        var donHang = _chiLenh.DonHang;

                        workSheet.Cells[5, "A"] = string.Format("ĐH: {0}", donHang.OrderNo);
                        workSheet.Cells[5, "D"] = string.Format("MH: {0}", donHang.MaHang);
                        workSheet.Cells[5, "F"] = string.Format("PHOM: {0}", donHang.Phom.MaNguyenLieu);
                        workSheet.Cells[5, "K"] = string.Format("KH: {0}", donHang.KhachHang.TenCongTy);
                        workSheet.Cells[5, "M"] = string.Format("XH: {0}", TimeHelper.TimestampToString(donHang.NgayXuat, "d"));
                        workSheet.Cells[5, "P"] = string.Format("SP: {0}", TimeHelper.TimestampToString(_chiLenh.NgayDuyet, "d"));

                        workSheet.Shapes.AddPicture(donHang.HinhAnh, MsoTriState.msoFalse, MsoTriState.msoCTrue, 447, 0, 150, 67);


                        var chiTietDonhang = donHang.ChiTietDonHangs.OrderBy(s => s.Size).ToList();
                        var firstColSize = 4;
                        foreach (var chitiet in chiTietDonhang)
                        {
                            workSheet.Cells[6, firstColSize] = string.Format("{0}#", chitiet.Size);
                            workSheet.Cells[7, firstColSize] = chitiet.SoLuong;
                            firstColSize++;
                        }

                        var nguyenLieuChiLenh = _chiLenh.NguyenLieuChiLenhs;
                        var firstRowNguyenLieu = 11;
                        foreach (var lieuChiLenh in nguyenLieuChiLenh)
                        {
                            var chitTietNguyenLieu = lieuChiLenh.ChiTietNguyenLieux.ToList();
                            workSheet.Cells[firstRowNguyenLieu, "D"] = SF.Get<NguyenLieuChiLenhViewModel>().NguyenLieuFormat(chitTietNguyenLieu);
                            workSheet.Cells[firstRowNguyenLieu, "J"] = lieuChiLenh.QuyCach;
                            if (lieuChiLenh.Mau != null) workSheet.Cells[firstRowNguyenLieu, "K"] = lieuChiLenh.Mau.Ten;

                            var nguyenLieuDaiDien = chitTietNguyenLieu.FirstOrDefault(s => s.NguyenLieu != null && s.NguyenLieu.DanhMuc != null);
                            if (nguyenLieuDaiDien != null)
                            {
                                workSheet.Cells[firstRowNguyenLieu, "L"] = nguyenLieuDaiDien.NguyenLieu.DanhMuc.Ten;
                            }
                            workSheet.Cells[firstRowNguyenLieu, "M"] = lieuChiLenh.DinhMucChuan;
                            workSheet.Cells[firstRowNguyenLieu, "P"] = lieuChiLenh.DinhMucThuc;
                            firstRowNguyenLieu++;
                        }

                        var currentDate = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
                        workSheet.Cells[44, "K"] = string.Format("Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);
                        workSheet.Cells[48, "K"] = Authorization.LoginUser.TenNguoiDung;

                        workBook.SaveAs(saveDialog.FileName);
                    }
                    finally
                    {
                        workBook.Close();
                    }

                });


                var confirmDialog = MessageBox.Show(Define.MESSAGE_EXPORT_SUCCESS_TEXT, Define.MESSAGE_EXPORT_SUCCESS_TITLE, MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    Process.Start(saveDialog.FileName);
                }
                this.ParentForm.Close();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (_chiLenh != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_chiLenh.TrangThai);
                    var ngayDuyet = TimeHelper.CurrentTimeStamp();
                    // Lock item
                    if (trangThai <= Define.TrangThai.HUY)
                    {
                        _chiLenh.NgayLap = ngayDuyet;
                        _chiLenh.NguoiLapId = Authorization.LoginUser.Id;
                        _chiLenh.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _chiLenh.NgayDuyet = ngayDuyet;
                        _chiLenh.NguoiDuyetId = Authorization.LoginUser.Id;
                        _chiLenh.SoPhieu = SF.Get<ChiLenhViewModel>().GenerateSoPhieu();
                        _chiLenh.TrangThai = Define.TrangThai.DUYET_PKT.ToString();
                    }

                    SF.Get<ChiLenhViewModel>().Save(_chiLenh);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            if (_chiLenh != null)
            {
                ShowCustomForm(new Form.NhatKyThayDoi(Define.ModelType.CHILENH.ToString(), _chiLenh.Id, () =>
                {
                    SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.CHILENH, _chiLenh.Id);
                    _chiLenh.TrangThai = Define.TrangThai.HUY.ToString();
                    _chiLenh.NgayDuyet = TimeHelper.CurrentTimeStamp();
                    _chiLenh.NguoiDuyetId = Authorization.LoginUser.Id;
                    InitAuthorize();
                }), "Nhật ký thay đổi");
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            // Clear old info
            xtraTabPage1.Controls.Clear();

            // Init new default info
            defaultInfo = new DefaultInfo();
            defaultInfo.Dock = DockStyle.Fill;
            xtraTabPage1.Controls.Add(defaultInfo);

            // Clear nhat ky
            gridNhatKy.DataSource = null;

            _chiLenh = null;

            var confirmDialog = MessageBox.Show("Đã tạo thành công chỉ lệnh tương tự, bạn có muốn lưu lại!", "Copy chỉ lệnh", MessageBoxButtons.YesNo);
            if (confirmDialog == DialogResult.Yes)
            {
                btnSave.PerformClick();
            }

        }

    }
}

