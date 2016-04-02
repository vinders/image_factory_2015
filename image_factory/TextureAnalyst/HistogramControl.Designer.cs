namespace TextureAnalyst
{
    partial class HistogramControl
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
            this.lblHistoXMax = new System.Windows.Forms.Label();
            this.lblTitleY = new System.Windows.Forms.Label();
            this.lblHistoYMax = new System.Windows.Forms.Label();
            this.lblTitleX = new System.Windows.Forms.Label();
            this.lblMinY = new System.Windows.Forms.Label();
            this.lblMinX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHistoXMax
            // 
            this.lblHistoXMax.AutoSize = true;
            this.lblHistoXMax.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoXMax.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.lblHistoXMax.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoXMax.Location = new System.Drawing.Point(449, 117);
            this.lblHistoXMax.Name = "lblHistoXMax";
            this.lblHistoXMax.Size = new System.Drawing.Size(23, 16);
            this.lblHistoXMax.TabIndex = 0;
            this.lblHistoXMax.Text = "255";
            // 
            // lblTitleY
            // 
            this.lblTitleY.AutoSize = true;
            this.lblTitleY.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleY.Location = new System.Drawing.Point(11, 52);
            this.lblTitleY.Name = "lblTitleY";
            this.lblTitleY.Size = new System.Drawing.Size(36, 15);
            this.lblTitleY.TabIndex = 1;
            this.lblTitleY.Text = "Pixels";
            // 
            // lblHistoYMax
            // 
            this.lblHistoYMax.AutoSize = true;
            this.lblHistoYMax.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoYMax.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.lblHistoYMax.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoYMax.Location = new System.Drawing.Point(4, 4);
            this.lblHistoYMax.Name = "lblHistoYMax";
            this.lblHistoYMax.Size = new System.Drawing.Size(43, 16);
            this.lblHistoYMax.TabIndex = 2;
            this.lblHistoYMax.Text = "1000000";
            this.lblHistoYMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTitleX
            // 
            this.lblTitleX.AutoSize = true;
            this.lblTitleX.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitleX.Location = new System.Drawing.Point(226, 117);
            this.lblTitleX.Name = "lblTitleX";
            this.lblTitleX.Size = new System.Drawing.Size(52, 15);
            this.lblTitleX.TabIndex = 3;
            this.lblTitleX.Text = "Intensité";
            // 
            // lblMinY
            // 
            this.lblMinY.AutoSize = true;
            this.lblMinY.BackColor = System.Drawing.Color.Transparent;
            this.lblMinY.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.lblMinY.ForeColor = System.Drawing.Color.Gray;
            this.lblMinY.Location = new System.Drawing.Point(35, 101);
            this.lblMinY.Name = "lblMinY";
            this.lblMinY.Size = new System.Drawing.Size(13, 16);
            this.lblMinY.TabIndex = 4;
            this.lblMinY.Text = "0";
            // 
            // lblMinX
            // 
            this.lblMinX.AutoSize = true;
            this.lblMinX.BackColor = System.Drawing.Color.Transparent;
            this.lblMinX.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.lblMinX.ForeColor = System.Drawing.Color.Gray;
            this.lblMinX.Location = new System.Drawing.Point(45, 117);
            this.lblMinX.Name = "lblMinX";
            this.lblMinX.Size = new System.Drawing.Size(13, 16);
            this.lblMinX.TabIndex = 5;
            this.lblMinX.Text = "0";
            // 
            // HistogramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblMinX);
            this.Controls.Add(this.lblMinY);
            this.Controls.Add(this.lblTitleX);
            this.Controls.Add(this.lblHistoYMax);
            this.Controls.Add(this.lblTitleY);
            this.Controls.Add(this.lblHistoXMax);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HistogramControl";
            this.Size = new System.Drawing.Size(475, 137);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HistogramControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHistoXMax;
        private System.Windows.Forms.Label lblTitleY;
        private System.Windows.Forms.Label lblHistoYMax;
        private System.Windows.Forms.Label lblTitleX;
        private System.Windows.Forms.Label lblMinY;
        private System.Windows.Forms.Label lblMinX;
    }
}
