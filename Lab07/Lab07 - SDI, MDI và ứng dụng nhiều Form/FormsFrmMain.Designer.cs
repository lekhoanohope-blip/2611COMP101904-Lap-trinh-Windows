namespace ShopManagerMini.Forms
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuCategory,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout,
            this.mnuExit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(69, 20);
            this.mnuSystem.Text = "Hệ thống";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(180, 22);
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuCategory
            // 
            this.mnuCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProduct,
            this.mnuCustomer});
            this.mnuCategory.Name = "mnuCategory";
            this.mnuCategory.Size = new System.Drawing.Size(74, 20);
            this.mnuCategory.Text = "Danh mục";
            // 
            // mnuProduct
            // 
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.Size = new System.Drawing.Size(180, 22);
            this.mnuProduct.Text = "Quản lý sản phẩm";
            this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(180, 22);
            this.mnuCustomer.Text = "Quản lý khách hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(64, 20);
            this.mnuHelp.Text = "Trợ giúp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(180, 22);
            this.mnuAbout.Text = "Giới thiệu";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUser,
            this.lblStatusRole,
            this.lblStatusSpring,
            this.lblStatusTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(80, 17);
            this.lblStatusUser.Text = "Người dùng: ";
            // 
            // lblStatusRole
            // 
            this.lblStatusRole.Name = "lblStatusRole";
            this.lblStatusRole.Size = new System.Drawing.Size(60, 17);
            this.lblStatusRole.Text = "Vai trò: ";
            // 
            // lblStatusSpring
            // 
            this.lblStatusSpring.Name = "lblStatusSpring";
            this.lblStatusSpring.Size = new System.Drawing.Size(600, 17);
            this.lblStatusSpring.Spring = true;
            // 
            // lblStatusTime
            // 
            this.lblStatusTime.Name = "lblStatusTime";
            this.lblStatusTime.Size = new System.Drawing.Size(60, 17);
            this.lblStatusTime.Text = "--:--:--";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 601);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopManagerMini - Quản lý cửa hàng mini";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRole;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusTime;
        private System.Windows.Forms.Timer timerClock;
    }
}