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
    public partial class GaussFilterForm : Form
    {
        public int matrixSize = 3;
        public int strength = 1;

        public GaussFilterForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            cboxMatrix.SelectedIndex = 0;
        }

        //validation
        private void btnOk_Click(object sender, EventArgs e)
        {
            strength = (int)numStrength.Value;
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
