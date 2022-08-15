using System;
using System.Windows.Forms;

namespace codingBlock.Edit
{
    public partial class Collapsible : UserControl
    {
        #region Field

        private bool _isOpened = false;

        #endregion

        #region Event

        private void _opener_Click(object sender, EventArgs e)
        {
            isOpened = !_isOpened;
        }

        private void Collapsible_Load(object sender, EventArgs e)
        {
            this.Height = _opener.Height;
        }

        #endregion

        #region Internal

        internal Collapsible(string name)
        {
            InitializeComponent();
            _opener.Text = name;
        }

        internal bool isOpened
        {
            set
            {
                this.Height = value ? Controls[Controls.Count - 1].Bottom : _opener.Height;
                _isOpened = value;
            }
        }

        #endregion
    }
}
