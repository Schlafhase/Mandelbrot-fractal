using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_fractal_2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bitmap bitmap = Mandelbrot.CreateBitmap(800, 800, 1000, xLeft: -1.5, xRight: -1.4, yBottom: -0.05, yTop: 0.05);
            TestForm form = new TestForm();
            form.SetBitmap(bitmap);
            Application.Run(form);
        }
    }

    public struct ComplexNumber
    {

        public double X { get; set; }
        public double Y { get; set; }

        public ComplexNumber(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return $"{this.X} + {this.Y}i";
        }
    }
    public class Mandelbrot
    {
        private static int belongsToMandelbrot(ComplexNumber number, int iterations)
        {
            ComplexNumber z = new ComplexNumber(0, 0);
            z = number;
            for (int i = 0; i < iterations; i++)
            {
                //Console.WriteLine(z);
                //z = z^2 + number
                z = new ComplexNumber(
                    x: (z.X * z.X) - (z.Y * z.Y) + number.X,
                    y: 2 * z.X * z.Y + number.Y);
                if ((z.X * z.X) + (z.Y * z.Y) > 4)
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

            //int i = 0;
            //foreach(var t in ts)
            //{
            //    int r = (int)(startColor.R + (endColor.R - startColor.R) * t);
            //    int g = (int)(startColor.G + (endColor.G - startColor.G) * t);
            //    int b = (int)(startColor.B + (endColor.B - startColor.B) * t);
            //    result[i] = Color.FromArgb(r, g, b);
            //    i++;
            //}
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
            Console.WriteLine(j);
            Console.WriteLine(colors.Length);
            Console.WriteLine(ts.Length);
            foreach (Color color in palette)
            {
                Console.WriteLine(color);
            }
            return palette;
        }

        private static Color[] generateColorArray(int iterations)
        {
            Color[] rainbowColors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
            Color[] wikipediaColorPalette = new Color[] { Color.DarkBlue, Color.Aqua, Color.White, Color.Yellow, Color.Orange, Color.OrangeRed, Color.Red, Color.Crimson, Color.DarkBlue, Color.Aqua };
            Color[] colorPalette = linearInterpolationColors(wikipediaColorPalette, 20);
            return colorPalette;
        }

        private readonly static object locker = new object();

        public static Bitmap CreateBitmap(int width, int height, int iterations, double xLeft = -1.7, double xRight = 0.7, double yBottom = -1.2, double yTop = 1.2)
        {
            Random rnd = new Random(0);
            //Color[] colors = Enumerable.Range(0, iterations)
            //    .Select(x => Color.FromArgb(255, rnd.Next(10, 255), rnd.Next(10, 255), rnd.Next(10, 255)))
            //    .Concat(new[] { Color.Black })
            //    .ToArray();
            Color[] colorPalette = generateColorArray(iterations);

            double deltaX = (xRight - xLeft) / width;
            double deltaY = (yTop - yBottom) / height;
            Bitmap bitmap = new Bitmap(width, height);

            Console.WriteLine((width, height));


            for (int x = 0; (x < width); x++)
            {
                Parallel.For(0, height, y =>
                {
                    double mandelbrotX = x * deltaX + xLeft;
                    double mandelbrotY = -y * deltaY + yTop;
                    ComplexNumber c = new ComplexNumber(mandelbrotX, mandelbrotY);
                    int mandelBrotIndex = belongsToMandelbrot(c, iterations);
                    Color color;
                    //if(mandelBrotIndex == 0) { color = Color.White; }
                    if (mandelBrotIndex == iterations) { color = Color.Black; }
                    else
                    {
                        color = colorPalette[mandelBrotIndex % colorPalette.Length];
                    }
                    //Console.WriteLine(belongsToMandelbrot(c, iterations));
                    //Console.WriteLine(color.ToString());
                    lock (locker)
                    {
                        bitmap.SetPixel(x, y, color);
                    }
                });
                //for (int y = 0; y < height; y++)
                //{
                //    double mandelbrotX = x*deltaX + xLeft;
                //    double mandelbrotY = -y*deltaY + yTop;
                //    ComplexNumber c = new ComplexNumber(mandelbrotX, mandelbrotY);
                //    Color color = colors[belongsToMandelbrot(c, iterations)];
                //    //Console.WriteLine(belongsToMandelbrot(c, iterations));
                //    //Console.WriteLine(color.ToString());
                //    bitmap.SetPixel(x, y, color);
                //}

                if (x % 50 == 0)
                {
                    Console.WriteLine(x);
                }
            }
            return bitmap;
        }
    }
}