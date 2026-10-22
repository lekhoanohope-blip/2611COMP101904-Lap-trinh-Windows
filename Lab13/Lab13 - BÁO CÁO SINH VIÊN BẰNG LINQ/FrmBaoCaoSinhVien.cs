using StudentReportDemo.Models;
using System.Text;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private List<SinhVien> danhSachSinhVien = new();
        private List<object> duLieuDangHienThi = new();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        // ==================== LOAD FORM ====================
        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                TaoDuLieuMau();
                LoadComboBox();
                XemBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== TẠO DỮ LIỆU MẪU ====================
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new() { MaSV="SV001", HoTen="Nguyễn Văn An",   MaLop="CTK47A", TenLop="CNTT K47A", Diem=8.2 },
                new() { MaSV="SV002", HoTen="Trần Thị Bình",   MaLop="CTK47A", TenLop="CNTT K47A", Diem=6.5 },
                new() { MaSV="SV003", HoTen="Lê Minh Cường",   MaLop="CTK47A", TenLop="CNTT K47A", Diem=4.8 },
                new() { MaSV="SV004", HoTen="Phạm Thanh Dung", MaLop="CTK47A", TenLop="CNTT K47A", Diem=9.1 },
                new() { MaSV="SV005", HoTen="Hoàng Quốc Huy",  MaLop="CTK47B", TenLop="CNTT K47B", Diem=7.4 },
                new() { MaSV="SV006", HoTen="Võ Gia Khang",    MaLop="CTK47B", TenLop="CNTT K47B", Diem=3.9 },
                new() { MaSV="SV007", HoTen="Đặng Minh Khôi",  MaLop="CTK47B", TenLop="CNTT K47B", Diem=5.5 },
                new() { MaSV="SV008", HoTen="Bùi Thảo Linh",   MaLop="CTK47B", TenLop="CNTT K47B", Diem=8.0 },
                new() { MaSV="SV009", HoTen="Ngô Tuấn Minh",   MaLop="CTK48A", TenLop="CNTT K48A", Diem=6.0 },
                new() { MaSV="SV010", HoTen="Đỗ Bảo Ngọc",     MaLop="CTK48A", TenLop="CNTT K48A", Diem=9.3 },
                new() { MaSV="SV011", HoTen="Huỳnh Gia Phúc",  MaLop="CTK48A", TenLop="CNTT K48A", Diem=4.2 },
                new() { MaSV="SV012", HoTen="Mai Anh Thư",     MaLop="CTK48A", TenLop="CNTT K48A", Diem=7.8 }
            };
        }

        // ==================== LOAD COMBOBOX ====================
        private void LoadComboBox()
        {
            // Dùng LINQ: Select + Distinct + OrderBy
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(l => l.MaLop)
                .ToList();

            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = dsLop;

            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { "Tất cả", "Đạt", "Không đạt" });
            cboKetQua.SelectedIndex = 0;
        }

        // ==================== XEM BÁO CÁO (LỌC + SẮP XẾP) ====================
        private void XemBaoCao()
        {
            if (cboLop.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            // Bắt đầu từ nguồn dữ liệu gốc
            var query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

            // Lọc theo kết quả
            if (ketQua == "Đạt")
                query = query.Where(sv => sv.Diem >= 5);
            else if (ketQua == "Không đạt")
                query = query.Where(sv => sv.Diem < 5);

            // Lọc theo từ khóa (MSSV hoặc họ tên)
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // Sắp xếp + chọn cột hiển thị
            var baoCao = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            duLieuDangHienThi = baoCao.Cast<object>().ToList();

            CapNhatThongKe(baoCao.Count);

            if (baoCao.Count == 0)
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện lọc.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== CẬP NHẬT LABEL THỐNG KÊ ====================
        private void CapNhatThongKe(int soDongHienThi)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";

            var dsLop = danhSachSinhVien.Where(sv => sv.MaLop == maLop).ToList();

            int tongSo = dsLop.Count;
            int soDat = dsLop.Count(sv => sv.Diem >= 5);
            int soKhongDat = dsLop.Count(sv => sv.Diem < 5);
            double diemTB = tongSo > 0 ? dsLop.Average(sv => sv.Diem) : 0;

            lblThongKe.Text =
                $"Đang hiển thị: {soDongHienThi} | " +
                $"Tổng lớp: {tongSo} | Đạt: {soDat} | " +
                $"Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}";
        }

        // ==================== THỐNG KÊ THEO LỚP ====================
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // GroupBy + Select -> bảng thống kê
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;
            duLieuDangHienThi = thongKe.Cast<object>().ToList();
            lblThongKe.Text = "Thống kê theo lớp";
        }

        // ==================== XUẤT FILE CSV ====================
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new();
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new();

                // Header
                for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                {
                    sb.Append(dgvBaoCao.Columns[i].HeaderText);
                    if (i < dgvBaoCao.Columns.Count - 1) sb.Append(',');
                }
                sb.AppendLine();

                // Rows
                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                    {
                        string value = row.Cells[i].Value?.ToString() ?? "";
                        // Xử lý dấu phẩy trong nội dung (tránh vỡ cột CSV)
                        value = value.Replace(",", " ");
                        sb.Append(value);
                        if (i < dgvBaoCao.Columns.Count - 1) sb.Append(',');
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất file thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CÁC SỰ KIỆN KHÁC ====================
        private void btnXemBaoCao_Click(object sender, EventArgs e) => XemBaoCao();
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e) => XemBaoCao();
        private void cboKetQua_SelectedIndexChanged(object sender, EventArgs e) => XemBaoCao();
        private void txtTuKhoa_TextChanged(object sender, EventArgs e) => XemBaoCao();
    }
}