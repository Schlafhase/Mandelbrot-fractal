using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot_fractal_2
{
    partial class FractalDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvasBox = new System.Windows.Forms.PictureBox();
            this.centerPosLabel = new System.Windows.Forms.Label();
            this.ComplexNumberLabel = new System.Windows.Forms.Label();
            this.renderButton = new System.Windows.Forms.Button();
            this.squareSizeInput = new System.Windows.Forms.NumericUpDown();
            this.iterationInput = new System.Windows.Forms.NumericUpDown();
            this.windowSizeLabel = new System.Windows.Forms.Label();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.renderProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squareSizeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationInput)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasBox
            // 
            this.canvasBox.Location = new System.Drawing.Point(0, 0);
            this.canvasBox.Name = "canvasBox";
            this.canvasBox.Size = new System.Drawing.Size(800, 800);
            this.canvasBox.TabIndex = 0;
            this.canvasBox.TabStop = false;
            this.canvasBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.canvasBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.canvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // centerPosLabel
            // 
            this.centerPosLabel.AutoSize = true;
            this.centerPosLabel.Location = new System.Drawing.Point(839, 41);
            this.centerPosLabel.Name = "centerPosLabel";
            this.centerPosLabel.Size = new System.Drawing.Size(107, 13);
            this.centerPosLabel.TabIndex = 1;
            this.centerPosLabel.Text = "CenterX: -; CenterY: -";
            this.centerPosLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ComplexNumberLabel
            // 
            this.ComplexNumberLabel.AutoSize = true;
            this.ComplexNumberLabel.Location = new System.Drawing.Point(842, 71);
            this.ComplexNumberLabel.Name = "ComplexNumberLabel";
            this.ComplexNumberLabel.Size = new System.Drawing.Size(96, 13);
            this.ComplexNumberLabel.TabIndex = 2;
            this.ComplexNumberLabel.Text = "Complex Number: -";
            this.ComplexNumberLabel.Click += new System.EventHandler(this.ComplexNumberLabel_Click);
            // 
            // renderButton
            // 
            this.renderButton.Location = new System.Drawing.Point(842, 164);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(75, 23);
            this.renderButton.TabIndex = 3;
            this.renderButton.Text = "Render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // squareSizeInput
            // 
            this.squareSizeInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.squareSizeInput.Location = new System.Drawing.Point(921, 102);
            this.squareSizeInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.squareSizeInput.Name = "squareSizeInput";
            this.squareSizeInput.Size = new System.Drawing.Size(143, 20);
            this.squareSizeInput.TabIndex = 5;
            this.squareSizeInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.squareSizeInput.ValueChanged += new System.EventHandler(this.squareSizeInput_ValueChanged);
            // 
            // iterationInput
            // 
            this.iterationInput.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.iterationInput.Location = new System.Drawing.Point(921, 128);
            this.iterationInput.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.iterationInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.iterationInput.Name = "iterationInput";
            this.iterationInput.Size = new System.Drawing.Size(143, 20);
            this.iterationInput.TabIndex = 6;
            this.iterationInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iterationInput.ValueChanged += new System.EventHandler(this.iterationInput_ValueChanged);
            // 
            // windowSizeLabel
            // 
            this.windowSizeLabel.AutoSize = true;
            this.windowSizeLabel.Location = new System.Drawing.Point(842, 109);
            this.windowSizeLabel.Name = "windowSizeLabel";
            this.windowSizeLabel.Size = new System.Drawing.Size(72, 13);
            this.windowSizeLabel.TabIndex = 7;
            this.windowSizeLabel.Text = "Window Size:";
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(842, 135);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(53, 13);
            this.iterationsLabel.TabIndex = 8;
            this.iterationsLabel.Text = "Iterations:";
            // 
            // renderProgressBar
            // 
            this.renderProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.renderProgressBar.Location = new System.Drawing.Point(924, 163);
            this.renderProgressBar.MarqueeAnimationSpeed = 0;
            this.renderProgressBar.Name = "renderProgressBar";
            this.renderProgressBar.Size = new System.Drawing.Size(140, 23);
            this.renderProgressBar.TabIndex = 9;
            // 
            // FractalDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 800);
            this.Controls.Add(this.renderProgressBar);
            this.Controls.Add(this.iterationsLabel);
            this.Controls.Add(this.windowSizeLabel);
            this.Controls.Add(this.iterationInput);
            this.Controls.Add(this.squareSizeInput);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.ComplexNumberLabel);
            this.Controls.Add(this.centerPosLabel);
            this.Controls.Add(this.canvasBox);
            this.MaximumSize = new System.Drawing.Size(1500, 839);
            this.MinimumSize = new System.Drawing.Size(1500, 839);
            this.Name = "FractalDisplay";
            this.Text = "Mandelbrot viewer";
            ((System.ComponentModel.ISupportInitialize)(this.canvasBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squareSizeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.PictureBox canvasBox;
        private Label centerPosLabel;
        private Label ComplexNumberLabel;
        private Button renderButton;
        private NumericUpDown squareSizeInput;
        private NumericUpDown iterationInput;
        private Label windowSizeLabel;
        private Label iterationsLabel;
        private ProgressBar renderProgressBar;
    }
}