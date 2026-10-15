# Lab10 - Cơ sở dữ liệu quản lý sinh viên EduManagerDB

**Học phần:** 2611COMP101904 - Lập trình trên Windows  
**Sinh viên thực hiện:** Lê Trần Anh Khoa | **MSSV:** 51.01.104.044 | **Lớp:** 51.01.CNTT.C

---

## 📑 Mục lục

1. [Giới thiệu](#1-giới-thiệu)
2. [Cấu trúc project](#2-cấu-trúc-project)
3. [Sơ đồ quan hệ các bảng](#3-sơ-đồ-quan-hệ-các-bảng)
4. [Luồng hoạt động tổng quát](#4-luồng-hoạt-động-tổng-quát)
5. [Chi tiết từng file](#5-chi-tiết-từng-file)
6. [Ràng buộc dữ liệu](#6-ràng-buộc-dữ-liệu)
7. [Danh sách truy vấn](#7-danh-sách-truy-vấn)
8. [Kiểm thử ràng buộc](#8-kiểm-thử-ràng-buộc)
9. [Kiến trúc & kỹ thuật chính](#9-kiến-trúc--kỹ-thuật-chính)
10. [Xử lý lỗi & Validation](#10-xử-lý-lỗi--validation)
11. [Ghi chú & mở rộng](#12-ghi-chú--mở-rộng)

---

## 1. Giới thiệu

**EduManagerDB** là cơ sở dữ liệu quan hệ dùng cho bài toán quản lý sinh viên, được xây dựng bằng **T-SQL trên SQL Server**. Cơ sở dữ liệu quản lý 6 đối tượng chính: khoa, lớp, sinh viên, môn học, kết quả học tập và tài khoản đăng nhập.

Các kỹ thuật chính được minh họa:

- Tạo **database, bảng, khóa chính, khóa ngoại** bằng T-SQL.
- Áp dụng **ràng buộc CHECK** để chặn dữ liệu sai (điểm, giới tính, số tín chỉ).
- Nhập **dữ liệu mẫu** đảm bảo đúng quan hệ giữa các bảng.
- Viết truy vấn **SELECT, JOIN, GROUP BY, UPDATE, DELETE**.
- **Kiểm thử ràng buộc** bằng các trường hợp cố tình nhập sai.
- Tổ chức script SQL rõ ràng, có comment, dễ đọc.

| Thông tin | Nội dung |
|---|---|
| Tên database | EduManagerDB |
| Phiên bản | 1.0 |
| Nền tảng | SQL Server 2016+ / SSMS 21+ |
| Lưu trữ | Database file (.mdf, .ldf) |
| Ngôn ngữ | T-SQL |

---

## 2. Cấu trúc project

```
Lab10_EduManagerDB
│
├── 01_CreateDatabase.sql       # Tạo database, bảng, khóa chính, khóa ngoại, ràng buộc
├── 02_InsertSampleData.sql     # Nhập dữ liệu mẫu cho 6 bảng
├── 03_Queries.sql              # Truy vấn SELECT, JOIN, GROUP BY, UPDATE, DELETE và test ràng buộc
├── README.md                   # File mô tả này
└── Ảnh/                        # Ảnh chụp màn hình minh họa
    ├── tao_bang.png
    ├── du_lieu_mau.png
    ├── truy_van_join.png
    ├── thong_ke_lop.png
    └── test_rang_buoc.png
```

---

## 3. Sơ đồ quan hệ các bảng

```
┌────────────┐         ┌────────────┐         ┌────────────┐
│   KHOA     │ 1     n │    LOP     │ 1     n │  SINHVIEN  │
│  MaKhoa PK │◄────────│  MaLop PK  │◄────────│  MaSV PK   │
│  TenKhoa   │         │  MaKhoa FK │         │  MaLop FK  │
│  DienThoai │         │  TenLop    │         │  HoTen     │
└────────────┘         └────────────┘         │  NgaySinh  │
                                              │  GioiTinh  │
                                              └─────┬──────┘
                                                    │ n
                                                    ▼
┌────────────┐         ┌───────────────────────┐
│  MONHOC    │ 1     n │       KETQUA          │
│  MaMH PK   │◄────────│  MaSV PK, FK          │
│  TenMH     │         │  MaMH PK, FK          │
│  SoTinChi  │         │  Diem                 │
└────────────┘         └───────────────────────┘

┌──────────────────┐
│    TAIKHOAN      │   (độc lập)
│  TenDangNhap PK  │
│  MatKhau         │
│  HoTen           │
│  VaiTro          │
│  TrangThai       │
└──────────────────┘
```

- Bảng **LOP** tham chiếu **KHOA** qua `MaKhoa`.
- Bảng **SINHVIEN** tham chiếu **LOP** qua `MaLop`.
- Bảng **KETQUA** tham chiếu **SINHVIEN** (`MaSV`) và **MONHOC** (`MaMH`).
- Bảng **KETQUA** dùng **khóa chính ghép** `(MaSV, MaMH)` để tránh nhập trùng điểm.

---

## 4. Luồng hoạt động tổng quát

```
┌───────────────────────────┐
│  01_CreateDatabase.sql    │  ← Chạy ĐẦU TIÊN
│  - DROP DATABASE cũ       │
│  - CREATE DATABASE        │
│  - CREATE 6 bảng + FK/CK  │
└─────────────┬─────────────┘
              │
              ▼
┌───────────────────────────┐
│ 02_InsertSampleData.sql   │  ← Chạy THỨ HAI
│  - INSERT KHOA (2)        │
│  - INSERT LOP (3)         │
│  - INSERT SINHVIEN (6)    │
│  - INSERT MONHOC (4)      │
│  - INSERT KETQUA (8)      │
│  - INSERT TAIKHOAN (2)    │
└─────────────┬─────────────┘
              │
              ▼
┌───────────────────────────┐
│    03_Queries.sql         │  ← Chạy THỨ BA
│  - Phần 1: Câu 1 → 10     │  → Chạy ra kết quả bình thường
│  - Phần 2: Câu 11 → 14    │  → CỐ Ý báo lỗi để test ràng buộc
└───────────────────────────┘
```

1. **File 1** phải chạy trước để tạo database và bảng.
2. **File 2** chỉ chạy được khi File 1 đã tạo bảng thành công.
3. **File 3** chỉ chạy được khi File 2 đã nhập dữ liệu.
4. Nếu muốn chạy lại từ đầu: chạy lại File 1 → File 2 → File 3.

---

## 5. Chi tiết từng file

### 5.1. File `01_CreateDatabase.sql`

**Mục đích:** Tạo database `EduManagerDB` và 6 bảng với đầy đủ khóa chính, khóa ngoại, ràng buộc.

**Nội dung chính:**

```sql
USE master;
GO

DROP DATABASE IF EXISTS EduManagerDB;
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO
```

Sau đó tạo lần lượt 6 bảng theo đúng thứ tự quan hệ: **KHOA → LOP → SINHVIEN → MONHOC → KETQUA → TAIKHOAN**.

| Bảng | Khóa chính | Khóa ngoại | Ghi chú |
|---|---|---|---|
| KHOA | MaKhoa | — | Lưu thông tin khoa |
| LOP | MaLop | MaKhoa → KHOA | Mỗi lớp thuộc một khoa |
| SINHVIEN | MaSV | MaLop → LOP | Mỗi sinh viên thuộc một lớp |
| MONHOC | MaMH | — | Lưu thông tin môn học |
| KETQUA | (MaSV, MaMH) | MaSV → SINHVIEN, MaMH → MONHOC | Lưu điểm theo môn |
| TAIKHOAN | TenDangNhap | — | Tài khoản đăng nhập demo |

---

### 5.2. File `02_InsertSampleData.sql`

**Mục đích:** Nhập dữ liệu mẫu đảm bảo đúng quan hệ giữa các bảng.

**Số lượng dữ liệu mẫu:**

| Bảng | Số dòng | Ví dụ |
|---|---|---|
| KHOA | 2 | FIT, MATH |
| LOP | 3 | CNTT01, CNTT02, SPTIN01 |
| SINHVIEN | 6 | SV001 → SV006 |
| MONHOC | 4 | COMP1019, COMP1017, COMP1020, COMP1044 |
| KETQUA | 8 | Điểm của SV001 → SV006 theo môn |
| TAIKHOAN | 2 | admin, gv01 |

**Thứ tự nhập bắt buộc:**

```
KHOA → LOP → SINHVIEN → MONHOC → KETQUA → TAIKHOAN
```

→ Nhập KHOA trước LOP; nhập LOP trước SINHVIEN; nhập SINHVIEN và MONHOC trước KETQUA.

**Ví dụ một dòng INSERT:**

```sql
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES 
('SV001', N'Nguyễn Văn An', '2005-02-10', N'Nam', 'CNTT01');
```

---

### 5.3. File `03_Queries.sql`

**Mục đích:** Chứa 14 câu truy vấn, chia làm 2 phần:

| Phần | Câu | Mục đích | Kết quả |
|---|---|---|---|
| Phần 1 | 1 → 10 | Truy vấn SELECT, JOIN, GROUP BY, UPDATE, DELETE | Ra kết quả bình thường |
| Phần 2 | 11 → 14 | Test ràng buộc dữ liệu | **CỐ Ý báo lỗi đỏ** |

**Chi tiết 10 truy vấn đầu:**

| Câu | Nội dung | Kỹ thuật |
|---|---|---|
| 1 | Liệt kê toàn bộ sinh viên | SELECT |
| 2 | Sinh viên kèm tên lớp và tên khoa | INNER JOIN (3 bảng) |
| 3 | Tìm sinh viên theo họ tên | LIKE + ORDER BY |
| 4 | Liệt kê sinh viên theo lớp | WHERE |
| 5 | Cập nhật họ tên sinh viên | UPDATE |
| 6 | Xóa sinh viên chưa có điểm | DELETE + NOT EXISTS |
| 7 | Liệt kê điểm của sinh viên theo môn | INNER JOIN (3 bảng) |
| 8 | Tính điểm trung bình từng sinh viên | AVG + GROUP BY |
| 9 | Thống kê số sinh viên theo lớp | COUNT + LEFT JOIN + GROUP BY |
| 10 | Lớp có từ 2 sinh viên trở lên | GROUP BY + HAVING |

---

## 6. Ràng buộc dữ liệu

| Ràng buộc | Bảng | Cột | Điều kiện |
|---|---|---|---|
| Khóa chính | Tất cả các bảng | — | PRIMARY KEY |
| Khóa ngoại | LOP | MaKhoa | REFERENCES KHOA(MaKhoa) |
| Khóa ngoại | SINHVIEN | MaLop | REFERENCES LOP(MaLop) |
| Khóa ngoại | KETQUA | MaSV, MaMH | REFERENCES SINHVIEN, MONHOC |
| CHECK giới tính | SINHVIEN | GioiTinh | IN (N'Nam', N'Nữ') |
| CHECK điểm | KETQUA | Diem | BETWEEN 0 AND 10 |
| CHECK số tín chỉ | MONHOC | SoTinChi | > 0 |
| DEFAULT vai trò | TAIKHOAN | VaiTro | 'User' |
| DEFAULT trạng thái | TAIKHOAN | TrangThai | 1 |

---

## 7. Danh sách truy vấn

### 7.1. Truy vấn JOIN 3 bảng (Câu 2)

```sql
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa 
FROM SINHVIEN sv 
INNER JOIN LOP l ON sv.MaLop = l.MaLop 
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
```

### 7.2. Truy vấn GROUP BY + AVG (Câu 8)

```sql
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh 
FROM SINHVIEN sv 
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV 
GROUP BY sv.MaSV, sv.HoTen;
```

### 7.3. Truy vấn GROUP BY + HAVING (Câu 10)

```sql
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
FROM LOP l 
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
GROUP BY l.MaLop, l.TenLop 
HAVING COUNT(sv.MaSV) >= 2;
```

---

## 8. Kiểm thử ràng buộc

**Mục tiêu:** Chứng minh database đã chặn được dữ liệu sai. **Các câu lệnh này SẼ báo lỗi đỏ ở tab Messages — đây là điều ĐÚNG với yêu cầu bài Lab.**

| Câu | Test | Kỳ vọng |
|---|---|---|
| 11 | Thêm sinh viên vào lớp `CNTT99` (không tồn tại) | Lỗi FK |
| 12 | Nhập điểm `12` (> 10) | Lỗi CHECK |
| 13 | Nhập giới tính `'Khác'` | Lỗi CHECK |
| 14 | Thêm `MaSV = 'SV001'` (đã tồn tại) | Lỗi PK |

**Ví dụ câu 11:**

```sql
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
-- SQL Server báo: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_SINHVIEN_LOP"
```

---

## 9. Kiến trúc & kỹ thuật chính

| Kỹ thuật | Nơi áp dụng | Mô tả |
|---|---|---|
| **CREATE DATABASE** | File 1 | Tạo database EduManagerDB |
| **CREATE TABLE** | File 1 | Tạo 6 bảng với kiểu dữ liệu phù hợp |
| **PRIMARY KEY** | File 1 | Định nghĩa khóa chính cho từng bảng |
| **FOREIGN KEY** | File 1 | Ràng buộc quan hệ giữa các bảng |
| **CHECK** | File 1 | Ràng buộc miền giá trị (điểm, giới tính, số TC) |
| **DEFAULT** | File 1 | Giá trị mặc định (VaiTro, TrangThai) |
| **INSERT** | File 2 | Nhập dữ liệu mẫu theo đúng thứ tự quan hệ |
| **SELECT** | File 3 (câu 1, 3, 4) | Truy vấn cơ bản |
| **INNER JOIN** | File 3 (câu 2, 7, 8) | Kết hợp dữ liệu nhiều bảng |
| **LEFT JOIN** | File 3 (câu 9, 10) | Giữ tất cả lớp kể cả lớp chưa có SV |
| **WHERE + LIKE** | File 3 (câu 3, 4) | Lọc dữ liệu |
| **ORDER BY** | File 3 (câu 3, 7) | Sắp xếp kết quả |
| **GROUP BY + COUNT** | File 3 (câu 9, 10) | Gom nhóm và đếm |
| **GROUP BY + AVG** | File 3 (câu 8) | Tính trung bình |
| **HAVING** | File 3 (câu 10) | Lọc sau khi gom nhóm |
| **UPDATE** | File 3 (câu 5) | Cập nhật dữ liệu |
| **DELETE + NOT EXISTS** | File 3 (câu 6) | Xóa có điều kiện an toàn |

### 9.1. Vì sao dùng khóa chính ghép cho KETQUA?

```sql
CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH)
```

→ Mỗi cặp `(MaSV, MaMH)` chỉ xuất hiện **một lần duy nhất** trong bảng KETQUA. Điều này ngăn chặn việc nhập trùng điểm của cùng một sinh viên cho cùng một môn học.

### 9.2. Vì sao dùng `LEFT JOIN` ở câu 9, 10?

```sql
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
FROM LOP l 
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
GROUP BY l.MaLop, l.TenLop;
```

→ `LEFT JOIN` giữ lại **tất cả các lớp**, kể cả lớp **chưa có sinh viên nào** (số lượng = 0). Nếu dùng `INNER JOIN`, lớp rỗng sẽ bị mất khỏi kết quả.

### 9.3. Vì sao dùng `NOT EXISTS` ở câu 6?

```sql
DELETE FROM SINHVIEN 
WHERE MaSV = 'SV003' 
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV003');
```

→ Điều kiện `NOT EXISTS` đảm bảo **chỉ xóa khi sinh viên chưa có điểm**. Nếu sinh viên đã có điểm trong bảng KETQUA, câu lệnh sẽ không xóa được (đúng với yêu cầu "xóa sinh viên chưa có dữ liệu điểm").

---

## 10. Xử lý lỗi & Validation

| Trường hợp | Hành vi | Thông báo |
|---|---|---|
| Chạy File 2 trước File 1 | Lỗi `Cannot find database` | Invalid object name |
| Chạy File 3 trước File 2 | Lỗi `Invalid object name 'SINHVIEN'` | Table không tồn tại |
| Chạy lại File 1 khi DB đang mở | Bị treo ở `DROP DATABASE` | Nonqualified transactions are being rolled back |
| Thêm SV vào lớp không tồn tại | Lỗi FK | The INSERT statement conflicted with the FOREIGN KEY constraint |
| Nhập điểm ngoài 0–10 | Lỗi CHECK | The INSERT statement conflicted with the CHECK constraint |
| Nhập giới tính sai | Lỗi CHECK | The INSERT statement conflicted with the CHECK constraint |
| Trùng khóa chính | Lỗi PK | Violation of PRIMARY KEY constraint |
| Xóa SV đã có điểm | Không xóa được (0 rows) | The DELETE statement conflicted with the REFERENCE constraint |

---
## 11. Ghi chú & mở rộng

- **Chạy đúng thứ tự:** File 1 → File 2 → File 3. Nếu chạy sai thứ tự, sẽ báo lỗi `Invalid object name`.
- **Không chạy nút "Build":** Nút Build (biểu tượng cái xẻng) chỉ dùng để biên dịch project C#, không dùng để chạy SQL. Chỉ nhấn **Execute** (F5) hoặc **Ctrl + Shift + E**.
- **Lỗi ảo của IntelliSense:** Đôi khi SSMS báo lỗi đỏ ở Error List nhưng khi F5 vẫn chạy thành công. Nhấn **Ctrl + Shift + R** để refresh cache.
- **Khi bị treo ở DROP DATABASE:** Đóng tất cả tab query cũ, ngắt kết nối Object Explorer, hoặc chạy đoạn kill connection trước khi DROP.

- **Có thể mở rộng thêm:**
  - Thêm cột `Email`, `SoDienThoai` cho bảng `SINHVIEN`.
  - Thêm bảng `GIANGVIEN` và bảng `PHANCONG` (phân công giảng dạy).
  - Thêm ràng buộc `UNIQUE` cho `TenDangNhap`.
  - Viết **Stored Procedure** để thêm/sửa/xóa sinh viên.
  - Viết **Trigger** để tự cập nhật `DiemTrungBinh` khi có điểm mới.
  - Viết **View** để hiển thị bảng điểm đầy đủ.
  - **Backup / Restore** database định kỳ.

- **Tối ưu:** Với các cột thường JOIN như `MaKhoa`, `MaLop`, `MaSV`, `MaMH`, SQL Server đã tự tạo index do là khóa chính/khóa ngoại. Không cần thêm index thủ công.

---
