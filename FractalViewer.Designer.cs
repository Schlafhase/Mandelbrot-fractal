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
			this.resetWindowButton = new System.Windows.Forms.Button();
			this.specificWindowSizeLabel = new System.Windows.Forms.Label();
			this.SpecificWindowSizeInput = new System.Windows.Forms.NumericUpDown();
			this.centerRealValue = new System.Windows.Forms.NumericUpDown();
			this.centerImaginaryValue = new System.Windows.Forms.NumericUpDown();
			this.plusLabel = new System.Windows.Forms.Label();
			this.iLabel = new System.Windows.Forms.Label();
			this.renderWorker = new System.ComponentModel.BackgroundWorker();
			this.elapsedLabel = new System.Windows.Forms.Label();
			this.placeWindowButton = new System.Windows.Forms.Button();
			this.loadJsonButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveFileLabel = new System.Windows.Forms.Label();
			this.placeAndRenderButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.canvasBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.squareSizeInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iterationInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpecificWindowSizeInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.centerRealValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.centerImaginaryValue)).BeginInit();
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
			this.canvasBox.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
			this.canvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// centerPosLabel
			// 
			this.centerPosLabel.AutoSize = true;
			this.centerPosLabel.Location = new System.Drawing.Point(843, 68);
			this.centerPosLabel.Name = "centerPosLabel";
			this.centerPosLabel.Size = new System.Drawing.Size(107, 13);
			this.centerPosLabel.TabIndex = 1;
			this.centerPosLabel.Text = "CenterX: -; CenterY: -";
			this.centerPosLabel.Click += new System.EventHandler(this.label1_Click_1);
			// 
			// ComplexNumberLabel
			// 
			this.ComplexNumberLabel.AutoSize = true;
			this.ComplexNumberLabel.Location = new System.Drawing.Point(843, 96);
			this.ComplexNumberLabel.Name = "ComplexNumberLabel";
			this.ComplexNumberLabel.Size = new System.Drawing.Size(96, 13);
			this.ComplexNumberLabel.TabIndex = 2;
			this.ComplexNumberLabel.Text = "Complex Number: -";
			this.ComplexNumberLabel.Click += new System.EventHandler(this.ComplexNumberLabel_Click);
			// 
			// renderButton
			// 
			this.renderButton.Location = new System.Drawing.Point(842, 183);
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
			this.squareSizeInput.Location = new System.Drawing.Point(921, 121);
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
			this.iterationInput.Location = new System.Drawing.Point(921, 147);
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
			this.windowSizeLabel.Location = new System.Drawing.Point(843, 123);
			this.windowSizeLabel.Name = "windowSizeLabel";
			this.windowSizeLabel.Size = new System.Drawing.Size(72, 13);
			this.windowSizeLabel.TabIndex = 7;
			this.windowSizeLabel.Text = "Window Size:";
			// 
			// iterationsLabel
			// 
			this.iterationsLabel.AutoSize = true;
			this.iterationsLabel.Location = new System.Drawing.Point(843, 149);
			this.iterationsLabel.Name = "iterationsLabel";
			this.iterationsLabel.Size = new System.Drawing.Size(53, 13);
			this.iterationsLabel.TabIndex = 8;
			this.iterationsLabel.Text = "Iterations:";
			// 
			// renderProgressBar
			// 
			this.renderProgressBar.ForeColor = System.Drawing.Color.Lime;
			this.renderProgressBar.Location = new System.Drawing.Point(924, 182);
			this.renderProgressBar.Name = "renderProgressBar";
			this.renderProgressBar.Size = new System.Drawing.Size(140, 23);
			this.renderProgressBar.Step = 1;
			this.renderProgressBar.TabIndex = 9;
			// 
			// resetWindowButton
			// 
			this.resetWindowButton.Location = new System.Drawing.Point(842, 212);
			this.resetWindowButton.Name = "resetWindowButton";
			this.resetWindowButton.Size = new System.Drawing.Size(222, 23);
			this.resetWindowButton.TabIndex = 10;
			this.resetWindowButton.Text = "Reset Window";
			this.resetWindowButton.UseVisualStyleBackColor = true;
			this.resetWindowButton.Click += new System.EventHandler(this.resetWindowButton_Click);
			// 
			// specificWindowSizeLabel
			// 
			this.specificWindowSizeLabel.AutoSize = true;
			this.specificWindowSizeLabel.Location = new System.Drawing.Point(1070, 123);
			this.specificWindowSizeLabel.Name = "specificWindowSizeLabel";
			this.specificWindowSizeLabel.Size = new System.Drawing.Size(59, 13);
			this.specificWindowSizeLabel.TabIndex = 12;
			this.specificWindowSizeLabel.Text = "as number:";
			this.specificWindowSizeLabel.Click += new System.EventHandler(this.specificWindowSizeLabel_Click);
			// 
			// SpecificWindowSizeInput
			// 
			this.SpecificWindowSizeInput.DecimalPlaces = 15;
			this.SpecificWindowSizeInput.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.SpecificWindowSizeInput.Location = new System.Drawing.Point(1135, 121);
			this.SpecificWindowSizeInput.Name = "SpecificWindowSizeInput";
			this.SpecificWindowSizeInput.Size = new System.Drawing.Size(120, 20);
			this.SpecificWindowSizeInput.TabIndex = 13;
			this.SpecificWindowSizeInput.ValueChanged += new System.EventHandler(this.specificWindowSizeInput_ValueChanged);
			// 
			// centerRealValue
			// 
			this.centerRealValue.DecimalPlaces = 15;
			this.centerRealValue.Location = new System.Drawing.Point(944, 94);
			this.centerRealValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.centerRealValue.Name = "centerRealValue";
			this.centerRealValue.Size = new System.Drawing.Size(120, 20);
			this.centerRealValue.TabIndex = 14;
			this.centerRealValue.ValueChanged += new System.EventHandler(this.centerRealValue_ValueChanged);
			// 
			// centerImaginaryValue
			// 
			this.centerImaginaryValue.DecimalPlaces = 15;
			this.centerImaginaryValue.Location = new System.Drawing.Point(1086, 94);
			this.centerImaginaryValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.centerImaginaryValue.Name = "centerImaginaryValue";
			this.centerImaginaryValue.Size = new System.Drawing.Size(120, 20);
			this.centerImaginaryValue.TabIndex = 15;
			this.centerImaginaryValue.ValueChanged += new System.EventHandler(this.centerImaginaryValue_ValueChanged);
			// 
			// plusLabel
			// 
			this.plusLabel.AutoSize = true;
			this.plusLabel.Location = new System.Drawing.Point(1071, 96);
			this.plusLabel.Name = "plusLabel";
			this.plusLabel.Size = new System.Drawing.Size(13, 13);
			this.plusLabel.TabIndex = 16;
			this.plusLabel.Text = "+";
			// 
			// iLabel
			// 
			this.iLabel.AutoSize = true;
			this.iLabel.Location = new System.Drawing.Point(1212, 96);
			this.iLabel.Name = "iLabel";
			this.iLabel.Size = new System.Drawing.Size(9, 13);
			this.iLabel.TabIndex = 17;
			this.iLabel.Text = "i";
			// 
			// elapsedLabel
			// 
			this.elapsedLabel.AutoSize = true;
			this.elapsedLabel.Location = new System.Drawing.Point(1071, 188);
			this.elapsedLabel.Name = "elapsedLabel";
			this.elapsedLabel.Size = new System.Drawing.Size(80, 13);
			this.elapsedLabel.TabIndex = 18;
			this.elapsedLabel.Text = "Elapsed Time: -";
			// 
			// placeWindowButton
			// 
			this.placeWindowButton.Location = new System.Drawing.Point(1227, 91);
			this.placeWindowButton.Name = "placeWindowButton";
			this.placeWindowButton.Size = new System.Drawing.Size(106, 23);
			this.placeWindowButton.TabIndex = 19;
			this.placeWindowButton.Text = "Place Window";
			this.placeWindowButton.UseVisualStyleBackColor = true;
			this.placeWindowButton.Click += new System.EventHandler(this.placeWindowButton_Click);
			// 
			// loadJsonButton
			// 
			this.loadJsonButton.Location = new System.Drawing.Point(842, 739);
			this.loadJsonButton.Name = "loadJsonButton";
			this.loadJsonButton.Size = new System.Drawing.Size(75, 23);
			this.loadJsonButton.TabIndex = 20;
			this.loadJsonButton.Text = "Load json";
			this.loadJsonButton.UseVisualStyleBackColor = true;
			this.loadJsonButton.Click += new System.EventHandler(this.loadJsonButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(924, 739);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(102, 23);
			this.saveButton.TabIndex = 21;
			this.saveButton.Text = "Save as Json";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveFileLabel
			// 
			this.saveFileLabel.AutoSize = true;
			this.saveFileLabel.Location = new System.Drawing.Point(1032, 744);
			this.saveFileLabel.Name = "saveFileLabel";
			this.saveFileLabel.Size = new System.Drawing.Size(0, 13);
			this.saveFileLabel.TabIndex = 22;
			// 
			// placeAndRenderButton
			// 
			this.placeAndRenderButton.Location = new System.Drawing.Point(1339, 91);
			this.placeAndRenderButton.Name = "placeAndRenderButton";
			this.placeAndRenderButton.Size = new System.Drawing.Size(108, 23);
			this.placeAndRenderButton.TabIndex = 23;
			this.placeAndRenderButton.Text = "Place and Render";
			this.placeAndRenderButton.UseVisualStyleBackColor = true;
			this.placeAndRenderButton.Click += new System.EventHandler(this.placeAndRenderButton_Click);
			// 
			// FractalDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1484, 800);
			this.Controls.Add(this.placeAndRenderButton);
			this.Controls.Add(this.saveFileLabel);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.loadJsonButton);
			this.Controls.Add(this.placeWindowButton);
			this.Controls.Add(this.elapsedLabel);
			this.Controls.Add(this.iLabel);
			this.Controls.Add(this.plusLabel);
			this.Controls.Add(this.centerImaginaryValue);
			this.Controls.Add(this.centerRealValue);
			this.Controls.Add(this.SpecificWindowSizeInput);
			this.Controls.Add(this.specificWindowSizeLabel);
			this.Controls.Add(this.resetWindowButton);
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
			((System.ComponentModel.ISupportInitialize)(this.SpecificWindowSizeInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.centerRealValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.centerImaginaryValue)).EndInit();
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
        private Button resetWindowButton;
        private Label specificWindowSizeLabel;
        private NumericUpDown SpecificWindowSizeInput;
        private NumericUpDown centerRealValue;
        private NumericUpDown centerImaginaryValue;
        private Label plusLabel;
        private Label iLabel;
        private System.ComponentModel.BackgroundWorker renderWorker;
        private Label elapsedLabel;
        private Button placeWindowButton;
		private Button loadJsonButton;
		private Button saveButton;
		private Label saveFileLabel;
		private Button placeAndRenderButton;
	}
}