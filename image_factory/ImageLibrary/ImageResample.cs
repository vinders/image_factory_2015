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
        public const int MAX_SIZE = 2000;

        private static int sourceSizeXToScale;
        private static int sourceSizeYToScale;
        private static int destScaledSizeX;
        private static int destScaledSizeY;
        private static float ratioX;
        private static float ratioY;

        // CALCUL DE DIMENSIONS SOURCE MAX (selon facteur)
        private static void setScaledSize(float factorX, float factorY)
        {
            // dimensions source
            sourceSizeXToScale = _imageWidth;
            sourceSizeYToScale = _imageHeight;

            // calcul dimensions destination
            destScaledSizeX = (int)((float)_imageWidth * (float)factorX);
            if (destScaledSizeX < 1) // min
                destScaledSizeX = 1;
            destScaledSizeY = (int)((float)_imageHeight * (float)factorY);
            if (destScaledSizeY < 1) // min
                destScaledSizeY = 1;

            // limite de largeur -> tronquer source
            float modifier;
            if (destScaledSizeX > MAX_SIZE)
            {
                modifier = (float)MAX_SIZE / (float)destScaledSizeX;
                sourceSizeXToScale = (int)((float)sourceSizeXToScale * (float)modifier);
                sourceSizeYToScale = (int)((float)sourceSizeYToScale * (float)modifier);
                destScaledSizeX = MAX_SIZE;
                destScaledSizeY = (int)((float)destScaledSizeY * (float)modifier);
            }
            // limite de hauteur -> tronquer source
            if (destScaledSizeY > MAX_SIZE)
            {
                modifier = (float)MAX_SIZE / (float)destScaledSizeY;
                sourceSizeXToScale = (int)((float)sourceSizeXToScale * (float)modifier);
                sourceSizeYToScale = (int)((float)sourceSizeYToScale * (float)modifier);
                destScaledSizeX = (int)((float)destScaledSizeX * (float)modifier);
                destScaledSizeY = MAX_SIZE;
            }

            // calcul ratio
            ratioX = ((float)(sourceSizeXToScale - 1)) / (float)destScaledSizeX;
            ratioY = ((float)(sourceSizeYToScale - 1)) / (float)destScaledSizeY;
        }

        // AGRANDISSEMENT AU PLUS PROCHE
        public unsafe static Bitmap scaleNearest(float factorX, float factorY)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            setScaledSize(factorX, factorY);
            int destBytes = destScaledSizeX * destScaledSizeY * _colorLayers;
            byte[] destMatrix = new Byte[destBytes];

            // agrandissement au plus proche
            int coordX, coordY, srcIndex, destIndex = 0;
            float roundX, roundY;
            for (int i = 0; i < destScaledSizeY; i++)
            {
                for (int j = 0; j < destScaledSizeX; j++)
                {
                    // coordonnées proportionnelles
                    coordX = (int)((float)ratioX * (float)j);
                    coordY = (int)((float)ratioY * (float)i);
                    roundX = (ratioX * (float)j) - (float)coordX; // taille d'arrondi
                    roundY = (ratioY * (float)i) - (float)coordY;

                    // récupérer pixel source (le plus proche)
                    if (roundX <= 0.5)
                    {
                        if (roundY <= 0.5)
                            srcIndex = (coordY * _imageWidth + coordX) * _colorLayers;
                        else
                            srcIndex = ((coordY+1) * _imageWidth + coordX) * _colorLayers;
                    }
                    else
                    {
                        if (roundY <= 0.5)
                            srcIndex = (coordY * _imageWidth + coordX+1) * _colorLayers;
                        else
                            srcIndex = ((coordY+1) * _imageWidth + coordX+1) * _colorLayers;
                    }
                    destMatrix[destIndex] = _imageMatrix[srcIndex];
                    destMatrix[destIndex + 1] = _imageMatrix[srcIndex + 1];
                    destMatrix[destIndex + 2] = _imageMatrix[srcIndex + 2];
                    destMatrix[destIndex + 3] = _imageMatrix[srcIndex + 3];

                    destIndex += _colorLayers; // prochain pixel
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(destScaledSizeX, destScaledSizeY);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, destScaledSizeX, destScaledSizeY), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }

        // AGRANDISSEMENT BILINEAIRE
        public unsafe static Bitmap scaleBilinear(float factorX, float factorY)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            setScaledSize(factorX, factorY);
            int destBytes = destScaledSizeX * destScaledSizeY * _colorLayers;
            byte[] destMatrix = new Byte[destBytes];
            int srcStride = _imageWidth * _colorLayers;

            // interpolation bilinéaire
            int srcIndex, destIndex = 0, coordX, coordY, pxA, pxB, pxC, pxD;
            float roundX, roundY, layerValue;
            for (int i = 0; i < destScaledSizeY; i++)
            {
                for (int j = 0; j < destScaledSizeX; j++)
                {
                    // coordonnées proportionnelles
                    coordX = (int)((float)ratioX * (float)j);
                    coordY = (int)((float)ratioY * (float)i);
                    roundX = (ratioX * (float)j) - (float)coordX; // taille d'arrondi
                    roundY = (ratioY * (float)i) - (float)coordY;
                    srcIndex = coordY * _imageWidth + coordX; // coord px

                    // récupérer pixels sources
                    pxA = srcIndex * _colorLayers; // pixel 1 (supérieur gauche = px)
                    pxB = pxA + _colorLayers; // pixel 2 (supérieur droit = px + 1)
                    pxC = pxA + srcStride; // pixel 3 (inférieur gauche = px + largeur)
                    pxD = pxB + srcStride; // pixel 4 (inférieur droit = px + largeur + 1)

                    // interpolation = px1*(1-roundX)*(1-roundY) + px2*roundX*(1-roundY) + px3*(1-roundX)*roundY + px4*roundX*roundY
                    // interpolation bleu
                    layerValue = (float)_imageMatrix[pxA] * (1 - roundX) * (1 - roundY)
                                + (float)_imageMatrix[pxB] * roundX * (1 - roundY)
                                + (float)_imageMatrix[pxC] * (1 - roundX) * roundY
                                + (float)_imageMatrix[pxD] * roundX * roundY;
                    destMatrix[destIndex] = (byte)layerValue;
                    // interpolation vert
                    layerValue = (float)_imageMatrix[pxA + 1] * (1 - roundX) * (1 - roundY)
                                + (float)_imageMatrix[pxB + 1] * roundX * (1 - roundY)
                                + (float)_imageMatrix[pxC + 1] * (1 - roundX) * roundY
                                + (float)_imageMatrix[pxD + 1] * roundX * roundY;
                    destMatrix[destIndex+1] = (byte)layerValue;
                    // interpolation rouge
                    layerValue = (float)_imageMatrix[pxA + 2] * (1 - roundX) * (1 - roundY)
                                + (float)_imageMatrix[pxB + 2] * roundX * (1 - roundY)
                                + (float)_imageMatrix[pxC + 2] * (1 - roundX) * roundY
                                + (float)_imageMatrix[pxD + 2] * roundX * roundY;
                    destMatrix[destIndex+2] = (byte)layerValue;
                    // interpolation alpha (arrondi vers opacité pour compenser erreurs de flottants)
                    layerValue = (float)_imageMatrix[pxA + 3] * (1 - roundX) * (1 - roundY)
                                + (float)_imageMatrix[pxB + 3] * roundX * (1 - roundY)
                                + (float)_imageMatrix[pxC + 3] * (1 - roundX) * roundY
                                + (float)_imageMatrix[pxD + 3] * roundX * roundY;
                    if (layerValue > 254.0f)
                        layerValue = 255.0f;
                    destMatrix[destIndex+3] = (byte)layerValue;

                    destIndex += _colorLayers; // prochain pixel
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(destScaledSizeX, destScaledSizeY);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, destScaledSizeX, destScaledSizeY), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }
    }
}
