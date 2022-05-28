using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class ProjectDataOtherSettings : UserControl
    {
        #region Const

        private const int padding = 5;

        #endregion

        #region Field

        private readonly ProjectData projectData;
        private readonly SelectProjectForm selectProjectForm;
        private readonly Action close;

        #endregion

        #region Event

        private void ProjectDataOtherSettings_Resize(object sender, EventArgs e)
        {
            Point point = new Point(padding, padding);
            Size size = new Size(this.Width - padding * 2, this.Height / Controls.Count - padding * 2);
            for(int i = 0; i < Controls.Count; i++)
            {
                point.Y = (size.Height + padding * 2) * i + padding;
                Controls[i].Location = point;
                Controls[i].Size = size;
            }
        }

        private void _showInExplorerBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", @"/select," + projectData.fileFullPath);
        }

        private void _removeFromListBtn_Click(object sender, EventArgs e)
        {
            close();
            selectProjectForm.RemoveProjectDataFromList(projectData);
        }

        #endregion

        #region Internal

        internal ProjectDataOtherSettings(ProjectData projectData, SelectProjectForm selectProjectForm, Action close)
        {
            this.projectData = projectData;
            this.selectProjectForm = selectProjectForm;
            this.close = close;
            InitializeComponent();
        }

        #endregion
    }
}
