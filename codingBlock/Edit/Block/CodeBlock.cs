using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public class CodeBlock : UserControl
    {
        #region Const

        protected const int padding = 5;

        #endregion

        #region Field

        private DragType dragType;
        private string code;
        private Label[] codeLbls;
        private InputBox[] inputBoxes;
        private InputBox.SaveData[] inputBlocksSaveData;
        private Point clickPoint;
        private bool isDragging = false;
        private bool _onTrashCan = true;
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
                inputBoxes[i] = inputBlocksSaveData == null ? new InputBox(this, inputable) : new InputBox(this, inputBlocksSaveData[i]);
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
                codeBlock.Parent = EditForm.instance;
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
            this.Parent = EditForm.instance;
            this.BringToFront();
        }

        private void CodeBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;
            Point point = this.Location;
            point = Vector2Helper.Add(point, e.Location);
            point = Vector2Helper.Sub(point, clickPoint);
            this.Location = point;

            bool onTrashCan = !EditForm.instance.InCodeRegion(this);
            if (onTrashCan ^ _onTrashCan)
            {
                EditForm.instance.VisionTrashCan(onTrashCan);
                _onTrashCan = onTrashCan;
            }

            detectConatiner();
        }

        private void CodeBlock_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            if (_onTrashCan)
            {
                EditForm.instance.ThrowAwayBlock(this);
                EditForm.instance.VisionTrashCan(false);
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
            CodeBlock codeBlock = EditForm.instance.OnWhichBlock(this.Location);

            if (codeBlock == null || !codeBlock.GetType().Equals(typeof(ContainerBlock)))
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

        internal CodeBlock(SaveData saveData, ContainerBlock parentBlock)
        {
            this.dragType = saveData.dragType;
            this.code = saveData.code;
            this.BackColor = saveData.color.ToColor();
            this.Height = height;
            this.inputBlocksSaveData = saveData.inputBlocksSaveData;

            this.Load += CodeBlock_Load;

            if (dragType == DragType.unmovable) return;

            this.MouseDown += CodeBlock_MouseDown;

            if (dragType == DragType.clone) return;

            this.MouseUp += CodeBlock_MouseUp;
            this.MouseMove += CodeBlock_MouseMove;

            this.parentBlock = parentBlock;
        }

        internal virtual SaveData CreateSaveData()
        {
            if (this.inputBoxes == null)
                return new SaveData(this.GetType(), this.BackColor, this.code, this.dragType, this.Location, null);

            if (inputBlocksSaveData == null)
                inputBlocksSaveData = new InputBox.SaveData[inputBoxes.Length];

            for(int i = 0; i < inputBlocksSaveData.Length; i++)
                inputBlocksSaveData[i] = inputBoxes[i].CreateSaveData();
            
            return new SaveData(this.GetType(), this.BackColor, this.code, this.dragType, this.Location, inputBlocksSaveData);
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

            if (inputBoxes != null) 
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

        [Serializable]
        internal struct SaveData
        {
            public SaveData(Type type, Color color, string code, DragType dragType, Point location, InputBox.SaveData[] inputBlocksSaveData, SaveData[] codeBlocksSaveData = null)
            {
                if (type.Equals(typeof(CodeBlock)))
                    this.blockType = BlockType.code;
                else if (type.Equals(typeof(ContainerBlock)))
                    this.blockType = BlockType.container;
                else
                    this.blockType = BlockType.data;

                this.color = new M_Color(color);
                this.code = code;
                this.location = location;
                this.inputBlocksSaveData = inputBlocksSaveData;
                this.childrenSaveData = codeBlocksSaveData;
                this.dragType = dragType;
            }

            public BlockType blockType { get; set; }
            public M_Color color { get; set; }
            public string code { get; set; }
            public Point location { get; set; }
            public InputBox.SaveData[] inputBlocksSaveData { get; set; }
            public SaveData[] childrenSaveData { get; set; }
            public DragType dragType { get; set; }

            public CodeBlock ToCodeBlock(ContainerBlock parentBlock = null)
            {
                switch (blockType)
                {
                    case BlockType.code:
                        return new CodeBlock(this, parentBlock);
                    case BlockType.container:
                        return new ContainerBlock(this, parentBlock);
                    case BlockType.data:
                        return new DataBlock(color.ToColor(), code);
                }

                return new CodeBlock(this, parentBlock);
            }

            public enum BlockType
            {
                code, container, data
            }

            public struct M_Color
            {
                public M_Color(Color color)
                {
                    this.A = color.A;
                    this.R = color.R;
                    this.G = color.G;
                    this.B = color.B;
                }

                public byte A { get; set; }
                public byte R { get; set; }
                public byte G { get; set; }
                public byte B { get; set; }

                public Color ToColor()
                {
                    return Color.FromArgb(this.A, this.R, this.G, this.B);
                }
            }
        }

        internal virtual bool hasParent()
        {
            return parentBlock != null;
        }

        #endregion
    }
}