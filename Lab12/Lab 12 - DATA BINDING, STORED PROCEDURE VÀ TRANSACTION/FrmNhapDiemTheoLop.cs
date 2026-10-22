using System.Data;
using System.Globalization;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.DataSource = ketQuaSource;
            dgvKetQua.AllowUserToAddRows = false;

            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = ketQuaDAL.GetLop();

                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();

                lblTrangThai.Text = "Đã tải danh sách lớp và môn học.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(maLop) || string.IsNullOrWhiteSpace(maMon))
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
                ketQuaSource.DataSource = table;
                lblTrangThai.Text = $"Đã tải {table.Rows.Count} sinh viên.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                ketQuaSource.EndEdit();

                if (ketQuaSource.DataSource is not DataTable table)
                {
                    MessageBox.Show("Chưa có dữ liệu để lưu.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ValidateData(table);

                string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(maMon))
                {
                    MessageBox.Show("Vui lòng chọn môn học.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int count = ketQuaDAL.SaveAll(maMon, table);

                lblTrangThai.Text = $"Đã lưu thành công {count} dòng.";
                MessageBox.Show($"Đã lưu thành công {count} dòng.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lưu dữ liệu thất bại.";
                MessageBox.Show("Không thể lưu dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateData(DataTable table)
        {
            if (table.Rows.Count == 0)
                throw new Exception("Danh sách sinh viên rỗng, không có gì để lưu.");

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;

                string maSV = row["MaSV"].ToString() ?? "";
                object diemObj = row["Diem"];

                if (diemObj == null || diemObj == DBNull.Value ||
                    string.IsNullOrWhiteSpace(diemObj.ToString()))
                {
                    throw new Exception($"Điểm của sinh viên {maSV} không được để trống.");
                }

                if (!double.TryParse(diemObj.ToString(), NumberStyles.Any,
                        CultureInfo.CurrentCulture, out double diem))
                {
                    throw new Exception($"Điểm của sinh viên {maSV} không hợp lệ.");
                }

                if (diem < 0 || diem > 10)
                {
                    throw new Exception($"Điểm của sinh viên {maSV} phải từ 0 đến 10.");
                }
            }
        }

        private void dgvKetQua_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvKetQua.Columns.Contains("MaSV"))
                dgvKetQua.Columns["MaSV"].ReadOnly = true;

            if (dgvKetQua.Columns.Contains("HoTen"))
                dgvKetQua.Columns["HoTen"].ReadOnly = true;

            if (dgvKetQua.Columns.Contains("Diem"))
            {
                dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
                dgvKetQua.Columns["Diem"].DefaultCellStyle.Format = "0.##";
            }

            if (dgvKetQua.Columns.Contains("GhiChu"))
                dgvKetQua.Columns["GhiChu"].HeaderText = "Ghi chú";

            if (dgvKetQua.Columns.Contains("MaSV"))
                dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";

            if (dgvKetQua.Columns.Contains("HoTen"))
                dgvKetQua.Columns["HoTen"].HeaderText = "Họ tên";
        }

        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            e.ThrowException = false;

            MessageBox.Show("Giá trị nhập không hợp lệ. Điểm phải là số từ 0 đến 10.",
                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}