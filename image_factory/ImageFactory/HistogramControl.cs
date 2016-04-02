using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class HistogramControl : UserControl
    {
        private long[] points = null;
        private int limitNb = 0;
        private int[] limits = null;
        private long maxNumber = 0;

        public HistogramControl()
        {
            InitializeComponent();
        }

        private void HistogramControl_Paint(object sender, PaintEventArgs e)
        {
            // échelles repères
            Graphics graphics = e.Graphics;
            Pen drawPen;
            int offsetX = 49, offsetY = 5;
            drawPen = new Pen(new SolidBrush(Color.DarkGray), 1);
            graphics.DrawRectangle(drawPen, offsetX - 2, offsetY, 1, this.Height - 26);
            graphics.DrawRectangle(drawPen, offsetX - 2, this.Height - 22, this.Width - 55, 1);
            SolidBrush background = new SolidBrush(Color.WhiteSmoke);
            graphics.FillRectangle(background, offsetX, 5, this.Width - 56, (this.Height - 27) / 2);
            graphics.FillRectangle(background, offsetX, 6 + (this.Height - 27) / 2, this.Width - 56, (this.Height - 28) / 2);

            // histogramme
            if (points != null)
            {
                // configuration des tailles
                int width = this.Width - 56, height = this.Height - 28;
                double unitX = (double)width / 256.0;
                double unitY = (double)height / maxNumber;
                double drawX;

                // limites / seuils
                if (limits != null)
                {
                    drawPen = new Pen(new SolidBrush(Color.Silver), 1);
                    for (int j = 0; j < limitNb; j++)
                    {
                        drawX = offsetX + (limits[j] * unitX);
                        graphics.DrawLine(drawPen, new PointF((float)drawX, height + offsetY - 1),
                                                   new PointF((float)drawX, offsetY));
                    }
                }
                // dessin ligne par ligne
                drawPen = new Pen(new SolidBrush(Color.Black), (float)unitX);
                for (int i = 0; i < 256; i++)
                {
                    drawX = offsetX + (i * unitX);
                    graphics.DrawLine(drawPen, new PointF((float)drawX, height + offsetY),
                                               new PointF((float)drawX, (float)((double)(height + offsetY) - points[i] * unitY)));
                }
            }
        }

        public void setLimits(int nb, int[] newLimits)
        {
            limits = newLimits;
            limitNb = nb;
            this.Refresh();
        }

        public void setHistogram(long[] newPoints)
        {
            points = null;
            if (newPoints != null)
            {
                maxNumber = 0;
                for (int i = 0; i < 256; i++)
                    if (newPoints[i] > maxNumber)
                        maxNumber = newPoints[i];
            }
            lblHistoYMax.Text = maxNumber.ToString();
            points = newPoints;
            this.Refresh();
        }
    }
}
