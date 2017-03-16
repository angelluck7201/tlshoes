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

        public static Dictionary<string, string> LoaiDanhMucDic = new Dictionary<string, string>()
        {
            {LoaiDanhMuc.MAU.ToString(), "MÀU"},
            {LoaiDanhMuc.PHAN_LOAI_TEST.ToString(), "PHÂN LOẠI TEST"},
            {LoaiDanhMuc.CHI_TIET.ToString(), "CHI TIẾT"},
            {LoaiDanhMuc.DON_VI_TINH.ToString(), "ĐƠN VỊ TÍNH"},
            {LoaiDanhMuc.PHAN_XUONG.ToString(), "PHÂN XƯỞNG"},
            {LoaiDanhMuc.LOAI_NGUYEN_LIEU.ToString(), "LOẠI NGUYÊN LIỆU"},
            {LoaiDanhMuc.TIEU_CHI_QC.ToString(), "TIÊU CHÍ QC"},
        };

        public enum TienTe
        {
            VND,
            USD,
        }

        public enum TrangThai
        {
            MOI,
            HUY,
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
            {LoaiNguoiDung.PKH, "PHÒNG KẾ HOẠCH"},
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

        public enum ConfigType
        {
            FILE_PATH,
            LASTEST_VERSION,
            UPDATE_PATH,
        }

        public enum ActionType
        {
            SAVE,
            CLOSE,
            REFRESH,
            EXPORT
        }

        public static Dictionary<string, string> PhanXuongDict = new Dictionary<string, string>()
        {
            {PhanXuong.CHAT.ToString(), "CHẶT"},
            {PhanXuong.MAY.ToString(), "MAY"},
            {PhanXuong.DE.ToString(), "ĐẾ"},
            {PhanXuong.GO.ToString(), "GÒ"},
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

        public const string SO_PHIEU_DON_DAT_HANG = "DDH_{0}/{1}/{2}";

        public const string SO_PHIEU_NHAP_KHO_VT = "KVT_{0}/{1}/{2}";
        public const string SO_PHIEU_NHAP_KHO_TP = "KTP_{0}/{1}/{2}";
        public const string SO_PHIEU_NHAP_KHO_BTP = "KBTP_{0}/{1}/{2}";

        public const string SO_PHIEU_NHAP_KHO_VT_UPDATE = "KVT_{0}";
        public const string SO_PHIEU_NHAP_KHO_TP_UPDATE = "KTP_{0}";
        public const string SO_PHIEU_NHAP_KHO_BTP_UPDATE = "KBTP_{0}";


        public const string SO_PHIEU_XUAT_KHO = "PXK_{0}/{1}/{2}";
        public const string EXPORT_EXTENSION = "Excel |*.xls";


        public const string MESSAGE_EXPORT_SUCCESS_TITLE = "Export thành công!";
        public const string MESSAGE_EXPORT_SUCCESS_TEXT = "Bạn có muốn mở file vừa export";
        public const string MESSAGE_EXPORT_FAIL_TITLE = "Export thất bại!";
        public const string MESSAGE_EXPORT_FAIL_TEXT = "Đã xảy ra lỗi trong quá trình export!";


    }
}
