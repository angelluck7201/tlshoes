using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinh : BaseUserControl
    {
        private TLShoes.ToTrinh currentToTrinh = null;
        private Dictionary<long, List<ChiTietToTrinh>> DictChiTietToTrinh = new Dictionary<long, List<ChiTietToTrinh>>();
        private BindingList<TLShoes.ToTrinh> ToTrinhList = new BindingList<TLShoes.ToTrinh>();
        public ucToTrinh(TLShoes.ToTrinh data = null)
        {
            InitializeComponent();

            ToTrinh_NguyenLieuId.DisplayMember = "Ten";
            ToTrinh_NguyenLieuId.ValueMember = "Id";
            ToTrinh_NguyenLieuId.DataSource = new BindingSource(SF.Get<NguyenLieuViewModel>().GetList(), null);

            Init(data);

            if (data != null)
            {
                ToTrinhList = new BindingList<TLShoes.ToTrinh>(SF.Get<ToTrinhViewModel>().GetList(data.SoPhieu));
            }

            gridToTrinh.DataSource = ToTrinhList;
            currentToTrinh = data;
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

            using (var transaction = new TransactionScope())
            {
                var soToTrinh = SF.Get<ToTrinhViewModel>().GenerateSoPhieu();
                foreach (var toTrinh in ToTrinhList)
                {
                    if (string.IsNullOrEmpty(toTrinh.SoPhieu))
                    {
                        toTrinh.SoPhieu = soToTrinh;
                    }
                    SF.Get<ToTrinhViewModel>().Save(toTrinh);

                    // Clear old data
                    if (toTrinh.ChiTietToTrinhs != null)
                    {
                        foreach (var chiTietToTrinh in toTrinh.ChiTietToTrinhs)
                        {
                            SF.Get<ChiTietToTrinhViewModel>().Delete(chiTietToTrinh);
                        }
                    }

                    // Save chi tiet to trinh
                    var nguyenLieuId = (long)toTrinh.NguyenLieuId;
                    if (DictChiTietToTrinh.ContainsKey(nguyenLieuId))
                    {
                        foreach (var chiTietToTrinh in DictChiTietToTrinh[nguyenLieuId])
                        {
                            chiTietToTrinh.ToTrinhId = toTrinh.Id;
                            SF.Get<ChiTietToTrinhViewModel>().Save(chiTietToTrinh);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                var nguyenLieuObj = ToTrinh_NguyenLieuId.SelectedValue;
                if (nguyenLieuObj != null)
                {
                    var nguyenLieuId = (long)nguyenLieuObj;
                    var chiLenhList = SF.Get<ChiTietNguyenLieuViewModel>().GetList()
                        .Where(s => s.ChiTietNguyenLieuId == nguyenLieuId)
                        .GroupBy(s => s.NguyenLieuChiLenh.ChiLenh.DonHang);

                    List<TLShoes.ToTrinh> oldToTrinh;
                    if (currentToTrinh == null)
                    {
                        oldToTrinh = SF.Get<ToTrinhViewModel>().GetList();
                    }
                    else
                    {
                        oldToTrinh = SF.Get<ToTrinhViewModel>().GetList(currentToTrinh.Id);
                    }

                    var thuHoiOldToTrinh = oldToTrinh.Sum(s => s.ThuHoi);

                    var xuatKhoList = SF.Get<ChiTietXuatKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongXuatKho = xuatKhoList.Sum(s => s.SoLuong);

                    var nhapKhoList = SF.Get<ChiTietNhapKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongNhapKho = nhapKhoList.Sum(s => s.SoLuong);

                    // Bổ sung là tổng xuất kho ngoài chỉ lệnh
                    var xuatKhoBoSung = xuatKhoList.Where(s => s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.NGOAI_CHI_LENH.ToString()).Sum(s => s.SoLuong);

                    // 
                    var thuHoi = tongXuatKho - tongNhapKho + thuHoiOldToTrinh;
                    var tonToTrinh = oldToTrinh.Sum(s => s.TonThucTe);
                    var tonTheKho = tongNhapKho - tongXuatKho;
                    var tongXuatKhoHaoHut = tongXuatKho * (1 + PrimitiveConvert.StringToFloat(ToTrinh_HaoHut));
                    var luyKe = tonToTrinh + thuHoi - tongXuatKhoHaoHut;

                    ToTrinh_BoSung.Text = xuatKhoBoSung.ToString();
                    ToTrinh_ThuHoi.Text = thuHoi.ToString();
                    ToTrinh_TonToTrinh.Text = tonToTrinh.ToString();
                    ToTrinh_TonTheKho.Text = tonTheKho.ToString();
                    ToTrinh_DuKien.Text = "0";
                    if (luyKe < 0)
                    {
                        ToTrinh_DuKien.Text = (-luyKe).ToString();
                    }

                    // Tính toán nhu cầu thực tế và xuất kho theo chỉ lệnh của vật tư
                    var lstChiTietToTrinh = new List<ChiTietToTrinh>();
                    foreach (var chilenh in chiLenhList)
                    {
                        var chitiet = new ChiTietToTrinh();
                        chitiet.DonHangId = chilenh.Key.Id;
                        chitiet.DonHang = chilenh.Key;
                        chitiet.NhuCau = chilenh.Sum(s => s.NguyenLieuChiLenh.DinhMucThuc);
                        chitiet.ThucTe = xuatKhoList.Where(s => s.PhieuXuatKho.DonHang.Id == chitiet.DonHangId
                                                                 && s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.TRONG_CHI_LENH.ToString())
                                                    .Sum(s => s.SoLuong);
                        lstChiTietToTrinh.Add(chitiet);
                    }

                    if (!DictChiTietToTrinh.ContainsKey(nguyenLieuId))
                    {
                        DictChiTietToTrinh.Add(nguyenLieuId, lstChiTietToTrinh);
                    }
                    gridChiTietToTrinh.DataSource = lstChiTietToTrinh.Select(s => new { s.DonHang.MaHang, s.NhuCau, s.ThucTe });
                }
            });
        }

        private void btnUpdateToTrinh_Click(object sender, EventArgs e)
        {
            var toTrinh = CRUD.GetFormObject<TLShoes.ToTrinh>(FormControls);
            toTrinh.NguyenLieu = SF.Get<NguyenLieuViewModel>().GetDetail((long)toTrinh.NguyenLieuId);
            ToTrinhList.Add(toTrinh);
        }
        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewToTrinh.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void gridViewToTrinh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var data = gridViewToTrinh.GetRow(gridViewToTrinh.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                Init(data);
                var nguyenLieuId = (long)data.NguyenLieuId;
                gridChiTietToTrinh.DataSource = DictChiTietToTrinh.ContainsKey(nguyenLieuId) ? DictChiTietToTrinh[nguyenLieuId] : data.ChiTietToTrinhs.ToList();
            }
        }
    }
}
