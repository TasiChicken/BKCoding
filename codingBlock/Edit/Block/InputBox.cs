using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class InputBox : UserControl
    {
        #region Field

        private readonly CodeBlock parentBlock;
        private DataBlock _dataBlock;

        #endregion

        #region Event

        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            Graphics g = _textBox.CreateGraphics();
            int textWidth = (int)g.MeasureString(_textBox.Text, _textBox.Font).Width + 1;

            _textBox.Width = textWidth + _textBox.Margin.Horizontal;
        }

        private void _textBox_Resize(object sender, EventArgs e)
        {
            this.Size = Vector2Helper.Add(_textBox.Size, _textBox.Margin.Size);
            parentBlock.LocateCodeControls(this);
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

        #region Function

        private void tranformWithDataBlock(DataBlock dataBlock)
        {
            if (dataBlock == null)
            {
                _textBox_TextChanged(null, null);
                this.Top = (CodeBlock.height - this.Height) / 2;
                return;
            }

            _textBox.Width = dataBlock.Width - _textBox.Margin.Horizontal;
            this.Height = dataBlock.Height;
            this.Top = 0;
        }

        #endregion

        #region Internal

        internal DataBlock dataBlock
        {
            get
            {
                return _dataBlock;
            }
            set
            {
                this._dataBlock = value;

                tranformWithDataBlock(value);

                _textBox.Visible = value == null;

                if (value == null) return;

                value.Parent = this;
                value.Location = new Point();
            }
        }

        internal InputBox(CodeBlock parent, bool enable)
        {
            this.parentBlock = parent;

            InitializeComponent();

            this.Parent = parent;

            _textBox.Enabled = enable;
            if (!enable) return;

            this._textBox.TextChanged += _textBox_TextChanged;
            this._textBox.Enter += _textBox_Enter;
            this._textBox.Leave += _textBox_Leave;
        }
        
        internal void PreviewBlock(DataBlock dataBlock)
        {
            tranformWithDataBlock(dataBlock);

            this.BackColor = dataBlock == null ? Color.Transparent : Colors.Gray114;
        }

        internal string GetCode()
        {
            return _dataBlock == null ? _textBox.Text : _dataBlock.GetCode();
        }

        #endregion
    }
}
