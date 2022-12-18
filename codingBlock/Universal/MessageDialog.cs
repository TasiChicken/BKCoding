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
        private Button[] btns;

        #endregion
        
        #region Event

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            btns = new Button[] { _yesBtn, _okBtn, _noBtn, _copyBtn };

            _header.SetTitle(caption);
            _header.HideButtons();
            _contentLbl.Text = content;
            _contentLbl.Location = new Point(padding, _header.Height + padding);
            
            this.Width = _contentLbl.Width + padding * 2;
            this.Height = _contentLbl.Bottom  + _okBtn.Height + padding * 2;
            
            Size size = Vector2Helper.Sub(SystemInformation.WorkingArea.Size, this.Size);
            size = Vector2Helper.Div(size, 2);
            this.Location = new Point(size);

            int top = this.Height - padding - _okBtn.Height;
            int width = this.Width / btns.Length;
            for(int i = 0; i < btns.Length; i++)
            {
                btns[i].Top = top;
                btns[i].Width = width;
                btns[i].Left = width * i;
            }
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    _okBtn.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    _yesBtn.Visible = true;
                    _noBtn.Visible = true;
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

        private void _copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_contentLbl.Text);
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
