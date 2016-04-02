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
        private static double[,] _cooccurrenceMatrix = null;
        public static double cooccurrenceMax = 0.0;
        public static int cooccurrenceTotal = 0;

        // MATRICE DE CO-OCCURRENCE
        public unsafe static bool setCooccurrenceMatrix(int order, int[,] directions, int distance, bool isGrayscale, bool symetric)
        {
            if (_imageMatrix == null)
                return false;
            int i, j, k;

            // création de bitmap monochrome (8 bits/pixel)
            byte[] monochromeImage = getMonochromeImage(isGrayscale);
            // création de matrice de co-occurrence (2^8 * 2^8)
            _cooccurrenceMatrix = new double[256, 256];
            for (i = 0; i < 256; i++)
                for (j = 0; j < 256; j++)
                    _cooccurrenceMatrix[i, j] = 0;

            // remplissage de la matrice
            cooccurrenceTotal = 0;
            int indexX, indexY, curPx, neighborPx;
            for (k = 0; k < order; k++) // chaque ordre
            {
                for (i = 0; i < _imageHeight; i++) // hauteur
                {
                    for (j = 0; j < _imageWidth; j++) // largeur
                    {
                        // repérer pixel voisin
                        indexX = j + distance * directions[k, 0];
                        indexY = i + distance * directions[k, 1];
                        if (indexX > 0 && indexX < _imageWidth && indexY > 0 && indexY < _imageHeight) // pixel dans l'image
                        {
                            // valeurs (pixel courant et pixel voisin)
                            curPx = monochromeImage[i*_imageWidth + j];
                            neighborPx = monochromeImage[indexY*_imageWidth + indexX];
                            // incrémenter matrice co-occurrence
                            _cooccurrenceMatrix[curPx, neighborPx]++;
                            if (symetric)
                            {
                                _cooccurrenceMatrix[neighborPx, curPx]++;
                                cooccurrenceTotal += 2;
                            }
                            else
                                cooccurrenceTotal++;
                        }
                    }
                }
            }

            // récupérer le maximum
            cooccurrenceMax = 0.0;
            for (i = 0; i < 256; i++)
            {
                for (j = 0; j < 256; j++)
                {
                    if (_cooccurrenceMatrix[i, j] > cooccurrenceMax)
                        cooccurrenceMax = _cooccurrenceMatrix[i, j];
                }
            }
            // normalisation (division par la somme et moyenne du nombre d'ordres)
            if (cooccurrenceTotal != 0.0)
            {
                double divider = cooccurrenceTotal * (double)order;
                for (i = 0; i < 256; i++)
                    for (j = 0; j < 256; j++)
                        _cooccurrenceMatrix[i, j] /= divider;
            }
            return true;
        }

        // CONVERSION SOURCE EN IMAGE 8 BITS MONOCHROME
        private static byte[] getMonochromeImage(bool isGrayscale)
        {
            byte[] monochromeMatrix = new byte[_imageWidth * _imageHeight];
            int i, j;
            if (isGrayscale == false) // conversion en niveaux de gris puis copie de bytes
            {
                float luminosity;
                j = 0;
                for (i = 0; i < _imageBytes; i += _colorLayers)
                {
                    luminosity = (float)_imageMatrix[i] * 0.114f + (float)_imageMatrix[i + 1] * 0.587f + (float)_imageMatrix[i + 2] * 0.299f;
                    if (luminosity > 255.0f)
                        luminosity = 255.0f;
                    monochromeMatrix[j] = (byte)luminosity;
                    j++;
                }
            }
            else // copie de bytes (image grise)
            {
                j = 0;
                for (i = 0; i < _imageBytes; i += _colorLayers)
                {
                    monochromeMatrix[j] = _imageMatrix[i];
                    j++;
                }
            }
            return monochromeMatrix;
        }

        // CONVERSION EN BITMAP
        public static unsafe Bitmap getCoocurrenceBitmap()
        {
            if (_cooccurrenceMatrix == null)
                return null;

            // convertir matrice en image de destination
            byte[] destMatrix = new byte[256 * 256 * _colorLayers];
            int stride = 256*_colorLayers;
            double grayVal;
            int index;
            double factor = 128.0 * (256*256); // approximation pour augmenter contraste
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    grayVal = factor * _cooccurrenceMatrix[i, j];
                    if (grayVal > 255.0)
                        grayVal = 255.0;
                    index = i * stride + j * _colorLayers;
                    destMatrix[index] = destMatrix[index+1] = destMatrix[index+2] = (byte)grayVal;
                    destMatrix[index+3] = 255;
                }
            }
            Bitmap dest = new Bitmap(256, 256);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, 256, 256), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // STATISTIQUES
        public static double statEnergy = 0.0;
        public static double statInertia = 0.0;
        public static double statHomogeneity = 0.0;
        public static double statCorrelation = 0.0;
        public static void doCooccurrenceStats()
        {
            if (_cooccurrenceMatrix == null)
                return;

            int i, j;
            double tmpVal, tmpOp;
            double average = cooccurrenceTotal / (256 * 256);
            // variance
            double variance = 0.0;
            for (i = 0; i < 256; i++)
                for (j = 0; j < 256; j++)
                    variance += _cooccurrenceMatrix[i, j] * (i - average) * (i - average);

            // statistiques
            statEnergy = 0.0;
            tmpOp = 0.0;
            statInertia = 0.0;
            statHomogeneity = 0.0;
            statCorrelation = 0.0;
            for (i = 0; i < 256; i++)
            {
                for (j = 0; j < 256; j++)
                {
                    tmpVal = _cooccurrenceMatrix[i, j];
                    statEnergy +=  tmpVal * tmpVal;
                    tmpOp = (i - j) * (i - j);
                    statInertia += tmpOp * tmpVal;
                    statHomogeneity += tmpVal / (1.0 + tmpOp);
                    statCorrelation += (tmpVal * ((double)i - average) * ((double)j - average)) / variance;
                }
            }
        }

        // NORMALISATION 3D DES VALEURS (entre 0 et 1)
        public static double[,] getNormalizedMatrix()
        {
            // chercher valeur normalisée max
            int i, j;
            double max = 0.0;
            for (i = 0; i < 256; i++)
            {
                for (j = 0; j < 256; j++)
                {
                    if (_cooccurrenceMatrix[i,j] > max)
                        max = _cooccurrenceMatrix[i,j];
                }
            }
            if (max == 0.0)
                max = 1.0;
            
            // normaliser entre 0 et 1
            double[,] normMatrix = new double[256,256];
            for (i = 0; i < 256; i++)
                for (j = 0; j < 256; j++)
                    normMatrix[i,j] = _cooccurrenceMatrix[i,j] / max;
            return normMatrix;
        }
    }
}
