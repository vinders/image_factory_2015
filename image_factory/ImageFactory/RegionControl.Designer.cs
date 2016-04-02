namespace ImageFactory
{
    partial class RegionControl
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
            this.btnRegionChange = new System.Windows.Forms.Button();
            this.btnRegionResize = new System.Windows.Forms.Button();
            this.lblRegionSizeX = new System.Windows.Forms.Label();
            this.numRegionSizey = new System.Windows.Forms.NumericUpDown();
            this.numRegionSizex = new System.Windows.Forms.NumericUpDown();
            this.lblRegionTitle3 = new System.Windows.Forms.Label();
            this.btnRegionScale = new System.Windows.Forms.Button();
            this.lblRegion1 = new System.Windows.Forms.Label();
            this.numRegionScaleY = new System.Windows.Forms.NumericUpDown();
            this.lblRegionScalePctY = new System.Windows.Forms.Label();
            this.cboxRegionFilter = new System.Windows.Forms.ComboBox();
            this.numRegionScaleX = new System.Windows.Forms.NumericUpDown();
            this.lblRegionScalePctX = new System.Windows.Forms.Label();
            this.lblRegionScaleX = new System.Windows.Forms.Label();
            this.lblRegionScaleY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionSizey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionSizex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionScaleX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegionChange
            // 
            this.btnRegionChange.Location = new System.Drawing.Point(24, 105);
            this.btnRegionChange.Name = "btnRegionChange";
            this.btnRegionChange.Size = new System.Drawing.Size(133, 23);
            this.btnRegionChange.TabIndex = 7;
            this.btnRegionChange.Text = "Recadrer sélection";
            this.btnRegionChange.UseVisualStyleBackColor = true;
            this.btnRegionChange.Click += new System.EventHandler(this.btnRegionChange_Click);
            // 
            // btnRegionResize
            // 
            this.btnRegionResize.Location = new System.Drawing.Point(24, 66);
            this.btnRegionResize.Name = "btnRegionResize";
            this.btnRegionResize.Size = new System.Drawing.Size(112, 23);
            this.btnRegionResize.TabIndex = 11;
            this.btnRegionResize.Text = "Modifier la taille";
            this.btnRegionResize.UseVisualStyleBackColor = true;
            this.btnRegionResize.Click += new System.EventHandler(this.btnRegionResize_Click);
            // 
            // lblRegionSizeX
            // 
            this.lblRegionSizeX.AutoSize = true;
            this.lblRegionSizeX.BackColor = System.Drawing.Color.Transparent;
            this.lblRegionSizeX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionSizeX.Location = new System.Drawing.Point(75, 41);
            this.lblRegionSizeX.Name = "lblRegionSizeX";
            this.lblRegionSizeX.Size = new System.Drawing.Size(12, 13);
            this.lblRegionSizeX.TabIndex = 15;
            this.lblRegionSizeX.Text = "x";
            // 
            // numRegionSizey
            // 
            this.numRegionSizey.Location = new System.Drawing.Point(85, 39);
            this.numRegionSizey.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numRegionSizey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegionSizey.Name = "numRegionSizey";
            this.numRegionSizey.Size = new System.Drawing.Size(50, 20);
            this.numRegionSizey.TabIndex = 16;
            this.numRegionSizey.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRegionSizex
            // 
            this.numRegionSizex.Location = new System.Drawing.Point(25, 39);
            this.numRegionSizex.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numRegionSizex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegionSizex.Name = "numRegionSizex";
            this.numRegionSizex.Size = new System.Drawing.Size(50, 20);
            this.numRegionSizex.TabIndex = 17;
            this.numRegionSizex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRegionTitle3
            // 
            this.lblRegionTitle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblRegionTitle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegionTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionTitle3.Location = new System.Drawing.Point(3, 150);
            this.lblRegionTitle3.Name = "lblRegionTitle3";
            this.lblRegionTitle3.Size = new System.Drawing.Size(176, 21);
            this.lblRegionTitle3.TabIndex = 19;
            this.lblRegionTitle3.Text = "RÉÉCHANTILLONNAGE";
            this.lblRegionTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegionScale
            // 
            this.btnRegionScale.Location = new System.Drawing.Point(24, 271);
            this.btnRegionScale.Name = "btnRegionScale";
            this.btnRegionScale.Size = new System.Drawing.Size(111, 23);
            this.btnRegionScale.TabIndex = 18;
            this.btnRegionScale.Text = "Redimensionner";
            this.btnRegionScale.UseVisualStyleBackColor = true;
            this.btnRegionScale.Click += new System.EventHandler(this.btnRegionScale_Click);
            // 
            // lblRegion1
            // 
            this.lblRegion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.lblRegion1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegion1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegion1.Location = new System.Drawing.Point(3, 3);
            this.lblRegion1.Name = "lblRegion1";
            this.lblRegion1.Size = new System.Drawing.Size(176, 21);
            this.lblRegion1.TabIndex = 20;
            this.lblRegion1.Text = "TAILLE ZONE DE TRAVAIL";
            this.lblRegion1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numRegionScaleY
            // 
            this.numRegionScaleY.DecimalPlaces = 1;
            this.numRegionScaleY.Location = new System.Drawing.Point(81, 215);
            this.numRegionScaleY.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numRegionScaleY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegionScaleY.Name = "numRegionScaleY";
            this.numRegionScaleY.Size = new System.Drawing.Size(53, 20);
            this.numRegionScaleY.TabIndex = 21;
            this.numRegionScaleY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblRegionScalePctY
            // 
            this.lblRegionScalePctY.AutoSize = true;
            this.lblRegionScalePctY.BackColor = System.Drawing.Color.Transparent;
            this.lblRegionScalePctY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionScalePctY.Location = new System.Drawing.Point(137, 219);
            this.lblRegionScalePctY.Name = "lblRegionScalePctY";
            this.lblRegionScalePctY.Size = new System.Drawing.Size(15, 13);
            this.lblRegionScalePctY.TabIndex = 22;
            this.lblRegionScalePctY.Text = "%";
            // 
            // cboxRegionFilter
            // 
            this.cboxRegionFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRegionFilter.FormattingEnabled = true;
            this.cboxRegionFilter.Items.AddRange(new object[] {
            "Au plus proche",
            "Interpolation bilinéaire"});
            this.cboxRegionFilter.Location = new System.Drawing.Point(25, 243);
            this.cboxRegionFilter.Name = "cboxRegionFilter";
            this.cboxRegionFilter.Size = new System.Drawing.Size(131, 21);
            this.cboxRegionFilter.TabIndex = 23;
            // 
            // numRegionScaleX
            // 
            this.numRegionScaleX.DecimalPlaces = 1;
            this.numRegionScaleX.Location = new System.Drawing.Point(81, 186);
            this.numRegionScaleX.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numRegionScaleX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegionScaleX.Name = "numRegionScaleX";
            this.numRegionScaleX.Size = new System.Drawing.Size(53, 20);
            this.numRegionScaleX.TabIndex = 24;
            this.numRegionScaleX.Tag = "";
            this.numRegionScaleX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblRegionScalePctX
            // 
            this.lblRegionScalePctX.AutoSize = true;
            this.lblRegionScalePctX.BackColor = System.Drawing.Color.Transparent;
            this.lblRegionScalePctX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionScalePctX.Location = new System.Drawing.Point(137, 190);
            this.lblRegionScalePctX.Name = "lblRegionScalePctX";
            this.lblRegionScalePctX.Size = new System.Drawing.Size(15, 13);
            this.lblRegionScalePctX.TabIndex = 25;
            this.lblRegionScalePctX.Text = "%";
            // 
            // lblRegionScaleX
            // 
            this.lblRegionScaleX.AutoSize = true;
            this.lblRegionScaleX.BackColor = System.Drawing.Color.Transparent;
            this.lblRegionScaleX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionScaleX.Location = new System.Drawing.Point(22, 188);
            this.lblRegionScaleX.Name = "lblRegionScaleX";
            this.lblRegionScaleX.Size = new System.Drawing.Size(53, 13);
            this.lblRegionScaleX.TabIndex = 26;
            this.lblRegionScaleX.Text = "Facteur X";
            // 
            // lblRegionScaleY
            // 
            this.lblRegionScaleY.AutoSize = true;
            this.lblRegionScaleY.BackColor = System.Drawing.Color.Transparent;
            this.lblRegionScaleY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblRegionScaleY.Location = new System.Drawing.Point(22, 217);
            this.lblRegionScaleY.Name = "lblRegionScaleY";
            this.lblRegionScaleY.Size = new System.Drawing.Size(53, 13);
            this.lblRegionScaleY.TabIndex = 27;
            this.lblRegionScaleY.Text = "Facteur Y";
            // 
            // RegionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRegionScaleY);
            this.Controls.Add(this.lblRegionScaleX);
            this.Controls.Add(this.lblRegionScalePctX);
            this.Controls.Add(this.numRegionScaleX);
            this.Controls.Add(this.cboxRegionFilter);
            this.Controls.Add(this.lblRegionScalePctY);
            this.Controls.Add(this.numRegionScaleY);
            this.Controls.Add(this.lblRegion1);
            this.Controls.Add(this.lblRegionTitle3);
            this.Controls.Add(this.btnRegionScale);
            this.Controls.Add(this.numRegionSizex);
            this.Controls.Add(this.numRegionSizey);
            this.Controls.Add(this.lblRegionSizeX);
            this.Controls.Add(this.btnRegionResize);
            this.Controls.Add(this.btnRegionChange);
            this.Name = "RegionControl";
            this.Size = new System.Drawing.Size(182, 570);
            ((System.ComponentModel.ISupportInitialize)(this.numRegionSizey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionSizex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegionScaleX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegionChange;
        private System.Windows.Forms.Button btnRegionResize;
        private System.Windows.Forms.Label lblRegionSizeX;
        private System.Windows.Forms.NumericUpDown numRegionSizey;
        private System.Windows.Forms.NumericUpDown numRegionSizex;
        private System.Windows.Forms.Label lblRegionTitle3;
        private System.Windows.Forms.Button btnRegionScale;
        private System.Windows.Forms.Label lblRegion1;
        private System.Windows.Forms.NumericUpDown numRegionScaleY;
        private System.Windows.Forms.Label lblRegionScalePctY;
        private System.Windows.Forms.ComboBox cboxRegionFilter;
        private System.Windows.Forms.NumericUpDown numRegionScaleX;
        private System.Windows.Forms.Label lblRegionScalePctX;
        private System.Windows.Forms.Label lblRegionScaleX;
        private System.Windows.Forms.Label lblRegionScaleY;
    }
}
