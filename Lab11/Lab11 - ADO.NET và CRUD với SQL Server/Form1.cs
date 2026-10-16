using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace COMP1019_Buoi11_Lab11
{
    public partial class FrmLop : Form
    {
        // ============================================================
        // CHUỖI KẾT NỐI - Dùng database EduManagerDB của Lab10
        // - SQL Server Express: Data Source=.\SQLEXPRESS
        // - SQL Server mặc định: Data Source=.
        // ============================================================
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            LoadData();
        }

        // ============================================================
        // LOAD COMBOBOX KHOA
        // ============================================================
        private void LoadKhoaComboBox()
        {
            try
            {
                string sql = "SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY MaKhoa";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaKhoa.DataSource = dt;
                cboMaKhoa.DisplayMember = "TenKhoa";
                cboMaKhoa.ValueMember = "MaKhoa";
                cboMaKhoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi load khoa: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LOAD DATA - Lấy danh sách lớp kèm tên khoa và số SV
        // ============================================================
        private void LoadData()
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, k.TenKhoa, l.MaKhoa,
                                      COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               GROUP BY l.MaLop, l.TenLop, k.TenKhoa, l.MaKhoa
                               ORDER BY l.MaLop";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi load du lieu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // VALIDATION
        // ============================================================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui long nhap ma lop",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui long nhap ten lop",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            if (cboMaKhoa.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chon khoa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaKhoa.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // KIỂM TRA MÃ LỚP ĐÃ TỒN TẠI
        // ============================================================
        private bool IsMaLopExists(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);

            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // ============================================================
        // ĐẾM SỐ SINH VIÊN THUỘC LỚP
        // ============================================================
        private int CountSinhVienByLop(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // ============================================================
        // NÚT THÊM
        // ============================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboMaKhoa.SelectedValue.ToString();

            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Ma lop da ton tai",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "INSERT INTO LOP(MaLop, TenLop, MaKhoa) VALUES(@ma, @ten, @makhoa)";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@makhoa", maKhoa);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Them lop thanh cong",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi them lop: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT SỬA
        // ============================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboMaKhoa.SelectedValue.ToString();

            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten, MaKhoa = @makhoa WHERE MaLop = @ma";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@makhoa", maKhoa);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Cap nhat lop thanh cong",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Khong tim thay lop can sua",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi cap nhat: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT XÓA
        // ============================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui long chon lop can xoa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int soSinhVien = CountSinhVienByLop(ma);
                if (soSinhVien > 0)
                {
                    MessageBox.Show("Khong the xoa lop dang co sinh vien",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Ban co chac muon xoa lop nay?",
                    "Xac nhan xoa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                string sql = "DELETE FROM LOP WHERE MaLop = @ma";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Xoa lop thanh cong",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa lop: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT TÌM KIẾM
        // ============================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string sql = @"SELECT l.MaLop, l.TenLop, k.TenKhoa, l.MaKhoa,
                                      COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw OR k.TenKhoa LIKE @kw
                               GROUP BY l.MaLop, l.TenLop, k.TenKhoa, l.MaKhoa
                               ORDER BY l.MaLop";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tim kiem: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NÚT LÀM MỚI
        // ============================================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        // ============================================================
        // CLICK DÒNG TRONG DATAGRIDVIEW
        // ============================================================
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value.ToString();

            if (row.Cells["MaKhoa"].Value != null)
            {
                cboMaKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
            }
        }

        // ============================================================
        // CLEAR INPUT
        // ============================================================
        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            cboMaKhoa.SelectedIndex = -1;
            txtMaLop.Focus();
        }
    }
}