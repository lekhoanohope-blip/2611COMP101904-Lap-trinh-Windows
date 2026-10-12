namespace COMP1019_Lab08_SimplePaint
{
    partial class Form1
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.labelMode = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkFill = new System.Windows.Forms.CheckBox();
            this.btnOpenBg = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.canvas = new DoubleBufferedPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlToolbar.Controls.Add(this.labelMode);
            this.pnlToolbar.Controls.Add(this.cboMode);
            this.pnlToolbar.Controls.Add(this.labelWidth);
            this.pnlToolbar.Controls.Add(this.nudWidth);
            this.pnlToolbar.Controls.Add(this.btnColor);
            this.pnlToolbar.Controls.Add(this.btnUndo);
            this.pnlToolbar.Controls.Add(this.btnClear);
            this.pnlToolbar.Controls.Add(this.chkFill);
            this.pnlToolbar.Controls.Add(this.btnOpenBg);
            this.pnlToolbar.Controls.Add(this.btnSave);
            this.pnlToolbar.Controls.Add(this.btnBgColor);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1000, 50);
            this.pnlToolbar.TabIndex = 0;
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Location = new System.Drawing.Point(12, 17);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(45, 15);
            this.labelMode.TabIndex = 0;
            this.labelMode.Text = "Chế độ:";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            this.cboMode.Location = new System.Drawing.Point(60, 14);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(110, 23);
            this.cboMode.TabIndex = 1;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(185, 17);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(48, 15);
            this.labelWidth.TabIndex = 2;
            this.labelWidth.Text = "Độ dày:";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(239, 15);
            this.nudWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(55, 23);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(310, 12);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(70, 27);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Màu";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(390, 12);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(70, 27);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(470, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 27);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkFill
            // 
            this.chkFill.AutoSize = true;
            this.chkFill.Location = new System.Drawing.Point(555, 17);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(65, 19);
            this.chkFill.TabIndex = 7;
            this.chkFill.Text = "Tô màu";
            this.chkFill.UseVisualStyleBackColor = true;
            // 
            // btnOpenBg
            // 
            this.btnOpenBg.Location = new System.Drawing.Point(640, 12);
            this.btnOpenBg.Name = "btnOpenBg";
            this.btnOpenBg.Size = new System.Drawing.Size(90, 27);
            this.btnOpenBg.TabIndex = 8;
            this.btnOpenBg.Text = "Mở ảnh nền";
            this.btnOpenBg.UseVisualStyleBackColor = true;
            this.btnOpenBg.Click += new System.EventHandler(this.btnOpenBg_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(740, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu PNG";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBgColor
            // 
            this.btnBgColor.Location = new System.Drawing.Point(835, 12);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(90, 27);
            this.btnBgColor.TabIndex = 10;
            this.btnBgColor.Text = "Màu nền";
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // canvas  (dùng DoubleBufferedPanel)
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 50);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1000, 570);
            this.canvas.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 620);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lblStatus.Size = new System.Drawing.Size(78, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "X: 0, Y: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 641);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.lblStatus);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMP1019 - Lab08 Xây dựng ứng dụng Paint đơn giản bằng WinForms và GDI+";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.Button btnOpenBg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBgColor;
        private DoubleBufferedPanel canvas;
        private System.Windows.Forms.Label lblStatus;
    }
}
