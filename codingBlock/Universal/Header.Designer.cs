using System.Windows.Forms;

namespace codingBlock
{
    partial class Header
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
            this._minWindowBtn = new System.Windows.Forms.Button();
            this._sizeWindowBtn = new System.Windows.Forms.Button();
            this._exitBtn = new System.Windows.Forms.Button();
            this._titlelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _minWindowBtn
            // 
            this._minWindowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._minWindowBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this._minWindowBtn.FlatAppearance.BorderSize = 0;
            this._minWindowBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._minWindowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._minWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._minWindowBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._minWindowBtn.ForeColor = System.Drawing.Color.White;
            this._minWindowBtn.Image = global::codingBlock.Properties.Resources.minWin;
            this._minWindowBtn.Location = new System.Drawing.Point(917, 4);
            this._minWindowBtn.Margin = new System.Windows.Forms.Padding(4);
            this._minWindowBtn.Name = "_minWindowBtn";
            this._minWindowBtn.Size = new System.Drawing.Size(74, 41);
            this._minWindowBtn.TabIndex = 8;
            this._minWindowBtn.UseVisualStyleBackColor = false;
            this._minWindowBtn.Click += new System.EventHandler(this._minWindowBtn_Click);
            // 
            // _sizeWindowBtn
            // 
            this._sizeWindowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._sizeWindowBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this._sizeWindowBtn.FlatAppearance.BorderSize = 0;
            this._sizeWindowBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._sizeWindowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._sizeWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._sizeWindowBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._sizeWindowBtn.ForeColor = System.Drawing.Color.White;
            this._sizeWindowBtn.Image = global::codingBlock.Properties.Resources.maxWin;
            this._sizeWindowBtn.Location = new System.Drawing.Point(991, 4);
            this._sizeWindowBtn.Margin = new System.Windows.Forms.Padding(4);
            this._sizeWindowBtn.Name = "_sizeWindowBtn";
            this._sizeWindowBtn.Size = new System.Drawing.Size(74, 41);
            this._sizeWindowBtn.TabIndex = 7;
            this._sizeWindowBtn.UseVisualStyleBackColor = false;
            this._sizeWindowBtn.Click += new System.EventHandler(this._sizeWindowBtn_Click);
            // 
            // _exitBtn
            // 
            this._exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._exitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this._exitBtn.FlatAppearance.BorderSize = 0;
            this._exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this._exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this._exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._exitBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._exitBtn.ForeColor = System.Drawing.Color.White;
            this._exitBtn.Image = global::codingBlock.Properties.Resources.exit;
            this._exitBtn.Location = new System.Drawing.Point(1065, 4);
            this._exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this._exitBtn.Name = "_exitBtn";
            this._exitBtn.Size = new System.Drawing.Size(74, 41);
            this._exitBtn.TabIndex = 6;
            this._exitBtn.UseVisualStyleBackColor = false;
            this._exitBtn.Click += new System.EventHandler(this._exitBtn_Click);
            // 
            // _titlelbl
            // 
            this._titlelbl.AutoSize = true;
            this._titlelbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F);
            this._titlelbl.Location = new System.Drawing.Point(12, 12);
            this._titlelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._titlelbl.Name = "_titlelbl";
            this._titlelbl.Size = new System.Drawing.Size(109, 26);
            this._titlelbl.TabIndex = 5;
            this._titlelbl.Text = "BKCoding";
            this._titlelbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._titlelbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            this._titlelbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
            this._titlelbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Header_MouseUp);
            // 
            // Header
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.Controls.Add(this._minWindowBtn);
            this.Controls.Add(this._sizeWindowBtn);
            this.Controls.Add(this._exitBtn);
            this.Controls.Add(this._titlelbl);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Name = "Header";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(1143, 49);
            this.Load += new System.EventHandler(this.Header_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Header_MouseUp);
            this.Resize += new System.EventHandler(this.Header_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button _minWindowBtn;
        private Button _sizeWindowBtn;
        private Button _exitBtn;
        private Label _titlelbl;
    }
}
