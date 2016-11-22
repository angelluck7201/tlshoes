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

namespace TLShoes.FormControls.TheKho
{
    public partial class ucTheKhoList : BaseForm
    {
        public ucTheKhoList()
        {
            InitializeComponent();
            Init();
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();

                var lstData = new List<TheKho>();
                var nhapKhoList = SF.Get<PhieuNhapKhoViewModel>().GetList();
                foreach (var phieuNhapKho in nhapKhoList)
                {
                    var theKho = new TheKho();
                    theKho.Ngay = TimeHelper.TimeStampToDateTime(phieuNhapKho.NgayNhap);
                    theKho.ChungTu = string.Format("PNK_{0}", phieuNhapKho.SoPhieu);
                    theKho.DienGiai = phieuNhapKho.LyDo;
                    theKho.Nhap = (double)phieuNhapKho.ChiTietNhapKhoes.Sum(s => s.SoLuong);
                    lstData.Add(theKho);
                }

                var xuatKhoList = SF.Get<PhieuXuatKhoViewModel>().GetList();
                foreach (var phieuXuatKho in xuatKhoList)
                {
                    var theKho = new TheKho();
                    theKho.Ngay = TimeHelper.TimeStampToDateTime(phieuXuatKho.NgayXuat);
                    theKho.ChungTu = string.Format("{0}_{1}", phieuXuatKho.LoaiXuat, phieuXuatKho.DonHang.OrderNo);
                    theKho.DienGiai = phieuXuatKho.LyDo;
                    theKho.Xuat = (double)phieuXuatKho.ChiTietXuatKhoes.Sum(s => s.SoLuong);
                    lstData.Add(theKho);
                }

                gridControl.DataSource = lstData;

                if (gridView.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }

            });

        }

        public override void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        public class TheKho
        {
            public DateTime Ngay { get; set; }
            public string ChungTu { get; set; }
            public string DienGiai { get; set; }
            public double Nhap { get; set; }
            public double Xuat { get; set; }
            public double Ton { get; set; }
        }
    }
}
