using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.BLL;
using Lab_14___Entity_Framework_và_mô_hình_ba_lớp.Models;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.GUI
{
    public partial class FrmMonHoc : Form
    {
        private readonly MonHocBLL _bll = new MonHocBLL();

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        // ---------------- Sự kiện Load ----------------
        private void FrmMonHoc_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _bll.GetAll();
                BindGrid(list);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tải danh sách môn học", ex);
            }
        }

        private void BindGrid(List<MonHoc> list)
        {
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = list;

            if (dgvMonHoc.Columns.Contains("MaMonHoc")) dgvMonHoc.Columns["MaMonHoc"]!.HeaderText = "Mã môn học";
            if (dgvMonHoc.Columns.Contains("TenMonHoc")) dgvMonHoc.Columns["TenMonHoc"]!.HeaderText = "Tên môn học";
            if (dgvMonHoc.Columns.Contains("SoTinChi")) dgvMonHoc.Columns["SoTinChi"]!.HeaderText = "Số tín chỉ";
            if (dgvMonHoc.Columns.Contains("TrangThai")) dgvMonHoc.Columns["TrangThai"]!.HeaderText = "Còn sử dụng";
        }

        // ---------------- Tiện ích ----------------
        private MonHoc ReadForm()
        {
            return new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text.Trim(),
                TenMonHoc = txtTenMonHoc.Text.Trim(),
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };
        }

        private void ClearForm()
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 3;
            chkTrangThai.Checked = true;
            txtMaMonHoc.Focus();
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"{title}:\n{ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string? GetSelectedMaMonHoc()
            => dgvMonHoc.CurrentRow?.DataBoundItem is MonHoc mh ? mh.MaMonHoc : null;

        // ---------------- Grid ----------------
        private void dgvMonHoc_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMonHoc.CurrentRow?.DataBoundItem is not MonHoc mh) return;

            txtMaMonHoc.Text = mh.MaMonHoc;
            txtTenMonHoc.Text = mh.TenMonHoc;
            nudSoTinChi.Value = Math.Clamp(mh.SoTinChi, 1, 6);
            chkTrangThai.Checked = mh.TrangThai;

            txtMaMonHoc.ReadOnly = true;
        }

        // ---------------- Buttons ----------------
        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                _bll.Add(ReadForm());
                MessageBox.Show("Thêm môn học thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
                txtMaMonHoc.ReadOnly = false;
            }
            catch (Exception ex)
            {
                ShowError("Không thể thêm môn học", ex);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                _bll.Update(ReadForm());
                MessageBox.Show("Cập nhật môn học thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
                txtMaMonHoc.ReadOnly = false;
            }
            catch (Exception ex)
            {
                ShowError("Không thể cập nhật môn học", ex);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            var ma = GetSelectedMaMonHoc() ?? txtMaMonHoc.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa môn học '{ma}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _bll.Delete(ma);
                MessageBox.Show("Xóa môn học thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
                txtMaMonHoc.ReadOnly = false;
            }
            catch (Exception ex)
            {
                ShowError("Không thể xóa môn học", ex);
            }
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearForm();
            txtTimKiem.Clear();
            txtMaMonHoc.ReadOnly = false;
            LoadData();
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            try
            {
                var list = _bll.Search(txtTimKiem.Text);
                BindGrid(list);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tìm kiếm", ex);
            }
        }
    }
}