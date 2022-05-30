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
    public class CodeBlockContainer : CodeBlock
    {
        private void CodeBlockContainer_Load(object sender, EventArgs e)
        {

        }

        #region Internal

        internal CodeBlockContainer(Color color, string code) : base(color, code)
        {
            this.Load += CodeBlockContainer_Load;
        }

        #endregion
    }
}
