using System.Windows.Forms;

namespace codingBlock
{
    partial class BlockTypeButton
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._imgLbl = new System.Windows.Forms.Label();
            this._textLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _imgLbl
            // 
            this._imgLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._imgLbl.Location = new System.Drawing.Point(0, 61);
            this._imgLbl.Margin = new System.Windows.Forms.Padding(0);
            this._imgLbl.Name = "_imgLbl";
            this._imgLbl.Size = new System.Drawing.Size(64, 3);
            this._imgLbl.TabIndex = 0;
            this._imgLbl.Click += new System.EventHandler(this.BlockTypeButton_Click);
            // 
            // _textLbl
            // 
            this._textLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textLbl.Location = new System.Drawing.Point(0, 0);
            this._textLbl.Margin = new System.Windows.Forms.Padding(0);
            this._textLbl.Name = "_textLbl";
            this._textLbl.Size = new System.Drawing.Size(64, 61);
            this._textLbl.TabIndex = 1;
            this._textLbl.Text = "Text";
            this._textLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._textLbl.Click += new System.EventHandler(this.BlockTypeButton_Click);
            this._textLbl.MouseEnter += new System.EventHandler(this._textLbl_MouseEnter);
            this._textLbl.MouseLeave += new System.EventHandler(this._textLbl_MouseLeave);
            // 
            // BlockTypeButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Colors.Black13;
            this.Controls.Add(this._textLbl);
            this.Controls.Add(this._imgLbl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = Colors.White247;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BlockTypeButton";
            this.Size = new System.Drawing.Size(64, 64);
            this.Click += new System.EventHandler(this.BlockTypeButton_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private Label _imgLbl;
        private Label _textLbl;
    }
}
