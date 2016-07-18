using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinh : BaseUserControl
    {
        private TLShoes.ToTrinh currentToTrinh = null;
        public ucToTrinh(TLShoes.ToTrinh data = null)
        {
            InitializeComponent();
            ToTrinh_NguyenLieuId.DataSource = new BindingSource(SF.Get<NguyenLieuViewModel>().GetList(), null);
            ToTrinh_NguyenLieuId.DisplayMember = "Ten";
            ToTrinh_NguyenLieuId.ValueMember = "Id";

            Init(data);
            currentToTrinh = data;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            // Save Don hang
            var saveData = CRUD.GetFormObject<TLShoes.ToTrinh>(FormControls);
            SF.Get<ToTrinhViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void ToTrinh_NguyenLieuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nguyenLieuObj = ToTrinh_NguyenLieuId.SelectedValue;
            if (nguyenLieuObj != null)
            {
                var nguyenLieuId = (long)nguyenLieuObj;
                var listChiTietToTrinh = new List<ChiTietToTrinh>();
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

                var thuHoi = tongXuatKho - tongNhapKho + thuHoiOldToTrinh;
                var tonToTrinh = oldToTrinh.Sum(s => s.TonThucTe);
                var xuatKhoBoSung = xuatKhoList.Where(s => s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.NGOAI_CHI_LENH.ToString()).Sum(s => s.SoLuong);
                var tonTheKho = tongNhapKho - tongXuatKho;
                var tongXuatKhoHaoHut = tongXuatKho * (1 + PrimitiveConvert.StringToFloat(ToTrinh_HaoHut));
                var luyKe = tonToTrinh + thuHoi - tongXuatKhoHaoHut;

                ToTrinh_BoSung.Text = xuatKhoBoSung.ToString();
                ToTrinh_ThuHoi.Text = thuHoi.ToString();
                ToTrinh_TonTheKho.Text = tonTheKho.ToString();
                ToTrinh_DuKien.Text = "0";
                if (luyKe < 0)
                {
                    ToTrinh_DuKien.Text = (-luyKe).ToString();
                }

                foreach (var chilenh in chiLenhList)
                {
                    var chitiet = new ChiTietToTrinh();
                    chitiet.DonHangId = chilenh.Key.Id;
                    chitiet.DonHang = chilenh.Key;
                    chitiet.NhuCau = chilenh.Sum(s => s.NguyenLieuChiLenh.DinhMucThuc);
                    chitiet.ThucTe = xuatKhoList
                        .Where(s => s.PhieuXuatKho.DonHang.Id == chitiet.DonHangId
                                 && s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.TRONG_CHI_LENH.ToString())
                        .Sum(s => s.SoLuong);
                    listChiTietToTrinh.Add(chitiet);
                }

                gridChiTietToTrinh.DataSource = listChiTietToTrinh.Select(s => new { s.DonHang.MaHang, s.NhuCau, s.ThucTe });

            }
        }
    }
}
