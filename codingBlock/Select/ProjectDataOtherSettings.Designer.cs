using System.Windows.Forms;

namespace codingBlock
{
    partial class ProjectDataOtherSettings
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
            this._showInExplorerBtn = new System.Windows.Forms.Button();
            this._removeFromListBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _showInExplorerBtn
            // 
            this._showInExplorerBtn.FlatAppearance.BorderSize = 0;
            this._showInExplorerBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._showInExplorerBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._showInExplorerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._showInExplorerBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._showInExplorerBtn.Location = new System.Drawing.Point(5, 5);
            this._showInExplorerBtn.Margin = new System.Windows.Forms.Padding(5);
            this._showInExplorerBtn.Name = "_showInExplorerBtn";
            this._showInExplorerBtn.Padding = new System.Windows.Forms.Padding(5);
            this._showInExplorerBtn.Size = new System.Drawing.Size(200, 50);
            this._showInExplorerBtn.TabIndex = 1;
            this._showInExplorerBtn.Text = "在檔案總管中開啟";
            this._showInExplorerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._showInExplorerBtn.UseVisualStyleBackColor = true;
            this._showInExplorerBtn.Click += new System.EventHandler(this._showInExplorerBtn_Click);
            // 
            // _removeFromListBtn
            // 
            this._removeFromListBtn.FlatAppearance.BorderSize = 0;
            this._removeFromListBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._removeFromListBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._removeFromListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._removeFromListBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._removeFromListBtn.Location = new System.Drawing.Point(5, 65);
            this._removeFromListBtn.Margin = new System.Windows.Forms.Padding(5);
            this._removeFromListBtn.Name = "_removeFromListBtn";
            this._removeFromListBtn.Padding = new System.Windows.Forms.Padding(5);
            this._removeFromListBtn.Size = new System.Drawing.Size(200, 50);
            this._removeFromListBtn.TabIndex = 2;
            this._removeFromListBtn.Text = "從常用專案中移除";
            this._removeFromListBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._removeFromListBtn.UseVisualStyleBackColor = true;
            this._removeFromListBtn.Click += new System.EventHandler(this._removeFromListBtn_Click);
            // 
            // ProjectDataOtherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._removeFromListBtn);
            this.Controls.Add(this._showInExplorerBtn);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProjectDataOtherSettings";
            this.Size = new System.Drawing.Size(210, 120);
            this.Resize += new System.EventHandler(this.ProjectDataOtherSettings_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private Button _showInExplorerBtn;
        private Button _removeFromListBtn;
    }
}
