namespace MCspot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbLEDs = new System.Windows.Forms.GroupBox();
            this.rbGrid = new System.Windows.Forms.RadioButton();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPGs = new System.Windows.Forms.NumericUpDown();
            this.nudPGc = new System.Windows.Forms.NumericUpDown();
            this.nudPGr = new System.Windows.Forms.NumericUpDown();
            this.rbCircle = new System.Windows.Forms.RadioButton();
            this.panelCirc = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.nudPCr = new System.Windows.Forms.NumericUpDown();
            this.nudPCnl = new System.Windows.Forms.NumericUpDown();
            this.lERROR = new System.Windows.Forms.Label();
            this.lSNR = new System.Windows.Forms.Label();
            this.lProgress = new System.Windows.Forms.Label();
            this.bCpyImg = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lTimeElapsed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.chartSNR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chartLOC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbLEDs.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGr)).BeginInit();
            this.panelCirc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSNR)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLOC)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartError, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.64486F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.35514F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 617);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chartError
            // 
            chartArea1.AxisY.IsLogarithmic = true;
            chartArea1.Name = "ChartArea1";
            this.chartError.ChartAreas.Add(chartArea1);
            this.chartError.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartError.Legends.Add(legend1);
            this.chartError.Location = new System.Drawing.Point(3, 333);
            this.chartError.Name = "chartError";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartError.Series.Add(series1);
            this.chartError.Size = new System.Drawing.Size(387, 281);
            this.chartError.TabIndex = 5;
            this.chartError.Text = "chart2";
            title1.Name = "Title1";
            title1.Text = "Error plot";
            this.chartError.Titles.Add(title1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbLEDs);
            this.panel1.Controls.Add(this.lERROR);
            this.panel1.Controls.Add(this.lSNR);
            this.panel1.Controls.Add(this.lProgress);
            this.panel1.Controls.Add(this.bCpyImg);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lTimeElapsed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbFileName);
            this.panel1.Controls.Add(this.bStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 324);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // gbLEDs
            // 
            this.gbLEDs.Controls.Add(this.rbGrid);
            this.gbLEDs.Controls.Add(this.panelGrid);
            this.gbLEDs.Controls.Add(this.rbCircle);
            this.gbLEDs.Controls.Add(this.panelCirc);
            this.gbLEDs.Location = new System.Drawing.Point(128, 45);
            this.gbLEDs.Name = "gbLEDs";
            this.gbLEDs.Size = new System.Drawing.Size(256, 129);
            this.gbLEDs.TabIndex = 13;
            this.gbLEDs.TabStop = false;
            this.gbLEDs.Text = "LEDs configuration";
            this.gbLEDs.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // rbGrid
            // 
            this.rbGrid.AutoSize = true;
            this.rbGrid.Location = new System.Drawing.Point(131, 20);
            this.rbGrid.Name = "rbGrid";
            this.rbGrid.Size = new System.Drawing.Size(42, 17);
            this.rbGrid.TabIndex = 13;
            this.rbGrid.Text = "grid";
            this.rbGrid.UseVisualStyleBackColor = true;
            this.rbGrid.CheckedChanged += new System.EventHandler(this.rbGrid_CheckedChanged);
            // 
            // panelGrid
            // 
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.label5);
            this.panelGrid.Controls.Add(this.label4);
            this.panelGrid.Controls.Add(this.label3);
            this.panelGrid.Controls.Add(this.nudPGs);
            this.panelGrid.Controls.Add(this.nudPGc);
            this.panelGrid.Controls.Add(this.nudPGr);
            this.panelGrid.Enabled = false;
            this.panelGrid.Location = new System.Drawing.Point(131, 42);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(125, 87);
            this.panelGrid.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "spacing [mm]";
            // 
            // nudPGs
            // 
            this.nudPGs.Location = new System.Drawing.Point(4, 56);
            this.nudPGs.Name = "nudPGs";
            this.nudPGs.Size = new System.Drawing.Size(37, 20);
            this.nudPGs.TabIndex = 2;
            this.nudPGs.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPGc
            // 
            this.nudPGc.Location = new System.Drawing.Point(4, 30);
            this.nudPGc.Name = "nudPGc";
            this.nudPGc.Size = new System.Drawing.Size(37, 20);
            this.nudPGc.TabIndex = 1;
            this.nudPGc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPGr
            // 
            this.nudPGr.Location = new System.Drawing.Point(4, 4);
            this.nudPGr.Name = "nudPGr";
            this.nudPGr.Size = new System.Drawing.Size(37, 20);
            this.nudPGr.TabIndex = 0;
            this.nudPGr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbCircle
            // 
            this.rbCircle.AutoSize = true;
            this.rbCircle.Checked = true;
            this.rbCircle.Location = new System.Drawing.Point(0, 18);
            this.rbCircle.Name = "rbCircle";
            this.rbCircle.Size = new System.Drawing.Size(59, 17);
            this.rbCircle.TabIndex = 12;
            this.rbCircle.TabStop = true;
            this.rbCircle.Text = "circular";
            this.rbCircle.UseVisualStyleBackColor = true;
            this.rbCircle.CheckedChanged += new System.EventHandler(this.rbCircle_CheckedChanged);
            // 
            // panelCirc
            // 
            this.panelCirc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCirc.Controls.Add(this.label2);
            this.panelCirc.Controls.Add(this.label33);
            this.panelCirc.Controls.Add(this.nudPCr);
            this.panelCirc.Controls.Add(this.nudPCnl);
            this.panelCirc.Location = new System.Drawing.Point(0, 42);
            this.panelCirc.Name = "panelCirc";
            this.panelCirc.Size = new System.Drawing.Size(125, 87);
            this.panelCirc.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "R [mm]";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(52, 6);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "n LEDs";
            this.label33.Click += new System.EventHandler(this.plab1_Click);
            // 
            // nudPCr
            // 
            this.nudPCr.Location = new System.Drawing.Point(6, 31);
            this.nudPCr.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudPCr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPCr.Name = "nudPCr";
            this.nudPCr.Size = new System.Drawing.Size(40, 20);
            this.nudPCr.TabIndex = 1;
            this.nudPCr.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPCr.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // nudPCnl
            // 
            this.nudPCnl.Location = new System.Drawing.Point(6, 4);
            this.nudPCnl.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudPCnl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPCnl.Name = "nudPCnl";
            this.nudPCnl.Size = new System.Drawing.Size(40, 20);
            this.nudPCnl.TabIndex = 0;
            this.nudPCnl.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lERROR
            // 
            this.lERROR.AutoSize = true;
            this.lERROR.Location = new System.Drawing.Point(9, 87);
            this.lERROR.Name = "lERROR";
            this.lERROR.Size = new System.Drawing.Size(32, 13);
            this.lERROR.TabIndex = 9;
            this.lERROR.Text = "Error:";
            // 
            // lSNR
            // 
            this.lSNR.AutoSize = true;
            this.lSNR.Location = new System.Drawing.Point(9, 67);
            this.lSNR.Name = "lSNR";
            this.lSNR.Size = new System.Drawing.Size(36, 13);
            this.lSNR.TabIndex = 8;
            this.lSNR.Text = "SNR: ";
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.BackColor = System.Drawing.Color.Transparent;
            this.lProgress.Location = new System.Drawing.Point(9, 109);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(21, 13);
            this.lProgress.TabIndex = 7;
            this.lProgress.Text = "0%";
            // 
            // bCpyImg
            // 
            this.bCpyImg.Location = new System.Drawing.Point(220, 286);
            this.bCpyImg.Name = "bCpyImg";
            this.bCpyImg.Size = new System.Drawing.Size(75, 23);
            this.bCpyImg.TabIndex = 6;
            this.bCpyImg.Text = "Copy img";
            this.bCpyImg.UseVisualStyleBackColor = true;
            this.bCpyImg.Click += new System.EventHandler(this.bCpyImg_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(205, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 5;
            // 
            // lTimeElapsed
            // 
            this.lTimeElapsed.AutoSize = true;
            this.lTimeElapsed.Location = new System.Drawing.Point(9, 45);
            this.lTimeElapsed.Name = "lTimeElapsed";
            this.lTimeElapsed.Size = new System.Drawing.Size(33, 13);
            this.lTimeElapsed.TabIndex = 4;
            this.lTimeElapsed.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File name:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(128, 14);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(125, 20);
            this.tbFileName.TabIndex = 2;
            this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(301, 286);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // chartSNR
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSNR.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartSNR.Legends.Add(legend2);
            this.chartSNR.Location = new System.Drawing.Point(3, 3);
            this.chartSNR.Name = "chartSNR";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSNR.Series.Add(series2);
            this.chartSNR.Size = new System.Drawing.Size(139, 114);
            this.chartSNR.TabIndex = 4;
            this.chartSNR.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "SNR plot";
            this.chartSNR.Titles.Add(title2);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(396, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 324);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(116, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 167);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.4677F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5323F));
            this.tableLayoutPanel2.Controls.Add(this.chartSNR, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartLOC, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(396, 333);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.0605F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.9395F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(387, 281);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // chartLOC
            // 
            chartArea3.AxisX.Maximum = 1D;
            chartArea3.AxisX.Minimum = -1D;
            chartArea3.AxisY.Maximum = 1D;
            chartArea3.AxisY.Minimum = -1D;
            chartArea3.Name = "ChartArea1";
            this.chartLOC.ChartAreas.Add(chartArea3);
            this.chartLOC.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartLOC.Legends.Add(legend3);
            this.chartLOC.Location = new System.Drawing.Point(148, 123);
            this.chartLOC.Name = "chartLOC";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartLOC.Series.Add(series3);
            this.chartLOC.Size = new System.Drawing.Size(236, 155);
            this.chartLOC.TabIndex = 5;
            this.chartLOC.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Monte Carlo pinhole simulator";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbLEDs.ResumeLayout(false);
            this.gbLEDs.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGr)).EndInit();
            this.panelCirc.ResumeLayout(false);
            this.panelCirc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSNR)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label lTimeElapsed;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bCpyImg;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.Label lSNR;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSNR;
        private System.Windows.Forms.Label lERROR;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelCirc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gbLEDs;
        private System.Windows.Forms.RadioButton rbGrid;
        private System.Windows.Forms.RadioButton rbCircle;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown nudPCr;
        private System.Windows.Forms.NumericUpDown nudPCnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPGc;
        private System.Windows.Forms.NumericUpDown nudPGr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPGs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLOC;
    }
}

