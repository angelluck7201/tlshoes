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
            HUONG_DAN_DONG_GOI
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
    }
}
