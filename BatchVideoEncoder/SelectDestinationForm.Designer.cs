namespace BatchVideoEncoder
{
    partial class SelectDestinationForm
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
            this.btnDstFormOk = new System.Windows.Forms.Button();
            this.btnDstFormCancel = new System.Windows.Forms.Button();
            this.radioUseSrcFolder = new System.Windows.Forms.RadioButton();
            this.radioUseOutputFolder = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOutputDir = new System.Windows.Forms.TextBox();
            this.btnBrowseOutDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDstFormOk
            // 
            this.btnDstFormOk.Location = new System.Drawing.Point(23, 183);
            this.btnDstFormOk.Name = "btnDstFormOk";
            this.btnDstFormOk.Size = new System.Drawing.Size(66, 24);
            this.btnDstFormOk.TabIndex = 0;
            this.btnDstFormOk.Text = "Ok";
            this.btnDstFormOk.UseVisualStyleBackColor = true;
            this.btnDstFormOk.Click += new System.EventHandler(this.btnDstFormOk_Click);
            // 
            // btnDstFormCancel
            // 
            this.btnDstFormCancel.Location = new System.Drawing.Point(111, 183);
            this.btnDstFormCancel.Name = "btnDstFormCancel";
            this.btnDstFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDstFormCancel.TabIndex = 1;
            this.btnDstFormCancel.Text = "Cancel";
            this.btnDstFormCancel.UseVisualStyleBackColor = true;
            this.btnDstFormCancel.Click += new System.EventHandler(this.btnDstFormCancel_Click);
            // 
            // radioUseSrcFolder
            // 
            this.radioUseSrcFolder.AutoSize = true;
            this.radioUseSrcFolder.Location = new System.Drawing.Point(23, 45);
            this.radioUseSrcFolder.Name = "radioUseSrcFolder";
            this.radioUseSrcFolder.Size = new System.Drawing.Size(113, 17);
            this.radioUseSrcFolder.TabIndex = 2;
            this.radioUseSrcFolder.TabStop = true;
            this.radioUseSrcFolder.Text = "Use Source Folder";
            this.radioUseSrcFolder.UseVisualStyleBackColor = true;
            this.radioUseSrcFolder.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioUseOutputFolder
            // 
            this.radioUseOutputFolder.AutoSize = true;
            this.radioUseOutputFolder.Location = new System.Drawing.Point(23, 68);
            this.radioUseOutputFolder.Name = "radioUseOutputFolder";
            this.radioUseOutputFolder.Size = new System.Drawing.Size(148, 17);
            this.radioUseOutputFolder.TabIndex = 3;
            this.radioUseOutputFolder.TabStop = true;
            this.radioUseOutputFolder.Text = "Save Output to this folder:";
            this.radioUseOutputFolder.UseVisualStyleBackColor = true;
            this.radioUseOutputFolder.CheckedChanged += new System.EventHandler(this.radioUseOutputFolder_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Where to save output files ?";
            // 
            // tbOutputDir
            // 
            this.tbOutputDir.Location = new System.Drawing.Point(23, 118);
            this.tbOutputDir.Name = "tbOutputDir";
            this.tbOutputDir.Size = new System.Drawing.Size(251, 20);
            this.tbOutputDir.TabIndex = 53;
            // 
            // btnBrowseOutDir
            // 
            this.btnBrowseOutDir.Location = new System.Drawing.Point(23, 91);
            this.btnBrowseOutDir.Name = "btnBrowseOutDir";
            this.btnBrowseOutDir.Size = new System.Drawing.Size(52, 23);
            this.btnBrowseOutDir.TabIndex = 54;
            this.btnBrowseOutDir.Text = "Browse..";
            this.btnBrowseOutDir.UseVisualStyleBackColor = true;
            this.btnBrowseOutDir.Click += new System.EventHandler(this.btnBrowseOutDir_Click);
            // 
            // SelectDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 224);
            this.Controls.Add(this.btnBrowseOutDir);
            this.Controls.Add(this.tbOutputDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioUseOutputFolder);
            this.Controls.Add(this.radioUseSrcFolder);
            this.Controls.Add(this.btnDstFormCancel);
            this.Controls.Add(this.btnDstFormOk);
            this.Name = "SelectDestination";
            this.Text = "SelectDestination";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDstFormOk;
        private System.Windows.Forms.Button btnDstFormCancel;
        private System.Windows.Forms.RadioButton radioUseSrcFolder;
        private System.Windows.Forms.RadioButton radioUseOutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOutputDir;
        private System.Windows.Forms.Button btnBrowseOutDir;
    }
}