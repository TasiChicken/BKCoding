using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class MessageDialog : Form
    {
        #region Const

        private const int borderSize = 2;
        private const int padding = 15;

        #endregion

        #region Constructor

        private MessageDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Field

        private string content;
        private string caption;
        private MessageBoxButtons buttons;

        #endregion
        
        #region Event

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            _header.SetTitle(caption);
            _header.HideButtons();
            _contentLbl.Text = content;
            _contentLbl.Location = new Point(padding, _header.Height + padding);
            
            this.Width = _contentLbl.Width + padding * 2;
            this.Height = _contentLbl.Bottom  + _okBtn.Height + padding * 2;
            
            Size size = Vector2Helper.Sub(SystemInformation.WorkingArea.Size, this.Size);
            size = Vector2Helper.Div(size, 2);
            this.Location = new Point(size);

            _okBtn.Top =_noBtn.Top = _yesBtn.Top = this.Height - padding - _okBtn.Height;
            int width = this.Width / 3;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    _okBtn.Visible = true;
                    
                    _okBtn.Width = width;
                    
                    if (width < _okBtn.MinimumSize.Width) _okBtn.Left = (this.Width - _okBtn.Width) / 2;
                    else _okBtn.Left = width;
                    break;
                case MessageBoxButtons.YesNo:
                    _yesBtn.Visible = true;
                    _noBtn.Visible = true;
                    
                    _yesBtn.Width = _noBtn.Width = width;
                    
                    int margin = width < _yesBtn.MinimumSize.Width ? (this.Width - _yesBtn.Width * 2) / 3 : this.Width / 9;
                    _yesBtn.Left = margin;
                    _noBtn.Left = _yesBtn.Right + margin;
                    break;
            }
        }

        private void _yesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void _okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void _noBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void MessageDialog_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            Point p1 = new Point(), p2 = new Point(0, this.Height - 1);

            using(Pen pen = new Pen(Colors.Black13, borderSize))
            {
                for (int i = 0; i < 3; i++)
                {
                    e.Graphics.DrawLine(pen, p1, p2);
                    p1 = p2;
                    if (i == 0) p2.X = this.Width - 1;
                    else p2.Y = 0;
                }
            }
        }

        #endregion

        #region Internal

        internal static DialogResult Show(string content, string caption, MessageBoxButtons buttons)
        {
            MessageDialog messageDialog = new MessageDialog();
            messageDialog.content = content;
            messageDialog.caption = caption;
            messageDialog.buttons = buttons;
            return messageDialog.ShowDialog();
        }

        internal static DialogResult Show(string content, MessageBoxButtons buttons)
        {
            MessageDialog messageDialog = new MessageDialog();
            messageDialog.content = content;
            messageDialog.caption = "";
            messageDialog.buttons = buttons;
            return messageDialog.ShowDialog();
        }

        internal static DialogResult Show(string content, string caption)
        {
            MessageDialog messageDialog = new MessageDialog();
            messageDialog.content = content;
            messageDialog.caption = caption;
            messageDialog.buttons = MessageBoxButtons.OK;
            return messageDialog.ShowDialog();
        }

        internal static DialogResult Show(string content)
        {
            MessageDialog messageDialog = new MessageDialog();
            messageDialog.content = content;
            messageDialog.caption = "";
            messageDialog.buttons = MessageBoxButtons.OK;
            return messageDialog.ShowDialog();
        }

        #endregion
    }
}
