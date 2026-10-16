USE EduManagerDB;
GO

-- 1. Liệt kê toàn bộ sinh viên 
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop 
FROM SINHVIEN;
GO

-- 2. Sinh viên kèm tên lớp và tên khoa 
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa 
FROM SINHVIEN sv 
INNER JOIN LOP l ON sv.MaLop = l.MaLop 
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;
GO

-- 3. Tìm sinh viên theo họ tên 
SELECT MaSV, HoTen, MaLop 
FROM SINHVIEN 
WHERE HoTen LIKE N'%An%' 
ORDER BY HoTen ASC;
GO

-- 4. Liệt kê sinh viên theo lớp 
SELECT MaSV, HoTen, GioiTinh 
FROM SINHVIEN 
WHERE MaLop = 'CNTT01';
GO

-- 5. Cập nhật thông tin sinh viên 
UPDATE SINHVIEN 
SET HoTen = N'Nguyễn Văn An Updated' 
WHERE MaSV = 'SV001';
GO

-- 6. Xóa sinh viên chưa có điểm 
DELETE FROM SINHVIEN 
WHERE MaSV = 'SV003' 
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV003');
GO

-- 7. Liệt kê điểm của sinh viên theo môn 
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem 
FROM KETQUA kq 
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV 
INNER JOIN MONHOC mh ON kq.MaMH = mh.MaMH 
ORDER BY sv.MaSV, mh.TenMH;
GO

-- 8. Tính điểm trung bình từng sinh viên 
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh 
FROM SINHVIEN sv 
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV 
GROUP BY sv.MaSV, sv.HoTen;
GO

-- 9. Thống kê số sinh viên theo lớp 
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
FROM LOP l 
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
GROUP BY l.MaLop, l.TenLop;
GO

-- 10. Các lớp có từ 2 sinh viên trở lên 
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
FROM LOP l 
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
GROUP BY l.MaLop, l.TenLop 
HAVING COUNT(sv.MaSV) >= 2;
GO

-- =============================================
-- PHẦN KIỂM THỬ RÀNG BUỘC (Các câu lệnh dưới đây SẼ BÁO LỖI)
-- Mục tiêu: Kiểm tra xem database có chặn dữ liệu sai hay không.
-- =============================================

-- 11. Test khóa ngoại: phải lỗi vì lớp CNTT99 không tồn tại 
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
GO

-- 12. Test CHECK điểm: phải lỗi vì điểm lớn hơn 10 
INSERT INTO KETQUA (MaSV, MaMH, Diem) 
VALUES ('SV001', 'COMP1019', 12);
GO

-- 13. Test CHECK giới tính: phải lỗi vì giá trị không thuộc Nam/Nữ 
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
GO

-- 14. Test khóa chính: phải lỗi vì MaSV SV001 đã tồn tại 
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
GO