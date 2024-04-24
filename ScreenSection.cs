namespace Mandelbrot_fractal_2
{
    public struct ScreenSection
    {
        public double centerX { get; set; }
        public double centerY { get; set; }
        public double xLeft { get; }
        public double xRight { get; }
        public double yBottom { get; }
        public double yTop { get; }
        public double squareLenght;

        public ScreenSection(ComplexNumber center, double squareLength)
        {
            this.centerX = center.X;
            this.centerY = center.Y;

            this.xLeft = center.X - squareLength/2;
            this.xRight = center.X + squareLength/2;
            this.yBottom = center.Y - squareLength/2;
            this.yTop = center.Y + squareLength/2;

            this.squareLenght = squareLength;
        }
    }
}