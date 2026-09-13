using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Lab01_ThongTinCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Khởi tạo dữ liệu ComboBox khi form load
            LoadComboBoxData();
        }
        /// Load dữ liệu cho ComboBox Khoa/Lớp
        private void LoadComboBoxData()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("-- Chọn khoa/lớp --");
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("SP Toán");
            cboKhoa.Items.Add("SP Hóa");
            cboKhoa.Items.Add("SP Vật lý");
            cboKhoa.Items.Add("SP Sinh");
            cboKhoa.SelectedIndex = 0; // Chọn mục đầu tiên mặc định
        }
        /// Hàm kiểm tra Họ và Tên hợp lệ
        private bool IsValidFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return false;
            string trimmed = fullName.Trim();
            // 1. Độ dài tổng thể từ 3 đến 50 ký tự (ví dụ: "Lê A" -> 4 ký tự)
            if (trimmed.Length < 3 || trimmed.Length > 50)
                return false;
            // 2. Bắt buộc phải có ít nhất 2 từ trở lên (để đảm bảo có đủ Họ và Tên)
            string[] words = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2)
                return false;
            // 3. Chỉ cho phép chữ cái (bao gồm tiếng Việt có dấu) và khoảng trắng
            string pattern = @"^[a-zA-ZàáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵđĐ\s]+$";
            return Regex.IsMatch(trimmed, pattern);
        }
        /// Hàm kiểm tra định dạng Email chuẩn xác cao
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            string emailInput = email.Trim().ToLower();
            // 1. Kiểm tra cấu trúc Regex
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@([a-z0-9][a-z0-9-]*[a-z0-9]\.)+[a-z]{2,63}$";
            if (!Regex.IsMatch(emailInput, pattern))
                return false;
            // 2. Tách phần Domain (sau dấu @) để kiểm tra nâng cao
            string[] parts = emailInput.Split('@');
            if (parts.Length != 2) return false;

            string domain = parts[1];
            // 3. Bắt lỗi gõ sai tên miền phổ biến (Typo Check)
            string[] invalidDomains = new string[]
            {
        "gamil.com", "gmial.com", "gmaill.com", "gmai.com", "gamil.vn",
        "yaho.com", "yaho.com.vn", "hotmai.com", "outloo.com"
            };
            foreach (string badDomain in invalidDomains)
            {
                if (domain == badDomain)
                    return false;
            }
            // 4. Chặn các đuôi miền ghép sai cấu trúc (như .cm.com, .co.com, .edu.com nếu không hợp lệ)
            if (domain.EndsWith(".cm.com") || domain.EndsWith(".com.com") || domain.EndsWith(".net.net"))
                return false;
            // 5. Kiểm tra TLD (Top-Level Domain - Đuôi tên miền cuối cùng như .com, .vn, .edu, .org,...)
            string[] domainParts = domain.Split('.');
            string tld = domainParts[domainParts.Length - 1];
            // Đuôi tên miền phải từ 2 đến 6 ký tự chữ
            if (tld.Length < 2 || tld.Length > 6)
                return false;
            return true;
        }
        /// Xử lý nút Hiển thị
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            //KIỂM TRA DỮ LIỆU
            // 1. Họ tên không được rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            // 1. Kiểm tra Họ và Tên
            string hoTenInput = txtHoTen.Text.Trim();

            if (!IsValidFullName(hoTenInput))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ Họ và Tên!\n" +
                    "- Phải bao gồm cả Họ và Tên (ít nhất 2 từ, ví dụ: Nguyễn Văn A).\n" +
                    "- Không chứa số hoặc ký tự đặc biệt.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtHoTen.Focus();
                return;
            }
            // 2. Năm sinh không được rỗng và phải là số nguyên
            if (string.IsNullOrWhiteSpace(txtNamSinh.Text))
            {
                MessageBox.Show("Năm sinh không được để trống!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            if (!int.TryParse(txtNamSinh.Text, out int namSinh))
            {
                MessageBox.Show("Năm sinh phải là số nguyên!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            // 3. Năm sinh nằm trong khoảng 1900 → năm hiện tại
            int namHienTai = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            // 4. Kiểm tra Email
            string emailInput = txtEmail.Text.Trim();

            if (!IsValidEmail(emailInput))
            {
                MessageBox.Show(
                    "Email không hợp lệ!\n" +
                    "- Hãy kiểm tra lại địa chỉ Email (ví dụ đúng: nguyenvana@gmail.com hoặc sv@hcmue.edu.vn).\n" +
                    "- Chú ý: Tránh gõ sai tên miền (như gamil.com, gmail.cm.com).",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtEmail.Focus();
                return;
            }
            // 5. Phải chọn giới tính
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Phải chọn khoa/lớp (không được chọn mục mặc định)
            if (cboKhoa.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            // XỬ LÝ HIỂN THỊ
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            int tuoi = namHienTai - namSinh;

            string ketQua = "THÔNG TIN SINH VIÊN\n" +
                            $"Họ tên: {txtHoTen.Text.Trim()}\n" +
                            $"Tuổi: {tuoi}\n" +
                            $"Email: {txtEmail.Text.Trim()}\n" +
                            $"Giới tính: {gioiTinh}\n" +
                            $"Khoa/Lớp: {cboKhoa.SelectedItem}";

            MessageBox.Show(ketQua, "Thông tin sinh viên",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// Xử lý nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();

            radNam.Checked = false;
            radNu.Checked = false;

            cboKhoa.SelectedIndex = 0; // Về lựa chọn đầu tiên
            txtHoTen.Focus();
        }
        /// Xử lý nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}