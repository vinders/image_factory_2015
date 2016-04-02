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
    public partial class AnalysisForm : Form
    {
        private bool _imageBusy;
        private Bitmap _originalImage;
        private Bitmap _backupImage;
        private bool _imageLoaded;
        private bool _imageGrayscale;

        public AnalysisForm()
        {
            InitializeComponent();
            _imageBusy = _imageLoaded = false;
            _originalImage = null;
            _backupImage = null;
            _imageGrayscale = false;
            cboxDir2.Visible = false;
            cboxDistance.SelectedIndex = 0;
            cboxOrder.SelectedIndex = 0;
            cboxDir1.SelectedIndex = 0;
            cboxDir2.SelectedIndex = 2;
            cancelToolStripMenuItem.ForeColor = Color.Gray;

            lblInfoImg.Visible = lblInfoImgVal.Visible = false;
            lblInfoAvg.Visible = lblInfoAvgVal.Visible = false;
            lblInfoMax.Visible = lblInfoMaxVal.Visible = false;
            lblInfoTotal.Visible = lblInfoTotalVal.Visible = false;
        }
        private void cboxOrder_SelectedIndexChanged(object sender, EventArgs e) // changement listes
        {
            if (cboxOrder.SelectedIndex == 0)
                cboxDir2.Visible = false;
            else
                cboxDir2.Visible = true;
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e) // annuler / rétablir
        {
            if (_imageLoaded && _backupImage != null)
            {
                // inverser
                Bitmap tmpImage = _originalImage;
                _originalImage = _backupImage;
                _backupImage = tmpImage;
                pictureImage.Image = _originalImage;
                // mémoriser matrice de bytes
                ImageLibrary.ImageLibrary.setImageBytes(_originalImage);
            }
            if (_backupImage == null)
                cancelToolStripMenuItem.ForeColor = Color.Gray;
            else
                cancelToolStripMenuItem.ForeColor = Color.Black;
        }

        // OUVERTURE IMAGE
        private void menuBtnOpen_Click(object sender, EventArgs e)
        {
            try 
            {
                // boîte de dialogue - ouverture
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    _imageBusy = true;
                    _originalImage = new Bitmap(open.FileName);
                    if (_originalImage != null)
                    {
                        // taille max
                        if (_originalImage.Width > ImageLibrary.ImageLibrary.MAX_SIZE
                            || _originalImage.Height > ImageLibrary.ImageLibrary.MAX_SIZE)
                        {
                            _originalImage = new Bitmap(_originalImage,
                                                    new Size(Math.Min(_originalImage.Width, ImageLibrary.ImageLibrary.MAX_SIZE),
                                                             Math.Min(_originalImage.Height, ImageLibrary.ImageLibrary.MAX_SIZE)));
                        }
                        _imageLoaded = (_originalImage != null);
                        _imageGrayscale = false;
                        cancelToolStripMenuItem.ForeColor = Color.Gray;
                        _backupImage = null;

                        // mémoriser matrice de bytes
                        ImageLibrary.ImageLibrary.setImageBytes(_originalImage);
                        // afficher image
                        if (_imageLoaded)
                        {
                            pictureImage.Image = _originalImage;
                        }

                        // afficher histogramme
                        histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
                    }
                }
            }
            catch (Exception imgEx)
            {
                MessageBox.Show(imgEx.ToString(), "Erreur d'ouverture", MessageBoxButtons.OK);
            }
            _imageBusy = false;
        }

        // FILTRES DE BASE
        private void setBitmapOppositeToolStripMenuItem_Click(object sender, EventArgs e) // négatif
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.setOppositeColors();
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void setBitmapGrayscaleToolStripMenuItem_Click(object sender, EventArgs e) // gris
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.extractPlane(Color.Black);
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void planeGToolStripMenuItem_Click(object sender, EventArgs e) // vert
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.extractPlane(Color.Green);
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void planeBToolStripMenuItem_Click(object sender, EventArgs e) // bleu
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.extractPlane(Color.Blue);
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void planeRToolStripMenuItem_Click(object sender, EventArgs e) // rouge
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.extractPlane(Color.Red);
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void autoEqualizeToolStripMenuItem_Click(object sender, EventArgs e) // égalisation
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.autoEqualizeHistogram();
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }
        private void autoNormalizeToolStripMenuItem_Click(object sender, EventArgs e) // normalisation
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // modifier image
            Bitmap tmpImage = ImageLibrary.ImageLibrary.autoNormalizeHistogram();
            // mémoriser matrice de bytes
            ImageLibrary.ImageLibrary.setImageBytes(tmpImage);
            // afficher image
            cancelToolStripMenuItem.ForeColor = Color.Black;
            _backupImage = _originalImage;
            _originalImage = tmpImage;
            pictureImage.Image = _originalImage;
            _imageLoaded = (_originalImage != null);
            _imageGrayscale = true;
            // afficher histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }

        // MATRICE DE CO-OCCURRENCE
        private void btnMatrix_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            if (cboxOrder.SelectedIndex > 0 && cboxDir1.SelectedIndex == cboxDir2.SelectedIndex)
            {
                MessageBox.Show("Vous devez choisir des directions différentes.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;

            // paramétrage
            int[,] directions = new int[1+cboxOrder.SelectedIndex, 2];
            switch (cboxDir1.SelectedIndex)
            {
                case 0: directions[0, 0] = 1; directions[0, 1] = 0; break;
                case 1: directions[0, 0] = -1; directions[0, 1] = 0; break;
                case 2: directions[0, 0] = 0; directions[0, 1] = 1; break;
                case 3: directions[0, 0] = 0; directions[0, 1] = -1; break;
                case 4: directions[0, 0] = 1; directions[0, 1] = 1; break;
                case 5: directions[0, 0] = -1; directions[0, 1] = 1; break;
                case 6: directions[0, 0] = 1; directions[0, 1] = -1; break;
                case 7: directions[0, 0] = -1; directions[0, 1] = -1; break;
            }
            if (cboxOrder.SelectedIndex > 0)
            {
                switch (cboxDir2.SelectedIndex)
                {
                    case 0: directions[1, 0] = 1; directions[1, 1] = 0; break;
                    case 1: directions[1, 0] = -1; directions[1, 1] = 0; break;
                    case 2: directions[1, 0] = 0; directions[1, 1] = 1; break;
                    case 3: directions[1, 0] = 0; directions[1, 1] = -1; break;
                    case 4: directions[1, 0] = 1; directions[1, 1] = 1; break;
                    case 5: directions[1, 0] = -1; directions[1, 1] = 1; break;
                    case 6: directions[1, 0] = 1; directions[1, 1] = -1; break;
                    case 7: directions[1, 0] = -1; directions[1, 1] = -1; break;
                }
            }
            // calcul
            if (ImageLibrary.ImageLibrary.setCooccurrenceMatrix(1+cboxOrder.SelectedIndex, directions, 
                                          1+cboxDistance.SelectedIndex, _imageGrayscale, checkSym.Checked))
            {
                // affichage d'informations
                lblInfoImg.Visible = lblInfoImgVal.Visible = true;
                lblInfoAvg.Visible = lblInfoAvgVal.Visible = true;
                lblInfoMax.Visible = lblInfoMaxVal.Visible = true;
                lblInfoTotal.Visible = lblInfoTotalVal.Visible = true;
                lblInfoImgVal.Text = _originalImage.Width + " x " + _originalImage.Height + " pixels";
                lblInfoTotalVal.Text = ImageLibrary.ImageLibrary.cooccurrenceTotal.ToString();
                lblInfoAvgVal.Text = (Math.Round((double)ImageLibrary.ImageLibrary.cooccurrenceTotal*1000.0 / (256.0 * 256.0))/1000.0).ToString();
                lblInfoMaxVal.Text = ImageLibrary.ImageLibrary.cooccurrenceMax + " (" 
                                    + Math.Round((ImageLibrary.ImageLibrary.cooccurrenceMax 
                                                / (double)ImageLibrary.ImageLibrary.cooccurrenceTotal)*10000.0)/10000.0 + " %)";
                
                // affichage d'histogramme 3D
                sharpGLControl.drawItem(ImageLibrary.ImageLibrary.getNormalizedMatrix());
            }

            _imageBusy = false;
        }

        // VUE EN 2D
        private void btnCMatrix2D_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // boîte de dialogue - vue 2D avec hausse de contraste
            PreviewForm prev2D = new PreviewForm(ImageLibrary.ImageLibrary.getCoocurrenceBitmap());
            prev2D.ShowDialog();
            _imageBusy = false;
        }
        // STATISTIQUES
        private void btnStats_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Aucune image ouverte.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            // boîte de dialogue - statistiques
            ImageLibrary.ImageLibrary.doCooccurrenceStats();
            StatForm stats = new StatForm();
            stats.ShowDialog();
            _imageBusy = false;
        }
    }
}
