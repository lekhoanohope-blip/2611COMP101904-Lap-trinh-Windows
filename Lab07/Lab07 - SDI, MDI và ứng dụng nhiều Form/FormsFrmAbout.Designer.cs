namespace ShopManagerMini.Forms
{
    partial class FrmAbout
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
            lblTitle = new Label();
            lblInfo = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.SteelBlue;
            lblTitle.Location = new Point(14, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ShopManagerMini";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(34, 100);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(439, 200);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Ứng dụng quản lý cửa hàng mini\r\n\r\nPhiên bản: 1.0\r\nSinh viên: Lê Trần Anh Khoa\r\nLớp: K51 CNTT C\r\nMSSV: 51.01.104.044\r\nMôn: Lập trình Windows Forms";
            lblInfo.Click += lblInfo_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(189, 320);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 45);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmAbout
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 388);
            Controls.Add(btnClose);
            Controls.Add(lblInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giới thiệu";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnClose;
    }
}