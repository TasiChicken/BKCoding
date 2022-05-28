using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    internal class BCFK_ContextMenuStrip : ContextMenuStrip
    {
        #region Const

        private const int itemVerticalMargin = 5;

        #endregion

        #region Event

        private void BCFK_ContextMenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            e.Item.Margin = new Padding(0, itemVerticalMargin, 0, itemVerticalMargin);
        }

        #endregion

        #region Class

        private class BCFK_ProfessionalColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground { get { return Colors.Black38; } }
            public override Color MenuBorder { get { return Colors.Black13; } }
            public override Color MenuItemBorder { get { return Colors.Black13; } }
            public override Color MenuItemSelected { get { return Colors.Black64; } }
            public override Color MenuItemSelectedGradientBegin { get { return Colors.Black64; } }
            public override Color MenuItemSelectedGradientEnd { get { return Colors.Black64; } }
            public override Color ImageMarginGradientBegin { get { return Colors.Black51; } }
            public override Color ImageMarginGradientMiddle { get { return Colors.Black51; } }
            public override Color ImageMarginGradientEnd { get { return Colors.Black51; } }
        }

        #endregion

        #region Internal

        internal BCFK_ContextMenuStrip() : base()
        {
            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripProfessionalRenderer(new BCFK_ProfessionalColorTable());
            this.ForeColor = Colors.White247;
            this.ItemAdded += BCFK_ContextMenuStrip_ItemAdded;
        }

        internal BCFK_ContextMenuStrip(IContainer container) : base(container)
        {
            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripProfessionalRenderer(new BCFK_ProfessionalColorTable());
            this.ForeColor = Colors.White247;
            this.ItemAdded += BCFK_ContextMenuStrip_ItemAdded;
        }

        #endregion
    }
}
