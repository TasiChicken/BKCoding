using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class SelectProjectForm : Form
    {
        #region Field

        private List<ProjectData> projectDataList;
        private string selectedFile;

        #endregion

        #region Event

        #region SelectProjectForm

        private void SelectProjectForm_Load(object sender, EventArgs e)
        {
            string projectDataString = Properties.Settings.Default.projectDatas;
            if (projectDataString != null) projectDataList = FileHelper.FromJson<List<ProjectData>>(FileHelper.DecryptString(projectDataString));
            projectDataList = projectDataList ?? new List<ProjectData>();

            if(selectedFile != null)
            {
                OpenFile(selectedFile);
                return;
            }

            FormResizer.AddResizer(this);

            _projectDatasPnl.MouseWheel += EventHandlers.Scrollable_MouseWheel;

            displayProjectDatas(projectDataList);
        }

        private void SelectProjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string projectDataString = FileHelper.EncryptString(FileHelper.ToJson<List<ProjectData>>(projectDataList));
            Properties.Settings.Default.projectDatas = projectDataString;
            Properties.Settings.Default.Save();
        }

        #endregion
       
        #region _searchBar

        private void _searchBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(_searchBar.Parent.BackColor);
            
            using(Pen pen = new Pen(_searchContent.Focused ? Colors.Gray153 : Colors.Gray114))
            using(SolidBrush solidBrush = new SolidBrush(Color.Black))
            {
                solidBrush.Color = _searchBar.BackColor;
                DrawingHelper.DrawRoundedRetangle(solidBrush, _searchBar, e.Graphics, 10);
                DrawingHelper.DrawRoundedBorder(pen, _searchBar, e.Graphics, 10);
            }
        }

        private void _searchBar_Resize(object sender, EventArgs e)
        {
            _searchContent.Width = _searchBar.Width - _searchBar.Padding.Right - _searchContent.Left;
            _searchBar.Refresh();
        }

        private void _searchContent_GotFocus(object sender, EventArgs e)
        {
            _searchBar.BackColor = Colors.Black26;
            foreach (Control control in _searchBar.Controls) control.BackColor = _searchBar.BackColor;
            _searchBar.Refresh();
        }

        private void _searchContent_LostFocus(object sender, EventArgs e)
        {
            _searchBar.BackColor = Colors.Black38;
            foreach (Control control in _searchBar.Controls) control.BackColor = _searchBar.BackColor;
            _searchBar.Refresh();
        }

        private void _searchContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) search(sender, e);
        }

        #endregion

        #region Button

        private void _newProject_Click(object sender, EventArgs e)
        {
            OpenFile(null);
        }

        private void _openProjectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "開啟專案";
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = Strings.fileNameExtension.ToUpper() + "檔案|*." + Strings.fileNameExtension;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }

            openFileDialog.Dispose();
        }

        #endregion

        private void _projectDatasPnl_Resize(object sender, EventArgs e)
        {
            int width = _projectDatasPnl.Width - 4;

            foreach (Control control in _projectDatasPnl.Controls)
            {
                control.Width = width;
            }
        }

        #endregion

        #region Function

        private void search(object sender, EventArgs e)
        {
            List<ProjectData> list = new List<ProjectData>(projectDataList.Count);

            foreach(ProjectData projectData in projectDataList)
            {
                if (Strings.Contains(projectData.fileName, _searchContent.Text)) list.Add(projectData);
            }

            displayProjectDatas(list);
        }
        
        private void displayProjectDatas(List<ProjectData> projectDatas)
        {
            _projectDatasPnl.Controls.Clear();

            for (int i = 0; i < projectDatas.Count; i++)
            {
                ProjectDataExhibition exhibition = new ProjectDataExhibition(projectDatas[i], this);
                _projectDatasPnl.Controls.Add(exhibition);

                exhibition.Top = (exhibition.Height + 10) * i;
                exhibition.Left = 2;
                exhibition.Width = _projectDatasPnl.Width - 4;
            }
        }

        #endregion

        #region Internal

        internal SelectProjectForm()
        {
            InitializeComponent();
        }

        internal SelectProjectForm(string selectedFile)
        {
            this.selectedFile = selectedFile;
            InitializeComponent();
        }
        
        internal void OpenFile(string file)
        {
            ProjectData projectData = GetProjectDataFromList(file);
            if (projectData == null && file != null) AddProjectDataIntoList(projectData = new ProjectData(file));

            this.Hide();
            new EditForm(projectData, this).ShowDialog();
            this.Close();
        }

        #region ProjectDataList

        internal ProjectData GetProjectDataFromList(string fileFullPath)
        {
            if (fileFullPath == null) return null;

            foreach (ProjectData projectData in projectDataList)
            {
                if (projectData.fileFullPath.Equals(fileFullPath)) return projectData;
            }

            return null;
        }

        internal void AddProjectDataIntoList(ProjectData projectData)
        {
            for (int i = 0; i < projectDataList.Count; i++)
            {
                if (projectData.CompareTo(projectDataList[i]) != CompareResult.Less)
                {
                    projectDataList.Insert(i, projectData);
                    return;
                }
            }

            projectDataList.Add(projectData);
        }

        internal void RemoveProjectDataFromList(ProjectData projectData)
        {
            projectDataList.Remove(projectData);
            displayProjectDatas(projectDataList);
        }

        internal void LocateProjectDataInList(ProjectData projectData)
        {
            projectDataList.Remove(projectData);
            AddProjectDataIntoList(projectData);
            displayProjectDatas(projectDataList);
        }

        #endregion

        #endregion
    }
}