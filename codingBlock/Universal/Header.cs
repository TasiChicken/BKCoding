using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class Header : UserControl
    {
        #region Field

        private Form form;
        private bool _isMaxWindow;
        private bool isDragging = false;
        private Point clickPoint;
        private Point LeftTop = new Point(FormResizer.gripRange, FormResizer.gripRange);
        private Point RightBottom;
        private ExitAction _exitAction;
        
        #endregion

        #region Event

        private void Header_Load(object sender, EventArgs e)
        {
            form = (this.Parent as Form);
            _exitAction = closeForm;
            isMaxWindow = form.WindowState == FormWindowState.Maximized;
        }
        
        private void Header_Resize(object sender, EventArgs e)
        {
            _titlelbl.Top = (this.Height - _titlelbl.Height) / 2;
        }

        #region Button

        private void _exitBtn_Click(object sender, EventArgs e)
        {
            _exitAction();
        }

        private void _minWindowBtn_Click(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        private void _sizeWindowBtn_Click(object sender, EventArgs e)
        {
            isMaxWindow = !isMaxWindow;
        }

        #endregion

        #region Moveable
        
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            clickPoint = e.Location;
            RightBottom = new Point(this.Width - FormResizer.gripRange, this.Height);
            isDragging = (Vector2Helper.Compare(clickPoint, LeftTop) == CompareResult.More) && (Vector2Helper.Compare(clickPoint, RightBottom) == CompareResult.Less);
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;
            Point point = this.TopLevelControl.Location;
            point = Vector2Helper.Add(point, e.Location);
            point = Vector2Helper.Sub(point, clickPoint);
            this.TopLevelControl.Location = point;
        }

        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        #endregion
        
        #endregion

        #region Function

        private void closeForm()
        {
            if (form != null) form.Close();
        }

        #endregion

        #region Internal
        
        internal Header()
        {
            InitializeComponent();
        }

        internal bool isMaxWindow
        {
            get
            {
                return _isMaxWindow;
            }
            set
            {
                _isMaxWindow = value;

                string imageName;
                if (_isMaxWindow)
                {
                    imageName = "oriWin";
                    form.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    imageName = "maxWin";
                    form.WindowState = FormWindowState.Normal;
                }

                _sizeWindowBtn.Image = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            }
        }
        
        internal delegate void ExitAction();

        internal void SetTitle(string text)
        {
            _titlelbl.Text = text;
        }

        internal void HideButtons()
        {
            _minWindowBtn.Hide();
            _sizeWindowBtn.Hide();
        }

        internal void SetExitBtnAction(ExitAction action)
        {
            this._exitAction = action;
        }

        #endregion
    }
}
