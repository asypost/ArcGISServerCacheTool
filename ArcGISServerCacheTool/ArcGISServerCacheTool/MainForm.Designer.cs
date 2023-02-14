namespace ArcGISServerCacheTool
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textInputPath = new System.Windows.Forms.TextBox();
            this.buttonChooseInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textOutputPath = new System.Windows.Forms.TextBox();
            this.buttonChooseOutput = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.progressTip = new System.Windows.Forms.ToolStripLabel();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkOverWrite = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "缓存目录";
            // 
            // textInputPath
            // 
            this.textInputPath.Location = new System.Drawing.Point(87, 19);
            this.textInputPath.Name = "textInputPath";
            this.textInputPath.Size = new System.Drawing.Size(537, 27);
            this.textInputPath.TabIndex = 1;
            // 
            // buttonChooseInput
            // 
            this.buttonChooseInput.Location = new System.Drawing.Point(640, 18);
            this.buttonChooseInput.Name = "buttonChooseInput";
            this.buttonChooseInput.Size = new System.Drawing.Size(94, 29);
            this.buttonChooseInput.TabIndex = 2;
            this.buttonChooseInput.Text = "选择";
            this.buttonChooseInput.UseVisualStyleBackColor = true;
            this.buttonChooseInput.Click += new System.EventHandler(this.buttonChooseInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出目录";
            // 
            // textOutputPath
            // 
            this.textOutputPath.Location = new System.Drawing.Point(87, 63);
            this.textOutputPath.Name = "textOutputPath";
            this.textOutputPath.Size = new System.Drawing.Size(537, 27);
            this.textOutputPath.TabIndex = 4;
            // 
            // buttonChooseOutput
            // 
            this.buttonChooseOutput.Location = new System.Drawing.Point(640, 62);
            this.buttonChooseOutput.Name = "buttonChooseOutput";
            this.buttonChooseOutput.Size = new System.Drawing.Size(94, 29);
            this.buttonChooseOutput.TabIndex = 5;
            this.buttonChooseOutput.Text = "选择";
            this.buttonChooseOutput.UseVisualStyleBackColor = true;
            this.buttonChooseOutput.Click += new System.EventHandler(this.buttonChooseOutput_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.progressTip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 175);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(749, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 22);
            // 
            // progressTip
            // 
            this.progressTip.Name = "progressTip";
            this.progressTip.Size = new System.Drawing.Size(39, 22);
            this.progressTip.Text = "进度";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(329, 122);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(94, 45);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkOverWrite
            // 
            this.checkOverWrite.AutoSize = true;
            this.checkOverWrite.Location = new System.Drawing.Point(640, 107);
            this.checkOverWrite.Name = "checkOverWrite";
            this.checkOverWrite.Size = new System.Drawing.Size(91, 24);
            this.checkOverWrite.TabIndex = 9;
            this.checkOverWrite.Text = "覆盖写入";
            this.checkOverWrite.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 200);
            this.Controls.Add(this.checkOverWrite);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonChooseOutput);
            this.Controls.Add(this.textOutputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChooseInput);
            this.Controls.Add(this.textInputPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArcGISServerCacheTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textInputPath;
        private Button buttonChooseInput;
        private Label label2;
        private TextBox textOutputPath;
        private Button buttonChooseOutput;
        private ToolStrip toolStrip1;
        private ToolStripProgressBar progressBar;
        private ToolStripLabel progressTip;
        private System.ComponentModel.BackgroundWorker worker;
        private Button buttonStart;
        private CheckBox checkOverWrite;
    }
}