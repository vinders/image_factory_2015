namespace TextureAnalyst
{
    partial class StatForm
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
            this.lblStatEnergy = new System.Windows.Forms.Label();
            this.lblStatCorrel = new System.Windows.Forms.Label();
            this.lblStatHom = new System.Windows.Forms.Label();
            this.lblStatCtr = new System.Windows.Forms.Label();
            this.lblStatCtrVal = new System.Windows.Forms.Label();
            this.lblStatHomVal = new System.Windows.Forms.Label();
            this.lblStatCorrelVal = new System.Windows.Forms.Label();
            this.lblStatEnergyVal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(164, 114);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblStatEnergy
            // 
            this.lblStatEnergy.AutoSize = true;
            this.lblStatEnergy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatEnergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatEnergy.Location = new System.Drawing.Point(55, 16);
            this.lblStatEnergy.Name = "lblStatEnergy";
            this.lblStatEnergy.Size = new System.Drawing.Size(61, 19);
            this.lblStatEnergy.TabIndex = 1;
            this.lblStatEnergy.Text = "Énergie :";
            this.lblStatEnergy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatCorrel
            // 
            this.lblStatCorrel.AutoSize = true;
            this.lblStatCorrel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatCorrel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatCorrel.Location = new System.Drawing.Point(32, 81);
            this.lblStatCorrel.Name = "lblStatCorrel";
            this.lblStatCorrel.Size = new System.Drawing.Size(84, 19);
            this.lblStatCorrel.TabIndex = 2;
            this.lblStatCorrel.Text = "Corrélation :";
            this.lblStatCorrel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatHom
            // 
            this.lblStatHom.AutoSize = true;
            this.lblStatHom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatHom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatHom.Location = new System.Drawing.Point(17, 59);
            this.lblStatHom.Name = "lblStatHom";
            this.lblStatHom.Size = new System.Drawing.Size(99, 19);
            this.lblStatHom.TabIndex = 3;
            this.lblStatHom.Text = "Homogénéité :";
            this.lblStatHom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatCtr
            // 
            this.lblStatCtr.AutoSize = true;
            this.lblStatCtr.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatCtr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatCtr.Location = new System.Drawing.Point(61, 37);
            this.lblStatCtr.Name = "lblStatCtr";
            this.lblStatCtr.Size = new System.Drawing.Size(55, 19);
            this.lblStatCtr.TabIndex = 4;
            this.lblStatCtr.Text = "Inertie :";
            this.lblStatCtr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatCtrVal
            // 
            this.lblStatCtrVal.AutoSize = true;
            this.lblStatCtrVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatCtrVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatCtrVal.Location = new System.Drawing.Point(122, 37);
            this.lblStatCtrVal.Name = "lblStatCtrVal";
            this.lblStatCtrVal.Size = new System.Drawing.Size(15, 19);
            this.lblStatCtrVal.TabIndex = 9;
            this.lblStatCtrVal.Text = "-";
            // 
            // lblStatHomVal
            // 
            this.lblStatHomVal.AutoSize = true;
            this.lblStatHomVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatHomVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatHomVal.Location = new System.Drawing.Point(122, 59);
            this.lblStatHomVal.Name = "lblStatHomVal";
            this.lblStatHomVal.Size = new System.Drawing.Size(15, 19);
            this.lblStatHomVal.TabIndex = 8;
            this.lblStatHomVal.Text = "-";
            // 
            // lblStatCorrelVal
            // 
            this.lblStatCorrelVal.AutoSize = true;
            this.lblStatCorrelVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatCorrelVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatCorrelVal.Location = new System.Drawing.Point(122, 81);
            this.lblStatCorrelVal.Name = "lblStatCorrelVal";
            this.lblStatCorrelVal.Size = new System.Drawing.Size(15, 19);
            this.lblStatCorrelVal.TabIndex = 7;
            this.lblStatCorrelVal.Text = "-";
            // 
            // lblStatEnergyVal
            // 
            this.lblStatEnergyVal.AutoSize = true;
            this.lblStatEnergyVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatEnergyVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatEnergyVal.Location = new System.Drawing.Point(122, 16);
            this.lblStatEnergyVal.Name = "lblStatEnergyVal";
            this.lblStatEnergyVal.Size = new System.Drawing.Size(15, 19);
            this.lblStatEnergyVal.TabIndex = 6;
            this.lblStatEnergyVal.Text = "-";
            // 
            // StatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(287, 148);
            this.Controls.Add(this.lblStatCtrVal);
            this.Controls.Add(this.lblStatHomVal);
            this.Controls.Add(this.lblStatCorrelVal);
            this.Controls.Add(this.lblStatEnergyVal);
            this.Controls.Add(this.lblStatCtr);
            this.Controls.Add(this.lblStatHom);
            this.Controls.Add(this.lblStatCorrel);
            this.Controls.Add(this.lblStatEnergy);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistiques de la matrice";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblStatEnergy;
        private System.Windows.Forms.Label lblStatCorrel;
        private System.Windows.Forms.Label lblStatHom;
        private System.Windows.Forms.Label lblStatCtr;
        private System.Windows.Forms.Label lblStatCtrVal;
        private System.Windows.Forms.Label lblStatHomVal;
        private System.Windows.Forms.Label lblStatCorrelVal;
        private System.Windows.Forms.Label lblStatEnergyVal;
    }
}