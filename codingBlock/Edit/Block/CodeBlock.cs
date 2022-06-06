using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace codingBlock
{
    public class CodeBlock : UserControl
    {
        #region Const

        protected const int padding = 5;
        protected const int height = 36;

        #endregion

        #region Field

        private string code;
        private Label[] codeLbls;
        private InputBox[] inputBoxes;
        private bool enable;
        private Point clickPoint;
        private bool _onTrashCan = true;
        protected EditForm editForm;
        protected bool isDragging = false;

        #endregion

        #region Event

        private void CodeBlock_Load(object sender, EventArgs e)
        {
            this.editForm = this.TopLevelControl as EditForm;

            string[] codes = code.Split('#');

            codeLbls = new Label[codes.Length];
            
            for (int i = 0; i < codeLbls.Length; i++)
            {
                codeLbls[i] = new Label();
                codeLbls[i].MouseDown += CodeBlock_MouseDown;
                codeLbls[i].Text = codes[i];
                codeLbls[i].AutoSize = true;
                codeLbls[i].Parent = this;
                codeLbls[i].Top = (height - codeLbls[i].Height) / 2;

                if (!enable) continue;

                codeLbls[i].MouseUp += CodeBlock_MouseUp;
                codeLbls[i].MouseMove += CodeBlock_MouseMove;
            }

            codeLbls[0].Left = padding;
            
            inputBoxes = new InputBox[codes.Length - 1];

            if (inputBoxes.Length == 0) return;

            for(int i = 0; i < inputBoxes.Length; i++)
            {
                inputBoxes[i] = new InputBox(this, enable);
                inputBoxes[i].Top = (height - inputBoxes[i].Height) / 2;
            }

            LocateCodeControls(inputBoxes[0]);
        }

        protected virtual void CodeBlock_MouseDown(object sender, MouseEventArgs e)
        {
            if (enable)
            {
                clickPoint = e.Location;
                isDragging = true;
                this.Parent = editForm;
                this.BringToFront();
                return;
            }

            CodeBlock codeBlock = clone(this.BackColor, this.code);
            codeBlock.Font = this.Font;
            codeBlock.ForeColor = this.ForeColor;
            codeBlock.Parent = editForm;
            codeBlock.Location = Vector2Helper.PositionInTopLevel(this);
            this.Capture = false;
            codeBlock.Capture = true;
            codeBlock.CodeBlock_MouseDown(codeBlock, e);
            codeBlock.BringToFront();
        }

        protected virtual void CodeBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;
            Point point = this.Location;
            point = Vector2Helper.Add(point, e.Location);
            point = Vector2Helper.Sub(point, clickPoint);
            this.Location = point;

            bool onTrashCan = !editForm.InCodeRegion(this);
            if (onTrashCan ^ _onTrashCan)
            {
                editForm.VisionTrashCan(onTrashCan);
                _onTrashCan = onTrashCan;
            }
        }

        protected virtual void CodeBlock_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            if (_onTrashCan)
            {
                editForm.VisionTrashCan(false);
                this.Dispose();
                return;
            }

            editForm.IntoCodePnl(this);
            this.BringToFront();
        }

        #endregion

        #region Function

        protected virtual CodeBlock clone(Color color, string code)
        {
            return new CodeBlock(color, code);
        }

        #endregion

        #region Internal

        internal CodeBlock(Color color, string code, bool enable = true)
        {
            this.enable = enable;
            this.code = code;
            this.BackColor = color;
            this.Height = height;

            this.Load += CodeBlock_Load;
            this.MouseDown += CodeBlock_MouseDown;
            
            if (!enable) return;

            this.MouseUp += CodeBlock_MouseUp;
            this.MouseMove += CodeBlock_MouseMove;
        }

        internal virtual string GetCode()
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

        internal Point BottomRight()
        {
            return Vector2Helper.Add(this.Location, new Point(this.Width, height));
        }

        internal InputBox NearbyInputBox(int x)
        {
            Debug.WriteLine("again");
            Debug.WriteLine(x);

            for(int i = 0; i < inputBoxes.Length; i++)
            {
                Debug.WriteLine(inputBoxes[i].Left);
                if (inputBoxes[i].Left > x) return null;
                if (inputBoxes[i].Right < x) continue;
                if (inputBoxes[i].dataBlock != null) return inputBoxes[i].dataBlock.NearbyInputBox(x - inputBoxes[i].Left);
                return inputBoxes[i];
            }

            return null;
        }

        #endregion
    }
}