using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.Drawing.Imaging;

namespace TextureAnalyst
{
    public partial class SharpGLControl : UserControl
    {
        bool _busy = false;
        float[,] _vertices;
        float[,] _colors;

        public SharpGLControl()
        {
            _busy = true;
            _vertices = new float[6*256*256,3];
            _colors = new float[6*256*256,3];
            InitializeComponent();
            for (int i = 0; i < 255; i += 2)
            {
                for (int j = 0; j < 255; j += 2)
                {
                    _colors[0, 0] = 0.0f;
                    _vertices[0, 0] = 0.0f;
                }
            }
            _busy = false;
        }

        // RECEPTION DES DONNEES (conversion valeurs en vertex et couleurs)
        public void drawItem(double[,] normalizedMatrix)
        {
            // convertir matrice en triangles
            float[,] vertices = new float[6*256*256, 3];
            float[,] colors = new float[6*256*256, 3];
            float factor = 32.0f; // division des coordonnées (0-255 -> 0-8)
            float offset = 4.0f;  // décalage moitié
            int v = 0;            // compteur de vertex
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    // quadrilatères
                    // i,j     i,j+1
                    // i+1,j   i+1,j+1
                    // = 2 triangles (sens anti-horloger)
                    // (i,j ; i+1,j ; i,j+1)
                    // (i+1,j ; i+1,j+1 ; i,j+1)
                    // hauteur = valeur

                    // positions vertex
                    vertices[v, 0] = -offset + (float)i / factor;       // i,j -> T1(A)
                    vertices[v, 1] = -offset + (float)j / factor;
                    vertices[v, 2] = 2.0f*(float)normalizedMatrix[i, j];
                    vertices[v + 1, 0] = vertices[v + 3, 0] = -offset + (float)(i + 1) / factor;  // i+1,j -> T1(B) et T2(A)
                    vertices[v + 1, 1] = vertices[v + 3, 1] = -offset + (float)j / factor;
                    vertices[v + 1, 2] = vertices[v + 3, 2] = 2.0f*(float)normalizedMatrix[i + 1, j];
                    vertices[v + 2, 0] = vertices[v + 5, 0] = -offset + (float)i / factor;        // i,j+1 -> T1(C) et T2(C)
                    vertices[v + 2, 1] = vertices[v + 5, 1] = -offset + (float)(j + 1) / factor;
                    vertices[v + 2, 2] = vertices[v + 5, 2] = 2.0f*(float)normalizedMatrix[i, j + 1];
                    vertices[v + 4, 0] = -offset + (float)(i + 1) / factor;   // i+1,j+1 -> T2(B)
                    vertices[v + 4, 1] = -offset + (float)(j + 1) / factor;
                    vertices[v + 4, 2] = 2.0f*(float)normalizedMatrix[i + 1, j + 1];

                    // couleurs
                    // rouge = pics (avec rehaussement global, extrêmes tronqués)
                    colors[v, 0] = Math.Min(1.0f, 8.0f * (float)normalizedMatrix[i, j]);
                    colors[v + 1, 0] = colors[v + 3, 0] = Math.Min(1.0f, 8.0f * (float)normalizedMatrix[i + 1, j]);
                    colors[v + 2, 0] = colors[v + 5, 0] = Math.Min(1.0f, 8.0f * (float)normalizedMatrix[i, j + 1]);
                    colors[v + 4, 0] = Math.Min(1.0f, 8.0f * (float)normalizedMatrix[i + 1, j + 1]);
                    // vert = fond (exclusion des pics non rehaussés)
                    colors[v, 1] = (1.0f - (float)normalizedMatrix[i, j]) / 4.0f;
                    colors[v + 1, 1] = colors[v + 3, 1] = (1.0f - (float)normalizedMatrix[i + 1, j]) / 4.0f;
                    colors[v + 2, 1] = colors[v + 5, 1] = (1.0f - (float)normalizedMatrix[i, j + 1]) / 4.0f;
                    colors[v + 4, 1] = (1.0f - (float)normalizedMatrix[i + 1, j + 1]) / 4.0f;
                    // bleu = fond + pics (sans rehaussement, extrêmes tronqués)
                    colors[v, 2] = Math.Min(1.0f, 0.1f + (float)normalizedMatrix[i, j]);
                    colors[v + 1, 2] = Math.Min(1.0f, 0.1f + (float)normalizedMatrix[i + 1, j]);
                    colors[v + 2, 2] = Math.Min(1.0f, 0.1f + (float)normalizedMatrix[i, j + 1]);
                    colors[v + 4, 2] = Math.Min(1.0f, 0.1f + (float)normalizedMatrix[i + 1, j + 1]);
                    // lignes régulières
                    if (i % 4 == 0 || j % 4 == 0)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            colors[v + k, 0] /= 1.2f; // division pics rehaussés (légère)
                            colors[v + k, 1] /= 1.5f; // division fond
                            colors[v + k, 2] /= 1.6f; // division fond/pics
                        }
                    }

                    v += 6; // 2 triangles = 6 vertex (pour 4 coordonnées)
                }
            }

            // mise à jour des tableaux de vertex/couleurs
            while (_busy);
            _busy = true;
            _vertices = vertices;
            _colors = colors;
            _busy = false;
        }
        
        // DESSIN OPENGL (sharpGL) -> afficher triangles
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            if (_busy)
                return;

            // charger objet openGL
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            // afficher matrice de co-occurrence
            gl.Translate(1.0f, 1.0f, 1.0f);     // positionnement
            gl.Rotate(-90.0f, 0.0f, 1.0f, 0.0f);
            gl.Rotate(20.0f, 0.5f, 0.0f, 0.5f);
            gl.Begin(OpenGL.GL_TRIANGLES);
            int size = 6*256*256;               // affichage
            for (int i = 0; i < size; i++)
            {
                gl.Color(_colors[i, 0], _colors[i, 1], _colors[i, 2]);
                gl.Vertex(_vertices[i, 0], _vertices[i, 2], _vertices[i, 1]);
            }
            gl.End();
        }
        
        // LANCEMENT OPENGL (sharpGL)
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(0, 0, 0, 0); // fond noir
        }

        // CONFIGURATION SELON DIMENSIONS
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // obtention controle openGL
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            // perspective
            gl.Perspective(64.0f, (double)Width / (double)Height, 0.01, 100.0);

            // direction caméra
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            // mode d'affichage de matrice
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
