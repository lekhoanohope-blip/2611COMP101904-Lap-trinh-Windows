IF DB_ID('EduManagerDB') IS NULL
    CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

IF OBJECT_ID('MONHOC', 'U') IS NOT NULL
    DROP TABLE MONHOC;
GO

CREATE TABLE MONHOC
(
    MaMonHoc   NVARCHAR(10)  NOT NULL,
    TenMonHoc  NVARCHAR(100) NOT NULL,
    SoTinChi   INT           NOT NULL,
    TrangThai  BIT           NOT NULL CONSTRAINT DF_MONHOC_TrangThai DEFAULT (1),
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMonHoc),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi BETWEEN 1 AND 6)
);
GO

INSERT INTO MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai) VALUES
('COMP1019', N'Lập trình trên Windows', 3, 1),
('COMP1020', N'Cơ sở dữ liệu',          3, 1),
('COMP1021', N'Lập trình hướng đối tượng', 4, 1);
GO