namespace CourseRegistrationApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            chkKhongNhanEmail = new CheckBox();
            label4 = new Label();
            chkNhanEmail = new CheckBox();
            label3 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            groupBox2 = new GroupBox();
            lblhocphithang = new Label();
            lblHocphi = new Label();
            label8 = new Label();
            lblTongTien = new Label();
            numSoThang = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            radOffline = new RadioButton();
            radOnline = new RadioButton();
            label5 = new Label();
            cboKhoaHoc = new ComboBox();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            panel1 = new Panel();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkKhongNhanEmail);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(chkNhanEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Location = new Point(106, 196);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(492, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin học viên";
            // 
            // chkKhongNhanEmail
            // 
            chkKhongNhanEmail.AutoSize = true;
            chkKhongNhanEmail.Location = new Point(165, 209);
            chkKhongNhanEmail.Name = "chkKhongNhanEmail";
            chkKhongNhanEmail.Size = new Size(224, 24);
            chkKhongNhanEmail.TabIndex = 7;
            chkKhongNhanEmail.Text = "Không nhận Email thông báo";
            chkKhongNhanEmail.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 168);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(165, 168);
            chkNhanEmail.Margin = new Padding(3, 4, 3, 4);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(180, 24);
            chkNhanEmail.TabIndex = 0;
            chkNhanEmail.Text = "Nhận Email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            chkNhanEmail.CheckedChanged += chkNhanEmail_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 124);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 5;
            label3.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(165, 119);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(273, 27);
            dtpNgaySinh.TabIndex = 4;
            dtpNgaySinh.ValueChanged += dtpNgaySinh_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 79);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 3;
            label2.Text = "Số điện thoại:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "Họ và tên:";
            label1.Click += label1_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(165, 28);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(273, 27);
            txtHoTen.TabIndex = 1;
            txtHoTen.TextChanged += textBox2_TextChanged;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(165, 76);
            txtSoDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(273, 27);
            txtSoDienThoai.TabIndex = 0;
            txtSoDienThoai.TextChanged += txtSoDienThoai_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblhocphithang);
            groupBox2.Controls.Add(lblHocphi);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(lblTongTien);
            groupBox2.Controls.Add(numSoThang);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(radOffline);
            groupBox2.Controls.Add(radOnline);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cboKhoaHoc);
            groupBox2.Location = new Point(818, 196);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(479, 283);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin khóa học";
            // 
            // lblhocphithang
            // 
            lblhocphithang.AutoSize = true;
            lblhocphithang.Location = new Point(194, 194);
            lblhocphithang.Name = "lblhocphithang";
            lblhocphithang.Size = new Size(52, 20);
            lblhocphithang.TabIndex = 16;
            lblhocphithang.Text = "0 VNĐ";
            // 
            // lblHocphi
            // 
            lblHocphi.AutoSize = true;
            lblHocphi.Location = new Point(52, 194);
            lblHocphi.Name = "lblHocphi";
            lblHocphi.Size = new Size(116, 20);
            lblHocphi.TabIndex = 15;
            lblHocphi.Text = "Học phí / tháng:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(52, 235);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 14;
            label8.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(194, 235);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(52, 20);
            lblTongTien.TabIndex = 13;
            lblTongTien.Text = "0 VNĐ";
            lblTongTien.Click += lblTongTien_Click;
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(194, 138);
            numSoThang.Margin = new Padding(3, 4, 3, 4);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(74, 27);
            numSoThang.TabIndex = 12;
            numSoThang.TextAlign = HorizontalAlignment.Center;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numSoThang_ValueChanged_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 138);
            label7.Name = "label7";
            label7.Size = new Size(124, 20);
            label7.TabIndex = 11;
            label7.Text = "Số tháng đăng kí:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 101);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 10;
            label6.Text = "Hình thức:";
            label6.Click += label6_Click;
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.Location = new Point(241, 101);
            radOffline.Margin = new Padding(3, 4, 3, 4);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(75, 24);
            radOffline.TabIndex = 9;
            radOffline.Text = "Offline";
            radOffline.UseVisualStyleBackColor = true;
            radOffline.CheckedChanged += radOffline_CheckedChanged;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Checked = true;
            radOnline.Location = new Point(164, 101);
            radOnline.Margin = new Padding(3, 4, 3, 4);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(73, 24);
            radOnline.TabIndex = 8;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            radOnline.CheckedChanged += radOnline_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 51);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 7;
            label5.Text = "Khóa học:";
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(164, 51);
            cboKhoaHoc.Margin = new Padding(3, 4, 3, 4);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(223, 28);
            cboKhoaHoc.TabIndex = 0;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged_1;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.SpringGreen;
            btnDangKy.Location = new Point(57, 33);
            btnDangKy.Margin = new Padding(3, 4, 3, 4);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(144, 58);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DeepSkyBlue;
            btnLamMoi.Location = new Point(367, 31);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(144, 62);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.Location = new Point(676, 37);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(144, 54);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDangKy);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnLamMoi);
            panel1.Location = new Point(271, 560);
            panel1.Name = "panel1";
            panel1.Size = new Size(863, 125);
            panel1.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label9.ForeColor = Color.BurlyWood;
            label9.Location = new Point(522, 106);
            label9.Name = "label9";
            label9.Size = new Size(442, 32);
            label9.TabIndex = 6;
            label9.Text = "ĐĂNG KÍ KHÓA HỌC NGẮN HẠN";
            label9.TextAlign = ContentAlignment.TopCenter;
            label9.Click += label9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 728);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNhanEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radOffline;
        private System.Windows.Forms.RadioButton radOnline;
        private System.Windows.Forms.NumericUpDown numSoThang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThoat;
        private CheckBox chkKhongNhanEmail;
        private Panel panel1;
        private Label lblhocphithang;
        private Label lblHocphi;
        private Label label9;
    }
}
