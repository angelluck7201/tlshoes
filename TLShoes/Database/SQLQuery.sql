--Drop database GiayTL;
--Create database GiayTL;
--use GiayTL;

create table AppConfig(
Id bigint primary key identity(1,1),
ConfigName nvarchar(100) default '' not null,
ConfigParam text default '' not null, 
);

insert AppConfig(ConfigName, ConfigParam) values('FILE_PATH','\\LONGNGUYEN\Users\nguye\Desktop\Share Folder\image\'); 
insert AppConfig(ConfigName, ConfigParam) values('LASTEST_VERSION','1'); 
insert AppConfig(ConfigName, ConfigParam) values('UPDATE_PATH','\\LONGNGUYEN\Users\nguye\Desktop\Share Folder\update\'); 


create table ErrorLog(
Id bigint primary key identity(1,1),
CreatedDate datetime2 default getdate() not null,
AppVersion nvarchar(20) default '' not null,
Messagelog nvarchar(max) default '' not null,
);

create table UserAccount(
Id bigint primary key identity(1,1),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

TenNguoiDung nvarchar(50) default '',
MatKhau text default '' not null,
LoaiNguoiDung text default '' not null,
TenNhanVien nvarchar(100) default '',
DiaChi nvarchar(100) default '',
CMND varchar(20) default '',
Dienthoai varchar(20) default '',
GhiChu nvarchar(1000) default '',
);

create table PhanQuyenNguoiDung(
Id bigint primary key identity(1,1),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

LoaiNguoiDung text default '' not null,
Feature nvarchar(50) default '' not null,
Permission nvarchar (50) default 'VIEW' not null,
)

insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('NV', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('CBDH', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('PVT', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('PKT', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('QC', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('PKH', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('THU_KHO', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('TRUONG_PKT', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('TRUONG_PVT', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('PX', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('GDKT', 'DanhMuc', 'VIEW')
insert PhanQuyenNguoiDung(LoaiNguoiDung, Feature, Permission) values ('GDSX', 'DanhMuc', 'VIEW')


insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('admin', '123456', 'ADMIN')
insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('phongvattu', '123456', 'PVT')
insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('phongvattu', '123456', 'PKT')
insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('truongphongvattu', '123456', 'TRUONG_PVT')
insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('phongkythuat', '123456', 'TRUONG_PKT')
insert UserAccount(TenNguoiDung, MatKhau, LoaiNguoiDung) values ('thukho', '123456', 'THU_KHO')

create table DanhMuc(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

Ten nvarchar(100) default '' not null,
Loai nvarchar(20) default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table NguyenLieu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

LoaiNguyenLieuId bigint foreign key references DanhMuc(Id),
Ten nvarchar(100) default '' not null,
MaNguyenLieu nvarchar(50) default '' not null,
DonViTinh bigint foreign key references DanhMuc(Id),
MauId bigint foreign key references DanhMuc(Id),
QuyCach nvarchar(100) default '' not null,
DacTinh nvarchar(50) default '' not null,
SoLuong real default 0 not null,
GhiChu nvarchar(1000) default '' not null,
);

create table KhachHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

TenCongTy nvarchar(100) default '' not null,
TenNguoiDaiDien nvarchar(100) default '' not null,
DiaChi nvarchar(100) default '' not null,
Dienthoai varchar(20),
Fax nvarchar(100) default '' not null,
Email nvarchar(100) default '' not null,
MatHang nvarchar(100) default '' not null,
DungYeuCauKyThuat int default 0 not null,
DungThoiGian int default 0 not null,
DungMau int default 0 not null,
DatTestLy int default 0 not null,
DatTestHoa int default 0 not null,
Gia int default 0 not null,
DichVuGiaoHang int default 0 not null,
DichVuHauMai int default 0 not null,
Khac int default 0 not null,
GhiChuNoiBo nvarchar(1000) default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table DonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

MaPhomId bigint foreign key references NguyenLieu(Id),
MuId bigint foreign key references NguyenLieu(Id),
LotId bigint foreign key references NguyenLieu(Id),
DaLotTayId bigint foreign key references NguyenLieu(Id),
DeId bigint foreign key references NguyenLieu(Id),
MaHang varchar(50) default '' not null,
KhachHangId bigint foreign key references KhachHang(id),
OrderNo varchar(50) default '' not null,
NgayNhan bigint default 0 not null,
NgayXuat bigint default 0 not null,
HinhAnh text default '' not null,

GopYVatTu nvarchar(1000) default '' not null,
GopYXuongChat nvarchar(1000) default '' not null,
GopYXuongMay nvarchar(1000) default '' not null,
GopYXuongDe nvarchar(1000) default '' not null,
GopYXuongGo nvarchar(1000) default '' not null,
GopYQc nvarchar(1000) default '' not null,
GopYCongNghe nvarchar(1000) default '' not null,
GopYMau nvarchar(1000) default '' not null,
GopYKhoVatTu nvarchar(1000) default '' not null,
GopYPhuTro nvarchar(1000) default '' not null,
GopYKhoThanhPham nvarchar(1000) default '' not null,

DungYeuCauKyThuat int default 0 not null,
DungThoiGian int default 0 not null,
DungMau int default 0 not null,
DatTestLy int default 0 not null,
DatTestHoa int default 0 not null,
Gia int default 0 not null,
DichVuGiaoHang int default 0 not null,
DichVuHauMai int default 0 not null,
Khac int default 0 not null,
);

create table ChiTietDonHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
MauId bigint foreign key references DanhMuc(Id),
Size int default 0 not null,
SoLuong int default 0 not null,
);


create table MauDoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
HinhAnh text default '' not null,
NgayNhan bigint default 0 not null,
MauNgay bigint default 0 not null,
GhiChu nvarchar(1000) default '' not null,
);

create table MauDoiHinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

MauDoiId bigint foreign key references MauDoi(Id),
HinhAnh text default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table MauTest(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
NgayGuiMau bigint default 0 not null,
NgayKetquaTestLy bigint default 0 not null,
KetQuaTestLy nvarchar(1000) default '' not null,
PhanLoaiTestLyId bigint foreign key references DanhMuc(Id),
NgayKetquaTestHoa bigint default 0 not null,
KetQuaTestHoa nvarchar(1000) default '' not null,
PhanLoaiTestHoaId bigint foreign key references DanhMuc(Id),

GopYCongNghe nvarchar(1000) default '' not null,
GopYMau nvarchar(1000) default '' not null,
GopYQc nvarchar(1000) default '' not null,
GopYKhoVatTu nvarchar(1000) default '' not null,
GopYVatTu nvarchar(1000) default '' not null,
GopYPhuTro nvarchar(1000) default '' not null,
GopYXuongChat nvarchar(1000) default '' not null,
GopYXuongMay nvarchar(1000) default '' not null,
GopYXuongDe nvarchar(1000) default '' not null,
GopYXuongGo nvarchar(1000) default '' not null,
);

create table MauSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
NgayGuiMau bigint default 0 not null,
NgayKetqua bigint default 0 not null,
KetQua nvarchar(1000) default '' not null,
PhanLoaiKetQua bigint foreign key references DanhMuc(Id),
GopYCongNghe nvarchar(1000) default '' not null,
GopYMau nvarchar(1000) default '' not null,
GopYQc nvarchar(1000) default '' not null,
GopYKhoVatTu nvarchar(1000) default '' not null,
GopYVatTu nvarchar(1000) default '' not null,
GopYPhuTro nvarchar(1000) default '' not null,
GopYXuongChat nvarchar(1000) default '' not null,
GopYXuongMay nvarchar(1000) default '' not null,
GopYXuongDe nvarchar(1000) default '' not null,
GopYXuongGo nvarchar(1000) default '' not null,
);


create table MauThuDao(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
NgayBatDau datetime2 default getdate() not null,
NgayHoanThanh datetime2 default getdate() not null,
GopYCongNghe nvarchar(1000) default '' not null,
GopYMau nvarchar(1000) default '' not null,
GopYQc nvarchar(1000) default '' not null,
GopYKhoVatTu nvarchar(1000) default '' not null,
GopYVatTu nvarchar(1000) default '' not null,
GopYPhuTro nvarchar(1000) default '' not null,
GopYXuongChat nvarchar(1000) default '' not null,
GopYXuongMay nvarchar(1000) default '' not null,
GopYXuongDe nvarchar(1000) default '' not null,
GopYXuongGo nvarchar(1000) default '' not null,
KetQuaXuongChat nvarchar(20) default '' not null,
KetQuaXuongMay nvarchar(20) default '' not null,
KetQuaXuongDe nvarchar(20) default '' not null,
KetQuaXuongGo nvarchar(20) default '' not null,
);

create table CongNgheSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
MauDoiId bigint foreign key references MauDoi(Id),
PhanLoaiThuRap nvarchar(20) default '' not null,
YKienThuRap nvarchar(1000) default '' not null,
PhanLoaiThuDao nvarchar(20) default '' not null,
YKienThuDao nvarchar(1000) default '' not null,
HinhBangThongSo text default '' not null,
HinhCongNgheDuocDuyet text default '' not null,
NgayDuyet datetime2 default getdate() not null,
);

create table ChiLenh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
SoPhieu nvarchar(50) default '' not null,
TrangThai nvarchar(50) default '' not null,
NgayLap datetime2 default getdate() not null,
NguoiLapId bigint foreign key references UserAccount(Id),
NgayDuyet datetime2 default getdate() not null,
NguoiDuyetId bigint foreign key references UserAccount(Id),
);

create table NguyenLieuChiLenh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

PhanXuongId bigint foreign key references DanhMuc(Id),
ChiLenhId bigint foreign key references ChiLenh(Id),
ChiTietId bigint foreign key references DanhMuc(Id),
QuyCach nvarchar(10) default '' not null,
MauId bigint foreign key references DanhMuc(Id),
DinhMucChuan real default 0 not null,
DinhMucThuc real default 0 not null,
);

create table ChiTietNguyenLieu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

NguyenLieuChiLenhId bigint foreign key references NguyenLieuChiLenh(Id),
ChiTietNguyenLieuId bigint foreign key references NguyenLieu(Id),
GhiChu nvarchar(1000) default '' not null,
);

create table KeHoachSanXuat(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
NgayKiemHang datetime2 default getdate() not null,
NgayBatDauPxChat datetime2 default getdate() not null,
NgayHoanThanhPxChat datetime2 default getdate() not null,
NgayBatDauToPhuTro datetime2 default getdate() not null,
NgayHoanThanhToPhuTro datetime2 default getdate() not null,
NgayBatDauPxMay datetime2 default getdate() not null,
NgayHoanThanhPxMay datetime2 default getdate() not null,
NgayBatDauPxGo datetime2 default getdate() not null,
NgayHoanThanhPxGo datetime2 default getdate() not null,
NgayBatDauPxDe datetime2 default getdate() not null,
NgayHoanThanhPxDe datetime2 default getdate() not null,
NgayBatDauBpVatTu datetime2 default getdate() not null,
NgayHoanThanhBpVatTu datetime2 default getdate() not null,
GhiChu nvarchar(1000) default '' not null,
);

create table BaoCaoPhanXuong(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
PhanXuong nvarchar(50) default '' not null,
SanLuongKhoan int default 0 not null,
SanLuongThucHien int default 0 not null,
BaoCaoNgay datetime2 default getdate() not null,
GhiChu nvarchar(1000) default '' not null,
);

create table TongHopToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null, 
IsActived bit default 1 not null,

SoPhieu nvarchar(50) default '' not null,
TrangThai nvarchar(100) default '' not null,
NguoiLapId bigint foreign key references UserAccount(Id),	
NgayLap datetime2 default getdate() not null,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayDuyet datetime2 default getdate() not null,
);

create table ToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null, 
IsActived bit default 1 not null,

TongHopToTrinhId bigint foreign key references TongHopToTrinh(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonDatHangList text default '' not null,
BoSung real default 0 not null,
ThuHoi real default 0 not null,
TonToTrinh real default 0 not null,
TonTheKho real default 0 not null,
TonThucTe real default 0 not null,
DuKien real default 0 not null,
HaoHut real default 0 not null,
GhiChu nvarchar(1000) default '' not null,
);

create table ChiTietToTrinh(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

ToTrinhId bigint foreign key references ToTrinh(Id),
DonHangId bigint foreign key references DonHang(Id),
NhuCau real default 0 not null,
ThucTe real default 0 not null,
);

create table PhieuNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

NguoiGiao nvarchar(50) default '' not null,
DiaChi nvarchar(100) default '' not null,
LyDo nvarchar(100) default '' not null,
Kho nvarchar(50) default '' not null,
NgayNhap datetime2 default getdate() not null,
SoPhieu nvarchar(100) default '' not null,
TrangThai nvarchar(100) default '' not null,
DanhGiaId bigint foreign key references DanhGia(Id),
NgayDuyet datetime2 default getdate() not null,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap datetime2 default getdate() not null,
NguoiLapId bigint foreign key references UserAccount(Id),
);

create table ChiTietNhapKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

PhieuNhapKhoId bigint foreign key references PhieuNhapKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real default 0 not null,
);

create table PhieuXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
NguoiNhan nvarchar(50) default '' not null,
DiaChi nvarchar(100) default '' not null,
BoPhan nvarchar(50) default '' not null,
LyDo nvarchar(100) default '' not null,
Kho nvarchar(50) default '' not null,
LoaiXuat nvarchar(50) default '' not null,
NgayXuat bigint default 0 not null,
SoPhieu nvarchar(100) default '' not null,
TrangThai nvarchar(100) default '' not null,
NgayDuyet datetime2 default getdate() not null,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap datetime2 default getdate() not null,
NguoiLapId bigint foreign key references UserAccount(Id),
);

create table ChiTietXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

PhieuXuatKhoId bigint foreign key references PhieuXuatKho(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
SoLuong real default 0 not null,
);

create table NhatKyXuatKho(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),	
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

ChiTietXuatKhoId bigint foreign key references ChiTietXuatKho(Id),
SoLuong real default 0 not null,
NguoiNhan nvarchar(100) default '' not null,
GhiChu nvarchar(100) default '' not null,
);


create table NhaCungCap(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

TenCongTy nvarchar(100) default '' not null,
TenNguoiDaiDien nvarchar(100) default '' not null,
DiaChi nvarchar(100) default '' not null,
Dienthoai varchar(20),
Fax nvarchar(100) default '' not null,
Email nvarchar(100) default '' not null,
MatHang nvarchar(100) default '' not null,
DungYeuCauKyThuat int default 0 not null,
DungThoiGian int default 0 not null,
DungMau int default 0 not null,
DatTestLy int default 0 not null,
DatTestHoa int default 0 not null,
Gia int default 0 not null,
DichVuGiaoHang int default 0 not null,
DichVuHauMai int default 0 not null,
Khac int default 0 not null,
GhiChuNoiBo nvarchar(1000) default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table NhaCungCapVatTu(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

NhaCungCapId bigint foreign key references NhaCungCap(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonGia float default 0 not null,
DonVi nvarchar(10),
GiaBanTuNgay datetime2 default getdate() not null, 
GiaBanDenNgay datetime2 default getdate() not null,
);

create table DonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

ToTrinhId bigint foreign key references NhaCungCap(Id),
SoDH varchar(50),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NgayDatHang datetime2 default getdate() not null,
NgayGiaoHang datetime2 default getdate() not null,
DungYeuCauKyThuat int default 0 not null,
DungThoiGian int default 0 not null,
DungMau int default 0 not null,
DatTestLy int default 0 not null,
DatTestHoa int default 0 not null,
Gia int default 0 not null,
DichVuGiaoHang int default 0 not null,
DichVuHauMai int default 0 not null,
Khac int default 0 not null,
NgayDuyet datetime2 default getdate() not null,
NguoiDuyetId bigint foreign key references UserAccount(Id),
NgayLap datetime2 default getdate() not null,
NguoiLapId bigint foreign key references UserAccount(Id),
TrangThai nvarchar(100) default '' not null,
);

create table ChiTietDonDatHang(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonDatHangId bigint foreign key references DonDatHang(Id),
NhaCungCapId bigint foreign key references NhaCungCap(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
DonGia float default 0 not null,
SoLuong float default 0 not null,
SoLuongThuc float default 0 not null,
GhiChu nvarchar(1000) default '' not null,
)

create table MauDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

MauDanhGia nvarchar(100) default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table ChiTietMauDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

MauDanhGiaId bigint foreign key references MauDanhGia(Id),
TieuChiId bigint foreign key references DanhMuc(Id),
);

create table DanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonDatHangId bigint foreign key references DonDatHang(Id),
MauDanhGiaId bigint foreign key references MauDanhGia(Id),
SoPhieu nvarchar(100) default '' not null,
SoLuongKiem float default 0 not null,
BienPhapXuLy nvarchar(1000) default '' not null,
NgayKiem datetime2 default getdate() not null,
);


create table ChiTietDanhGia(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DanhGiaId bigint foreign key references DanhGia(Id),
TieuChiId bigint foreign key references DanhMuc(Id),
SoLuongKem float default 0 not null,
GhiChu nvarchar(1000) default '' not null,
);

create table MauHuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

KhachHangId bigint foreign key references KhachHang(Id),
TenMau nvarchar(50) default '' not null,
ApDungTuNgay datetime2 default getdate() not null,
ApDungDenNgay datetime2 default getdate() not null,
GhiChu nvarchar(1000) default '' not null,
)

create table ChiTietHuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

MauHuongDanDongGoiId bigint foreign key references MauHuongDanDongGoi(Id),
DanhMucId bigint foreign key references DanhMuc(Id),
DonViTinhId bigint foreign key references DanhMuc(Id),
KichThuoc nvarchar(50) default '' not null,
MauId bigint foreign key references DanhMuc(Id),
NguyenLieuId bigint foreign key references NguyenLieu(Id),
CachSuDung text default '' not null,
ViTriSuDung nvarchar(100) default '' not null,
SoLuong int default 0 not null,
HinhMauDinhKem text default '' not null,
GhiChu nvarchar(1000) default '' not null,
);

create table HuongDanDongGoi(
Id bigint primary key identity(1,1),
AuthorId bigint foreign key references UserAccount(Id),
CreatedDate datetime2 default getdate() not null,
ModifiedDate datetime2 default getdate() not null,
IsActived bit default 1 not null,

DonHangId bigint foreign key references DonHang(Id),
MauDongGoiId bigint foreign key references MauHuongDanDongGoi(Id),
CachDong nvarchar(50) default '' not null,
DongAssorment text default '' not null,
SoLuong int default 0 not null,
SoDoi int default 0 not null,
GhiChu nvarchar(1000) default '' not null,
);


 









