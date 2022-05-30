using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class InputBox : UserControl
    {
        #region Field

        CodeBlock codeBlock;

        #endregion

        #region Event

        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            Graphics g = _textBox.CreateGraphics();
            int textWidth = (int)g.MeasureString(_textBox.Text, _textBox.Font).Width + 1;

            _textBox.Width = textWidth + _textBox.Margin.Horizontal;
            codeBlock.LocateCodeControls(this);
        }

        private void _textBox_Resize(object sender, EventArgs e)
        {
            this.Size = Vector2Helper.Add(_textBox.Size, _textBox.Margin.Size);
        }

        private void _textBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Colors.Gray114;
        }

        private void _textBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        #endregion

        #region Internal
        
        internal InputBox(CodeBlock codeBlock, bool enable)
        {
            this.codeBlock = codeBlock;
            InitializeComponent();

            _textBox.Enabled = enable;
            if (!enable) return;

            this._textBox.TextChanged += _textBox_TextChanged;
            this._textBox.Enter += _textBox_Enter;
            this._textBox.Leave += _textBox_Leave;
        }

        #endregion
    }
}
