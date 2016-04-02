namespace ImageFactory
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnInvertPictures = new System.Windows.Forms.Button();
            this.picturesPanel = new System.Windows.Forms.Panel();
            this.cboxContours = new System.Windows.Forms.ComboBox();
            this.btnMorph = new System.Windows.Forms.Button();
            this.btnContours = new System.Windows.Forms.Button();
            this.btnLinearFilter = new System.Windows.Forms.Button();
            this.cboxLinearFilter = new System.Windows.Forms.ComboBox();
            this.lblOtherFilters = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNormAuto = new System.Windows.Forms.Button();
            this.btnEqAuto = new System.Windows.Forms.Button();
            this.btnEqManual = new System.Windows.Forms.Button();
            this.btnThresholdAuto = new System.Windows.Forms.Button();
            this.btnThresholdManual = new System.Windows.Forms.Button();
            this.lblLinearFilters = new System.Windows.Forms.Label();
            this.lblHisto = new System.Windows.Forms.Label();
            this.lblHistoControl = new System.Windows.Forms.Label();
            this.btnSavePicture = new System.Windows.Forms.Button();
            this.btnOpenPicture = new System.Windows.Forms.Button();
            this.picturesContainer = new System.Windows.Forms.Panel();
            this.pictureOrigPanel = new System.Windows.Forms.Panel();
            this.pictureOrig = new System.Windows.Forms.PictureBox();
            this.pictureModPanel = new System.Windows.Forms.Panel();
            this.pictureMod = new System.Windows.Forms.PictureBox();
            this.mainMenu = new System.Windows.Forms.ToolStrip();
            this.btnToolRegion = new System.Windows.Forms.ToolStripButton();
            this.btnToolPalette = new System.Windows.Forms.ToolStripButton();
            this.toolOptions = new System.Windows.Forms.Panel();
            this.histogramControl = new ImageFactory.HistogramControl();
            this.paletteControl = new ImageFactory.PaletteControl();
            this.regionControl = new ImageFactory.RegionControl();
            this.picturesPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.picturesContainer.SuspendLayout();
            this.pictureOrigPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrig)).BeginInit();
            this.pictureModPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMod)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.toolOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvertPictures
            // 
            this.btnInvertPictures.Location = new System.Drawing.Point(443, 1);
            this.btnInvertPictures.Name = "btnInvertPictures";
            this.btnInvertPictures.Size = new System.Drawing.Size(75, 23);
            this.btnInvertPictures.TabIndex = 4;
            this.btnInvertPictures.Text = "< - >";
            this.btnInvertPictures.UseVisualStyleBackColor = true;
            this.btnInvertPictures.Click += new System.EventHandler(this.btnInvertPictures_Click);
            // 
            // picturesPanel
            // 
            this.picturesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesPanel.BackColor = System.Drawing.Color.Silver;
            this.picturesPanel.Controls.Add(this.cboxContours);
            this.picturesPanel.Controls.Add(this.btnMorph);
            this.picturesPanel.Controls.Add(this.btnContours);
            this.picturesPanel.Controls.Add(this.btnLinearFilter);
            this.picturesPanel.Controls.Add(this.cboxLinearFilter);
            this.picturesPanel.Controls.Add(this.lblOtherFilters);
            this.picturesPanel.Controls.Add(this.panel1);
            this.picturesPanel.Controls.Add(this.lblLinearFilters);
            this.picturesPanel.Controls.Add(this.lblHisto);
            this.picturesPanel.Controls.Add(this.lblHistoControl);
            this.picturesPanel.Controls.Add(this.histogramControl);
            this.picturesPanel.Controls.Add(this.btnSavePicture);
            this.picturesPanel.Controls.Add(this.btnOpenPicture);
            this.picturesPanel.Controls.Add(this.btnInvertPictures);
            this.picturesPanel.Controls.Add(this.picturesContainer);
            this.picturesPanel.Location = new System.Drawing.Point(0, 25);
            this.picturesPanel.Name = "picturesPanel";
            this.picturesPanel.Size = new System.Drawing.Size(963, 577);
            this.picturesPanel.TabIndex = 5;
            // 
            // cboxContours
            // 
            this.cboxContours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxContours.FormattingEnabled = true;
            this.cboxContours.Items.AddRange(new object[] {
            "Filtre de Sobel",
            "Sobel sans division",
            "Filtre de Prewitt",
            "Prewitt sans division",
            "Filtre de Kirsch",
            "Kirsch en négatif",
            "Filtre de Roberts",
            "Roberts en gris négatif",
            "Opérateur Laplacien 1",
            "Masque Laplacien 1",
            "Opérateur Laplacien 2",
            "Masque Laplacien 2"});
            this.cboxContours.Location = new System.Drawing.Point(740, 541);
            this.cboxContours.Name = "cboxContours";
            this.cboxContours.Size = new System.Drawing.Size(124, 21);
            this.cboxContours.TabIndex = 33;
            // 
            // btnMorph
            // 
            this.btnMorph.Location = new System.Drawing.Point(739, 472);
            this.btnMorph.Name = "btnMorph";
            this.btnMorph.Size = new System.Drawing.Size(125, 23);
            this.btnMorph.TabIndex = 32;
            this.btnMorph.Text = "Filtres morphologiques";
            this.btnMorph.UseVisualStyleBackColor = true;
            this.btnMorph.Click += new System.EventHandler(this.btnMorph_Click);
            // 
            // btnContours
            // 
            this.btnContours.Location = new System.Drawing.Point(867, 540);
            this.btnContours.Name = "btnContours";
            this.btnContours.Size = new System.Drawing.Size(75, 23);
            this.btnContours.TabIndex = 31;
            this.btnContours.Text = "Appliquer";
            this.btnContours.UseVisualStyleBackColor = true;
            this.btnContours.Click += new System.EventHandler(this.btnContours_Click);
            // 
            // btnLinearFilter
            // 
            this.btnLinearFilter.Location = new System.Drawing.Point(867, 439);
            this.btnLinearFilter.Name = "btnLinearFilter";
            this.btnLinearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnLinearFilter.TabIndex = 30;
            this.btnLinearFilter.Text = "Appliquer";
            this.btnLinearFilter.UseVisualStyleBackColor = true;
            this.btnLinearFilter.Click += new System.EventHandler(this.btnLinearFilter_Click);
            // 
            // cboxLinearFilter
            // 
            this.cboxLinearFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLinearFilter.FormattingEnabled = true;
            this.cboxLinearFilter.Items.AddRange(new object[] {
            "Filtre moyenneur",
            "Filtre gaussien",
            "Filtre médian",
            "Filtre passe-bas",
            "Opérateur passe-haut",
            "Masque passe-haut",
            "Unsharp masking"});
            this.cboxLinearFilter.Location = new System.Drawing.Point(740, 440);
            this.cboxLinearFilter.Name = "cboxLinearFilter";
            this.cboxLinearFilter.Size = new System.Drawing.Size(124, 21);
            this.cboxLinearFilter.TabIndex = 29;
            // 
            // lblOtherFilters
            // 
            this.lblOtherFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblOtherFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOtherFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOtherFilters.Location = new System.Drawing.Point(724, 511);
            this.lblOtherFilters.Name = "lblOtherFilters";
            this.lblOtherFilters.Size = new System.Drawing.Size(233, 21);
            this.lblOtherFilters.TabIndex = 28;
            this.lblOtherFilters.Text = "DÉTECTION DE CONTOURS";
            this.lblOtherFilters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnNormAuto);
            this.panel1.Controls.Add(this.btnEqAuto);
            this.panel1.Controls.Add(this.btnEqManual);
            this.panel1.Controls.Add(this.btnThresholdAuto);
            this.panel1.Controls.Add(this.btnThresholdManual);
            this.panel1.Location = new System.Drawing.Point(486, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 137);
            this.panel1.TabIndex = 27;
            // 
            // btnNormAuto
            // 
            this.btnNormAuto.Location = new System.Drawing.Point(21, 8);
            this.btnNormAuto.Name = "btnNormAuto";
            this.btnNormAuto.Size = new System.Drawing.Size(191, 24);
            this.btnNormAuto.TabIndex = 25;
            this.btnNormAuto.Text = "Normalisation automatique";
            this.btnNormAuto.UseVisualStyleBackColor = true;
            this.btnNormAuto.Click += new System.EventHandler(this.btnNormAuto_Click);
            // 
            // btnEqAuto
            // 
            this.btnEqAuto.Location = new System.Drawing.Point(21, 30);
            this.btnEqAuto.Name = "btnEqAuto";
            this.btnEqAuto.Size = new System.Drawing.Size(191, 24);
            this.btnEqAuto.TabIndex = 12;
            this.btnEqAuto.Text = "Égalisation automatique";
            this.btnEqAuto.UseVisualStyleBackColor = true;
            this.btnEqAuto.Click += new System.EventHandler(this.btnEqAuto_Click);
            // 
            // btnEqManual
            // 
            this.btnEqManual.Location = new System.Drawing.Point(21, 52);
            this.btnEqManual.Name = "btnEqManual";
            this.btnEqManual.Size = new System.Drawing.Size(191, 24);
            this.btnEqManual.TabIndex = 13;
            this.btnEqManual.Text = "Normalisation manuelle";
            this.btnEqManual.UseVisualStyleBackColor = true;
            this.btnEqManual.Click += new System.EventHandler(this.btnEqManual_Click);
            // 
            // btnThresholdAuto
            // 
            this.btnThresholdAuto.Location = new System.Drawing.Point(21, 82);
            this.btnThresholdAuto.Name = "btnThresholdAuto";
            this.btnThresholdAuto.Size = new System.Drawing.Size(191, 24);
            this.btnThresholdAuto.TabIndex = 24;
            this.btnThresholdAuto.Text = "Seuillage automatique";
            this.btnThresholdAuto.UseVisualStyleBackColor = true;
            this.btnThresholdAuto.Click += new System.EventHandler(this.btnThresholdAuto_Click);
            // 
            // btnThresholdManual
            // 
            this.btnThresholdManual.Location = new System.Drawing.Point(21, 104);
            this.btnThresholdManual.Name = "btnThresholdManual";
            this.btnThresholdManual.Size = new System.Drawing.Size(191, 24);
            this.btnThresholdManual.TabIndex = 14;
            this.btnThresholdManual.Text = "Seuillage (simple ou multiple)";
            this.btnThresholdManual.UseVisualStyleBackColor = true;
            this.btnThresholdManual.Click += new System.EventHandler(this.btnThresholdManual_Click);
            // 
            // lblLinearFilters
            // 
            this.lblLinearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblLinearFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLinearFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLinearFilters.Location = new System.Drawing.Point(724, 410);
            this.lblLinearFilters.Name = "lblLinearFilters";
            this.lblLinearFilters.Size = new System.Drawing.Size(233, 21);
            this.lblLinearFilters.TabIndex = 26;
            this.lblLinearFilters.Text = "GALERIE DE FILTRES";
            this.lblLinearFilters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHisto
            // 
            this.lblHisto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblHisto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHisto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblHisto.Location = new System.Drawing.Point(6, 410);
            this.lblHisto.Name = "lblHisto";
            this.lblHisto.Size = new System.Drawing.Size(475, 21);
            this.lblHisto.TabIndex = 23;
            this.lblHisto.Text = "HISTOGRAMME  (NIVEAUX DE GRIS)";
            this.lblHisto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHistoControl
            // 
            this.lblHistoControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblHistoControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHistoControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblHistoControl.Location = new System.Drawing.Point(486, 410);
            this.lblHistoControl.Name = "lblHistoControl";
            this.lblHistoControl.Size = new System.Drawing.Size(233, 21);
            this.lblHistoControl.TabIndex = 22;
            this.lblHistoControl.Text = "AJUSTEMENTS D\'HISTOGRAMME";
            this.lblHistoControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSavePicture
            // 
            this.btnSavePicture.Location = new System.Drawing.Point(831, 1);
            this.btnSavePicture.Name = "btnSavePicture";
            this.btnSavePicture.Size = new System.Drawing.Size(123, 23);
            this.btnSavePicture.TabIndex = 6;
            this.btnSavePicture.Text = "Enregistrer sous...";
            this.btnSavePicture.UseVisualStyleBackColor = true;
            this.btnSavePicture.Click += new System.EventHandler(this.btnSavePicture_Click);
            // 
            // btnOpenPicture
            // 
            this.btnOpenPicture.Location = new System.Drawing.Point(5, 1);
            this.btnOpenPicture.Name = "btnOpenPicture";
            this.btnOpenPicture.Size = new System.Drawing.Size(82, 23);
            this.btnOpenPicture.TabIndex = 2;
            this.btnOpenPicture.Text = "Ouvrir...";
            this.btnOpenPicture.UseVisualStyleBackColor = true;
            this.btnOpenPicture.Click += new System.EventHandler(this.btnOpenPicture_Click);
            // 
            // picturesContainer
            // 
            this.picturesContainer.Controls.Add(this.pictureOrigPanel);
            this.picturesContainer.Controls.Add(this.pictureModPanel);
            this.picturesContainer.Location = new System.Drawing.Point(0, 24);
            this.picturesContainer.Name = "picturesContainer";
            this.picturesContainer.Size = new System.Drawing.Size(963, 382);
            this.picturesContainer.TabIndex = 10;
            // 
            // pictureOrigPanel
            // 
            this.pictureOrigPanel.AutoScroll = true;
            this.pictureOrigPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pictureOrigPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureOrigPanel.Controls.Add(this.pictureOrig);
            this.pictureOrigPanel.Location = new System.Drawing.Point(0, 0);
            this.pictureOrigPanel.MaximumSize = new System.Drawing.Size(482, 382);
            this.pictureOrigPanel.Name = "pictureOrigPanel";
            this.pictureOrigPanel.Size = new System.Drawing.Size(482, 382);
            this.pictureOrigPanel.TabIndex = 9;
            // 
            // pictureOrig
            // 
            this.pictureOrig.BackColor = System.Drawing.Color.Transparent;
            this.pictureOrig.Location = new System.Drawing.Point(0, 0);
            this.pictureOrig.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.pictureOrig.MinimumSize = new System.Drawing.Size(1, 1);
            this.pictureOrig.Name = "pictureOrig";
            this.pictureOrig.Size = new System.Drawing.Size(480, 380);
            this.pictureOrig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureOrig.TabIndex = 7;
            this.pictureOrig.TabStop = false;
            this.pictureOrig.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureOrig_Paint);
            this.pictureOrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureOrig_MouseDown);
            this.pictureOrig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureOrig_MouseMove);
            this.pictureOrig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureOrig_MouseUp);
            // 
            // pictureModPanel
            // 
            this.pictureModPanel.AutoScroll = true;
            this.pictureModPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pictureModPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureModPanel.Controls.Add(this.pictureMod);
            this.pictureModPanel.Location = new System.Drawing.Point(481, 0);
            this.pictureModPanel.MaximumSize = new System.Drawing.Size(482, 382);
            this.pictureModPanel.Name = "pictureModPanel";
            this.pictureModPanel.Size = new System.Drawing.Size(482, 382);
            this.pictureModPanel.TabIndex = 0;
            // 
            // pictureMod
            // 
            this.pictureMod.BackColor = System.Drawing.Color.Transparent;
            this.pictureMod.Location = new System.Drawing.Point(0, 0);
            this.pictureMod.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.pictureMod.MinimumSize = new System.Drawing.Size(2, 2);
            this.pictureMod.Name = "pictureMod";
            this.pictureMod.Size = new System.Drawing.Size(480, 380);
            this.pictureMod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureMod.TabIndex = 8;
            this.pictureMod.TabStop = false;
            // 
            // mainMenu
            // 
            this.mainMenu.AutoSize = false;
            this.mainMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToolRegion,
            this.btnToolPalette});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1147, 25);
            this.mainMenu.TabIndex = 6;
            // 
            // btnToolRegion
            // 
            this.btnToolRegion.Checked = true;
            this.btnToolRegion.CheckOnClick = true;
            this.btnToolRegion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnToolRegion.Image = global::ImageFactory.Properties.Resources.select;
            this.btnToolRegion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolRegion.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.btnToolRegion.Name = "btnToolRegion";
            this.btnToolRegion.Size = new System.Drawing.Size(73, 22);
            this.btnToolRegion.Text = "Recadrer";
            this.btnToolRegion.Click += new System.EventHandler(this.btnToolRegion_Click);
            // 
            // btnToolPalette
            // 
            this.btnToolPalette.CheckOnClick = true;
            this.btnToolPalette.Image = global::ImageFactory.Properties.Resources.palette;
            this.btnToolPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolPalette.Name = "btnToolPalette";
            this.btnToolPalette.Size = new System.Drawing.Size(126, 22);
            this.btnToolPalette.Text = "Remplacer couleur";
            this.btnToolPalette.Click += new System.EventHandler(this.btnToolPalette_Click);
            // 
            // toolOptions
            // 
            this.toolOptions.BackColor = System.Drawing.Color.LightGray;
            this.toolOptions.Controls.Add(this.paletteControl);
            this.toolOptions.Controls.Add(this.regionControl);
            this.toolOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolOptions.Location = new System.Drawing.Point(963, 25);
            this.toolOptions.Name = "toolOptions";
            this.toolOptions.Size = new System.Drawing.Size(184, 577);
            this.toolOptions.TabIndex = 1;
            // 
            // histogramControl
            // 
            this.histogramControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.histogramControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramControl.Location = new System.Drawing.Point(6, 435);
            this.histogramControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.histogramControl.Name = "histogramControl";
            this.histogramControl.Size = new System.Drawing.Size(475, 137);
            this.histogramControl.TabIndex = 11;
            // 
            // paletteControl
            // 
            this.paletteControl.Location = new System.Drawing.Point(1, 1);
            this.paletteControl.Name = "paletteControl";
            this.paletteControl.Size = new System.Drawing.Size(184, 570);
            this.paletteControl.TabIndex = 1;
            // 
            // regionControl
            // 
            this.regionControl.Location = new System.Drawing.Point(1, 1);
            this.regionControl.Name = "regionControl";
            this.regionControl.Size = new System.Drawing.Size(184, 570);
            this.regionControl.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 602);
            this.Controls.Add(this.picturesPanel);
            this.Controls.Add(this.toolOptions);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1163, 640);
            this.Name = "mainForm";
            this.Text = "Image Factory";
            this.picturesPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.picturesContainer.ResumeLayout(false);
            this.pictureOrigPanel.ResumeLayout(false);
            this.pictureOrigPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrig)).EndInit();
            this.pictureModPanel.ResumeLayout(false);
            this.pictureModPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMod)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvertPictures;
        private System.Windows.Forms.Panel picturesPanel;
        private System.Windows.Forms.Button btnOpenPicture;
        private System.Windows.Forms.Button btnSavePicture;
        private System.Windows.Forms.ToolStrip mainMenu;
        private System.Windows.Forms.ToolStripButton btnToolRegion;
        private System.Windows.Forms.ToolStripButton btnToolPalette;
        private System.Windows.Forms.PictureBox pictureMod;
        private System.Windows.Forms.PictureBox pictureOrig;
        private System.Windows.Forms.Panel toolOptions;
        private PaletteControl paletteControl;
        private RegionControl regionControl;
        private System.Windows.Forms.Panel pictureModPanel;
        private System.Windows.Forms.Panel pictureOrigPanel;
        private System.Windows.Forms.Panel picturesContainer;
        private HistogramControl histogramControl;
        private System.Windows.Forms.Button btnThresholdManual;
        private System.Windows.Forms.Button btnEqManual;
        private System.Windows.Forms.Button btnEqAuto;
        private System.Windows.Forms.Label lblHistoControl;
        private System.Windows.Forms.Label lblHisto;
        private System.Windows.Forms.Button btnThresholdAuto;
        private System.Windows.Forms.Button btnNormAuto;
        private System.Windows.Forms.Label lblLinearFilters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOtherFilters;
        private System.Windows.Forms.ComboBox cboxContours;
        private System.Windows.Forms.Button btnMorph;
        private System.Windows.Forms.Button btnContours;
        private System.Windows.Forms.Button btnLinearFilter;
        private System.Windows.Forms.ComboBox cboxLinearFilter;
    }
}

