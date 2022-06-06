using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codingBlock
{
    public class ContainerBlock : CodeBlock
    {
        #region Const

        private const int blank = 20;
        private const int curlyBracketWidth = 50;

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
            e.Graphics.Clear(Colors.White247);

            using (Brush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, 0, 0, this.Width, height);
                e.Graphics.FillRectangle(brush, 0, 0, blank, this.Height);
                e.Graphics.FillRectangle(brush, 0, height, curlyBracketWidth, height);
                e.Graphics.FillRectangle(brush, 0, this.Height - height, curlyBracketWidth, height);
            }
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString("{", this.Font, brush, padding, height + padding);
                e.Graphics.DrawString("}", this.Font, brush, padding, this.Height - height + padding);
            }
        }

        #endregion

        #region Function

        protected override CodeBlock clone(Color color, string code)
        {
            return new ContainerBlock(color, code);
        }

        private void transformWithChild()
        {

        }

        #endregion

        #region Internal

        internal ContainerBlock(Color color, string code, bool enable = true) : base(color, code, enable)
        {
            this.Height = CodeBlock.height * 3;
            this.LocationChanged += ContainerBlock_LocationChanged;
            this.Paint += ContainerBlock_Paint;
        }

        internal override string GetCode()
        {
            return base.GetCode();
        }

        #endregion
    }
}
