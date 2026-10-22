namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblLop = new Label();
            this.cboLop = new ComboBox();
            this.lblKetQua = new Label();
            this.cboKetQua = new ComboBox();
            this.lblTuKhoa = new Label();
            this.txtTuKhoa = new TextBox();
            this.btnXemBaoCao = new Button();
            this.btnThongKe = new Button();
            this.btnXuatFile = new Button();
            this.dgvBaoCao = new DataGridView();
            this.lblThongKe = new Label();

            ((System.ComponentModel.ISupportInitialize)this.dgvBaoCao).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(300, 15);
            this.lblTitle.Text = "BÁO CÁO SINH VIÊN";

            // lblLop
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new Point(20, 60);
            this.lblLop.Text = "Lớp:";

            // cboLop
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLop.Location = new Point(70, 57);
            this.cboLop.Size = new Size(180, 28);
            this.cboLop.SelectedIndexChanged += new EventHandler(this.cboLop_SelectedIndexChanged);

            // lblKetQua
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new Point(270, 60);
            this.lblKetQua.Text = "Kết quả:";

            // cboKetQua
            this.cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKetQua.Location = new Point(335, 57);
            this.cboKetQua.Size = new Size(140, 28);
            this.cboKetQua.SelectedIndexChanged += new EventHandler(this.cboKetQua_SelectedIndexChanged);

            // lblTuKhoa
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new Point(495, 60);
            this.lblTuKhoa.Text = "Từ khóa:";

            // txtTuKhoa
            this.txtTuKhoa.Location = new Point(560, 57);
            this.txtTuKhoa.Size = new Size(200, 27);
            this.txtTuKhoa.PlaceholderText = "MSSV hoặc họ tên...";
            this.txtTuKhoa.TextChanged += new EventHandler(this.txtTuKhoa_TextChanged);

            // btnXemBaoCao
            this.btnXemBaoCao.Location = new Point(20, 100);
            this.btnXemBaoCao.Size = new Size(150, 40);
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.BackColor = Color.LightGreen;
            this.btnXemBaoCao.Click += new EventHandler(this.btnXemBaoCao_Click);

            // btnThongKe
            this.btnThongKe.Location = new Point(180, 100);
            this.btnThongKe.Size = new Size(150, 40);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.BackColor = Color.LightBlue;
            this.btnThongKe.Click += new EventHandler(this.btnThongKe_Click);

            // btnXuatFile
            this.btnXuatFile.Location = new Point(340, 100);
            this.btnXuatFile.Size = new Size(150, 40);
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.BackColor = Color.LightYellow;
            this.btnXuatFile.Click += new EventHandler(this.btnXuatFile_Click);

            // dgvBaoCao
            this.dgvBaoCao.Location = new Point(20, 155);
            this.dgvBaoCao.Size = new Size(860, 380);
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.BackgroundColor = Color.White;

            // lblThongKe
            this.lblThongKe.AutoSize = false;
            this.lblThongKe.Location = new Point(20, 545);
            this.lblThongKe.Size = new Size(860, 30);
            this.lblThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblThongKe.ForeColor = Color.DarkRed;
            this.lblThongKe.Text = "Chưa có dữ liệu thống kê.";

            // FrmBaoCaoSinhVien
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 590);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.cboKetQua);
            this.Controls.Add(this.lblTuKhoa);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.lblThongKe);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lab 13 - Báo cáo sinh viên bằng LINQ";
            this.Load += new EventHandler(this.FrmBaoCaoSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)this.dgvBaoCao).EndInit();
            this.ResumeLayout(false);
        }

        private Label lblTitle, lblLop, lblKetQua, lblTuKhoa, lblThongKe;
        private ComboBox cboLop, cboKetQua;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao, btnThongKe, btnXuatFile;
        private DataGridView dgvBaoCao;
    }
}