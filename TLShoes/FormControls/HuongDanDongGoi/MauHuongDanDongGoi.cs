using System;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucMauHuongDanDongGoi : BaseUserControl
    {
        BindingList<ChiTietHuongDanDongGoi> ChiTietHuongDanList = new BindingList<ChiTietHuongDanDongGoi>();
        private ChiTietHuongDanDongGoi _curSelectedCard;
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

            DanhMucId.DisplayMember = "Ten";
            DanhMucId.ValueMember = "Id";
            DanhMucId.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.CHI_TIET).Select(s => new { s.Ten, s.Id }).ToList();

            DonViTinhId.DisplayMember = "Ten";
            DonViTinhId.ValueMember = "Id";
            DonViTinhId.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.DON_VI_TINH).Select(s => new { s.Ten, s.Id }).ToList();

            MauId.DisplayMember = "Ten";
            MauId.ValueMember = "Id";
            MauId.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU).Select(s => new { s.Ten, s.Id }).ToList();

            NguyenLieuId.DisplayMember = "Ten";
            NguyenLieuId.ValueMember = "Id";
            NguyenLieuId.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();

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
            using (var transaction = new TransactionScope())
            {
                _viewModel.Save(saveData);

                foreach (var chitiet in ChiTietHuongDanList)
                {
                    chitiet.MauHuongDanDongGoiId = saveData.Id;
                    chitiet.HinhMauDinhKem = FileHelper.ImageSave(chitiet.HinhMauDinhKemFormat);
                    CRUD.DecorateSaveData(chitiet);
                    _viewModel.Save(chitiet);
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
                            _viewModel.Delete(chitiet);
                        }
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

        private void btnDeleteHuongDan_Click(object sender, EventArgs e)
        {
            //            gridViewHuongDan.DeleteRow(gridViewHuongDan.FocusedRowHandle);
        }

        private void cardView1_Click(object sender, EventArgs e)
        {
            var selectedRow = cardView1.GetRow(cardView1.FocusedRowHandle) as ChiTietHuongDanDongGoi;
            if (selectedRow != null)
            {
                _curSelectedCard = selectedRow;
                DanhMucId.SelectedValue = selectedRow.DanhMucId;
                DonViTinhId.SelectedValue = selectedRow.DonViTinhId;
                KichThuoc.Text = selectedRow.KichThuoc;
                MauId.SelectedValue = selectedRow.MauId;
                NguyenLieuId.SelectedValue = selectedRow.NguyenLieuId;
                CachSuDung.Text = selectedRow.CachSuDung;
                ViTriSuDung.Text = selectedRow.ViTriSuDung;
                SoLuong.Text = selectedRow.SoLuong.ToString();
                FileHelper.SetImage(HinhAnh, selectedRow.HinhMauDinhKem);
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            MapChiTietHuongDanDongGoi(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_curSelectedCard != null)
            {
                ChiTietHuongDanList.Remove(_curSelectedCard);
                _curSelectedCard = null;
            }
        }

        private void btnUpdateHinh_Click(object sender, EventArgs e)
        {
            MapChiTietHuongDanDongGoi(false);
        }

        private void MapChiTietHuongDanDongGoi(bool isNew = false)
        {
            if (_curSelectedCard == null || isNew)
            {
                _curSelectedCard = new ChiTietHuongDanDongGoi();
                ChiTietHuongDanList.Add(_curSelectedCard);
            }
            _curSelectedCard.DanhMucId = (long)DanhMucId.SelectedValue;
            _curSelectedCard.DonViTinhId = (long)DonViTinhId.SelectedValue;
            _curSelectedCard.KichThuoc = KichThuoc.Text;
            _curSelectedCard.MauId = (long)MauId.SelectedValue;
            _curSelectedCard.NguyenLieuId = (long)NguyenLieuId.SelectedValue;
            _curSelectedCard.CachSuDung = CachSuDung.Text;
            _curSelectedCard.ViTriSuDung = ViTriSuDung.Text;
            _curSelectedCard.SoLuong = (int)PrimitiveConvert.StringToInt(SoLuong.Text);
            _curSelectedCard.HinhMauDinhKemFormat = HinhAnh.Image;
        }
    }
}
