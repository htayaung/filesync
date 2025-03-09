namespace FileSync
{
    public partial class FrmMain : Form
    {
        private string SourceFolder
        {
            get
            {
                var value = txtSourceFolder.Text;
                if (value.EndsWith('\\'))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                return value;
            }
            set
            {
                txtSourceFolder.Text = value;
            }
        }

        private DateTime DateModified
        {
            get
            {
                var datePart = dtpModifiedDate.Value.Date;
                var timePart = dtpModifiedTime.Value.TimeOfDay;
                return datePart + timePart;
            }
        }

        private string FileExtensions
        {
            get
            {
                return txtFileExtension.Text;
            }
        }

        private string DestinationFolder
        {
            get
            {
                var value = txtDestinationFolder.Text;
                if (value.EndsWith('\\'))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                return value;
            }
            set
            {
                txtDestinationFolder.Text = value;
            }
        }

        private CancellationTokenSource? CancellationTokenSource;
        private CancellationToken CancellationToken;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Events

        private void btnBrowseSourceFolder_Click(object sender, EventArgs e)
        {
            Run(() =>
            {
                using var folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    SourceFolder = folderDialog.SelectedPath;
                }
            });
        }

        private void txtSourceFolder_TextChanged(object sender, EventArgs e)
        {
            Run(() =>
            {
                btnSearch.Enabled = SourceFolder.IsNotEmpty();
                SetCopyButtonEnabled();
            });
        }

        private void btnBrowseDestinationFolder_Click(object sender, EventArgs e)
        {
            Run(() =>
            {
                using var folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    DestinationFolder = folderDialog.SelectedPath;
                }
            });
        }

        private void txtDestinationFolder_TextChanged(object sender, EventArgs e)
        {
            Run(() =>
            {
                SetCopyButtonEnabled();
            });
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            InitializeRunningProcess(ProcessType.Search);
            await RunAsync(() =>
            {
                SetCancellationToken();
                ExceptionHandler.ThrowIfEmpty(SourceFolder, "Please specify a source directory.");
                ExceptionHandler.ThrowIfDirectoryDoesNotExist(SourceFolder, "Source directory does not exist.");

                List<string> includedFiles = [];
                List<string> includedDirs = [];
                SearchDirectories(SourceFolder, DateModified, includedFiles, includedDirs);

                HashSet<string> allDirectories = CollectParentDirectories(SourceFolder, includedFiles, includedDirs);
                Thread.Sleep(5000);
                Invoke(() =>
                {
                    BuildTreeView(SourceFolder, allDirectories, includedFiles);
                });
            }, () =>
            {
                FinalizeRunningProcess(ProcessType.Search);
            });
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            InitializeRunningProcess(ProcessType.Copy);
            await RunAsync(() =>
            {
                ExceptionHandler.ThrowIfEmpty(DestinationFolder, "Please specify a destination directory.");
                ExceptionHandler.ThrowIfDirectoryDoesNotExist(DestinationFolder, "Destination directory does not exist.");

                List<TreeNode> checkedNodes = GetCheckedNodes(tvFileSystem.Nodes);
                var directories = checkedNodes.Where(n => Directory.Exists(n.Tag.ToString()))
                                            .Select(n => n.Tag.ToString()).ToList();
                var files = checkedNodes.Where(n => File.Exists(n.Tag.ToString()))
                                       .Select(n => n.Tag.ToString()).ToList();

                // Create directories first
                foreach (string dirPath in directories)
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    string relativePath = GetRelativePath(dirPath, SourceFolder);
                    string destPath = Path.Combine(DestinationFolder, relativePath);
                    Directory.CreateDirectory(destPath);
                }

                Thread.Sleep(5000);

                // Copy files
                foreach (string filePath in files)
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    string relativePath = GetRelativePath(filePath, SourceFolder);
                    string destFilePath = Path.Combine(DestinationFolder, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(destFilePath));
                    File.Copy(filePath, destFilePath, true);
                }

                MessageBox.Show("Copy completed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }, () =>
            {
                FinalizeRunningProcess(ProcessType.Copy);
            });
        }

        private void tvFileSystem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Run(() =>
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    SetChildrenChecked(e.Node, e.Node.Checked);
                }
            });
        }

        private void btnCancelProcess_Click(object sender, EventArgs e)
        {
            if (CancellationTokenSource != null)
            {
                CancellationTokenSource.Cancel();
            }
        }

        #endregion

        #region Search

        private void SearchDirectories(string path, DateTime minDate, List<string> includedFiles, List<string> includedDirectories)
        {
            try
            {
                var filesInDirectory = Directory.GetFiles(path)
                    .Where(file => File.GetLastWriteTime(file) >= minDate)
                    .ToList();

                foreach (string file in filesInDirectory)
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    includedFiles.Add(file);
                }

                if (filesInDirectory.Any())
                {
                    includedDirectories.Add(path);
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    SearchDirectories(directory, minDate, includedFiles, includedDirectories);
                }

                if (FileExtensions.IsNotEmpty())
                {
                    var extensions = FileExtensions.Replace(" ", "")
                        .ToUpper()
                        .Split(',')
                        .ToList();
                    includedFiles.RemoveAll(file =>
                    {
                        var fileInfo = new FileInfo(file);
                        return fileInfo.Extension.IsEmpty() || !extensions.Contains(fileInfo.Extension.Remove(0, 1).ToUpper());
                    });

                    var validDirectories = new HashSet<string>();
                    foreach (var directory in includedDirectories)
                    {
                        CancellationToken.ThrowIfCancellationRequested();
                        if (includedFiles.Any(file => Path.GetDirectoryName(file) == directory))
                        {
                            validDirectories.Add(directory);
                        }
                    }

                    includedDirectories.Clear();
                    includedDirectories.AddRange(validDirectories);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HashSet<string> CollectParentDirectories(string sourceDirectory, List<string> files, List<string> directories)
        {
            HashSet<string> allDirectories = new HashSet<string>();

            foreach (var path in files.Concat(directories))
            {
                CancellationToken.ThrowIfCancellationRequested();
                string directory = Path.GetDirectoryName(path);
                while (directory != null && IsSubdirectoryOf(sourceDirectory, directory))
                {
                    CancellationToken.ThrowIfCancellationRequested();
                    allDirectories.Add(directory);
                    directory = Path.GetDirectoryName(directory);
                }
            }

            if (allDirectories.Count > 0 || files.Count > 0)
            {
                allDirectories.Add(sourceDirectory);
            }

            return allDirectories;
        }

        private bool IsSubdirectoryOf(string parentDirectory, string childDirectory)
        {
            return new Uri(parentDirectory).IsBaseOf(new Uri(childDirectory));
        }

        #endregion

        #region Copy

        private string GetRelativePath(string fullPath, string basePath)
        {
            basePath = basePath.TrimEnd(Path.DirectorySeparatorChar);
            return Path.GetRelativePath(basePath, fullPath);
        }

        #endregion

        #region TreeView

        private void BuildTreeView(string sourceDirectory, HashSet<string> allDirectories, List<string> includedFiles)
        {
            tvFileSystem.Nodes.Clear();
            TreeNode root = new TreeNode(sourceDirectory)
            {
                Tag = sourceDirectory,
                Checked = true
            };
            tvFileSystem.Nodes.Add(root);

            var directoryNodes = new Dictionary<string, TreeNode> { [sourceDirectory] = root };

            foreach (string directory in allDirectories.OrderBy(d => d.Length))
            {
                CancellationToken.ThrowIfCancellationRequested();
                if (directory == sourceDirectory) continue;

                string parentDirectory = Path.GetDirectoryName(directory);
                if (directoryNodes.TryGetValue(parentDirectory, out TreeNode parentNode))
                {
                    TreeNode node = new TreeNode(Path.GetFileName(directory))
                    {
                        Tag = directory,
                        Checked = true
                    };
                    parentNode.Nodes.Add(node);
                    directoryNodes[directory] = node;
                }
            }

            foreach (string file in includedFiles)
            {
                CancellationToken.ThrowIfCancellationRequested();
                string directory = Path.GetDirectoryName(file);
                if (directoryNodes.TryGetValue(directory, out TreeNode parentNode))
                {
                    parentNode.Nodes.Add(new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file,
                        Checked = true
                    });
                }
            }

            root.Expand();
        }

        private List<TreeNode> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<TreeNode> checkedNodes = [];
            foreach (TreeNode node in nodes)
            {
                CancellationToken.ThrowIfCancellationRequested();
                if (node.Checked) checkedNodes.Add(node);
                checkedNodes.AddRange(GetCheckedNodes(node.Nodes));
            }
            return checkedNodes;
        }

        private void CopyNode(TreeNode node, string destinationDirectory, string sourceDirectory)
        {
            string sourcePath = node.Tag.ToString();
            string relativePath = GetRelativePath(sourcePath, sourceDirectory);
            string destPath = Path.Combine(destinationDirectory, relativePath);

            if (Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(destPath);
                foreach (TreeNode child in node.Nodes)
                    CopyNode(child, destinationDirectory, sourceDirectory);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(sourcePath, destPath, true);
            }
        }

        private void SetChildrenChecked(TreeNode node, bool isChecked)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = isChecked;
                SetChildrenChecked(child, isChecked);
            }
        }

        #endregion

        #region Helper Methods

        private void Run(Action action, Action? callback = null)
        {
            try
            {
                action();
            }
            catch (OperationCanceledException)
            {
                Invoke(() =>
                {
                    progressBar.Visible = false;
                });

                MessageBox.Show("Process cancelled.",
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "An error has occurred while processing.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (callback != null)
                {
                    callback();
                }
            }
        }

        private async Task RunAsync(Action action, Action? callback = null)
        {
            try
            {
                await Task.Run(action);
            }
            catch (OperationCanceledException)
            {
                Invoke(() =>
                {
                    progressBar.Visible = false;
                });

                MessageBox.Show("Process cancelled.",
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "An error has occurred while processing.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (callback != null)
                {
                    callback();
                }
            }
        }

        private void InitializeRunningProcess(ProcessType type)
        {
            Invoke(() =>
            {
                Cursor = Cursors.WaitCursor;
                pnlSource.Enabled = false;
                pnlDestination.Enabled = false;
                ShowProgressStyle();

                switch (type)
                {
                    case ProcessType.Search:
                        btnSearch.Enabled = false;
                        break;
                    case ProcessType.Copy:
                        btnCopy.Enabled = false;
                        break;
                }
            });
        }

        private void FinalizeRunningProcess(ProcessType type)
        {
            Invoke(() =>
            {
                Cursor = Cursors.Default;
                pnlSource.Enabled = true;
                pnlDestination.Enabled = true;
                HideProgressStyle();

                switch (type)
                {
                    case ProcessType.Search:
                        btnSearch.Enabled = true;
                        break;
                    case ProcessType.Copy:
                        btnCopy.Enabled = true;
                        break;
                }
            });
        }

        private void SetCopyButtonEnabled()
        {
            btnCopy.Enabled = SourceFolder.IsNotEmpty() && DestinationFolder.IsNotEmpty();
        }

        private void SetCancellationToken()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
        }

        private void ShowProgressStyle()
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;
            btnCancelProcess.Visible = true;
            btnCancelProcess.Cursor = Cursors.Default;
        }

        private void HideProgressStyle()
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Visible = false;
            btnCancelProcess.Visible = false;
        }

        #endregion
    }
}
