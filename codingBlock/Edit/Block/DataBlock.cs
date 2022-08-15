using System.Windows.Forms;
using System.Drawing;
using System;

namespace codingBlock
{
    internal class DataBlock : CodeBlock
    {
        #region Field

        private InputBox inputBox = null;

        #endregion

        #region Event

        private void DataBlock_Resize(object sender, EventArgs e)
        {
            if(inputBox == null) return;
            inputBox.dataBlock = this;
        }

        #endregion

        #region Function

        protected override void leftConatiner()
        {
            if (inputBox == null) return;

            inputBox.PreviewBlock(null);
            inputBox.dataBlock = null;
            inputBox = null;
        }

        protected override void detectConatiner()
        {
            CodeBlock codeBlock = EditForm.instance.OnWhichBlock(this.Location);

            InputBox inputBox = codeBlock == null ? null : codeBlock.OnWhichInputBox(this.Location);

            if (inputBox == this.inputBox) return;

            if (this.inputBox != null) this.inputBox.PreviewBlock(null);

            this.inputBox = inputBox;

            if (inputBox != null) inputBox.PreviewBlock(this);
        }

        protected override void enterConatiner()
        {
            if (inputBox == null) return;

            inputBox.dataBlock = this;
        }

        protected override CodeBlock clone(Color color, string code, DragType dragType)
        {
            return new DataBlock(color, code, dragType);
        }

        #endregion

        #region Internal

        internal DataBlock(Color color, string code, DragType dragType = DragType.normal) : base(color, code, dragType)
        {
            this.Resize += DataBlock_Resize;
        }

        internal override string GetCode()
        {
            return base.GetCode();
        }
        
        internal override bool hasParent()
        {
            return inputBox != null;
        }

        #endregion
    }
}
