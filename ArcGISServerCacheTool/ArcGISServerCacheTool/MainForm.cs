namespace ArcGISServerCacheTool
{
    public partial class MainForm : Form
    {
        private class TaskArgument
        {
            public string InputPath { get; set; }

            public string OutputPath { get; set; }

            public bool OverWrite { get; set; } = false;

            public TaskArgument(string inputPath, string outputPath)
            {
                InputPath = inputPath;
                OutputPath = outputPath;
            }
        }

        private bool IsClosing { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonChooseInput_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textInputPath.Text = dialog.SelectedPath;
            }
        }

        private void buttonChooseOutput_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textOutputPath.Text = dialog.SelectedPath;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IsClosing = false;
            if (string.IsNullOrEmpty(textInputPath.Text) || string.IsNullOrEmpty(textOutputPath.Text))
            {
                MessageBox.Show(this, "请选择输入输出目录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var args = new TaskArgument(textInputPath.Text, textOutputPath.Text);
                args.OverWrite = checkOverWrite.Checked;
                if (worker.IsBusy)
                {
                    MessageBox.Show(this, "当前任务忙", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    buttonStart.Enabled = false;
                    buttonChooseInput.Enabled = false;
                    buttonChooseOutput.Enabled = false;

                    worker.RunWorkerAsync(args);
                }
            }
        }

        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                TaskArgument? argument = e.Argument as TaskArgument;
                if (argument != null)
                {
                    DirectoryInfo root = new(argument.InputPath);
                    var levels = root.GetDirectories();
                    double processedLevels = 0;
                    foreach (var level in levels)
                    {
                        if (IsClosing)
                        {
                            throw new OperationCanceledException("用户取消了操作");
                        }

                        var levelName = level.Name.Substring(1);
                        var outputRoot = Path.Combine(argument.OutputPath, $"{int.Parse(levelName)}");
                        if (!Directory.Exists(outputRoot))
                        {
                            Directory.CreateDirectory(outputRoot);
                        }

                        var yDirectories = level.GetDirectories();
                        foreach (var yDir in yDirectories)
                        {
                            if (IsClosing)
                            {
                                throw new OperationCanceledException("用户取消了操作");
                            }

                            var y = Convert.ToInt64($"0x{yDir.Name.Substring(1)}", 16);
                            var outputYDir = Path.Combine(outputRoot, $"{y}");
                            if (!Directory.Exists(outputYDir))
                            {
                                Directory.CreateDirectory(outputYDir);
                            }

                            var files = yDir.GetFiles();
                            files.AsParallel().ForAll(p =>
                            {
                                var ext = Path.GetExtension(p.Name);
                                var x = Convert.ToInt64($"0x{p.Name.Substring(1, p.Name.Length - 1 - ext.Length)}", 16);
                                var filePath = Path.Combine(outputYDir, $"{x}{ext}");
                                p.CopyTo(filePath, argument.OverWrite);

                                var message = $"Processing: {level.Name}/{yDir.Name}/{p.Name}";

                                worker.ReportProgress((int)((processedLevels / levels.Length) * 100), message);
                            });
                        }
                        processedLevels += 1;
                    }
                    worker.ReportProgress((int)((processedLevels / levels.Length) * 100));
                }
                else
                {
                    throw new ArgumentException(nameof(TaskArgument));
                }

            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (e.UserState is string)
            {
                progressTip.Text = (string)e.UserState;
            }
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            buttonStart.Enabled = true;
            buttonChooseInput.Enabled = true;
            buttonChooseOutput.Enabled = true;
            if (e.Result is Exception)
            {
                if (e.Result is OperationCanceledException)
                {
                    MessageBox.Show(this, ((Exception)e.Result).Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, ((Exception)e.Result).Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "操作完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            progressBar.Value = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show(this, "请等待后台任务结束", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            e.Cancel = worker.IsBusy;
            IsClosing = true;
        }
    }
}