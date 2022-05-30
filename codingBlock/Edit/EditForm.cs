using System;
using System.Drawing;
using System.Windows.Forms;

namespace codingBlock
{
    public partial class EditForm : Form
    {
        #region Const
        
        private const int _playBtnPadding = 5;
        private const int mainPnlMinWidth = 150;

        #endregion

        #region Data
        
        private static readonly BlockType[] blockTypes =
        {
            new BlockType("I/O", Color.FromArgb(135, 19, 23)),
            new BlockType("運算", Color.FromArgb(142, 77, 13)),
            new BlockType("條件", Color.FromArgb(133, 123, 2)),
            new BlockType("迴圈", Color.FromArgb(0, 130, 60)),
            new BlockType("資料", Color.FromArgb(58, 48, 134)),
            new BlockType("函式", Color.FromArgb(128, 29, 100))
        };

        #endregion

        #region Fields

        private ProjectData _projectData;
        private SelectProjectForm selectProjectForm;
        private bool _hasSaved;
        private bool hasSaved
        {
            get
            {
                return _hasSaved;
            }
            set
            {
                _hasSaved = value;
                if (_projectData != null) _header.SetTitle(_projectData.fileNameNoExtension + (value ? "" : "(未儲存)"));
            }
        }

        #endregion

        #region Event

        private void EditForm_Load(object sender, EventArgs e)
        {
            FormResizer.AddResizer(this);
            
            _blocksPnl.MouseWheel += EventHandlers.Scrollable_MouseWheel;
            _blockTypePnl.MouseWheel += EventHandlers.Scrollable_MouseWheel;

            _header.SetExitBtnAction(new Header.ExitAction(closeThisForm));
            _header.isMaxWindow = true;

            hasSaved = _projectData != null;

            //To do read file

            addBlockTypeBtn();
        }

        private void _blocksPnl_Resize(object sender, EventArgs e)
        {
            int maxWidth = this.Width - _blocksPnl.Left - mainPnlMinWidth;
            if (_blocksPnl.Width > maxWidth) _blocksPnl.Width = maxWidth;
            else if (_blocksPnl.Width < mainPnlMinWidth) _blocksPnl.Width = mainPnlMinWidth;
        }

        #region Menu Strip

        #region _playBtn

        private void _playBtn_Paint(object sender, PaintEventArgs e)
        {
            int sideLength = _playBtn.Height - _playBtnPadding * 2;
            e.Graphics.DrawImage(Properties.Resources.play, _playBtnPadding, _playBtnPadding, sideLength, sideLength);
        }

        private void _playBtn_Click(object sender, EventArgs e)
        {
            MessageDialog.Show("編譯失敗");
        }

        #endregion

        #region _fileMenuBtn

        private void _fileMenuBtn_Click(object sender, EventArgs e)
        {
            _fileCms.Show(_fileMenuBtn, 0, _fileMenuBtn.Height);
        }

        private void _saveFileCmsi_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void _saveNewFileCmsi_Click(object sender, EventArgs e)
        {
            saveNewFile();
        }

        private void _exportCFileCmsi_Click(object sender, EventArgs e)
        {

        }

        private void _exportExeFileCmsi_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region _editMenuBtn

        private void _editMenuBtn_Click(object sender, EventArgs e)
        {
            _editCms.Show(_editMenuBtn, 0, _editMenuBtn.Height);
        }

        private void _copyCmsi_Click(object sender, EventArgs e)
        {

        }

        private void _pastCmsi_Click(object sender, EventArgs e)
        {

        }

        private void _cutCmsi_Click(object sender, EventArgs e)
        {

        }

        private void _deleteCmsi_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #endregion

        #region Function

        #region Project

        private void saveFile()
        {
            if (_projectData == null)
            {
                saveNewFile();
                return;
            }

            _projectData.lastEditTime = DateTime.Now;
            selectProjectForm.LocateProjectDataInList(_projectData);

            FileHelper.WriteFile(_projectData.fileFullPath, "");

            hasSaved = true;
        }

        private void saveNewFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "開啟專案";
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = Strings.fileNameExtension.ToUpper() + "檔案|*." + Strings.fileNameExtension;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string file = saveFileDialog.FileName;
            saveFileDialog.Dispose();

            _projectData = selectProjectForm.GetProjectDataFromList(file);
            if (_projectData != null)
            {
                _projectData.lastEditTime = DateTime.Now;
                selectProjectForm.LocateProjectDataInList(_projectData);
            }
            else
            {
                _projectData = new ProjectData(saveFileDialog.FileName);
                selectProjectForm.AddProjectDataIntoList(_projectData);
            }
            
            _header.SetTitle(_projectData.fileNameNoExtension);

            //To do write file
            FileHelper.WriteFile(_projectData.fileFullPath, "");

            hasSaved = true;
        }

        #endregion

        private void closeThisForm()
        {
            if (hasSaved)
            {
                this.Close();
                return;
            }

            DialogResult result = MessageDialog.Show("是否要儲存專案?", "專案尚未儲存", MessageBoxButtons.YesNo);

            if (result == DialogResult.Cancel) return;

            if (result == DialogResult.Yes)
            {
                saveFile();
            }

            this.Close();
        }

        private void addBlockTypeBtn()
        {
            Size size = new Size(_blockTypePnl.Width, _blockTypePnl.Width);
            Point location = new Point();

            for (int i = 0; i < blockTypes.Length; i++)
            {
                BlockTypeButton button = new BlockTypeButton(i, this, blockTypes[i].color, blockTypes[i].name);
                _blockTypePnl.Controls.Add(button);
                button.Size = size;
                button.Location = location;
                location.Y += size.Height;
            }

            ChangeBlockType(0);
        }

        #endregion

        #region Struct

        private struct BlockType
        {
            public BlockType(string name, Color color)
            {
                this.name = name;
                this.color = color;
            }

            public string name;
            public Color color;
        }
        
        #endregion

        #region Internal

        internal EditForm(ProjectData projectData, SelectProjectForm selectProjectForm)
        {
            _projectData = projectData;
            this.selectProjectForm = selectProjectForm;
            InitializeComponent();
        }
        
        internal void ChangeBlockType(int index)
        {
            _blocksPnl.Controls.Clear();

            for (int i = 0; i < blockTypes.Length; i++)
            {
                BlockTypeButton button = _blockTypePnl.Controls[i] as BlockTypeButton;
                if (button == null) continue;
                button.isChecked = i == index;
            }

            _blocksPnl.BorderStyle = BorderStyle.None;
            _splitter.BackColor = Colors.Black26;
            _splitter.Width = 10;

            CodeBlock c = new CodeBlock(blockTypes[index].color, "int # = #;");
            _blocksPnl.Controls.Add(c);
            c.Location = new Point(5, 5);
            c = new CodeBlock(blockTypes[index].color, "int # = #;", false);
            _blocksPnl.Controls.Add(c);
            c.Location = new Point(5, 50);
        }

        #endregion
    }
}
