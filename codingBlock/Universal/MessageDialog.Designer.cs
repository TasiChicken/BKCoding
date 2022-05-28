﻿using System.Windows.Forms;

namespace codingBlock
{
    partial class MessageDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._header = new Header();
            this._contentLbl = new System.Windows.Forms.Label();
            this._okBtn = new System.Windows.Forms.Button();
            this._yesBtn = new System.Windows.Forms.Button();
            this._noBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _header
            // 
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.Location = new System.Drawing.Point(0, 0);
            this._header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._header.Name = "_header";
            this._header.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._header.Size = new System.Drawing.Size(656, 39);
            this._header.TabIndex = 0;
            // 
            // _contentLbl
            // 
            this._contentLbl.AutoSize = true;
            this._contentLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F);
            this._contentLbl.ForeColor = Colors.White247;
            this._contentLbl.Location = new System.Drawing.Point(13, 51);
            this._contentLbl.Name = "_contentLbl";
            this._contentLbl.Size = new System.Drawing.Size(0, 26);
            this._contentLbl.TabIndex = 1;
            // 
            // _okBtn
            // 
            this._okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._okBtn.BackColor = Colors.Black51;
            this._okBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._okBtn.FlatAppearance.BorderSize = 0;
            this._okBtn.FlatAppearance.MouseDownBackColor = Colors.Black64;
            this._okBtn.FlatAppearance.MouseOverBackColor = Colors.Gray84;
            this._okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._okBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._okBtn.ForeColor = Colors.White247;
            this._okBtn.Location = new System.Drawing.Point(257, 148);
            this._okBtn.Margin = new System.Windows.Forms.Padding(2);
            this._okBtn.MinimumSize = new System.Drawing.Size(69, 40);
            this._okBtn.Name = "_okBtn";
            this._okBtn.Size = new System.Drawing.Size(86, 40);
            this._okBtn.TabIndex = 3;
            this._okBtn.Text = "確定";
            this._okBtn.UseVisualStyleBackColor = false;
            this._okBtn.Visible = false;
            this._okBtn.Click += new System.EventHandler(this._okBtn_Click);
            // 
            // _yesBtn
            // 
            this._yesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._yesBtn.BackColor = Colors.Black51;
            this._yesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._yesBtn.FlatAppearance.BorderSize = 0;
            this._yesBtn.FlatAppearance.MouseDownBackColor = Colors.Black64;
            this._yesBtn.FlatAppearance.MouseOverBackColor = Colors.Gray84;
            this._yesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._yesBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._yesBtn.ForeColor =Colors.White247;
            this._yesBtn.Location = new System.Drawing.Point(53, 148);
            this._yesBtn.Margin = new System.Windows.Forms.Padding(2);
            this._yesBtn.MinimumSize = new System.Drawing.Size(43, 40);
            this._yesBtn.Name = "_yesBtn";
            this._yesBtn.Size = new System.Drawing.Size(86, 40);
            this._yesBtn.TabIndex = 4;
            this._yesBtn.Text = "是";
            this._yesBtn.UseVisualStyleBackColor = false;
            this._yesBtn.Visible = false;
            this._yesBtn.Click += new System.EventHandler(this._yesBtn_Click);
            // 
            // _noBtn
            // 
            this._noBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._noBtn.BackColor = Colors.Black51;
            this._noBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._noBtn.FlatAppearance.BorderSize = 0;
            this._noBtn.FlatAppearance.MouseDownBackColor = Colors.Black64;
            this._noBtn.FlatAppearance.MouseOverBackColor = Colors.Gray84;
            this._noBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._noBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._noBtn.ForeColor = Colors.White247;
            this._noBtn.Location = new System.Drawing.Point(473, 148);
            this._noBtn.Margin = new System.Windows.Forms.Padding(2);
            this._noBtn.MinimumSize = new System.Drawing.Size(43, 40);
            this._noBtn.Name = "_noBtn";
            this._noBtn.Size = new System.Drawing.Size(86, 40);
            this._noBtn.TabIndex = 5;
            this._noBtn.Text = "否";
            this._noBtn.UseVisualStyleBackColor = false;
            this._noBtn.Visible = false;
            this._noBtn.Click += new System.EventHandler(this._noBtn_Click);
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Colors.Black26;
            this.ClientSize = new System.Drawing.Size(656, 197);
            this.Controls.Add(this._noBtn);
            this.Controls.Add(this._yesBtn);
            this.Controls.Add(this._okBtn);
            this.Controls.Add(this._contentLbl);
            this.Controls.Add(this._header);
            this.ForeColor = Colors.Gray153;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::codingBlock.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(343, 160);
            this.Name = "MessageDialog";
            this.Text = "MessageDialog";
            this.Load += new System.EventHandler(this.MessageDialog_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageDialog_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Header _header;
        private Label _contentLbl;
        private Button _okBtn;
        private Button _yesBtn;
        private Button _noBtn;
    }
}