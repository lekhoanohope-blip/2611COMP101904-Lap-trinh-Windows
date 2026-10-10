using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmCustomer : Form
    {
        /// <summary>Danh sách khách hàng dùng chung (lưu trong bộ nhớ).</summary>
        public static readonly BindingList<Customer> Customers = new BindingList<Customer>();

        private readonly BindingSource _bs = new BindingSource();
        private Customer _selected;
        private bool _suppressSelection;

        static FrmCustomer()
        {
            Customers.Add(new Customer("KH001", "Nguyễn Văn An", "0901234567", "Thường"));
            Customers.Add(new Customer("KH002", "Trần Thị Bích", "0912345678", "VIP"));
        }

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { "Thường", "VIP", "Thân thiết" });
            cboLoai.SelectedIndex = 0;

            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = _bs;

            LoadData();
            ClearInput();
        }

        private void LoadData()
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                _bs.DataSource = Customers;
            }
            else
            {
                var result = Customers.Where(c =>
                        (c.MaKH ?? "").ToLower().Contains(keyword) ||
                        (c.HoTen ?? "").ToLower().Contains(keyword) ||
                        (c.DienThoai ?? "").ToLower().Contains(keyword))
                    .ToList();
                _bs.DataSource = result;
            }
            _bs.ResetBindings(false);
        }

        private void ClearInput()
        {
            _suppressSelection = true;

            txtMa.Clear();
            txtTen.Clear();
            txtDienThoai.Clear();
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            _selected = null;
            dgvCustomers.ClearSelection();

            _suppressSelection = false;
            txtMa.Focus();
        }

        private Customer GetInput()
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            string dt = txtDienThoai.Text.Trim();
            string loai = cboLoai.Text;

            if (ma == "" || ten == "")
            {
                MessageBox.Show("Mã khách hàng và họ tên không được để trống!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dt != "" && (dt.Length < 9 || dt.Length > 11 || !dt.All(char.IsDigit)))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ gồm 9-11 chữ số)!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return null;
            }

            return new Customer(ma, ten, dt, loai);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Customer c = GetInput();
            if (c == null) return;

            if (Customers.Any(x => x.MaKH.Equals(c.MaKH, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng \"" + c.MaKH + "\" đã tồn tại!",
                                "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Focus();
                return;
            }

            Customers.Add(c);
            LoadData();
            ClearInput();

            MessageBox.Show("Thêm khách hàng thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer c = GetInput();
            if (c == null) return;

            if (Customers.Any(x => x != _selected &&
                                   x.MaKH.Equals(c.MaKH, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng \"" + c.MaKH + "\" đã tồn tại!",
                                "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _selected.MaKH = c.MaKH;
            _selected.HoTen = c.HoTen;
            _selected.DienThoai = c.DienThoai;
            _selected.LoaiKH = c.LoaiKH;

            LoadData();
            ClearInput();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng \"" + _selected.HoTen + "\"?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Customers.Remove(_selected);
            LoadData();
            ClearInput();
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

            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp!",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressSelection) return;
            if (dgvCustomers.CurrentRow == null) return;

            Customer c = dgvCustomers.CurrentRow.DataBoundItem as Customer;
            if (c == null) return;

            _selected = c;
            txtMa.Text = c.MaKH;
            txtTen.Text = c.HoTen;
            txtDienThoai.Text = c.DienThoai;
            cboLoai.Text = c.LoaiKH;
        }
    }
}