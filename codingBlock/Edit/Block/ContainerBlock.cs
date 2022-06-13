﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace codingBlock
{
    public class ContainerBlock : CodeBlock
    {
        #region Const

        private const int blank = 20;

        #endregion

        #region Field

        private LinkedList<CodeBlock> children = new LinkedList<CodeBlock>();

        #endregion

        #region Event

        private void ContainerBlock_LocationChanged(object sender, EventArgs e)
        {
            if (children.Count == 0) return;

            LocateChlidren(children.First.Value, true);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing) foreach (CodeBlock block in children) editForm.ThrowAwayBlock(block);
            base.Dispose(disposing);
        }

        private CodeBlock onWhichBlock(Point point)
        {
            if (point.X < this.Left + blank) return null;

            int idealTop = this.Top + height * 2;
            for(LinkedListNode<CodeBlock> node = children.First; node != null; node = node.Next)
            {
                if (node.Value.Top != idealTop && node.Next != null)
                {
                    idealTop = node.Next.Value.Top;
                    continue;
                }
                if (node.Value.Top > point.Y) break;
                if (node.Value.Bottom < point.Y)
                {
                    idealTop = node.Value.Bottom;
                    continue;
                }
                return node.Value;
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

        internal void InsertChild(CodeBlock codeBlock, bool preview = false)
        {
            LinkedListNode<CodeBlock> node = children.Find(codeBlock);
            
            if (node != null)
            {
                if (!preview)
                {
                    codeBlock.Left = this.Left + blank;
                    LocateChlidren(codeBlock);
                    return;
                }

                int minTop = node == children.First ? this.Top : node.Previous.Value.Bottom;
                int maxTop;
                if (node == children.Last) maxTop = this.Bottom;
                else
                {
                    maxTop = node.Next.Value.Top;
                    if (node.Next.Value.GetType().Equals(containerType)) maxTop += height;
                }
                if (codeBlock.Top >= minTop && codeBlock.Top <= maxTop) return;
                RemoveChild(codeBlock);
            }
                    
            node = children.First;
            while (node != null)
            {
                if (node.Value.Bottom > codeBlock.Top)
                {
                    node = children.AddBefore(node, codeBlock);
                    break;
                }
                node = node.Next;
            }
            if (node == null) children.AddLast(codeBlock);
            
            if (!preview) codeBlock.Left = this.Left + blank;
            
            LocateChlidren(codeBlock);
        }

        internal void RemoveChild(CodeBlock codeBlock)
        {
            LinkedListNode<CodeBlock> node = children.Find(codeBlock);

            if (node == null) return;

            if (node == children.Last)
            {
                children.Remove(node);
                LocateChlidren(this);
                return;
            }

            node = node.Next;
            children.Remove(codeBlock);
            LocateChlidren(node.Value);
        }

        internal override InputBox OnWhichInputBox(Point point)
        {
            if (point.Y <= this.Top + height) return base.OnWhichInputBox(point);
            CodeBlock codeBlock = onWhichBlock(point);
            if (codeBlock == null) return null;
            return codeBlock.OnWhichInputBox(point);
        }
        
        internal override void BringToFront()
        {
            base.BringToFront();
            foreach (CodeBlock child in children) child.BringToFront();
        }
    
        internal void LocateChlidren(CodeBlock codeBlock, bool changeLeft = false)
        {
            LinkedListNode<CodeBlock> node = children.Find(codeBlock);

            while (node != null)
            {
                node.Value.Top = node == children.First ? this.Top + height * 2 : node.Previous.Value.Bottom;
                if (changeLeft) node.Value.Left = this.Left + blank;
                node = node.Next;
            }

            this.Height = children.Count == 0 ? height * 3 : children.Last.Value.Bottom - this.Top + height;
            this.Refresh();

            if (this.parentBlock != null) parentBlock.LocateChlidren(this);
        }
        
        internal ContainerBlock OnWhichConatinerBlock(CodeBlock codeBlock)
        {
            CodeBlock coveredBlock = onWhichBlock(codeBlock.Location);
            if (coveredBlock != null) Debug.WriteLine(coveredBlock.Location);
            if (coveredBlock == null || coveredBlock == codeBlock || coveredBlock.Top > codeBlock.Top - height) return this;
            if (coveredBlock.GetType().Equals(containerType)) return (coveredBlock as ContainerBlock).OnWhichConatinerBlock(coveredBlock);
            return this;
        }

        #endregion
    }
}
