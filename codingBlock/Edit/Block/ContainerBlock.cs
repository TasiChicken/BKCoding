using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public class ContainerBlock : CodeBlock
    {
        #region Const

        private const int blank = 20;

        #endregion

        #region Field

        private LinkedList<CodeBlock> childs = new LinkedList<CodeBlock>();

        #endregion

        #region Event

        private void ContainerBlock_LocationChanged(object sender, EventArgs e)
        {

        }

        private void ContainerBlock_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.FillRectangle(brush, blank, height * 2, this.Width - blank, this.Height - height * 3);
                e.Graphics.DrawString("{", this.Font, brush, padding, height + padding);
                e.Graphics.DrawString("}", this.Font, brush, padding, this.Height - height + padding);
            }
        }

        #endregion

        #region Function

        protected override CodeBlock clone(Color color, string code, DragType dragType)
        {
            return new ContainerBlock(color, code, dragType);
        }

        private void transformWithChild()
        {

        }

        private CodeBlock onWhichBlock(Point point)
        {
            foreach (CodeBlock codeBlock in childs)
            {
                if (Vector2Helper.Compare(codeBlock.Location, point) != CompareResult.Less) continue;
                if (Vector2Helper.Compare(codeBlock.Location + codeBlock.Size, point) != CompareResult.More) continue;
                return codeBlock;
            }
            return null;
        }

        #endregion

        #region Internal

        internal ContainerBlock(Color color, string code, DragType dragType = DragType.normal) : base(color, code, dragType)
        {
            this.Height = CodeBlock.height * 3;
            this.LocationChanged += ContainerBlock_LocationChanged;
            this.Paint += ContainerBlock_Paint;
        }

        internal override string GetCode()
        {
            return base.GetCode();
        }

        internal void InsertChlid(CodeBlock codeBlock)
        {
            System.Diagnostics.Debug.WriteLine("insert");
        }

        internal void RemoveChlid(CodeBlock codeBlock)
        {
            System.Diagnostics.Debug.WriteLine("remove");
        }

        internal void PreviewChild(CodeBlock codeBlock)
        {
            System.Diagnostics.Debug.WriteLine("view");
        }

        internal override InputBox OnWhichInputBox(Point point)
        {
            if (point.Y > this.Top + height) return null;
            return base.OnWhichInputBox(point);
        }

        #endregion
    }
}
