namespace TextureAnalyst
{
    partial class AnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBtnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.histogrammeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoNormalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoEqualizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oppositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionDePlanDeCouleurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.lblInfoTotalVal = new System.Windows.Forms.Label();
            this.lblInfoAvgVal = new System.Windows.Forms.Label();
            this.lblInfoTotal = new System.Windows.Forms.Label();
            this.lblInfoAvg = new System.Windows.Forms.Label();
            this.lblInfoMaxVal = new System.Windows.Forms.Label();
            this.lblInfoImgVal = new System.Windows.Forms.Label();
            this.lblInfoImg = new System.Windows.Forms.Label();
            this.lblInfoMax = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.btnStats = new System.Windows.Forms.Button();
            this.checkSym = new System.Windows.Forms.CheckBox();
            this.btnCMatrix2D = new System.Windows.Forms.Button();
            this.cboxDistance = new System.Windows.Forms.ComboBox();
            this.cboxDir2 = new System.Windows.Forms.ComboBox();
            this.cboxOrder = new System.Windows.Forms.ComboBox();
            this.cboxDir1 = new System.Windows.Forms.ComboBox();
            this.btnCMatrix = new System.Windows.Forms.Button();
            this.lblHisto = new System.Windows.Forms.Label();
            this.histogramControl = new TextureAnalyst.HistogramControl();
            this.sharpGLControl = new TextureAnalyst.SharpGLControl();
            this.menuStrip1.SuspendLayout();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.matrixPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBtnOpen,
            this.histogrammeToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBtnOpen
            // 
            this.menuBtnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuBtnOpen.Name = "menuBtnOpen";
            this.menuBtnOpen.Size = new System.Drawing.Size(120, 20);
            this.menuBtnOpen.Text = "Ouvrir une image...";
            this.menuBtnOpen.Click += new System.EventHandler(this.menuBtnOpen_Click);
            // 
            // histogrammeToolStripMenuItem
            // 
            this.histogrammeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.histogrammeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoNormalizeToolStripMenuItem,
            this.autoEqualizeToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.oppositeToolStripMenuItem,
            this.extractionDePlanDeCouleurToolStripMenuItem});
            this.histogrammeToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.histogrammeToolStripMenuItem.Name = "histogrammeToolStripMenuItem";
            this.histogrammeToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.histogrammeToolStripMenuItem.Text = "Histogramme...";
            // 
            // autoNormalizeToolStripMenuItem
            // 
            this.autoNormalizeToolStripMenuItem.Name = "autoNormalizeToolStripMenuItem";
            this.autoNormalizeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.autoNormalizeToolStripMenuItem.Text = "Normalisation automatique";
            this.autoNormalizeToolStripMenuItem.Click += new System.EventHandler(this.autoNormalizeToolStripMenuItem_Click);
            // 
            // autoEqualizeToolStripMenuItem
            // 
            this.autoEqualizeToolStripMenuItem.Name = "autoEqualizeToolStripMenuItem";
            this.autoEqualizeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.autoEqualizeToolStripMenuItem.Text = "Égalisation automatique";
            this.autoEqualizeToolStripMenuItem.Click += new System.EventHandler(this.autoEqualizeToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.grayscaleToolStripMenuItem.Text = "Image en niveaux de gris";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.setBitmapGrayscaleToolStripMenuItem_Click);
            // 
            // oppositeToolStripMenuItem
            // 
            this.oppositeToolStripMenuItem.Name = "oppositeToolStripMenuItem";
            this.oppositeToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.oppositeToolStripMenuItem.Text = "Image en négatif";
            this.oppositeToolStripMenuItem.Click += new System.EventHandler(this.setBitmapOppositeToolStripMenuItem_Click);
            // 
            // extractionDePlanDeCouleurToolStripMenuItem
            // 
            this.extractionDePlanDeCouleurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planeRToolStripMenuItem,
            this.planeGToolStripMenuItem,
            this.planeBToolStripMenuItem});
            this.extractionDePlanDeCouleurToolStripMenuItem.Name = "extractionDePlanDeCouleurToolStripMenuItem";
            this.extractionDePlanDeCouleurToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.extractionDePlanDeCouleurToolStripMenuItem.Text = "Extraction de plan de couleur";
            // 
            // planeRToolStripMenuItem
            // 
            this.planeRToolStripMenuItem.Name = "planeRToolStripMenuItem";
            this.planeRToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.planeRToolStripMenuItem.Text = "plan rouge";
            this.planeRToolStripMenuItem.Click += new System.EventHandler(this.planeRToolStripMenuItem_Click);
            // 
            // planeGToolStripMenuItem
            // 
            this.planeGToolStripMenuItem.Name = "planeGToolStripMenuItem";
            this.planeGToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.planeGToolStripMenuItem.Text = "plan vert";
            this.planeGToolStripMenuItem.Click += new System.EventHandler(this.planeGToolStripMenuItem_Click);
            // 
            // planeBToolStripMenuItem
            // 
            this.planeBToolStripMenuItem.Name = "planeBToolStripMenuItem";
            this.planeBToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.planeBToolStripMenuItem.Text = "plan bleu";
            this.planeBToolStripMenuItem.Click += new System.EventHandler(this.planeBToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cancelToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.cancelToolStripMenuItem.Text = "Annuler / rétablir";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // picturePanel
            // 
            this.picturePanel.AutoScroll = true;
            this.picturePanel.BackColor = System.Drawing.Color.DarkGray;
            this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePanel.Controls.Add(this.pictureImage);
            this.picturePanel.Location = new System.Drawing.Point(0, 24);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(480, 380);
            this.picturePanel.TabIndex = 1;
            // 
            // pictureImage
            // 
            this.pictureImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureImage.Location = new System.Drawing.Point(0, 0);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(400, 300);
            this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureImage.TabIndex = 0;
            this.pictureImage.TabStop = false;
            // 
            // matrixPanel
            // 
            this.matrixPanel.BackColor = System.Drawing.Color.Black;
            this.matrixPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrixPanel.Controls.Add(this.lblInfoTotalVal);
            this.matrixPanel.Controls.Add(this.lblInfoAvgVal);
            this.matrixPanel.Controls.Add(this.lblInfoTotal);
            this.matrixPanel.Controls.Add(this.lblInfoAvg);
            this.matrixPanel.Controls.Add(this.lblInfoMaxVal);
            this.matrixPanel.Controls.Add(this.lblInfoImgVal);
            this.matrixPanel.Controls.Add(this.lblInfoImg);
            this.matrixPanel.Controls.Add(this.lblInfoMax);
            this.matrixPanel.Controls.Add(this.sharpGLControl);
            this.matrixPanel.Location = new System.Drawing.Point(479, 24);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(480, 480);
            this.matrixPanel.TabIndex = 2;
            // 
            // lblInfoTotalVal
            // 
            this.lblInfoTotalVal.AutoSize = true;
            this.lblInfoTotalVal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoTotalVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoTotalVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoTotalVal.Location = new System.Drawing.Point(81, 419);
            this.lblInfoTotalVal.Name = "lblInfoTotalVal";
            this.lblInfoTotalVal.Size = new System.Drawing.Size(15, 19);
            this.lblInfoTotalVal.TabIndex = 12;
            this.lblInfoTotalVal.Text = "-";
            // 
            // lblInfoAvgVal
            // 
            this.lblInfoAvgVal.AutoSize = true;
            this.lblInfoAvgVal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoAvgVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoAvgVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoAvgVal.Location = new System.Drawing.Point(109, 441);
            this.lblInfoAvgVal.Name = "lblInfoAvgVal";
            this.lblInfoAvgVal.Size = new System.Drawing.Size(15, 19);
            this.lblInfoAvgVal.TabIndex = 11;
            this.lblInfoAvgVal.Text = "-";
            // 
            // lblInfoTotal
            // 
            this.lblInfoTotal.AutoSize = true;
            this.lblInfoTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoTotal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoTotal.Location = new System.Drawing.Point(28, 419);
            this.lblInfoTotal.Name = "lblInfoTotal";
            this.lblInfoTotal.Size = new System.Drawing.Size(46, 19);
            this.lblInfoTotal.TabIndex = 10;
            this.lblInfoTotal.Text = "Total :";
            // 
            // lblInfoAvg
            // 
            this.lblInfoAvg.AutoSize = true;
            this.lblInfoAvg.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoAvg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoAvg.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoAvg.Location = new System.Drawing.Point(28, 441);
            this.lblInfoAvg.Name = "lblInfoAvg";
            this.lblInfoAvg.Size = new System.Drawing.Size(74, 19);
            this.lblInfoAvg.TabIndex = 9;
            this.lblInfoAvg.Text = "Moyenne :";
            // 
            // lblInfoMaxVal
            // 
            this.lblInfoMaxVal.AutoSize = true;
            this.lblInfoMaxVal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoMaxVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoMaxVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoMaxVal.Location = new System.Drawing.Point(306, 441);
            this.lblInfoMaxVal.Name = "lblInfoMaxVal";
            this.lblInfoMaxVal.Size = new System.Drawing.Size(15, 19);
            this.lblInfoMaxVal.TabIndex = 8;
            this.lblInfoMaxVal.Text = "-";
            // 
            // lblInfoImgVal
            // 
            this.lblInfoImgVal.AutoSize = true;
            this.lblInfoImgVal.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoImgVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoImgVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoImgVal.Location = new System.Drawing.Point(132, 12);
            this.lblInfoImgVal.Name = "lblInfoImgVal";
            this.lblInfoImgVal.Size = new System.Drawing.Size(15, 19);
            this.lblInfoImgVal.TabIndex = 7;
            this.lblInfoImgVal.Text = "-";
            // 
            // lblInfoImg
            // 
            this.lblInfoImg.AutoSize = true;
            this.lblInfoImg.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoImg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoImg.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoImg.Location = new System.Drawing.Point(28, 12);
            this.lblInfoImg.Name = "lblInfoImg";
            this.lblInfoImg.Size = new System.Drawing.Size(98, 19);
            this.lblInfoImg.TabIndex = 6;
            this.lblInfoImg.Text = "Image source :";
            // 
            // lblInfoMax
            // 
            this.lblInfoMax.AutoSize = true;
            this.lblInfoMax.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoMax.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblInfoMax.Location = new System.Drawing.Point(222, 441);
            this.lblInfoMax.Name = "lblInfoMax";
            this.lblInfoMax.Size = new System.Drawing.Size(77, 19);
            this.lblInfoMax.TabIndex = 0;
            this.lblInfoMax.Text = "Maximum :";
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Silver;
            this.controlPanel.Controls.Add(this.btnStats);
            this.controlPanel.Controls.Add(this.checkSym);
            this.controlPanel.Controls.Add(this.btnCMatrix2D);
            this.controlPanel.Controls.Add(this.cboxDistance);
            this.controlPanel.Controls.Add(this.cboxDir2);
            this.controlPanel.Controls.Add(this.cboxOrder);
            this.controlPanel.Controls.Add(this.cboxDir1);
            this.controlPanel.Controls.Add(this.btnCMatrix);
            this.controlPanel.Location = new System.Drawing.Point(479, 503);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(480, 67);
            this.controlPanel.TabIndex = 3;
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(405, 35);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(63, 23);
            this.btnStats.TabIndex = 7;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // checkSym
            // 
            this.checkSym.AutoSize = true;
            this.checkSym.Checked = true;
            this.checkSym.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSym.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkSym.Location = new System.Drawing.Point(13, 40);
            this.checkSym.Name = "checkSym";
            this.checkSym.Size = new System.Drawing.Size(114, 17);
            this.checkSym.TabIndex = 6;
            this.checkSym.Text = "Matrice symétrique";
            this.checkSym.UseVisualStyleBackColor = true;
            // 
            // btnCMatrix2D
            // 
            this.btnCMatrix2D.Location = new System.Drawing.Point(405, 11);
            this.btnCMatrix2D.Name = "btnCMatrix2D";
            this.btnCMatrix2D.Size = new System.Drawing.Size(63, 23);
            this.btnCMatrix2D.TabIndex = 5;
            this.btnCMatrix2D.Text = "Vue 2D";
            this.btnCMatrix2D.UseVisualStyleBackColor = true;
            this.btnCMatrix2D.Click += new System.EventHandler(this.btnCMatrix2D_Click);
            // 
            // cboxDistance
            // 
            this.cboxDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDistance.FormattingEnabled = true;
            this.cboxDistance.Items.AddRange(new object[] {
            "Distance 1",
            "Distance 2",
            "Distance 3"});
            this.cboxDistance.Location = new System.Drawing.Point(13, 12);
            this.cboxDistance.Name = "cboxDistance";
            this.cboxDistance.Size = new System.Drawing.Size(75, 21);
            this.cboxDistance.TabIndex = 4;
            // 
            // cboxDir2
            // 
            this.cboxDir2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDir2.FormattingEnabled = true;
            this.cboxDir2.Items.AddRange(new object[] {
            "Direction 2 : +x",
            "Direction 2 : -x",
            "Direction 2 : +y",
            "Direction 2 : -y",
            "Direction 2 : +x, +y",
            "Direction 2 : -x, +y",
            "Direction 2 : +x, -y",
            "Direction 2 : -x, -y"});
            this.cboxDir2.Location = new System.Drawing.Point(165, 36);
            this.cboxDir2.Name = "cboxDir2";
            this.cboxDir2.Size = new System.Drawing.Size(111, 21);
            this.cboxDir2.TabIndex = 3;
            // 
            // cboxOrder
            // 
            this.cboxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxOrder.FormattingEnabled = true;
            this.cboxOrder.Items.AddRange(new object[] {
            "Ordre 1",
            "Ordre 2"});
            this.cboxOrder.Location = new System.Drawing.Point(94, 12);
            this.cboxOrder.Name = "cboxOrder";
            this.cboxOrder.Size = new System.Drawing.Size(65, 21);
            this.cboxOrder.TabIndex = 2;
            this.cboxOrder.SelectedIndexChanged += new System.EventHandler(this.cboxOrder_SelectedIndexChanged);
            // 
            // cboxDir1
            // 
            this.cboxDir1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDir1.FormattingEnabled = true;
            this.cboxDir1.Items.AddRange(new object[] {
            "Direction 1 : +x",
            "Direction 1 : -x",
            "Direction 1 : +y",
            "Direction 1 : -y",
            "Direction 1 : +x, +y",
            "Direction 1 : -x, +y",
            "Direction 1 : +x, -y",
            "Direction 1 : -x, -y"});
            this.cboxDir1.Location = new System.Drawing.Point(165, 12);
            this.cboxDir1.Name = "cboxDir1";
            this.cboxDir1.Size = new System.Drawing.Size(111, 21);
            this.cboxDir1.TabIndex = 1;
            // 
            // btnCMatrix
            // 
            this.btnCMatrix.Location = new System.Drawing.Point(282, 11);
            this.btnCMatrix.Name = "btnCMatrix";
            this.btnCMatrix.Size = new System.Drawing.Size(118, 47);
            this.btnCMatrix.TabIndex = 0;
            this.btnCMatrix.Text = "Calculer matrice de co-occurence";
            this.btnCMatrix.UseVisualStyleBackColor = true;
            this.btnCMatrix.Click += new System.EventHandler(this.btnMatrix_Click);
            // 
            // lblHisto
            // 
            this.lblHisto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblHisto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHisto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblHisto.Location = new System.Drawing.Point(2, 408);
            this.lblHisto.Name = "lblHisto";
            this.lblHisto.Size = new System.Drawing.Size(475, 21);
            this.lblHisto.TabIndex = 5;
            this.lblHisto.Text = "HISTOGRAMME (NIVEAUX DE GRIS)";
            this.lblHisto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // histogramControl
            // 
            this.histogramControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.histogramControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramControl.Location = new System.Drawing.Point(2, 433);
            this.histogramControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.histogramControl.Name = "histogramControl";
            this.histogramControl.Size = new System.Drawing.Size(475, 137);
            this.histogramControl.TabIndex = 4;
            // 
            // sharpGLControl
            // 
            this.sharpGLControl.BackColor = System.Drawing.Color.Black;
            this.sharpGLControl.Location = new System.Drawing.Point(0, 16);
            this.sharpGLControl.Name = "sharpGLControl";
            this.sharpGLControl.Size = new System.Drawing.Size(480, 440);
            this.sharpGLControl.TabIndex = 13;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 574);
            this.Controls.Add(this.lblHisto);
            this.Controls.Add(this.histogramControl);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.matrixPanel);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AnalysisForm";
            this.Text = "Analyseur de textures";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.matrixPanel.ResumeLayout(false);
            this.matrixPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBtnOpen;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.Panel matrixPanel;
        private System.Windows.Forms.Panel controlPanel;
        private HistogramControl histogramControl;
        private System.Windows.Forms.Label lblHisto;
        private System.Windows.Forms.ToolStripMenuItem histogrammeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoNormalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoEqualizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oppositeToolStripMenuItem;
        private System.Windows.Forms.Button btnCMatrix;
        private System.Windows.Forms.ToolStripMenuItem extractionDePlanDeCouleurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeBToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboxDir1;
        private System.Windows.Forms.ComboBox cboxOrder;
        private System.Windows.Forms.ComboBox cboxDir2;
        private System.Windows.Forms.ComboBox cboxDistance;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Label lblInfoMax;
        private System.Windows.Forms.Label lblInfoMaxVal;
        private System.Windows.Forms.Label lblInfoImgVal;
        private System.Windows.Forms.Label lblInfoImg;
        private System.Windows.Forms.Label lblInfoTotalVal;
        private System.Windows.Forms.Label lblInfoAvgVal;
        private System.Windows.Forms.Label lblInfoTotal;
        private System.Windows.Forms.Label lblInfoAvg;
        private System.Windows.Forms.Button btnCMatrix2D;
        private System.Windows.Forms.CheckBox checkSym;
        private System.Windows.Forms.Button btnStats;
        private SharpGLControl sharpGLControl;
    }
}

