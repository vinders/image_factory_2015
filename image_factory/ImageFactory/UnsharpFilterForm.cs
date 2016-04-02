using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class UnsharpFilterForm : Form
    {
        public int matrixSize = 3;
        public int strength = 4;
        public int mask = 2;

        public UnsharpFilterForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            cboxMatrix.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            strength = (int)numStrength.Value;
            mask = (int)numMask.Value;
            switch (cboxMatrix.SelectedIndex)
            {
                case 0: matrixSize = 3; break;
                case 1: matrixSize = 5; break;
                case 2: matrixSize = 7; break;
                default: matrixSize = 3; break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
