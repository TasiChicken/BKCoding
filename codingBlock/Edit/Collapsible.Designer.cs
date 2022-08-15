namespace codingBlock.Edit
{
    partial class Collapsible
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
            this._opener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _opener
            // 
            this._opener.AutoSize = true;
            this._opener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._opener.Dock = System.Windows.Forms.DockStyle.Top;
            this._opener.FlatAppearance.BorderSize = 0;
            this._opener.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._opener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this._opener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._opener.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._opener.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._opener.Location = new System.Drawing.Point(0, 0);
            this._opener.Name = "_opener";
            this._opener.Size = new System.Drawing.Size(150, 30);
            this._opener.TabIndex = 0;
            this._opener.Text = "button1";
            this._opener.UseVisualStyleBackColor = false;
            this._opener.Click += new System.EventHandler(this._opener_Click);
            // 
            // Collapsible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._opener);
            this.Name = "Collapsible";
            this.Load += new System.EventHandler(this.Collapsible_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _opener;
    }
}
