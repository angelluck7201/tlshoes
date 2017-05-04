using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class DonHangViewModel : BaseModel, IViewModel<DonHang>
    {
        public List<DonHang> GetList()
        {
            var listDonHang = DbContext.DonHangs.ToList();
            return listDonHang;
        }

        public List<DonHang> GetList(Define.TrangThai trangThai)
        {
            var sTrangThai = trangThai.ToString();
            var listDonHang = DbContext.DonHangs.Where(s => s.TrangThai == sTrangThai).ToList();
            return listDonHang;
        }

        public List<DonHang> GetListAvailable()
        {
            var trangThaiDuyet = Define.TrangThai.DUYET.ToString();
            var trangThaiDone = Define.TrangThai.DONE.ToString();

            var listDonHang = DbContext.DonHangs.Where(s => s.TrangThai != trangThaiDuyet && s.TrangThai != trangThaiDone).ToList();
            return listDonHang;
        }

        public void CheckAvailableBaseOnDonHang(long donHangId, SimpleButton disableButton, LabelControl lblMessage)
        {
            var donHang = GetDetail(donHangId);
            if (donHang != null)
            {
                if (donHang.TrangThai == Define.TrangThai.DUYET.ToString())
                {
                    disableButton.Enabled = false;
                    lblMessage.Text = Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DUYET;
                }else if (donHang.TrangThai == Define.TrangThai.DUYET.ToString())
                {
                    disableButton.Enabled = false;
                    lblMessage.Text = Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DONE;
                }
                else
                {
                    disableButton.Enabled = true;
                    lblMessage.Text = "";
                }
            }
        }

        public void CheckDoneBaseOnDonHang(long donHangId, SimpleButton disableButton, LabelControl lblMessage)
        {
            var donHang = GetDetail(donHangId);
            if (donHang != null)
            {
                if (donHang.TrangThai == Define.TrangThai.DUYET.ToString())
                {
                    disableButton.Enabled = false;
                    lblMessage.Text = Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DONE;
                }
                else
                {
                    disableButton.Enabled = true;
                    lblMessage.Text = "";
                }
            }
        }

        public DonHang GetDetail(long id)
        {
            return DbContext.DonHangs.Find(id);
        }

        public int TongDonHang(long id)
        {
            var result = 0;
            var donhang = GetDetail(id);
            if (donhang != null && donhang.ChiTietDonHangs != null)
            {
                result = (int)donhang.ChiTietDonHangs.Sum(s => s.SoLuong);
            }
            return result;
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.MaHang,
                s.OrderNo,
                s.KhachHang.TenCongTy,
                NgayNhanFormat = s.NgayNhan,
                NgayXuatFormat = s.NgayXuat,
                SoLuong = s.ChiTietDonHangs.Sum(d => d.SoLuong),
                Hinh = FileHelper.ImageFromFile(s.HinhAnh),
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void UpdateTrangThai(Define.TrangThai trangThai, long donHangId)
        {
            var donHang = GetDetail(donHangId);
            if (donHang != null)
            {
                donHang.TrangThai = trangThai.ToString();
                Save(donHang);
            }
        }

        public void Save(object data, bool isCommit = true)
        {
            DbContext.DonHangs.AddOrUpdate((DonHang)data);
            if (isCommit)
            {
                Commit();
            }
        }
    }

}


namespace TLShoes
{
    public partial class DonHang
    {
        public bool IsAvailable
        {
            get { return string.IsNullOrEmpty(TrangThai) || (TrangThai != Define.TrangThai.DUYET.ToString() && TrangThai != Define.TrangThai.DONE.ToString()); }
        }
    }

}
