using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class BlockTypeButton : UserControl
    {
        #region Const

        private const int checkedLine = 8;
        private const int unCheckedLine = 3;

        #endregion

        #region Field

        private int index;
        private EditForm editForm;
        private bool _isChecked;

        #endregion

        #region Events

        private void BlockTypeButton_Click(object sender, EventArgs e)
        {
            editForm.ChangeBlockType(index);
        }

        private void _textLbl_MouseEnter(object sender, EventArgs e)
        {
            if (isChecked) return;
            _textLbl.BackColor = Colors.Black51;
        }

        private void _textLbl_MouseLeave(object sender, EventArgs e)
        {
            _textLbl.BackColor = this.BackColor;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            _textLbl.BackColor = this.BackColor;
        }

        #endregion

        #region Internal

        internal bool isChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                this.BackColor = value ? Colors.Black38 : Parent.BackColor;
                this._imgLbl.Height = value ? checkedLine : unCheckedLine;
            }
        }

        internal BlockTypeButton(int index, EditForm editForm, Color color, string text)
        {
            this.index = index;
            this.editForm = editForm;

            InitializeComponent();

            this._textLbl.Text = text;
            this._imgLbl.BackColor = color;
        }

        #endregion
    }
}
