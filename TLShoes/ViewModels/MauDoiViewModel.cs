using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using DevExpress.XtraGrid;
using TLShoes.Common;

namespace TLShoes.ViewModels
{
    public class MauDoiViewModel : BaseModel, IViewModel<MauDoi>
    {
        public List<MauDoi> GetList()
        {
            return DbContext.MauDois.ToList();
        }

        public List<MauDoi> GetList(long donHangId)
        {
            return DbContext.MauDois.Where(s => s.DonHangId == donHangId).ToList();
        }

        public List<MauDoiHinh> GetHinhMauDoi(long mauDoiId)
        {
            return DbContext.MauDoiHinhs.Where(s => s.MauDoiId == mauDoiId).ToList();
        }

        public MauDoi GetDetail(long id)
        {
            return DbContext.MauDois.Find(id);
        }

        public void Delete(MauDoiHinh mauDoiHinh)
        {
            FileHelper.DeleteImage(mauDoiHinh.HinhAnh);
            DbContext.MauDoiHinhs.Remove(mauDoiHinh);
            DbContext.SaveChanges();
        }

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.DonHang.MaHang,
                SoDH = s.DonHang.OrderNo,
                //                NgayNhanFormat = TimeHelper.TimeStampToDateTime(s.NgayNhan, "d"),
                //                MauNgayFormat = TimeHelper.TimeStampToDateTime(s.MauNgay, "d"),
                Hinh = FileHelper.ImageFromFile(s.HinhAnh),
                s.UserAccount.LoaiNguoiDung
            }).ToList();
        }

        public void GetDataSummarySource(GridControl control)
        {
            var listResult = new List<SummaryTest>();
            foreach (var maudoi in GetList())
            {
                var item = new SummaryTest();
                item.Id = (long)maudoi.DonHangId;
                item.MaHang = maudoi.DonHang.MaHang;
                item.SoDonHang = maudoi.DonHang.OrderNo;
                item.SoLuong = maudoi.DonHang.ChiTietDonHangs.Sum(s => (int)s.SoLuong);
                item.MauDoiNgayGui = maudoi.NgayNhan;
                item.MauDoiNgayXacNhan = maudoi.MauNgay;
                item.Hinh = FileHelper.ImageFromFile(maudoi.DonHang.HinhAnh);

                var mauTestList = SF.Get<MauTestViewModel>().GetList((long)maudoi.DonHangId).Take(3);
                foreach (var mauTest in mauTestList)
                {
                    var ketQuaTestly = mauTest.PhanLoaiTestLy.Ten;
                    if (string.IsNullOrEmpty(item.TestLy))
                    {
                        item.TestLy = ketQuaTestly;
                    }
                    else if (item.TestLy != ketQuaTestly)
                    {
                        item.TestLy += "/" + ketQuaTestly;
                    }

                    var ketQuaTestHoa = mauTest.PhanLoaiTestHoa.Ten;
                    if (string.IsNullOrEmpty(item.TestHoa))
                    {
                        item.TestHoa = ketQuaTestHoa;
                    }
                    else if (item.TestHoa != ketQuaTestHoa)
                    {
                        item.TestHoa += "/" + ketQuaTestHoa;
                    }
                }

                var mauSanXuatList = SF.Get<MauSanXuatViewModel>().GetList((long)maudoi.DonHangId);
                foreach (var mauSanXuat in mauSanXuatList)
                {
                    if (string.IsNullOrEmpty(item.MauSanXuat))
                    {
                        item.MauSanXuat = mauSanXuat.DanhMuc.Ten;
                    }
                    else
                    {
                        item.MauSanXuat += "/" + mauSanXuat.DanhMuc.Ten;
                    }
                }


                var mauThuDao = SF.Get<MauThuDaoViewModel>().GetList((long)maudoi.DonHangId);
                if (mauThuDao.Any())
                {
                    item.MauThuDaoBatDau = mauThuDao.OrderBy(s => s.NgayBatDau).First().NgayBatDau;
                    item.MauThuDaoHoanThanh = mauThuDao.OrderByDescending(s => s.NgayHoanThanh).First().NgayHoanThanh;
                }

                listResult.Add(item);
            }
            control.DataSource = listResult;
        }

        public void Save(object data)
        {
            dynamic dynamicData = data;
            if (dynamicData.Id == 0)
            {
                DbContext.MauDois.Add((MauDoi)data);
            }
            else
            {
                DbContext.MauDois.AddOrUpdate((MauDoi)data);
            }
            DbContext.SaveChanges();
        }

        public void SaveHinh(MauDoi mauDoi, List<MauDoiHinh> listHinh, long mauDoiId)
        {
            // Clear hình cũ 
            if (mauDoi.MauDoiHinhs != null)
            {
                foreach (var source in mauDoi.MauDoiHinhs.ToList())
                {
                    if (listHinh.All(s => s.Id != source.Id))
                    {
                        Delete(source);
                    }
                }
            }

            foreach (var hinh in listHinh)
            {
                hinh.MauDoiId = mauDoiId;
                if (hinh.Hinh != null)
                {
                    hinh.HinhAnh = FileHelper.ImageSave(hinh.Hinh as Image, hinh.HinhAnh);
                }
                DbContext.MauDoiHinhs.AddOrUpdate(hinh);
            }
            DbContext.SaveChanges();
        }

        public class SummaryTest
        {
            public long Id { get; set; }
            public string MaHang { get; set; }
            public object Hinh { get; set; }
            public string SoDonHang { get; set; }
            public int SoLuong { get; set; }
            public DateTime MauDoiNgayGui { get; set; }
            public DateTime MauDoiNgayXacNhan { get; set; }
            public string TestLy { get; set; }
            public string TestHoa { get; set; }
            public string MauSanXuat { get; set; }
            public DateTime MauThuDaoBatDau { get; set; }
            public DateTime MauThuDaoHoanThanh { get; set; }
        }
    }
}

namespace TLShoes
{
    public partial class MauDoiHinh
    {
        private object _hinh;
        public object Hinh
        {
            get
            {
                if (_hinh == null)
                {
                    _hinh = FileHelper.ImageFromFile(HinhAnh);
                }
                return _hinh;
            }
            set { _hinh = value; }
        }
    }

}
