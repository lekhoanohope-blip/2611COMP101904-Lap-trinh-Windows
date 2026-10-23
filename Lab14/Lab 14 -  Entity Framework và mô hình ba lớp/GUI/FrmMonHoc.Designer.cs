using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_14___Entity_Framework_và_mô_hình_ba_lớp.GUI
{
    partial class FrmMonHoc
    {
        private System.ComponentModel.IContainer components = null!;

        private System.Windows.Forms.Label lblMaMonHoc = null!;
        private System.Windows.Forms.TextBox txtMaMonHoc = null!;
        private System.Windows.Forms.Label lblTenMonHoc = null!;
        private System.Windows.Forms.TextBox txtTenMonHoc = null!;
        private System.Windows.Forms.Label lblSoTinChi = null!;
        private System.Windows.Forms.NumericUpDown nudSoTinChi = null!;
        private System.Windows.Forms.CheckBox chkTrangThai = null!;

        private System.Windows.Forms.Label lblTimKiem = null!;
        private System.Windows.Forms.TextBox txtTimKiem = null!;
        private System.Windows.Forms.Button btnTimKiem = null!;

        private System.Windows.Forms.DataGridView dgvMonHoc = null!;

        private System.Windows.Forms.Button btnThem = null!;
        private System.Windows.Forms.Button btnSua = null!;
        private System.Windows.Forms.Button btnXoa = null!;
        private System.Windows.Forms.Button btnLamMoi = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaMonHoc = new System.Windows.Forms.Label();
            txtMaMonHoc = new System.Windows.Forms.TextBox();
            lblTenMonHoc = new System.Windows.Forms.Label();
            txtTenMonHoc = new System.Windows.Forms.TextBox();
            lblSoTinChi = new System.Windows.Forms.Label();
            nudSoTinChi = new System.Windows.Forms.NumericUpDown();
            chkTrangThai = new System.Windows.Forms.CheckBox();
            lblTimKiem = new System.Windows.Forms.Label();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvMonHoc = new System.Windows.Forms.DataGridView();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();

            // lblMaMonHoc
            lblMaMonHoc.AutoSize = true;
            lblMaMonHoc.Location = new System.Drawing.Point(20, 20);
            lblMaMonHoc.Text = "Mã môn học:";

            // txtMaMonHoc
            txtMaMonHoc.Location = new System.Drawing.Point(130, 17);
            txtMaMonHoc.Size = new System.Drawing.Size(200, 23);

            // lblTenMonHoc
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Location = new System.Drawing.Point(20, 55);
            lblTenMonHoc.Text = "Tên môn học:";

            // txtTenMonHoc
            txtTenMonHoc.Location = new System.Drawing.Point(130, 52);
            txtTenMonHoc.Size = new System.Drawing.Size(300, 23);

            // lblSoTinChi
            lblSoTinChi.AutoSize = true;
            lblSoTinChi.Location = new System.Drawing.Point(20, 90);
            lblSoTinChi.Text = "Số tín chỉ:";

            // nudSoTinChi
            nudSoTinChi.Location = new System.Drawing.Point(130, 87);
            nudSoTinChi.Minimum = 1;
            nudSoTinChi.Maximum = 6;
            nudSoTinChi.Value = 3;
            nudSoTinChi.Size = new System.Drawing.Size(60, 23);

            // chkTrangThai
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new System.Drawing.Point(220, 88);
            chkTrangThai.Text = "Còn sử dụng";
            chkTrangThai.Checked = true;

            // lblTimKiem
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(20, 130);
            lblTimKiem.Text = "Tìm kiếm:";

            // txtTimKiem
            txtTimKiem.Location = new System.Drawing.Point(130, 127);
            txtTimKiem.Size = new System.Drawing.Size(250, 23);

            // btnTimKiem
            btnTimKiem.Location = new System.Drawing.Point(390, 125);
            btnTimKiem.Size = new System.Drawing.Size(90, 27);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += new System.EventHandler(btnTimKiem_Click);

            // btnThem
            btnThem.Location = new System.Drawing.Point(130, 170);
            btnThem.Size = new System.Drawing.Size(90, 30);
            btnThem.Text = "Thêm";
            btnThem.Click += new System.EventHandler(btnThem_Click);

            // btnSua
            btnSua.Location = new System.Drawing.Point(230, 170);
            btnSua.Size = new System.Drawing.Size(90, 30);
            btnSua.Text = "Sửa";
            btnSua.Click += new System.EventHandler(btnSua_Click);

            // btnXoa
            btnXoa.Location = new System.Drawing.Point(330, 170);
            btnXoa.Size = new System.Drawing.Size(90, 30);
            btnXoa.Text = "Xóa";
            btnXoa.Click += new System.EventHandler(btnXoa_Click);

            // btnLamMoi
            btnLamMoi.Location = new System.Drawing.Point(430, 170);
            btnLamMoi.Size = new System.Drawing.Size(90, 30);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += new System.EventHandler(btnLamMoi_Click);

            // dgvMonHoc
            dgvMonHoc.Location = new System.Drawing.Point(20, 215);
            dgvMonHoc.Size = new System.Drawing.Size(740, 320);
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvMonHoc_CellClick);

            // FrmMonHoc
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 555);
            Controls.Add(lblMaMonHoc);
            Controls.Add(txtMaMonHoc);
            Controls.Add(lblTenMonHoc);
            Controls.Add(txtTenMonHoc);
            Controls.Add(lblSoTinChi);
            Controls.Add(nudSoTinChi);
            Controls.Add(chkTrangThai);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvMonHoc);

            Name = "FrmMonHoc";
            Text = "Lab 14 - Entity Framework và mô hình ba lớp";
            Load += new System.EventHandler(FrmMonHoc_Load);

            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}