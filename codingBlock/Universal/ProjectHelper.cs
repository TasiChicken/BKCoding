using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace codingBlock
{
    internal class Vector2Helper
    {
        #region Size
        public static Size Add(Size a, Size b)
        {
            return new Size(a.Width + b.Width, a.Height + b.Height);
        }

        public static Size Sub(Size a, Size b)
        {
            return new Size(a.Width - b.Width, a.Height - b.Height);
        }

        public static Size Mul(Size a, int b)
        {
            return new Size(a.Width * b, a.Height * b);
        }

        public static Size Div(Size a, int b)
        {
            return new Size(a.Width / b, a.Height / b);
        }

        public static CompareResult Compare(Size a, Size b, bool strict = false)
        {
            if (a.Width == b.Width && a.Height == b.Height) return CompareResult.Equal;

            if (strict)
            {
                if (a.Width > b.Width && a.Height > b.Height) return CompareResult.More;
                if (a.Width < b.Width && a.Height < b.Height) return CompareResult.Less;
            }
            else
            {
                if (a.Width >= b.Width && a.Height >= b.Height) return CompareResult.More;
                if (a.Width <= b.Width && a.Height <= b.Height) return CompareResult.Less;
            }

            return CompareResult.NoResult;
        }
        #endregion

        #region Point

        public static Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point Sub(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point Mul(Point a, int b)
        {
            return new Point(a.X * b, a.Y * b);
        }

        public static Point Div(Point a, int b)
        {
            return new Point(a.X / b, a.Y / b);
        }

        public static CompareResult Compare(Point a, Point b, bool strict = false)
        {
            if (a.X == b.X && a.Y == b.Y) return CompareResult.Equal;
            
            if (strict)
            {
                if (a.X > b.X && a.Y > b.Y) return CompareResult.More;
                if (a.X < b.X && a.Y < b.Y) return CompareResult.Less;
            }
            else
            {
                if (a.X >= b.X && a.Y >= b.Y) return CompareResult.More;
                if (a.X <= b.X && a.Y <= b.Y) return CompareResult.Less;
            }

            return CompareResult.NoResult;
        }

        public static Point PositionInTopLevel(Control control, Point initialPoint = new Point())
        {
            if (control.Equals(control.TopLevelControl) || control.Parent == null) return initialPoint;
            else return PositionInTopLevel(control.Parent, Vector2Helper.Add(initialPoint, control.Location));
        }

        #endregion
    }

    internal class DrawingHelper
    {
        public static void DrawRoundedBorder(Pen pen, Control control, Graphics graphics, int radius)
        {
            GraphicsPath graphicsPath = GetRoundedRectanglePath(control, radius);
            graphics.DrawPath(pen, graphicsPath);
        }

        public static void DrawRoundedRetangle(Brush brush, Control control, Graphics graphics, int radius)
        {
            GraphicsPath graphicsPath = GetRoundedRectanglePath(control, radius);
            graphics.FillPath(brush, graphicsPath);
        }

        private static GraphicsPath GetRoundedRectanglePath(Control control, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();

            float startAngle = 0;
            Size size = new Size(radius, radius);
            Rectangle drawingRectangle = new Rectangle();
            drawingRectangle.Size = Vector2Helper.Mul(size, 2);
            Size graphicsSize = Vector2Helper.Sub(control.Size, new Size(1, 1));

            for (int i = 0; i < 4; i++)
            {
                drawingRectangle.X = i == 0 || i == 3 ? (graphicsSize.Width - drawingRectangle.Width) : 0;
                drawingRectangle.Y = i < 2 ? (graphicsSize.Height - drawingRectangle.Height) : 0;
                
                graphicsPath.AddArc(drawingRectangle, startAngle, 90);
                startAngle += 90;
            }
            
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
    }

    internal static class Strings
    {
        public const string fileNameExtension = "bcfk";


        public static string saveDirectory
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BCFK";
                Directory.CreateDirectory(path);
                return path + "\\";
            }
        }

        public static bool Contains(string content, string keyword, bool ignoreCase = true)
        {
            return content.IndexOf(keyword, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture) >= 0;
        }
    }
    
    internal static class Colors
    {
        public static readonly Color Black13 = Colors.TheSameRgb(13);
        public static readonly Color Black26 = Colors.TheSameRgb(26);
        public static readonly Color Black38 = Colors.TheSameRgb(38);
        public static readonly Color Black51 = Colors.TheSameRgb(51);
        public static readonly Color Black64 = Colors.TheSameRgb(64);
        public static readonly Color Gray84 = Colors.TheSameRgb(84);
        public static readonly Color Gray114 = Colors.TheSameRgb(114);
        public static readonly Color Gray153 = Colors.TheSameRgb(153);
        public static readonly Color Gray200 = Colors.TheSameRgb(200);
        public static readonly Color White247 = Colors.TheSameRgb(247);

        public static Color TheSameRgb(int value)
        {
            return Color.FromArgb(value, value, value);
        }
    }

    internal class FileHelper
    {
        public static string ReadFile(string filePath)
        {
            string content;
            try
            {
                content = File.ReadAllText(filePath);
            }
            catch
            {
                content = null;
            }

            //decryption
            return content;
        }

        public static void WriteFile(string filePath, string content)
        {
            //encryption

            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception e)
            {
                MessageDialog.Show(e.ToString(), "錯誤");
            }
        }
        
        public static TValue FromJson<TValue>(string jsonContent)
        {
            //decryption

            TValue value;
            try
            {
                value = JsonSerializer.Deserialize<TValue>(jsonContent);
            }
            catch (Exception e)
            {
                value = default(TValue);
            }
            return value;
        }

        public static string ToJson<TValue>(TValue data)
        {
            string jsonContent;
            try
            {
                jsonContent = JsonSerializer.Serialize<TValue>(data);
            }
            catch(Exception e)
            {
                jsonContent = null;
            }

            //encryption
            return jsonContent;
        }
    }

    internal class ProjectData
    {
        #region Constructors
        
        public ProjectData(string fileFullPath)
        {
            lastEditTime = DateTime.Now;
            this.fileFullPath = fileFullPath;
        }

        #endregion
        
        public string fileName;
        public string fileNameNoExtension
        {
            get
            {
                return fileName.Remove(fileName.Length - Strings.fileNameExtension.Length - 1, Strings.fileNameExtension.Length + 1);
            }
            set
            {
                fileName = value + "." + Strings.fileNameExtension;
            }
        }
        public string filePath;
        public string fileFullPath
        {
            get
            {
                return filePath + "\\" + fileName;
            }

            set
            {
                string[] s = value.Split('\\');

                StringBuilder stringBuilder = new StringBuilder(value.Length);

                for (int i = 0; i < s.Length - 1; i++)
                {
                    stringBuilder.Append(s[i]);

                    if (i == s.Length - 2) fileName = s[i + 1];
                    else stringBuilder.Append("\\");
                }

                filePath = stringBuilder.ToString();
            }
        }
        public DateTime lastEditTime { get; set; }
        public bool isFavorite { get; set; }
    
        public CompareResult CompareTo(ProjectData projectData)
        {
            if (this.isFavorite ^ projectData.isFavorite) return this.isFavorite ? CompareResult.More : CompareResult.Less;
            if (this.lastEditTime != projectData.lastEditTime) return this.lastEditTime > projectData.lastEditTime ? CompareResult.More : CompareResult.Less;
            
            int result = this.fileName.CompareTo(projectData.fileName);
            if (result < 0) return CompareResult.More;
            if (result > 0) return CompareResult.Less;

            if(this.fileName.Length < projectData.fileName.Length) return CompareResult.More;
            if(this.fileName.Length > projectData.fileName.Length) return CompareResult.Less;

            return CompareResult.Equal;
        }
    }

    internal enum CompareResult
    {
        More,
        Equal,
        Less,
        NoResult
    }
    
    internal class FormResizer
    {
        public static void AddResizer(Form form)
        {
            FormResizer formResizer = new FormResizer(form);

            Control control = form;
            for (int i = 0; i <= form.Controls.Count; i++)
            {
                control.MouseDown += formResizer.MouseDown;
                control.MouseUp += formResizer.MouseUp;
                control.MouseLeave += formResizer.MouseLeave;
                control.MouseMove += formResizer.MouseMove;

                if (i < form.Controls.Count) control = form.Controls[i];
            }
        }

        internal const int gripRange = 10;

        bool resizing, atTop, atBottom, atLeft, atRight;
        Form form;
        private FormResizer(Form form)
        {
            this.form = form;
        }

        Point lastPoint;
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if(resizing = atTop || atBottom || atLeft || atRight)
                lastPoint = Vector2Helper.PositionInTopLevel(sender as Control, e.Location);
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            form.Cursor = Cursors.Default;
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (form.WindowState == FormWindowState.Maximized) return;

            Control control = sender as Control;
            Point cursorPosition = Vector2Helper.PositionInTopLevel(control, e.Location);

            if (resizing)
            {
                Point location = form.Location;
                Size size = form.Size;
                if (atTop)
                {
                    int deltaY = cursorPosition.Y - lastPoint.Y;

                    if (size.Height - deltaY <= form.MinimumSize.Height) deltaY = size.Height - form.MinimumSize.Height;

                    if (deltaY != 0)
                    {
                        size.Height -= deltaY;
                        location.Y += deltaY;
                        cursorPosition.Y -= deltaY;
                    }
                    else cursorPosition.Y = 0;
                }
                else if (atBottom)
                {
                    size.Height += cursorPosition.Y - lastPoint.Y;

                    if (form.Height == form.MinimumSize.Height) cursorPosition.Y = form.Height;
                }
                if (atLeft)
                {
                    int deltaX = cursorPosition.X - lastPoint.X;

                    if (size.Width - deltaX <= form.MinimumSize.Width) deltaX = size.Width - form.MinimumSize.Width;

                    if(deltaX != 0)
                    {
                        size.Width -= deltaX;
                        location.X += deltaX;
                        cursorPosition.X -= deltaX;
                    }
                    else cursorPosition.X = 0;
                }
                if (atRight)
                {
                    size.Width += cursorPosition.X - lastPoint.X;

                    if (form.Width == form.MinimumSize.Width) cursorPosition.X = form.Width;
                }

                lastPoint = cursorPosition;
                form.Location = location;
                form.Size = size;
                return;
            }

            atTop = cursorPosition.Y < gripRange;
            atBottom = cursorPosition.Y > form.Height - gripRange;
            atLeft = cursorPosition.X < gripRange;
            atRight = cursorPosition.X > form.Width - gripRange;

            bool[] ats = { atTop, atBottom, atLeft, atRight };
            int situation = 0;
            for (int i = 0; i < 4; i++)
            {
                situation <<= 1;
                situation += ats[i] ? 1 : 0;
            }

            switch (situation)
            {
                case 1://atRight
                    form.Cursor = Cursors.SizeWE;
                    break;
                case 2://atLeft
                    form.Cursor = Cursors.SizeWE;
                    break;
                case 4://atBottom
                    form.Cursor = Cursors.SizeNS;
                    break;
                case 5://atBottomRight
                    form.Cursor = Cursors.SizeNWSE;
                    break;
                case 6://atBottomLeft
                    form.Cursor = Cursors.SizeNESW;
                    break;
                case 8://atTop
                    form.Cursor = Cursors.SizeNS;
                    break;
                case 9://atTopRight
                    form.Cursor = Cursors.SizeNESW;
                    break;
                case 10://atTopLeft
                    form.Cursor = Cursors.SizeNWSE;
                    break;
                default: form.Cursor = Cursors.Default;
                    break;
            }
        }
    }

    internal class EventHandlers
    {
        public static void Scrollable_MouseWheel(object sender, MouseEventArgs e)
        {
            Control container = sender as Control;

            if (container.Controls.Count <= 0) return;

            int delta = e.Delta;

            if(e.Delta > 0)
            {
                int maxDelta = int.MaxValue;
                foreach (Control control in container.Controls)
                    if (control.Visible)
                        maxDelta = Math.Min(maxDelta, control.Top);
                maxDelta = -maxDelta;
                if (maxDelta <= 0) return;
                if (delta > maxDelta) delta = maxDelta;
            }
            if (e.Delta < 0)
            {
                int minDelta = 0;
                foreach (Control control in container.Controls)
                    if (control.Visible)
                        minDelta = Math.Max(minDelta, control.Bottom);
                minDelta = container.Height - minDelta;
                if (minDelta >= 0) return;
                if (delta < minDelta) delta = minDelta;
            }

            foreach (Control control in container.Controls)
                if (control.Visible)
                    control.Top += delta;
        }
    }
}
