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
    public partial class ThresholdHistoForm : Form
    {
        private Bitmap _imageSource = null;
        public Bitmap imagePreview = null;

        public ThresholdHistoForm(Bitmap imageSource)
        {
            InitializeComponent();
            thrSlider2.Visible = false;
            thrSlider3.Visible = false;
            btnColor2.Visible = false;
            btnColor3.Visible = false;
            comboNumber.SelectedIndex = 0;

            histogramControl.setHistogram(ImageLibrary.ImageLibrary.getImageHistogram(false));
            _imageSource = imageSource;
            setImagePreview();
            this.DialogResult = DialogResult.Cancel;
        }

        // générer résultat
        private void setImagePreview()
        {
            int[] thresholdsValues = new int[comboNumber.SelectedIndex + 1];
            Color[] newColors = new Color[comboNumber.SelectedIndex + 2];
            switch (comboNumber.SelectedIndex)
            {
                case 2: // triple
                    newColors[3] = btnColor3.BackColor;
                    thresholdsValues[2] = thrSlider3.Value;
                    newColors[2] = btnColor2.BackColor;
                    thresholdsValues[1] = thrSlider2.Value;
                    newColors[1] = btnColor1.BackColor;
                    thresholdsValues[0] = thrSlider1.Value;
                    if (thresholdsValues[2] > thresholdsValues[1])
                    {
                        if (thresholdsValues[1] > thresholdsValues[0]) // 3 > 2 > 1
                        {
                            newColors[3] = btnColor3.BackColor;
                            thresholdsValues[2] = thrSlider3.Value;
                            newColors[2] = btnColor2.BackColor;
                            thresholdsValues[1] = thrSlider2.Value;
                            newColors[1] = btnColor1.BackColor;
                            thresholdsValues[0] = thrSlider1.Value;
                        }
                        else if (thresholdsValues[2] > thresholdsValues[0]) // 3 > 1 > 2
                        {
                            newColors[3] = btnColor3.BackColor;
                            thresholdsValues[2] = thrSlider3.Value;
                            newColors[2] = btnColor1.BackColor;
                            thresholdsValues[1] = thrSlider1.Value;
                            newColors[1] = btnColor2.BackColor;
                            thresholdsValues[0] = thrSlider2.Value;
                        }
                        else // 1 > 3 > 2
                        {
                            newColors[3] = btnColor1.BackColor;
                            thresholdsValues[2] = thrSlider1.Value;
                            newColors[2] = btnColor3.BackColor;
                            thresholdsValues[1] = thrSlider3.Value;
                            newColors[1] = btnColor2.BackColor;
                            thresholdsValues[0] = thrSlider2.Value;
                        }
                    }
                    else
                    {
                        if (thresholdsValues[2] > thresholdsValues[0]) // 2 > 3 > 1
                        {
                            newColors[3] = btnColor2.BackColor;
                            thresholdsValues[2] = thrSlider2.Value;
                            newColors[2] = btnColor3.BackColor;
                            thresholdsValues[1] = thrSlider3.Value;
                            newColors[1] = btnColor1.BackColor;
                            thresholdsValues[0] = thrSlider1.Value;
                        }
                        else if (thresholdsValues[1] > thresholdsValues[0]) // 2 > 1 > 3
                        {
                            newColors[3] = btnColor2.BackColor;
                            thresholdsValues[2] = thrSlider2.Value;
                            newColors[2] = btnColor1.BackColor;
                            thresholdsValues[1] = thrSlider1.Value;
                            newColors[1] = btnColor3.BackColor;
                            thresholdsValues[0] = thrSlider3.Value;
                        }
                        else // 1 > 2 > 3
                        {
                            newColors[3] = btnColor1.BackColor;
                            thresholdsValues[2] = thrSlider1.Value;
                            newColors[2] = btnColor2.BackColor;
                            thresholdsValues[1] = thrSlider2.Value;
                            newColors[1] = btnColor3.BackColor;
                            thresholdsValues[0] = thrSlider3.Value;
                        }
                    }
                    newColors[0] = btnColorBack.BackColor;
                    break;
                case 1: // double
                    newColors[2] = btnColor2.BackColor;
                    thresholdsValues[1] = thrSlider2.Value;
                    newColors[1] = btnColor1.BackColor;
                    thresholdsValues[0] = thrSlider1.Value;
                    if (thresholdsValues[1] > thresholdsValues[0])
                    {
                        newColors[2] = btnColor2.BackColor;
                        thresholdsValues[1] = thrSlider2.Value;
                        newColors[1] = btnColor1.BackColor;
                        thresholdsValues[0] = thrSlider1.Value;
                    }
                    else
                    {
                        newColors[2] = btnColor1.BackColor;
                        thresholdsValues[1] = thrSlider1.Value;
                        newColors[1] = btnColor2.BackColor;
                        thresholdsValues[0] = thrSlider2.Value;
                    }
                    newColors[0] = btnColorBack.BackColor;
                    break;
                case 0: // simple
                default: 
                    newColors[1] = btnColor1.BackColor;
                    thresholdsValues[0] = thrSlider1.Value;
                    newColors[0] = btnColorBack.BackColor;
                    break;
            }

            histogramControl.setLimits(comboNumber.SelectedIndex + 1, thresholdsValues);
            imagePreview = ImageLibrary.ImageLibrary.applyThreshold(comboNumber.SelectedIndex + 1, //image
                                                                    thresholdsValues, newColors);
            previewPicture.Image = imagePreview;
        }

        // changer nombre de seuils
        private void comboNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNumber.SelectedIndex >= 1)
            {
                thrSlider2.Visible = true;
                btnColor2.Visible = true;
                if (comboNumber.SelectedIndex >= 2)
                {
                    thrSlider3.Visible = true;
                    btnColor3.Visible = true;
                }
                else
                {
                    thrSlider3.Visible = false;
                    btnColor3.Visible = false;
                }
            }
            else
            {
                thrSlider2.Visible = false;
                thrSlider3.Visible = false;
                btnColor2.Visible = false;
                btnColor3.Visible = false;
            }
            setImagePreview();
        }

        // mise à jour de preview
        private void thrSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            setImagePreview();
        }
        private void thrSlider2_MouseUp(object sender, MouseEventArgs e)
        {
            setImagePreview();
        }
        private void thrSlider3_MouseUp(object sender, MouseEventArgs e)
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

        // changer couleur
        private void btnColor1_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnColor1.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor1.BackColor = colorDialog.Color;
                setImagePreview();
            }
        }
        private void btnColor2_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnColor2.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor2.BackColor = colorDialog.Color;
                setImagePreview();
            }
        }
        private void btnColor3_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnColor3.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor3.BackColor = colorDialog.Color;
                setImagePreview();
            }
        }
        private void btnColorBack_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btnColorBack.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColorBack.BackColor = colorDialog.Color;
                setImagePreview();
            }
        }
    }
}
