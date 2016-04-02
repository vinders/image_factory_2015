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
        // variables manipulation images
        private static byte[] _imageMatrix;    // image mémorisée
        private static int _imageBytes;     // taille de l'image en mémoire
        private static int _colorLayers;   // nombre de couches
        private static int _imageWidth;
        private static int _imageHeight;


        // MÉMORISER BYTES D'IMAGE (ouverture ou inversion)
        public unsafe static void setImageBytes(Bitmap source)
        {
            if (source == null)
            {
                _imageBytes = 0;
                _imageMatrix = null;
                return;
            }

            // récupérer informations image
            Rectangle srcSize = new Rectangle(0, 0, source.Width, source.Height);
            _imageWidth = source.Width;
            _imageHeight = source.Height;
            _colorLayers = 4; // 32 bits

            // convertir bitmap source en matrice
            BitmapData rawSrc = source.LockBits(srcSize, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // 32 bits
            _imageBytes = rawSrc.Width * rawSrc.Height * _colorLayers;
            _imageMatrix = new Byte[_imageBytes];
            System.Runtime.InteropServices.Marshal.Copy(rawSrc.Scan0, _imageMatrix, 0, _imageBytes);
            source.UnlockBits(rawSrc);
        }


        // MODIFIER TAILLE DE CONTENEUR D'IMAGE
        public unsafe static Bitmap resizeCanvas(int destWidth, int destHeight)
        {
            if (_imageMatrix == null)
                return null;
            
            // définir taille de matrice
            int destBytes = destWidth * destHeight * _colorLayers;
            byte[] destMatrix = new byte[destBytes];

            // découpe de l'image
            int srcI = 0, destI = 0;
            int srcStride = _imageWidth * _colorLayers;
            int destStride = destWidth * _colorLayers;
            for (int i = 0; i < destHeight; i++)
            {
                for (int j = 0; j < destStride; j += _colorLayers)
                {
                    srcI = i * srcStride + j; // ligne*taille_mem_ligne + case
                    destI = i * destStride + j; //ligne*taille_ligne*couches + case

                    if (i < _imageHeight && j < srcStride)
                    {
                        destMatrix[destI] = _imageMatrix[srcI];
                        destMatrix[destI + 1] = _imageMatrix[srcI + 1];
                        destMatrix[destI + 2] = _imageMatrix[srcI + 2];
                        destMatrix[destI + 3] = _imageMatrix[srcI + 3];
                    }
                    else
                    {
                        destMatrix[destI] = 60;
                        destMatrix[destI+1] = 60;
                        destMatrix[destI+2] = 60;
                        destMatrix[destI + 3] = 255;
                    }
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(destWidth, destHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, destWidth, destHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }


        // RECADRER CONTENEUR D'IMAGE
        public unsafe static Bitmap setCanvasPosition(Rectangle position)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            int destBytes = (position.Width+1) * (position.Height+1) * _colorLayers;
            byte[] destMatrix = new Byte[destBytes];
            int destStride = (position.Width + 1) * _colorLayers;
           
            // définir partie d'image originale
            int srcStride = _imageWidth * _colorLayers;
            int maxX = position.X + position.Width + 1;
            if (maxX > _imageWidth)
                maxX = _imageWidth;
            maxX *= _colorLayers;
            int maxY = position.Y + position.Height + 1;
            if (maxY > _imageHeight)
                maxY = _imageHeight;

            // copie de partie d'image originale
            int destI = 0, destJ = 0, srcIndex = 0, destIndex = 0;
            for (int i = position.Y; i < maxY; i++)
            {
                destJ = 0;
                for (int j = position.X*_colorLayers; j < maxX; j += _colorLayers)
                {
                    srcIndex = i * srcStride + j; //ligne*taille_ligne*couches + case
                    destIndex = destI*destStride + destJ; //ligne*taille_ligne*couches + case
                    destMatrix[destIndex] = _imageMatrix[srcIndex];
                    destMatrix[destIndex + 1] = _imageMatrix[srcIndex + 1];
                    destMatrix[destIndex + 2] = _imageMatrix[srcIndex + 2];
                    destMatrix[destIndex + 3] = _imageMatrix[srcIndex + 3];
                    destJ += _colorLayers;
                }
                destI++;
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(position.Width+1, position.Height+1);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, position.Width+1, position.Height+1), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }


        // MODIFIER COULEUR DE PALETTE
        public unsafe static Bitmap setPaletteColor(Color origColor, Color newColor, int acceptance)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            byte[] destMatrix = new byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // remplacement de couleur(s)
            int index = 0;
            for (int i = 0; i < _imageHeight; i++)
            {
                for (int j = 0; j < stride; j += _colorLayers)
                {
                    index = i * stride + j; //ligne*taille_ligne*couches + case

                    // couleur cible (ou dans intervalle spécifié) -> remplacer
                    if ((int)_imageMatrix[index + 2] >= (int)origColor.R - acceptance && (int)_imageMatrix[index + 2] <= (int)origColor.R + acceptance
                      && (int)_imageMatrix[index + 1] >= (int)origColor.G - acceptance && (int)_imageMatrix[index + 1] <= (int)origColor.G + acceptance
                      && (int)_imageMatrix[index] >= (int)origColor.B -acceptance && (int)_imageMatrix[index] <= (int)origColor.B + acceptance)
                    {
                        destMatrix[index] = newColor.B;
                        destMatrix[index + 1] = newColor.G;
                        destMatrix[index + 2] = newColor.R;
                    }
                    // couleur non ciblée -> copier
                    else
                    {
                        destMatrix[index] = _imageMatrix[index];
                        destMatrix[index + 1] = _imageMatrix[index + 1];
                        destMatrix[index + 2] = _imageMatrix[index + 2];
                    }
                    destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }


        // MODE NEGATIF
        public unsafe static Bitmap setOppositeColors()
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            byte[] destMatrix = new byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;

            // négatif des couleurs
            int index = 0;
            for (int i = 0; i < _imageHeight; i++)
            {
                for (int j = 0; j < stride; j += _colorLayers)
                {
                    index = i * stride + j; //ligne*taille_ligne*couches + case
                    destMatrix[index] = (byte)(255 - _imageMatrix[index]);
                    destMatrix[index + 1] = (byte)(255 - _imageMatrix[index + 1]);
                    destMatrix[index + 2] = (byte)(255 - _imageMatrix[index + 2]);
                    destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                }
            }

            // convertir matrice en image de destination
            Bitmap dest = new Bitmap(_imageWidth, _imageHeight);
            BitmapData rawDest = dest.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(destMatrix, 0, rawDest.Scan0, destMatrix.Length);
            dest.UnlockBits(rawDest);
            return dest;
        }


        // MODE DE COULEUR OU EXTRACTION DE PLAN COULEUR
        public unsafe static Bitmap extractPlane(Color colorPlane)
        {
            if (_imageMatrix == null)
                return null;

            // définir taille de matrice
            byte[] destMatrix = new byte[_imageBytes];
            int stride = _imageWidth * _colorLayers;
            int index = 0;

            // bleu uniquement
            if(colorPlane == Color.Blue)
            {
                for (int i = 0; i < _imageHeight; i++)
                {
                    for (int j = 0; j < stride; j += _colorLayers)
                    {
                        index = i * stride + j; //ligne*taille_ligne*couches + case
                        destMatrix[index] = _imageMatrix[index];
                        destMatrix[index + 1] = _imageMatrix[index];
                        destMatrix[index + 2] = _imageMatrix[index];
                        destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                    }
                }
            }
            // vert uniquement
            else if(colorPlane == Color.Green)
            {
                for (int i = 0; i < _imageHeight; i++)
                {
                    for (int j = 0; j < stride; j += _colorLayers)
                    {
                        index = i * stride + j; //ligne*taille_ligne*couches + case
                        destMatrix[index] = _imageMatrix[index + 1];
                        destMatrix[index + 1] = _imageMatrix[index + 1];
                        destMatrix[index + 2] = _imageMatrix[index + 1];
                        destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                    }
                }
            }
            // rouge uniquement
            else if (colorPlane == Color.Red)
            {
                for (int i = 0; i < _imageHeight; i++)
                {
                    for (int j = 0; j < stride; j += _colorLayers)
                    {
                        index = i * stride + j; //ligne*taille_ligne*couches + case
                        destMatrix[index] = _imageMatrix[index + 2];
                        destMatrix[index + 1] = _imageMatrix[index + 2];
                        destMatrix[index + 2] = _imageMatrix[index + 2];
                        destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                    }
                }
            }
            // niveaux de gris
            else
            {
                double luminosity = 0.0;
                for (int i = 0; i < _imageHeight; i++)
                {
                    for (int j = 0; j < stride; j += _colorLayers)
                    {
                        index = i * stride + j; //ligne*taille_ligne*couches + case
                        luminosity = (double)_imageMatrix[index] * 0.114 + (double)_imageMatrix[index + 1] * 0.587 + (double)_imageMatrix[index + 2] * 0.299;
                        if (luminosity > 255.0)
                            luminosity = 255.0;
                        destMatrix[index] = (byte)luminosity;
                        destMatrix[index + 1] = (byte)luminosity;
                        destMatrix[index + 2] = (byte)luminosity;
                        destMatrix[index + 3] = _imageMatrix[index + 3]; // alpha inchangé
                    }
                }
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
