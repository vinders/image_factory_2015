namespace ImageFactory
{
    partial class PaletteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPaletteChange = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.btnPaletteOrigColor = new System.Windows.Forms.Button();
            this.btnPaletteNewColor = new System.Windows.Forms.Button();
            this.lblPaletteOrig = new System.Windows.Forms.Label();
            this.lblPaletteNew = new System.Windows.Forms.Label();
            this.radioPickerOrig = new System.Windows.Forms.RadioButton();
            this.radioPickerNew = new System.Windows.Forms.RadioButton();
            this.paletteGroup = new System.Windows.Forms.GroupBox();
            this.cboxPalettePlane = new System.Windows.Forms.ComboBox();
            this.btnPalettePlane = new System.Windows.Forms.Button();
            this.lblPaletteAccept = new System.Windows.Forms.Label();
            this.numAccept = new System.Windows.Forms.NumericUpDown();
            this.lblPaletteTitle1 = new System.Windows.Forms.Label();
            this.lblPaletteTitle2 = new System.Windows.Forms.Label();
            this.paletteGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAccept)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaletteChange
            // 
            this.btnPaletteChange.Location = new System.Drawing.Point(24, 127);
            this.btnPaletteChange.Name = "btnPaletteChange";
            this.btnPaletteChange.Size = new System.Drawing.Size(112, 23);
            this.btnPaletteChange.TabIndex = 0;
            this.btnPaletteChange.Text = "Remplacer";
            this.btnPaletteChange.UseVisualStyleBackColor = true;
            this.btnPaletteChange.Click += new System.EventHandler(this.btnPaletteChange_Click);
            // 
            // btnPaletteOrigColor
            // 
            this.btnPaletteOrigColor.BackColor = System.Drawing.Color.Black;
            this.btnPaletteOrigColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaletteOrigColor.Location = new System.Drawing.Point(81, 37);
            this.btnPaletteOrigColor.Name = "btnPaletteOrigColor";
            this.btnPaletteOrigColor.Size = new System.Drawing.Size(55, 22);
            this.btnPaletteOrigColor.TabIndex = 1;
            this.btnPaletteOrigColor.UseVisualStyleBackColor = false;
            this.btnPaletteOrigColor.Click += new System.EventHandler(this.btnPaletteOrigColor_Click);
            // 
            // btnPaletteNewColor
            // 
            this.btnPaletteNewColor.BackColor = System.Drawing.Color.White;
            this.btnPaletteNewColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaletteNewColor.Location = new System.Drawing.Point(81, 65);
            this.btnPaletteNewColor.Name = "btnPaletteNewColor";
            this.btnPaletteNewColor.Size = new System.Drawing.Size(55, 22);
            this.btnPaletteNewColor.TabIndex = 2;
            this.btnPaletteNewColor.UseVisualStyleBackColor = false;
            this.btnPaletteNewColor.Click += new System.EventHandler(this.btnPaletteNewColor_Click);
            // 
            // lblPaletteOrig
            // 
            this.lblPaletteOrig.AutoSize = true;
            this.lblPaletteOrig.Location = new System.Drawing.Point(27, 42);
            this.lblPaletteOrig.Name = "lblPaletteOrig";
            this.lblPaletteOrig.Size = new System.Drawing.Size(48, 13);
            this.lblPaletteOrig.TabIndex = 4;
            this.lblPaletteOrig.Text = "Originale";
            // 
            // lblPaletteNew
            // 
            this.lblPaletteNew.AutoSize = true;
            this.lblPaletteNew.Location = new System.Drawing.Point(27, 70);
            this.lblPaletteNew.Name = "lblPaletteNew";
            this.lblPaletteNew.Size = new System.Drawing.Size(49, 13);
            this.lblPaletteNew.TabIndex = 5;
            this.lblPaletteNew.Text = "Nouvelle";
            // 
            // radioPickerOrig
            // 
            this.radioPickerOrig.AutoSize = true;
            this.radioPickerOrig.Checked = true;
            this.radioPickerOrig.Location = new System.Drawing.Point(15, 25);
            this.radioPickerOrig.Name = "radioPickerOrig";
            this.radioPickerOrig.Size = new System.Drawing.Size(102, 17);
            this.radioPickerOrig.TabIndex = 8;
            this.radioPickerOrig.TabStop = true;
            this.radioPickerOrig.Text = "couleur originale";
            this.radioPickerOrig.UseVisualStyleBackColor = true;
            // 
            // radioPickerNew
            // 
            this.radioPickerNew.AutoSize = true;
            this.radioPickerNew.Location = new System.Drawing.Point(15, 48);
            this.radioPickerNew.Name = "radioPickerNew";
            this.radioPickerNew.Size = new System.Drawing.Size(103, 17);
            this.radioPickerNew.TabIndex = 9;
            this.radioPickerNew.Text = "nouvelle couleur";
            this.radioPickerNew.UseVisualStyleBackColor = true;
            // 
            // paletteGroup
            // 
            this.paletteGroup.Controls.Add(this.radioPickerOrig);
            this.paletteGroup.Controls.Add(this.radioPickerNew);
            this.paletteGroup.Location = new System.Drawing.Point(24, 168);
            this.paletteGroup.Name = "paletteGroup";
            this.paletteGroup.Size = new System.Drawing.Size(133, 88);
            this.paletteGroup.TabIndex = 10;
            this.paletteGroup.TabStop = false;
            this.paletteGroup.Text = "Pipette";
            // 
            // cboxPalettePlane
            // 
            this.cboxPalettePlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPalettePlane.FormattingEnabled = true;
            this.cboxPalettePlane.Items.AddRange(new object[] {
            "Niveaux de gris",
            "Extraire plan rouge",
            "Extraire plan vert",
            "Extraire plan bleu",
            "Négatif"});
            this.cboxPalettePlane.Location = new System.Drawing.Point(25, 315);
            this.cboxPalettePlane.Name = "cboxPalettePlane";
            this.cboxPalettePlane.Size = new System.Drawing.Size(110, 21);
            this.cboxPalettePlane.TabIndex = 12;
            // 
            // btnPalettePlane
            // 
            this.btnPalettePlane.Location = new System.Drawing.Point(24, 341);
            this.btnPalettePlane.Name = "btnPalettePlane";
            this.btnPalettePlane.Size = new System.Drawing.Size(112, 23);
            this.btnPalettePlane.TabIndex = 13;
            this.btnPalettePlane.Text = "Appliquer";
            this.btnPalettePlane.UseVisualStyleBackColor = true;
            this.btnPalettePlane.Click += new System.EventHandler(this.btnPalettePlane_Click);
            // 
            // lblPaletteAccept
            // 
            this.lblPaletteAccept.AutoSize = true;
            this.lblPaletteAccept.Location = new System.Drawing.Point(27, 98);
            this.lblPaletteAccept.Name = "lblPaletteAccept";
            this.lblPaletteAccept.Size = new System.Drawing.Size(55, 13);
            this.lblPaletteAccept.TabIndex = 14;
            this.lblPaletteAccept.Text = "Tolérance";
            // 
            // numAccept
            // 
            this.numAccept.Location = new System.Drawing.Point(81, 94);
            this.numAccept.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numAccept.Name = "numAccept";
            this.numAccept.Size = new System.Drawing.Size(55, 20);
            this.numAccept.TabIndex = 16;
            // 
            // lblPaletteTitle1
            // 
            this.lblPaletteTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblPaletteTitle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaletteTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPaletteTitle1.Location = new System.Drawing.Point(3, 3);
            this.lblPaletteTitle1.Name = "lblPaletteTitle1";
            this.lblPaletteTitle1.Size = new System.Drawing.Size(176, 21);
            this.lblPaletteTitle1.TabIndex = 21;
            this.lblPaletteTitle1.Text = "REMPLACER COULEUR";
            this.lblPaletteTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaletteTitle2
            // 
            this.lblPaletteTitle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblPaletteTitle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaletteTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblPaletteTitle2.Location = new System.Drawing.Point(3, 280);
            this.lblPaletteTitle2.Name = "lblPaletteTitle2";
            this.lblPaletteTitle2.Size = new System.Drawing.Size(176, 21);
            this.lblPaletteTitle2.TabIndex = 22;
            this.lblPaletteTitle2.Text = "FILTRAGE DE COULEURS";
            this.lblPaletteTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaletteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPaletteTitle2);
            this.Controls.Add(this.lblPaletteTitle1);
            this.Controls.Add(this.numAccept);
            this.Controls.Add(this.lblPaletteAccept);
            this.Controls.Add(this.btnPalettePlane);
            this.Controls.Add(this.cboxPalettePlane);
            this.Controls.Add(this.paletteGroup);
            this.Controls.Add(this.lblPaletteNew);
            this.Controls.Add(this.lblPaletteOrig);
            this.Controls.Add(this.btnPaletteNewColor);
            this.Controls.Add(this.btnPaletteOrigColor);
            this.Controls.Add(this.btnPaletteChange);
            this.Name = "PaletteControl";
            this.Size = new System.Drawing.Size(182, 570);
            this.paletteGroup.ResumeLayout(false);
            this.paletteGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAccept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPaletteChange;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button btnPaletteOrigColor;
        private System.Windows.Forms.Button btnPaletteNewColor;
        private System.Windows.Forms.Label lblPaletteOrig;
        private System.Windows.Forms.Label lblPaletteNew;
        private System.Windows.Forms.RadioButton radioPickerOrig;
        private System.Windows.Forms.RadioButton radioPickerNew;
        private System.Windows.Forms.GroupBox paletteGroup;
        private System.Windows.Forms.ComboBox cboxPalettePlane;
        private System.Windows.Forms.Button btnPalettePlane;
        private System.Windows.Forms.Label lblPaletteAccept;
        private System.Windows.Forms.NumericUpDown numAccept;
        private System.Windows.Forms.Label lblPaletteTitle1;
        private System.Windows.Forms.Label lblPaletteTitle2;
    }
}
