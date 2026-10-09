using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class FrmProduct : Form
    {
        private readonly BindingList<Product> _products = new BindingList<Product>();
        private readonly BindingSource _source = new BindingSource();
        private Product _editing;               // sản phẩm đang được sửa
        private string _currentImagePath = "";  // đường dẫn ảnh hiện tại

        public FrmProduct()
        {
            InitializeComponent();
        }

        // ================= KHỞI TẠO =================
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoaiSP.Items.AddRange(new object[]
                { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });

            // Dữ liệu mẫu
            _products.Add(new Product
            {
                MaSP = "SP001",
                TenSP = "Laptop Dell Inspiron",
                LoaiSP = "Điện tử",
                DonGia = 15500000,
                SoLuong = 10,
                NgayNhap = DateTime.Today.AddDays(-10),
                ConKinhDoanh = true
            });
            _products.Add(new Product
            {
                MaSP = "SP002",
                TenSP = "Bút bi Thiên Long",
                LoaiSP = "Văn phòng",
                DonGia = 5000,
                SoLuong = 200,
                NgayNhap = DateTime.Today.AddDays(-5),
                ConKinhDoanh = true
            });
            _products.Add(new Product
            {
                MaSP = "SP003",
                TenSP = "Nồi cơm điện Sunhouse",
                LoaiSP = "Gia dụng",
                DonGia = 1250000,
                SoLuong = 15,
                NgayNhap = DateTime.Today.AddDays(-2),
                ConKinhDoanh = false
            });

            _source.DataSource = _products;
            dgvProducts.DataSource = _source;

            ClearInput();
            UpdateStatus("Sẵn sàng", _products.Count);
        }

        // ================= TIỆN ÍCH =================
        /// <summary>Cập nhật trạng thái trên StatusStrip.</summary>
        private void UpdateStatus(string message, int count)
        {
            lblStatus.Text = message;
            decimal total = _products.Sum(p => p.DonGia * p.SoLuong);
            lblCount.Text = $"Số sản phẩm: {count}   |   Tổng giá trị tồn: {total:N0} đ";
        }

        /// <summary>Xóa nội dung nhập và bỏ lỗi ErrorProvider.</summary>
        private void ClearInput()
        {
            errProvider.Clear();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;

            _currentImagePath = "";
            if (picAnh.Image != null) { picAnh.Image.Dispose(); picAnh.Image = null; }
            _editing = null;
        }

        /// <summary>Đưa dữ liệu 1 sản phẩm lên form.</summary>
        private void LoadProductToForm(Product p)
        {
            if (p == null) return;
            errProvider.Clear();
            txtMaSP.Text = p.MaSP;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.SelectedItem = p.LoaiSP;
            if (cboLoaiSP.SelectedIndex < 0 && cboLoaiSP.Items.Count > 0)
                cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = Math.Min(p.DonGia, numDonGia.Maximum);
            numSoLuong.Value = Math.Min(p.SoLuong, numSoLuong.Maximum);
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;

            _currentImagePath = p.HinhAnh ?? "";
            LoadImageToPicture(_currentImagePath);
        }

        /// <summary>Kiểm tra dữ liệu nhập. excludeProduct: bỏ qua khi check trùng mã (chế độ Sửa).</summary>
        private bool ValidateInput(Product excludeProduct)
        {
            errProvider.Clear();
            bool ok = true;

            // Mã sản phẩm
            string ma = txtMaSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                errProvider.SetError(txtMaSP, "Mã sản phẩm không được rỗng!");
                ok = false;
            }
            else if (_products.Any(p =>
                        p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase) && p != excludeProduct))
            {
                errProvider.SetError(txtMaSP, "Mã sản phẩm đã tồn tại!");
                ok = false;
            }

            // Tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errProvider.SetError(txtTenSP, "Tên sản phẩm không được rỗng!");
                ok = false;
            }

            // Loại sản phẩm
            if (cboLoaiSP.SelectedIndex < 0)
            {
                errProvider.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm!");
                ok = false;
            }

            // Đơn giá
            if (numDonGia.Value <= 0)
            {
                errProvider.SetError(numDonGia, "Đơn giá phải lớn hơn 0!");
                ok = false;
            }

            // Số lượng
            if (numSoLuong.Value < 0)
            {
                errProvider.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0!");
                ok = false;
            }

            // Ngày nhập
            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errProvider.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại!");
                ok = false;
            }

            if (!ok)
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ. Vui lòng kiểm tra lại!",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return ok;
        }

        /// <summary>Nạp ảnh vào PictureBox (đọc qua stream để tránh khóa file).</summary>
        private void LoadImageToPicture(string path)
        {
            try
            {
                if (picAnh.Image != null) { picAnh.Image.Dispose(); picAnh.Image = null; }
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picAnh.Image = Image.FromStream(fs);
                    }
                }
            }
            catch { /* bỏ qua ảnh lỗi */ }
        }

        /// <summary>Lấy sản phẩm đang được chọn trên grid (nếu có).</summary>
        private Product GetSelectedProduct()
        {
            if (dgvProducts.CurrentRow == null) return null;
            return dgvProducts.CurrentRow.DataBoundItem as Product;
        }

        /// <summary>Load lại grid với nguồn dữ liệu hiện tại.</summary>
        private void RefreshGrid()
        {
            var ds = dgvProducts.DataSource;
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = ds;
        }

        // ================= SỰ KIỆN =================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var p = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (p == null) return;

            _editing = p;
            LoadProductToForm(p);
            UpdateStatus($"Đã chọn {p.MaSP} — Chỉnh sửa rồi bấm Sửa để cập nhật.", _products.Count);
        }

        // -------- THÊM --------
        private void Them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            var p = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.SelectedItem.ToString(),
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                HinhAnh = _currentImagePath
            };
            _products.Add(p);
            ClearInput();
            UpdateStatus($"Đã thêm sản phẩm {p.MaSP}.", _products.Count);
        }

        // -------- SỬA --------
        private void Sua_Click(object sender, EventArgs e)
        {
            var p = _editing ?? GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách để sửa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(p)) return;

            p.MaSP = txtMaSP.Text.Trim();
            p.TenSP = txtTenSP.Text.Trim();
            p.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value;
            p.NgayNhap = dtpNgayNhap.Value.Date;
            p.ConKinhDoanh = chkConKinhDoanh.Checked;
            p.HinhAnh = _currentImagePath;

            RefreshGrid();
            UpdateStatus($"Đã cập nhật sản phẩm {p.MaSP}.", _products.Count);
        }

        // -------- XÓA --------
        private void Xoa_Click(object sender, EventArgs e)
        {
            var p = GetSelectedProduct();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm '{p.TenSP}' ({p.MaSP})?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            _products.Remove(p);

            // Nếu đang xem danh sách lọc -> xóa khỏi BindingList hiển thị
            var viewList = _source.DataSource as BindingList<Product>;
            if (viewList != null && !ReferenceEquals(viewList, _products))
                viewList.Remove(p);

            if (_editing == p) ClearInput();

            RefreshGrid();
            UpdateStatus($"Đã xóa sản phẩm {p.MaSP}.", _products.Count);
        }

        // -------- LÀM MỚI --------
        private void LamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            _source.DataSource = _products;
            dgvProducts.DataSource = _source;
            RefreshGrid();
            UpdateStatus("Đã làm mới dữ liệu.", _products.Count);
        }

        // -------- TÌM KIẾM --------
        private void TimKiem_Click(object sender, EventArgs e)
        {
            string kw = PromptInput("Tìm kiếm", "Nhập mã hoặc tên sản phẩm cần tìm:");
            if (kw == null) return;          // người dùng bấm Hủy
            kw = kw.Trim();

            if (kw.Length == 0)
            {
                LamMoi_Click(sender, e);
                return;
            }

            var result = _products
                .Where(p => p.MaSP.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0
                         || p.TenSP.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            _source.DataSource = new BindingList<Product>(result);
            dgvProducts.DataSource = _source;
            RefreshGrid();
            UpdateStatus($"Tìm thấy {result.Count} sản phẩm cho từ khóa '{kw}'.", result.Count);

            if (result.Count == 0)
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -------- CHỌN ẢNH --------
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                _currentImagePath = ofd.FileName;
                LoadImageToPicture(_currentImagePath);
                UpdateStatus("Đã chọn ảnh: " + Path.GetFileName(_currentImagePath), _products.Count);
            }
        }

        // -------- XEM CHI TIẾT (ContextMenu) --------
        private void cmsXemChiTiet_Click(object sender, EventArgs e)
        {
            var p = GetSelectedProduct();
            if (p == null) return;

            MessageBox.Show(
                $"Mã SP        : {p.MaSP}\n" +
                $"Tên SP       : {p.TenSP}\n" +
                $"Loại         : {p.LoaiSP}\n" +
                $"Đơn giá      : {p.DonGia:N0} đ\n" +
                $"Số lượng     : {p.SoLuong}\n" +
                $"Ngày nhập    : {p.NgayNhap:dd/MM/yyyy}\n" +
                $"Còn KD       : {(p.ConKinhDoanh ? "Có" : "Không")}\n" +
                $"Thành tiền   : {p.DonGia * p.SoLuong:N0} đ",
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -------- MENU TRỢ GIÚP --------
        private void mnuFileExit_Click(object sender, EventArgs e) => Close();

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ứng dụng Quản lý sản phẩm - LAB 05\n" +
                            "Môn: COMP1019 - Lập trình trên Windows\n" +
                            "Sinh viên thực hiện: <Họ tên - MSSV>",
                            "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= HỘP THOẠI NHẬP TỰ TẠO =================
        private string PromptInput(string title, string label)
        {
            using (var f = new Form())
            {
                f.Text = title;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(380, 120);
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ShowInTaskbar = false;

                var lbl = new Label { Text = label, Left = 12, Top = 15, Width = 350 };
                var txt = new TextBox { Left = 12, Top = 40, Width = 350 };
                var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Left = 200, Top = 75, Width = 75 };
                var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 285, Top = 75, Width = 75 };

                f.Controls.AddRange(new Control[] { lbl, txt, btnOK, btnCancel });
                f.AcceptButton = btnOK;
                f.CancelButton = btnCancel;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}