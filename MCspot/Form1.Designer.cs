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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lERROR = new System.Windows.Forms.Label();
            this.lSNR = new System.Windows.Forms.Label();
            this.lProgress = new System.Windows.Forms.Label();
            this.bCpyImg = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lTimeElapsed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chartSNR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbCircle = new System.Windows.Forms.RadioButton();
            this.gbLEDs = new System.Windows.Forms.GroupBox();
            this.rbGrid = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSNR)).BeginInit();
            this.panel4.SuspendLayout();
            this.gbLEDs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartError, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartSNR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.64486F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.35514F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 535);
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
            this.chartError.Location = new System.Drawing.Point(3, 289);
            this.chartError.Name = "chartError";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartError.Series.Add(series1);
            this.chartError.Size = new System.Drawing.Size(387, 243);
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
            this.panel1.Size = new System.Drawing.Size(387, 280);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.bCpyImg.Location = new System.Drawing.Point(201, 254);
            this.bCpyImg.Name = "bCpyImg";
            this.bCpyImg.Size = new System.Drawing.Size(75, 23);
            this.bCpyImg.TabIndex = 6;
            this.bCpyImg.Text = "Copy img";
            this.bCpyImg.UseVisualStyleBackColor = true;
            this.bCpyImg.Click += new System.EventHandler(this.bCpyImg_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(182, 23);
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
            this.tbFileName.Location = new System.Drawing.Point(90, 11);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(125, 20);
            this.tbFileName.TabIndex = 2;
            this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(221, 9);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(108, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 167);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // chartSNR
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSNR.ChartAreas.Add(chartArea2);
            this.chartSNR.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartSNR.Legends.Add(legend2);
            this.chartSNR.Location = new System.Drawing.Point(396, 289);
            this.chartSNR.Name = "chartSNR";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSNR.Series.Add(series2);
            this.chartSNR.Size = new System.Drawing.Size(387, 243);
            this.chartSNR.TabIndex = 4;
            this.chartSNR.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "SNR plot";
            this.chartSNR.Titles.Add(title2);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 87);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(131, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 87);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(396, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 280);
            this.panel4.TabIndex = 6;
            // 
            // rbCircle
            // 
            this.rbCircle.AutoSize = true;
            this.rbCircle.Location = new System.Drawing.Point(0, 18);
            this.rbCircle.Name = "rbCircle";
            this.rbCircle.Size = new System.Drawing.Size(59, 17);
            this.rbCircle.TabIndex = 12;
            this.rbCircle.TabStop = true;
            this.rbCircle.Text = "circular";
            this.rbCircle.UseVisualStyleBackColor = true;
            // 
            // gbLEDs
            // 
            this.gbLEDs.Controls.Add(this.rbGrid);
            this.gbLEDs.Controls.Add(this.panel3);
            this.gbLEDs.Controls.Add(this.rbCircle);
            this.gbLEDs.Controls.Add(this.panel2);
            this.gbLEDs.Location = new System.Drawing.Point(90, 45);
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
            this.rbGrid.TabStop = true;
            this.rbGrid.Text = "grid";
            this.rbGrid.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 535);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Monte Carlo pinhole simulator";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSNR)).EndInit();
            this.panel4.ResumeLayout(false);
            this.gbLEDs.ResumeLayout(false);
            this.gbLEDs.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gbLEDs;
        private System.Windows.Forms.RadioButton rbGrid;
        private System.Windows.Forms.RadioButton rbCircle;
    }
}

