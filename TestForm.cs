using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_fractal_2
{
    public partial class FractalDisplay : Form
    {
        private Bitmap bitmap;

        int width = 800;
        int height = 800;
        int iterations = 1000;
        static int windowSize = 100;

        int centerX;
        int centerY;

        Graphics graphics;
        Pen pen = new Pen(Color.Green, 1);

        static ComplexNumber center = new ComplexNumber(-1, 0);
        ScreenSection section = new ScreenSection(center, windowSize);
        ScreenSection sectionPreview;

        public FractalDisplay()
        {
            InitializeComponent();
            graphics = canvasBox.CreateGraphics();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void SetBitmap(Bitmap bmp)
        {
            this.bitmap = bmp;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            bitmap = Mandelbrot.CreateBitmap(width, height, iterations, section.xLeft, section.xRight, section.yBottom, section.yTop, renderProgressBar);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            centerX = e.X;
            centerY = e.Y;
            center = Mandelbrot.ScreenPosToComplexNumber(width: width, height: height, xLeft: section.xLeft, xRight: section.xRight, yBottom: section.yBottom, yTop: section.yTop, screenX: centerX, screenY: centerY);
            //sectionPreview = new ScreenSection(center, squareSize);
            graphics.DrawImage(bitmap, 0, 0);
            graphics.DrawRectangle(pen, centerX-(windowSize/2), centerY-(windowSize/2), windowSize, windowSize);

            centerPosLabel.Text = $"CenterX: {center.X}; CenterY: {center.Y}";
            ComplexNumberLabel.Text = $"Complex Number: {center}";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ComplexNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            section = new ScreenSection(center, Mandelbrot.ScreenPosToComplexNumber(width: width, height: height, xLeft: 0, xRight: section.xRight-section.xLeft, yBottom: section.yBottom, yTop: section.yTop, screenX: windowSize, screenY: 0).X);
            bitmap = Mandelbrot.CreateBitmap(width, height, iterations, section.xLeft, section.xRight, section.yBottom, section.yTop, renderProgressBar);
            graphics.DrawImage(bitmap, 0, 0);
        }

        private void squareSizeInput_ValueChanged(object sender, EventArgs e)
        {
            windowSize = (int)squareSizeInput.Value;
            graphics.DrawImage(bitmap, 0, 0);
            graphics.DrawRectangle(pen, centerX - (windowSize / 2), centerY - (windowSize / 2), windowSize, windowSize);
        }

        private void iterationInput_ValueChanged(object sender, EventArgs e)
        {
            iterations = (int)iterationInput.Value;
        }
    }
}