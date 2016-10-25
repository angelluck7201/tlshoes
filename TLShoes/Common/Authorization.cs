using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLShoes.FormControls.TheKho;
using TLShoes.ViewModels;

namespace TLShoes.Common
{
    public class Authorization
    {
        public static UserAccount LoginUser;

        public static Dictionary<string, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>> AuthentDict = new Dictionary<string, Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>>()
        {
            {typeof(DanhMuc).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(KhachHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(DonHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDKT,Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(CongNgheSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDKT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDKT}},
            }},

            {typeof(BaoCaoPhanXuong).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.CBDH ,Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDKT,Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(KeHoachSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDKT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDKT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.GDSX}},
            }},

            {"TongHopBaoCao", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{}},
            }},

            {typeof(ChiLenh).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
            }},

            {typeof(MauHuongDanDongGoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(HuongDanDongGoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(MauDoi).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
            }},

            {typeof(MauTest).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},            
            }},

            {typeof(MauSanXuat).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},            
            }},

            {typeof(MauThuDao).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDKT}},            
            }},

            {"TongHopMauTest", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{}},
            }},

            {typeof(NguyenLieu).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>()},
            }},

            {typeof(ToTrinh).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(NhaCungCap).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(DonDatHang).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(MauDanhGia).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.QC, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDSX, Define.LoaiNguoiDung.GDKT}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(DanhGia).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.QC, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(PhieuNhapKho).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {typeof(PhieuXuatKho).Name, new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.PVT,Define.LoaiNguoiDung.QC, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.CBDH, Define.LoaiNguoiDung.PVT,Define.LoaiNguoiDung.QC, Define.LoaiNguoiDung.PKT, Define.LoaiNguoiDung.PKH, Define.LoaiNguoiDung.THU_KHO, Define.LoaiNguoiDung.TRUONG_PKT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.PX, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PKT,Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
            }},

            {"TheKho", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.NV}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{}},
            }},

            {"TongHopNguyenLieu", new Dictionary<Define.Authorization, List<Define.LoaiNguoiDung>>
            {
                {Define.Authorization.VIEW, new List<Define.LoaiNguoiDung> {Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.WRITE, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.PVT, Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
                {Define.Authorization.VERIFY, new List<Define.LoaiNguoiDung>{Define.LoaiNguoiDung.TRUONG_PVT, Define.LoaiNguoiDung.GDSX}},
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
