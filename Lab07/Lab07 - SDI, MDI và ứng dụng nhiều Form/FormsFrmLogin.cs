using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmLogin : Form
    {
        /// <summary>Danh sách tài khoản mẫu (lưu trong bộ nhớ).</summary>
        private readonly List<User> _accounts = new List<User>()
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user",  "123", "Nhân viên bán hàng", "User")
        };

        /// <summary>Người dùng đăng nhập thành công - dùng để truyền sang FrmMain.</summary>
        public User CurrentUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. Kiểm tra bỏ trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (string.IsNullOrEmpty(username) ? txtUsername : txtPassword).Focus();
                return;
            }

            // 2. Kiểm tra tài khoản
            User found = _accounts.Find(u => u.Username == username && u.Password == password);

            if (found == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 3. Đăng nhập thành công
            CurrentUser = found;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                                "Xác nhận", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}