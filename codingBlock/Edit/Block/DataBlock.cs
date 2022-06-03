using System.Windows.Forms;
using System.Drawing;
using System;

namespace codingBlock
{
    internal class DataBlock : CodeBlock
    {
        #region Field

        private bool onInputBox = false;
        private InputBox inputBox = null;

        #endregion

        #region Event

        protected override void CodeBlock_MouseDown(object sender, MouseEventArgs e)
        {
            base.CodeBlock_MouseDown(sender, e);

            if (inputBox == null) return;

            inputBox.dataBlock = null;
            inputBox = null;
        }

        protected override void CodeBlock_MouseMove(object sender, MouseEventArgs e)
        {
            base.CodeBlock_MouseMove(sender, e);

            if (!isDragging) return;

            InputBox inputBox = nearbyInputBox();
            onInputBox = inputBox != null;
            
            if(onInputBox)
            {
                this.inputBox = inputBox;
                inputBox.PreviewBlock(this);
                return;
            }


            if (this.inputBox == null) return;
            
            this.inputBox.PreviewBlock(null);
            this.inputBox = null;

        }

        protected override void CodeBlock_MouseUp(object sender, MouseEventArgs e)
        {
            base.CodeBlock_MouseUp(sender, e);

            if (inputBox == null) return;

            inputBox.dataBlock = this;
        }

        private void DataBlock_Resize(object sender, EventArgs e)
        {
            if(inputBox == null) return;
            inputBox.dataBlock = this;
        }

        #endregion

        #region Function

        private InputBox nearbyInputBox()
        {
            CodeBlock codeBlock = editForm.NearestBlock(this.Location);
            if (codeBlock == null) return null;

            return codeBlock.NearbyInputBox(this.Left - codeBlock.Left - codeBlock.Parent.Left);
        }

        protected override CodeBlock clone(Color color, string code)
        {
            return new DataBlock(color, code);
        }

        #endregion

        #region Internal

        internal DataBlock(Color color, string code, bool enable = true) : base(color, code, enable)
        {
            this.Resize += DataBlock_Resize;
        }

        internal override string GetCode()
        {
            return base.GetCode();
        }

        #endregion
    }
}
