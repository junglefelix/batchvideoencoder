using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediaInfoNET;
using System.Text.RegularExpressions;
using NLog;
using System.Reflection;
using System.Diagnostics;
using BatchVideoEncoder.Helpers;

namespace BatchVideoEncoder
{
    public partial class Form1 : Form
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        #region Members


        public static string logFile = "log.txt";
        string folderPath = "";
        //List<string> fileList;
        //List<string> fileLIstToEncode;
        //bool test_started = false;
        int currentFileIndex = 0;
        //int filesToEncode = 0;
        int step = 0;
        string tempDir = "";
        int xRes, yRes;
        string resize = "";

        
        System.Timers.Timer aTimer = null;

        private int curDstFileIndex = 0;
        //DateTime BeginOneFile, EndOneFile, BeginAllFiles, EndAllFiles;
        List<MovieEntry> SrcDB = new List<MovieEntry>();
        List<MovieEntry> DstDB = new List<MovieEntry>();
        MovieEntry defaultParams = new MovieEntry();

        CancellationTokenSource cancelToken = new CancellationTokenSource();
        //private bool IsEditingSrcGV;
        private double selectedEntryRatio;
        public static Form1 Instance { get; private set; }

        #endregion
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            tbSuffixMenu.Text = Settings.Default.OutFileSuffix;
            textBoxAAC.Text = Settings.Default.NeroAaacDefaultQuality;
            numericCrf.Value = Convert.ToDecimal(Settings.Default.X265DefaultCrf);
            comboBoxPreset.Items.AddRange(Settings.Default.X265Presets.Split(','));
            comboBoxPreset.SelectedItem = Settings.Default.defaultVideoPreset;
            radioEncodeAAC.Checked = true;
            numericUpDown1.Value = 100;
            MediaProcessingHelper.workingDir = Directory.GetCurrentDirectory();
            radioNoResize.Checked = true;
            tbXresLimit.Text = "720";
            tbYresLimit.Text = "480";
            runHiddenMenuItem.Checked = true;
            codecX265MenuItem.Checked = true;

            formatMkvMenuItem.Checked = true;
            formatMp4MenuItem.Checked = false;

            foreach (var filter in Settings.Default.NoiseFilters)
            {
                comboDenoise.Items.Add(filter.Split(',')[0]);
            }
            comboDenoise.SelectedIndex = 0;

            logger.Info("---------------------------------------------------------");
            logger.Info("---------------------------------------------------------");
            logger.Info("-------------------- APP LAUNCHED  ----------------------");
            logger.Info("---------------------------------------------------------");
            logger.Info("---------------------------------------------------------");

            tempDir = PrepareTempDir();
        }

        public static void LogMethod(string message)
        {
            if (Instance != null)
            {

                UiUpdateHelper.updateUI(Instance.tbLog, () => Instance.tbLog.AppendText(message + Environment.NewLine));

            }
        }
        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                SaveCurrentGuiParamsToDbEntry(defaultParams);
                dgvSrc.Rows.Clear();
                var allVideoFiles = AddSupportedFilesFromDir(folderPath);
                AddFilesToSrcDB(allVideoFiles);
                PopulateSrcDGVfromSrcDB();
            }
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Multiselect = true;
            theDialog.Title = "Open Media File";
            theDialog.Filter = "All files|*.*";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> supportedFiles = GetFilesFromDroppedLocations(theDialog.FileNames);
                AddFilesToSrcDB(supportedFiles);
                PopulateSrcDGVfromSrcDB();
            }
        }

        private void formatMkvMenuItem_Click(object sender, EventArgs e)
        {
            formatMkvMenuItem.Checked = true;
            formatMp4MenuItem.Checked = false;
        }

        private void formatMp4MenuItem_Click(object sender, EventArgs e)
        {
            formatMp4MenuItem.Checked = true;
            formatMkvMenuItem.Checked = false;
        }

        private void tbSuffixMenu_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            addFolderToolStripMenuItem_Click(sender, e);
        }
 

        private void PopulateSrcDGVfromSrcDB()
        {
            dgvSrc.Rows.Clear();
            //foreach (var dbEntry in SrcDB)
            for(int i = 0; i < SrcDB.Count; i++)
            {
                var dbEntry = SrcDB[i];
                var file = new FileInfo(dbEntry.fullFilePath);

                dgvSrc.Rows.Add(
                    i + 1,
                    dbEntry.fileNameOnly,
                    (long)file.Length / (1024 * 1024),
                    dbEntry.origResStr,
                    dbEntry.newResStr,
                    dbEntry.durationStr,
                    dbEntry.vRate.ToString(),
                    dbEntry.aCodec,
                    dbEntry.numOfAudioChannels.ToString(),
                    dbEntry.aRate.ToString(),
                    dbEntry.aSizeStr,
                    dbEntry.aStreams.ToString(),
                    dbEntry.bitsPixelFrameStr,
                    GetCodecLabel(dbEntry.videoCodec),
                    dbEntry.crf,
                    //dbEntry.preset.ToString(),
                    dbEntry.presetStr,
                    dbEntry.DenoiseFilterName.Split(' ').First()
                    );
            }
        }

        private void AddFilesToSrcDB(List<string> fileList)
        {
            //SrcDB.Clear();
            for (int i = 0; i < fileList.Count; i++)
            {
                MovieEntry dbEntry = new MovieEntry(i, fileList[i]);
                MediaFile movie = new MediaFile(fileList[i]);
                if (movie == null) return;
                if (movie.Video.Count > 0 && movie.Audio.Count > 0)
                {
                    dbEntry.xRes = dbEntry.NewXRes =  movie.Video[0].Width;
                    dbEntry.yRes =dbEntry.NewYRes =  movie.Video[0].Height;
                    //dbEntry.origResStr = dbEntry.xRes.ToString() + "x" + dbEntry.yRes.ToString();
                    //dbEntry.newResStr = dbEntry.NewXRes.ToString() + "x" + dbEntry.NewYRes.ToString();
                    dbEntry.durationStr = movie.Video[0].DurationString.ToString();
                    dbEntry.vRate = movie.Video[0].Bitrate;
                    dbEntry.aCodec = movie.Audio[0].FormatID.ToString();
                    dbEntry.numOfAudioChannels = movie.Audio[0].Channels;
                    dbEntry.aRate = movie.Audio[0].Bitrate;
                    if (movie.Audio[0].Properties.ContainsKey("Stream size"))
                    {
                        dbEntry.aSizeStr = movie.Audio[0].Properties["Stream size"].ToString();
                        dbEntry.aSizeMB = GeneralHelper.getSizeInKB(dbEntry.aSizeStr);
                    }
                    if (movie.Video[0].Properties.ContainsKey("Stream size"))
                    {
                        dbEntry.vSizeStr = movie.Video[0].Properties["Stream size"].ToString();
                        dbEntry.vSizeMB = GeneralHelper.getSizeInKB(dbEntry.vSizeStr);
                    }
                    dbEntry.aStreams = movie.Audio.Count;
                    if (movie.Video[0].Properties.ContainsKey("Bits/(Pixel*Frame)"))
                    {
                        dbEntry.bitsPixelFrameStr = movie.Video[0].Properties["Bits/(Pixel*Frame)"].ToString();
                    }
                    dbEntry.totFrames = movie.FrameCount;
                }
                SetDefaultEncParamsForDbEntry(dbEntry);

                SrcDB.Add(dbEntry);
            }
            if (!string.IsNullOrEmpty(Settings.Default.OutputDirectory) && !Directory.Exists(Settings.Default.OutputDirectory))
            {
                Directory.CreateDirectory(Settings.Default.OutputDirectory);
            }
        }

        
        private void btnAddAllToList_Click(object sender, EventArgs e) //  ADD ALL TO LIST BUTTON
        {
            DstDB.AddRange(SrcDB);
            SrcDB.Clear();
            SaveCurrentGuiParamsToDbEntry(defaultParams);
            foreach(var dbEntry in DstDB)
            {
                SetDefaultEncParamsForDbEntry(dbEntry);
            }
            UpdateDstDGV();
            dgvSrc.Rows.Clear();
        }

        private void UpdateDstDGV()
        {
            dgvDst.Rows.Clear();
            int fileIndex = 0;
            foreach (var dbEntry in DstDB)
            {
                if (dbEntry == null) continue;
                if(!System.IO.File.Exists(dbEntry.fullFilePath))
                {
                    logger.Error("Error! About to add entry to dst GridView. File: " + dbEntry.fullFilePath + " does not exist!!");
                    continue;
                }
                FileInfo file = new FileInfo(dbEntry.fullFilePath);
                fileIndex++; // current file index
                string curFileName = Path.GetFileName(dbEntry.fullFilePath); // file name
                string status = "Not Done"; // status
                long srcFileSizeMb = (long)file.Length / (1024 * 1024); //Source File Size
                string length = "n/a";
                string resolution = "n/a";
                string percentDone = "0%";
                // find the entry in the dst database.
                //dbEntry = DstDB.FirstOrDefault(r => r.fileNameOnly == curFileName);

                length = dbEntry.durationStr;
                resolution = dbEntry.newResStr;


                //dgvDst.Rows.Add(fileIndex, curFileName, status, srcFileSizeMb, length, resolution, percentDone);
                dgvDst.Rows.Add(
                    fileIndex,
                    dbEntry.fileNameOnly,
                    (long)file.Length / (1024 * 1024),
                    dbEntry.origResStr,
                    dbEntry.newResStr,
                    dbEntry.durationStr,
                    dbEntry.vRate.ToString(),
                    dbEntry.aCodec,
                    dbEntry.numOfAudioChannels.ToString(),
                    dbEntry.aRate.ToString(),
                    dbEntry.aSizeStr,
                    dbEntry.aStreams.ToString(),
                    dbEntry.bitsPixelFrameStr,
                    GetCodecLabel(dbEntry.videoCodec),
                    dbEntry.crf,
                    //dbEntry.preset.ToString(),
                    dbEntry.presetStr,
                    dbEntry.DenoiseFilterName.Split(' ').First(),
                    status,
                    percentDone,
                    "n/a",  // DstSize
                    "n/a", // % of orig
                    "n/a", // enc time
                    "n/a" // ETA

                    );

            }
        }


        private void btnStart_Click(object sender, EventArgs e) 
        {
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = DstDB.Count;
            progressBar.Step = 1;
            progressBar.Value = 0;

            currentFileIndex = 0; // reset loops

            MediaProcessingHelper.isRunHidden = runHiddenMenuItem.Checked;
            if (DstDB.Any())
            {
                // go over all dst db, and update with latest ui changes - as suffix,extension,codec, etc.
                updateTargetFileNamesInDstDb();

                btnStart.Enabled = false;
                var work = Task.Run(() => StartWork(), cancelToken.Token);
            }

        }

        private void updateTargetFileNamesInDstDb()
        {
            foreach (var entry in DstDB)
            {

                string targetOutFileDir = string.IsNullOrEmpty(Settings.Default.OutputDirectory) ? Path.GetDirectoryName(entry.fullFilePath) : Settings.Default.OutputDirectory;
                string name = Path.GetFileNameWithoutExtension(entry.fullFilePath);

                entry.dstEncodedFile = Path.Combine(targetOutFileDir, name + tbSuffixMenu.Text + (formatMkvMenuItem.Checked ? ".mkv" : ".mp4"));
                entry.encodedAacFile = Path.Combine(tempDir, name + GeneralHelper.GenerateRandomWord(5, 5) + ".mp4");
                logger.Info("encoded aac mp4 file: " + entry.encodedAacFile);
                entry.videoCodec = GetSelectedCodec();
               
            }
        }

        private void StartWork()
        {
            for (int fileCnt = 0; fileCnt < /*fileLIstToEncode.Count*/ DstDB.Count; fileCnt++)
            {
                curDstFileIndex = fileCnt;
                var curDbEntry = DstDB[fileCnt];
                UiUpdateHelper.update_label(lblCurFile, (fileCnt + 1).ToString() + "/" + (DstDB.Count).ToString());
                //loop_running = true;
                UiUpdateHelper.update_label(label_status, "Running");
                DstDB[fileCnt].TimeStartedEncoding = DateTime.Now;
                var curFile = curDbEntry.fullFilePath; //  fileLIstToEncode[fileCnt];

         
                if(curDbEntry.audioMode == AudioMode.Encode)
                {
                    #region Audio Encoding
                UiUpdateHelper.updateGridView(dgvDst, 17, fileCnt, "Enc. Audio...");
                var encodeAudioTask = Task.Factory.StartNew(() => MediaProcessingHelper.encodeAudio(curDbEntry), CancellationToken.None,
                    TaskCreationOptions.LongRunning, TaskScheduler.Default);
                encodeAudioTask.Wait();
                if (encodeAudioTask.Result == false)
                {
                    UiUpdateHelper.updateGridView(dgvDst, 17, fileCnt, "! Audio Fail !");
                    logger.Info("!! Error !! Audio Encoding failed. Aborting current encoding..");
                    continue;
                }
                logger.Info( "Audio Encoding finished successfully."); 
                #endregion
                }

                UiUpdateHelper.updateGridView(dgvDst, 17, fileCnt, "Enc. Video...");

                var encodeVideoTask = Task.Factory.StartNew(() => MediaProcessingHelper.encodeVideoFFMpeg(curDbEntry, ProgressCallback), CancellationToken.None,
                    TaskCreationOptions.LongRunning, TaskScheduler.Default);
                encodeVideoTask.Wait();
                if(encodeVideoTask.Result == false)
                {
                    UiUpdateHelper.updateGridView(dgvDst, 17, fileCnt, "! Video Fail !"); 
                    logger.Error("!! Error !! Video Encoding failed. Aborting current encoding..");

                    continue;
                }
                logger.Info("Video Encoding finished successfully.");

                var updateInfoTask = Task.Factory.StartNew(() => UpdateInfo(curDbEntry, fileCnt, DstDB.Count), CancellationToken.None,
                    TaskCreationOptions.LongRunning, TaskScheduler.Default);
                //updateGridView(dataGridViewDst, 2, "Updating Info");

                updateInfoTask.Wait();
                if (cancelToken.IsCancellationRequested) break;
            }
            UiUpdateHelper.update_label(label_status, "Stopped");
            UiUpdateHelper.update_btn(btnStart, true);
        }
        private string PrepareTempDir()
        {
            string curDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string tempDir = Path.Combine(curDir, "Temp");
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            //FileHelper.EmptyDirectory(tempDir); // other instanced may be working - don't empty.
            return tempDir;
        }
        private void ProgressCallback(string line, bool IsOutput)
        {
            if (line == null) return;
            //logger.Info("### ProgressCallback invoked. Text=" + line);
            //if (IsOutput) Helper.updateTextBox(tbCmdOut, line);
            UiUpdateHelper.updateTextBox(tbCmdOut,  line);
            // parse the cmd output.
            var curDstDbEntry = DstDB[curDstFileIndex];
            if (curDstDbEntry == null) return;
            // cmd Out sample: frame=46977 fps=6.7 q=-0.0 size=  202918kB time=00:31:18.43 bitrate= 884.9kbits/s speed=0.268x
            // cmd Out Sampel2:frame=  331 fps=3.0 q=-0.0 size=     369kB time=00:00:12.06 bitrate= 250.4kbits/s speed=0.11x
            var regex1 = new Regex(@"frame\s*=\s*\d+");
            var strOut = regex1.Match(line).Value; // should match "frame = 12345"
            //logger.Info("First regex=" + strOut);

            var regex2 = new Regex(@"\d+");
            var curFrameStr = regex2.Match(strOut).Value; // should match "12345"
            //logger.Info("Second regex=" + curFrameStr);

            if (curFrameStr != string.Empty)
            {
                int curFrame = Convert.ToInt32(curFrameStr);
                double percentDone = (double)curFrame * 100.0 / (double)curDstDbEntry.totFrames;
                string percentDoneStr = Math.Round(percentDone, 1).ToString();
                // write current percentage to the DB entry itself.
                curDstDbEntry.curPercentDone = percentDone;
                UiUpdateHelper.updateGridView(dgvDst, 18, curDstFileIndex, percentDoneStr); //% Done

                // calculate ETA
                // col10 - ETA
                var regexFPS1 = new Regex(@"fps\s*=\s*\d+\.*\d*");
                var fpsPattern = regexFPS1.Match(line).Value;
                var regexFPS2 = new Regex(@"\d+\.*\d*");
                string fpsValueStr = regexFPS2.Match(fpsPattern).Value;
                if(fpsValueStr!= string.Empty)
                {
                    double fpsValue = Convert.ToDouble(fpsValueStr);

                    if (fpsValue > 0.0)
                    {
                        int remainingFrames = curDstDbEntry.totFrames - curFrame;
                        double secondsToEncode = (double)remainingFrames / fpsValue;
                        TimeSpan ts = TimeSpan.FromSeconds(secondsToEncode);
                        string ETAstr = ts.ToString(@"hh\:mm\:ss");
                        UiUpdateHelper.updateGridView(dgvDst, 22, curDstFileIndex, ETAstr); //% ETA 
                    }
                }
            }
            // update encoding time.
            var encodingTime = DateTime.Now - curDstDbEntry.TimeStartedEncoding;
            string encTimeStr = encodingTime.ToString(@"hh\:mm\:ss");
            UiUpdateHelper.updateGridView(dgvDst, 21, curDstFileIndex, encTimeStr); //% enc time 


        }

        private void UpdateInfo(MovieEntry dbEntry, int rowCnt, int totFiles)
        {
            logger.Info("Entered analyze()");

            try
            {
                UiUpdateHelper.updateProgressBar(progressBar, rowCnt + 1, totFiles);
                //EndOneFile = DateTime.Now;
                TimeSpan TimeForOneFile = DateTime.Now - dbEntry.TimeStartedEncoding;

                #region Check that Dst File exists
                logger.Info( "Dst File path= " + dbEntry.dstEncodedFile);
                if (!System.IO.File.Exists(dbEntry.dstEncodedFile))
                {
                    logger.Info("Error! Dst File not found, path= " + dbEntry.dstEncodedFile);
                    UiUpdateHelper.updateGridView(dgvDst, 17, rowCnt, "! Update Info FAILED !"); // status
                    return;
                } 
                #endregion
               logger.Info( "Dst File was found, path= " + dbEntry.dstEncodedFile);
                string dstVideoFilePath = dbEntry.dstEncodedFile;
                FileInfo SrcFile = new FileInfo(dbEntry.fullFilePath);

               
                FileInfo DstFile = new FileInfo(dbEntry.dstEncodedFile);
                UiUpdateHelper.updateGridView(dgvDst, 17 , rowCnt, "Done"); // status
                UiUpdateHelper.updateGridView(dgvDst, 19 , rowCnt, ((long)DstFile.Length / (1024 * 1024)).ToString()); // dst size
                UiUpdateHelper.updateGridView(dgvDst, 20 , rowCnt, ((int)(DstFile.Length * 100 / SrcFile.Length)).ToString()); // % Tot
                UiUpdateHelper.updateGridView(dgvDst, 21, rowCnt, TimeForOneFile.ToString(@"hh\:mm\:ss"));  //time

                // if <% done>  field is near 100% (like 99.7%) - replace it with 100% 
               
                    logger.Info("##curPercent is: " + dbEntry.curPercentDone);

                    if (dbEntry.curPercentDone > 90)
                    {
                        UiUpdateHelper.updateGridView(dgvDst, 18, rowCnt, "100.0");
                        logger.Info("## Updating Grid View with value 100.0");
                    }
            }
            catch (Exception ex)
            {
                logger.Error( "! Error ! occurred in updateInfo(), ex={0}{1}", Environment.NewLine, ex.ToString());
            }
        }
        private List<string> AddSupportedFilesFromDir(string folderPath)
        {
            var supportedExtensions = Settings.Default.SupportedFileExtensions.Split(',');
            var allFiles = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories);
            return allFiles.Where(f => supportedExtensions.Contains(Path.GetExtension(f).ToLower())).ToList();
        }
  
        private void bntStop_Click(object sender, EventArgs e) // TODO !!!
        {
            //test_started = false ;
            cancelToken.Cancel(false);
            label_status.Text = "Cancelled..";
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //checkBoxResize.Checked = true;
            radioResizeByPercent.Checked = true;
        }
        
        private void btnClear_Click(object sender, EventArgs e) // Clear Button
        {
            // Cannot clear just like that - at least need to leave file that is currently running.
            DstDB.Clear();
            dgvDst.Rows.Clear();
        }
        private void btnAddSelected_Click(object sender, EventArgs e) // Add Selected Button // 
        {
            List<int> removeIndexes = new List<int>();
            foreach (var row in dgvSrc.SelectedRows)
            {
                var curRow = (DataGridViewRow)row;
                removeIndexes.Add(curRow.Index);
            }
            foreach(var rowIndex in removeIndexes.OrderByDescending( t => t))
            {
                var matchingDbEntry = SrcDB[rowIndex];
                DstDB.Add(matchingDbEntry);
                SrcDB.Remove(matchingDbEntry);
            }
            SaveCurrentGuiParamsToDbEntry(defaultParams);
            foreach (var dbEntry in DstDB)
            {
                SetDefaultEncParamsForDbEntry(dbEntry);
            }
            PopulateSrcDGVfromSrcDB();
            UpdateDstDGV();
            
        }

 

        private void SetDefaultEncParamsForDbEntry(MovieEntry entry)
        {
            if (!entry.useDefaultParams) return;
            entry.crf = defaultParams.crf;
            entry.nr = defaultParams.nr; // ???
            entry.aQuality = defaultParams.aQuality;
            //entry.preset = defaultParams.preset;
            entry.presetStr = defaultParams.presetStr;
            entry.videoCodec = defaultParams.videoCodec;
            entry.resize = defaultParams.resize;
            entry.ResizePercentage = defaultParams.ResizePercentage;
            entry.NewXRes = defaultParams.NewXRes;
            entry.NewYRes = defaultParams.NewYRes;
            entry.useNoiseFilter = defaultParams.useNoiseFilter;
            entry.DenoiseFilterName = defaultParams.DenoiseFilterName;
            entry.DenoiseFilterStr = defaultParams.DenoiseFilterStr;
            entry.audioMode = defaultParams.audioMode;


            entry.calculateNewRes();

        }

  
        
        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Save the current gui state as default template
            SaveCurrentGuiParamsToDbEntry(defaultParams);
            string[] DroppedFileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> supportedFiles = GetFilesFromDroppedLocations(DroppedFileList);

            AddFilesToSrcDB(supportedFiles);
            PopulateSrcDGVfromSrcDB();
        }
        private void dataGridViewSrc_SelectionChanged(object sender, EventArgs e)
        {
            //IsEditingSrcGV = true;
            var selectedRowIndex = dgvSrc.CurrentCell.RowIndex;
            var selectedFileName = dgvSrc.Rows[selectedRowIndex].Cells[1].Value;
            if (selectedFileName != null && !string.IsNullOrWhiteSpace(selectedFileName.ToString()))
            {
                // find the corresponding db entry
                if (selectedRowIndex > SrcDB.Count - 1) return;
                var selectedDbEntry = SrcDB[selectedRowIndex];
                //if (selectedDbEntry == null) return;
                GetGuiParamsFromDb(selectedDbEntry);
            }
        }

        private void dataGridViewDst_SelectionChanged(object sender, EventArgs e)
        {
            //IsEditingSrcGV = false;
            var selectedRowIndex = dgvDst.CurrentCell.RowIndex;
            var selectedFileName = dgvDst.Rows[selectedRowIndex].Cells[1].Value;
            if (selectedFileName != null &&!string.IsNullOrWhiteSpace(selectedFileName.ToString()))
            {
                // find the db entry by filename
                var selectedDbEntry = DstDB.FirstOrDefault(r => r.fileNameOnly == selectedFileName.ToString());
                if (selectedDbEntry == null) return;
                GetGuiParamsFromDb(selectedDbEntry);
            }

        }

        private void GetGuiParamsFromDb(MovieEntry selectedDbEntry)
        {
            if (selectedDbEntry == null) return;
            // In any case - get the current resolution.
            selectedEntryRatio = selectedDbEntry.inputRatio;
            
            tbXresLimit.Text = selectedDbEntry.xRes.ToString();
            tbYresLimit.Text = selectedDbEntry.yRes.ToString();
            if (selectedDbEntry.useDefaultParams == false)
            {
                LoadGuiParams(selectedDbEntry);
            }
            else
            {
                LoadGuiParams(defaultParams);
            }
        }

        // loads GUi params from supplied DB entry
        private void LoadGuiParams(MovieEntry dbEntry)
        {
            //textBoxCRF.Text = dbEntry.crf.ToString();
            numericCrf.Value = Convert.ToDecimal(  dbEntry.crf);
            //textBoxNR.Text = dbEntry.nr.ToString();
            textBoxAAC.Text = dbEntry.aQuality.ToString();
            //comboBoxPreset.Text = dbEntry.preset.ToString();
            comboBoxPreset.Text = dbEntry.presetStr;
            


            switch (dbEntry.resize)
            {
                case ResizeOption.NoResize:
                    radioNoResize.Checked = true;
                    break;
                case ResizeOption.ResizeByPercent:
                    radioResizeByPercent.Checked = true;
                    numericUpDown1.Value = dbEntry.ResizePercentage;


                    break;
                case ResizeOption.LimitRes:
                    radioResizeByLimit.Checked = true;
                    //tbXresLimit.Text = dbEntry.NewXRes.ToString();
                    //tbYresLimit.Text = dbEntry.NewYRes.ToString();
                    tbXresLimit.Text = dbEntry.limitXres.ToString();
                    tbYresLimit.Text = dbEntry.limitYres.ToString();

                    break;
                default:
                    break;
            }
            SetCheckedCodecMenuItem(dbEntry.videoCodec);
            //cbNoiseFilter.Checked = dbEntry.useNoiseFilter;
            if(dbEntry.useNoiseFilter == false)
            {
                comboDenoise.SelectedIndex = 0;
            }
            else
            {
                comboDenoise.SelectedItem = dbEntry.DenoiseFilterName;
                //dbEntry.DenoiseFilterStr
            }

        }

        private void radioNoResize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewDst_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            // If entry in Dst Data  Grid is selected - capture the GUI state and save it to specific file settings.
        }
        
        private void btnClearSrc_Click(object sender, EventArgs e)
        {
            dgvSrc.Rows.Clear();
            SrcDB.Clear();
            //fileList.Clear();
        }

        private void btnResolutionUP_click(object sender, EventArgs e)
        {
            radioResizeByLimit.Checked = true;

            int step = 16;
            SetNewRes(step);

        }

        private void SetNewRes(int step)
        {
            //dataGridViewSrc_SelectionChanged(null, null);
            var oldХ = int.Parse(tbXresLimit.Text);
            var oldY = int.Parse(tbYresLimit.Text);
            double ratio = selectedEntryRatio;//(double)oldХ / (double)oldY;
            int newX = oldХ + step;
            int newY = UiUpdateHelper.to_nearest_16(((newX) / ratio));

            tbXresLimit.Text = newX.ToString();
            tbYresLimit.Text = newY.ToString();
        }

        private void btnResolutionDown_Click(object sender, EventArgs e)
        {
            radioResizeByLimit.Checked = true;
            int step = -16;
            SetNewRes(step);
        }

        private void btnSaveConfig_Click(object sender, EventArgs e) // Save config Button. 
        {
            //dataGridViewDst.SelectedCells[0].RowIndex
            SetDbEntryFromGui(dgvSrc, SrcDB);
            //else SetDbEntryFromGui(dataGridViewDst, DstDB);

        }

        private void SetDbEntryFromGui(DataGridView dgv, List<MovieEntry> DB)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (var row in dgv.SelectedRows)
                {
                    var curRow = (DataGridViewRow)row;
                    var rowIndex = curRow.Index;
                    //var selectedFileName = dgv.Rows[rowIndex].Cells[1].Value;
                    //if (selectedFileName == null) return;
                    //var matchingDbEntry = DB.FirstOrDefault(d => d.fullFilePath == selectedFileName.ToString());
                    //if (matchingDbEntry == null) return;
                    // Row index should be the same as SrcDB index
                    if (rowIndex > DB.Count - 1) continue;
                    var matchingDbEntry = DB[rowIndex];

                    SaveCurrentGuiParamsToDbEntry(matchingDbEntry);
                    // in case it is Src DGV - update relevant fields
                    //if (dgv == dataGridViewSrc)
                    //{
                    if (radioResizeByLimit.Checked || radioResizeByPercent.Checked) dgv.Rows[rowIndex].Cells[4].Value = matchingDbEntry.newResStr;
                    dgv.Rows[rowIndex].Cells[13].Value = GetCodecLabel(matchingDbEntry.videoCodec);
                    dgv.Rows[rowIndex].Cells[14].Value = matchingDbEntry.crf;
                    dgv.Rows[rowIndex].Cells[15].Value = matchingDbEntry.presetStr;
                    //dgv.Rows[rowIndex].Cells[15].Value = matchingDbEntry.preset.ToString();
                    dgv.Rows[rowIndex].Cells[16].Value = matchingDbEntry.DenoiseFilterName.Split(' ').First();


                    

                }
            }
        }

        private void SaveCurrentGuiParamsToDbEntry(MovieEntry dbEntry)
        {
            dbEntry.useDefaultParams = false;
            dbEntry.NewXRes = Convert.ToInt32(tbXresLimit.Text);
            dbEntry.NewYRes = Convert.ToInt32(tbYresLimit.Text);
            dbEntry.crf = Convert.ToDouble(numericCrf.Value);
            //dbEntry.nr = Convert.ToDouble(textBoxNR.Text);
            dbEntry.aQuality = Convert.ToDouble(textBoxAAC.Text);
            //dbEntry.preset = (Preset)Enum.Parse(typeof(Preset), comboBoxPreset.Text);
            dbEntry.presetStr = comboBoxPreset.Text;
            if (radioNoResize.Checked)
            {
                dbEntry.resize = ResizeOption.NoResize;
            }
            else if (radioResizeByPercent.Checked)
            {
                dbEntry.resize = ResizeOption.ResizeByPercent;
                dbEntry.ResizePercentage = (int)numericUpDown1.Value;
            }
            else if (radioResizeByLimit.Checked)
            {
                dbEntry.resize = ResizeOption.LimitRes;
                //dbEntry.NewXRes = Convert.ToInt32(tbXresLimit.Text);
                //dbEntry.NewYRes = Convert.ToInt32(tbYresLimit.Text);
                dbEntry.limitXres = Convert.ToInt32(tbXresLimit.Text);
                dbEntry.limitYres = Convert.ToInt32(tbYresLimit.Text);
            }

            dbEntry.videoCodec = GetSelectedCodec();
            //dbEntry.useNoiseFilter = cbNoiseFilter.Checked;

            dbEntry.useNoiseFilter = (comboDenoise.SelectedIndex != 0);
            dbEntry.DenoiseFilterName = comboDenoise.Text;
            foreach (var filter in Settings.Default.NoiseFilters)
            {
                string filterName = filter.Split(',')[0];
                if(filterName==  comboDenoise.Text)
                {
                    dbEntry.DenoiseFilterStr = filter.Split(',')[1];
                }

            }
            //if(dbEntry.useNoiseFilter) dbEntry.DenoiseFilterStr = appConfigDict[dbEntry.DenoiseFilterName];
            dbEntry.audioMode = radioEncodeAAC.Checked ? AudioMode.Encode : radioCopyAudio.Checked ? AudioMode.Copy : AudioMode.Disable;

            dbEntry.calculateNewRes();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }




        private void BtnSaveDstConfig_Click(object sender, EventArgs e)
        {
            SetDbEntryFromGui(dgvDst, DstDB);
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            addFilesToolStripMenuItem_Click(sender, e);
        }
        private List<string> GetFilesFromDroppedLocations(string[] droppedList)
        {
            var supportedExtensions = Settings.Default.SupportedFileExtensions.Split(',');
            List<string> mediaFiles = new List<string>();
            foreach (string fileOrFolder in droppedList)
            {
                if (System.IO.File.Exists(fileOrFolder) && supportedExtensions.Contains(Path.GetExtension(fileOrFolder).ToLower()))
                {
                    mediaFiles.Add(fileOrFolder);

                }
                else
                {
                    // It must be a directory then...
                    if (!Directory.Exists(fileOrFolder)) continue;
                    mediaFiles.AddRange(AddSupportedFilesFromDir(fileOrFolder));
                }
            }
            return mediaFiles;
        }

        private void selectDestinationForOutputFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDestinationForm selectDestForm = new SelectDestinationForm();
            selectDestForm.Show();
            
        }

        private void radioEncodeAAC_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAAC.Enabled = radioEncodeAAC.Checked;
        }

        private void radioCopyAudio_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAAC.Enabled = radioEncodeAAC.Checked;

        }

        private void radioDisableAudio_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAAC.Enabled = radioEncodeAAC.Checked;

        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            string logPath =  Path.Combine(Directory.GetCurrentDirectory(), "Logs", "AppLog.log");
            if (!System.IO.File.Exists(logPath))
            {
                logger.Error("Could not find log file: " + logPath);
                return;
            }
            Process.Start(logPath);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "AppLog.log");
            if (System.IO.File.Exists(logPath)) System.IO.File.WriteAllText(logPath, "");
        }

        private void numericCrf_ValueChanged(object sender, EventArgs e)
        {

        }

        private void setCurrentParamsAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentGuiParamsToDbEntry(defaultParams);
        }

        private VideoCodec GetSelectedCodec()
        {
            if (codecX264MenuItem.Checked) return VideoCodec.X264;
            if (codecAv1MenuItem.Checked)  return VideoCodec.AV1;
            return VideoCodec.X265; // default
        }

        private void SetCheckedCodecMenuItem(VideoCodec codec)
        {
            codecX265MenuItem.Checked = codec == VideoCodec.X265;
            codecX264MenuItem.Checked = codec == VideoCodec.X264;
            codecAv1MenuItem.Checked  = codec == VideoCodec.AV1;
        }

        private void codecX265MenuItem_Click(object sender, EventArgs e)
        {
            codecX264MenuItem.Checked = false;
            codecAv1MenuItem.Checked  = false;
            codecX265MenuItem.Checked = true;
        }

        private void codecX264MenuItem_Click(object sender, EventArgs e)
        {
            codecX265MenuItem.Checked = false;
            codecAv1MenuItem.Checked  = false;
            codecX264MenuItem.Checked = true;
        }

        private void codecAv1MenuItem_Click(object sender, EventArgs e)
        {
            codecX265MenuItem.Checked = false;
            codecX264MenuItem.Checked = false;
            codecAv1MenuItem.Checked  = true;
        }

        private static string GetCodecLabel(VideoCodec codec)
        {
            switch (codec)
            {
                case VideoCodec.X264: return "x264";
                case VideoCodec.AV1:  return "av1";
                default:             return "x265";
            }
        }
    }
}
