namespace ImageFactory
{
    partial class MorphFiltersForm
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
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.thresholdSlider = new System.Windows.Forms.TrackBar();
            this.thresholdPanel = new System.Windows.Forms.Panel();
            this.thresholdPicture = new System.Windows.Forms.PictureBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.previewPicture = new System.Windows.Forms.PictureBox();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblMorph = new System.Windows.Forms.Label();
            this.cboxMorph = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboxParam = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboxNeighbor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).BeginInit();
            this.thresholdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdPicture)).BeginInit();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.ForeColor = System.Drawing.Color.Gray;
            this.thresholdLabel.Location = new System.Drawing.Point(327, 388);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(25, 13);
            this.thresholdLabel.TabIndex = 0;
            this.thresholdLabel.Text = "128";
            // 
            // thresholdSlider
            // 
            this.thresholdSlider.Location = new System.Drawing.Point(39, 385);
            this.thresholdSlider.Maximum = 255;
            this.thresholdSlider.Name = "thresholdSlider";
            this.thresholdSlider.Size = new System.Drawing.Size(291, 45);
            this.thresholdSlider.TabIndex = 1;
            this.thresholdSlider.TickFrequency = 32;
            this.thresholdSlider.Value = 128;
            this.thresholdSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.thresholdSlider_MouseUp);
            // 
            // thresholdPanel
            // 
            this.thresholdPanel.AutoScroll = true;
            this.thresholdPanel.BackColor = System.Drawing.Color.DarkGray;
            this.thresholdPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresholdPanel.Controls.Add(this.thresholdPicture);
            this.thresholdPanel.Location = new System.Drawing.Point(2, 2);
            this.thresholdPanel.Name = "thresholdPanel";
            this.thresholdPanel.Size = new System.Drawing.Size(380, 380);
            this.thresholdPanel.TabIndex = 2;
            // 
            // thresholdPicture
            // 
            this.thresholdPicture.BackColor = System.Drawing.Color.Transparent;
            this.thresholdPicture.Location = new System.Drawing.Point(0, 0);
            this.thresholdPicture.Name = "thresholdPicture";
            this.thresholdPicture.Size = new System.Drawing.Size(376, 376);
            this.thresholdPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.thresholdPicture.TabIndex = 3;
            this.thresholdPicture.TabStop = false;
            // 
            // previewPanel
            // 
            this.previewPanel.AutoScroll = true;
            this.previewPanel.BackColor = System.Drawing.Color.DarkGray;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Controls.Add(this.previewPicture);
            this.previewPanel.Location = new System.Drawing.Point(381, 2);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(380, 380);
            this.previewPanel.TabIndex = 0;
            // 
            // previewPicture
            // 
            this.previewPicture.BackColor = System.Drawing.Color.Transparent;
            this.previewPicture.Location = new System.Drawing.Point(0, 0);
            this.previewPicture.Name = "previewPicture";
            this.previewPicture.Size = new System.Drawing.Size(376, 376);
            this.previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPicture.TabIndex = 4;
            this.previewPicture.TabStop = false;
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblThreshold.Location = new System.Drawing.Point(7, 393);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(30, 13);
            this.lblThreshold.TabIndex = 5;
            this.lblThreshold.Text = "Seuil";
            // 
            // lblMorph
            // 
            this.lblMorph.AutoSize = true;
            this.lblMorph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMorph.Location = new System.Drawing.Point(379, 393);
            this.lblMorph.Name = "lblMorph";
            this.lblMorph.Size = new System.Drawing.Size(29, 13);
            this.lblMorph.TabIndex = 6;
            this.lblMorph.Text = "Filtre";
            // 
            // cboxMorph
            // 
            this.cboxMorph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMorph.FormattingEnabled = true;
            this.cboxMorph.Items.AddRange(new object[] {
            "Érosion",
            "Dilatation",
            "Ouverture",
            "Fermeture"});
            this.cboxMorph.Location = new System.Drawing.Point(414, 390);
            this.cboxMorph.Name = "cboxMorph";
            this.cboxMorph.Size = new System.Drawing.Size(123, 21);
            this.cboxMorph.TabIndex = 7;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(414, 428);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(84, 23);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "Aperçu";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(564, 428);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboxParam
            // 
            this.cboxParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxParam.FormattingEnabled = true;
            this.cboxParam.Items.AddRange(new object[] {
            "Simple",
            "Double",
            "Triple"});
            this.cboxParam.Location = new System.Drawing.Point(658, 390);
            this.cboxParam.Name = "cboxParam";
            this.cboxParam.Size = new System.Drawing.Size(90, 21);
            this.cboxParam.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(658, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cboxNeighbor
            // 
            this.cboxNeighbor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxNeighbor.FormattingEnabled = true;
            this.cboxNeighbor.Items.AddRange(new object[] {
            "4-connexe",
            "8-connexe",
            "Alterner (4/8)",
            "Alterner (8/4)",
            "4-connexe oblique"});
            this.cboxNeighbor.Location = new System.Drawing.Point(541, 390);
            this.cboxNeighbor.Name = "cboxNeighbor";
            this.cboxNeighbor.Size = new System.Drawing.Size(113, 21);
            this.cboxNeighbor.TabIndex = 12;
            // 
            // MorphFiltersForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(763, 460);
            this.Controls.Add(this.cboxNeighbor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboxParam);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cboxMorph);
            this.Controls.Add(this.lblMorph);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.thresholdPanel);
            this.Controls.Add(this.thresholdSlider);
            this.Controls.Add(this.thresholdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MorphFiltersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filtres morphologiques";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).EndInit();
            this.thresholdPanel.ResumeLayout(false);
            this.thresholdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdPicture)).EndInit();
            this.previewPanel.ResumeLayout(false);
            this.previewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TrackBar thresholdSlider;
        private System.Windows.Forms.Panel thresholdPanel;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.PictureBox thresholdPicture;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblMorph;
        private System.Windows.Forms.ComboBox cboxMorph;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cboxParam;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboxNeighbor;
    }
}