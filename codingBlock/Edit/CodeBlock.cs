using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public class CodeBlock : UserControl
    {
        #region Const

        private const int padding = 5;

        #endregion

        #region Field

        private string[] code;
        private string[] values;

        #endregion

        #region Event

        private void CodeBlock_Load(object sender, EventArgs e)
        {
            Point point = new Point(padding, padding);
            for (int i = 0; i < code.Length; i++)
            {
                Label label = new Label();
                label.Text = code[i];
                label.AutoSize = true;
                this.Controls.Add(label);
                label.Location = point;
                point.X += label.Width;

                if (i != code.Length - 1)
                {
                    TextBox textBox = new TextBox();
                    textBox.AutoSize = true;
                    this.Controls.Add(textBox);
                    textBox.Location = point;
                    point.X += textBox.Width;
                }
                else
                {
                    this.Width = label.Right + padding;
                    this.Height = label.Bottom + padding;
                }
            }
            
        }

        #endregion

        #region Internal

        internal CodeBlock(Color color, string code)
        {
            this.code = code.Split('#');
            this.Load += CodeBlock_Load;
            this.Name = "CodeBlock";
            this.BackColor = color;
        }

        internal string GetCode()
        {
            return code.ToString();
        }

        #endregion
    }
}