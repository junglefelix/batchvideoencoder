namespace BatchVideoEncoder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_browse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAAC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.lblCurFile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bntStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbYresLimit = new System.Windows.Forms.TextBox();
            this.tbXresLimit = new System.Windows.Forms.TextBox();
            this.radioNoResize = new System.Windows.Forms.RadioButton();
            this.radioResizeByLimit = new System.Windows.Forms.RadioButton();
            this.radioResizeByPercent = new System.Windows.Forms.RadioButton();
            this.labelNewRes = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnAddAllToList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvDst = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dst_res = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_rate_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codec_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crf_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preset_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denoise_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.CheckBoxRunHidden = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dgvSrc = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioCodec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioStreams = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BitsPerPixel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._codec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CRF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Denoise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearSrc = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCurrentParamsAsDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDestinationForOutputFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codecX265MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codecX264MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codecAv1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatMkvMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatMp4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputSuffixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSuffixMenu = new System.Windows.Forms.ToolStripTextBox();
            this.runHiddenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCmdOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboDenoise = new System.Windows.Forms.ComboBox();
            this.BtnSaveDstConfig = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioMp4 = new System.Windows.Forms.RadioButton();
            this.radioMkv = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSuffix = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericCrf = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioDisableAudio = new System.Windows.Forms.RadioButton();
            this.radioCopyAudio = new System.Windows.Forms.RadioButton();
            this.radioEncodeAAC = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrc)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrf)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(16, 32);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(4);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(100, 28);
            this.btn_browse.TabIndex = 1;
            this.btn_browse.Text = "Add Folder";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(348, 0);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 28);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "aac quality:";
            // 
            // textBoxAAC
            // 
            this.textBoxAAC.Location = new System.Drawing.Point(189, 21);
            this.textBoxAAC.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAAC.Name = "textBoxAAC";
            this.textBoxAAC.Size = new System.Drawing.Size(68, 22);
            this.textBoxAAC.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "crf:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Preset:";
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Location = new System.Drawing.Point(95, 38);
            this.comboBoxPreset.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(103, 24);
            this.comboBoxPreset.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Status:";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_status.Location = new System.Drawing.Point(549, 6);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(68, 17);
            this.label_status.TabIndex = 24;
            this.label_status.Text = "Stopped";
            // 
            // lblCurFile
            // 
            this.lblCurFile.AutoSize = true;
            this.lblCurFile.Location = new System.Drawing.Point(937, 10);
            this.lblCurFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurFile.Name = "lblCurFile";
            this.lblCurFile.Size = new System.Drawing.Size(0, 16);
            this.lblCurFile.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1363, 380);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 28);
            this.button1.TabIndex = 28;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // bntStop
            // 
            this.bntStop.Location = new System.Drawing.Point(416, 0);
            this.bntStop.Margin = new System.Windows.Forms.Padding(4);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(63, 28);
            this.bntStop.TabIndex = 29;
            this.bntStop.Text = "Stop";
            this.bntStop.UseVisualStyleBackColor = true;
            this.bntStop.Click += new System.EventHandler(this.bntStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbYresLimit);
            this.groupBox2.Controls.Add(this.tbXresLimit);
            this.groupBox2.Controls.Add(this.radioNoResize);
            this.groupBox2.Controls.Add(this.radioResizeByLimit);
            this.groupBox2.Controls.Add(this.radioResizeByPercent);
            this.groupBox2.Controls.Add(this.labelNewRes);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(895, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(412, 124);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resize";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 100);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 22);
            this.button3.TabIndex = 12;
            this.button3.Text = "∨";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnResolutionDown_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 21);
            this.button2.TabIndex = 11;
            this.button2.Text = "∧";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnResolutionUP_click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 94);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 95);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "X:";
            // 
            // tbYresLimit
            // 
            this.tbYresLimit.Location = new System.Drawing.Point(200, 91);
            this.tbYresLimit.Margin = new System.Windows.Forms.Padding(4);
            this.tbYresLimit.Name = "tbYresLimit";
            this.tbYresLimit.Size = new System.Drawing.Size(93, 22);
            this.tbYresLimit.TabIndex = 9;
            // 
            // tbXresLimit
            // 
            this.tbXresLimit.Location = new System.Drawing.Point(71, 91);
            this.tbXresLimit.Margin = new System.Windows.Forms.Padding(4);
            this.tbXresLimit.Name = "tbXresLimit";
            this.tbXresLimit.Size = new System.Drawing.Size(93, 22);
            this.tbXresLimit.TabIndex = 8;
            // 
            // radioNoResize
            // 
            this.radioNoResize.AutoSize = true;
            this.radioNoResize.Location = new System.Drawing.Point(13, 17);
            this.radioNoResize.Margin = new System.Windows.Forms.Padding(4);
            this.radioNoResize.Name = "radioNoResize";
            this.radioNoResize.Size = new System.Drawing.Size(104, 20);
            this.radioNoResize.TabIndex = 7;
            this.radioNoResize.TabStop = true;
            this.radioNoResize.Text = "Don\'t Resize";
            this.radioNoResize.UseVisualStyleBackColor = true;
            this.radioNoResize.CheckedChanged += new System.EventHandler(this.radioNoResize_CheckedChanged);
            // 
            // radioResizeByLimit
            // 
            this.radioResizeByLimit.AutoSize = true;
            this.radioResizeByLimit.Location = new System.Drawing.Point(13, 69);
            this.radioResizeByLimit.Margin = new System.Windows.Forms.Padding(4);
            this.radioResizeByLimit.Name = "radioResizeByLimit";
            this.radioResizeByLimit.Size = new System.Drawing.Size(139, 20);
            this.radioResizeByLimit.TabIndex = 6;
            this.radioResizeByLimit.TabStop = true;
            this.radioResizeByLimit.Text = "Limit Resolution to:";
            this.radioResizeByLimit.UseVisualStyleBackColor = true;
            // 
            // radioResizeByPercent
            // 
            this.radioResizeByPercent.AutoSize = true;
            this.radioResizeByPercent.Location = new System.Drawing.Point(13, 42);
            this.radioResizeByPercent.Margin = new System.Windows.Forms.Padding(4);
            this.radioResizeByPercent.Name = "radioResizeByPercent";
            this.radioResizeByPercent.Size = new System.Drawing.Size(146, 20);
            this.radioResizeByPercent.TabIndex = 5;
            this.radioResizeByPercent.TabStop = true;
            this.radioResizeByPercent.Text = "Resize by % of orig.";
            this.radioResizeByPercent.UseVisualStyleBackColor = true;
            // 
            // labelNewRes
            // 
            this.labelNewRes.AutoSize = true;
            this.labelNewRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelNewRes.Location = new System.Drawing.Point(97, 100);
            this.labelNewRes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNewRes.Name = "labelNewRes";
            this.labelNewRes.Size = new System.Drawing.Size(0, 17);
            this.labelNewRes.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(177, 43);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnAddAllToList
            // 
            this.btnAddAllToList.Location = new System.Drawing.Point(4, 4);
            this.btnAddAllToList.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAllToList.Name = "btnAddAllToList";
            this.btnAddAllToList.Size = new System.Drawing.Size(100, 28);
            this.btnAddAllToList.TabIndex = 33;
            this.btnAddAllToList.Text = "AddAllToList";
            this.btnAddAllToList.UseVisualStyleBackColor = true;
            this.btnAddAllToList.Click += new System.EventHandler(this.btnAddAllToList_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(819, 382);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 28);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvDst
            // 
            this.dgvDst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.FileName,
            this.SrcSize,
            this.Resolution,
            this.dst_res,
            this.Length,
            this.v_rate_,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.codec_,
            this.crf_,
            this.preset_,
            this.denoise_,
            this.Status,
            this.PercentDone,
            this.DstSize,
            this.Percent,
            this.Time,
            this.ETA});
            this.dgvDst.Location = new System.Drawing.Point(3, 416);
            this.dgvDst.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDst.Name = "dgvDst";
            this.dgvDst.ReadOnly = true;
            this.dgvDst.RowHeadersWidth = 51;
            this.dgvDst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDst.Size = new System.Drawing.Size(1500, 285);
            this.dgvDst.TabIndex = 35;
            this.dgvDst.SelectionChanged += new System.EventHandler(this.dataGridViewDst_SelectionChanged);
            // 
            // Index
            // 
            this.Index.HeaderText = "#";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 30;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 250;
            // 
            // SrcSize
            // 
            this.SrcSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.SrcSize.HeaderText = "SrcSize";
            this.SrcSize.MinimumWidth = 6;
            this.SrcSize.Name = "SrcSize";
            this.SrcSize.ReadOnly = true;
            this.SrcSize.Width = 24;
            // 
            // Resolution
            // 
            this.Resolution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Resolution.HeaderText = "old Res";
            this.Resolution.MinimumWidth = 6;
            this.Resolution.Name = "Resolution";
            this.Resolution.ReadOnly = true;
            this.Resolution.Width = 24;
            // 
            // dst_res
            // 
            this.dst_res.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dst_res.HeaderText = "new Res";
            this.dst_res.MinimumWidth = 6;
            this.dst_res.Name = "dst_res";
            this.dst_res.ReadOnly = true;
            this.dst_res.Width = 24;
            // 
            // Length
            // 
            this.Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Length.HeaderText = "Duration";
            this.Length.MinimumWidth = 6;
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 24;
            // 
            // v_rate_
            // 
            this.v_rate_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.v_rate_.HeaderText = "V. Rate";
            this.v_rate_.MinimumWidth = 6;
            this.v_rate_.Name = "v_rate_";
            this.v_rate_.ReadOnly = true;
            this.v_rate_.Width = 24;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column1.HeaderText = "A. Codec";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 24;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column2.HeaderText = "# of ch.";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 24;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column3.HeaderText = "A. Rate";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 24;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column4.HeaderText = "A. Size";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 24;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column5.HeaderText = "# Streams";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 24;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column6.HeaderText = "B/(P*F)";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 24;
            // 
            // codec_
            // 
            this.codec_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.codec_.HeaderText = "Codec";
            this.codec_.MinimumWidth = 6;
            this.codec_.Name = "codec_";
            this.codec_.ReadOnly = true;
            this.codec_.Width = 24;
            // 
            // crf_
            // 
            this.crf_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.crf_.HeaderText = "CRF";
            this.crf_.MinimumWidth = 6;
            this.crf_.Name = "crf_";
            this.crf_.ReadOnly = true;
            this.crf_.Width = 24;
            // 
            // preset_
            // 
            this.preset_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.preset_.HeaderText = "Preset";
            this.preset_.MinimumWidth = 6;
            this.preset_.Name = "preset_";
            this.preset_.ReadOnly = true;
            this.preset_.Width = 24;
            // 
            // denoise_
            // 
            this.denoise_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.denoise_.HeaderText = "DeNoise";
            this.denoise_.MinimumWidth = 6;
            this.denoise_.Name = "denoise_";
            this.denoise_.ReadOnly = true;
            this.denoise_.Width = 24;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 24;
            // 
            // PercentDone
            // 
            this.PercentDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PercentDone.HeaderText = "% Done";
            this.PercentDone.MinimumWidth = 6;
            this.PercentDone.Name = "PercentDone";
            this.PercentDone.ReadOnly = true;
            this.PercentDone.Width = 24;
            // 
            // DstSize
            // 
            this.DstSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DstSize.HeaderText = "DstSize";
            this.DstSize.MinimumWidth = 6;
            this.DstSize.Name = "DstSize";
            this.DstSize.ReadOnly = true;
            this.DstSize.Width = 24;
            // 
            // Percent
            // 
            this.Percent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Percent.HeaderText = "% of Orig";
            this.Percent.MinimumWidth = 6;
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            this.Percent.Width = 24;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Time.HeaderText = "Enc. Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 24;
            // 
            // ETA
            // 
            this.ETA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ETA.HeaderText = "ETA";
            this.ETA.MinimumWidth = 6;
            this.ETA.Name = "ETA";
            this.ETA.ReadOnly = true;
            this.ETA.Width = 24;
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAddSelected.Location = new System.Drawing.Point(112, 5);
            this.btnAddSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(107, 28);
            this.btnAddSelected.TabIndex = 36;
            this.btnAddSelected.Text = "Add Selected";
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // CheckBoxRunHidden
            // 
            this.CheckBoxRunHidden.AutoSize = true;
            this.CheckBoxRunHidden.Location = new System.Drawing.Point(273, 33);
            this.CheckBoxRunHidden.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxRunHidden.Name = "CheckBoxRunHidden";
            this.CheckBoxRunHidden.Size = new System.Drawing.Size(100, 20);
            this.CheckBoxRunHidden.TabIndex = 37;
            this.CheckBoxRunHidden.Text = "Run Hidden";
            this.CheckBoxRunHidden.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 384);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(793, 25);
            this.progressBar.TabIndex = 38;
            // 
            // dgvSrc
            // 
            this.dgvSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSrc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.newRes,
            this.Duration,
            this.dataGridViewTextBoxColumn5,
            this.AudioCodec,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.AudioSize,
            this.AudioStreams,
            this.BitsPerPixel,
            this._codec,
            this._CRF,
            this._preset,
            this._Denoise});
            this.dgvSrc.Location = new System.Drawing.Point(4, 36);
            this.dgvSrc.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSrc.Name = "dgvSrc";
            this.dgvSrc.ReadOnly = true;
            this.dgvSrc.RowHeadersWidth = 51;
            this.dgvSrc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSrc.Size = new System.Drawing.Size(1499, 337);
            this.dgvSrc.TabIndex = 35;
            this.dgvSrc.SelectionChanged += new System.EventHandler(this.dataGridViewSrc_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "FileName";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "Size MB";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 24;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn4.HeaderText = "old Res.";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 24;
            // 
            // newRes
            // 
            this.newRes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.newRes.HeaderText = "new Res";
            this.newRes.MinimumWidth = 6;
            this.newRes.Name = "newRes";
            this.newRes.ReadOnly = true;
            this.newRes.Width = 24;
            // 
            // Duration
            // 
            this.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Duration.HeaderText = "Duration";
            this.Duration.MinimumWidth = 6;
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 24;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn5.HeaderText = "V. Rate";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 24;
            // 
            // AudioCodec
            // 
            this.AudioCodec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.AudioCodec.HeaderText = "A. Codec";
            this.AudioCodec.MinimumWidth = 6;
            this.AudioCodec.Name = "AudioCodec";
            this.AudioCodec.ReadOnly = true;
            this.AudioCodec.Width = 24;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "# of ch.";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.dataGridViewTextBoxColumn7.HeaderText = "A. Rate";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 24;
            // 
            // AudioSize
            // 
            this.AudioSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.AudioSize.HeaderText = "Audio Size";
            this.AudioSize.MinimumWidth = 6;
            this.AudioSize.Name = "AudioSize";
            this.AudioSize.ReadOnly = true;
            this.AudioSize.Width = 24;
            // 
            // AudioStreams
            // 
            this.AudioStreams.HeaderText = "# of A. Streams";
            this.AudioStreams.MinimumWidth = 6;
            this.AudioStreams.Name = "AudioStreams";
            this.AudioStreams.ReadOnly = true;
            this.AudioStreams.Width = 45;
            // 
            // BitsPerPixel
            // 
            this.BitsPerPixel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.BitsPerPixel.HeaderText = "B/(P*F)";
            this.BitsPerPixel.MinimumWidth = 6;
            this.BitsPerPixel.Name = "BitsPerPixel";
            this.BitsPerPixel.ReadOnly = true;
            this.BitsPerPixel.Width = 24;
            // 
            // _codec
            // 
            this._codec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this._codec.HeaderText = "[Codec]";
            this._codec.MinimumWidth = 6;
            this._codec.Name = "_codec";
            this._codec.ReadOnly = true;
            this._codec.Width = 24;
            // 
            // _CRF
            // 
            this._CRF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this._CRF.HeaderText = "[CRF]";
            this._CRF.MinimumWidth = 6;
            this._CRF.Name = "_CRF";
            this._CRF.ReadOnly = true;
            this._CRF.Width = 24;
            // 
            // _preset
            // 
            this._preset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this._preset.HeaderText = "[Preset]";
            this._preset.MinimumWidth = 6;
            this._preset.Name = "_preset";
            this._preset.ReadOnly = true;
            this._preset.Width = 24;
            // 
            // _Denoise
            // 
            this._Denoise.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this._Denoise.HeaderText = "[Denoise]";
            this._Denoise.MinimumWidth = 6;
            this._Denoise.Name = "_Denoise";
            this._Denoise.ReadOnly = true;
            this._Denoise.Width = 24;
            // 
            // btnClearSrc
            // 
            this.btnClearSrc.Location = new System.Drawing.Point(1120, 5);
            this.btnClearSrc.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSrc.Name = "btnClearSrc";
            this.btnClearSrc.Size = new System.Drawing.Size(83, 28);
            this.btnClearSrc.TabIndex = 39;
            this.btnClearSrc.Text = "Clear";
            this.btnClearSrc.UseVisualStyleBackColor = true;
            this.btnClearSrc.Click += new System.EventHandler(this.btnClearSrc_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1211, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 28);
            this.button4.TabIndex = 40;
            this.button4.Text = "Save Src Config";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1521, 28);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.addFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addFolderToolStripMenuItem.Text = "Add Folder...";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addFilesToolStripMenuItem.Text = "Add Files...";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setCurrentParamsAsDefaultToolStripMenuItem,
            this.selectDestinationForOutputFilesToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.runHiddenMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputFormatToolStripMenuItem,
            this.outputSuffixToolStripMenuItem,
            this.tbSuffixMenu});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.outputToolStripMenuItem.Text = "Output";
            // 
            // outputFormatToolStripMenuItem
            // 
            this.outputFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatMkvMenuItem,
            this.formatMp4MenuItem});
            this.outputFormatToolStripMenuItem.Name = "outputFormatToolStripMenuItem";
            this.outputFormatToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.outputFormatToolStripMenuItem.Text = "Output Format";
            // 
            // formatMkvMenuItem
            // 
            this.formatMkvMenuItem.CheckOnClick = true;
            this.formatMkvMenuItem.Name = "formatMkvMenuItem";
            this.formatMkvMenuItem.Size = new System.Drawing.Size(120, 26);
            this.formatMkvMenuItem.Text = "MKV";
            this.formatMkvMenuItem.Click += new System.EventHandler(this.formatMkvMenuItem_Click);
            // 
            // formatMp4MenuItem
            // 
            this.formatMp4MenuItem.CheckOnClick = true;
            this.formatMp4MenuItem.Name = "formatMp4MenuItem";
            this.formatMp4MenuItem.Size = new System.Drawing.Size(120, 26);
            this.formatMp4MenuItem.Text = "MP4";
            this.formatMp4MenuItem.Click += new System.EventHandler(this.formatMp4MenuItem_Click);
            // 
            // outputSuffixToolStripMenuItem
            // 
            this.outputSuffixToolStripMenuItem.Enabled = false;
            this.outputSuffixToolStripMenuItem.Name = "outputSuffixToolStripMenuItem";
            this.outputSuffixToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.outputSuffixToolStripMenuItem.Text = "Output File Suffix:";
            // 
            // tbSuffixMenu
            // 
            this.tbSuffixMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSuffixMenu.Name = "tbSuffixMenu";
            this.tbSuffixMenu.Size = new System.Drawing.Size(160, 27);
            this.tbSuffixMenu.ToolTipText = "Output file suffix";
            this.tbSuffixMenu.TextChanged += new System.EventHandler(this.tbSuffixMenu_TextChanged);
            // 
            // runHiddenMenuItem
            // 
            this.runHiddenMenuItem.CheckOnClick = true;
            this.runHiddenMenuItem.Name = "runHiddenMenuItem";
            this.runHiddenMenuItem.Size = new System.Drawing.Size(326, 26);
            this.runHiddenMenuItem.Text = "Run Hidden";
            // 
            // setCurrentParamsAsDefaultToolStripMenuItem
            // 
            this.setCurrentParamsAsDefaultToolStripMenuItem.Name = "setCurrentParamsAsDefaultToolStripMenuItem";
            this.setCurrentParamsAsDefaultToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.setCurrentParamsAsDefaultToolStripMenuItem.Text = "Set Current Params as Default";
            this.setCurrentParamsAsDefaultToolStripMenuItem.Click += new System.EventHandler(this.setCurrentParamsAsDefaultToolStripMenuItem_Click);
            // 
            // selectDestinationForOutputFilesToolStripMenuItem
            // 
            this.selectDestinationForOutputFilesToolStripMenuItem.Name = "selectDestinationForOutputFilesToolStripMenuItem";
            this.selectDestinationForOutputFilesToolStripMenuItem.Size = new System.Drawing.Size(326, 26);
            this.selectDestinationForOutputFilesToolStripMenuItem.Text = "Select Destination  for  Output Files";
            this.selectDestinationForOutputFilesToolStripMenuItem.Click += new System.EventHandler(this.selectDestinationForOutputFilesToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codecToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // codecToolStripMenuItem
            // 
            this.codecToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codecX265MenuItem,
            this.codecX264MenuItem,
            this.codecAv1MenuItem});
            this.codecToolStripMenuItem.Name = "codecToolStripMenuItem";
            this.codecToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.codecToolStripMenuItem.Text = "Codec";
            // 
            // codecX265MenuItem
            // 
            this.codecX265MenuItem.CheckOnClick = true;
            this.codecX265MenuItem.Name = "codecX265MenuItem";
            this.codecX265MenuItem.Size = new System.Drawing.Size(224, 26);
            this.codecX265MenuItem.Text = "x265";
            this.codecX265MenuItem.Click += new System.EventHandler(this.codecX265MenuItem_Click);
            // 
            // codecX264MenuItem
            // 
            this.codecX264MenuItem.CheckOnClick = true;
            this.codecX264MenuItem.Name = "codecX264MenuItem";
            this.codecX264MenuItem.Size = new System.Drawing.Size(224, 26);
            this.codecX264MenuItem.Text = "x264";
            this.codecX264MenuItem.Click += new System.EventHandler(this.codecX264MenuItem_Click);
            // 
            // codecAv1MenuItem
            // 
            this.codecAv1MenuItem.CheckOnClick = true;
            this.codecAv1MenuItem.Name = "codecAv1MenuItem";
            this.codecAv1MenuItem.Size = new System.Drawing.Size(224, 26);
            this.codecAv1MenuItem.Text = "AV1";
            this.codecAv1MenuItem.Click += new System.EventHandler(this.codecAv1MenuItem_Click);
            // 
            // tbCmdOut
            // 
            this.tbCmdOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCmdOut.Location = new System.Drawing.Point(80, 708);
            this.tbCmdOut.Margin = new System.Windows.Forms.Padding(4);
            this.tbCmdOut.Name = "tbCmdOut";
            this.tbCmdOut.Size = new System.Drawing.Size(1421, 22);
            this.tbCmdOut.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 713);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "Cmd Out:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "Denoise filter:";
            // 
            // comboDenoise
            // 
            this.comboDenoise.FormattingEnabled = true;
            this.comboDenoise.Location = new System.Drawing.Point(203, 38);
            this.comboDenoise.Margin = new System.Windows.Forms.Padding(4);
            this.comboDenoise.Name = "comboDenoise";
            this.comboDenoise.Size = new System.Drawing.Size(165, 24);
            this.comboDenoise.TabIndex = 48;
            // 
            // BtnSaveDstConfig
            // 
            this.BtnSaveDstConfig.Location = new System.Drawing.Point(1197, 380);
            this.BtnSaveDstConfig.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSaveDstConfig.Name = "BtnSaveDstConfig";
            this.BtnSaveDstConfig.Size = new System.Drawing.Size(157, 28);
            this.BtnSaveDstConfig.TabIndex = 54;
            this.BtnSaveDstConfig.Text = "Save Dst Config";
            this.BtnSaveDstConfig.UseVisualStyleBackColor = true;
            this.BtnSaveDstConfig.Click += new System.EventHandler(this.BtnSaveDstConfig_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioMp4);
            this.groupBox4.Controls.Add(this.radioMkv);
            this.groupBox4.Location = new System.Drawing.Point(101, 63);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(107, 80);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Out. Format";
            // 
            // radioMp4
            // 
            this.radioMp4.AutoSize = true;
            this.radioMp4.Location = new System.Drawing.Point(8, 52);
            this.radioMp4.Margin = new System.Windows.Forms.Padding(4);
            this.radioMp4.Name = "radioMp4";
            this.radioMp4.Size = new System.Drawing.Size(55, 20);
            this.radioMp4.TabIndex = 1;
            this.radioMp4.TabStop = true;
            this.radioMp4.Text = "MP4";
            this.radioMp4.UseVisualStyleBackColor = true;
            // 
            // radioMkv
            // 
            this.radioMkv.AutoSize = true;
            this.radioMkv.Location = new System.Drawing.Point(8, 22);
            this.radioMkv.Margin = new System.Windows.Forms.Padding(4);
            this.radioMkv.Name = "radioMkv";
            this.radioMkv.Size = new System.Drawing.Size(56, 20);
            this.radioMkv.TabIndex = 0;
            this.radioMkv.TabStop = true;
            this.radioMkv.Text = "MKV";
            this.radioMkv.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(131, 32);
            this.btnAddFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(105, 28);
            this.btnAddFiles.TabIndex = 57;
            this.btnAddFiles.Text = "Add Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "Out file Suffix: ";
            // 
            // tbSuffix
            // 
            this.tbSuffix.Location = new System.Drawing.Point(507, 30);
            this.tbSuffix.Margin = new System.Windows.Forms.Padding(4);
            this.tbSuffix.Name = "tbSuffix";
            this.tbSuffix.Size = new System.Drawing.Size(96, 22);
            this.tbSuffix.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericCrf);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxPreset);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboDenoise);
            this.groupBox1.Location = new System.Drawing.Point(8, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(380, 86);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video:"; 
            // 
            // numericCrf
            // 
            this.numericCrf.DecimalPlaces = 1;
            this.numericCrf.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericCrf.Location = new System.Drawing.Point(8, 39);
            this.numericCrf.Margin = new System.Windows.Forms.Padding(4);
            this.numericCrf.Name = "numericCrf";
            this.numericCrf.Size = new System.Drawing.Size(79, 22);
            this.numericCrf.TabIndex = 0;
            this.numericCrf.ValueChanged += new System.EventHandler(this.numericCrf_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioDisableAudio);
            this.groupBox5.Controls.Add(this.radioCopyAudio);
            this.groupBox5.Controls.Add(this.radioEncodeAAC);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBoxAAC);
            this.groupBox5.Location = new System.Drawing.Point(612, 30);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(267, 108);
            this.groupBox5.TabIndex = 61;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Audio";
            // 
            // radioDisableAudio
            // 
            this.radioDisableAudio.AutoSize = true;
            this.radioDisableAudio.Location = new System.Drawing.Point(8, 68);
            this.radioDisableAudio.Margin = new System.Windows.Forms.Padding(4);
            this.radioDisableAudio.Name = "radioDisableAudio";
            this.radioDisableAudio.Size = new System.Drawing.Size(113, 20);
            this.radioDisableAudio.TabIndex = 19;
            this.radioDisableAudio.TabStop = true;
            this.radioDisableAudio.Text = "Disable Audio";
            this.radioDisableAudio.UseVisualStyleBackColor = true;
            this.radioDisableAudio.CheckedChanged += new System.EventHandler(this.radioDisableAudio_CheckedChanged);
            // 
            // radioCopyAudio
            // 
            this.radioCopyAudio.AutoSize = true;
            this.radioCopyAudio.Location = new System.Drawing.Point(8, 44);
            this.radioCopyAudio.Margin = new System.Windows.Forms.Padding(4);
            this.radioCopyAudio.Name = "radioCopyAudio";
            this.radioCopyAudio.Size = new System.Drawing.Size(115, 20);
            this.radioCopyAudio.TabIndex = 18;
            this.radioCopyAudio.TabStop = true;
            this.radioCopyAudio.Text = "Copy all Audio";
            this.radioCopyAudio.UseVisualStyleBackColor = true;
            this.radioCopyAudio.CheckedChanged += new System.EventHandler(this.radioCopyAudio_CheckedChanged);
            // 
            // radioEncodeAAC
            // 
            this.radioEncodeAAC.AutoSize = true;
            this.radioEncodeAAC.Location = new System.Drawing.Point(8, 22);
            this.radioEncodeAAC.Margin = new System.Windows.Forms.Padding(4);
            this.radioEncodeAAC.Name = "radioEncodeAAC";
            this.radioEncodeAAC.Size = new System.Drawing.Size(75, 20);
            this.radioEncodeAAC.TabIndex = 17;
            this.radioEncodeAAC.TabStop = true;
            this.radioEncodeAAC.Text = "Encode";
            this.radioEncodeAAC.UseVisualStyleBackColor = true;
            this.radioEncodeAAC.CheckedChanged += new System.EventHandler(this.radioEncodeAAC_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(8, 148);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1513, 770);
            this.tabControl1.TabIndex = 62;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSrc);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label_status);
            this.tabPage1.Controls.Add(this.lblCurFile);
            this.tabPage1.Controls.Add(this.bntStop);
            this.tabPage1.Controls.Add(this.btnAddAllToList);
            this.tabPage1.Controls.Add(this.BtnSaveDstConfig);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnAddSelected);
            this.tabPage1.Controls.Add(this.tbCmdOut);
            this.tabPage1.Controls.Add(this.btnClearSrc);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.dgvDst);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1505, 741);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1505, 741);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Progress";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnClearLog);
            this.tabPage3.Controls.Add(this.btnOpenLog);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.tbLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1505, 741);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(268, 7);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 28);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(148, 7);
            this.btnOpenLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(100, 28);
            this.btnOpenLog.TabIndex = 2;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detailed Log:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(8, 42);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(1483, 697);
            this.tbLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 927);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Batch Video Encoder v0.68";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrc)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrf)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label lblCurFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bntStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelNewRes;
        private System.Windows.Forms.Button btnAddAllToList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvDst;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.CheckBox CheckBoxRunHidden;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dgvSrc;
        private System.Windows.Forms.Button btnClearSrc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbYresLimit;
        private System.Windows.Forms.TextBox tbXresLimit;
        private System.Windows.Forms.RadioButton radioNoResize;
        private System.Windows.Forms.RadioButton radioResizeByLimit;
        private System.Windows.Forms.RadioButton radioResizeByPercent;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCurrentParamsAsDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codecX265MenuItem;
        private System.Windows.Forms.ToolStripMenuItem codecX264MenuItem;
        private System.Windows.Forms.ToolStripMenuItem codecAv1MenuItem;
        private System.Windows.Forms.TextBox tbCmdOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboDenoise;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn newRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioCodec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioStreams;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitsPerPixel;
        private System.Windows.Forms.DataGridViewTextBoxColumn _codec;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CRF;
        private System.Windows.Forms.DataGridViewTextBoxColumn _preset;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Denoise;
        private System.Windows.Forms.Button BtnSaveDstConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn dst_res;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn v_rate_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn codec_;
        private System.Windows.Forms.DataGridViewTextBoxColumn crf_;
        private System.Windows.Forms.DataGridViewTextBoxColumn preset_;
        private System.Windows.Forms.DataGridViewTextBoxColumn denoise_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETA;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioMp4;
        private System.Windows.Forms.RadioButton radioMkv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ToolStripMenuItem selectDestinationForOutputFilesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSuffix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericCrf;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioDisableAudio;
        private System.Windows.Forms.RadioButton radioCopyAudio;
        private System.Windows.Forms.RadioButton radioEncodeAAC;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatMkvMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatMp4MenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputSuffixToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbSuffixMenu;
        private System.Windows.Forms.ToolStripMenuItem runHiddenMenuItem;
    }
}

