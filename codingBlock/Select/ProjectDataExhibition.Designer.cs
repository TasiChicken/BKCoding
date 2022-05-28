using System.Windows.Forms;

namespace codingBlock
{
    partial class ProjectDataExhibition
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
            this._fileNameLbl = new System.Windows.Forms.Label();
            this._filePathLbl = new System.Windows.Forms.Label();
            this._othersBtn = new System.Windows.Forms.Button();
            this._starMark = new System.Windows.Forms.PictureBox();
            this._lastEditTimeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._starMark)).BeginInit();
            this.SuspendLayout();
            // 
            // _fileNameLbl
            // 
            this._fileNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._fileNameLbl.Font = new System.Drawing.Font("細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._fileNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._fileNameLbl.Location = new System.Drawing.Point(80, 15);
            this._fileNameLbl.Name = "_fileNameLbl";
            this._fileNameLbl.Size = new System.Drawing.Size(120, 30);
            this._fileNameLbl.TabIndex = 0;
            this._fileNameLbl.Text = "FileName";
            this._fileNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._fileNameLbl.Click += new System.EventHandler(this.ProjectDataExhibition_Click);
            this._fileNameLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectDataExhibition_MouseDown);
            this._fileNameLbl.MouseEnter += new System.EventHandler(this.ProjectDataExhibition_MouseEnter);
            this._fileNameLbl.MouseLeave += new System.EventHandler(this.ProjectDataExhibition_MouseLeave);
            // 
            // _filePathLbl
            // 
            this._filePathLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._filePathLbl.AutoSize = true;
            this._filePathLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this._filePathLbl.Location = new System.Drawing.Point(80, 50);
            this._filePathLbl.Name = "_filePathLbl";
            this._filePathLbl.Size = new System.Drawing.Size(240, 15);
            this._filePathLbl.TabIndex = 1;
            this._filePathLbl.Text = "filePath:\\filePath\\filePath\\filePath\\filePath";
            this._filePathLbl.Click += new System.EventHandler(this.ProjectDataExhibition_Click);
            this._filePathLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectDataExhibition_MouseDown);
            this._filePathLbl.MouseEnter += new System.EventHandler(this.ProjectDataExhibition_MouseEnter);
            this._filePathLbl.MouseLeave += new System.EventHandler(this.ProjectDataExhibition_MouseLeave);
            // 
            // _othersBtn
            // 
            this._othersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._othersBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this._othersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._othersBtn.FlatAppearance.BorderSize = 0;
            this._othersBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._othersBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this._othersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._othersBtn.Image = global::codingBlock.Properties.Resources.other;
            this._othersBtn.Location = new System.Drawing.Point(513, 15);
            this._othersBtn.Name = "_othersBtn";
            this._othersBtn.Size = new System.Drawing.Size(50, 50);
            this._othersBtn.TabIndex = 3;
            this._othersBtn.UseVisualStyleBackColor = false;
            this._othersBtn.Click += new System.EventHandler(this._othersBtn_Click);
            // 
            // _starMark
            // 
            this._starMark.Image = global::codingBlock.Properties.Resources.grayStar;
            this._starMark.Location = new System.Drawing.Point(15, 15);
            this._starMark.Name = "_starMark";
            this._starMark.Size = new System.Drawing.Size(50, 50);
            this._starMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._starMark.TabIndex = 5;
            this._starMark.TabStop = false;
            this._starMark.Click += new System.EventHandler(this._starMark_Click);
            this._starMark.MouseEnter += new System.EventHandler(this._starMark_MouseEnter);
            this._starMark.MouseLeave += new System.EventHandler(this._starMark_MouseLeave);
            // 
            // _lastEditTimeLbl
            // 
            this._lastEditTimeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lastEditTimeLbl.AutoSize = true;
            this._lastEditTimeLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lastEditTimeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this._lastEditTimeLbl.Location = new System.Drawing.Point(215, 15);
            this._lastEditTimeLbl.Name = "_lastEditTimeLbl";
            this._lastEditTimeLbl.Size = new System.Drawing.Size(283, 30);
            this._lastEditTimeLbl.TabIndex = 6;
            this._lastEditTimeLbl.Text = "(yyyy/MM/dd tt hh:mm)";
            this._lastEditTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lastEditTimeLbl.Click += new System.EventHandler(this.ProjectDataExhibition_Click);
            this._lastEditTimeLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectDataExhibition_MouseDown);
            this._lastEditTimeLbl.MouseEnter += new System.EventHandler(this.ProjectDataExhibition_MouseEnter);
            this._lastEditTimeLbl.MouseLeave += new System.EventHandler(this.ProjectDataExhibition_MouseLeave);
            // 
            // ProjectDataExhibition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this._lastEditTimeLbl);
            this.Controls.Add(this._starMark);
            this.Controls.Add(this._othersBtn);
            this.Controls.Add(this._filePathLbl);
            this.Controls.Add(this._fileNameLbl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProjectDataExhibition";
            this.Size = new System.Drawing.Size(582, 80);
            this.Load += new System.EventHandler(this.ProjectDataExhibition_Load);
            this.Click += new System.EventHandler(this.ProjectDataExhibition_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.projectDataExhibition_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectDataExhibition_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ProjectDataExhibition_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ProjectDataExhibition_MouseLeave);
            this.Resize += new System.EventHandler(this.ProjectDataExhibition_Resize);
            ((System.ComponentModel.ISupportInitialize)(this._starMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _fileNameLbl;
        private Label _filePathLbl;
        private Button _othersBtn;
        private PictureBox _starMark;
        private Label _lastEditTimeLbl;
    }
}
