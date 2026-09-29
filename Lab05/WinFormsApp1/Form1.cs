using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseRegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public class KhoaHoc
        {
            public string TenKhoaHoc { get; set; }
            public decimal HocPhiMotThang { get; set; }

            // Hàm khởi tạo
            public KhoaHoc(string tenKhoaHoc, decimal hocPhiMotThang)
            {
                TenKhoaHoc = tenKhoaHoc;
                HocPhiMotThang = hocPhiMotThang;
            }
        }

        // 5.1. Khi Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp danh sách khóa học và học phí theo đề bài
            List<KhoaHoc> dsKhoaHoc = new List<KhoaHoc>
            {
                new KhoaHoc("C# WinForms cơ bản", 800000),
                new KhoaHoc("SQL Server cơ bản", 700000),
                new KhoaHoc("Web Frontend cơ bản", 750000),
                new KhoaHoc("Lập trình Python cơ bản", 650000)
            };

            cboKhoaHoc.DataSource = dsKhoaHoc;
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";

            // Chọn mặc định
            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;
            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            CapNhatTongTien();
        }

        // Hàm tính và hiển thị tổng học phí = học phí 1 tháng x số tháng

        private void CapNhatTongTien()
        {
            if (cboKhoaHoc.SelectedItem is KhoaHoc kh)
            {
                int soThang = (int)numSoThang.Value;
                decimal tongTien = kh.HocPhiMotThang * soThang;

                lblTongTien.Text = $"{tongTien:N0} VNĐ";
                lblhocphithang.Text = $"{kh.HocPhiMotThang:N0} VNĐ";
            }
        }

        // Tự động tính lại tiền khi đổi khóa học hoặc số tháng
        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkNhanEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboKhoaHoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void radOnline_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radOffline_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numSoThang_ValueChanged_1(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên học viên!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhoaHoc kh = (KhoaHoc)cboKhoaHoc.SelectedItem;
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            decimal tongTien = kh.HocPhiMotThang * numSoThang.Value;

            // Xuất thông tin phiếu đăng ký
            string thongTinPhieu = "=== THÔNG TIN PHIẾU ĐĂNG KÝ ===\n\n" +
                                   $"• Họ tên: {hoTen}\n" +
                                   $"• Số điện thoại: {sdt}\n" +
                                   $"• Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                                   $"• Khóa học: {kh.TenKhoaHoc}\n" +
                                   $"• Hình thức học: {hinhThuc}\n" +
                                   $"• Số tháng đăng ký: {numSoThang.Value}\n" +
                                   $"• Tổng học phí: {tongTien:N0} VNĐ\n" +
                                   $"• Nhận email thông báo: {nhanEmail}";

            MessageBox.Show(thongTinPhieu, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            chkNhanEmail.Checked = false;

            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;
            numSoThang.Value = 1;

            CapNhatTongTien();
            txtHoTen.Focus();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}