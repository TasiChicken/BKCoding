using System.Windows.Forms;

namespace codingBlock
{
    partial class EditForm
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
            this._blockTypePnl = new System.Windows.Forms.Panel();
            this._menuStripPnl = new System.Windows.Forms.Panel();
            this._playBtn = new System.Windows.Forms.Button();
            this._editMenuBtn = new System.Windows.Forms.Button();
            this._fileMenuBtn = new System.Windows.Forms.Button();
            this._saveFileCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._saveNewFileCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._exportCFileCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._exportExeFileCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._copyCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._pastCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._cutCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteCmsi = new System.Windows.Forms.ToolStripMenuItem();
            this._blocksPnl = new System.Windows.Forms.Panel();
            this._trashCan = new System.Windows.Forms.PictureBox();
            this._splitter = new System.Windows.Forms.Splitter();
            this._header = new Header();
            this._fileCms = new BCFK_ContextMenuStrip();
            this._editCms = new BCFK_ContextMenuStrip();
            this._menuStripPnl.SuspendLayout();
            this._blocksPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trashCan)).BeginInit();
            this._fileCms.SuspendLayout();
            this._editCms.SuspendLayout();
            this.SuspendLayout();
            // 
            // _blockTypePnl
            // 
            this._blockTypePnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this._blockTypePnl.Dock = System.Windows.Forms.DockStyle.Left;
            this._blockTypePnl.Location = new System.Drawing.Point(0, 76);
            this._blockTypePnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._blockTypePnl.Name = "_blockTypePnl";
            this._blockTypePnl.Size = new System.Drawing.Size(55, 428);
            this._blockTypePnl.TabIndex = 2;
            // 
            // _menuStripPnl
            // 
            this._menuStripPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this._menuStripPnl.Controls.Add(this._playBtn);
            this._menuStripPnl.Controls.Add(this._editMenuBtn);
            this._menuStripPnl.Controls.Add(this._fileMenuBtn);
            this._menuStripPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this._menuStripPnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this._menuStripPnl.Location = new System.Drawing.Point(0, 39);
            this._menuStripPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._menuStripPnl.Name = "_menuStripPnl";
            this._menuStripPnl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._menuStripPnl.Size = new System.Drawing.Size(960, 37);
            this._menuStripPnl.TabIndex = 1;
            // 
            // _playBtn
            // 
            this._playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._playBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this._playBtn.FlatAppearance.BorderSize = 0;
            this._playBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._playBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._playBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._playBtn.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this._playBtn.Location = new System.Drawing.Point(887, 4);
            this._playBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._playBtn.Name = "_playBtn";
            this._playBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._playBtn.Size = new System.Drawing.Size(69, 29);
            this._playBtn.TabIndex = 4;
            this._playBtn.Text = "執行";
            this._playBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._playBtn.UseVisualStyleBackColor = true;
            this._playBtn.Click += new System.EventHandler(this._playBtn_Click);
            this._playBtn.Paint += new System.Windows.Forms.PaintEventHandler(this._playBtn_Paint);
            // 
            // _editMenuBtn
            // 
            this._editMenuBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this._editMenuBtn.FlatAppearance.BorderSize = 0;
            this._editMenuBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._editMenuBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._editMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._editMenuBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._editMenuBtn.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this._editMenuBtn.Location = new System.Drawing.Point(54, 4);
            this._editMenuBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._editMenuBtn.Name = "_editMenuBtn";
            this._editMenuBtn.Size = new System.Drawing.Size(50, 29);
            this._editMenuBtn.TabIndex = 3;
            this._editMenuBtn.Text = "編輯";
            this._editMenuBtn.UseVisualStyleBackColor = true;
            this._editMenuBtn.Click += new System.EventHandler(this._editMenuBtn_Click);
            // 
            // _fileMenuBtn
            // 
            this._fileMenuBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this._fileMenuBtn.FlatAppearance.BorderSize = 0;
            this._fileMenuBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._fileMenuBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._fileMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._fileMenuBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._fileMenuBtn.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this._fileMenuBtn.Location = new System.Drawing.Point(4, 4);
            this._fileMenuBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._fileMenuBtn.Name = "_fileMenuBtn";
            this._fileMenuBtn.Size = new System.Drawing.Size(50, 29);
            this._fileMenuBtn.TabIndex = 2;
            this._fileMenuBtn.Text = "檔案";
            this._fileMenuBtn.UseVisualStyleBackColor = true;
            this._fileMenuBtn.Click += new System.EventHandler(this._fileMenuBtn_Click);
            // 
            // _saveFileCmsi
            // 
            this._saveFileCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._saveFileCmsi.Name = "_saveFileCmsi";
            this._saveFileCmsi.Size = new System.Drawing.Size(173, 24);
            this._saveFileCmsi.Text = "儲存專案";
            this._saveFileCmsi.Click += new System.EventHandler(this._saveFileCmsi_Click);
            // 
            // _saveNewFileCmsi
            // 
            this._saveNewFileCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._saveNewFileCmsi.Name = "_saveNewFileCmsi";
            this._saveNewFileCmsi.Size = new System.Drawing.Size(173, 24);
            this._saveNewFileCmsi.Text = "另存新檔";
            this._saveNewFileCmsi.Click += new System.EventHandler(this._saveNewFileCmsi_Click);
            // 
            // _exportCFileCmsi
            // 
            this._exportCFileCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._exportCFileCmsi.Name = "_exportCFileCmsi";
            this._exportCFileCmsi.Size = new System.Drawing.Size(173, 24);
            this._exportCFileCmsi.Text = "匯出(*.c)檔";
            this._exportCFileCmsi.Click += new System.EventHandler(this._exportCFileCmsi_Click);
            // 
            // _exportExeFileCmsi
            // 
            this._exportExeFileCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._exportExeFileCmsi.Name = "_exportExeFileCmsi";
            this._exportExeFileCmsi.Size = new System.Drawing.Size(173, 24);
            this._exportExeFileCmsi.Text = "匯出(*.exe)檔";
            this._exportExeFileCmsi.Click += new System.EventHandler(this._exportExeFileCmsi_Click);
            // 
            // _copyCmsi
            // 
            this._copyCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._copyCmsi.Name = "_copyCmsi";
            this._copyCmsi.Size = new System.Drawing.Size(110, 24);
            this._copyCmsi.Text = "複製";
            this._copyCmsi.Click += new System.EventHandler(this._copyCmsi_Click);
            // 
            // _pastCmsi
            // 
            this._pastCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._pastCmsi.Name = "_pastCmsi";
            this._pastCmsi.Size = new System.Drawing.Size(110, 24);
            this._pastCmsi.Text = "貼上";
            this._pastCmsi.Click += new System.EventHandler(this._pastCmsi_Click);
            // 
            // _cutCmsi
            // 
            this._cutCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._cutCmsi.Name = "_cutCmsi";
            this._cutCmsi.Size = new System.Drawing.Size(110, 24);
            this._cutCmsi.Text = "剪下";
            this._cutCmsi.Click += new System.EventHandler(this._cutCmsi_Click);
            // 
            // _deleteCmsi
            // 
            this._deleteCmsi.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this._deleteCmsi.Name = "_deleteCmsi";
            this._deleteCmsi.Size = new System.Drawing.Size(110, 24);
            this._deleteCmsi.Text = "刪除";
            this._deleteCmsi.Click += new System.EventHandler(this._deleteCmsi_Click);
            // 
            // _blocksPnl
            // 
            this._blocksPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._blocksPnl.Controls.Add(this._trashCan);
            this._blocksPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this._blocksPnl.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blocksPnl.ForeColor = System.Drawing.Color.White;
            this._blocksPnl.Location = new System.Drawing.Point(55, 76);
            this._blocksPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._blocksPnl.Name = "_blocksPnl";
            this._blocksPnl.Size = new System.Drawing.Size(200, 428);
            this._blocksPnl.TabIndex = 3;
            this._blocksPnl.Resize += new System.EventHandler(this._blocksPnl_Resize);
            // 
            // _trashCan
            // 
            this._trashCan.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this._trashCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this._trashCan.Image = global::codingBlock.Properties.Resources.trashCan;
            this._trashCan.Location = new System.Drawing.Point(0, 0);
            this._trashCan.Name = "_trashCan";
            this._trashCan.Size = new System.Drawing.Size(200, 428);
            this._trashCan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._trashCan.TabIndex = 0;
            this._trashCan.TabStop = false;
            this._trashCan.Visible = false;
            // 
            // _splitter
            // 
            this._splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._splitter.Location = new System.Drawing.Point(255, 76);
            this._splitter.Name = "_splitter";
            this._splitter.Size = new System.Drawing.Size(8, 428);
            this._splitter.TabIndex = 4;
            this._splitter.TabStop = false;
            // 
            // _header
            // 
            this._header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this._header.Location = new System.Drawing.Point(0, 0);
            this._header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._header.Name = "_header";
            this._header.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._header.Size = new System.Drawing.Size(960, 39);
            this._header.TabIndex = 0;
            // 
            // _fileCms
            // 
            this._fileCms.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._fileCms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._fileCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveFileCmsi,
            this._saveNewFileCmsi,
            this._exportCFileCmsi,
            this._exportExeFileCmsi});
            this._fileCms.Name = "_fileCms";
            this._fileCms.ShowItemToolTips = false;
            this._fileCms.Size = new System.Drawing.Size(174, 140);
            // 
            // _editCms
            // 
            this._editCms.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this._editCms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._editCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyCmsi,
            this._pastCmsi,
            this._cutCmsi,
            this._deleteCmsi});
            this._editCms.Name = "_editCms";
            this._editCms.ShowItemToolTips = false;
            this._editCms.Size = new System.Drawing.Size(111, 140);
            // 
            // EditForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(960, 504);
            this.Controls.Add(this._splitter);
            this.Controls.Add(this._blocksPnl);
            this.Controls.Add(this._blockTypePnl);
            this.Controls.Add(this._menuStripPnl);
            this.Controls.Add(this._header);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::codingBlock.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(686, 360);
            this.Name = "EditForm";
            this.Text = "BKCoding";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this._menuStripPnl.ResumeLayout(false);
            this._blocksPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._trashCan)).EndInit();
            this._fileCms.ResumeLayout(false);
            this._editCms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Header _header;
        private Panel _blockTypePnl;
        private Panel _menuStripPnl;
        private Button _fileMenuBtn;
        private Button _playBtn;
        private Button _editMenuBtn;
        private Panel _blocksPnl;
        private ToolStripMenuItem _saveFileCmsi;
        private ToolStripMenuItem _saveNewFileCmsi;
        private ToolStripMenuItem _exportCFileCmsi;
        private ToolStripMenuItem _exportExeFileCmsi;
        private ToolStripMenuItem _copyCmsi;
        private ToolStripMenuItem _pastCmsi;
        private ToolStripMenuItem _cutCmsi;
        private ToolStripMenuItem _deleteCmsi;
        private BCFK_ContextMenuStrip _fileCms;
        private BCFK_ContextMenuStrip _editCms;
        private Splitter _splitter;
        private PictureBox _trashCan;
    }
}