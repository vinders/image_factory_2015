using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLibrary
{
    public partial class ImageLibrary
    {
        private static long[] _grayscaleHistogram = null;

        // LIRE VALEURS D'HISTOGRAMME (niveaux de gris)
        public static long[] getImageHistogram(bool recheck)
        {
            if (recheck == false)
                return _grayscaleHistogram;
            if (_imageMatrix == null)
            {
                _grayscaleHistogram = null;
                return null;
            }

            // initialiser histogramme
            _grayscaleHistogram = new long[256];
            for (int z = 0; z < 256; z++)
                _grayscaleHistogram[z] = 0;

            // compter chaque valeur (+ conversion en niveaux de gris)
            int length = _imageHeight * _imageWidth * _colorLayers;
            double luminosity = 0.0;
            for (int i = 0; i < length; i += _colorLayers)
            {
                luminosity = (double)_imageMatrix[i] * 0.114 + (double)_imageMatrix[i + 1] * 0.587 + (double)_imageMatrix[i + 2] * 0.299;
                if (luminosity > 255.0)
                    luminosity = 255.0;
                _grayscaleHistogram[(int)luminosity] += 1;
            }

            return _grayscaleHistogram;
        }

        // NORMALISATION (+conversion niveaux de gris)
        private static byte[] normalize(int min, int max, bool equ, byte[] srcMatrix, int width, int height)
        {
            if (srcMatrix == null)
                return null;

            // définir taille de matrice
            byte[] destMatrix = new byte[width * height * _colorLayers];
            int length = height * width * _colorLayers;
            // histogramme
            long[] baseHisto = new long[256];
            if (equ)
            {
                for (int b = 1; b < 256; b++)
                    baseHisto[b] = 0;
            }

            // définir échelle
            if (min > max)
            {
                int tmp = min;
                min = max;
                max = tmp;
            }
            else if (min == max)
            {
                if (min > 0)
                    min -= 1;
                else
                    max += 1;
            }
            double scale = 255.0 / (double)(max - min); // limite max / différence de valeurs extrêmes

            // normaliser l'histogramme de l'image (+ conversion en niveaux de gris)
            double luminosity = 0.0;
            for (int i = 0; i < length; i += _colorLayers)
            {
                // niveaux de gris
                luminosity = (double)srcMatrix[i] * 0.114 + (double)srcMatrix[i + 1] * 0.587 + (double)srcMatrix[i + 2] * 0.299;

                // normalisation
                luminosity -= (double)min; // décaler
                if (luminosity < 0.0)
                    luminosity = 0.0;
                luminosity *= scale; // étirer
                if (luminosity > 255.0) // tronquer (si erreur d'arrondi)
                    luminosity = 255.0;

                // copie de valeur
                destMatrix[i] = destMatrix[i + 1] = destMatrix[i + 2] = (byte)luminosity;
                destMatrix[i + 3] = srcMatrix[i + 3];
                // ajouter à l'histogramme
                baseHisto[(int)luminosity] += 1;
            }
            // égalisation
            if (equ)
                return equalize(destMatrix, baseHisto, width, height);
            else
                return destMatrix;
        }

        // EGALISATION (niveaux de gris uniquement)
        private static byte[] equalize(byte[] destMatrix, long[] baseHisto, int width, int height)
        {
            if (destMatrix == null)
                return null;

            // calcul histogramme cumulé
            long[] sumHisto = new long[256];
            sumHisto[0] = baseHisto[0];
            for (int z = 1; z < 256; z++)
                sumHisto[z] = sumHisto[z-1] + baseHisto[z];

            // égaliser l'histogramme de l'image
            int length = height * width * _colorLayers;
            double valueRatio = 255.0 / (width*height); // valeur max / nombre de pixels max
            for (int i = 0; i < length; i += _colorLayers)
            {
                // valeur = (valeur max * nombre de pixels cumulés pour cette luminance) / nombre total de pixels = ratio * pixels cumulés
                destMatrix[i + 1] = destMatrix[i + 2] = (byte)((double)valueRatio * (double)sumHisto[(int)destMatrix[i]]);
                destMatrix[i] = destMatrix[i + 1];
            }
            return destMatrix;
        }

        // NORMALISATION MANUELLE
        public unsafe static Bitmap normalizeHistogram(bool equ, int min, int max)
        {
            if (_imageMatrix == null)
                return null;

            // normalisation
            byte[] destMatrix = normalize(min, max, equ, _imageMatrix, _imageWidth, _imageHeight);

            // convertir matrice en image de destination
            if (destMatrix != null)
            {
                Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
                BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
                dest.UnlockBits(rawDest);
                return dest;
            }
            else
                return null;
        }

        // NORMALISATION AUTOMATIQUE
        public unsafe static Bitmap autoNormalizeHistogram()
        {
            if (_imageMatrix == null)
                return null;

            // trouver minimum et maximum
            int min = 255;
            int max = 0;
            for (int i = 0; i < 256; i++)
            {
                if (_grayscaleHistogram[i] > 0)
                {
                    if (i < min)
                        min = i;
                    if (i > max)
                        max = i;
                }
            }

            // normalisation auto + égalisation
            byte[] destMatrix = normalize(min, max, false, _imageMatrix, _imageWidth, _imageHeight);

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // EGALISATION AUTOMATIQUE
        public unsafe static Bitmap autoEqualizeHistogram()
        {
            if (_imageMatrix == null)
                return null;

            // créer histogramme
            long[] baseHisto = new long[256];
            for (int b = 1; b < 256; b++)
                baseHisto[b] = 0;
            // conversion en niveaux de gris et création histogramme
            byte[] destMatrix = new byte[_imageHeight * _imageWidth * _colorLayers];
            int length = _imageWidth * _imageHeight * _colorLayers;
            double luminosity = 0.0;
            for (int i = 0; i < length; i += _colorLayers)
            {
                // niveaux de gris
                luminosity = (double)_imageMatrix[i] * 0.114 + (double)_imageMatrix[i + 1] * 0.587 + (double)_imageMatrix[i + 2] * 0.299;
                // copie de valeur
                destMatrix[i] = destMatrix[i + 1] = destMatrix[i + 2] = (byte)luminosity;
                destMatrix[i + 3] = _imageMatrix[i + 3];
                // ajouter à l'histogramme
                baseHisto[(int)luminosity] += 1;
            }

            // égalisation
            destMatrix = equalize(destMatrix, baseHisto, _imageWidth, _imageHeight);

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // SEUILLAGE(S)
        public unsafe static Bitmap applyThreshold(int nb, int[] thresholds, Color[] newColors)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            int length = _imageWidth * _imageHeight * _colorLayers;
            byte[] destMatrix = new byte[length];

            // choix des couleurs selon histogramme
            byte[] colorHisto = new byte[256];
            int histoI = 0;
            for (int thr = 0; thr < nb; thr++)
            {
                if (thresholds[thr] > 256)
                    thresholds[thr] = 256;
                while(histoI < thresholds[thr])
                {
                    colorHisto[histoI] = (byte)thr;
                    histoI++;
                }
            }
            while (histoI < 256)
            {
                colorHisto[histoI] = (byte)nb;
                histoI++;
            }

            // seuillage(s)
            double luminosity = 0.0;
            for (int i = 0; i < length; i += _colorLayers)
            {
                luminosity = (double)_imageMatrix[i] * 0.114 + (double)_imageMatrix[i + 1] * 0.587 + (double)_imageMatrix[i + 2] * 0.299;
                destMatrix[i] = newColors[colorHisto[(int)luminosity]].B;
                destMatrix[i + 1] = newColors[colorHisto[(int)luminosity]].G;
                destMatrix[i + 2] = newColors[colorHisto[(int)luminosity]].R;
                destMatrix[i + 3] = 255;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // SEUILLAGE AUTOMATIQUE (mélange : moitié des pixels + méthode d'otsu)
        public unsafe static Bitmap autoThreshold()
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            int length = _imageWidth * _imageHeight * _colorLayers;
            byte[] destMatrix = new byte[length];

            // calcul histogramme normalisé + totaux moyens
            if (_grayscaleHistogram == null)
                getImageHistogram(true);
            int size = _imageWidth*_imageHeight;
            float[] histoNorm = new float[255];
            float[] meanLevel = new float[255];
            meanLevel[0] = 0.0f;
            for (int n = 1; n < 255; n++)
            {
                histoNorm[n] = _grayscaleHistogram[n] / (float)size;
                meanLevel[n] = meanLevel[n-1] + ((n + 1) * histoNorm[n]);
            }

            // seuil de moitié des pixels selon histogramme cumulé
            long[] sumHisto = new long[256];
            sumHisto[0] = _grayscaleHistogram[0];
            int z;
            for (z = 1; z < 256 && sumHisto[z - 1] <= size/2; z++)
                sumHisto[z] = sumHisto[z - 1] + _grayscaleHistogram[z];
            double threshold = z - 1;

            // calcul seuil optimal
            float histoNormCumul = 0.0f;
            float eval1, eval2, divide, optimum = 0.0f;
            for (int i = 1; i < 255; i++)
            {
                histoNormCumul += histoNorm[i];
                eval1 = meanLevel[254] * histoNormCumul - meanLevel[i];
                divide = histoNormCumul * (1.0f - histoNormCumul);
                if (divide == 0.0f)
                    divide = 1f;
                eval2 = (eval1 * eval1) / divide;
                // vérifier si carré optimal
                if (eval2 > optimum)
                    optimum = eval2;
            }
            threshold = threshold*0.4 + Math.Sqrt(optimum)*0.6; // racine optimum*0.6 + moitié*0.4

            // seuillage(s)
            double luminosity = 0.0;
            for (int i = 0; i < length; i += _colorLayers)
            {
                luminosity = (double)_imageMatrix[i] * 0.114 + (double)_imageMatrix[i + 1] * 0.587 + (double)_imageMatrix[i + 2] * 0.299;
                if (luminosity >= threshold)
                    destMatrix[i] = 255;
                else
                    destMatrix[i] = 0;
                destMatrix[i + 1] = destMatrix[i + 2] = destMatrix[i];
                destMatrix[i + 3] = 255;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
    }
}
