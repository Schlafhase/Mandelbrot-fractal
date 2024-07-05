using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_fractal_2
{
    public static class Mandelbrot
    {
        private static int belongsToMandelbrot(ComplexNumber number, int iterations)
        {
            double x = 0;
            double y = 0;
            double x2 = 0;
            double y2 = 0;
            for (int i = 0; i < iterations; i++)
            {
                y = (x + x) * y + number.Y;
                x = x2 - y2 + number.X;
                x2 = x * x;
                y2 = y * y;
                if (x2 + y2 >= 4)
                {
                    return i;
                }
            }
            return iterations;
        }

        private static Color[] linearInterpolationColors(Color[] colors, int paletteLength)
        {
            if (colors.Length < 2)
            {
                throw new ArgumentException("colors must contain at least 2 colors.");
            }

            double[] ts = Enumerable.Range(0, paletteLength / (colors.Length - 1))
                .Select(x => (double)x / ((double)paletteLength / (colors.Length - 1)))
                .ToArray();

            Color[] palette = new Color[paletteLength];
            Color startColor = colors[0];

            int j = 0;
            Color lastColor = new Color();
            foreach (Color endColor in colors.Skip(1))
            {
                for (int i = 0; i < ts.Length; i++)
                {
                    var t = ts[i];
                    int r = (int)(startColor.R + (endColor.R - startColor.R) * t);
                    int g = (int)(startColor.G + (endColor.G - startColor.G) * t);
                    int b = (int)(startColor.B + (endColor.B - startColor.B) * t);
                    lastColor = Color.FromArgb(r, g, b);
                    palette[j] = lastColor;
                    j++;
                }
                startColor = endColor;
            }
            for (int i = j; i < paletteLength; i++)
            {
                palette[i] = lastColor;
            }
            return palette;
        }

        private static Color[] generateColorArray(int iterations)
        {
            Color[] rainbowColors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
            Color[] wikipediaColorPalette = new Color[] { Color.DarkBlue, Color.Aqua, Color.White, Color.Yellow, Color.Orange, Color.OrangeRed, Color.Red, Color.Crimson, Color.DarkBlue, Color.Aqua };
            Color[] colorPalette = linearInterpolationColors(wikipediaColorPalette, 1000);
            return colorPalette;
        }

        private readonly static object locker = new object();
        private readonly static object progressBarLocker = new object();

        public static ComplexNumber ScreenPosToComplexNumber(int width, int height, double xLeft, double xRight, double yBottom, double yTop, int screenX, int screenY)
        {
            double deltaX = (xRight - xLeft) / width;
            double deltaY = (yTop - yBottom) / height;

            double realValue = screenX * deltaX + xLeft;
            double imaginaryValue = -screenY * deltaY + yTop;

            ComplexNumber result = new ComplexNumber(realValue, imaginaryValue);

            return result;
        }

        public static (int, int) ComplexNumberToScreenPos(int width, int height, double xLeft, double xRight, double yBottom, double yTop, double realValue, double imaginaryValue)
        {
            double deltaX = width / (xRight - xLeft);
            double deltaY = (height / (yBottom - yTop));

            double offsetX = -(deltaX * xLeft);
            double offsetY = -(deltaY * yTop);

            int x = (int)(realValue * deltaX + offsetX);
            int y = (int)(imaginaryValue * deltaY + offsetY);
            return (x, y);
        }

        public static Bitmap CreateBitmap(int width, int height, int iterations, double xLeft, double xRight, double yBottom, double yTop,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            Random rnd = new Random(0);
            Color[] colorPalette = generateColorArray(iterations);

            double deltaX = (xRight - xLeft) / width;
            double deltaY = (yTop - yBottom) / height;
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var rect = new Rectangle(0, 0, width, height);
            var lockedBits = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            double progress = 0;

            byte[] data = new byte[width * height * 3];

            for (int y = 0; (y < height); y++)
            {
                Parallel.For(0, width, x =>
                {
                    double mandelbrotX = x * deltaX + xLeft;
                    double mandelbrotY = -y * deltaY + yTop;
                    ComplexNumber c = new ComplexNumber(mandelbrotX, mandelbrotY);
                    int mandelBrotIndex = belongsToMandelbrot(c, iterations);
                    Color color;
                    if (mandelBrotIndex == iterations) { color = Color.Black; }
                    else
                    {
                        color = colorPalette[mandelBrotIndex % colorPalette.Length];
                    }
                    var position = 3 * (y * width + x);
                    data[position] = color.B;
                    data[position + 1] = color.G;
                    data[position + 2] = color.R;
                });

                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (y % 100 == 0)
                {
                    progress = ((double)y) / (height - 1);
                    worker.ReportProgress((int)(progress * 100));
                }

            }

            Marshal.Copy(data, 0, lockedBits.Scan0, data.Length);
            bitmap.UnlockBits(lockedBits);

            worker.ReportProgress(100);
            return bitmap;
        }
    }
}