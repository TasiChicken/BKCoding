namespace codingBlock
{
    partial class InputBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(2, 2);
            this._textBox.Margin = new System.Windows.Forms.Padding(2);
            this._textBox.MinimumSize = new System.Drawing.Size(20, 22);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(20, 22);
            this._textBox.TabIndex = 0;
            this._textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._textBox.Resize += new System.EventHandler(this._textBox_Resize);
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._textBox);
            this.Name = "InputBox";
            this.Size = new System.Drawing.Size(24, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBox;
    }
}
