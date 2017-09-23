IF EXISTS
(
    SELECT name
    FROM   master.dbo.sysdatabases
    WHERE  '['+name+']' = 'GiayTL'
           OR name = 'GiayTL'
)
    USE GiayTL;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[AppConfig]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE AppConfig
        (Id          BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         ConfigName  NVARCHAR(100) DEFAULT '',
         ConfigParam TEXT DEFAULT '',
        );
END;



IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ErrorLog]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ErrorLog
        (Id          BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         CreatedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         AppVersion  NVARCHAR(20) DEFAULT '' NOT NULL,
         Messagelog  NVARCHAR(MAX) DEFAULT '' NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[UserAccount]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE UserAccount
        (Id            BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         CreatedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived     BIT DEFAULT 1 NOT NULL,
         TenNguoiDung  NVARCHAR(50) DEFAULT '',
         MatKhau       TEXT DEFAULT '',
         LoaiNguoiDung TEXT DEFAULT '',
         TenNhanVien   NVARCHAR(100) DEFAULT '',
         DiaChi        NVARCHAR(100) DEFAULT '',
         CMND          VARCHAR(20) DEFAULT '',
         Dienthoai     VARCHAR(20) DEFAULT '',
         GhiChu        NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[PhanQuyenNguoiDung]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE dbo.PhanQuyenNguoiDung
        (Id            BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         CreatedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived     BIT DEFAULT 1 NOT NULL,
         LoaiNguoiDung TEXT DEFAULT '',
         Feature       NVARCHAR(50) DEFAULT '',
         Permission    NVARCHAR(50) DEFAULT 'VIEW' NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'NV'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('NV',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'CBDH'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('CBDH',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'PVT'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('PVT',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'PKT'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('PKT',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'QC'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('QC',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'PKH'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('PKH',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'THU_KHO'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('THU_KHO',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'TRUONG_PKT'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('TRUONG_PKT',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'TRUONG_PVT'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('TRUONG_PVT',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'PX'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('PX',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'GDKT'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('GDKT',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         PhanQuyenNguoiDung
    WHERE        LoaiNguoiDung = 'GDSX'
                 AND Feature = 'DanhMuc'
                 AND Permission = 'VIEW'
)
    INSERT INTO PhanQuyenNguoiDung
    (LoaiNguoiDung,
     Feature,
     Permission
    )
    VALUES
    ('GDSX',
     'DanhMuc',
     'VIEW'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         UserAccount
    WHERE        TenNguoiDung = 'admin'
)
    INSERT INTO UserAccount
    (TenNguoiDung,
     MatKhau,
     LoaiNguoiDung
    )
    VALUES
    ('admin',
     '123456',
     'ADMIN'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         UserAccount
    WHERE        TenNguoiDung = 'phongvattu'
)
    INSERT INTO UserAccount
    (TenNguoiDung,
     MatKhau,
     LoaiNguoiDung
    )
    VALUES
    ('phongvattu',
     '123456',
     'PVT'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         UserAccount
    WHERE        TenNguoiDung = 'truongphongvattu'
)
    INSERT INTO UserAccount
    (TenNguoiDung,
     MatKhau,
     LoaiNguoiDung
    )
    VALUES
    ('truongphongvattu',
     '123456',
     'TRUONG_PVT'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         UserAccount
    WHERE        TenNguoiDung = 'phongkythuat'
)
    INSERT INTO UserAccount
    (TenNguoiDung,
     MatKhau,
     LoaiNguoiDung
    )
    VALUES
    ('phongkythuat',
     '123456',
     'TRUONG_PKT'
    );

IF NOT EXISTS
(
    SELECT TOP 1 *
    FROM         UserAccount
    WHERE        TenNguoiDung = 'thukho'
)
    INSERT INTO UserAccount
    (TenNguoiDung,
     MatKhau,
     LoaiNguoiDung
    )
    VALUES
    ('thukho',
     '123456',
     'THU_KHO'
    );

CREATE TABLE DanhMuc
(Id           BIGINT
 PRIMARY KEY IDENTITY(1, 1),
 AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
 CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
 ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
 IsActived    BIT DEFAULT 1 NOT NULL,
 Ten          NVARCHAR(100) DEFAULT '',
 Loai         NVARCHAR(20) DEFAULT '' NOT NULL,
 GhiChu       NVARCHAR(1000) DEFAULT '',
);

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NguyenLieu]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NguyenLieu
        (Id               BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId         BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate     DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived        BIT DEFAULT 1 NOT NULL,
         LoaiNguyenLieuId BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         Ten              NVARCHAR(100) DEFAULT '',
         MaNguyenLieu     NVARCHAR(50) DEFAULT '',
         DonViTinh        BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         MauId            BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         QuyCach          NVARCHAR(100) DEFAULT '',
         SoLuong          REAL DEFAULT 0 NOT NULL,
         GhiChu           NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[KhachHang]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE KhachHang
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         TenCongTy         NVARCHAR(100) DEFAULT '',
         TenNguoiDaiDien   NVARCHAR(100) DEFAULT '',
         DiaChi            NVARCHAR(100) DEFAULT '',
         Dienthoai         VARCHAR(20),
         Fax               NVARCHAR(100) DEFAULT '',
         Email             NVARCHAR(100) DEFAULT '',
         MatHang           NVARCHAR(100) DEFAULT '',
         DungYeuCauKyThuat INT DEFAULT 0 NOT NULL,
         DungThoiGian      INT DEFAULT 0 NOT NULL,
         DungMau           INT DEFAULT 0 NOT NULL,
         DatTestLy         INT DEFAULT 0 NOT NULL,
         DatTestHoa        INT DEFAULT 0 NOT NULL,
         Gia               INT DEFAULT 0 NOT NULL,
         DichVuGiaoHang    INT DEFAULT 0 NOT NULL,
         DichVuHauMai      INT DEFAULT 0 NOT NULL,
         Khac              INT DEFAULT 0 NOT NULL,
         GhiChuNoiBo       NVARCHAR(1000) DEFAULT '',
         GhiChu            NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[DonHang]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE DonHang
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         MaPhomId          BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         MuId              BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         LotId             BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         DaLotTayId        BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         DeId              BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         MaHang            VARCHAR(50) DEFAULT '',
         MaGiay            VARCHAR(50) DEFAULT '',
         KhachHangId       BIGINT FOREIGN KEY REFERENCES KhachHang(id),
         OrderNo           VARCHAR(50) DEFAULT '',
         NgayNhan          DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayXuat          DATETIME2 DEFAULT GETDATE() NOT NULL,
         HinhAnh           TEXT DEFAULT '',
         SoLuong           INT DEFAULT 0 NOT NULL,
         TrangThai         VARCHAR(20) DEFAULT '',
         GopYVatTu         NVARCHAR(1000) DEFAULT '',
         GopYXuongChat     NVARCHAR(1000) DEFAULT '',
         GopYXuongMay      NVARCHAR(1000) DEFAULT '',
         GopYXuongDe       NVARCHAR(1000) DEFAULT '',
         GopYXuongGo       NVARCHAR(1000) DEFAULT '',
         GopYQc            NVARCHAR(1000) DEFAULT '',
         GopYCongNghe      NVARCHAR(1000) DEFAULT '',
         GopYMau           NVARCHAR(1000) DEFAULT '',
         GopYKhoVatTu      NVARCHAR(1000) DEFAULT '',
         GopYPhuTro        NVARCHAR(1000) DEFAULT '',
         GopYKhoThanhPham  NVARCHAR(1000) DEFAULT '',
         DungYeuCauKyThuat INT DEFAULT 0 NOT NULL,
         DungThoiGian      INT DEFAULT 0 NOT NULL,
         DungMau           INT DEFAULT 0 NOT NULL,
         DatTestLy         INT DEFAULT 0 NOT NULL,
         DatTestHoa        INT DEFAULT 0 NOT NULL,
         Gia               INT DEFAULT 0 NOT NULL,
         DichVuGiaoHang    INT DEFAULT 0 NOT NULL,
         DichVuHauMai      INT DEFAULT 0 NOT NULL,
         Khac              INT DEFAULT 0 NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietDonHang]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietDonHang
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonHangId    BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         MauId        BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         Size         INT DEFAULT 0 NOT NULL,
         SoLuong      INT DEFAULT 0 NOT NULL,
        );
        CREATE TABLE MauDoi
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonHangId    BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         HinhAnh      TEXT DEFAULT '',
         NgayNhan     DATETIME2 DEFAULT GETDATE() NOT NULL,
         MauNgay      DATETIME2 DEFAULT GETDATE() NOT NULL,
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauDoiHinh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauDoiHinh
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         MauDoiId     BIGINT FOREIGN KEY REFERENCES MauDoi(Id),
         HinhAnh      TEXT DEFAULT '',
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauTest]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauTest
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         DonHangId         BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         NgayGuiMau        DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayKetquaTestLy  DATETIME2 DEFAULT GETDATE() NOT NULL,
         KetQuaTestLy      NVARCHAR(1000) DEFAULT '',
         PhanLoaiTestLyId  BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         NgayKetquaTestHoa DATETIME2 DEFAULT GETDATE() NOT NULL,
         KetQuaTestHoa     NVARCHAR(1000) DEFAULT '',
         PhanLoaiTestHoaId BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         GopYCongNghe      NVARCHAR(1000) DEFAULT '',
         GopYMau           NVARCHAR(1000) DEFAULT '',
         GopYQc            NVARCHAR(1000) DEFAULT '',
         GopYKhoVatTu      NVARCHAR(1000) DEFAULT '',
         GopYVatTu         NVARCHAR(1000) DEFAULT '',
         GopYPhuTro        NVARCHAR(1000) DEFAULT '',
         GopYXuongChat     NVARCHAR(1000) DEFAULT '',
         GopYXuongMay      NVARCHAR(1000) DEFAULT '',
         GopYXuongDe       NVARCHAR(1000) DEFAULT '',
         GopYXuongGo       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauSanXuat]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauSanXuat
        (Id             BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId       BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate    DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived      BIT DEFAULT 1 NOT NULL,
         DonHangId      BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         NgayGuiMau     DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayKetqua     DATETIME2 DEFAULT GETDATE() NOT NULL,
         KetQua         NVARCHAR(1000) DEFAULT '',
         PhanLoaiKetQua BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         GopYCongNghe   NVARCHAR(1000) DEFAULT '',
         GopYMau        NVARCHAR(1000) DEFAULT '',
         GopYQc         NVARCHAR(1000) DEFAULT '',
         GopYKhoVatTu   NVARCHAR(1000) DEFAULT '',
         GopYVatTu      NVARCHAR(1000) DEFAULT '',
         GopYPhuTro     NVARCHAR(1000) DEFAULT '',
         GopYXuongChat  NVARCHAR(1000) DEFAULT '',
         GopYXuongMay   NVARCHAR(1000) DEFAULT '',
         GopYXuongDe    NVARCHAR(1000) DEFAULT '',
         GopYXuongGo    NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauThuDao]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauThuDao
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         DonHangId         BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         NgayBatDau        DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanh     DATETIME2 DEFAULT GETDATE() NOT NULL,
         GopYCongNghe      NVARCHAR(1000) DEFAULT '',
         GopYMau           NVARCHAR(1000) DEFAULT '',
         GopYQc            NVARCHAR(1000) DEFAULT '',
         GopYKhoVatTu      NVARCHAR(1000) DEFAULT '',
         GopYVatTu         NVARCHAR(1000) DEFAULT '',
         GopYPhuTro        NVARCHAR(1000) DEFAULT '',
         GopYXuongChat     NVARCHAR(1000) DEFAULT '',
         GopYXuongMay      NVARCHAR(1000) DEFAULT '',
         GopYXuongDe       NVARCHAR(1000) DEFAULT '',
         GopYXuongGo       NVARCHAR(1000) DEFAULT '',
         KetQuaXuongChatId BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         KetQuaXuongMayId  BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         KetQuaXuongDeId   BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         KetQuaXuongGoId   BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[CongNgheSanXuat]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE CongNgheSanXuat
        (Id                    BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId              BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate           DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate          DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived             BIT DEFAULT 1 NOT NULL,
         DonHangId             BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         MauDoiId              BIGINT FOREIGN KEY REFERENCES MauDoi(Id),
         PhanLoaiThuRapId      BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         YKienThuRap           NVARCHAR(1000) DEFAULT '',
         PhanLoaiThuDaoId      BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         YKienThuDao           NVARCHAR(1000) DEFAULT '',
         HinhBangThongSo       TEXT DEFAULT '',
         HinhCongNgheDuocDuyet TEXT DEFAULT '',
         NgayDuyet             DATETIME2 DEFAULT GETDATE() NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiLenh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiLenh
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonHangId    BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         SoPhieu      NVARCHAR(50) DEFAULT '',
         TrangThai    NVARCHAR(50) DEFAULT '',
         NgayLap      DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiLapId   BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayDuyet    DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiDuyetId BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NguyenLieuChiLenh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NguyenLieuChiLenh
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         PhanXuong    NVARCHAR(50) DEFAULT '',
         ChiLenhId    BIGINT FOREIGN KEY REFERENCES ChiLenh(Id),
         ChiTietId    BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         QuyCach      NVARCHAR(10) DEFAULT '' NOT NULL,
         MauId        BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         DinhMucChuan REAL DEFAULT 0 NOT NULL,
         DinhMucThuc  REAL DEFAULT 0 NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietNguyenLieu]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietNguyenLieu
        (Id                  BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId            BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate         DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate        DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived           BIT DEFAULT 1 NOT NULL,
         NguyenLieuChiLenhId BIGINT FOREIGN KEY REFERENCES NguyenLieuChiLenh(Id),
         ChiTietNguyenLieuId BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         GhiChu              NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[KeHoachSanXuat]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE KeHoachSanXuat
        (Id                    BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId              BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate           DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate          DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived             BIT DEFAULT 1 NOT NULL,
         DonHangId             BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         NgayKiemHang          DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauPxChat      DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhPxChat   DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauToPhuTro    DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhToPhuTro DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauPxMay       DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhPxMay    DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauPxGo        DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhPxGo     DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauPxDe        DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhPxDe     DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayBatDauBpVatTu     DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayHoanThanhBpVatTu  DATETIME2 DEFAULT GETDATE() NOT NULL,
         GhiChu                NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[BaoCaoPhanXuong]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE BaoCaoPhanXuong
        (Id               BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId         BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate     DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived        BIT DEFAULT 1 NOT NULL,
         DonHangId        BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         PhanXuong        NVARCHAR(50) DEFAULT '',
         SanLuongKhoan    INT DEFAULT 0 NOT NULL,
         SanLuongThucHien INT DEFAULT 0 NOT NULL,
         LuyKe            INT DEFAULT 0 NOT NULL,
         BaoCaoNgay       DATETIME2 DEFAULT GETDATE() NOT NULL,
         GhiChu           NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[TongHopToTrinh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE TongHopToTrinh
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         SoPhieu      NVARCHAR(50) DEFAULT '',
         TrangThai    NVARCHAR(100) DEFAULT '',
         NguoiLapId   BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayLap      DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiDuyetId BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayDuyet    DATETIME2 DEFAULT GETDATE() NOT NULL,
        );
END;


ALTER TABLE TOTRINH ADD CONSTRAINT FK_ToTrinh_TongHopToTrinh FOREIGN KEY (TongHopToTrinhId) REFERENCES TongHopToTrinh(Id) ON DELETE CASCADE
IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ToTrinh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ToTrinh
        (Id               BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId         BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate     DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived        BIT DEFAULT 1 NOT NULL,
         TongHopToTrinhId BIGINT FOREIGN KEY REFERENCES TongHopToTrinh(Id) ON DELETE CASCADE,
         NguyenLieuId     BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         BoSung           REAL DEFAULT 0 NOT NULL,
         ThuHoi           REAL DEFAULT 0 NOT NULL,
         TonToTrinh       REAL DEFAULT 0 NOT NULL,
         TonTheKho        REAL DEFAULT 0 NOT NULL,
         TonThucTe        REAL DEFAULT 0 NOT NULL,
         DuKien           REAL DEFAULT 0 NOT NULL,
         HaoHut           REAL DEFAULT 0 NOT NULL,
         GhiChu           NVARCHAR(1000) DEFAULT '',
        );
END;


IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietToTrinh]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietToTrinh
        (Id				  BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId			  BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate		  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate		  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived			  BIT DEFAULT 1 NOT NULL,
         ToTrinhId			  BIGINT FOREIGN KEY REFERENCES ToTrinh(Id) ON DELETE CASCADE,
	    ChiTietNguyenLieuId    BIGINT FOREIGN KEY REFERENCES ChiTietNguyenLieu(Id),
         NhuCau			  REAL DEFAULT 0 NOT NULL,
         ThucTe			  REAL DEFAULT 0 NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NhaCungCap]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NhaCungCap
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         TenCongTy         NVARCHAR(100) DEFAULT '',
         TenNguoiDaiDien   NVARCHAR(100) DEFAULT '',
         DiaChi            NVARCHAR(100) DEFAULT '',
         Dienthoai         VARCHAR(20),
         Fax               NVARCHAR(100) DEFAULT '',
         Email             NVARCHAR(100) DEFAULT '',
         MatHang           NVARCHAR(100) DEFAULT '',
         DungYeuCauKyThuat INT DEFAULT 0 NOT NULL,
         DungThoiGian      INT DEFAULT 0 NOT NULL,
         DungMau           INT DEFAULT 0 NOT NULL,
         DatTestLy         INT DEFAULT 0 NOT NULL,
         DatTestHoa        INT DEFAULT 0 NOT NULL,
         Gia               INT DEFAULT 0 NOT NULL,
         DichVuGiaoHang    INT DEFAULT 0 NOT NULL,
         DichVuHauMai      INT DEFAULT 0 NOT NULL,
         Khac              INT DEFAULT 0 NOT NULL,
         GhiChuNoiBo       NVARCHAR(1000) DEFAULT '',
         GhiChu            NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NhaCungCapVatTu]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NhaCungCapVatTu
        (Id            BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId      BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived     BIT DEFAULT 1 NOT NULL,
         NhaCungCapId  BIGINT FOREIGN KEY REFERENCES NhaCungCap(Id),
         NguyenLieuId  BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         DonGia        FLOAT DEFAULT 0 NOT NULL,
         DonVi         NVARCHAR(10),
         GiaBanTuNgay  DATETIME2 DEFAULT GETDATE() NOT NULL,
         GiaBanDenNgay DATETIME2 DEFAULT GETDATE() NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[DonDatHang]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE DonDatHang
        (Id                BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId          BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate       DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived         BIT DEFAULT 1 NOT NULL,
         ToTrinhId         BIGINT FOREIGN KEY REFERENCES NhaCungCap(Id),
         SoDH              VARCHAR(50),
         NhaCungCapId      BIGINT FOREIGN KEY REFERENCES NhaCungCap(Id),
         NgayDatHang       DATETIME2 DEFAULT GETDATE() NOT NULL,
         NgayGiaoHang      DATETIME2 DEFAULT GETDATE() NOT NULL,
         DungYeuCauKyThuat INT DEFAULT 0 NOT NULL,
         DungThoiGian      INT DEFAULT 0 NOT NULL,
         DungMau           INT DEFAULT 0 NOT NULL,
         DatTestLy         INT DEFAULT 0 NOT NULL,
         DatTestHoa        INT DEFAULT 0 NOT NULL,
         Gia               INT DEFAULT 0 NOT NULL,
         DichVuGiaoHang    INT DEFAULT 0 NOT NULL,
         DichVuHauMai      INT DEFAULT 0 NOT NULL,
         Khac              INT DEFAULT 0 NOT NULL,
         NgayDuyet         DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiDuyetId      BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayLap           DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiLapId        BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         TrangThai         NVARCHAR(100) DEFAULT '',
         SoLuongDat        FLOAT DEFAULT 0 NOT NULL
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietDonDatHang]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietDonDatHang
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonDatHangId BIGINT FOREIGN KEY REFERENCES DonDatHang(Id),
         NhaCungCapId BIGINT FOREIGN KEY REFERENCES NhaCungCap(Id),
         NguyenLieuId BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         DonGia       REAL DEFAULT 0 NOT NULL,
         SoLuong      REAL DEFAULT 0 NOT NULL,
         SoLuongThuc  REAL DEFAULT 0 NOT NULL,
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauDanhGia]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauDanhGia
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         TenMau       NVARCHAR(100) DEFAULT '',
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietMauDanhGia]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietMauDanhGia
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         MauDanhGiaId BIGINT FOREIGN KEY REFERENCES MauDanhGia(Id),
         TieuChiId    BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[DanhGia]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE DanhGia
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonDatHangId BIGINT FOREIGN KEY REFERENCES DonDatHang(Id),
         MauDanhGiaId BIGINT FOREIGN KEY REFERENCES MauDanhGia(Id),
         SoPhieu      NVARCHAR(100) DEFAULT '',
         SoLuongKiem  FLOAT DEFAULT 0 NOT NULL,
         SoLuongKem   FLOAT DEFAULT 0 NOT NULL,
         BienPhapXuLy NVARCHAR(1000) DEFAULT '',
         NgayKiem     DATETIME2 DEFAULT GETDATE() NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietDanhGia]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietDanhGia
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DanhGiaId    BIGINT FOREIGN KEY REFERENCES DanhGia(Id),
         TieuChiId    BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         SoLuongKem   FLOAT DEFAULT 0 NOT NULL,
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[PhieuNhapKho]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE PhieuNhapKho
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         NguoiGiao    NVARCHAR(50) DEFAULT '',
         DiaChi       NVARCHAR(100) DEFAULT '',
         LyDo         NVARCHAR(100) DEFAULT '',
         Kho          NVARCHAR(50) DEFAULT '',
         LoaiPhieu    NVARCHAR(50) DEFAULT '',
         NgayNhap     DATETIME2 DEFAULT GETDATE() NOT NULL,
         SoPhieu      NVARCHAR(100) DEFAULT '',
         TrangThai    NVARCHAR(100) DEFAULT '',
         DanhGiaId    BIGINT FOREIGN KEY REFERENCES DanhGia(Id),
         ChiLenhId    BIGINT FOREIGN KEY REFERENCES ChiLenh(Id),
         NgayDuyet    DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiDuyetId BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayLap      DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiLapId   BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietNhapKho]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietNhapKho
        (Id             BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId       BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate    DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived      BIT DEFAULT 1 NOT NULL,
         PhieuNhapKhoId BIGINT FOREIGN KEY REFERENCES PhieuNhapKho(Id),
         NguyenLieuId   BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         SoLuong        REAL DEFAULT 0 NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[PhieuXuatKho]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE PhieuXuatKho
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         DonHangId    BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         NguoiNhan    NVARCHAR(50) DEFAULT '',
         DiaChi       NVARCHAR(100) DEFAULT '',
         BoPhan       NVARCHAR(50) DEFAULT '',
         LyDo         NVARCHAR(100) DEFAULT '',
         Kho          NVARCHAR(50) DEFAULT '',
         LoaiXuat     NVARCHAR(50) DEFAULT '',
         NgayXuat     DATETIME2 DEFAULT GETDATE() NOT NULL,
         SoPhieu      NVARCHAR(100) DEFAULT '',
         TrangThai    NVARCHAR(100) DEFAULT '',
         NgayDuyet    DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiDuyetId BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         NgayLap      DATETIME2 DEFAULT GETDATE() NOT NULL,
         NguoiLapId   BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietXuatKho]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietXuatKho
        (Id             BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId       BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate    DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived      BIT DEFAULT 1 NOT NULL,
         PhieuXuatKhoId BIGINT FOREIGN KEY REFERENCES PhieuXuatKho(Id),
         NguyenLieuId   BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         SoLuong        REAL DEFAULT 0 NOT NULL,
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NhatKyXuatKho]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NhatKyXuatKho
        (Id               BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId         BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate      DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate     DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived        BIT DEFAULT 1 NOT NULL,
         ChiTietXuatKhoId BIGINT FOREIGN KEY REFERENCES ChiTietXuatKho(Id),
         SoLuong          REAL DEFAULT 0 NOT NULL,
         NguoiNhan        NVARCHAR(100) DEFAULT '',
         GhiChu           NVARCHAR(100) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[MauHuongDanDongGoi]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE MauHuongDanDongGoi
        (Id            BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId      BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived     BIT DEFAULT 1 NOT NULL,
         KhachHangId   BIGINT FOREIGN KEY REFERENCES KhachHang(Id),
         TenMau        NVARCHAR(50) DEFAULT '',
         ApDungTuNgay  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ApDungDenNgay DATETIME2 DEFAULT GETDATE() NOT NULL,
         GhiChu        NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[ChiTietHuongDanDongGoi]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE ChiTietHuongDanDongGoi
        (Id                   BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId             BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate          DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate         DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived            BIT DEFAULT 1 NOT NULL,
         MauHuongDanDongGoiId BIGINT FOREIGN KEY REFERENCES MauHuongDanDongGoi(Id),
         DanhMucId            BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         DonViTinhId          BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         KichThuoc            NVARCHAR(50) DEFAULT '',
         MauId                BIGINT FOREIGN KEY REFERENCES DanhMuc(Id),
         NguyenLieuId         BIGINT FOREIGN KEY REFERENCES NguyenLieu(Id),
         CachSuDung           TEXT DEFAULT '',
         ViTriSuDung          NVARCHAR(100) DEFAULT '',
         SoLuong              INT DEFAULT 0 NOT NULL,
         HinhMauDinhKem       TEXT DEFAULT '',
         GhiChu               NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[HuongDanDongGoi]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE HuongDanDongGoi
        (Id            BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId      BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate   DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived     BIT DEFAULT 1 NOT NULL,
         DonHangId     BIGINT FOREIGN KEY REFERENCES DonHang(Id),
         MauDongGoiId  BIGINT FOREIGN KEY REFERENCES MauHuongDanDongGoi(Id),
         CachDong      NVARCHAR(50) DEFAULT '',
         DongAssorment TEXT DEFAULT '',
         SoLuong       INT DEFAULT 0 NOT NULL,
         SoDoi         INT DEFAULT 0 NOT NULL,
         GhiChu        NVARCHAR(1000) DEFAULT '',
        );
END;

IF NOT EXISTS
(
    SELECT *
    FROM   dbo.sysobjects
    WHERE  id = OBJECT_ID(N'dbo.[NhatKyThayDoi]')
           AND OBJECTPROPERTY(id, N'IsTable') = 1
)
    BEGIN
        CREATE TABLE NhatKyThayDoi
        (Id           BIGINT
         PRIMARY KEY IDENTITY(1, 1),
         AuthorId     BIGINT FOREIGN KEY REFERENCES UserAccount(Id),
         CreatedDate  DATETIME2 DEFAULT GETDATE() NOT NULL,
         ModifiedDate DATETIME2 DEFAULT GETDATE() NOT NULL,
         IsActived    BIT DEFAULT 1 NOT NULL,
         ModelName    NVARCHAR(50) DEFAULT '',
         ItemId       BIGINT DEFAULT 0 NOT NULL,
         GhiChu       NVARCHAR(1000) DEFAULT '',
        );
END;