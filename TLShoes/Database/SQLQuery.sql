--Drop database GiayTL;
Create database GiayTL;
use GiayTL;

create table ErrorLog(
Id bigint primary key identity(1,1),
CreatedDate nvarchar(50),
AppVersion nvarchar(20),
Messagelog nvarchar(max),
);


create table UserAccount(
Id bigint primary key identity(1,1),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

TenNguoiDung nvarchar(50),

);

insert UserAccount(CreatedDate,ModifiedDate,IsActived,TenNguoiDung) values (123,456,1, 'Long')
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




create table DonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

MaPhomId bigint foreign key references NguyenLieu(Id),
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

--create table GopYKhachHang(
--Id bigint primary key identity(1,1),
--AuthorId bigint foreign key references UserAccount(Id),
--CreatedDate bigint,
--ModifiedDate bigint,
--IsActived bit,

--DonHangId bigint foreign key references DonHang(Id),
--VatTu nvarchar(1000),
--XuongChat nvarchar(1000),
--XuongMay nvarchar(1000),
--XuongDe nvarchar(1000),
--XuongGo nvarchar(1000),
--Qc nvarchar(1000),

--);

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

drop table MauTest
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

drop table MauThuDao
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
);

--create table BangThongSo(
--Id bigint primary key identity(1,1),
--AuthorId bigint foreign key references UserAccount(Id),
--CreatedDate bigint,
--ModifiedDate bigint,
--IsActived bit,

--DonHangId bigint foreign key references DonHang(Id),
--MaPhomId bigint foreign key references NguyenLieu(Id),
--PhanXuongId bigint foreign key references DanhMuc(Id),
--NgayKy bigint,
--NgayXacNhan bigint
--);

--create table ChiTietThongSo(
--Id bigint primary key identity(1,1),
--AuthorId bigint foreign key references UserAccount(Id),
--CreatedDate bigint,
--ModifiedDate bigint,
--IsActived bit,

--BangThongSoId bigint foreign key references BangThongSo(Id),
--ChiTietId bigint foreign key references DanhMuc(Id),
--Size int,
--ThongSo float
--);

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
DinhMucChuan real,
DinhMucThuc real,
);

alter table NguyenLieuChiLenh alter column DinhMucChuan real
alter table NguyenLieuChiLenh alter column DinhMucThuc real
--alter table NguyenLieuChiLenh
--add DinhMucChuan int
--alter table NguyenLieuChiLenh
--add DinhMucThuc int

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

--create table CongCuDungCu(
--Id bigint primary key identity(1,1),
--AuthorId bigint foreign key references UserAccount(Id),
--CreatedDate bigint,
--ModifiedDate bigint,
--IsActived bit,

--DonHangId bigint foreign key references DonHang(Id),
--BangThongSoId bigint foreign key references BangThongSo(Id),
--RapHoaNgay bigint,

--GhiChu nvarchar(1000),
--);


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
	
create table ToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

NguyenLieuId bigint foreign key references NguyenLieu(Id),
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


create table PhieuNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),nh
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

NguoiGiao nvarchar(50),
DiaChi nvarchar(100),
LyDo nvarchar(100),
Kho nvarchar(50),
NgayNhap bigint,
)


create table ChiTietNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

PhieuNhapKhoId bigint foreign key references PhieuNhapKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real,
)


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
)

create table ChiTietXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

PhieuXuatKhoId bigint foreign key references PhieuXuatKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real,
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


alter table DonDatHang add SoDH varchar(20)
create table DonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

SoDH varchar(20),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NgayDatHang bigint,
NgayGiaoHang bigint,
)

create table ChiTietDonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonDatHangId bigint foreign key references DonDatHang(Id),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
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


create table DanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate bigint,
ModifiedDate bigint,
IsActived bit,

DonDatHangId bigint foreign key references DonDatHang(Id),
MauDanhGiaId bigint foreign key references MauDanhGia(Id),
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









