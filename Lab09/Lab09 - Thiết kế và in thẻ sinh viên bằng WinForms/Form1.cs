using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace StudentCardApp
{
    public partial class FrmStudentCard : Form
    {
        private Image _avatar;

        public FrmStudentCard()
        {
            InitializeComponent();
            InitData();
            WireEvents();
        }

        private void InitData()
        {
            cboLop.Items.AddRange(new object[] { "CNTTC", "CNTTB", "SP Tin", "SP Toán" });
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán", "Hóa", "Vật Lý" });
            cboKhoaHoc.Items.AddRange(new object[] { "K49", "K50", "K51", "K52" });
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);
        }

        private void WireEvents()
        {
            txtMaSV.TextChanged += (s, e) => pnlPreview.Invalidate();
            txtHoTen.TextChanged += (s, e) => pnlPreview.Invalidate();
            cboLop.SelectedIndexChanged += (s, e) => pnlPreview.Invalidate();
            cboKhoa.SelectedIndexChanged += (s, e) => pnlPreview.Invalidate();
            cboKhoaHoc.SelectedIndexChanged += (s, e) => pnlPreview.Invalidate();
            cboGioiTinh.SelectedIndexChanged += (s, e) => pnlPreview.Invalidate();
            dtpNgaySinh.ValueChanged += (s, e) => pnlPreview.Invalidate();

            btnChonAnh.Click += btnChonAnh_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXemTruocIn.Click += btnXemTruocIn_Click;
            btnIn.Click += btnIn_Click;
            btnThoat.Click += btnThoat_Click;

            pnlPreview.Paint += pnlPreview_Paint;
            pnlPreview.Resize += (s, e) => pnlPreview.Invalidate();

            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private bool HasRequiredData()
        {
            return !string.IsNullOrWhiteSpace(txtMaSV.Text)
                && !string.IsNullOrWhiteSpace(txtHoTen.Text)
                && _avatar != null;
        }

        private bool ValidateInput(bool showMessage)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                if (showMessage)
                    MessageBox.Show("Vui lòng nhập mã sinh viên.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                if (showMessage)
                    MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (_avatar == null)
            {
                if (showMessage)
                    MessageBox.Show("Vui lòng chọn ảnh đại diện.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChonAnh.Focus();
                return false;
            }

            return true;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Tất cả file|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        using (Image img = Image.FromStream(fs))
                        {
                            _avatar?.Dispose();
                            _avatar = new Bitmap(img);
                        }

                        picAnh.Image = _avatar;
                        picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        pnlPreview.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở ảnh: " + ex.Message,
                            "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();

            cboLop.SelectedIndex = -1;
            cboKhoa.SelectedIndex = -1;
            cboKhoaHoc.SelectedIndex = -1;
            cboGioiTinh.SelectedIndex = 0;

            dtpNgaySinh.Value = new DateTime(2005, 1, 1);

            if (_avatar != null)
            {
                _avatar.Dispose();
                _avatar = null;
            }

            picAnh.Image = null;
            pnlPreview.Invalidate();
        }

        private void pnlPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(pnlPreview.BackColor);

            if (!HasRequiredData())
            {
                using (Font f = new Font("Segoe UI", 11, FontStyle.Italic))
                using (Brush b = new SolidBrush(Color.Gray))
                {
                    string msg = "Nhập Mã SV, Họ tên và chọn ảnh để xem trước thẻ.";
                    SizeF size = e.Graphics.MeasureString(msg, f);
                    e.Graphics.DrawString(msg, f, b,
                        (pnlPreview.Width - size.Width) / 2,
                        (pnlPreview.Height - size.Height) / 2);
                }
                return;
            }

            RectangleF container = new RectangleF(10, 10, pnlPreview.Width - 20, pnlPreview.Height - 20);
            RectangleF card = FitAspect(container, 85.6f / 54f);
            DrawStudentCard(e.Graphics, card);
        }

        private RectangleF FitAspect(RectangleF container, float aspect)
        {
            float w = container.Width;
            float h = w / aspect;

            if (h > container.Height)
            {
                h = container.Height;
                w = h * aspect;
            }

            float x = container.X + (container.Width - w) / 2;
            float y = container.Y + (container.Height - h) / 2;

            return new RectangleF(x, y, w, h);
        }

        private void DrawStudentCard(Graphics g, RectangleF r)
        {
            if (r.Width < 50 || r.Height < 50) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush bg = new LinearGradientBrush(r, Color.White, Color.AliceBlue, 45f))
            {
                g.FillRectangle(bg, r);
            }

            using (Pen border = new Pen(Color.DarkBlue, Math.Max(1f, r.Height * 0.015f)))
            {
                g.DrawRectangle(border, r.X, r.Y, r.Width, r.Height);
            }

            float pad = r.Height * 0.05f;
            float titleH = r.Height * 0.16f;

            using (Font titleFont = new Font("Arial", r.Height * 0.075f, FontStyle.Bold))
            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            using (Brush titleBrush = new SolidBrush(Color.DarkBlue))
            {
                g.DrawString("THẺ SINH VIÊN", titleFont, titleBrush,
                    new RectangleF(r.X, r.Y + pad * 0.5f, r.Width, titleH), sf);
            }

            using (Pen pen = new Pen(Color.DarkBlue, 1))
            {
                g.DrawLine(pen, r.X + pad, r.Y + titleH, r.Right - pad, r.Y + titleH);
            }

            float avatarW = r.Width * 0.28f;
            float avatarH = r.Height * 0.52f;
            float avatarX = r.X + pad;
            float avatarY = r.Y + titleH + pad;
            RectangleF avatarRect = new RectangleF(avatarX, avatarY, avatarW, avatarH);

            using (Pen pen = new Pen(Color.Gray, 1))
            {
                g.DrawRectangle(pen, avatarRect.X, avatarRect.Y, avatarRect.Width, avatarRect.Height);
            }

            if (_avatar != null)
            {
                DrawImageFit(g, _avatar, avatarRect);
            }

            float infoX = avatarRect.Right + pad;
            float infoY = avatarRect.Y;
            float infoW = r.Right - pad - infoX;
            float lineH = r.Height * 0.09f;

            using (Font labelFont = new Font("Arial", r.Height * 0.045f, FontStyle.Bold))
            using (Font valueFont = new Font("Arial", r.Height * 0.045f, FontStyle.Regular))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                string[][] lines = new string[][]
                {
        new[] { "Mã SV:", txtMaSV.Text },
        new[] { "Họ tên:", txtHoTen.Text },
        new[] { "Lớp:", cboLop.Text },
        new[] { "Khoa:", cboKhoa.Text },
        new[] { "Khóa:", cboKhoaHoc.Text },
        new[] { "Ngày sinh:", dtpNgaySinh.Value.ToString("dd/MM/yyyy") },
        new[] { "Giới tính:", cboGioiTinh.Text }
                };

                // Đo chiều rộng label dài nhất để làm cột giá trị
                float labelColWidth = 0f;
                foreach (string[] item in lines)
                {
                    float w = g.MeasureString(item[0], labelFont).Width;
                    if (w > labelColWidth) labelColWidth = w;
                }

                // Cộng thêm khoảng đệm cho thoáng
                float valueX = infoX + labelColWidth + r.Height * 0.02f;

                float y = infoY;
                foreach (string[] item in lines)
                {
                    g.DrawString(item[0], labelFont, brush, infoX, y);
                    g.DrawString(item[1], valueFont, brush, valueX, y);
                    y += lineH;
                }
            }

            using (Font f = new Font("Arial", r.Height * 0.035f, FontStyle.Italic))
            using (Brush b = new SolidBrush(Color.DimGray))
            {
                g.DrawString("Thẻ có giá trị đến hết khóa học", f, b,
                    r.X + pad, r.Bottom - pad - f.Height);
            }
        }

        private void DrawImageFit(Graphics g, Image img, RectangleF dest)
        {
            if (img == null) return;

            float ratio = Math.Min(dest.Width / img.Width, dest.Height / img.Height);
            float w = img.Width * ratio;
            float h = img.Height * ratio;
            float x = dest.X + (dest.Width - w) / 2;
            float y = dest.Y + (dest.Height - h) / 2;

            g.DrawImage(img, x, y, w, h);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF margin = e.MarginBounds;
            RectangleF card = FitAspect(margin, 85.6f / 54f);
            DrawStudentCard(e.Graphics, card);
            e.HasMorePages = false;
        }

        private void btnXemTruocIn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(true)) return;

            printDocument1.DocumentName = "TheSinhVien_" + txtMaSV.Text;

            using (PrintPreviewDialog dlg = new PrintPreviewDialog())
            {
                dlg.Document = printDocument1;
                dlg.Width = 1000;
                dlg.Height = 800;
                dlg.ShowDialog(this);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(true)) return;

            using (PrintDialog pd = new PrintDialog())
            {
                pd.Document = printDocument1;
                if (pd.ShowDialog(this) == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _avatar?.Dispose();
            base.OnFormClosed(e);
        }
    }
}