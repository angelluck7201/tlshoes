﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public void GetDataSource(GridControl control)
        {
            control.DataSource = GetList().Select(s => new
            {
                s.Id,
                s.DonHang.MaHang,
                SoDH = s.DonHang.OrderNo,
                NgayNhanFormat = TimeHelper.TimeStampToDateTime(s.NgayNhan, "d"),
                MauNgayFormat = TimeHelper.TimeStampToDateTime(s.MauNgay, "d"),
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
                item.MauDoiNgayGui = TimeHelper.TimeStampToDateTime(maudoi.NgayNhan, "d");
                item.MauDoiNgayXacNhan = TimeHelper.TimeStampToDateTime(maudoi.MauNgay, "d");
                item.Hinh = FileHelper.ImageFromFile(maudoi.DonHang.HinhAnh);

                var mauTestList = SF.Get<MauTestViewModel>().GetList((long)maudoi.DonHangId).Take(3);
                foreach (var mauTest in mauTestList)
                {
                    var ketQuaTestly = mauTest.DanhMuc.Ten;
                    if (string.IsNullOrEmpty(item.TestLy))
                    {
                        item.TestLy = ketQuaTestly;
                    }
                    else if (item.TestLy != ketQuaTestly)
                    {
                        item.TestLy += "/" + ketQuaTestly;
                    }

                    var ketQuaTestHoa = mauTest.DanhMuc1.Ten;
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
                    item.MauThuDaoBatDau = TimeHelper.TimeStampToDateTime(mauThuDao.OrderBy(s => s.NgayBatDau).First().NgayBatDau, "d");
                    item.MauThuDaoHoanThanh = TimeHelper.TimeStampToDateTime(mauThuDao.OrderByDescending(s => s.NgayHoanThanh).First().NgayHoanThanh, "d");
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

        public void SaveHinh(List<MauDoiHinh> listHinh, long mauDoiId)
        {
            foreach (var hinh in listHinh)
            {
                hinh.MauDoiId = mauDoiId;
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
