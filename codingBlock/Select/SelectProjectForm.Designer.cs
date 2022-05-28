using System.Windows.Forms;

namespace codingBlock
{
    partial class SelectProjectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this._newProject = new System.Windows.Forms.Button();
            this._openProjectBtn = new System.Windows.Forms.Button();
            this._searchBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._searchContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._header = new Header();
            this._mainPnl = new System.Windows.Forms.Panel();
            this._projectDatasPnl = new System.Windows.Forms.Panel();
            this._searchBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this._mainPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 36F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.label2.Location = new System.Drawing.Point(35, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = "常用專案";
            // 
            // _newProject
            // 
            this._newProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._newProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._newProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this._newProject.FlatAppearance.BorderSize = 0;
            this._newProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._newProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this._newProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._newProject.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._newProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._newProject.Location = new System.Drawing.Point(0, 98);
            this._newProject.Margin = new System.Windows.Forms.Padding(2);
            this._newProject.Name = "_newProject";
            this._newProject.Size = new System.Drawing.Size(250, 50);
            this._newProject.TabIndex = 2;
            this._newProject.Text = "建立新專案";
            this._newProject.UseVisualStyleBackColor = false;
            this._newProject.Click += new System.EventHandler(this._newProject_Click);
            // 
            // _openProjectBtn
            // 
            this._openProjectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._openProjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._openProjectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._openProjectBtn.FlatAppearance.BorderSize = 0;
            this._openProjectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._openProjectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this._openProjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._openProjectBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20.25F);
            this._openProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._openProjectBtn.Location = new System.Drawing.Point(0, 192);
            this._openProjectBtn.Margin = new System.Windows.Forms.Padding(2);
            this._openProjectBtn.Name = "_openProjectBtn";
            this._openProjectBtn.Size = new System.Drawing.Size(250, 50);
            this._openProjectBtn.TabIndex = 3;
            this._openProjectBtn.Text = "開啟舊專案";
            this._openProjectBtn.UseVisualStyleBackColor = false;
            this._openProjectBtn.Click += new System.EventHandler(this._openProjectBtn_Click);
            // 
            // _searchBar
            // 
            this._searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._searchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._searchBar.Controls.Add(this.label1);
            this._searchBar.Controls.Add(this._searchContent);
            this._searchBar.Location = new System.Drawing.Point(284, 20);
            this._searchBar.Margin = new System.Windows.Forms.Padding(2);
            this._searchBar.Name = "_searchBar";
            this._searchBar.Padding = new System.Windows.Forms.Padding(3);
            this._searchBar.Size = new System.Drawing.Size(392, 50);
            this._searchBar.TabIndex = 5;
            this._searchBar.Paint += new System.Windows.Forms.PaintEventHandler(this._searchBar_Paint);
            this._searchBar.Resize += new System.EventHandler(this._searchBar_Resize);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Image = global::codingBlock.Properties.Resources.search;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 44);
            this.label1.TabIndex = 7;
            this.label1.Click += new System.EventHandler(this.search);
            // 
            // _searchContent
            // 
            this._searchContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._searchContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._searchContent.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F);
            this._searchContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this._searchContent.Location = new System.Drawing.Point(47, 12);
            this._searchContent.Margin = new System.Windows.Forms.Padding(2);
            this._searchContent.Name = "_searchContent";
            this._searchContent.Size = new System.Drawing.Size(540, 31);
            this._searchContent.TabIndex = 6;
            this._searchContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this._searchContent_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._newProject);
            this.panel1.Controls.Add(this._openProjectBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(715, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 451);
            this.panel1.TabIndex = 8;
            // 
            // _header
            // 
            this._header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this._header.Dock = System.Windows.Forms.DockStyle.Top;
            this._header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this._header.Location = new System.Drawing.Point(0, 0);
            this._header.Margin = new System.Windows.Forms.Padding(4);
            this._header.Name = "_header";
            this._header.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this._header.Size = new System.Drawing.Size(1000, 49);
            this._header.TabIndex = 6;
            // 
            // _mainPnl
            // 
            this._mainPnl.Controls.Add(this._projectDatasPnl);
            this._mainPnl.Controls.Add(this.label2);
            this._mainPnl.Controls.Add(this._searchBar);
            this._mainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPnl.Location = new System.Drawing.Point(0, 49);
            this._mainPnl.Margin = new System.Windows.Forms.Padding(2);
            this._mainPnl.Name = "_mainPnl";
            this._mainPnl.Size = new System.Drawing.Size(715, 451);
            this._mainPnl.TabIndex = 9;
            // 
            // _projectDatasPnl
            // 
            this._projectDatasPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectDatasPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this._projectDatasPnl.Location = new System.Drawing.Point(35, 98);
            this._projectDatasPnl.Margin = new System.Windows.Forms.Padding(2);
            this._projectDatasPnl.Name = "_projectDatasPnl";
            this._projectDatasPnl.Size = new System.Drawing.Size(641, 316);
            this._projectDatasPnl.TabIndex = 8;
            this._projectDatasPnl.Resize += new System.EventHandler(this._projectDatasPnl_Resize);
            // 
            // SelectProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this._mainPnl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._header);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::codingBlock.Properties.Resources.Icon;
            this.MinimumSize = new System.Drawing.Size(1000, 400);
            this.Name = "SelectProjectForm";
            this.Text = "BKCoding";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectProjectForm_FormClosing);
            this.Load += new System.EventHandler(this.SelectProjectForm_Load);
            this._searchBar.ResumeLayout(false);
            this._searchBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this._mainPnl.ResumeLayout(false);
            this._mainPnl.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        private Label label2;
        private Button _newProject;
        private Button _openProjectBtn;
        private Panel _searchBar;
        private TextBox _searchContent;
        private Panel panel1;
        private Panel _mainPnl;
        private Panel _projectDatasPnl;
        private Header _header;
        private Label label1;
    }
}