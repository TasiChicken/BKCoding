using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace codingBlock
{
    public partial class EditForm : Form
    {
        #region Const
        
        private const int _playBtnPadding = 5;
        private const int mainPnlMinWidth = 150;
        private const string defaultCFilename = "test.c";
        private const string defaultExeFilename = "test.exe";
        private const string gccLocation = "TDM-GCC-64\\bin\\gcc.exe";

        #endregion

        #region Field

        private ContainerBlock codingArea;
        private ProjectData _projectData;
        private SelectProjectForm selectProjectForm;
        private bool _hasSaved;
        private List<CodeBlock> codeBlocks = new List<CodeBlock>();
        private readonly List<BlockType> blockTypes = new List<BlockType>();
        private readonly List<List<CodeBlock>> blockLists = new List<List<CodeBlock>>();

        #endregion

        #region Event

        private void EditForm_Load(object sender, EventArgs e)
        {
            FormResizer.AddResizer(this);

            this.MouseWheel += EditForm_MouseWheel;
            this.Layout += EditForm_Layout;
            _blockTypePnl.MouseWheel += EventHandlers.Scrollable_MouseWheel;
            _blocksPnl.MouseWheel += EventHandlers.Scrollable_MouseWheel;

            _header.SetExitBtnAction(new Header.ExitAction(closeThisForm));
            _header.isMaxWindow = true;

            hasSaved = _projectData != null;

            addBlockTypeBtn();

            if (hasSaved)
            {
                CodeBlock.SaveData[] saveDatas = FileHelper.FromJson<CodeBlock.SaveData[]>(FileHelper.ReadFile(_projectData.fileFullPath));
                foreach(CodeBlock.SaveData saveData in saveDatas)
                {
                    CodeBlock codeBlock = saveData.ToCodeBlock();

                    if (saveData.code.Equals(codingAreaTitle))
                        codingArea = codeBlock as ContainerBlock;

                    this.Controls.Add(codeBlock);
                    codeBlock.Location = saveData.location;
                    codeBlock.BringToFront();
                }
            
                hasSaved = true;
            }
            else
            {
                codingArea = new ContainerBlock(Color.FromArgb(0, 0, 0), codingAreaTitle, CodeBlock.DragType.unmovable);
                this.Controls.Add(codingArea);
                codingArea.BringToFront();
                codingArea.Location = new Point(_blocksPnl.Right + _splitter.Width, _menuStripPnl.Bottom);

                ContainerBlock intMain = new ContainerBlock(Color.FromArgb(58, 48, 134), "int main()");
                this.Controls.Add(intMain);
                intMain.BringToFront();
                codingArea.InsertChild(intMain);
                intMain.parentBlock = codingArea;

                CodeBlock codeBlock;
                codeBlock = new CodeBlock(Color.FromArgb(58, 48, 134), "return 0;");
                this.Controls.Add(codeBlock);
                codeBlock.BringToFront();
                intMain.InsertChild(codeBlock);
                codeBlock.parentBlock = intMain;

                codeBlock = new CodeBlock(Color.FromArgb(88, 88, 88), "#include <stdio.h>");
                this.Controls.Add(codeBlock);
                codeBlock.BringToFront();
                codingArea.InsertChild(codeBlock);
                codeBlock.parentBlock = codingArea;
            }
        }

        private void EditForm_Layout(object sender, LayoutEventArgs e)
        {
            _header.BringToFront();
            _menuStripPnl.BringToFront();
        }

        private void EditForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (codingArea.Top >= _menuStripPnl.Bottom && e.Delta > 0) return;
            if (codingArea.Bottom <= _splitter.Bottom && e.Delta < 0) return;

            codingArea.Top += e.Delta;
        }

        private void EditForm_ControlAdded(object sender, ControlEventArgs e)
        {
            Type type = e.Control.GetType();
            if (type.Equals(typeof(CodeBlock)) || type.IsSubclassOf(typeof(CodeBlock)))
            {
                codeBlocks.Add(e.Control as CodeBlock);
                e.Control.MouseWheel += EditForm_MouseWheel;
            }
        }

        private void _blocksPnl_Resize(object sender, EventArgs e)
        {
            int maxWidth = this.Width - _blocksPnl.Left - mainPnlMinWidth;
            if (_blocksPnl.Width > maxWidth) _blocksPnl.Width = maxWidth;
            else if (_blocksPnl.Width < mainPnlMinWidth) _blocksPnl.Width = mainPnlMinWidth;

            if (codingArea != null)
                codingArea.Location = new Point(_blocksPnl.Right + _splitter.Width, _blocksPnl.Top);
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
            FileHelper.WriteFile(Strings.saveDirectory + defaultCFilename, codingArea.ToString());
            var compiler = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Application.StartupPath + "\\" + gccLocation,
                    Arguments = $"-o {Strings.saveDirectory + defaultExeFilename} {Strings.saveDirectory + defaultCFilename} -fexec-charset=big5",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            
            compiler.Start();
            string error = compiler.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(error)) MessageDialog.Show(error);
            else Process.Start(Strings.saveDirectory + defaultExeFilename).WaitForExit();
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "C File | *.c";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(dialog.FileName, codingArea.ToString());
        }

        private void _exportExeFileCmsi_Click(object sender, EventArgs e)
        {
            FileHelper.WriteFile(Strings.saveDirectory + defaultCFilename, codingArea.ToString());

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Executable File | *.exe";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var compiler = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Application.StartupPath + "\\" + gccLocation,
                    Arguments = $"-o {dialog.FileName} {Strings.saveDirectory + defaultCFilename}",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            compiler.Start();
            string error = compiler.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(error)) MessageDialog.Show(error);
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

            List<CodeBlock.SaveData> blocksSaveData = new List<CodeBlock.SaveData>();

            foreach (CodeBlock codeBlock in codeBlocks)
                if (!codeBlock.HasParent())
                    blocksSaveData.Add(codeBlock.CreateSaveData());

            string saveContent = FileHelper.ToJson<List<CodeBlock.SaveData>>(blocksSaveData);
            FileHelper.WriteFile(_projectData.fileFullPath, saveContent);

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
            saveFile();
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
            int maxX = 50;
            foreach (var bT in blockTypes) maxX = Math.Max(TextRenderer.MeasureText(bT.name, _blockTypePnl.Font).Width, maxX);
            maxX += 5;
            if (maxX > _blockTypePnl.Width) _blockTypePnl.Width = maxX;

            Size size = new Size(maxX, 55);
            Point location = new Point();

            for (int i = 0; i < blockTypes.Count; i++)
            {
                BlockTypeButton button = new BlockTypeButton(i, this, blockTypes[i].color, blockTypes[i].name);
                _blockTypePnl.Controls.Add(button);
                button.Font = _blockTypePnl.Font;
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

        internal static EditForm instance;
        
        internal const string codingAreaTitle = "編譯區域";

        internal bool hasSaved
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

        internal EditForm(ProjectData projectData, SelectProjectForm selectProjectForm)
        {
            instance = this;
            _projectData = projectData;
            this.selectProjectForm = selectProjectForm;
            
            InitializeComponent();

            this.ControlAdded += EditForm_ControlAdded;

            StringReader reader = new StringReader(Properties.Resources.blocks);
            string line;
            while ((line = reader.ReadLine()) != null)
                if (line.Contains("@#$"))
                {
                    string[] data = line.Split(new string[] { "@#$" }, StringSplitOptions.None);
                    BlockType type = new BlockType(data[0], Color.FromArgb(Convert.ToInt32("FF" + data[1], 16)));
                    blockTypes.Add(type);
                    blockLists.Add(new List<CodeBlock>());
                }
                else
                {
                    CodeBlock codeBlock = null;
                    Color color = blockTypes.Last().color;
                    string code = line.Substring(1);
                    CodeBlock.DragType dragType = CodeBlock.DragType.clone;

                    switch (line[0])
                    {
                        case 'N':
                            codeBlock = new CodeBlock(color, code + (code.First() == '#' || code.Last() == ':' ? "" : ";"), dragType);
                            break;
                        case 'I':
                            codeBlock = new DataBlock(color, code, dragType);
                            break;
                        case 'C':
                            codeBlock = new ContainerBlock(color, code, dragType);
                            break;
                    }

                    _blocksPnl.Controls.Add(codeBlock);
                    codeBlock.Location = new Point(5, 5);
                    if (blockLists.Last().Count > 0) codeBlock.Top += blockLists.Last().Last().Bottom;
                    blockLists.Last().Add(codeBlock);
                    codeBlock.Hide();
                }
        }

        internal void ChangeBlockType(int index)
        {
            for (int i = 0; i < blockTypes.Count; i++)
            {
                BlockTypeButton button = _blockTypePnl.Controls[i] as BlockTypeButton;
                //if (button == null) continue;
                button.isChecked = i == index;
                foreach(var block in blockLists[i]) block.Visible = i == index;
            }

            /*
            _blocksPnl.BorderStyle = BorderStyle.None;
            _splitter.BackColor = Colors.Black26;
            _splitter.Width = 10;
            */
        }

        internal bool InCodeRegion(CodeBlock codeBlock)
        {
            return Vector2Helper.Compare(Vector2Helper.PositionInTopLevel(codeBlock), new Point(_splitter.Right, _splitter.Top)) == CompareResult.More;
        }

        internal void VisionTrashCan(bool visible)
        {
            _trashCan.Visible = visible;
            if (visible) _trashCan.BringToFront();
        }

        internal void ThrowAwayBlock(CodeBlock codeBlock)
        {
            this.codeBlocks.Remove(codeBlock);
            codeBlock.Parent = null;
            codeBlock.Dispose();
        }

        internal CodeBlock OnWhichBlock(Point point)
        {
            foreach(CodeBlock codeBlock in codeBlocks)
            {
                if (Vector2Helper.Compare(codeBlock.Location, point) != CompareResult.Less) continue;
                if (Vector2Helper.Compare(codeBlock.Location + codeBlock.Size, point) != CompareResult.More) continue;
                return codeBlock;
            }
            return null;
        }

        #endregion
    }
}
