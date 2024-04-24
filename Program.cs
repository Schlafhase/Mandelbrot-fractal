using System;
using System.Collections.Generic;
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
            FractalDisplay form = new FractalDisplay();
            Application.Run(form);
        }
    }
}