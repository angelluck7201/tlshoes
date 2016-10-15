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

        public static Dictionary<string, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>> AuthentDict = new Dictionary<string, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>>()
        {
            {typeof(BaoCaoPhanXuong).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(ChiLenh).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(CongNgheSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DanhGia).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DanhMuc).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DonDatHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(DonHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(HuongDanDongGoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(KeHoachSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(KhachHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauDanhGia).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauDoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauHuongDanDongGoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauTest).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(MauThuDao).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(NguyenLieu).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(NhaCungCap).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(PhieuXuatKho).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(PhieuNhapKho).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(ToTrinh).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT}},
            }},

            {"TongHopBaoCao", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT}},
            }},

            {"TongHopNguyenLieu", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT}},
            }},

            {"TongHopMauTest", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
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
        public static bool CheckAuthorization(string modelName, Define.Authorization auth)
        {
            var loaiNguoiDung = PrimitiveConvert.StringToEnum<Define.LoaiNguoiDung>(LoginUser.LoaiNguoiDung);
            if (loaiNguoiDung != Define.LoaiNguoiDung.ADMIN)
            {
                if (AuthentDict.ContainsKey(modelName))
                {
                    return AuthentDict[modelName][auth].Contains(loaiNguoiDung);
                }
                return false;
            }
            return true;
        }
    }
}
