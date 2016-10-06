using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public class Authorization
    {
        public static UserAccount LoginUser;

        public static Dictionary<Type, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>> AuthentDict = new Dictionary<Type, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>>()
        {
            {typeof(BaoCaoPhanXuong), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(ChiLenh), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(CongNgheSanXuat), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DanhGia), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DanhMuc), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DonDatHang), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DonHang), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(HuongDanDongGoi), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(KeHoachSanXuat), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(KhachHang), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauDanhGia), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauDoi), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauHuongDanDongGoi), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauSanXuat), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauTest), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauThuDao), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(NguyenLieu), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(NhaCungCap), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(PhieuXuatKho), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(PhieuNhapKho), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(ToTrinh), new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT}},
            }},
        };

        public static bool CheckLogin(string userName, string passWord)
        {
            LoginUser = BaseModel.DbContext.UserAccounts.ToList().FirstOrDefault(s => s.TenNguoiDung.ToUpper().Equals(userName.ToUpper()) && s.MatKhau.Equals(passWord));
            return LoginUser != null;
        }

        /// <summary>
        /// Check authorization of user
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        public static bool CheckAuthorization<T>(Define.Authorization auth)
        {
            var loaiNguoiDung = PrimitiveConvert.StringToEnum<Define.LoaiNguoiDung>(LoginUser.LoaiNguoiDung);
            if (loaiNguoiDung != Define.LoaiNguoiDung.ADMIN)
            {
                if (AuthentDict.ContainsKey(typeof(T)))
                {
                    return AuthentDict[typeof(T)][auth].Contains(loaiNguoiDung);
                }
                return false;
            }
            return true;
        }
    }
}
