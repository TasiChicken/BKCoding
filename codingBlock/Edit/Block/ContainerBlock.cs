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
        #region Event

        #endregion

        #region Function

        protected override CodeBlock clone(Color color, string code)
        {
            return new ContainerBlock(color, code);
        }

        #endregion

        #region Internal

        internal ContainerBlock(Color color, string code, bool enable = true) : base(color, code, enable)
        {

        }

        internal override string GetCode()
        {
            return base.GetCode();
        }

        #endregion
    }
}
