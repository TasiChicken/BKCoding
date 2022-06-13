using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public class CodeBlock : UserControl
    {
        #region Const

        protected const int padding = 5;
        protected static readonly Type containerType = typeof(ContainerBlock);

        #endregion

        #region Field

        private DragType dragType;
        private string code;
        private Label[] codeLbls;
        private InputBox[] inputBoxes;
        private Point clickPoint;
        private bool isDragging = false;
        private bool _onTrashCan = true;
        protected EditForm editForm;
        private ContainerBlock _parentBlock;
        protected ContainerBlock parentBlock
        {
            get
            {
                return _parentBlock;
            }
            set
            {
                if (_parentBlock != value && _parentBlock != null) _parentBlock.RemoveChild(this);
                _parentBlock = value;
            }
        }

        #endregion

        #region Event

        private void CodeBlock_Load(object sender, EventArgs e)
        {
            this.editForm = this.TopLevelControl as EditForm;

            string[] codes = code.Split('#');

            codeLbls = new Label[codes.Length];
            bool unmoveable = dragType != DragType.normal;

            for (int i = 0; i < codeLbls.Length; i++)
            {
                codeLbls[i] = new Label();
                codeLbls[i].MouseDown += CodeBlock_MouseDown;
                codeLbls[i].Text = codes[i];
                codeLbls[i].AutoSize = true;
                codeLbls[i].Parent = this;
                codeLbls[i].Top = (height - codeLbls[i].Height) / 2;

                if (unmoveable) continue;

                codeLbls[i].MouseUp += CodeBlock_MouseUp;
                codeLbls[i].MouseMove += CodeBlock_MouseMove;
            }

            codeLbls[0].Left = padding;

            if (codeLbls.Length == 1)
            {
                this.Width = codeLbls[0].Right + padding;
                return;
            }

            inputBoxes = new InputBox[codes.Length - 1];
            bool inputable = dragType != DragType.clone;

            for (int i = 0; i < inputBoxes.Length; i++)
            {
                inputBoxes[i] = new InputBox(this, inputable);
                inputBoxes[i].Top = (height - inputBoxes[i].Height) / 2;
            }

            LocateCodeControls(inputBoxes[0]);
        }

        private void CodeBlock_MouseDown(object sender, MouseEventArgs e)
        {
            if (dragType == DragType.clone)
            {
                CodeBlock codeBlock = clone(this.BackColor, this.code, DragType.normal);
                codeBlock.Font = this.Font;
                codeBlock.ForeColor = this.ForeColor;
                codeBlock.Parent = editForm;
                codeBlock.Location = Vector2Helper.PositionInTopLevel(this);
                this.Capture = false;
                codeBlock.Capture = true;
                codeBlock.CodeBlock_MouseDown(codeBlock, e);
                codeBlock.BringToFront();
                return;
            }

            leftConatiner();
            clickPoint = e.Location;
            isDragging = true;
            this.Parent = editForm;
            this.BringToFront();
        }

        private void CodeBlock_MouseMove(object sender, MouseEventArgs e)
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

            detectConatiner();
        }

        private void CodeBlock_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            if (_onTrashCan)
            {
                editForm.ThrowAwayBlock(this);
                editForm.VisionTrashCan(false);
                return;
            }

            enterConatiner();
            this.BringToFront();
        }

        #endregion

        #region Function

        protected virtual CodeBlock clone(Color color, string code, DragType dragType)
        {
            return new CodeBlock(color, code, dragType);
        }

        protected virtual void leftConatiner()
        {
        }

        protected virtual void detectConatiner()
        {
            CodeBlock codeBlock = editForm.OnWhichBlock(this.Location);

            if (codeBlock == null || !codeBlock.GetType().Equals(containerType))
            {
                parentBlock = null;
                return;
            }

            ContainerBlock containerBlock = (codeBlock as ContainerBlock).OnWhichConatinerBlock(this);
            
            if (parentBlock != containerBlock)
            {
                parentBlock = containerBlock;
                detectConatiner();
                return;
            }

            parentBlock.InsertChild(this, true);
        }

        protected virtual void enterConatiner()
        {
            if (parentBlock == null) return;

            parentBlock.InsertChild(this);
        }

        #endregion

        #region Internal

        internal const int height = 36;

        internal int index;

        protected internal enum DragType
        {
            normal, unmovable, clone
        }

        internal CodeBlock(Color color, string code, DragType dragType = DragType.normal)
        {
            this.dragType = dragType;
            this.code = code;
            this.BackColor = color;
            this.Height = height;

            this.Load += CodeBlock_Load;

            if (dragType == DragType.unmovable) return;

            this.MouseDown += CodeBlock_MouseDown;

            if (dragType == DragType.clone) return;

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
            for (int i = 0; i < inputBoxes.Length; i++)
            {
                if (inputBox.Equals(inputBoxes[i])) isBehind = true;

                else if (!isBehind) continue;

                inputBoxes[i].Left = codeLbls[i].Right;
                codeLbls[i + 1].Left = inputBoxes[i].Right;
            }

            this.Width = codeLbls[codeLbls.Length - 1].Right + padding;
        }

        internal virtual InputBox OnWhichInputBox(Point point)
        {
            if (dragType == DragType.clone) return null;

            int x = point.X - Vector2Helper.PositionInTopLevel(this).X;

            foreach (InputBox inputBox in inputBoxes)
            {
                if (inputBox.Left > x) return null;
                if (inputBox.Right < x) continue;
                if (inputBox.dataBlock == null) return inputBox;
                return inputBox.dataBlock.OnWhichInputBox(point);
            }

            return null;
        }

        internal new virtual void BringToFront()
        {
            base.BringToFront();
        }

        #endregion
    }
}