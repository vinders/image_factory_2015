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
    public partial class MorphFiltersForm : Form
    {
        private Bitmap _imageSource = null;
        private Bitmap _imageThreshold = null;
        public Bitmap imagePreview = null;

        public MorphFiltersForm(Bitmap imageSource)
        {
            InitializeComponent();
            _imageSource = imageSource;
            cboxMorph.SelectedIndex = 0;
            cboxNeighbor.SelectedIndex = 0;
            cboxParam.SelectedIndex = 0;
            setImageThreshold();
            this.DialogResult = DialogResult.Cancel;
        }

        // générer image seuillée
        private void setImageThreshold()
        {
            thresholdLabel.Text = thresholdSlider.Value.ToString();
            int[] threshold = new int[1];
            threshold[0] = thresholdSlider.Value;
            Color[] colors = new Color[2];
            colors[0] = Color.Black;
            colors[1] = Color.White;
            _imageThreshold = ImageLibrary.ImageLibrary.applyThreshold(1, threshold, colors);
            thresholdPicture.Image = _imageThreshold;
        }

        // générer résultat
        private void setImagePreview()
        {
            switch (cboxMorph.SelectedIndex)
            {
                case 0: imagePreview = ImageLibrary.ImageLibrary.morphErosion(_imageThreshold, 
                                                                    cboxNeighbor.SelectedIndex, 
                                                                    1 + cboxParam.SelectedIndex); break; // érosion
                case 1: imagePreview = ImageLibrary.ImageLibrary.morphDilatation(_imageThreshold, 
                                                                    cboxNeighbor.SelectedIndex, 
                                                                    1 + cboxParam.SelectedIndex); break; // dilatation
                case 2: imagePreview = ImageLibrary.ImageLibrary.morphOpen(_imageThreshold, 
                                                                    cboxNeighbor.SelectedIndex, 
                                                                    1 + cboxParam.SelectedIndex); break; // ouverture
                case 3: imagePreview = ImageLibrary.ImageLibrary.morphClose(_imageThreshold, 
                                                                    cboxNeighbor.SelectedIndex, 
                                                                    1 + cboxParam.SelectedIndex); break; // fermeture
            }
            previewPicture.Image = imagePreview;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            setImagePreview();
        }

        //validation
        private void btnOk_Click(object sender, EventArgs e)
        {
            setImagePreview();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void thresholdSlider_MouseUp(object sender, MouseEventArgs e)
        {
            setImageThreshold();
        }
    }
}
