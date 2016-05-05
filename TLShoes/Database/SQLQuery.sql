--Drop database GiayTL;
Create database GiayTL;
use GiayTL;

create table UserAccount(
Id bigint primary key identity(1,1),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

);

insert UserAccount(CreatedDate,ModifiedDate,IsActived) values (123,456,1)
--drop table LoaiDanhMuc
--create table LoaiDanhMuc(
--Id bigint primary key identity(1,1),
--AuthorId bigint foreign key references UserAccount(Id),
--CreatedDate bigint,
--ModifiedDate bigint,
--IsActived bit,

--Ten nvarchar(100)
--);

create table DanhMuc(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

Ten nvarchar(100),
Loai nvarchar(20),
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
GhiChu nvarchar(1000),
);

create table DonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MaHang varchar(50),
KhachHangId bigint foreign key references KhachHang(id),
OrderNo varchar(50),
NgayNhan bigint,
NgayXuat bigint,
HinhAnh text,
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

create table GopYKhachHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
VatTu nvarchar(1000),
XuongChat nvarchar(1000),
XuongMay nvarchar(1000),
XuongDe nvarchar(1000),
XuongGo nvarchar(1000),
Qc nvarchar(1000),

);

create table MauDoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayNhan bigint,
MauNgay bigint,
GhiChu nvarchar(1000),

);

create table MauTest(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayKetquaTestLy bigint,
KetQuaTestLy nvarchar(1000),
PhanLoaiTestLyId bigint foreign key references DanhMuc(Id),
NgayKetquaTestHoa bigint,
KetQuaTestHoa nvarchar(1000),
PhanLoaiTestHoaId bigint foreign key references DanhMuc(Id),
GhiChu nvarchar(1000),
);

create table NguyenLieu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

LoaiNguyenLieuId bigint foreign key references DanhMuc(Id),
Ten nvarchar(100),
MaNguyenLieu nvarchar(50),
DonViTinh bigint foreign key references DanhMuc(Id),
DacTinh nvarchar(50),
SoLuong real,
GhiChu nvarchar(1000),
);

create table BangThongSo(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
MaPhomId bigint foreign key references NguyenLieu(Id),
PhanXuongId bigint foreign key references DanhMuc(Id),
NgayKy bigint,
NgayXacNhan bigint
);

create table ChiTietThongSo(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

BangThongSoId bigint foreign key references BangThongSo(Id),
ChiTietId bigint foreign key references DanhMuc(Id),
Size int,
ThongSo float
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
NgayDuyet bigint,
);

create table ChiLenh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
NgayDuyet bigint,
NguoiDuyet bigint foreign key references UserAccount(Id),
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
);

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

create table CongCuDungCu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonHangId bigint foreign key references DonHang(Id),
BangThongSoId bigint foreign key references BangThongSo(Id),
RapHoaNgay bigint,

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







