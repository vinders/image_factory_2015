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
    public partial class NormalizeHistoForm : Form
    {
        private Bitmap _imageSource = null;
        public Bitmap imagePreview = null;

        public NormalizeHistoForm(Bitmap imageSource)
        {
            InitializeComponent();
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(false));
            _imageSource = imageSource;
            setImagePreview();
            this.DialogResult = DialogResult.Cancel;
        }

        // générer résultat
        private void setImagePreview()
        {
            int[] limits = new int[2];
            limits[0] = normalizeMinSlider.Value;
            limits[1] = normalizeMaxSlider.Value;
            histogramControl.setLimits(2, limits);
            imagePreview = ImageLibrary.ImageLibrary.normalizeHistogram(cboxEqualize.Checked, normalizeMinSlider.Value, normalizeMaxSlider.Value);
            previewPicture.Image = imagePreview;
        }

        // vérifier si slider min <= slider max
        private void normalizeMinSlider_ValueChanged(object sender, EventArgs e)
        {
            if (normalizeMinSlider.Value > normalizeMaxSlider.Value)
                normalizeMaxSlider.Value = normalizeMinSlider.Value;
        }
        private void normalizeMaxSlider_ValueChanged(object sender, EventArgs e)
        {
            if (normalizeMinSlider.Value > normalizeMaxSlider.Value)
                normalizeMinSlider.Value = normalizeMaxSlider.Value;
        }

        // mettre preview à jour
        private void normalizeMinSlider_MouseUp(object sender, MouseEventArgs e)
        {
            setImagePreview();
        }
        private void normalizeMaxSlider_MouseUp(object sender, MouseEventArgs e)
        {
            setImagePreview();
        }
        private void cboxEqualize_CheckedChanged(object sender, EventArgs e)
        {
            setImagePreview();
        }

        // validation
        private void btnOK_Click(object sender, EventArgs e)
        {
            setImagePreview();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
