using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmProduct : Form
    {
        /// <summary>Danh sách sản phẩm dùng chung cho cả ứng dụng (lưu trong bộ nhớ).</summary>
        public static readonly BindingList<Product> Products = new BindingList<Product>();

        private readonly BindingSource _bs = new BindingSource();
        private Product _selected;     // sản phẩm đang chọn trên lưới
        private bool _suppressSelection;  // chặn sự kiện SelectionChanged khi cần

        // Dữ liệu mẫu
        static FrmProduct()
        {
            Products.Add(new Product("SP001", "Coca Cola lon", "Đồ uống", 12000, 50));
            Products.Add(new Product("SP002", "Bánh Oreo", "Bánh kẹo", 25000, 30));
            Products.Add(new Product("SP003", "Bút bi Thiên Long", "Văn phòng phẩm", 5000, 100));
        }

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[]
            {
                "Đồ uống", "Bánh kẹo", "Gia dụng", "Văn phòng phẩm", "Khác"
            });
            cboLoai.SelectedIndex = 0;

            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = _bs;

            LoadData();
            ClearInput();
        }

        // ================== HIỂN THỊ DỮ LIỆU ==================

        /// <summary>Nạp dữ liệu vào lưới (có áp dụng từ khóa tìm kiếm nếu có).</summary>
        private void LoadData()
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                _bs.DataSource = Products;
            }
            else
            {
                var result = Products.Where(p =>
                        (p.MaSP ?? "").ToLower().Contains(keyword) ||
                        (p.TenSP ?? "").ToLower().Contains(keyword) ||
                        (p.LoaiSP ?? "").ToLower().Contains(keyword))
                    .ToList();
                _bs.DataSource = result;
            }
            _bs.ResetBindings(false);
        }

        // ================== NHẬP LIỆU ==================

        private void ClearInput()
        {
            _suppressSelection = true;

            txtMa.Clear();
            txtTen.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            _selected = null;
            dgvProducts.ClearSelection();

            _suppressSelection = false;
            txtMa.Focus();
        }

        /// <summary>Đọc và kiểm tra dữ liệu nhập. Trả về null nếu không hợp lệ.</summary>
        private Product GetInput()
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            string loai = cboLoai.Text;
            string giaText = txtDonGia.Text.Trim();
            string slText = txtSoLuong.Text.Trim();

            // Bắt buộc nhập
            if (ma == "" || ten == "")
            {
                MessageBox.Show("Mã sản phẩm và tên sản phẩm không được để trống!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Đơn giá
            decimal donGia;
            if (!decimal.TryParse(giaText, out donGia))
            {
                MessageBox.Show("Đơn giá phải là số!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return null;
            }
            if (donGia < 0)
            {
                MessageBox.Show("Đơn giá không được âm!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return null;
            }

            // Số lượng
            int soLuong;
            if (!int.TryParse(slText, out soLuong))
            {
                MessageBox.Show("Số lượng phải là số nguyên!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return null;
            }
            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng không được âm!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return null;
            }

            return new Product(ma, ten, loai, donGia, soLuong);
        }

        // ================== CÁC NÚT ==================

        private void btnThem_Click(object sender, EventArgs e)
        {
            Product p = GetInput();
            if (p == null) return;

            // Không cho trùng mã
            if (Products.Any(x => x.MaSP.Equals(p.MaSP, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm \"" + p.MaSP + "\" đã tồn tại!",
                                "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Focus();
                return;
            }

            Products.Add(p);
            LoadData();
            ClearInput();

            MessageBox.Show("Thêm sản phẩm thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên danh sách!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product p = GetInput();
            if (p == null) return;

            // Kiểm tra trùng mã với sản phẩm khác
            if (Products.Any(x => x != _selected &&
                                  x.MaSP.Equals(p.MaSP, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm \"" + p.MaSP + "\" đã tồn tại!",
                                "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selected.MaSP = p.MaSP;
            _selected.TenSP = p.TenSP;
            _selected.LoaiSP = p.LoaiSP;
            _selected.DonGia = p.DonGia;
            _selected.SoLuong = p.SoLuong;

            LoadData();
            ClearInput();

            MessageBox.Show("Cập nhật sản phẩm thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm \"" + _selected.TenSP + "\"?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Products.Remove(_selected);
            LoadData();
            ClearInput();

            MessageBox.Show("Đã xóa sản phẩm.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
            ClearInput();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();

            if (dgvProducts.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ================== LƯỚI ==================

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressSelection) return;
            if (dgvProducts.CurrentRow == null) return;

            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (p == null) return;

            _selected = p;
            txtMa.Text = p.MaSP;
            txtTen.Text = p.TenSP;
            cboLoai.Text = p.LoaiSP;
            txtDonGia.Text = p.DonGia.ToString("0");
            txtSoLuong.Text = p.SoLuong.ToString();
        }
    }
}