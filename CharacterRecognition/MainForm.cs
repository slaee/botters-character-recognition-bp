using CharacterRecognitionBP.Common;
using CharacterRecognitionBP.Core.Interfaces;
using CharacterRecognitionBP.Interfaces;
using CharacterRecognitionBP.Utils;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CharacterRecognition
{
    public partial class MainForm : Form
    {
        private readonly IWaiter Waiter;

        private int _x = -1;
        private int _y = -1;
        private bool mouseMove = false;

        private Pen _pen;
        private Bitmap _bmp;
        private Graphics _canvas;
        private Graphics _drawingArea;

        private NeuralNet NN;

        public MainForm(IWaiter waiter)
        {
            InitializeComponent();
            Waiter = waiter;
            NN = new NeuralNet(input: 1024, hidden: 60, output: 5, lrpOut: 0.2, lrpIn: 0.15);

            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            _canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _canvas.Clear(Color.White);
            _pen = new Pen(Color.Black, 35);
            _pen.StartCap = _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            canvasContainer.Image = _bmp;

            var bmp = new Bitmap(drawingArea.Width, drawingArea.Height);
            _drawingArea = Graphics.FromImage(bmp);
            _drawingArea.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _drawingArea.DrawLine(new Pen(Color.Gray, 1), new Point(0, drawingArea.Height / 2), new Point(drawingArea.Width, drawingArea.Height / 2));
            _drawingArea.DrawLine(new Pen(Color.Gray, 1), new Point(drawingArea.Width / 2, 0), new Point(drawingArea.Width / 2, drawingArea.Height));
            _drawingArea.DrawEllipse(new Pen(Color.Gray, 1), new Rectangle(drawingArea.Width / 2 - 50, drawingArea.Height / 2 - 50, 100, 100));
            _drawingArea.DrawEllipse(new Pen(Color.Gray, 1), new Rectangle(drawingArea.Width / 2 - 90, drawingArea.Height / 2 - 90, 180, 180));

            drawingArea.BackColor = Color.Transparent;
            drawingArea.Image = bmp;
            drawingArea.Parent = canvasContainer;

            var path = Path.Combine(AppContext.BaseDirectory, "weights.txt");
            NN.loadWeights(path);
        }

        private void CanvasContainer_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = true;
            _x = e.X;
            _y = e.Y;
            canvasContainer.Cursor = Cursors.Cross;
        }

        private void CanvasContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove && _x != -1 && _y != -1)
            {
                _canvas.DrawLine(_pen, new Point(_x, _y), e.Location);
                _x = e.X;
                _y = e.Y;
            }
            ProcessImage();
            canvasContainer.Refresh();
        }

        private void CanvasContainer_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = false;
            _x = -1;
            _y = -1;
            canvasContainer.Cursor = Cursors.Default;
            ProcessImage();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        private void ClearCanvas()
        {
            canvasContainer.Image = null;
            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            canvasContainer.Image = _bmp;
            _canvas.Clear(Color.White);
            outputLabel.Text = string.Empty;
        }

        private void ProcessImage()
        {
            var ms = new MemoryStream();
            //remove the drawingArea child of canvasContainer
            drawingArea.Parent = null;
            var bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);

            canvasContainer.DrawToBitmap(bmp, new Rectangle(0, 0, canvasContainer.Width, canvasContainer.Height));
            //bmp.Save(Path.Combine(AppContext.BaseDirectory, "images", $"original-{TimeStamp.GetUTCNow()}-{labelImage.Text}.png"), ImageFormat.Png);

            drawingArea.Parent = canvasContainer;

            var image = DIP.ResizeImage(bmp, 32, 32);
            //image.Save(Path.Combine(AppContext.BaseDirectory, "images", $"{TimeStamp.GetUTCNow()}-{labelImage.Text}.png"), ImageFormat.Png);
            image.Save(ms, ImageFormat.Png);

            //predictedOutput.Text = perceptron.Prediction(DIP.GetBits(ms));
            NN.setInputs(DIP.GetBits<double>(ms));
            NN.run();

            var output = NN.getOutputsData();

            //outputLabel.Text = $"{output[0]}{output[1]}{output[2]}{output[3]}{output[4]}";
            DoUpdateOutput(output);
        }

        private void DoUpdateOutput(int[] output)
        {
            var patternA = new int[] { 0, 0, 0, 0, 1 };
            var patternB = new int[] { 0, 0, 0, 1, 0 };
            var patternC = new int[] { 0, 0, 0, 1, 1 };
            var patternD = new int[] { 0, 0, 1, 0, 0 };
            var patternE = new int[] { 0, 0, 1, 0, 1 };
            var patternF = new int[] { 0, 0, 1, 1, 0 };
            var patternG = new int[] { 0, 0, 1, 1, 1 };
            var patternH = new int[] { 0, 1, 0, 0, 0 };
            var patternI = new int[] { 0, 1, 0, 0, 1 };
            var patternJ = new int[] { 0, 1, 0, 1, 0 };
            var patternK = new int[] { 0, 1, 0, 1, 1 };
            var patternL = new int[] { 0, 1, 1, 0, 0 };
            var patternM = new int[] { 0, 1, 1, 0, 1 };
            var patternN = new int[] { 0, 1, 1, 1, 0 };
            var patternO = new int[] { 0, 1, 1, 1, 1 };
            var patternP = new int[] { 1, 0, 0, 0, 0 };
            var patternQ = new int[] { 1, 0, 0, 0, 1 };
            var patternR = new int[] { 1, 0, 0, 1, 0 };
            var patternS = new int[] { 1, 0, 0, 1, 1 };
            var patternT = new int[] { 1, 0, 1, 0, 0 };
            var patternU = new int[] { 1, 0, 1, 0, 1 };
            var patternV = new int[] { 1, 0, 1, 1, 0 };
            var patternW = new int[] { 1, 0, 1, 1, 1 };
            var patternX = new int[] { 1, 1, 0, 0, 0 };
            var patternY = new int[] { 1, 1, 0, 0, 1 };
            var patternZ = new int[] { 1, 1, 0, 1, 0 };

            if (output.SequenceEqual(patternA))
            {
                outputLabel.Text = "A";
            }
            else if (output.SequenceEqual(patternB))
            {
                outputLabel.Text = "B";
            }
            else if (output.SequenceEqual(patternC))
            {
                outputLabel.Text = "C";
            }
            else if (output.SequenceEqual(patternD))
            {
                outputLabel.Text = "D";
            }
            else if (output.SequenceEqual(patternE))
            {
                outputLabel.Text = "E";
            }
            else if (output.SequenceEqual(patternF))
            {
                outputLabel.Text = "F";
            }
            else if (output.SequenceEqual(patternG))
            {
                outputLabel.Text = "G";
            }
            else if (output.SequenceEqual(patternH))
            {
                outputLabel.Text = "H";
            }
            else if (output.SequenceEqual(patternI))
            {
                outputLabel.Text = "I";
            }
            else if (output.SequenceEqual(patternJ))
            {
                outputLabel.Text = "J";
            }
            else if (output.SequenceEqual(patternK))
            {
                outputLabel.Text = "K";
            }
            else if (output.SequenceEqual(patternL))
            {
                outputLabel.Text = "L";
            }
            else if (output.SequenceEqual(patternM))
            {
                outputLabel.Text = "M";
            }
            else if (output.SequenceEqual(patternN))
            {
                outputLabel.Text = "N";
            }
            else if (output.SequenceEqual(patternO))
            {
                outputLabel.Text = "O";
            }
            else if (output.SequenceEqual(patternP))
            {
                outputLabel.Text = "P";
            }
            else if (output.SequenceEqual(patternQ))
            {
                outputLabel.Text = "Q";
            }
            else if (output.SequenceEqual(patternR))
            {
                outputLabel.Text = "R";
            }
            else if (output.SequenceEqual(patternS))
            {
                outputLabel.Text = "S";
            }
            else if (output.SequenceEqual(patternT))
            {
                outputLabel.Text = "T";
            }
            else if (output.SequenceEqual(patternU))
            {
                outputLabel.Text = "U";
            }
            else if (output.SequenceEqual(patternV))
            {
                outputLabel.Text = "V";
            }
            else if (output.SequenceEqual(patternW))
            {
                outputLabel.Text = "W";
            }
            else if (output.SequenceEqual(patternX))
            {
                outputLabel.Text = "X";
            }
            else if (output.SequenceEqual(patternY))
            {
                outputLabel.Text = "Y";
            }
            else if (output.SequenceEqual(patternZ))
            {
                outputLabel.Text = "Z";
            }
        }
    }
}