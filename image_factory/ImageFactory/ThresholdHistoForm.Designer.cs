namespace ImageFactory
{
    partial class ThresholdHistoForm
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
            this.previewPanel = new System.Windows.Forms.Panel();
            this.previewPicture = new System.Windows.Forms.PictureBox();
            this.comboNumber = new System.Windows.Forms.ComboBox();
            this.thrSlider1 = new System.Windows.Forms.TrackBar();
            this.thrSlider2 = new System.Windows.Forms.TrackBar();
            this.thrSlider3 = new System.Windows.Forms.TrackBar();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.btnColor3 = new System.Windows.Forms.Button();
            this.btnColorBack = new System.Windows.Forms.Button();
            this.lblColorBack = new System.Windows.Forms.Label();
            this.histogramControl = new ImageFactory.HistogramControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider3)).BeginInit();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.AutoScroll = true;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Controls.Add(this.previewPicture);
            this.previewPanel.Location = new System.Drawing.Point(6, 6);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(380, 380);
            this.previewPanel.TabIndex = 1;
            // 
            // previewPicture
            // 
            this.previewPicture.Location = new System.Drawing.Point(0, 0);
            this.previewPicture.Name = "previewPicture";
            this.previewPicture.Size = new System.Drawing.Size(380, 380);
            this.previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPicture.TabIndex = 0;
            this.previewPicture.TabStop = false;
            // 
            // comboNumber
            // 
            this.comboNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNumber.FormattingEnabled = true;
            this.comboNumber.Items.AddRange(new object[] {
            "Seuillage simple",
            "Seuillage double",
            "Seuillage triple"});
            this.comboNumber.Location = new System.Drawing.Point(623, 303);
            this.comboNumber.Name = "comboNumber";
            this.comboNumber.Size = new System.Drawing.Size(129, 21);
            this.comboNumber.TabIndex = 2;
            this.comboNumber.SelectedIndexChanged += new System.EventHandler(this.comboNumber_SelectedIndexChanged);
            // 
            // thrSlider1
            // 
            this.thrSlider1.Location = new System.Drawing.Point(427, 164);
            this.thrSlider1.Maximum = 255;
            this.thrSlider1.Name = "thrSlider1";
            this.thrSlider1.Size = new System.Drawing.Size(447, 45);
            this.thrSlider1.TabIndex = 5;
            this.thrSlider1.TickFrequency = 5;
            this.thrSlider1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thrSlider1.Value = 210;
            this.thrSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.thrSlider1_MouseUp);
            // 
            // thrSlider2
            // 
            this.thrSlider2.Location = new System.Drawing.Point(427, 211);
            this.thrSlider2.Maximum = 255;
            this.thrSlider2.Name = "thrSlider2";
            this.thrSlider2.Size = new System.Drawing.Size(447, 45);
            this.thrSlider2.TabIndex = 6;
            this.thrSlider2.TickFrequency = 5;
            this.thrSlider2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thrSlider2.Value = 128;
            this.thrSlider2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.thrSlider2_MouseUp);
            // 
            // thrSlider3
            // 
            this.thrSlider3.Location = new System.Drawing.Point(427, 258);
            this.thrSlider3.Maximum = 255;
            this.thrSlider3.Name = "thrSlider3";
            this.thrSlider3.Size = new System.Drawing.Size(447, 45);
            this.thrSlider3.TabIndex = 7;
            this.thrSlider3.TickFrequency = 5;
            this.thrSlider3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thrSlider3.Value = 45;
            this.thrSlider3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.thrSlider3_MouseUp);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(622, 356);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 24);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(733, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.Color.White;
            this.btnColor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor1.Location = new System.Drawing.Point(401, 164);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(30, 19);
            this.btnColor1.TabIndex = 10;
            this.btnColor1.UseVisualStyleBackColor = false;
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.Silver;
            this.btnColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor2.Location = new System.Drawing.Point(401, 211);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(30, 19);
            this.btnColor2.TabIndex = 11;
            this.btnColor2.UseVisualStyleBackColor = false;
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // btnColor3
            // 
            this.btnColor3.BackColor = System.Drawing.Color.DimGray;
            this.btnColor3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor3.Location = new System.Drawing.Point(401, 258);
            this.btnColor3.Name = "btnColor3";
            this.btnColor3.Size = new System.Drawing.Size(30, 19);
            this.btnColor3.TabIndex = 12;
            this.btnColor3.UseVisualStyleBackColor = false;
            this.btnColor3.Click += new System.EventHandler(this.btnColor3_Click);
            // 
            // btnColorBack
            // 
            this.btnColorBack.BackColor = System.Drawing.Color.Black;
            this.btnColorBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorBack.Location = new System.Drawing.Point(401, 302);
            this.btnColorBack.Name = "btnColorBack";
            this.btnColorBack.Size = new System.Drawing.Size(30, 19);
            this.btnColorBack.TabIndex = 13;
            this.btnColorBack.UseVisualStyleBackColor = false;
            this.btnColorBack.Click += new System.EventHandler(this.btnColorBack_Click);
            // 
            // lblColorBack
            // 
            this.lblColorBack.AutoSize = true;
            this.lblColorBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblColorBack.Location = new System.Drawing.Point(438, 305);
            this.lblColorBack.Name = "lblColorBack";
            this.lblColorBack.Size = new System.Drawing.Size(90, 13);
            this.lblColorBack.TabIndex = 14;
            this.lblColorBack.Text = "Couleur hors seuil";
            // 
            // histogramControl
            // 
            this.histogramControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.histogramControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramControl.Location = new System.Drawing.Point(392, 6);
            this.histogramControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.histogramControl.Name = "histogramControl";
            this.histogramControl.Size = new System.Drawing.Size(475, 137);
            this.histogramControl.TabIndex = 0;
            // 
            // ThresholdHistoForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(873, 393);
            this.Controls.Add(this.lblColorBack);
            this.Controls.Add(this.btnColorBack);
            this.Controls.Add(this.btnColor3);
            this.Controls.Add(this.btnColor2);
            this.Controls.Add(this.btnColor1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.thrSlider3);
            this.Controls.Add(this.thrSlider2);
            this.Controls.Add(this.thrSlider1);
            this.Controls.Add(this.comboNumber);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.histogramControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThresholdHistoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Utilitaire de seuillage";
            this.TopMost = true;
            this.previewPanel.ResumeLayout(false);
            this.previewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thrSlider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HistogramControl histogramControl;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.ComboBox comboNumber;
        private System.Windows.Forms.TrackBar thrSlider1;
        private System.Windows.Forms.TrackBar thrSlider2;
        private System.Windows.Forms.TrackBar thrSlider3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Button btnColor3;
        private System.Windows.Forms.Button btnColorBack;
        private System.Windows.Forms.Label lblColorBack;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}