using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    public enum ShapeType { Pen, Line, Rectangle, Ellipse }

    public class DrawItem
    {
        public ShapeType Type { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
        public Point Start { get; set; }
        public Point End { get; set; }
        public bool IsFilled { get; set; }
    }

    // Panel chống giật (double buffered)
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }
    }

    public partial class Form1 : Form
    {
        private readonly List<DrawItem> drawItems = new List<DrawItem>();
        private bool isDrawing = false;
        private DrawItem currentItem = null;
        private Color selectedColor = Color.Black;
        private Image backgroundImage = null;

        public Form1()
        {
            InitializeComponent();
            cboMode.SelectedIndex = 0;
            btnColor.BackColor = selectedColor;

            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;

            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }

        // ====================== PAINT ======================
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ ảnh nền (nếu có) - scale vừa canvas
            if (backgroundImage != null)
                e.Graphics.DrawImage(backgroundImage, 0, 0, canvas.Width, canvas.Height);

            foreach (var item in drawItems)
                RenderItem(e.Graphics, item);

            if (isDrawing && currentItem != null)
                RenderItem(e.Graphics, currentItem);
        }

        private void RenderItem(Graphics g, DrawItem item)
        {
            using (Pen pen = new Pen(item.PenColor, item.PenWidth))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                switch (item.Type)
                {
                    case ShapeType.Pen:
                        if (item.Points.Count > 1)
                            g.DrawLines(pen, item.Points.ToArray());
                        else if (item.Points.Count == 1)
                            g.DrawLine(pen, item.Points[0], item.Points[0]);
                        break;

                    case ShapeType.Line:
                        g.DrawLine(pen, item.Start, item.End);
                        break;

                    case ShapeType.Rectangle:
                        var r = GetRect(item.Start, item.End);
                        if (r.Width > 0 && r.Height > 0)
                        {
                            if (item.IsFilled)
                                using (Brush b = new SolidBrush(item.PenColor))
                                    g.FillRectangle(b, r);
                            g.DrawRectangle(pen, r);
                        }
                        break;

                    case ShapeType.Ellipse:
                        var re = GetRect(item.Start, item.End);
                        if (re.Width > 0 && re.Height > 0)
                        {
                            if (item.IsFilled)
                                using (Brush b = new SolidBrush(item.PenColor))
                                    g.FillEllipse(b, re);
                            g.DrawEllipse(pen, re);
                        }
                        break;
                }
            }
        }

        private Rectangle GetRect(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }

        // ====================== MOUSE ======================
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;
            currentItem = new DrawItem
            {
                Type = (ShapeType)cboMode.SelectedIndex,
                PenColor = selectedColor,
                PenWidth = (float)nudWidth.Value,
                Start = e.Location,
                End = e.Location,
                IsFilled = chkFill.Checked
            };
            if (currentItem.Type == ShapeType.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X: {e.X}, Y: {e.Y}";

            if (!isDrawing || currentItem == null) return;

            if (currentItem.Type == ShapeType.Pen)
            {
                // Tránh thêm điểm trùng → giảm vẽ lại, mượt hơn
                if (currentItem.Points.Count == 0 ||
                    currentItem.Points[currentItem.Points.Count - 1] != e.Location)
                {
                    currentItem.Points.Add(e.Location);
                }
            }
            else
            {
                currentItem.End = e.Location;
            }
            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;
            isDrawing = false;

            bool hasContent = currentItem.Type == ShapeType.Pen
                ? currentItem.Points.Count > 1
                : currentItem.Start != currentItem.End;

            if (hasContent) drawItems.Add(currentItem);

            currentItem = null;
            canvas.Invalidate();
        }

        // ====================== TOOLBAR ======================
        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog { Color = selectedColor })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = cd.Color;
                    btnColor.BackColor = selectedColor;
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (drawItems.Count == 0) return;
            drawItems.RemoveAt(drawItems.Count - 1);
            canvas.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (drawItems.Count == 0) return;
            if (MessageBox.Show("Xóa toàn bộ hình vẽ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                drawItems.Clear();
                canvas.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // NÂNG CAO: Ctrl+Z
            if (e.Control && e.KeyCode == Keys.Z)
            {
                btnUndo.PerformClick();
                e.Handled = true;
            }
        }

        // NÂNG CAO: Lưu PNG
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = "my_paint.png";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (Bitmap bmp = new Bitmap(canvas.Width, canvas.Height))
                {
                    canvas.DrawToBitmap(bmp, new Rectangle(0, 0, canvas.Width, canvas.Height));
                    bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                MessageBox.Show("Đã lưu ảnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // NÂNG CAO: Đổi màu nền canvas
        private void btnBgColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog { Color = canvas.BackColor })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    canvas.BackColor = cd.Color;
            }
        }

        // NÂNG CAO: Mở ảnh nền để vẽ đè
        private void btnOpenBg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                ofd.Title = "Chọn ảnh nền";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Clone để giải phóng file handle
                    using (var temp = Image.FromFile(ofd.FileName))
                        backgroundImage = new Bitmap(temp);

                    canvas.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}