using System;
using System.Collections.Generic;
using System.Linq;


namespace TLShoes.Common
{
    public static class Define
    {
        public static List<T> ListEnum<T>() where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static List<string> ListString<T>() where T : struct, IConvertible
        {
            return ListEnum<T>().ConvertAll(s => s.ToString());
        }

        public enum LoaiDanhMuc
        {
            MAU,
            PHAN_LOAI_TEST,
            CHI_TIET,
            DON_VI_TINH,
            PHAN_XUONG,
            LOAI_NGUYEN_LIEU,
            TIEU_CHI_QC,
        }

        public enum ModelType
        {
            CHILENH,
            HUONG_DAN_DONG_GOI,
            TO_TRINH,
        }

        public static Dictionary<LoaiDanhMuc, string> LoaiDanhMucDic = new Dictionary<LoaiDanhMuc, string>()
        {
            {LoaiDanhMuc.MAU, "MÀU"},
            {LoaiDanhMuc.PHAN_LOAI_TEST, "PHÂN LOẠI TEST"},
            {LoaiDanhMuc.CHI_TIET, "CHI TIẾT"},
            {LoaiDanhMuc.DON_VI_TINH, "ĐƠN VỊ TÍNH"},
            {LoaiDanhMuc.PHAN_XUONG, "PHÂN XƯỞNG"},
            {LoaiDanhMuc.LOAI_NGUYEN_LIEU, "LOẠI NGUYÊN LIỆU"},
            {LoaiDanhMuc.TIEU_CHI_QC, "TIÊU CHÍ QC"},
        };

        public enum TienTe
        {
            VND,
            USD,
        }

        public enum TrangThai
        {
            HUY,
            MOI,
            DUYET,
            DUYET_PKT,
            DUYET_PVT,
            DUYET_NKP,
            DONE,
        }

        public enum LoaiNguoiDung
        {
            NV,
            CBDH,
            PVT,
            PKT,
            QC,
            PKH,
            THU_KHO,
            TRUONG_PKT,
            TRUONG_PVT,
            PX,
            GDKT,
            GDSX,
            ADMIN,
        }

        public static Dictionary<LoaiNguoiDung, string> LoaiNguoiDungDict = new Dictionary<LoaiNguoiDung, string>()
        {
            {LoaiNguoiDung.NV, "NHÂN VIÊN"},
            {LoaiNguoiDung.CBDH, "CÁN BỘ ĐƠN HÀNG"},
            {LoaiNguoiDung.PVT, "PHÒNG VẬT TỰ"},
            {LoaiNguoiDung.PKT, "PHÒNG KỸ THUẬT"},
            {LoaiNguoiDung.QC, "QC"},
            {LoaiNguoiDung.PKH, "PHÒNG KHOA HỌC"},
            {LoaiNguoiDung.THU_KHO, "THỦ KHO"},
            {LoaiNguoiDung.TRUONG_PKT, "TRƯỞNG PHÒNG KỸ THUẬT"},
            {LoaiNguoiDung.TRUONG_PVT, "TRƯỞNG PHÒNG VẬT TƯ"},
            {LoaiNguoiDung.PX, "PHÂN XƯỞNG"},
            {LoaiNguoiDung.GDKT, "GIÁM ĐỐC KỸ THUẬT"},
            {LoaiNguoiDung.GDSX, "GIÁM ĐỐC SẢN XUẤT"},
            {LoaiNguoiDung.ADMIN, "ADMIN"},
        };

        public enum Authorization
        {
            VIEW,
            WRITE,
            VERIFY,
        }

        public enum Kho
        {
            KHO_VAT_TU,
            KHO_THANH_PHAM,
            KHO_BAN_THANH_PHAM,
        }

        public static Dictionary<Kho, string> KhoDic = new Dictionary<Kho, string>()
        {
            {Kho.KHO_VAT_TU, "KHO VẬT TƯ"},
            {Kho.KHO_THANH_PHAM, "KHO THÀNH PHẨM"},
            {Kho.KHO_BAN_THANH_PHAM, "KHO BÁN THÀNH PHẨM"},
        };

        public enum LoaiXuat
        {
            TRONG_CHI_LENH,
            NGOAI_CHI_LENH,
        }

        public static Dictionary<LoaiXuat, string> LoaiXuatDic = new Dictionary<LoaiXuat, string>()
        {
            {LoaiXuat.TRONG_CHI_LENH, "TRONG CHỈ LỆNH"},
            {LoaiXuat.NGOAI_CHI_LENH, "NGOÀI CHỈ LỆNH"},
         };

        public enum LoaiDong
        {
            ASSORTMENT,
            SOLID
        }

        public static Dictionary<LoaiDong, string> LoaiDongDic = new Dictionary<LoaiDong, string>()
        {
            {LoaiDong.ASSORTMENT, "ASSORTMENT"},
            {LoaiDong.SOLID, "SOLID"},
         };

        public enum PhanXuong
        {
            CHAT,
            DE,
            MAY,
            GO

        }

        public static Dictionary<PhanXuong, string> PhanXuongDict = new Dictionary<PhanXuong, string>()
        {
            {PhanXuong.CHAT, "CHẶT"},
            {PhanXuong.MAY, "MAY"},
            {PhanXuong.DE, "ĐẾ"},
            {PhanXuong.GO, "GÒ"},
        };

        //        public static Dictionary<string, long> PhanXuongDict = new Dictionary<string, long>()
        //        {
        //            {"CHẶT", 50},
        //            {"ĐE", 51},
        //            {"MAY", 8},
        //            {"GÒ", 7},
        //        };

        public static Dictionary<string, long> ChiTietDict = new Dictionary<string, long>()
        {
            {"MŨ GIÀY", 11},
            {"QUAI CÀI", 12},
            {"LÓT MŨ", 13},
            {"LÓT HẬU", 26},
            {"DA LÓT TẨY", 27},
            {"ĐỆM TẨY TRÊN", 28},
            {"ĐỆM TẨY DƯỚI", 29},
            {"PHO HẬU", 30},
            {"PHO MŨI", 31},
            {"BẠT EO", 32},
            {"BẠT MÓNG NGỰA", 33},
            {"RẬP NÂNG", 35},
            {"CHỈ MAY MŨ", 36},
            {"CHỈ MAY LÓT", 37},
            {"DÂY T/C NYLON", 38},
            {"NƠ", 39},
            {"DÂY VIỀN", 40},
            {"BẠT CÀ RẼ", 41},
            {"BẠT TC HẬU", 42},
            {"XĂNG CN", 43},
            {"TẨY GIÀY", 44},
            {"ĐẾ", 45},
            {"NƯỚC CỨNG", 46},
            {"NƯỚC XỬ LÝ TPR", 47},
            {"NƯỚC XỬ LÝ MŨ", 48},
            {"TOLUEN", 49},
            {"KEO", 52},
        };

        public const string TEMPLATE_DON_DAT_HANG = "DonDatHang_template.xls";
        public const string TEMPLATE_CHI_LENH = "ChiLenh_template.xls";
        public const string TEMPLATE_TO_TRINH = "ToTrinh_template.xls";
        public const string TEMPLATE_XUAT_KHO = "XuatKho_template.xls";
        public const string TEMPLATE_NHAP_KHO = "NhapKho_template.xls";
        public const string TEMPLATE_MAU_THU = "MauThu_Template.xls";

        // 0 so chi lenh da duoc duyet trong thang
        // 1 thang
        // 2 nam
        public const string SO_PHIEU_CHI_LENH = "CL_{0}/{1}/{2}";

        public const string SO_PHIEU_TO_TRINH = "TT_{0}/{1}/{2}";


        public const string EXPORT_EXTENSION = "Excel |*.xls";


        public const string MESSAGE_EXPORT_SUCCESS_TITLE = "Export thành công!";
        public const string MESSAGE_EXPORT_SUCCESS_TEXT = "Bạn có muốn mở file vừa export";
        public const string MESSAGE_EXPORT_FAIL_TITLE = "Export thất bại!";

    }
}
