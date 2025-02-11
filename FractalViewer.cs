using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Mandelbrot_fractal_2
{
	public partial class FractalDisplay : Form
	{
		private Bitmap bitmap;
		private CancellationTokenSource cts = new CancellationTokenSource();
		//Lockers
		private readonly object bitmapLocker = new object();
		private readonly object workerLocker = new object();

		int width = 800;
		int height = 800;
		int iterations = 1000;
		static int windowSize = 100;
		double windowSizeAsNumber;
		bool firstStartup = true;
		bool isChangeByUser = true;

		int centerX;
		int centerY;

		Graphics graphics;
		Pen pen = new Pen(Color.Green, 1);

		static ComplexNumber center = new ComplexNumber(-1, 0);
		ScreenSection section = new ScreenSection(center, 4);
		ScreenSection previousSection;

		public FractalDisplay()
		{
			InitializeComponent();
			initializeBackgroundWorker();
			graphics = canvasBox.CreateGraphics();
			Console.WriteLine("App launched, starting render...");
		}

		private void initializeBackgroundWorker()
		{
			renderWorker.WorkerSupportsCancellation = true;
			renderWorker.WorkerReportsProgress = true;
			renderWorker.DoWork +=
				(s, e) =>
				{
					Bitmap oldBitmap = bitmap;
					renderProgressBar.Invoke(new MethodInvoker(() => renderProgressBar.Visible = true));
					Stopwatch sw = Stopwatch.StartNew();
					Bitmap newBitmap = Mandelbrot.CreateBitmap(width, height, iterations, section.xLeft, section.xRight, section.yBottom, section.yTop, renderWorker, e);
					sw.Stop();
					elapsedLabel.Invoke(new MethodInvoker(() => elapsedLabel.Text = $"Elapsed Time: {sw.Elapsed.TotalSeconds} seconds"));
					lock (bitmapLocker)
					{
						bitmap = newBitmap;
					}
					windowSizeAsNumber = Mandelbrot.ScreenPosToComplexNumber(width: width,
															height: height,
															xLeft: 0,
															xRight: previousSection.xRight - previousSection.xLeft,
															yBottom: previousSection.yBottom,
															yTop: previousSection.yTop,
															screenX: windowSize,
															screenY: 0).X;
					isChangeByUser = false;
					try
					{
						SpecificWindowSizeInput.Invoke(new MethodInvoker(() => SpecificWindowSizeInput.Value = (decimal)windowSizeAsNumber));
					}
					catch (ArgumentOutOfRangeException) { }
				};
			renderWorker.RunWorkerCompleted += (s, e) =>
			{
				if (e.Cancelled)
				{
					Console.WriteLine("Cancelled");
					return;
				}
				Console.WriteLine("Completed!");
				this.canvasBox.Image?.Dispose();
				this.canvasBox.Image = bitmap;
			};

			renderWorker.ProgressChanged += (s, e) =>
			{
				Console.WriteLine($"{e.ProgressPercentage}%");
				renderProgressBar.Invoke(new MethodInvoker(() => renderProgressBar.Value = e.ProgressPercentage));
			};
		}

		private void updateProgressBar(double progress)
		{
			renderProgressBar.Value = (int)progress * 100;
			renderProgressBar.Update();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			render(graphics);
		}


		private void render(Graphics g)
		{

			previousSection = section;
			renderWorker.CancelAsync();

			while (renderWorker.IsBusy)
			{
				Thread.Sleep(100);
			}

			renderWorker.RunWorkerAsync(g);
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (firstStartup)
			{
				render(e.Graphics);
				firstStartup = false;
			}
			else
			{
				lock (bitmapLocker)
				{
					if (bitmap != null)
					{
						e.Graphics.DrawImage(bitmap, 0, 0);
					}
				}
			}
		}

		private void updateWindow(double windowSizeAsNumber)
		{
			lock (bitmapLocker)
			{
				graphics.DrawImage(bitmap, 0, 0);
			}
			try
			{
				graphics.DrawRectangle(pen, centerX - (windowSize / 2), centerY - (windowSize / 2), windowSize, windowSize);
			}
			catch (OverflowException) { }
			section = new ScreenSection(center, windowSizeAsNumber);
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			centerX = e.X;
			centerY = e.Y;
			center = Mandelbrot.ScreenPosToComplexNumber(width: width,
														 height: height,
														 xLeft: previousSection.xLeft,
														 xRight: previousSection.xRight,
														 yBottom: previousSection.yBottom,
														 yTop: previousSection.yTop,
														 screenX: centerX,
														 screenY: centerY);
			windowSizeAsNumber = Mandelbrot.ScreenPosToComplexNumber(width: width,
																		height: height,
																		xLeft: 0,
																		xRight: previousSection.xRight - previousSection.xLeft,
																		yBottom: previousSection.yBottom,
																		yTop: previousSection.yTop,
																		screenX: windowSize,
																		screenY: 0).X;
			updateWindow(windowSizeAsNumber);

			centerPosLabel.Text = $"CenterX: {centerX}; CenterY: {centerY}";
			centerRealValue.Value = (decimal)center.X;
			centerImaginaryValue.Value = (decimal)center.Y;
		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void ComplexNumberLabel_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			cts?.Cancel();
			cts = new CancellationTokenSource();
			ThreadPool.QueueUserWorkItem(_ => render(graphics));
		}

		private void squareSizeInput_ValueChanged(object sender, EventArgs e)
		{
			if (isChangeByUser)
			{
				windowSize = (int)squareSizeInput.Value;
				windowSizeAsNumber = Mandelbrot.ScreenPosToComplexNumber(width: width,
																height: height,
																xLeft: 0,
																xRight: previousSection.xRight - previousSection.xLeft,
																yBottom: previousSection.yBottom,
																yTop: previousSection.yTop,
																screenX: windowSize,
																screenY: 0).X;
				isChangeByUser = false;
				try
				{
					SpecificWindowSizeInput.Value = (decimal)windowSizeAsNumber;
				}
				catch (ArgumentException) { }
			}
			else
			{
				isChangeByUser = true;
			}
			updateWindow(windowSizeAsNumber);
		}

		private void iterationInput_ValueChanged(object sender, EventArgs e)
		{
			iterations = (int)iterationInput.Value;
		}

		private void resetWindowButton_Click(object sender, EventArgs e)
		{
			section = previousSection;
			lock (bitmapLocker)
			{
				graphics.DrawImage(bitmap, 0, 0);
			}
		}

		private void specificWindowSizeLabel_Click(object sender, EventArgs e)
		{

		}

		private void specificWindowSizeInput_ValueChanged(object sender, EventArgs e)
		{
			if (isChangeByUser)
			{
				windowSize = Mandelbrot.ComplexNumberToScreenPos(width: width,
										 height: height,
										 xLeft: 0,
										 xRight: previousSection.xRight - previousSection.xLeft,
										 yBottom: previousSection.yBottom,
										 yTop: previousSection.yTop,
										 realValue: (double)SpecificWindowSizeInput.Value,
										 imaginaryValue: 0).Item1;
				isChangeByUser = false;
				try
				{
					squareSizeInput.Value = windowSize;
				}
				catch (ArgumentException) { }
				updateWindow((double)SpecificWindowSizeInput.Value);
			}
			else
			{
				isChangeByUser = true;
			}
		}

		private void centerRealValue_ValueChanged(object sender, EventArgs e)
		{
			center.X = (double)centerRealValue.Value;
			centerX = Mandelbrot.ComplexNumberToScreenPos(width: width,
									 height: height,
									 xLeft: previousSection.xLeft,
									 xRight: previousSection.xRight,
									 yBottom: previousSection.yBottom,
									 yTop: previousSection.yTop,
									 realValue: center.X,
									 imaginaryValue: center.Y).Item1;
			centerPosLabel.Text = $"CenterX: {centerX}; CenterY: {centerY}";
			updateWindow(windowSizeAsNumber);
		}

		private void centerImaginaryValue_ValueChanged(object sender, EventArgs e)
		{
			center.Y = (double)centerImaginaryValue.Value;
			centerY = Mandelbrot.ComplexNumberToScreenPos(width: width,
						 height: height,
						 xLeft: previousSection.xLeft,
						 xRight: previousSection.xRight,
						 yBottom: previousSection.yBottom,
						 yTop: previousSection.yTop,
						 realValue: center.X,
						 imaginaryValue: center.Y).Item2;
			centerPosLabel.Text = $"CenterX: {centerX}; CenterY: {centerY}";
			updateWindow(windowSizeAsNumber);
		}

		private void placeWindowButton_Click(object sender, EventArgs e)
		{
			centerRealValue_ValueChanged(new object(), new EventArgs());
		}

		private void loadFromFile(string filePath)
		{
			string fileContent = string.Empty;
			using (StreamReader sr = File.OpenText(filePath))
			{
				string s = string.Empty;
				while ((s = sr.ReadLine()) != null)
				{
					fileContent += s;
				}
			}
			Dictionary<string, object> settings;

			try
			{
				settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileContent);
			}
			catch (JsonException ex)
			{
				saveFileLabel.Text = ex.Message;
				return;
			}

			if (settings.ContainsKey("center_x"))
			{
				center.X = (double)settings["center_x"];
				centerX = Mandelbrot.ComplexNumberToScreenPos(width: width,
										 height: height,
										 xLeft: section.xLeft,
										 xRight: section.xRight,
										 yBottom: section.yBottom,
										 yTop: section.yTop,
										 realValue: center.X,
										 imaginaryValue: center.Y).Item1;
				centerPosLabel.Text = $"CenterX: {centerX}; CenterY: {centerY}";
				updateWindow(windowSizeAsNumber);
			}
			if (settings.ContainsKey("center_y"))
			{
				center.Y = (double)settings["center_y"];
				centerY = Mandelbrot.ComplexNumberToScreenPos(width: width,
							 height: height,
							 xLeft: section.xLeft,
							 xRight: section.xRight,
							 yBottom: section.yBottom,
							 yTop: section.yTop,
							 realValue: center.X,
							 imaginaryValue: center.Y).Item2;
				centerPosLabel.Text = $"CenterX: {centerX}; CenterY: {centerY}";
				updateWindow(windowSizeAsNumber);
			}
			if (settings.ContainsKey("window_size"))
			{
				windowSize = Mandelbrot.ComplexNumberToScreenPos(width: width,
										 height: height,
										 xLeft: 0,
										 xRight: section.xRight - section.xLeft,
										 yBottom: section.yBottom,
										 yTop: section.yTop,
										 realValue: (double)settings["window_size"],
										 imaginaryValue: 0).Item1;
				windowSizeAsNumber = (double)settings["window_size"];
				updateWindow(windowSizeAsNumber);
			}
			if (settings.ContainsKey("iterations"))
			{
				iterations = Convert.ToInt32(settings["iterations"]);
			}
			button1_Click(0, new EventArgs());
			try
			{
				centerRealValue.Value = (decimal)center.X;
				centerImaginaryValue.Value = (decimal)center.Y;
				iterationInput.Value = iterations;
				squareSizeInput.Value = windowSize;
				SpecificWindowSizeInput.Value = (decimal)windowSizeAsNumber;
			}
			catch (ArgumentException) { }
		}

		private void saveToFile(string filePath)
		{
			Dictionary<string, object> settings = new Dictionary<string, object>
			{
				{ "center_x", center.X },
				{ "center_y", center.Y },
				{ "window_size", section.squareLenght },
				{ "iterations", iterations }
			};
			string fileContent = JsonConvert.SerializeObject(settings, Formatting.Indented);
			using (FileStream fs = File.Create(@filePath))
			{
				// Add some text to file
				Byte[] content = new UTF8Encoding(true).GetBytes(fileContent);
				fs.Write(content, 0, content.Length);
			}
		}

		private void loadJsonButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Path.GetFullPath("./save_files");
				openFileDialog.Filter = "json files (*.json)|*.json";
				openFileDialog.RestoreDirectory = false;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					//Get the path of specified file
					string filePath = openFileDialog.FileName;
					loadFromFile(filePath);
				}
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			System.IO.Directory.CreateDirectory("save_files");
			string filename = $"save_files/Mandelbrot {Regex.Replace(DateTime.UtcNow.ToString(), @"/|:", "-")}.json";

			saveToFile(filename);
			saveFileLabel.Text = $"Saved file at {Path.GetFullPath(filename)}";
		}

		private void placeAndRenderButton_Click(object sender, EventArgs e)
		{
			placeWindowButton_Click(sender, e);
			button1_Click(sender, e);
		}
	}
}