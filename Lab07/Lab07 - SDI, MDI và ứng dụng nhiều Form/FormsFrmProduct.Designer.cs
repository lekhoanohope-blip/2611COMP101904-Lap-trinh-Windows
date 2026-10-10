namespace ShopManagerMini.Forms
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInfo.Controls.Add(this.lblMa);
            this.grpInfo.Controls.Add(this.txtMa);
            this.grpInfo.Controls.Add(this.lblTen);
            this.grpInfo.Controls.Add(this.txtTen);
            this.grpInfo.Controls.Add(this.lblLoai);
            this.grpInfo.Controls.Add(this.cboLoai);
            this.grpInfo.Controls.Add(this.lblDonGia);
            this.grpInfo.Controls.Add(this.txtDonGia);
            this.grpInfo.Controls.Add(this.lblSoLuong);
            this.grpInfo.Controls.Add(this.txtSoLuong);
            this.grpInfo.Location = new System.Drawing.Point(12, 12);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(860, 130);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin sản phẩm";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(20, 32);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(78, 15);
            this.lblMa.Text = "Mã sản phẩm:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(130, 29);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(180, 23);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(20, 67);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 15);
            this.lblTen.Text = "Tên sản phẩm:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(130, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(180, 23);
            this.txtTen.TabIndex = 3;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(20, 100);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(82, 15);
            this.lblLoai.Text = "Loại sản phẩm:";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new System.Drawing.Point(130, 97);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(180, 23);
            this.cboLoai.TabIndex = 5;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(380, 32);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(51, 15);
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(480, 29);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(180, 23);
            this.txtDonGia.TabIndex = 2;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(380, 67);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(60, 15);
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(480, 64);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(180, 23);
            this.txtSoLuong.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 155);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(108, 155);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(204, 155);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(300, 155);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(410, 164);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(60, 15);
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(480, 161);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 23);
            this.txtTimKiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(690, 155);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 32);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 200);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(860, 320);
            this.dgvProducts.TabIndex = 7;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 532);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpInfo);
            this.Name = "FrmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}