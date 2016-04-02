namespace ImageFactory
{
    partial class NormalizeHistoForm
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
            this.histogramControl = new ImageFactory.HistogramControl();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.previewPicture = new System.Windows.Forms.PictureBox();
            this.normalizeMinSlider = new System.Windows.Forms.TrackBar();
            this.normalizeMaxSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxEqualize = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalizeMinSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalizeMaxSlider)).BeginInit();
            this.SuspendLayout();
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
            // previewPanel
            // 
            this.previewPanel.AutoScroll = true;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Controls.Add(this.previewPicture);
            this.previewPanel.Location = new System.Drawing.Point(6, 6);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(380, 320);
            this.previewPanel.TabIndex = 1;
            // 
            // previewPicture
            // 
            this.previewPicture.Location = new System.Drawing.Point(0, 0);
            this.previewPicture.Name = "previewPicture";
            this.previewPicture.Size = new System.Drawing.Size(380, 320);
            this.previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.previewPicture.TabIndex = 0;
            this.previewPicture.TabStop = false;
            // 
            // normalizeMinSlider
            // 
            this.normalizeMinSlider.Location = new System.Drawing.Point(427, 164);
            this.normalizeMinSlider.Maximum = 255;
            this.normalizeMinSlider.Name = "normalizeMinSlider";
            this.normalizeMinSlider.Size = new System.Drawing.Size(446, 45);
            this.normalizeMinSlider.TabIndex = 2;
            this.normalizeMinSlider.TickFrequency = 5;
            this.normalizeMinSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.normalizeMinSlider.ValueChanged += new System.EventHandler(this.normalizeMinSlider_ValueChanged);
            this.normalizeMinSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.normalizeMinSlider_MouseUp);
            // 
            // normalizeMaxSlider
            // 
            this.normalizeMaxSlider.Location = new System.Drawing.Point(427, 212);
            this.normalizeMaxSlider.Maximum = 255;
            this.normalizeMaxSlider.Name = "normalizeMaxSlider";
            this.normalizeMaxSlider.Size = new System.Drawing.Size(446, 45);
            this.normalizeMaxSlider.TabIndex = 3;
            this.normalizeMaxSlider.TickFrequency = 5;
            this.normalizeMaxSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.normalizeMaxSlider.Value = 255;
            this.normalizeMaxSlider.ValueChanged += new System.EventHandler(this.normalizeMaxSlider_ValueChanged);
            this.normalizeMaxSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.normalizeMaxSlider_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(401, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(401, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max.";
            // 
            // cboxEqualize
            // 
            this.cboxEqualize.AutoSize = true;
            this.cboxEqualize.Location = new System.Drawing.Point(434, 259);
            this.cboxEqualize.Name = "cboxEqualize";
            this.cboxEqualize.Size = new System.Drawing.Size(270, 17);
            this.cboxEqualize.TabIndex = 6;
            this.cboxEqualize.Text = "Effectuer une égalisation en plus de la normalisation";
            this.cboxEqualize.UseVisualStyleBackColor = true;
            this.cboxEqualize.CheckedChanged += new System.EventHandler(this.cboxEqualize_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(434, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 24);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(537, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NormalizeHistoForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(873, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboxEqualize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.normalizeMaxSlider);
            this.Controls.Add(this.normalizeMinSlider);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.histogramControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NormalizeHistoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Utilitaire de normalisation et égalisation";
            this.TopMost = true;
            this.previewPanel.ResumeLayout(false);
            this.previewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalizeMinSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalizeMaxSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HistogramControl histogramControl;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.TrackBar normalizeMinSlider;
        private System.Windows.Forms.TrackBar normalizeMaxSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cboxEqualize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}