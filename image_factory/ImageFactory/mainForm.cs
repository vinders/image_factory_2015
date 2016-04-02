using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ImageLibrary;

namespace ImageFactory
{
    public partial class mainForm : Form
    {
        // application variables générales
        int _currentTool;
        //application variables images
        bool _imageBusy;
        bool _imageLoaded;
        bool _imageModified;
        Bitmap _originalImage;
        Bitmap _modImage;
        // outils
        const int TOOL_REGION = 1;
        const int TOOL_PALETTE = 2;
        const int DEF_SIZEX = 480;
        const int DEF_SIZEY = 380;


        // constructeur
        public mainForm()
        {
            InitializeComponent();
            // init menu
            toolMenu_hide();
            btnToolRegion.Checked = true;
            _currentTool = TOOL_REGION;
            regionControl.Visible = true;
            // init variables
            _imageBusy = false;
            _imageLoaded = false;
            _imageModified = false;
            _originalImage = null;
            _modImage = null;
            // init combo
            cboxContours.SelectedIndex = 0;
            cboxLinearFilter.SelectedIndex = 0;
        }

        // modifier bitmap de droite
        #region mod_recadrage
        public void setBitmapRegion() // recadrer selon sélection
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // vérifier sélection
            Rectangle selectedRect = pictureOrig_setRectangle();
            if (selectedRect == null || selectedRect.Height < 1)
            {
                MessageBox.Show("Aucune sélection.");
                return;
            }
            // recadrer
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.setCanvasPosition(selectedRect);
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        public void setBitmapDimensions(int sizeX, int sizeY) // modifier taille de zone de travail
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // modifier la taille
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.resizeCanvas(sizeX, sizeY);
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        #endregion
        #region mod_couleurs
        public void setBitmapPaletteColor(Color origColor, Color newColor, int acceptance) // palette - remplacer couleur
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.setPaletteColor(origColor, newColor, acceptance);
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        public void setBitmapColorPlane(Color colorPlane) // mode de couleur / extraction plan
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.extractPlane(colorPlane);
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        public void setBitmapOpposite() // négatif
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.setOppositeColors();
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        #endregion
        #region mod_reechantillonnage
        public void scaleBitmap(int type, float factorX, float factorY) // expansion/extraction
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;
            _imageBusy = true;
            switch(type)
            {
                case 0: _modImage = ImageLibrary.ImageLibrary.scaleNearest(factorX, factorY); break;
                case 1: _modImage = ImageLibrary.ImageLibrary.scaleBilinear(factorX, factorY); break;
            }
            pictureMod.Image = _modImage;
            _imageModified = true;
            _imageBusy = false;
        }
        #endregion

        #region handlers_images
        // event handler - ouvrir une image
        private void btnOpenPicture_Click(object sender, EventArgs e)
        {
            try
            {
                // boîte de dialogue - ouverture
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (open.ShowDialog() == DialogResult.OK) // confirmation
                {
                    // ouvrir image choisie
                    _imageBusy = true;
                    _selected = false;
                    _originalImage = new Bitmap(open.FileName);
                    if (_originalImage != null
                     && (_originalImage.Width > ImageLibrary.ImageLibrary.MAX_SIZE
                        || _originalImage.Height > ImageLibrary.ImageLibrary.MAX_SIZE)) // taille max
                    {
                        _originalImage = new Bitmap(_originalImage, 
                                                   new Size(Math.Min(_originalImage.Width, ImageLibrary.ImageLibrary.MAX_SIZE),
                                                            Math.Min(_originalImage.Height, ImageLibrary.ImageLibrary.MAX_SIZE)));
                    }

                    // mémoriser matrice de bytes (image de gauche)
                    ImageLibrary.ImageLibrary.setImageBytes(_originalImage);

                    // afficher l'image
                    _imageLoaded = (_originalImage != null);
                    if (_imageLoaded)
                    {
                        _modImage = null; // effacer image modifiée
                        _imageModified = false;
                        pictureMod.Width = DEF_SIZEX;
                        pictureMod.Height = DEF_SIZEY;
                        pictureMod.Image = _modImage;
                        pictureOrig.Image = _originalImage; // afficher nouvelle image
                        regionControl.setRegionSize(_originalImage.Width, _originalImage.Height); // taille affichée
                    }

                    // mettre à jour histogramme
                    histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
                }
            }
            catch (Exception imgEx)
            {
                MessageBox.Show(imgEx.ToString(), "Erreur d'ouverture", MessageBoxButtons.OK);
            }
            _imageBusy = false;
        }

        // event handler - inverser les images
        private void btnInvertPictures_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false && _imageModified == false)
                return;
            while (_imageBusy);
            _selected = false;

            // inverser bitmaps
            _imageBusy = true;
            Bitmap swapBuffer = _originalImage;
            _originalImage = _modImage;
            _modImage = swapBuffer;
            // inverser états
            bool swapStatus = _imageLoaded;
            _imageLoaded = _imageModified;
            _imageModified = swapStatus;

            // mémoriser matrice de bytes (image de gauche)
            ImageLibrary.ImageLibrary.setImageBytes(_originalImage);

            // modifier taille affichée
            if (_imageLoaded)
                regionControl.setRegionSize(_originalImage.Width, _originalImage.Height);
            else
                regionControl.setRegionSize(1, 1);

            // afficher bitmaps
            pictureOrig.Image = _originalImage;
            pictureMod.Image = _modImage;
            if (_originalImage == null)
            {
                pictureOrig.Width = DEF_SIZEX;
                pictureOrig.Height = DEF_SIZEY;
            }
            if (_modImage == null)
            {
                pictureMod.Width = DEF_SIZEX;
                pictureMod.Height = DEF_SIZEY;
            }

            // mettre à jour histogramme
            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(true));
            _imageBusy = false;
        }

        // event handler - sauvegarder l'image modifiée
        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            while (_imageBusy);
            if (_imageModified == false)
            {
                MessageBox.Show("La partie droite ne contient pas d'image", "Aucune image", MessageBoxButtons.OK);
                return;
            }

            // sauvegarder fichier
            _imageBusy = true;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (save.ShowDialog() == DialogResult.OK) // confirmation
            {
                _modImage.Save(save.FileName);
            }
            _imageBusy = false;
        }
        #endregion

        #region handlers_histogramme
        // event handlers - normalisation et égalisation
        private void btnNormAuto_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // normaliser sur min/max
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.autoNormalizeHistogram();
            pictureMod.Image = _modImage;
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        private void btnEqAuto_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy);

            // égaliser
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.autoEqualizeHistogram();
            pictureMod.Image = _modImage;
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        private void btnEqManual_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // normaliser manuellement
            _imageBusy = true;
            NormalizeHistoForm normalizer = new NormalizeHistoForm(_originalImage);
            if (normalizer.ShowDialog() == DialogResult.OK)
            {
                _modImage = normalizer.imagePreview;
                pictureMod.Image = _modImage;
            }
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        // event handlers - seuillage
        private void btnThresholdAuto_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // seuillage auto
            _imageBusy = true;
            _modImage = ImageLibrary.ImageLibrary.autoThreshold();
            pictureMod.Image = _modImage;
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        private void btnThresholdManual_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // seuillage manuel
            _imageBusy = true;
            ThresholdHistoForm thresholder = new ThresholdHistoForm(_originalImage);
            if (thresholder.ShowDialog() == DialogResult.OK)
            {
                _modImage = thresholder.imagePreview;
                pictureMod.Image = _modImage;
            }
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        #endregion

        #region outils
        // barre d'outils - masquer tous les menus
        private void toolMenu_hide()
        {
            _selection = false;
            _selected = false;
            regionControl.Visible = false;
            paletteControl.Visible = false;
            pictureOrig.Invalidate(true);
        }

        // event handler - barre d'outils - recadrer région
        private void btnToolRegion_Click(object sender, EventArgs e)
        {
            toolMenu_hide();
            if (((ToolStripButton)sender).Checked)
            {
                btnToolPalette.Checked = false; // décocher autres
                _currentTool = TOOL_REGION;
                regionControl.Visible = true;
            }
            else
                _currentTool = 0;
        }

        // event handler - barre d'outils - modifier couleur palette
        private void btnToolPalette_Click(object sender, EventArgs e)
        {
            toolMenu_hide();
            if (((ToolStripButton)sender).Checked)
            {
                btnToolRegion.Checked = false; // décocher autres
                _currentTool = TOOL_PALETTE;
                paletteControl.Visible = true;
            }
            else
                _currentTool = 0;
        }
        #endregion

        #region selection
        // variables de sélection (recadrage)
        private bool _selection = false;
        private bool _selected = false;
        private long _selectionBaseX = 0;
        private long _selectionBaseY = 0;
        private long _selectionSecondX = 0;
        private long _selectionSecondY = 0;

        // début de clic : début de sélection / choix de couleur
        private void pictureOrig_MouseDown(object sender, MouseEventArgs e)
        {
            if (_imageLoaded == false || _imageBusy)
                return;

            // recadrage
            if (_currentTool == TOOL_REGION)
            {
                // sauver coordonnées de départ
                _selectionBaseX = e.X;
                _selectionBaseY = e.Y;
                _selectionSecondX = e.X;
                _selectionSecondY = e.Y;

                _selection = true;
                _selected = false;
                pictureOrig.Invalidate(true); // paint
            }
            // choix couleur palette
            else if (_currentTool == TOOL_PALETTE)
            {
                Color pickedColor = ((Bitmap)pictureOrig.Image).GetPixel(e.X, e.Y);
                paletteControl.setImageColor(pickedColor);
            }
        }

        // déplacement de sélection
        private void pictureOrig_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selection == false)
                return;

            // sauver coordonnées terminales
            _selectionSecondX = e.X;
            _selectionSecondY = e.Y;
            if (_selectionSecondX < 0)
                _selectionSecondX = 0;
            if (_selectionSecondX > pictureOrig.Width - 1)
                _selectionSecondX = pictureOrig.Width - 1;
            if (_selectionSecondY < 0)
                _selectionSecondY = 0;
            if (_selectionSecondY > pictureOrig.Height - 1)
                _selectionSecondY = pictureOrig.Height - 1;

            pictureOrig.Invalidate(true); // paint
        }

        // fin de sélection (clic up)
        private void pictureOrig_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selection == false)
                return;

            // fin de sélection
            _selection = false;

            if (pictureOrig_setRectangle().Height > 0)
                _selected = true;
            pictureOrig.Invalidate(true); // paint
        }

        // calculer rectangle de sélection
        private Rectangle pictureOrig_setRectangle()
        {
            Rectangle selectionSize = new Rectangle();
            if (_selectionBaseX <= _selectionSecondX)
            {
                selectionSize.X = (int)_selectionBaseX;
                selectionSize.Width = (int)_selectionSecondX - (int)_selectionBaseX;
            }
            else if (_selectionBaseX > _selectionSecondX)
            {
                selectionSize.X = (int)_selectionSecondX;
                selectionSize.Width = (int)_selectionBaseX - (int)_selectionSecondX;
            }
            if (_selectionBaseY < _selectionSecondY)
            {
                selectionSize.Y = (int)_selectionBaseY;
                selectionSize.Height = (int)_selectionSecondY - (int)_selectionBaseY;
            }
            else if (_selectionBaseY > _selectionSecondY)
            {
                selectionSize.Y = (int)_selectionSecondY;
                selectionSize.Height = (int)_selectionBaseY - (int)_selectionSecondY;
            }
            return selectionSize;
        }

        // dessin de sélection
        private void pictureOrig_Paint(object sender, PaintEventArgs e)
        {
            // dessin sélection en cours
            if (_selection)
            {
                Rectangle selectionSize = pictureOrig_setRectangle();
                Pen border = new Pen(Color.Gainsboro, 1);
                e.Graphics.DrawRectangle(border, selectionSize);
            }
            // fin de sélection
            else if (_selected)
            {
                Rectangle selectionSize = pictureOrig_setRectangle();
                Pen border = new Pen(Color.Gray, 1);
                border.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawRectangle(border, selectionSize);
            }
        }
        #endregion

        #region filtres
        // event handlers - filtres
        private void btnLinearFilter_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // filtres stationnaires
            _imageBusy = true;
            switch (cboxLinearFilter.SelectedIndex)
            {
                case 0: 
                    {
                        GenericFilterSettingsForm filterForm = new GenericFilterSettingsForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterMean(filterForm.matrixSize); // moyenneur
                        }
                        break;
                    }
                case 1:
                    {
                        GaussFilterForm gaussform = new GaussFilterForm();
                        if (gaussform.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterGauss(gaussform.matrixSize, 2 * gaussform.strength); // gaussien
                        }
                        break;
                    }
                case 2:
                    {
                        GenericFilterSettingsForm filterForm = new GenericFilterSettingsForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterMedian(filterForm.matrixSize); // médian
                        }
                        break;
                    } 
                case 3:
                    {
                        GenericFilterSettingsForm filterForm = new GenericFilterSettingsForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterLowpass(filterForm.matrixSize); break; // passe-bas
                        }
                        break;
                    } 
                case 4:
                    {
                        GenericFilterSettingsForm filterForm = new GenericFilterSettingsForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterHighpass(filterForm.matrixSize, false); break; // contours passe-haut
                        }
                        break;
                    }
                case 5:
                    {
                        GenericFilterSettingsForm filterForm = new GenericFilterSettingsForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.filterHighpass(filterForm.matrixSize, true); break; // passe-haut
                        }
                        break;
                    } 
                case 6:
                    {
                        UnsharpFilterForm filterForm = new UnsharpFilterForm();
                        if (filterForm.ShowDialog() == DialogResult.OK)
                        {
                            _modImage = ImageLibrary.ImageLibrary.unsharpMasking(filterForm.matrixSize, 2*filterForm.mask, filterForm.strength); break;
                        }
                        break;
                    } 
            }
            pictureMod.Image = _modImage;
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        #endregion
        #region contours
        private void btnContours_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // détection de contours
            _imageBusy = true;
            switch (cboxContours.SelectedIndex)
            {
                case 0: _modImage = ImageLibrary.ImageLibrary.filterSobel(true); break; // Sobel standard
                case 1: _modImage = ImageLibrary.ImageLibrary.filterSobel(false); break; // Sobel sans division
                case 2: _modImage = ImageLibrary.ImageLibrary.filterPrewitt(true); break; // Prewitt standard
                case 3: _modImage = ImageLibrary.ImageLibrary.filterPrewitt(false); break; // Prewitt sans division
                case 4: _modImage = ImageLibrary.ImageLibrary.filterKirsch(false); break; // Kirsch
                case 5: _modImage = ImageLibrary.ImageLibrary.filterKirsch(true); break; // Kirsch négatif
                case 6: _modImage = ImageLibrary.ImageLibrary.filterRoberts(false); break; // Roberts
                case 7: _modImage = ImageLibrary.ImageLibrary.filterRoberts(true); break; // Roberts négatif gris
                case 8: _modImage = ImageLibrary.ImageLibrary.filterLaplace(1, false); break; // Laplace
                case 9: _modImage = ImageLibrary.ImageLibrary.filterLaplace(1, true); break; // soustraction Laplace
                case 10: _modImage = ImageLibrary.ImageLibrary.filterLaplace(2, false); break; // Laplace
                case 11: _modImage = ImageLibrary.ImageLibrary.filterLaplace(2, true); break; // soustraction Laplace
            }
            pictureMod.Image = _modImage;
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        #endregion
        #region morphologie
        private void btnMorph_Click(object sender, EventArgs e)
        {
            if (_imageLoaded == false)
            {
                MessageBox.Show("Il n'y a pas d'image à gauche.");
                return;
            }
            while (_imageBusy) ;

            // filtres de morphologie
            _imageBusy = true;
            MorphFiltersForm morph = new MorphFiltersForm(_originalImage);
            if (morph.ShowDialog() == DialogResult.OK)
            {
                _modImage = morph.imagePreview;
                pictureMod.Image = _modImage;
            }
            _imageModified = (_modImage != null);
            _imageBusy = false;
        }
        #endregion
    }
}
