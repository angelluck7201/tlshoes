--Drop database GiayTL;
Create database GiayTL;
use GiayTL;

create table ErrorLog(
Id bigint primary key identity(1,1),
CreatedDate nvarchar(50),
AppVersion nvarchar(20),
Messagelog nvarchar(max),
);

alter table UserAccount add MatKhau text
alter table UserAccount add LoaiNguoiDung text
alter table UserAccount alter column CreatedDate bigint not null
alter table UserAccount alter column ModifiedDate bigint not null
create table UserAccount(
Id bigint primary key identity(1,1),
CreatedDate bigint not null,
ModifiedDate bigint not null,
IsActived bit,

TenNguoiDung nvarchar(50),
MatKhau text,
LoaiNguoiDung text,
);


insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'admin', '123456', 'ADMIN')
insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'phongvattu', '123456', 'PVT')
insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'phongvattu', '123456', 'PKT')
insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'truongphongvattu', '123456', 'TRUONG_PVT')
insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'phongkythuat', '123456', 'TRUONG_PKT')
insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung, MatKhau, LoaiNguoiDung) values (123,456,1, 'thukho', '123456', 'THU_KHO')

alter table DanhMuc alter column CreatedDate bigint not null
alter table DanhMuc alter column ModifiedDate bigint not null
alter table DanhMuc alter column AuthorId bigint
create table DanhMuc(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint not null,
ModifiedDate bigint not null,
IsActived bit,

Ten nvarchar(100),
Loai nvarchar(20),
GhiChu nvarchar(1000),
);

create table NguyenLieu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint not null,
ModifiedDate bigint not null,
IsActived bit,

LoaiNguyenLieuId bigint foreign key references DanhMuc(Id),
Ten nvarchar(100),
MaNguyenLieu nvarchar(50),
DonViTinh bigint foreign key references DanhMuc(Id),
MauId bigint foreign key references DanhMuc(Id),
QuyCach nvarchar(20),
DacTinh nvarchar(50),
SoLuong real,
GhiChu nvarchar(1000),
);

create table KhachHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

TenCongTy nvarchar(100),
TenNguoiDaiDien nvarchar(100),
DiaChi nvarchar(100),
Dienthoai varchar(20),
Fax nvarchar(100),
Email nvarchar(100),
MatHang nvarchar(100),
DungYeuCauKyThuat int,
DungThoiGian int,
DungMau int,
DatTestLy int,
DatTestHoa int,
Gia int,
DichVuGiaoHang int,
DichVuHauMai int,
Khac int,
GhiChuNoiBo nvarchar(1000),
GhiChu nvarchar(1000),
);



alter table DonHang add DungYeuCauKyThuat int
alter table DonHang add DungThoiGian int
alter table DonHang add DungMau int
alter table DonHang add DatTestLy int
alter table DonHang add DatTestHoa int
alter table DonHang add Gia int
alter table DonHang add DichVuGiaoHang int
alter table DonHang add DichVuHauMai int
alter table DonHang add Khac int
alter table DonHang add MuId bigint foreign key references NguyenLieu(Id)
alter table DonHang add LotId bigint foreign key references NguyenLieu(Id)
alter table DonHang add DaLotTayId bigint foreign key references NguyenLieu(Id)
alter table DonHang add DeId bigint foreign key references NguyenLieu(Id)
create table DonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MaPhomId bigint foreign key references NguyenLieu(Id),
MuId bigint foreign key references NguyenLieu(Id),
LotId bigint foreign key references NguyenLieu(Id),
DaLotTayId bigint foreign key references NguyenLieu(Id),
DeId bigint foreign key references NguyenLieu(Id),
MaHang varchar(50),
KhachHangId bigint foreign key references KhachHang(id),
OrderNo varchar(50),
NgayNhan bigint,
NgayXuat bigint,
HinhAnh text,

GopYVatTu nvarchar(1000),
GopYXuongChat nvarchar(1000),
GopYXuongMay nvarchar(1000),
GopYXuongDe nvarchar(1000),
GopYXuongGo nvarchar(1000),
GopYQc nvarchar(1000),
GopYCongNghe nvarchar(1000),
GopYMau nvarchar(1000),
GopYKhoVatTu nvarchar(1000),
GopYPhuTro nvarchar(1000),
GopYKhoThanhPham nvarchar(1000),

DungYeuCauKyThuat int,
DungThoiGian int,
DungMau int,
DatTestLy int,
DatTestHoa int,
Gia int,
DichVuGiaoHang int,
DichVuHauMai int,
Khac int,

);

create table ChiTietDonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
MauId bigint foreign key references DanhMuc(Id),
Size int,
SoLuong int,
);


create table MauDoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
HinhAnh text,
NgayNhan bigint,
MauNgay bigint,
GhiChu nvarchar(1000),

);

create table MauDoiHinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MauDoiId bigint foreign key references MauDoi(Id),
HinhAnh text,
GhiChu nvarchar(1000),
);

create table MauTest(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayGuiMau bigint,
NgayKetquaTestLy bigint,
KetQuaTestLy nvarchar(1000),
PhanLoaiTestLyId bigint foreign key references DanhMuc(Id),
NgayKetquaTestHoa bigint,
KetQuaTestHoa nvarchar(1000),
PhanLoaiTestHoaId bigint foreign key references DanhMuc(Id),

GopYCongNghe nvarchar(1000),
GopYMau nvarchar(1000),
GopYQc nvarchar(1000),
GopYKhoVatTu nvarchar(1000),
GopYVatTu nvarchar(1000),
GopYPhuTro nvarchar(1000),
GopYXuongChat nvarchar(1000),
GopYXuongMay nvarchar(1000),
GopYXuongDe nvarchar(1000),
GopYXuongGo nvarchar(1000),
);

drop table MauSanXuat
create table MauSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayGuiMau bigint,
NgayKetqua bigint,
KetQua nvarchar(1000),
PhanLoaiKetQua bigint foreign key references DanhMuc(Id),
GopYCongNghe nvarchar(1000),
GopYMau nvarchar(1000),
GopYQc nvarchar(1000),
GopYKhoVatTu nvarchar(1000),
GopYVatTu nvarchar(1000),
GopYPhuTro nvarchar(1000),
GopYXuongChat nvarchar(1000),
GopYXuongMay nvarchar(1000),
GopYXuongDe nvarchar(1000),
GopYXuongGo nvarchar(1000),
);

alter table MauThuDao add KetQuaXuongChatId bigint foreign key references DanhMuc(Id)
alter table MauThuDao add KetQuaXuongMayId bigint foreign key references DanhMuc(Id)
alter table MauThuDao add KetQuaXuongDeId bigint foreign key references DanhMuc(Id)
alter table MauThuDao add KetQuaXuongGoId bigint foreign key references DanhMuc(Id)
create table MauThuDao(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayBatDau bigint,
NgayHoanThanh bigint,
GopYCongNghe nvarchar(1000),
GopYMau nvarchar(1000),
GopYQc nvarchar(1000),
GopYKhoVatTu nvarchar(1000),
GopYVatTu nvarchar(1000),
GopYPhuTro nvarchar(1000),
GopYXuongChat nvarchar(1000),
GopYXuongMay nvarchar(1000),
GopYXuongDe nvarchar(1000),
GopYXuongGo nvarchar(1000),
KetQuaXuongChatId bigint foreign key references DanhMuc(Id),
KetQuaXuongMayId bigint foreign key references DanhMuc(Id),
KetQuaXuongDeId bigint foreign key references DanhMuc(Id),
KetQuaXuongGoId bigint foreign key references DanhMuc(Id),
);

create table CongNgheSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
MauDoiId bigint foreign key references MauDoi(Id),
PhanLoaiThuRapId bigint foreign key references DanhMuc(Id),
YKienThuRap nvarchar(1000),
PhanLoaiThuDao bigint foreign key references DanhMuc(Id),
YKienThuDao nvarchar(1000),
HinhBangThongSo text,
HinhCongNgheDuocDuyet text,
NgayDuyet bigint,
);


create table ChiLenh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
SoPhieu nvarchar(50),
TrangThai nvarchar(50),
NgayLap bigint,
NguoiLapId bigint foreign key references UserAccount(Id),
NgayDuyet bigint,
NguoiDuyetId bigint foreign key references UserAccount(Id),
);

create table NguyenLieuChiLenh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

PhanXuongId bigint foreign key references DanhMuc(Id),
ChiLenhId bigint foreign key references ChiLenh(Id),
ChiTietId bigint foreign key references DanhMuc(Id),
QuyCach nvarchar(10),
MauId bigint foreign key references DanhMuc(Id),
DinhMucChuan real,
DinhMucThuc real,
);

alter table NguyenLieuChiLenh alter column DinhMucChuan real
alter table NguyenLieuChiLenh alter column DinhMucThuc real

create table ChiTietNguyenLieu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

NguyenLieuChiLenhId bigint foreign key references NguyenLieuChiLenh(Id),
ChiTietNguyenLieuId bigint foreign key references NguyenLieu(Id),
GhiChu nvarchar(1000),
);


create table KeHoachSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayKiemHang bigint,
NgayBatDauPxChat bigint,
NgayHoanThanhPxChat bigint,
NgayBatDauToPhuTro bigint,
NgayHoanThanhToPhuTro bigint,
NgayBatDauPxMay bigint,
NgayHoanThanhPxMay bigint,
NgayBatDauPxGo bigint,
NgayHoanThanhPxGo bigint,
NgayBatDauPxDe bigint,
NgayHoanThanhPxDe bigint,
NgayBatDauBpVatTu bigint,
NgayHoanThanhBpVatTu bigint,
GhiChu nvarchar(1000),
);

create table BaoCaoPhanXuong(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
PhanXuongId bigint foreign key references DanhMuc(Id),
SanLuongKhoan int,
SanLuongThucHien int,
BaoCaoNgay bigint,
GhiChu nvarchar(1000),
)
alter table TongHopToTrinh drop constraint FK__TongHopTo__Nguoi__4A18FC72
alter table TongHopToTrinh drop column NguoiDuyet
alter table TongHopToTrinh add NguoiDuyetId bigint foreign key references UserAccount(Id)
create table TongHopToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint, 
IsActived bit,

SoPhieu nvarchar(50),
TrangThai nvarchar(20),
NguoiLapId bigint foreign key references UserAccount(Id),	
NgayLap bigint,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayDuyet bigint,
)

alter table ToTrinh add TongHopToTrinhId bigint foreign key references TongHopToTrinh(Id)
create table ToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint, 
IsActived bit,

TongHopToTrinhId bigint foreign key references TongHopToTrinh(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonDatHangList text,
BoSung real,
ThuHoi real,
TonToTrinh real,
TonTheKho real,
TonThucTe real,
DuKien real,
HaoHut real,
GhiChu nvarchar(1000),
)

create table ChiTietToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

ToTrinhId bigint foreign key references ToTrinh(Id),
DonHangId bigint foreign key references DonHang(Id),
NhuCau real,
ThucTe real,
)

alter table PhieuNhapKho add SoPhieu nvarchar(20)
alter table PhieuNhapKho add DanhGiaId bigint foreign key references DanhGia(Id)
alter table PhieuNhapKho add TrangThai nvarchar(20)

	alter table PhieuNhapKho add NgayDuyet bigint
	alter table PhieuNhapKho add NguoiDuyetId bigint foreign key references UserAccount(Id)
	alter table PhieuNhapKho add NgayLap bigint
alter table PhieuNhapKho add NguoiLapId bigint foreign key references UserAccount(Id)
create table PhieuNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

NguoiGiao nvarchar(50),
DiaChi nvarchar(100),
LyDo nvarchar(100),
Kho nvarchar(50),
NgayNhap bigint,
SoPhieu nvarchar(20),
TrangThai nvarchar(20),
DanhGiaId bigint foreign key references DanhGia(Id),
NgayDuyet bigint,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap bigint,
NguoiLapId bigint foreign key references UserAccount(Id),
)

alter table ChiTietNhapKho add IsUpdateKho bit
create table ChiTietNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

PhieuNhapKhoId bigint foreign key references PhieuNhapKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real,
IsUpdateKho bit,
)

alter table PhieuXuatKho drop constraint FK__PhieuXuat__ChiLe__3FD07829
alter table PhieuXuatKho drop column ChiLenhId
alter table PhieuXuatKho add  DonHangId bigint foreign key references DonHang(Id)
alter table PhieuXuatKho add SoPhieu nvarchar(20)
alter table PhieuXuatKho add TrangThai nvarchar(20)

alter table PhieuXuatKho add NgayDuyet bigint
alter table PhieuXuatKho add NguoiDuyetId bigint foreign key references UserAccount(Id)
alter table PhieuXuatKho add NgayLap bigint
alter table PhieuXuatKho add NguoiLapId bigint foreign key references UserAccount(Id)
create table PhieuXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NguoiNhan nvarchar(50),
DiaChi nvarchar(100),
BoPhan nvarchar(50),
LyDo nvarchar(100),
Kho nvarchar(50),
LoaiXuat nvarchar(50),
NgayXuat bigint,
SoPhieu nvarchar(20),
TrangThai nvarchar(20),
NgayDuyet bigint,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap bigint,
NguoiLapId bigint foreign key references UserAccount(Id),
)

alter table ChiTietXuatKho add IsUpdateKho bit
create table ChiTietXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

PhieuXuatKhoId bigint foreign key references PhieuXuatKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real,
IsUpdateKho bit
)

create table NhatKyXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

ChiTietXuatKhoId bigint foreign key references ChiTietXuatKho(Id),
SoLuong real,
NguoiNhan nvarchar(100),
GhiChu nvarchar(100),
)


create table NhaCungCap(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

TenCongTy nvarchar(100),
TenNguoiDaiDien nvarchar(100),
DiaChi nvarchar(100),
Dienthoai varchar(20),
Fax nvarchar(100),
Email nvarchar(100),
MatHang nvarchar(100),
DungYeuCauKyThuat int,
DungThoiGian int,
DungMau int,
DatTestLy int,
DatTestHoa int,
Gia int,
DichVuGiaoHang int,
DichVuHauMai int,
Khac int,
GhiChuNoiBo nvarchar(1000),
GhiChu nvarchar(1000),
);

create table NhaCungCapVatTu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

NhaCungCapId bigint foreign key references NhaCungCap(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonGia float,
DonVi nvarchar(10),
GiaBanTuNgay bigint, 
GiaBanDenNgay bigint,
)


alter table DonDatHang add DungYeuCauKyThuat int
alter table DonDatHang add DungThoiGian int
alter table DonDatHang add DungMau int
alter table DonDatHang add DatTestLy int
alter table DonDatHang add DatTestHoa int
alter table DonDatHang add Gia int
alter table DonDatHang add DichVuGiaoHang int
alter table DonDatHang add DichVuHauMai int
alter table DonDatHang add Khac int
alter table DonDatHang add ToTrinhId bigint foreign key references NhaCungCap(Id)

alter table DonDatHang add NgayDuyet bigint
alter table DonDatHang add NguoiDuyetId bigint foreign key references UserAccount(Id)
alter table DonDatHang add NgayLap bigint
alter table DonDatHang add NguoiLapId bigint foreign key references UserAccount(Id)
create table DonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

ToTrinhId bigint foreign key references NhaCungCap(Id),
SoDH varchar(20),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NgayDatHang bigint,
NgayGiaoHang bigint,
DungYeuCauKyThuat int,
DungThoiGian int,
DungMau int,
DatTestLy int,
DatTestHoa int,
Gia int,
DichVuGiaoHang int,
DichVuHauMai int,
Khac int,
NgayDuyet bigint,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap bigint,
NguoiLapId bigint foreign key references UserAccount(Id),
)

alter table ChiTietDonDatHang add DonGia float
create table ChiTietDonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonDatHangId bigint foreign key references DonDatHang(Id),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonGia float,
SoLuong float,
SoLuongThuc float,
GhiChu nvarchar(1000),
)

create table MauDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MauDanhGia nvarchar(100),
GhiChu nvarchar(1000),
)

create table ChiTietMauDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MauDanhGiaId bigint foreign key references MauDanhGia(Id),
TieuChiId bigint foreign key references DanhMuc(Id),
)

alter table DanhGia add SoPhieu nvarchar(20)
create table DanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonDatHangId bigint foreign key references DonDatHang(Id),
MauDanhGiaId bigint foreign key references MauDanhGia(Id),
SoPhieu nvarchar(20),
SoLuongKiem float,
BienPhapXuLy nvarchar(1000),
NgayKiem bigint,
)


create table ChiTietDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DanhGiaId bigint foreign key references DanhGia(Id),
TieuChiId bigint foreign key references DanhMuc(Id),
SoLuongKem float,
GhiChu nvarchar(1000),
)

alter table MauHuongDanDongGoi alter column GhiChu nvarchar(1000)
create table MauHuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

KhachHangId bigint foreign key references KhachHang(Id),
TenMau nvarchar(50),
ApDungTuNgay bigint,
ApDungDenNgay bigint,
GhiChu nvarchar(1000),
)

alter table ChiTietHuongDanDongGoi alter column GhiChu nvarchar(1000)
create table ChiTietHuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MauHuongDanDongGoiId bigint foreign key references MauHuongDanDongGoi(Id),
DanhMucId bigint foreign key references DanhMuc(Id),
DonViTinhId bigint foreign key references DanhMuc(Id),
KichThuoc nvarchar(50),
MauId bigint foreign key references DanhMuc(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
CachSuDung text,
ViTriSuDung nvarchar(100),
SoLuong int,
HinhMauDinhKem text,
GhiChu nvarchar(1000),

)

alter table HuongDanDongGoi alter column GhiChu nvarchar(1000)
create table HuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
MauDongGoiId bigint foreign key references MauHuongDanDongGoi(Id),
CachDong nvarchar(50),
DongAssorment text,
SoLuong int,
SoDoi int,
GhiChu nvarchar(1000),
)


 









