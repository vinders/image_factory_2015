using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class RegionControl : UserControl
    {
        public RegionControl()
        {
            InitializeComponent();
            cboxRegionFilter.SelectedIndex = 1;
        }

        public void setRegionSize(int sizeX, int sizeY)
        {
            numRegionSizex.Value = sizeX;
            numRegionSizey.Value = sizeY;
        }

        private void btnRegionChange_Click(object sender, EventArgs e)
        {
            ((mainForm)this.Parent.Parent).setBitmapRegion();
        }

        private void btnRegionResize_Click(object sender, EventArgs e)
        {
            ((mainForm)this.Parent.Parent).setBitmapDimensions((int)numRegionSizex.Value, (int)numRegionSizey.Value);
        }

        private void btnRegionScale_Click(object sender, EventArgs e)
        {
            ((mainForm)this.Parent.Parent).scaleBitmap(cboxRegionFilter.SelectedIndex, 
                                                       ((float)numRegionScaleX.Value) / 100.0f, 
                                                       ((float)numRegionScaleY.Value) / 100.0f);
        }
    }
}
