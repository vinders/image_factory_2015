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
    public partial class GenericFilterSettingsForm : Form
    {
        public int matrixSize = 3;

        public GenericFilterSettingsForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            cboxMatrix.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
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
