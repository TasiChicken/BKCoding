using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace codingBlock
{
    public class CodeBlock : UserControl
    {
        #region Const

        private const int padding = 5;
        private const int height = 36;

        #endregion

        #region Field

        private string code;
        private Label[] codeLbls;
        private InputBox[] inputBoxes;
        private bool enable;
        private bool isDragging = false;
        private Point clickPoint;

        #endregion

        #region Event

        private void CodeBlock_Load(object sender, EventArgs e)
        {
            string[] codes = code.Split('#');

            codeLbls = new Label[codes.Length];
            inputBoxes = new InputBox[codes.Length - 1];

            this.Height = height;
            
            for (int i = 0; i < codeLbls.Length; i++)
            {
                codeLbls[i] = new Label();
                codeLbls[i].MouseDown += CodeBlock_MouseDown;
                codeLbls[i].MouseEnter += CodeBlock_MouseEnter;
                codeLbls[i].MouseLeave += CodeBlock_MouseLeave;
                codeLbls[i].Text = codes[i];
                codeLbls[i].AutoSize = true;
                codeLbls[i].Parent = this;
                codeLbls[i].Top = (height - codeLbls[0].Height) / 2;

                if (!enable) continue;

                codeLbls[i].MouseUp += CodeBlock_MouseUp;
                codeLbls[i].MouseMove += CodeBlock_MouseMove;
            }
            for(int i = 0; i < inputBoxes.Length; i++)
            {
                inputBoxes[i] = new InputBox(this, enable);
                inputBoxes[i].Parent = this;
                inputBoxes[i].Top = (height - inputBoxes[0].Height) / 2;
            }

            codeLbls[0].Left = padding;

            LocateCodeControls(inputBoxes[0]);
        }

        private void CodeBlock_MouseDown(object sender, MouseEventArgs e)
        {
            if (enable)
            {
                clickPoint = e.Location;
                isDragging = true;
                return;
            }

            CodeBlock codeBlock = new CodeBlock(this.BackColor, this.code);
            codeBlock.Font = this.Font;
            codeBlock.ForeColor = this.ForeColor;
            codeBlock.Parent = this.TopLevelControl;
            codeBlock.Location = Vector2Helper.PositionInTopLevel(this);
            this.Capture = false;
            codeBlock.Capture = true;
            codeBlock.CodeBlock_MouseDown(codeBlock, e);
            codeBlock.BringToFront();
        }
        
        private void CodeBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;
            Point point = this.Location;
            point = Vector2Helper.Add(point, e.Location);
            point = Vector2Helper.Sub(point, clickPoint);
            this.Location = point;
        }
        
        private void CodeBlock_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void CodeBlock_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void CodeBlock_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        #endregion

        #region Function


        #endregion

        #region Internal

        internal CodeBlock(Color color, string code, bool enable = true)
        {
            this.enable = enable;
            this.code = code;
            this.BackColor = color;
            this.Load += CodeBlock_Load;
            this.MouseDown += CodeBlock_MouseDown;
            this.MouseEnter += CodeBlock_MouseEnter;
            this.MouseLeave += CodeBlock_MouseLeave;

            if (!enable) return;

            this.MouseUp += CodeBlock_MouseUp;
            this.MouseMove += CodeBlock_MouseMove;
        }

        internal string GetCode()
        {
            return "";
        }

        internal void LocateCodeControls(InputBox inputBox)
        {
            bool isBehind = false;
            for(int i= 0; i < inputBoxes.Length; i++)
            {
                if (inputBox.Equals(inputBoxes[i])) isBehind = true;

                else if (!isBehind) continue;
                
                inputBoxes[i].Left = codeLbls[i].Right;
                codeLbls[i + 1].Left = inputBoxes[i].Right;
            }

            this.Width = codeLbls[codeLbls.Length - 1].Right + padding;
        }

        #endregion
    }
}