namespace ImageFactory
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
            this.lblHistoYMax = new System.Windows.Forms.Label();
            this.lblHistoYMin = new System.Windows.Forms.Label();
            this.lblHistoXMin = new System.Windows.Forms.Label();
            this.lblHistoXMax = new System.Windows.Forms.Label();
            this.lblHistoY = new System.Windows.Forms.Label();
            this.lblHistoX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHistoYMax
            // 
            this.lblHistoYMax.AutoSize = true;
            this.lblHistoYMax.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoYMax.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoYMax.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoYMax.Location = new System.Drawing.Point(4, 4);
            this.lblHistoYMax.MaximumSize = new System.Drawing.Size(44, 60);
            this.lblHistoYMax.MinimumSize = new System.Drawing.Size(44, 16);
            this.lblHistoYMax.Name = "lblHistoYMax";
            this.lblHistoYMax.Size = new System.Drawing.Size(44, 16);
            this.lblHistoYMax.TabIndex = 0;
            this.lblHistoYMax.Text = "1000000";
            this.lblHistoYMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHistoYMin
            // 
            this.lblHistoYMin.AutoSize = true;
            this.lblHistoYMin.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoYMin.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoYMin.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoYMin.Location = new System.Drawing.Point(35, 101);
            this.lblHistoYMin.Name = "lblHistoYMin";
            this.lblHistoYMin.Size = new System.Drawing.Size(13, 16);
            this.lblHistoYMin.TabIndex = 1;
            this.lblHistoYMin.Text = "0";
            this.lblHistoYMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHistoXMin
            // 
            this.lblHistoXMin.AutoSize = true;
            this.lblHistoXMin.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoXMin.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoXMin.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoXMin.Location = new System.Drawing.Point(45, 117);
            this.lblHistoXMin.Name = "lblHistoXMin";
            this.lblHistoXMin.Size = new System.Drawing.Size(13, 16);
            this.lblHistoXMin.TabIndex = 2;
            this.lblHistoXMin.Text = "0";
            // 
            // lblHistoXMax
            // 
            this.lblHistoXMax.AutoSize = true;
            this.lblHistoXMax.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoXMax.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoXMax.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoXMax.Location = new System.Drawing.Point(449, 117);
            this.lblHistoXMax.Name = "lblHistoXMax";
            this.lblHistoXMax.Size = new System.Drawing.Size(23, 16);
            this.lblHistoXMax.TabIndex = 3;
            this.lblHistoXMax.Text = "255";
            // 
            // lblHistoY
            // 
            this.lblHistoY.AutoSize = true;
            this.lblHistoY.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHistoY.Location = new System.Drawing.Point(11, 52);
            this.lblHistoY.Name = "lblHistoY";
            this.lblHistoY.Size = new System.Drawing.Size(36, 15);
            this.lblHistoY.TabIndex = 4;
            this.lblHistoY.Text = "Pixels";
            // 
            // lblHistoX
            // 
            this.lblHistoX.AutoSize = true;
            this.lblHistoX.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHistoX.Location = new System.Drawing.Point(226, 117);
            this.lblHistoX.Name = "lblHistoX";
            this.lblHistoX.Size = new System.Drawing.Size(52, 15);
            this.lblHistoX.TabIndex = 5;
            this.lblHistoX.Text = "Intensité";
            this.lblHistoX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HistogramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblHistoX);
            this.Controls.Add(this.lblHistoY);
            this.Controls.Add(this.lblHistoXMax);
            this.Controls.Add(this.lblHistoXMin);
            this.Controls.Add(this.lblHistoYMin);
            this.Controls.Add(this.lblHistoYMax);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HistogramControl";
            this.Size = new System.Drawing.Size(475, 137);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HistogramControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHistoYMax;
        private System.Windows.Forms.Label lblHistoYMin;
        private System.Windows.Forms.Label lblHistoXMin;
        private System.Windows.Forms.Label lblHistoXMax;
        private System.Windows.Forms.Label lblHistoY;
        private System.Windows.Forms.Label lblHistoX;
    }
}
