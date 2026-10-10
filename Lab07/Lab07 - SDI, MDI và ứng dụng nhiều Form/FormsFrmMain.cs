using System;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    public partial class FrmMain : Form
    {
        private User _currentUser;
        private bool _allowClose = false;   // cờ cho phép đóng khi đăng xuất

        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>Nhận thông tin người dùng từ FrmLogin qua constructor.</summary>
        public FrmMain(User user) : this()
        {
            _currentUser = user;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        /// <summary>Cập nhật tên người dùng + vai trò lên StatusStrip.</summary>
        private void UpdateStatusBar()
        {
            if (_currentUser != null)
            {
                lblStatusUser.Text = "Người dùng: " + _currentUser.FullName;
                lblStatusRole.Text = "Vai trò: " + _currentUser.Role;
            }
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ---------------------------------------------------------------
        //  Mở Form con MDI - KHÔNG mở trùng
        // ---------------------------------------------------------------
        private void OpenChildForm(Form child)
        {
            // Duyệt các Form con đang mở, nếu trùng kiểu thì kích hoạt lại
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == child.GetType())
                {
                    if (f.WindowState == FormWindowState.Minimized)
                        f.WindowState = FormWindowState.Normal;

                    f.Activate();
                    child.Dispose();     // huỷ Form mới vì không dùng
                    return;
                }
            }

            // Chưa có -> mở mới
            child.MdiParent = this;
            child.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmProduct());
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCustomer());
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            // FrmAbout mở dạng hộp thoại (không phải MDI child)
            using (FrmAbout frm = new FrmAbout())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?",
                                "Xác nhận", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Đóng tất cả form con
            foreach (Form f in this.MdiChildren) f.Close();

            this.Hide();

            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    _currentUser = login.CurrentUser;
                    UpdateStatusBar();
                    this.Show();
                }
                else
                {
                    _allowClose = true;
                    this.Close();
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowClose) return;

            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                                "Xác nhận thoát", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}