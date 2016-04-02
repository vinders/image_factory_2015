namespace ImageFactory
{
    partial class GaussFilterForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMatrix = new System.Windows.Forms.Label();
            this.cboxMatrix = new System.Windows.Forms.ComboBox();
            this.lblStrength = new System.Windows.Forms.Label();
            this.numStrength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(21, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblMatrix
            // 
            this.lblMatrix.AutoSize = true;
            this.lblMatrix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMatrix.Location = new System.Drawing.Point(21, 44);
            this.lblMatrix.Name = "lblMatrix";
            this.lblMatrix.Size = new System.Drawing.Size(84, 13);
            this.lblMatrix.TabIndex = 2;
            this.lblMatrix.Text = "Taille de matrice";
            // 
            // cboxMatrix
            // 
            this.cboxMatrix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMatrix.FormattingEnabled = true;
            this.cboxMatrix.Items.AddRange(new object[] {
            "3 x 3",
            "5 x 5",
            "7 x 7"});
            this.cboxMatrix.Location = new System.Drawing.Point(115, 41);
            this.cboxMatrix.Name = "cboxMatrix";
            this.cboxMatrix.Size = new System.Drawing.Size(90, 21);
            this.cboxMatrix.TabIndex = 3;
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStrength.Location = new System.Drawing.Point(21, 17);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(72, 13);
            this.lblStrength.TabIndex = 4;
            this.lblStrength.Text = "Netteté (1 - 8)";
            // 
            // numStrength
            // 
            this.numStrength.Location = new System.Drawing.Point(115, 15);
            this.numStrength.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrength.Name = "numStrength";
            this.numStrength.Size = new System.Drawing.Size(90, 20);
            this.numStrength.TabIndex = 5;
            this.numStrength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GaussFilterForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(227, 104);
            this.Controls.Add(this.numStrength);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.cboxMatrix);
            this.Controls.Add(this.lblMatrix);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GaussFilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paramètres du filtre";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMatrix;
        private System.Windows.Forms.ComboBox cboxMatrix;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.NumericUpDown numStrength;
    }
}