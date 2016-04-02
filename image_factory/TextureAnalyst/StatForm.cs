using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureAnalyst
{
    public partial class StatForm : Form
    {
        public StatForm()
        {
            InitializeComponent();

            lblStatEnergyVal.Text = ImageLibrary.ImageLibrary.statEnergy.ToString();
            lblStatCtrVal.Text = ImageLibrary.ImageLibrary.statInertia.ToString();
            lblStatHomVal.Text = ImageLibrary.ImageLibrary.statHomogeneity.ToString();
            lblStatCorrelVal.Text = ImageLibrary.ImageLibrary.statCorrelation.ToString();
        }
    }
}
