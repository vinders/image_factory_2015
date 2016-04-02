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
        #region convolutions
        // GENERER MATRICE GAUSS 3X3, 5X5 ou 7X7
        private static float[,] getWindowMatrix(int windowSize, int factor)
        {
            float[,] windowMatrix = new float[windowSize,windowSize];
            float factorSqRoot = (float)Math.Max(1.0, (double)Math.Sqrt(factor));
            float factorRootMult = factor*factorSqRoot;

            // matrices hardcodées
            float divider = 1;
            switch (windowSize)
            {
                case 3:
                    //1 S 1
                    //S C S
                    //1 S 1
                    divider = 4.0f + 4.0f*factor + factor*factor;
                    windowMatrix[0,0] = windowMatrix[2,2] = windowMatrix[2,0] = windowMatrix[0,2] = 1;
                    windowMatrix[0,1] = windowMatrix[1,0] = windowMatrix[2,1] = windowMatrix[1,2] = factor;
                    windowMatrix[1,1] = factor*factor;
                    break;
                case 5:
                    //1 H S H 1
                    //H S D S H
                    //S D C D S
                    //H S D S H
                    //1 H S H 1
                    divider = 4.0f + 8.0f * factorSqRoot + 8.0f * factor + 4.0f * factorRootMult + factor*factor;
                    windowMatrix[0,0] = windowMatrix[4,4] = windowMatrix[4,0] = windowMatrix[0,4] = 1;
                    windowMatrix[0, 1] = windowMatrix[1, 0] = windowMatrix[4, 1] = windowMatrix[1, 4] = factorSqRoot;
                    windowMatrix[0, 3] = windowMatrix[3, 0] = windowMatrix[4, 3] = windowMatrix[3, 4] = factorSqRoot;
                    windowMatrix[0,2] = windowMatrix[2,0] = windowMatrix[4,2] = windowMatrix[2,4] = factor;
                    windowMatrix[1,1] = windowMatrix[3,1] = windowMatrix[1,3] = windowMatrix[3,3] = factor;
                    windowMatrix[1, 2] = windowMatrix[2, 1] = windowMatrix[2, 3] = windowMatrix[3, 2] = factorRootMult;
                    windowMatrix[2,2] = factor*factor;
                    break;
                case 7:
                    //1 1 H H H 1 1
                    //1 H H S H H 1
                    //H H S D S H H
                    //H S D C D S H
                    //H H S D S H H
                    //1 H H S H H 1
                    //1 1 H H H 1 1
                    divider = 12.0f + 24.0f * factorSqRoot + 8.0f * factor + 4.0f * factorRootMult + factor * factor;
                    windowMatrix[0,0] = windowMatrix[6,6] = windowMatrix[6,0] = windowMatrix[0,6] = 1;
                    windowMatrix[0,1] = windowMatrix[1,0] = windowMatrix[6,1] = windowMatrix[1,6] = 1;
                    windowMatrix[0,5] = windowMatrix[5,0] = windowMatrix[6,5] = windowMatrix[5,6] = 1;
                    windowMatrix[0, 2] = windowMatrix[0, 3] = windowMatrix[0, 4] = factorSqRoot;
                    windowMatrix[6, 2] = windowMatrix[6, 3] = windowMatrix[6, 4] = factorSqRoot;
                    windowMatrix[2, 0] = windowMatrix[3, 0] = windowMatrix[4, 0] = factorSqRoot;
                    windowMatrix[2, 6] = windowMatrix[3, 6] = windowMatrix[4, 6] = factorSqRoot;
                    windowMatrix[1, 1] = windowMatrix[1, 2] = windowMatrix[2, 1] = factorSqRoot;
                    windowMatrix[5, 5] = windowMatrix[5, 4] = windowMatrix[4, 5] = factorSqRoot;
                    windowMatrix[1, 5] = windowMatrix[1, 4] = windowMatrix[2, 5] = factorSqRoot;
                    windowMatrix[5, 1] = windowMatrix[4, 1] = windowMatrix[5, 2] = factorSqRoot;
                    windowMatrix[3,1] = windowMatrix[1,3] = windowMatrix[3,5] = windowMatrix[5,3] = factor;
                    windowMatrix[2,2] = windowMatrix[4,2] = windowMatrix[2,4] = windowMatrix[4,4] = factor;
                    windowMatrix[2, 3] = windowMatrix[3, 2] = windowMatrix[3, 4] = windowMatrix[4, 3] = factorRootMult;
                    windowMatrix[3,3] = factor*factor;
                    break;
                default: return null;
            }

            // division par nombre total
            for (int i = 0; i < windowSize; i++)
                for (int j = 0; j < windowSize; j++)
                    windowMatrix[i, j] /= divider;

            return windowMatrix;
        }

        // CONVOLUTION DE L'IMAGE
        private static unsafe Bitmap doImageConvolution(int windowSize, float[,] windowMatrix, bool alphaConvolution, bool mask)
        {
            // définir taille de matrice
            byte[] destMatrix = new byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // convolution
            int offset = windowSize / 2;
            int index, i, j, convx, convy, convindex;
            float newR, newG, newB, newA, currentFactor;
            // centre de l'image
            for (i = offset; i < _imageHeight - offset; i++)
            {
                for (j = offset * _colorLayers; j < stride - _colorLayers * offset; j += _colorLayers)
                {
                    index = i * stride + j;
                    newR = newG = newB = newA = 0.0f;

                    // moyenne pondérée des voisins
                    for (convx = -offset; convx <= offset; convx++)
                    {
                        for (convy = -offset; convy <= offset; convy++)
                        {
                            convindex = index + convy*stride + convx*_colorLayers;
                            currentFactor = windowMatrix[offset + convx, offset + convy];
                            newB += _imageMatrix[convindex] * currentFactor;
                            newG += _imageMatrix[convindex + 1] * currentFactor;
                            newR += _imageMatrix[convindex + 2] * currentFactor;
                            newA += _imageMatrix[convindex + 3] * currentFactor;
                        }
                    }

                    // copie des valeurs
                    if (mask == false)
                    {
                        destMatrix[index] = newB > 0.0f ? (byte)newB : (byte)0;
                        destMatrix[index + 1] = newG > 0.0f ? (byte)newG : (byte)0;
                        destMatrix[index + 2] = newR > 0.0f ? (byte)newR : (byte)0;
                        if (newA > 254.0f)
                            newA = 255.0f;
                        destMatrix[index + 3] = (byte)newA;
                    }
                    else
                    {
                        newB += _imageMatrix[index];
                        if (newB > 255.0f)
                            newB = 255.0f;
                        newG += _imageMatrix[index + 1];
                        if (newG > 255.0f)
                            newG = 255.0f;
                        newR += _imageMatrix[index + 2];
                        if (newR > 255.0f)
                            newR = 255.0f;
                        destMatrix[index] = newB > 0.0f ? (byte)newB : (byte)0;
                        destMatrix[index + 1] = newG > 0.0f ? (byte)newG : (byte)0;
                        destMatrix[index + 2] = newR > 0.0f ? (byte)newR : (byte)0;
                        destMatrix[index + 3] = _imageMatrix[index + 3];
                    }
                }
            }
            // bords latéraux
            destMatrix = doBorderConvolution(destMatrix, stride, mask, 0, stride, 0, offset, windowSize, windowMatrix);
            destMatrix = doBorderConvolution(destMatrix, stride, mask, 0, stride, _imageHeight - (1 + offset), _imageHeight, windowSize, windowMatrix);
            destMatrix = doBorderConvolution(destMatrix, stride, mask, 0, offset * _colorLayers, offset, _imageHeight - offset, windowSize, windowMatrix);
            destMatrix = doBorderConvolution(destMatrix, stride, mask, stride - (1+offset) * _colorLayers, stride, offset, _imageHeight - offset, windowSize, windowMatrix);

            // ajuster alpha
            if (alphaConvolution)
            {
                for (i = 0; i < _imageBytes; i += _colorLayers)
                    destMatrix[i + 3] = 255;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // CONVOLUTION DE BORDURES
        private static byte[] doBorderConvolution(byte[] destMatrix, int stride, bool mask, int startX, int maxX, int startY, int maxY, int windowSize, float[,] windowMatrix)
        {
            int i, j;
            int index, convindex, convx, convy, offset = windowSize/2;
            float newR, newG, newB, newA, currentFactor;

            for (i = startY; i < maxY; i++)
            {
                for (j = startX; j < maxX; j += _colorLayers)
                {
                    index = i * stride + j;
                    newR = newG = newB = newA = 0.0f;

                    // moyenne pondérée des voisins
                    for (convx = -offset; convx <= offset; convx++)
                    {
                        for (convy = -offset; convy <= offset; convy++)
                        {
                            if (i + convy < maxY && i + convy >= startY)
                                convindex = index + convy * stride;
                            else
                                convindex = index;
                            if (j + convx * _colorLayers < maxX && j + convx * _colorLayers >= startX)
                                convindex += convx * _colorLayers;

                            currentFactor = windowMatrix[offset + convx, offset + convy];
                            newB += _imageMatrix[convindex] * currentFactor;
                            newG += _imageMatrix[convindex + 1] * currentFactor;
                            newR += _imageMatrix[convindex + 2] * currentFactor;
                            newA += _imageMatrix[convindex + 3] * currentFactor;
                        }
                    }

                    // copie des valeurs
                    if (mask == false)
                    { 
                        destMatrix[index] = newB > 0.0f ? (byte)newB : (byte)0;
                        destMatrix[index + 1] = newG > 0.0f ? (byte)newG : (byte)0;
                        destMatrix[index + 2] = newR > 0.0f ? (byte)newR : (byte)0;
                        if (newA > 254.0f)
                            newA = 255.0f;
                        destMatrix[index + 3] = (byte)newA;
                    }
                    else
                    {
                        newB += _imageMatrix[index];
                        if (newB > 255.0f)
                            newB = 255.0f;
                        newG += _imageMatrix[index + 1];
                        if (newG > 255.0f)
                            newG = 255.0f;
                        newR += _imageMatrix[index + 2];
                        if (newR > 255.0f)
                            newR = 255.0f;
                        destMatrix[index] = newB > 0.0f ? (byte)newB : (byte)0;
                        destMatrix[index + 1] = newG > 0.0f ? (byte)newG : (byte)0;
                        destMatrix[index + 2] = newR > 0.0f ? (byte)newR : (byte)0;
                        destMatrix[index + 3] = _imageMatrix[index + 3];
                    }
                }
            }
            return destMatrix;
        }

        // DOUBLE CONVOLUTION 3X3 (gradient des deux)
        private static unsafe Bitmap doImageDoubleConvolution(float[,] gxMatrix, float[,] gyMatrix)
        {
            // définir taille de matrice
            byte[] destMatrix = new Byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // double convolution
            int index, i, j, convx, convy, convindex, convresult, convresultx, convresulty;
            float newRx, newGx, newBx, newRy, newGy, newBy, currentFactor;
            // centre de l'image
            for (i = 1; i < _imageHeight - 1; i++)
            {
                for (j = _colorLayers; j < stride - _colorLayers; j += _colorLayers)
                {
                    index = i * stride + j;

                    // moyenne pondérée des voisins
                    newRx = newGx = newBx = newRy = newGy = newBy = 0.0f;
                    for (convx = -1; convx <= 1; convx++)
                    {
                        for (convy = -1; convy <= 1; convy++)
                        {
                            convindex = index + convy * stride + convx * _colorLayers;
                            currentFactor = gxMatrix[1 + convx, 1 + convy];
                            newBx += _imageMatrix[convindex] * currentFactor;
                            newGx += _imageMatrix[convindex + 1] * currentFactor;
                            newRx += _imageMatrix[convindex + 2] * currentFactor;
                            currentFactor = gyMatrix[1 + convx, 1 + convy];
                            newBy += _imageMatrix[convindex] * currentFactor;
                            newGy += _imageMatrix[convindex + 1] * currentFactor;
                            newRy += _imageMatrix[convindex + 2] * currentFactor;
                        }
                    }

                    // copie des valeurs
                    convresultx = (int)Math.Abs(newBx);
                    convresulty = (int)Math.Abs(newBy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                    convresultx = (int)Math.Abs(newGx);
                    convresulty = (int)Math.Abs(newGy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                    convresultx = (int)Math.Abs(newRx);
                    convresulty = (int)Math.Abs(newRy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;
                    destMatrix[index + 3] = 255;
                }
            }
            // bords latéraux
            destMatrix = doBorderDoubleConvolution(destMatrix, stride, 0, stride, 0, 1, gxMatrix, gyMatrix);
            destMatrix = doBorderDoubleConvolution(destMatrix, stride, 0, stride, _imageHeight - 2, _imageHeight, gxMatrix, gyMatrix);
            destMatrix = doBorderDoubleConvolution(destMatrix, stride, 0, _colorLayers, 1, _imageHeight - 1, gxMatrix, gyMatrix);
            destMatrix = doBorderDoubleConvolution(destMatrix, stride, stride - 2 * _colorLayers, stride, 1, _imageHeight - 1, gxMatrix, gyMatrix);
            
            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // DOUBLE CONVOLUTION 3X3 DE BORDURES (gradient des deux)
        private static byte[] doBorderDoubleConvolution(byte[] destMatrix, int stride, int startX, int maxX, int startY, int maxY, float[,] gxMatrix, float[,] gyMatrix)
        {
            int i, j;
            int index, convindex, convx, convy, convresult, convresultx, convresulty;
            float newRx, newGx, newBx, newRy, newGy, newBy, currentFactor;

            for (i = startY; i < maxY; i++)
            {
                for (j = startX; j < maxX; j += _colorLayers)
                {
                    index = i * stride + j;

                    // moyenne pondérée des voisins
                    newRx = newGx = newBx = newRy = newGy = newBy = 0.0f;
                    for (convx = -1; convx <= 1; convx++)
                    {
                        for (convy = -1; convy <= 1; convy++)
                        {
                            if (i + convy < maxY && i + convy >= startY)
                                convindex = index + convy * stride;
                            else
                                convindex = index;
                            if (j + convx * _colorLayers < maxX && j + convx * _colorLayers >= startX)
                                convindex += convx * _colorLayers;

                            currentFactor = gxMatrix[1 + convx, 1 + convy];
                            newBx += _imageMatrix[convindex] * currentFactor;
                            newGx += _imageMatrix[convindex + 1] * currentFactor;
                            newRx += _imageMatrix[convindex + 2] * currentFactor;
                            currentFactor = gyMatrix[1 + convx, 1 + convy];
                            newBy += _imageMatrix[convindex] * currentFactor;
                            newGy += _imageMatrix[convindex + 1] * currentFactor;
                            newRy += _imageMatrix[convindex + 2] * currentFactor;
                        }
                    }

                    // copie des valeurs
                    convresultx = (int)Math.Abs(newBx);
                    convresulty = (int)Math.Abs(newBy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                    convresultx = (int)Math.Abs(newGx);
                    convresulty = (int)Math.Abs(newGy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                    convresultx = (int)Math.Abs(newRx);
                    convresulty = (int)Math.Abs(newRy);
                    convresult = (int)Math.Sqrt(convresultx * convresultx + convresulty * convresulty);
                    destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;
                    destMatrix[index + 3] = 255;
                }
            }
            return destMatrix;
        }

        // CONVOLUTION DIRECTIONNELLE 3X3 (dériv. maximum) - niveaux de gris uniquement
        private static unsafe Bitmap doImageDirectionalConvolution(byte[] srcMatrix, float[,] dir0, float[,] dir1, float[,] dir2, float[,] dir3, bool negative)
        {
            // définir taille de matrice
            byte[] destMatrix = new Byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // convolution directionnelle
            int index, i, j, k, convx, convy, convindex;
            float[] sum = new float[8];
            float convmax;
            // centre de l'image
            for (i = 1; i < _imageHeight - 1; i++)
            {
                for (j = _colorLayers; j < stride - _colorLayers; j += _colorLayers)
                {
                    index = i * stride + j;

                    // moyenne pondérée des voisins
                    sum[0] = sum[1] = sum[2] = sum[3] = sum[4] = sum[5] = sum[6] = sum[7] = 0.0f;
                    for (convx = -1; convx <= 1; convx++)
                    {
                        for (convy = -1; convy <= 1; convy++)
                        {
                            convindex = index + convy * stride + convx * _colorLayers;
                            sum[0] += (float)_imageMatrix[convindex] * dir0[1 + convx, 1 + convy];
                            sum[1] += (float)_imageMatrix[convindex] * dir1[1 + convx, 1 + convy];
                            sum[2] += (float)_imageMatrix[convindex] * dir2[1 + convx, 1 + convy];
                            sum[3] += (float)_imageMatrix[convindex] * dir3[1 + convx, 1 + convy];
                            sum[4] += (float)_imageMatrix[convindex] * -1.0f*dir0[1 + convx, 1 + convy];
                            sum[5] += (float)_imageMatrix[convindex] * -1.0f*dir1[1 + convx, 1 + convy];
                            sum[6] += (float)_imageMatrix[convindex] * -1.0f*dir2[1 + convx, 1 + convy];
                            sum[7] += (float)_imageMatrix[convindex] * -1.0f*dir3[1 + convx, 1 + convy];
                        }
                    }

                    // trouver la valeur maximale
                    convmax = 0.0f;
                    for (k = 0; k < 8; k++)
                    {
                        if (sum[k] > convmax)
                            convmax = sum[k];
                    }
                    if (convmax > 255.0f)
                        convmax = 255.0f;
                    // copie de la valeur
                    destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = (byte)convmax;
                    destMatrix[index + 3] = 255;
                }
            }
            // bords latéraux
            destMatrix = doBorderDirectionalConvolution(srcMatrix, destMatrix, 0, stride, 0, 1, dir0, dir1, dir2, dir3);
            destMatrix = doBorderDirectionalConvolution(srcMatrix, destMatrix, 0, stride, _imageHeight - 2, _imageHeight, dir0, dir1, dir2, dir3);
            destMatrix = doBorderDirectionalConvolution(srcMatrix, destMatrix, 0, _colorLayers, 1, _imageHeight - 1, dir0, dir1, dir2, dir3);
            destMatrix = doBorderDirectionalConvolution(srcMatrix, destMatrix, stride - 2 * _colorLayers, stride, 1, _imageHeight - 1, dir0, dir1, dir2, dir3);

            // négatif
            if (negative)
            {
                for (int n = 0; n < _imageBytes; n += _colorLayers)
                {
                    destMatrix[n] = destMatrix[n + 1] = destMatrix[n + 2] = (byte)(255 - destMatrix[n]);
                }
            }
            
            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // CONVOLUTION DIRECTIONNELLE 3X3 DE BORDURES (dériv. max) - niveaux de gris uniquement
        private static byte[] doBorderDirectionalConvolution(byte[] srcMatrix, byte[] destMatrix, int startX, int maxX, int startY, int maxY, 
                                                        float[,] dir0, float[,] dir1, float[,] dir2, float[,] dir3)
        {
            int stride = _imageWidth * _colorLayers;
            int index, i, j, k, convindex, convx, convy;
            float[] sum = new float[8];
            float convmax;

            for (i = startY; i < maxY; i++)
            {
                for (j = startX; j < maxX; j += _colorLayers)
                {
                    index = i * stride + j;

                    // moyenne pondérée des voisins
                    sum[0] = sum[1] = sum[2] = sum[3] = sum[4] = sum[5] = sum[6] = sum[7] = 0.0f;
                    for (convx = -1; convx <= 1; convx++)
                    {
                        for (convy = -1; convy <= 1; convy++)
                        {
                            if (i + convy < maxY && i + convy >= startY)
                                convindex = index + convy * stride;
                            else
                                convindex = index;
                            if (j + convx * _colorLayers < maxX && j + convx * _colorLayers >= startX)
                                convindex += convx * _colorLayers;

                            sum[0] += (float)_imageMatrix[convindex] * dir0[1 + convx, 1 + convy];
                            sum[1] += (float)_imageMatrix[convindex] * dir1[1 + convx, 1 + convy];
                            sum[2] += (float)_imageMatrix[convindex] * dir2[1 + convx, 1 + convy];
                            sum[3] += (float)_imageMatrix[convindex] * dir3[1 + convx, 1 + convy];
                            sum[4] += (float)_imageMatrix[convindex] * -1.0f * dir0[1 + convx, 1 + convy];
                            sum[5] += (float)_imageMatrix[convindex] * -1.0f * dir1[1 + convx, 1 + convy];
                            sum[6] += (float)_imageMatrix[convindex] * -1.0f * dir2[1 + convx, 1 + convy];
                            sum[7] += (float)_imageMatrix[convindex] * -1.0f * dir3[1 + convx, 1 + convy];
                        }
                    }

                    // trouver la valeur maximale
                    convmax = 0.0f;
                    for (k = 0; k < 8; k++)
                    {
                        if (sum[k] > convmax)
                            convmax = sum[k];
                    }
                    if (convmax > 255.0f)
                        convmax = 255.0f;
                    // copie de la valeur
                    destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = (byte)convmax;
                    destMatrix[index + 3] = 255;
                }
            }
            return destMatrix;
        }
        #endregion


        // FILTRES LINEAIRES 
        //----------------------------------------------------------------------

        // FILTRE MOYENNEUR
        public unsafe static Bitmap filterMean(int windowSize)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution
            if (windowSize%2 == 0 || windowSize < 3 || windowSize > 7)
                windowSize = 3;
            float[,] windowMatrix = new float[windowSize, windowSize]; 
            float divider = windowSize*windowSize;
            for (int i = 0; i < windowSize; i++)
                for (int j = 0; j < windowSize; j++)
                    windowMatrix[i,j] = 1 / divider;

            // filtre moyenneur
            return doImageConvolution(windowSize, windowMatrix, false, false);
        }

        // FILTRE GAUSSIEN
        public unsafe static Bitmap filterGauss(int windowSize, int factor)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution
            if (windowSize % 2 == 0 || windowSize < 3 || windowSize > 7)
                windowSize = 3;
            float[,] windowMatrix = getWindowMatrix(windowSize, factor);

            // filtre gaussien
            return doImageConvolution(windowSize, windowMatrix, false, false);
        }

        // FILTRES NON LINEAIRES 
        //----------------------------------------------------------------------

        #region médian
        // FILTRE MEDIAN
        public unsafe static Bitmap filterMedian(int windowSize)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            byte[] destMatrix = new Byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // filtrage
            int offset = windowSize / 2;
            int windowLength = windowSize * windowSize;
            int index, indexMed, i, j, medx, medy, k, l, min;
            int[] windowMatrix = new int[windowSize*windowSize];
            // centre de l'image
            for (i = offset; i < _imageHeight - offset; i++)
            {
                for (j = offset * _colorLayers; j < stride - _colorLayers * offset; j += _colorLayers)
                {
                    index = i * stride + j;

                    // obtenir index voisins
                    for (medy = -offset; medy <= offset; medy++)
                        for (medx = -offset; medx <= offset; medx++)
                            windowMatrix[(offset+medy)*windowSize + offset+medx] = index + medy*stride + medx*_colorLayers;
                    // trier jusqu'à la moitié
                    for (k = 0; k <= windowLength/2; k++)
                    {
                        // trouver position du minimum
                        min = k;
                        for (l = k + 1; l < windowLength; l++)
                            if (_imageMatrix[windowMatrix[l]] * 0.114 + _imageMatrix[windowMatrix[l] + 1] * 0.587 + _imageMatrix[windowMatrix[l] + 2] * 0.299
                                < _imageMatrix[windowMatrix[min]] * 0.114 + _imageMatrix[windowMatrix[min] + 1] * 0.587 + _imageMatrix[windowMatrix[min] + 2] * 0.299)
                                min = l;
                        // tri de l'élément
                        int temp = windowMatrix[k];
                        windowMatrix[k] = windowMatrix[min];
                        windowMatrix[min] = temp;
                    }
                    // obtenir indice de médiane
                    indexMed = windowMatrix[windowLength / 2];

                    // copie des valeurs
                    destMatrix[index] = _imageMatrix[indexMed];
                    destMatrix[index + 1] = _imageMatrix[indexMed+1];
                    destMatrix[index + 2] = _imageMatrix[indexMed+2];
                    destMatrix[index + 3] = _imageMatrix[index+3]; // alpha inchangé
                }
            }
            // bords latéraux
            destMatrix = findBorderMedians(destMatrix, stride, 0, stride, 0, offset, windowSize);
            destMatrix = findBorderMedians(destMatrix, stride, 0, stride, _imageHeight - (1 + offset), _imageHeight, windowSize);
            destMatrix = findBorderMedians(destMatrix, stride, 0, offset * _colorLayers, offset, _imageHeight - offset, windowSize);
            destMatrix = findBorderMedians(destMatrix, stride, stride - (1 + offset) * _colorLayers, stride, offset, _imageHeight - offset, windowSize);

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // FILTRE MEDIAN DE BORDURES D'IMAGE
        private static byte[] findBorderMedians(byte[] destMatrix, int stride, int startX, int maxX, int startY, int maxY, int windowSize)
        {
            int offset = windowSize / 2;
            int windowLength = windowSize * windowSize;
            int index, indexMed, i, j, medx, medy, k, l, min;
            int[] windowMatrix = new int[windowSize * windowSize];
            // bord de l'image
            for (i = startY; i < maxY; i++)
            {
                for (j = startX; j < maxX; j += _colorLayers)
                {
                    index = i * stride + j;

                    // obtenir index voisins (si dans l'image)
                    for (medy = -offset; medy <= offset; medy++)
                    {
                        for (medx = -offset; medx <= offset; medx++)
                        {
                            if (i + medy >= startY && i + medy < maxY)
                                windowMatrix[(offset + medy) * windowSize + offset + medx] = index + medy * stride;
                            else
                                windowMatrix[(offset + medy) * windowSize + offset + medx] = index;
                            if (j + medx * _colorLayers >= startX && j + medx * _colorLayers < maxX)
                                windowMatrix[(offset + medy) * windowSize + offset + medx] += medx * _colorLayers;
                        }
                    }
                    // trier jusqu'à la moitié
                    for (k = 0; k <= windowLength / 2; k++)
                    {
                        // trouver position du minimum
                        min = k;
                        for (l = k + 1; l < windowLength; l++)
                            if (_imageMatrix[windowMatrix[l]] * 0.114 + _imageMatrix[windowMatrix[l] + 1] * 0.587 + _imageMatrix[windowMatrix[l] + 2] * 0.299
                                < _imageMatrix[windowMatrix[min]] * 0.114 + _imageMatrix[windowMatrix[min] + 1] * 0.587 + _imageMatrix[windowMatrix[min] + 2] * 0.299)
                                min = l;
                        // tri de l'élément
                        int temp = windowMatrix[k];
                        windowMatrix[k] = windowMatrix[min];
                        windowMatrix[min] = temp;
                    }
                    // obtenir indice de médiane
                    indexMed = windowMatrix[windowLength / 2];

                    // copie des valeurs
                    destMatrix[index] = _imageMatrix[indexMed];
                    destMatrix[index + 1] = _imageMatrix[indexMed + 1];
                    destMatrix[index + 2] = _imageMatrix[indexMed + 2];
                    destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                }
            }

            return destMatrix;
        }
        #endregion

        #region frequences
        // FILTRE PASSE-BAS
        public unsafe static Bitmap filterLowpass(int windowSize)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution
            if (windowSize % 2 == 0 || windowSize < 3 || windowSize > 7)
                windowSize = 3;
            float[,] windowMatrix = new float[windowSize, windowSize];
            
            // valeurs
            switch (windowSize)
            {
                case 3:
                    for (int i = 0; i < windowSize; i++)
                        for (int j = 0; j < windowSize; j++)
                            windowMatrix[i, j] = 0.125f;
                    windowMatrix[1, 1] = 0.0f;
                    break;
                case 5:
                    for (int i = 0; i < windowSize; i++)
                        for (int j = 0; j < windowSize; j++)
                            windowMatrix[i, j] = 1.0f/19.0f;
                    windowMatrix[1, 1] = windowMatrix[1, 3] = windowMatrix[3, 1] = windowMatrix[3, 3] = 1.0f/38.0f;
                    windowMatrix[1, 2] = windowMatrix[3, 2] = windowMatrix[2, 1] = windowMatrix[2, 3] = 1.0f/76.0f;
                    windowMatrix[2, 2] = 0.0f;
                    break;
                case 7:
                    for (int i = 0; i < windowSize; i++)
                        for (int j = 0; j < windowSize; j++)
                            windowMatrix[i, j] = 1.0f / 40.0f;
                    windowMatrix[1, 3] = windowMatrix[3, 1] = windowMatrix[3, 5] = windowMatrix[5, 3] = 1.0f/80.0f;
                    windowMatrix[2, 2] = windowMatrix[2, 4] = windowMatrix[4, 2] = windowMatrix[4, 4] = 1.0f/160.0f;
                    windowMatrix[2, 3] = windowMatrix[4, 3] = windowMatrix[3, 2] = windowMatrix[3, 4] = 1.0f/160.0f;
                    windowMatrix[3, 3] = 0.0f;
                    break;
            }

            // filtre passe-haut
            return doImageConvolution(windowSize, windowMatrix, true, false);
        }

        // FILTRE PASSE-HAUT
        public unsafe static Bitmap filterHighpass(int windowSize, bool mask)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution
            if (windowSize % 2 == 0 || windowSize < 3 || windowSize > 7)
                windowSize = 3;
            float[,] windowMatrix = new float[windowSize, windowSize];
            for (int i = 0; i < windowSize; i++)
                for (int j = 0; j < windowSize; j++)
                    windowMatrix[i,j] = -1.0f;
            // valeurs
            switch (windowSize)
            {
                case 3:
                    //-1 -1 -1
                    //-1  8 -1
                    //-1 -1 -1
                    windowMatrix[1, 1] = 8.0f;
                    break;
                case 5:
                    //-1 -1 -1 -1 -1
                    //-1  1  2  1 -1
                    //-1  2  4  2 -1
                    //-1  1  2  1 -1
                    //-1 -1 -1 -1 -1
                    windowMatrix[1, 1] = windowMatrix[1, 3] = windowMatrix[3, 1] = windowMatrix[3, 3] = 1.0f;
                    windowMatrix[1, 2] = windowMatrix[3, 2] = windowMatrix[2, 1] = windowMatrix[2, 3] = 2.0f;
                    windowMatrix[2, 2] = 4.0f;
                    break;
                case 7:
                    // 0 -1 -1 -1 -1 -1  0
                    //-1 -1 -1  1 -1 -1 -1
                    //-1 -1  1  4  1 -1 -1
                    //-1  1  4  8  4  1 -1
                    //-1 -1  1  4  1 -1 -1
                    //-1 -1 -1  1 -1 -1 -1
                    // 0 -1 -1 -1 -1 -1  0
                    windowMatrix[0, 0] = windowMatrix[0, 6] = windowMatrix[6, 0] = windowMatrix[6, 6] = 0.0f;
                    windowMatrix[1, 2] = windowMatrix[2, 1] = windowMatrix[1, 4] = windowMatrix[4, 1] = -1.0f;
                    windowMatrix[4, 5] = windowMatrix[5, 4] = windowMatrix[2, 5] = windowMatrix[5, 2] = -1.0f;
                    windowMatrix[1, 3] = windowMatrix[3, 1] = windowMatrix[3, 5] = windowMatrix[5, 3] = 1.0f;
                    windowMatrix[2, 2] = windowMatrix[2, 4] = windowMatrix[4, 2] = windowMatrix[4, 4] = 1.0f;
                    windowMatrix[2, 3] = windowMatrix[4, 3] = windowMatrix[3, 2] = windowMatrix[3, 4] = 4.0f;
                    windowMatrix[3, 3] = 8.0f;
                    break;
            }

            // filtre passe-haut
            return doImageConvolution(windowSize, windowMatrix, true, mask);
        }

        // UNSHARP MASKING
        public unsafe static Bitmap unsharpMasking(int windowSize, int maskFactor, int factor)
        {
            if (_imageMatrix == null)
                return null;

            // créer masque gaussien
            Bitmap mask = filterGauss(windowSize, maskFactor);
            // convertir bitmap en matrice
            Rectangle srcSize = new Rectangle(0, 0, mask.Width, mask.Height);
            BitmapData rawSrc = mask.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            byte[] maskMatrix = new byte[_imageBytes];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, maskMatrix, 0, _imageBytes);
            mask.UnlockBits(rawSrc);

            // définir taille de matrice
            int destBytes = _imageWidth * _imageHeight * _colorLayers;
            byte[] destMatrix = new byte[destBytes];

            // unsharp masking
            float multiplier = (float)factor / 2.0f;
            float newVal;
            for (int i = 0; i < destBytes; i += _colorLayers)
            {
                // appliquer masque
                newVal = (float)_imageMatrix[i] + ((float)_imageMatrix[i] - (float)maskMatrix[i])*multiplier;
                if (newVal < 0.0f)
                    newVal = 0.0f;
                if (newVal > 255.0f)
                    newVal = 255.0f;
                destMatrix[i] = (byte)newVal;
                newVal = (float)_imageMatrix[i + 1] + ((float)_imageMatrix[i + 1] - (float)maskMatrix[i + 1]) * multiplier;
                if (newVal < 0.0f)
                    newVal = 0.0f;
                if (newVal > 255.0f)
                    newVal = 255.0f;
                destMatrix[i+1] = (byte)newVal;
                newVal = (float)_imageMatrix[i + 2] + ((float)_imageMatrix[i + 2] - (float)maskMatrix[i + 2]) * multiplier;
                if (newVal < 0.0f)
                    newVal = 0.0f;
                if (newVal > 255.0f)
                    newVal = 255.0f;
                destMatrix[i+2] = (byte)newVal;
                destMatrix[i + 3] = _imageMatrix[i+3]; // alpha inchangé
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
        #endregion

        // FILTRES DETECTION CONTOURS 
        //----------------------------------------------------------------------

        #region contours
        // SOBEL
        public unsafe static Bitmap filterSobel(bool division)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution Gx
            float[,] gxMatrix = new float[3, 3];
            if (division)
            {
                gxMatrix[0, 0] = gxMatrix[2, 0] = -0.25f;
                gxMatrix[1, 0] = -0.5f;
                gxMatrix[0, 1] = gxMatrix[1, 1] = gxMatrix[2, 1] = 0.0f;
                gxMatrix[0, 2] = gxMatrix[2, 2] = 0.25f;
                gxMatrix[1, 2] = 0.5f;
            }
            else
            {
                gxMatrix[0, 0] = gxMatrix[2, 0] = -1.0f;
                gxMatrix[1, 0] = -2.0f;
                gxMatrix[0, 1] = gxMatrix[1, 1] = gxMatrix[2, 1] = 0.0f;
                gxMatrix[0, 2] = gxMatrix[2, 2] = 1.0f;
                gxMatrix[1, 2] = 2.0f;
            }

            // matrice de convolution Gy
            float[,] gyMatrix = new float[3, 3];
            if (division)
            {
                gyMatrix[0, 0] = gyMatrix[0, 2] = -0.25f;
                gyMatrix[0, 1] = -0.5f;
                gyMatrix[1, 0] = gyMatrix[1, 1] = gyMatrix[1, 2] = 0.0f;
                gyMatrix[2, 0] = gyMatrix[2, 2] = 0.25f;
                gyMatrix[2, 1] = 0.5f;
            }
            else
            {
                gyMatrix[0, 0] = gyMatrix[0, 2] = -1.0f;
                gyMatrix[0, 1] = -2.0f;
                gyMatrix[1, 0] = gyMatrix[1, 1] = gyMatrix[1, 2] = 0.0f;
                gyMatrix[2, 0] = gyMatrix[2, 2] = 1.0f;
                gyMatrix[2, 1] = 2.0f;
            }

            // filtre de Sobel
            return doImageDoubleConvolution(gxMatrix, gyMatrix);
        }

        // PREWITT
        public unsafe static Bitmap filterPrewitt(bool division)
        {
            if (_imageMatrix == null)
                return null;

            // matrice de convolution Gx
            float[,] gxMatrix = new float[3, 3];
            if (division)
            {
                gxMatrix[0, 0] = gxMatrix[1, 0] = gxMatrix[2, 0] = -1.0f / 3.0f;
                gxMatrix[0, 1] = gxMatrix[1, 1] = gxMatrix[2, 1] = 0.0f;
                gxMatrix[0, 2] = gxMatrix[1, 2] = gxMatrix[2, 2] = 1.0f / 3.0f;
            }
            else
            {
                gxMatrix[0, 0] = gxMatrix[1, 0] = gxMatrix[2, 0] = -1.0f;
                gxMatrix[0, 1] = gxMatrix[1, 1] = gxMatrix[2, 1] = 0.0f;
                gxMatrix[0, 2] = gxMatrix[1, 2] = gxMatrix[2, 2] = 1.0f;
            }

            // matrice de convolution Gy
            float[,] gyMatrix = new float[3, 3];
            if (division)
            {
                gyMatrix[0, 0] = gyMatrix[0, 1] = gyMatrix[0, 2] = -1.0f / 3.0f;
                gyMatrix[1, 0] = gyMatrix[1, 1] = gyMatrix[1, 2] = 0.0f;
                gyMatrix[2, 0] = gyMatrix[2, 1] = gyMatrix[2, 2] = 1.0f / 3.0f;
            }
            else
            {
                gyMatrix[0, 0] = gyMatrix[0, 1] = gyMatrix[0, 2] = -1.0f;
                gyMatrix[1, 0] = gyMatrix[1, 1] = gyMatrix[1, 2] = 0.0f;
                gyMatrix[2, 0] = gyMatrix[2, 1] = gyMatrix[2, 2] = 1.0f;
            }

            // filtre de Prewitt
            return doImageDoubleConvolution(gxMatrix, gyMatrix);
        }

        // KIRSCH
        public unsafe static Bitmap filterKirsch(bool negative)
        {
            if (_imageMatrix == null)
                return null;

            // code de Freeman :
            //3   2   1
            //    ^
            //4 <   > 0
            //    v
            //5   6   7
            // matrices de directions
            float[,] dir0 = new float[3,3];
            dir0[0,0] = dir0[1,0] = dir0[2,0] = -1.0f / 3.0f;
            dir0[0,1] = dir0[1,1] = dir0[2,1] = 0.0f;
            dir0[0,2] = dir0[1,2] = dir0[2,2] = 1.0f / 3.0f;
            float[,] dir1 = new float[3,3];
            dir1[0,1] = dir1[0,2] = dir1[1,2] = 1.0f / 3.0f;
            dir1[0,0] = dir1[1,1] = dir1[2,2] = 0.0f;
            dir1[1,0] = dir1[2,0] = dir1[2,1] = -1.0f / 3.0f;
            float[,] dir2 = new float[3,3];
            dir2[0,0] = dir2[0,1] = dir2[0,2] = 1.0f / 3.0f;
            dir2[1,0] = dir2[1,1] = dir2[1,2] = 0.0f;
            dir2[2,0] = dir2[2,1] = dir2[2,2] = -1.0f / 3.0f;
            float[,] dir3 = new float[3,3];
            dir3[0,0] = dir3[1,0] = dir3[0,1] = 1.0f / 3.0f;
            dir3[0,2] = dir3[1,1] = dir3[2,0] = 0.0f;
            dir3[1,2] = dir3[2,1] = dir3[2,2] = -1.0f / 3.0f;

            // conversion en niveaux de gris
            byte[] grayMatrix = new byte[_imageBytes];
            float luminosity;
            for (int i = 0; i < _imageBytes; i += _colorLayers)
            {
                luminosity = (float)_imageMatrix[i]*0.144f + (float)_imageMatrix[i+1]*0.587f + (float)_imageMatrix[i+2]*0.299f;
                if (luminosity > 255.0f)
                    luminosity = 255.0f;
                grayMatrix[i] = grayMatrix[i+1] = grayMatrix[i+2] = (byte)luminosity;
                grayMatrix[i + 3] = 255;
            }

            // filtre de Kirsch
            return doImageDirectionalConvolution(grayMatrix, dir0, dir1, dir2, dir3, negative);
        }

        // ROBERTS
        public unsafe static Bitmap filterRoberts(bool negativeGray)
        {
            if (_imageMatrix == null)
                return null;

            // addition des masques de Roberts
            int index, i, j, convresult;
            double convpart1, convpart2;
            byte[] destMatrix = new byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;
            for (i = 0; i < _imageHeight - 1; i++)
            {
                for (j = 0; j < stride - _colorLayers; j += _colorLayers)
                {
                    index = i * stride + j;

                    //SQRT( ([i+1][j] - [i][j+1])^2 + ([i][j] - [i+1][j+1])^2 )
                    //rouge
                    convpart1 = (_imageMatrix[index + stride] - _imageMatrix[index + _colorLayers]);
                    convpart2 = (_imageMatrix[index] - _imageMatrix[index + stride + _colorLayers]);
                    convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2);
                    destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                    //vert
                    convpart1 = (_imageMatrix[index+1 + stride] - _imageMatrix[index+1 + _colorLayers]);
                    convpart2 = (_imageMatrix[index+1] - _imageMatrix[index+1 + stride + _colorLayers]);
                    convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2);
                    destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                    //rouge
                    convpart1 = (_imageMatrix[index + 2 + stride] - _imageMatrix[index + 2 + _colorLayers]);
                    convpart2 = (_imageMatrix[index + 2] - _imageMatrix[index + 2 + stride + _colorLayers]);
                    convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2); 
                    destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;

                    /* //| [i+1][j] - [i][j+1] | + | [i][j] - [i+1][j+1] |
                    //bleu
                    convresult = Math.Abs(_imageMatrix[index + stride] - _imageMatrix[index + _colorLayers]) 
                         + Math.Abs(_imageMatrix[index] - _imageMatrix[index + stride + _colorLayers]); 
                    destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                    //vert
                    convresult = Math.Abs(_imageMatrix[index + 1 + stride] - _imageMatrix[index + 1 + _colorLayers])
                         + Math.Abs(_imageMatrix[index + 1] - _imageMatrix[index + 1 + stride + _colorLayers]); 
                    destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                    //rouge
                    convresult = Math.Abs(_imageMatrix[index + 2 + stride] - _imageMatrix[index + 2 + _colorLayers])
                         + Math.Abs(_imageMatrix[index + 2] - _imageMatrix[index + 2 + stride + _colorLayers]); 
                    destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;
                     */
                    //alpha
                    destMatrix[index + 3] = 255;
                }
            }
            // bordures
            destMatrix = filterRobertsBorders(destMatrix);

            // niveaux de gris et négatif
            if (negativeGray)
            {
                float luminosity;
                for (int n = 0; n < _imageBytes; n += _colorLayers)
                {
                    luminosity = (float)destMatrix[n] * 0.114f + (float)destMatrix[n + 1] * 0.587f + (float)destMatrix[n + 2] * 0.299f;
                    if (luminosity > 255)
                        luminosity = 255;
                    destMatrix[n] = destMatrix[n + 1] = destMatrix[n + 2] = (byte)(255 - (int)luminosity);
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
        // ROBERTS - bordures
        private static byte[] filterRobertsBorders(byte[] destMatrix)
        {
            //bordure inférieure
            int i, j, convresult;
            int stride = _imageWidth * _colorLayers;
            int index = (_imageHeight - 1) * stride;
            double convpart1, convpart2;
            for (j = 0; j < stride - _colorLayers; j += _colorLayers)
            {
                convpart1 = (_imageMatrix[index] - _imageMatrix[index + _colorLayers]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart1 * convpart1);
                destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                convpart1 = (_imageMatrix[index+1] - _imageMatrix[index+1 + _colorLayers]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart1 * convpart1);
                destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                convpart1 = (_imageMatrix[index+2] - _imageMatrix[index+2 + _colorLayers]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart1 * convpart1);
                destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;
                destMatrix[index + 3] = 255; // alpha

                index += _colorLayers; // prochaine colonne
            }
            //bordure droite
            index = stride - (_colorLayers);
            for (i = 0; i < _imageHeight - 1; i++)
            {
                convpart1 = (_imageMatrix[index + stride] - _imageMatrix[index]);
                convpart2 = (_imageMatrix[index] - _imageMatrix[index + stride]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2);
                destMatrix[index] = convresult > 255 ? (byte)255 : (byte)convresult;
                convpart1 = (_imageMatrix[index+1 + stride] - _imageMatrix[index+1]);
                convpart2 = (_imageMatrix[index+1] - _imageMatrix[index+1 + stride]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2);
                destMatrix[index + 1] = convresult > 255 ? (byte)255 : (byte)convresult;
                convpart1 = (_imageMatrix[index+2 + stride] - _imageMatrix[index+2]);
                convpart2 = (_imageMatrix[index+2] - _imageMatrix[index+2 + stride]);
                convresult = (int)Math.Sqrt(convpart1 * convpart1 + convpart2 * convpart2);
                destMatrix[index + 2] = convresult > 255 ? (byte)255 : (byte)convresult;
                destMatrix[index + 3] = 255; // alpha

                index += stride; // prochaine ligne
            }
            // coin
            index = _imageBytes - (_colorLayers);
            destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = (byte)0;
            destMatrix[index + 3] = 255;

            return destMatrix;
        }

        // LAPLACE POSITIF
        public unsafe static Bitmap filterLaplace(int type, bool applyMask)
        {
            if (_imageMatrix == null)
                return null;

            float[,] windowMatrix = new float[3, 3];
            switch (type)
            { 
                case 2:
                    // matrice de convolution
                    // 1 -2  1
                    //-2  4 -2
                    // 1 -2  1
                    windowMatrix[0, 0] = windowMatrix[0, 2] = windowMatrix[2, 0] = windowMatrix[2, 2] = 1.0f;
                    windowMatrix[0, 1] = windowMatrix[1, 0] = windowMatrix[2, 1] = windowMatrix[1, 2] = -2.0f;
                    windowMatrix[1, 1] = 4.0f;
                    break;
                default:
                    // matrice de convolution
                    // 0 -1  0
                    //-1  4 -1
                    // 0 -1  0
                    windowMatrix[0, 0] = windowMatrix[0, 2] = windowMatrix[2, 0] = windowMatrix[2, 2] = 0.0f;
                    windowMatrix[0, 1] = windowMatrix[1, 0] = windowMatrix[2, 1] = windowMatrix[1, 2] = -1.0f;
                    windowMatrix[1, 1] = 4.0f;
                    break;
            }
            // opérateur laplacien
            return doImageConvolution(3, windowMatrix, true, applyMask);
        }
        #endregion

        // FILTRES MORPHOLOGIQUES 
        //----------------------------------------------------------------------

        #region morphologie
        // EROSION
        public unsafe static Bitmap morphErosion(Bitmap source, int neighbors, int strength)
        {
            if (source == null)
                return null;

            // convertir bitmap en matrice
            Rectangle srcSize = new Rectangle(0, 0, source.Width, source.Height);
            BitmapData rawSrc = source.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            byte[] destMatrix = new byte[source.Width * source.Height * _colorLayers];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, destMatrix, 0, _imageBytes);
            source.UnlockBits(rawSrc);

            // érosion
            int connected = neighbors;
            if (neighbors == 4)
                neighbors = -1;
            else if (neighbors >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < strength; i++)
            {
                destMatrix = morphErosion(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(source.Width, source.Height);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
        private static byte[] morphErosion(byte[] srcMatrix, int width, int height, int neighbors)
        {
            // définir taille de matrice
            int destBytes = width * height * _colorLayers;
            byte[] destMatrix = new byte[destBytes];

            // érosion
            int stride = width * _colorLayers;
            int index;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < stride; j += _colorLayers)
                {
                    index = i*stride + j;
                    // pixel actif
                    if (srcMatrix[index] > 0 || srcMatrix[index+1] > 0 || srcMatrix[index+2] > 0)
                    {
                        // voisinage total (sinon effacer)
                        if (neighbors >= 0 && ((i > 0 && (srcMatrix[index - stride] == 0 
                                        || srcMatrix[index+1 - stride] == 0 
                                        || srcMatrix[index+2 - stride] == 0))
                          || (i < height - 1 && (srcMatrix[index + stride] == 0 
                                                || srcMatrix[index+1 + stride] == 0 
                                                || srcMatrix[index+2 + stride] == 0))
                          || (j > 0 && (srcMatrix[index - _colorLayers] == 0 
                                        || srcMatrix[index+1 - _colorLayers] == 0 
                                        || srcMatrix[index+2 - _colorLayers] == 0))
                          || (j < stride - _colorLayers && (srcMatrix[index + _colorLayers] == 0 
                                                            || srcMatrix[index + 1 + _colorLayers] == 0 
                                                            || srcMatrix[index + 2 + _colorLayers] == 0)))
                          || (neighbors != 0
                             && ((i > 0 && j > 0 && (srcMatrix[index - (stride + _colorLayers)] == 0
                                                    || srcMatrix[index + 1 - (stride + _colorLayers)] == 0
                                                    || srcMatrix[index + 2 - (stride + _colorLayers)] == 0))
                               || (i > 0 && j < stride - _colorLayers && (srcMatrix[index + _colorLayers - stride] == 0
                                                    || srcMatrix[index + 1 + _colorLayers - stride] == 0
                                                    || srcMatrix[index + 2 + _colorLayers - stride] == 0))
                               || (i < height - 1 && j > 0 && (srcMatrix[index + stride - _colorLayers] == 0
                                                    || srcMatrix[index + 1 + stride - _colorLayers] == 0
                                                    || srcMatrix[index + 2 + stride - _colorLayers] == 0))
                               || (i < height - 1 && j < stride - _colorLayers && (srcMatrix[index + stride + _colorLayers] == 0
                                                    || srcMatrix[index + 1 + stride + _colorLayers] == 0
                                                    || srcMatrix[index + 2 + stride + _colorLayers] == 0)))))
                        {
                            // effacer
                            destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 0;
                        }
                        else
                        {
                            // conserver
                            destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 255;
                        }
                    }
                    else
                    {
                        // ne pas activer
                        destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 0;
                    }
                    destMatrix[index+3] = 255;
                }
            }

            return destMatrix;
        }

        // DILATATION
        public unsafe static Bitmap morphDilatation(Bitmap source, int neighbors, int strength)
        {
            if (source == null)
                return null;

            // convertir bitmap en matrice
            Rectangle srcSize = new Rectangle(0, 0, source.Width, source.Height);
            BitmapData rawSrc = source.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            byte[] destMatrix = new byte[source.Width * source.Height * _colorLayers];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, destMatrix, 0, _imageBytes);
            source.UnlockBits(rawSrc);

            // dilatation
            int connected = neighbors;
            if (neighbors == 4)
                neighbors = -1;
            else if (neighbors >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < strength; i++)
            {
                destMatrix = morphDilatation(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(source.Width, source.Height);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
        private static byte[] morphDilatation(byte[] srcMatrix, int width, int height, int neighbors)
        {
            // définir taille de matrice
            int destBytes = width * height * _colorLayers;
            byte[] destMatrix = new byte[destBytes];

            // érosion
            int stride = width * _colorLayers;
            int index;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < stride; j += _colorLayers)
                {
                    index = i * stride + j;
                    // pixel inactif
                    if (srcMatrix[index] == 0 && srcMatrix[index + 1] == 0 && srcMatrix[index + 2] == 0)
                    {
                        // voisinage 4 connexe avec au moins un pixel actif (sinon effacer)
                        if (neighbors >= 0 && ((i > 0 && (srcMatrix[index - stride] > 0
                                        || srcMatrix[index + 1 - stride] > 0
                                        || srcMatrix[index + 2 - stride] > 0))
                          || (i < height - 1 && (srcMatrix[index + stride] > 0
                                                || srcMatrix[index + 1 + stride] > 0
                                                || srcMatrix[index + 2 + stride] > 0))
                          || (j > 0 && (srcMatrix[index - _colorLayers] > 0
                                        || srcMatrix[index + 1 - _colorLayers] > 0
                                        || srcMatrix[index + 2 - _colorLayers] > 0))
                          || (j < stride - _colorLayers && (srcMatrix[index + _colorLayers] > 0
                                                            || srcMatrix[index + 1 + _colorLayers] > 0
                                                            || srcMatrix[index + 2 + _colorLayers] > 0)))
                          || (neighbors != 0
                             && ((i > 0 && j > 0 && (srcMatrix[index - (stride + _colorLayers)] > 0
                                                    || srcMatrix[index + 1 - (stride + _colorLayers)] > 0
                                                    || srcMatrix[index + 2 - (stride + _colorLayers)] > 0))
                               || (i > 0 && j < stride - _colorLayers && (srcMatrix[index + _colorLayers - stride] > 0
                                                    || srcMatrix[index + 1 + _colorLayers - stride] > 0
                                                    || srcMatrix[index + 2 + _colorLayers - stride] > 0))
                               || (i < height - 1 && j > 0 && (srcMatrix[index + stride - _colorLayers] > 0
                                                    || srcMatrix[index + 1 + stride - _colorLayers] > 0
                                                    || srcMatrix[index + 2 + stride - _colorLayers] > 0))
                               || (i < height - 1 && j < stride - _colorLayers && (srcMatrix[index + stride + _colorLayers] > 0
                                                    || srcMatrix[index + 1 + stride + _colorLayers] > 0
                                                    || srcMatrix[index + 2 + stride + _colorLayers] > 0) ) ) ) )
                        {
                            // activer
                            destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 255;
                        }
                        else
                        {
                            // effacer
                            destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 0;
                        }
                    }
                    else
                    {
                        // conserver
                        destMatrix[index] = destMatrix[index + 1] = destMatrix[index + 2] = 255;
                    }
                    destMatrix[index + 3] = 255;
                }
            }

            return destMatrix;
        }

        // OUVERTURE
        public unsafe static Bitmap morphOpen(Bitmap source, int neighbors, int passes)
        {
            if (source == null)
                return null;

            // convertir bitmap en matrice
            Rectangle srcSize = new Rectangle(0, 0, source.Width, source.Height);
            BitmapData rawSrc = source.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            byte[] destMatrix = new byte[source.Width * source.Height * _colorLayers];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, destMatrix, 0, _imageBytes);
            source.UnlockBits(rawSrc);

            // ouverture
            int connected = neighbors;
            if (neighbors == 4)
                neighbors = -1;
            else if (neighbors >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < passes; i++)
            {
                destMatrix = morphErosion(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }
            if (connected != 4 && connected >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < passes; i++)
            {
                destMatrix = morphDilatation(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(source.Width, source.Height);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // FERMETURE
        public unsafe static Bitmap morphClose(Bitmap source, int neighbors, int passes)
        {
            if (source == null)
                return null;

            // convertir bitmap en matrice
            Rectangle srcSize = new Rectangle(0, 0, source.Width, source.Height);
            BitmapData rawSrc = source.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            byte[] destMatrix = new byte[source.Width * source.Height * _colorLayers];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, destMatrix, 0, _imageBytes);
            source.UnlockBits(rawSrc);

            // fermeture
            int connected = neighbors;
            if (neighbors == 4)
                neighbors = -1;
            else if (neighbors >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < passes; i++)
            {
                destMatrix = morphDilatation(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }
            if (connected != 4 && connected >= 2)
                neighbors = connected - 2;
            for (int i = 0; i < passes; i++)
            {
                destMatrix = morphErosion(destMatrix, source.Width, source.Height, neighbors);
                if (connected >= 2)
                    neighbors ^= 1;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(source.Width, source.Height);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
        #endregion
    }
}
