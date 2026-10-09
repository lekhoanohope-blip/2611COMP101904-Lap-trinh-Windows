namespace ProductManager
{
    partial class FrmProduct
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFileExit = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuThem = new ToolStripMenuItem();
            mnuSua = new ToolStripMenuItem();
            mnuXoa = new ToolStripMenuItem();
            mnuLamMoi = new ToolStripMenuItem();
            mnuTimKiem = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbThem = new ToolStripButton();
            tsbSua = new ToolStripButton();
            tsbXoa = new ToolStripButton();
            tsbLamMoi = new ToolStripButton();
            tsbTimKiem = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblCount = new ToolStripStatusLabel();
            grpInfo = new GroupBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblLoaiSP = new Label();
            cboLoaiSP = new ComboBox();
            lblDonGia = new Label();
            numDonGia = new NumericUpDown();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            lblNgayNhap = new Label();
            dtpNgayNhap = new DateTimePicker();
            lblConKinhDoanh = new Label();
            chkConKinhDoanh = new CheckBox();
            picAnh = new PictureBox();
            btnChonAnh = new Button();
            dgvProducts = new DataGridView();
            cmsGrid = new ContextMenuStrip(components);
            cmsSua = new ToolStripMenuItem();
            cmsXoa = new ToolStripMenuItem();
            cmsXemChiTiet = new ToolStripMenuItem();
            errProvider = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            cmsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(1333, 30);
            menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 24);
            mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            mnuFileExit.Name = "mnuFileExit";
            mnuFileExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuFileExit.Size = new Size(183, 26);
            mnuFileExit.Text = "Thoát";
            mnuFileExit.Click += mnuFileExit_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuLamMoi, mnuTimKiem });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "&Quản lý";
            // 
            // mnuThem
            // 
            mnuThem.Name = "mnuThem";
            mnuThem.ShortcutKeys = Keys.Control | Keys.N;
            mnuThem.Size = new Size(202, 26);
            mnuThem.Text = "Thêm";
            mnuThem.Click += Them_Click;
            // 
            // mnuSua
            // 
            mnuSua.Name = "mnuSua";
            mnuSua.ShortcutKeys = Keys.Control | Keys.E;
            mnuSua.Size = new Size(202, 26);
            mnuSua.Text = "Sửa";
            mnuSua.Click += Sua_Click;
            // 
            // mnuXoa
            // 
            mnuXoa.Name = "mnuXoa";
            mnuXoa.ShortcutKeys = Keys.Delete;
            mnuXoa.Size = new Size(202, 26);
            mnuXoa.Text = "Xóa";
            mnuXoa.Click += Xoa_Click;
            // 
            // mnuLamMoi
            // 
            mnuLamMoi.Name = "mnuLamMoi";
            mnuLamMoi.ShortcutKeys = Keys.F5;
            mnuLamMoi.Size = new Size(202, 26);
            mnuLamMoi.Text = "Làm mới";
            mnuLamMoi.Click += LamMoi_Click;
            // 
            // mnuTimKiem
            // 
            mnuTimKiem.Name = "mnuTimKiem";
            mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
            mnuTimKiem.Size = new Size(202, 26);
            mnuTimKiem.Text = "Tìm kiếm";
            mnuTimKiem.Click += TimKiem_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(78, 24);
            mnuTroGiup.Text = "Trợ &giúp";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(156, 26);
            mnuAbout.Text = "Giới thiệu";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem });
            toolStrip1.Location = new Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1333, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbThem
            // 
            tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbThem.Name = "tsbThem";
            tsbThem.Size = new Size(50, 24);
            tsbThem.Text = "Thêm";
            tsbThem.Click += Them_Click;
            // 
            // tsbSua
            // 
            tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSua.Name = "tsbSua";
            tsbSua.Size = new Size(38, 24);
            tsbSua.Text = "Sửa";
            tsbSua.Click += Sua_Click;
            // 
            // tsbXoa
            // 
            tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbXoa.Name = "tsbXoa";
            tsbXoa.Size = new Size(39, 24);
            tsbXoa.Text = "Xóa";
            tsbXoa.Click += Xoa_Click;
            // 
            // tsbLamMoi
            // 
            tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbLamMoi.Name = "tsbLamMoi";
            tsbLamMoi.Size = new Size(71, 24);
            tsbLamMoi.Text = "Làm mới";
            tsbLamMoi.Click += LamMoi_Click;
            // 
            // tsbTimKiem
            // 
            tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbTimKiem.Name = "tsbTimKiem";
            tsbTimKiem.Size = new Size(74, 24);
            tsbTimKiem.Text = "Tìm kiếm";
            tsbTimKiem.Click += TimKiem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblCount });
            statusStrip1.Location = new Point(0, 964);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 19, 0);
            statusStrip1.Size = new Size(1333, 22);
            statusStrip1.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 16);
            // 
            // lblCount
            // 
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(1313, 16);
            lblCount.Spring = true;
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(lblMaSP);
            grpInfo.Controls.Add(txtMaSP);
            grpInfo.Controls.Add(lblTenSP);
            grpInfo.Controls.Add(txtTenSP);
            grpInfo.Controls.Add(lblLoaiSP);
            grpInfo.Controls.Add(cboLoaiSP);
            grpInfo.Controls.Add(lblDonGia);
            grpInfo.Controls.Add(numDonGia);
            grpInfo.Controls.Add(lblSoLuong);
            grpInfo.Controls.Add(numSoLuong);
            grpInfo.Controls.Add(lblNgayNhap);
            grpInfo.Controls.Add(dtpNgayNhap);
            grpInfo.Controls.Add(lblConKinhDoanh);
            grpInfo.Controls.Add(chkConKinhDoanh);
            grpInfo.Controls.Add(picAnh);
            grpInfo.Controls.Add(btnChonAnh);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Location = new Point(0, 57);
            grpInfo.Margin = new Padding(4, 5, 4, 5);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(4, 5, 4, 5);
            grpInfo.Size = new Size(1333, 331);
            grpInfo.TabIndex = 3;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(20, 48);
            lblMaSP.Margin = new Padding(4, 0, 4, 0);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(101, 20);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã sản phẩm:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(153, 43);
            txtMaSP.Margin = new Padding(4, 5, 4, 5);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(239, 27);
            txtMaSP.TabIndex = 0;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(20, 109);
            lblTenSP.Margin = new Padding(4, 0, 4, 0);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(103, 20);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "Tên sản phẩm:";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(153, 105);
            txtTenSP.Margin = new Padding(4, 5, 4, 5);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(239, 27);
            txtTenSP.TabIndex = 1;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(20, 171);
            lblLoaiSP.Margin = new Padding(4, 0, 4, 0);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(108, 20);
            lblLoaiSP.TabIndex = 2;
            lblLoaiSP.Text = "Loại sản phẩm:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(153, 166);
            cboLoaiSP.Margin = new Padding(4, 5, 4, 5);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(239, 28);
            cboLoaiSP.TabIndex = 2;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(440, 48);
            lblDonGia.Margin = new Padding(4, 0, 4, 0);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(65, 20);
            lblDonGia.TabIndex = 3;
            lblDonGia.Text = "Đơn giá:";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(573, 43);
            numDonGia.Margin = new Padding(4, 5, 4, 5);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(227, 27);
            numDonGia.TabIndex = 3;
            numDonGia.ThousandsSeparator = true;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(440, 109);
            lblSoLuong.Margin = new Padding(4, 0, 4, 0);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(72, 20);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "Số lượng:";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(573, 105);
            numSoLuong.Margin = new Padding(4, 5, 4, 5);
            numSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(227, 27);
            numSoLuong.TabIndex = 4;
            numSoLuong.ThousandsSeparator = true;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(440, 171);
            lblNgayNhap.Margin = new Padding(4, 0, 4, 0);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(84, 20);
            lblNgayNhap.TabIndex = 5;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(573, 166);
            dtpNgayNhap.Margin = new Padding(4, 5, 4, 5);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(225, 27);
            dtpNgayNhap.TabIndex = 5;
            // 
            // lblConKinhDoanh
            // 
            lblConKinhDoanh.AutoSize = true;
            lblConKinhDoanh.Location = new Point(20, 232);
            lblConKinhDoanh.Margin = new Padding(4, 0, 4, 0);
            lblConKinhDoanh.Name = "lblConKinhDoanh";
            lblConKinhDoanh.Size = new Size(115, 20);
            lblConKinhDoanh.TabIndex = 6;
            lblConKinhDoanh.Text = "Còn kinh doanh:";
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(153, 232);
            chkConKinhDoanh.Margin = new Padding(4, 5, 4, 5);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(18, 17);
            chkConKinhDoanh.TabIndex = 6;
            // 
            // picAnh
            // 
            picAnh.BorderStyle = BorderStyle.FixedSingle;
            picAnh.Location = new Point(920, 23);
            picAnh.Margin = new Padding(4, 5, 4, 5);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(199, 230);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.TabIndex = 7;
            picAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(920, 262);
            btnChonAnh.Margin = new Padding(4, 5, 4, 5);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(200, 46);
            btnChonAnh.TabIndex = 7;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.ContextMenuStrip = cmsGrid;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 388);
            dgvProducts.Margin = new Padding(4, 5, 4, 5);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 25;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1333, 576);
            dgvProducts.TabIndex = 4;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // cmsGrid
            // 
            cmsGrid.ImageScalingSize = new Size(20, 20);
            cmsGrid.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsXemChiTiet });
            cmsGrid.Name = "cmsGrid";
            cmsGrid.Size = new Size(158, 76);
            // 
            // cmsSua
            // 
            cmsSua.Name = "cmsSua";
            cmsSua.Size = new Size(157, 24);
            cmsSua.Text = "Sửa";
            cmsSua.Click += Sua_Click;
            // 
            // cmsXoa
            // 
            cmsXoa.Name = "cmsXoa";
            cmsXoa.Size = new Size(157, 24);
            cmsXoa.Text = "Xóa";
            cmsXoa.Click += Xoa_Click;
            // 
            // cmsXemChiTiet
            // 
            cmsXemChiTiet.Name = "cmsXemChiTiet";
            cmsXemChiTiet.Size = new Size(157, 24);
            cmsXemChiTiet.Text = "Xem chi tiết";
            cmsXemChiTiet.Click += cmsXemChiTiet_Click;
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 986);
            Controls.Add(dgvProducts);
            Controls.Add(grpInfo);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            Load += FrmProduct_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            cmsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuThem;
        private System.Windows.Forms.ToolStripMenuItem mnuSua;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.ToolStripMenuItem mnuLamMoi;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbThem;
        private System.Windows.Forms.ToolStripButton tsbSua;
        private System.Windows.Forms.ToolStripButton tsbXoa;
        private System.Windows.Forms.ToolStripButton tsbLamMoi;
        private System.Windows.Forms.ToolStripButton tsbTimKiem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblConKinhDoanh;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConKinhDoanh;
        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem cmsSua;
        private System.Windows.Forms.ToolStripMenuItem cmsXoa;
        private System.Windows.Forms.ToolStripMenuItem cmsXemChiTiet;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}