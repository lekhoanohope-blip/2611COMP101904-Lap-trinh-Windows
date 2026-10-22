using System.ComponentModel;

namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        private IContainer components = null;

        private Label lblLop;
        private Label lblMonHoc;
        private Label lblTrangThai;
        private ComboBox cboLop;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private Button btnLuuTatCa;
        private DataGridView dgvKetQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblLop = new Label();
            this.lblMonHoc = new Label();
            this.lblTrangThai = new Label();
            this.cboLop = new ComboBox();
            this.cboMonHoc = new ComboBox();
            this.btnTaiDanhSach = new Button();
            this.btnLuuTatCa = new Button();
            this.dgvKetQua = new DataGridView();
            ((ISupportInitialize)this.dgvKetQua).BeginInit();
            this.SuspendLayout();
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new Point(20, 24);
            this.lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLop.Location = new Point(60, 20);
            this.cboLop.Size = new Size(250, 28);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new Point(340, 24);
            this.lblMonHoc.Text = "Môn học:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMonHoc.Location = new Point(410, 20);
            this.cboMonHoc.Size = new Size(250, 28);
            // 
            // btnTaiDanhSach
            // 
            this.btnTaiDanhSach.Location = new Point(680, 18);
            this.btnTaiDanhSach.Size = new Size(120, 32);
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = true;
            this.btnTaiDanhSach.Click += this.btnTaiDanhSach_Click;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new Point(20, 70);
            this.dgvKetQua.Size = new Size(780, 380);
            this.dgvKetQua.DataBindingComplete += this.dgvKetQua_DataBindingComplete;
            this.dgvKetQua.DataError += this.dgvKetQua_DataError;
            // 
            // btnLuuTatCa
            // 
            this.btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnLuuTatCa.Location = new Point(680, 470);
            this.btnLuuTatCa.Size = new Size(120, 32);
            this.btnLuuTatCa.Text = "Lưu tất cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = true;
            this.btnLuuTatCa.Click += this.btnLuuTatCa_Click;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(20, 478);
            this.lblTrangThai.Text = "Sẵn sàng.";
            // 
            // FrmNhapDiemTheoLop
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 520);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Name = "FrmNhapDiemTheoLop";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nhập điểm theo lớp";
            this.Load += this.FrmNhapDiemTheoLop_Load;
            ((ISupportInitialize)this.dgvKetQua).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
