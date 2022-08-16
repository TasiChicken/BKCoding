﻿using System;
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

        private void InputBox_LocationChanged(object sender, EventArgs e)
        {
            MoveDataBlock();
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

                value.BringToFront();
                value.Location = Vector2Helper.PositionInTopLevel(this);
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
            this.LocationChanged += InputBox_LocationChanged;
        }

        internal InputBox(CodeBlock parent, SaveData saveData)
        {
            this.parentBlock = parent;

            InitializeComponent();

            this.Parent = parent;

            this._textBox.TextChanged += _textBox_TextChanged;
            this._textBox.Enter += _textBox_Enter;
            this._textBox.Leave += _textBox_Leave;
            this.LocationChanged += InputBox_LocationChanged;

            if (!saveData.dataBlockSaveData.HasValue) return;

            this.dataBlock = new DataBlock(saveData.dataBlockSaveData.Value, this);
        }

        internal void PreviewBlock(DataBlock dataBlock)
        {
            tranformWithDataBlock(dataBlock);

            this.BackColor = dataBlock == null ? Color.Transparent : Colors.Gray114;
        }

        internal void MoveDataBlock()
        {
            if (dataBlock == null) return;
            dataBlock.BringToFront();
            dataBlock.Location = Vector2Helper.PositionInTopLevel(this);
        }

        internal new void BringToFront()
        {
            base.BringToFront();

            if (dataBlock == null) return;
            dataBlock.BringToFront();
        }

        internal string GetCode()
        {
            return _dataBlock == null ? _textBox.Text : _dataBlock.GetCode();
        }

        internal SaveData CreateSaveData()
        {
            InputBox.SaveData data = new InputBox.SaveData(_textBox.Text);

            if (this.dataBlock != null)
                data.dataBlockSaveData = this.dataBlock.CreateSaveData();

            return data;
        }

        [Serializable]
        internal struct SaveData
        {
            public SaveData(string text)
            {
                this.text = text;
                this.dataBlockSaveData = null;
            }

            public string text { get; set; }
            public CodeBlock.SaveData? dataBlockSaveData { get; set; }
        }

        #endregion
    }
}
