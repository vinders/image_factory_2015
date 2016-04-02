using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageLibrary;

namespace ImageFactory
{
    public partial class PaletteControl : UserControl
    {
        // variables de palette
        private Color origColor;
        private Color newColor;

        public PaletteControl()
        {
            InitializeComponent();
            origColor = Color.Black;
            newColor = Color.White;
            cboxPalettePlane.SelectedIndex = 0;
        }

        public void setImageColor(Color pickedColor)
        {
            if (radioPickerOrig.Checked == true)
            {
                origColor = pickedColor;
                btnPaletteOrigColor.BackColor = pickedColor;
            }
            else
            {
                newColor = pickedColor;
                btnPaletteNewColor.BackColor = pickedColor;
            }
        }

        // remplacement de couleur de palette
        private void btnPaletteChange_Click(object sender, EventArgs e)
        {
            if (origColor.ToArgb() == newColor.ToArgb())
            {
                MessageBox.Show("Les deux couleurs sont identiques");
                return;
            }

            ((mainForm)this.Parent.Parent).setBitmapPaletteColor(origColor, newColor, (int)numAccept.Value);
        }

        // choix manuel de couleur originale
        private void btnPaletteOrigColor_Click(object sender, EventArgs e)
        {
            colorPicker.Color = origColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                origColor = colorPicker.Color;
                btnPaletteOrigColor.BackColor = origColor;
            }
        }

        // choix manuel de nouvelle couleur
        private void btnPaletteNewColor_Click(object sender, EventArgs e)
        {
            colorPicker.Color = newColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                newColor = colorPicker.Color;
                btnPaletteNewColor.BackColor = newColor;
            }
        }

        // event handler - modifier mode de couleur ou extraire plan
        private void btnPalettePlane_Click(object sender, EventArgs e)
        {
            if (cboxPalettePlane.SelectedIndex == 4)
            {
                ((mainForm)this.Parent.Parent).setBitmapOpposite();
            }
            else
            {
                Color choice;
                switch (cboxPalettePlane.SelectedIndex)
                {
                    case 0: choice = Color.Black; break;
                    case 1: choice = Color.Red; break;
                    case 2: choice = Color.Green; break;
                    case 3: choice = Color.Blue; break;
                    default: choice = Color.Black; break;
                }
                ((mainForm)this.Parent.Parent).setBitmapColorPlane(choice);
            }
        }
    }
}
