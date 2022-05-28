using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class ProjectDataExhibition : UserControl
    {
        #region Const
        
        private const int controlMargin = 15;

        #endregion

        #region Field

        private readonly ProjectData projectData;
        private readonly SelectProjectForm selectProjectForm;
        private int maxFileNameLength;
        private ProjectDataOtherSettings otherSettings;
        private System.Windows.Forms.Timer timer;

        #endregion

        #region Event

        #region ProjectDataExhibition

        private void ProjectDataExhibition_Load(object sender, EventArgs e)
        {
            _lastEditTimeLbl.Text = projectData.lastEditTime.ToString("(yyyy / MM / dd tt hh:mm)");
            _filePathLbl.Text = projectData.filePath;
            _starMark.Image = projectData.isFavorite ? Properties.Resources.star : Properties.Resources.grayStar;
        }
        
        private void projectDataExhibition_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.Parent.BackColor);
            using (Brush brush = new SolidBrush(this.BackColor)) DrawingHelper.DrawRoundedRetangle(brush, this, e.Graphics, 20);
        }

        private void ProjectDataExhibition_Resize(object sender, EventArgs e)
        {
            _othersBtn.Top = controlMargin;
            _othersBtn.Height = this.Height - controlMargin * 2;
            _othersBtn.Width = _othersBtn.Height;
            _othersBtn.Left = this.Width - _othersBtn.Width - controlMargin;

            _starMark.Location = new Point(controlMargin, controlMargin);
            _starMark.Size = _othersBtn.Size;
            
            _fileNameLbl.Left = _filePathLbl.Left = this.Height;
            _lastEditTimeLbl.Left = _othersBtn.Left - controlMargin - _lastEditTimeLbl.Width;
            
            maxFileNameLength = _fileNameLbl.Width / 15;

            string fileName = projectData.fileNameNoExtension;
            if (fileName.Length > maxFileNameLength)
            {
                StringBuilder stringBuilder = new StringBuilder(maxFileNameLength);

                char[] c = fileName.ToCharArray();
                for (int i = 0; i < maxFileNameLength; i++)
                {
                    if (i > maxFileNameLength - 4) c[i] = '.';
                    stringBuilder.Append(c[i]);
                }
                fileName = stringBuilder.ToString();
                _fileNameLbl.Text = fileName;
            }
            else _fileNameLbl.Text = projectData.fileNameNoExtension;

            Refresh();
        }

        private void ProjectDataExhibition_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Colors.Black64;
            _othersBtn.BackColor = Colors.Gray84;
        }

        private void ProjectDataExhibition_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Colors.Black38;
            _othersBtn.BackColor = Colors.Black51;
        }

        private void ProjectDataExhibition_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Colors.Black51;
            _othersBtn.BackColor = Colors.Black64;
        }

        private void ProjectDataExhibition_Click(object sender, EventArgs e)
        {
            this.BackColor = Colors.Black64;
            if (!File.Exists(projectData.fileFullPath))
            {
                if(MessageDialog.Show("檔案已刪除或變更位置\n是否要移除專案?", "找不到檔案", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectProjectForm.RemoveProjectDataFromList(projectData);
                }

                return;
            }
            
            selectProjectForm.OpenFile(projectData.fileFullPath);
        }

        #endregion

        #region _starMark

        private void _starMark_Click(object sender, EventArgs e)
        {
            projectData.isFavorite = !projectData.isFavorite;
            selectProjectForm.LocateProjectDataInList(projectData);
        }

        private void _starMark_MouseEnter(object sender, EventArgs e)
        {
            _starMark.Image = projectData.isFavorite ? Properties.Resources.starBorder : Properties.Resources.grayStarBorder;
        }

        private void _starMark_MouseLeave(object sender, EventArgs e)
        {
            _starMark.Image = projectData.isFavorite ? Properties.Resources.star : Properties.Resources.grayStar;
        }

        #endregion
      
        private void _othersBtn_Click(object sender, EventArgs e)
        {          
            if (otherSettings != null)
            {
                closeOtherSettings();
                return;
            }

            otherSettings = new ProjectDataOtherSettings(projectData, selectProjectForm, closeOtherSettings);
            otherSettings.Parent = selectProjectForm;

            otherSettings.Location = Vector2Helper.PositionInTopLevel(_othersBtn);
            otherSettings.Top -= otherSettings.Height;
            otherSettings.BringToFront();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += detecOtherSettingsLostFocused;
            timer.Start();
            
        }
        
        private void detecOtherSettingsLostFocused(object sender, EventArgs e)
        {
            if (otherSettings == null)
            {
                timer.Dispose();
                timer = null;
                return;
            }
            if (otherSettings.Parent == null || _othersBtn == null)
            {
                closeOtherSettings();
                return;
            }
            
            Point cursorPoint = Vector2Helper.Sub(Cursor.Position, otherSettings.TopLevelControl.Location);

            if (Vector2Helper.Compare(cursorPoint, Vector2Helper.PositionInTopLevel(otherSettings), true) == CompareResult.More)
            {
                Control control = otherSettings;
                for (int i = 0; i < 2; i++)
                {
                    Point rightBottom = Vector2Helper.PositionInTopLevel(control);
                    Size size = Vector2Helper.Sub(control.Size, new Size(1, 1));
                    rightBottom = Vector2Helper.Add(rightBottom, new Point(size));

                    if (Vector2Helper.Compare(cursorPoint, rightBottom, true) == CompareResult.Less) return;

                    control = _othersBtn;
                }
            }

            closeOtherSettings();
        }
        
        #endregion

        #region Function

        private void closeOtherSettings()
        {
            otherSettings.Dispose();
            otherSettings = null;
            timer.Dispose();
            timer = null;
        }
        
        #endregion

        #region Internal

        internal ProjectDataExhibition(ProjectData projectData, SelectProjectForm selectProjectForm)
        {
            this.projectData = projectData;
            this.selectProjectForm = selectProjectForm;
            InitializeComponent();
        }

        #endregion
    }
}
