using System.Drawing.Imaging;
using CharacterRecognitionBP.Utils;
using CharacterRecognitionBP.Interfaces;
using CharacterRecognitionBP.Common;
using System.Diagnostics;
using CharacterRecognitionBP.Components;
using System.Windows.Forms;

namespace CharacterRecognitionBP
{
    public partial class MainForm : Form
    {
        private readonly IWaiter Waiter;

        private Task? _trainTask;
        private CancellationTokenSource? _ctsAuto;

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

            Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "images"));

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
            canvasContainer.Refresh();
        }

        private void CanvasContainer_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = false;
            _x = -1;
            _y = -1;
            canvasContainer.Cursor = Cursors.Default;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            pictureBox.Image = null;
        }

        private void ClearCanvas()
        {
            canvasContainer.Image = null;
            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            canvasContainer.Image = _bmp;
            _canvas.Clear(Color.White);
            predictedOutput.Text = string.Empty;
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            ProcessImage();
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

            pictureBox.Image = image;
            //predictedOutput.Text = perceptron.Prediction(DIP.GetBits(ms));
            NN.setInputs(DIP.GetBits<double>(ms));
            NN.run();

            var output = NN.getOutputsData();
            predictedOutput.Text = $"{output[0]}{output[1]}{output[2]}{output[3]}{output[4]}";
        }

        private async Task Train(CancellationToken token)
        {
            var images = Directory.GetFiles(dataSetPath.Text, "*.png")
                            .Where(file => !file.Contains("original"))
                            .ToArray();

            var originalImages = Directory.GetFiles(dataSetPath.Text, "*.png")
                           .Where(file => file.Contains("original"))
                           .ToArray();
            
            var imageDictionary = new Dictionary<string, string>();
            for (int i = 0; i < images.Length; i++)
            {
                imageDictionary.Add(images[i], originalImages[i]);
            }

            // Shuffle data set to avoid overfitting
            var rand = new Random();
            imageDictionary = imageDictionary.OrderBy(x => rand.Next()).ToDictionary(x => x.Key, x => x.Value);

            images = imageDictionary.Keys.ToArray();
            originalImages = imageDictionary.Values.ToArray();

            int countEpoch = 0;
            for (int i = 0; i < Convert.ToInt32(epochsInput.Text) && !token.IsCancellationRequested; i++)
            {
                for (int j = 0; j < images.Length && !token.IsCancellationRequested; j++)
                {
                    var x = new MemoryStream();
                    var image = Image.FromFile(images[j]);
                    image.Save(x, ImageFormat.Png);

                    var y = Path.GetFileNameWithoutExtension(images[j]).Split('-')[1];
                    double[] y_outputs = y.Select(c => c == '1' ? 1.0 : 0.0).ToArray();

                // Start learn the model here
                // ----------------------------------------
                    NN.setInputs(DIP.GetBits<double>(x));
                    NN.setDesiredOutput(y_outputs);
                    NN.learn();
                // ----------------------------------------

                    dataSetsFeed.Invoke(new Action(() =>
                    {
                        dataSetsFeed.Items.Add($"Img: {Path.GetFileNameWithoutExtension(images[j])}   T: {Math.Abs(NN.getTotalError())}");
                        dataSetsFeed.SelectedIndex = dataSetsFeed.Items.Count - 1;
                    }));
                    
                    pictureBox.Image = image;
                    _canvas = Graphics.FromImage(Image.FromFile(originalImages[j]));
                    canvasContainer.Image = Image.FromFile(originalImages[j]);
                }

                if(NN.countgood())
                {
                    _ctsAuto!.Cancel();
                    break;
                }

                //if (Math.Abs(perceptron.TotalError) < 0.01)
                //{
                //    _ctsAuto!.Cancel();
                //    break;
                //}
                countEpoch++;
                epochsLabel.Invoke(new Action(() =>
                {
                    epochsLabel.Text = $"Epochs: {countEpoch}";
                }));
            }

            totalErrorLabel.Invoke(new Action(() =>
            {
                //totalErrorLabel.Text = $"Total Error: {Math.Abs(perceptron.TotalError).ToString()}";
            }));
        }

        private async void trainBtn_Click(object sender, EventArgs e)
        {
            if (dataSetPath.Text.Contains("No data set loaded"))
            {
                MessageBox.Show("Please select a data set first", "No data set loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            trainBtn.Enabled = false;
            resetPerceptronModel.Enabled = false;
            learningRateInput.Enabled = false;
            epochsInput.Enabled = false;

            _ctsAuto = new CancellationTokenSource();
            _trainTask = await Task.Factory.StartNew(async () =>
            {
                try
                {
                    await Train(_ctsAuto!.Token);
                } 
                catch (Exception e)
                {
                    Trace.WriteLine(e.StackTrace);
                }
                finally
                {
                    _ctsAuto?.Dispose();
                    _ctsAuto = null;
                }
            }, _ctsAuto!.Token);

            await Waiter.ForTrueAsync(() => _ctsAuto is null, 20);

            trainBtn.Enabled = true;
            resetPerceptronModel.Enabled = true;
            learningRateInput.Enabled = true;
            epochsInput.Enabled = true;
        }

        private void resetPerceptronModel_Click(object sender, EventArgs e)
        {
            totalErrorLabel.Text = "Total Error:";
            epochsLabel.Text = $"Epochs:";
            dataSetsFeed.Items.Clear();
        }

        private void randCharImageBtn_Click(object sender, EventArgs e)
        {
            if (dataSetPath.Text.Contains("No data set loaded"))
            {
                MessageBox.Show("Please select a data set first", "No data set loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
                
            var images = Directory.GetFiles(dataSetPath.Text, "*.png")
                            .Where(file => file.Contains("original"))
                            .ToArray();

            var rand = new Random();

            var image = Image.FromFile(images[rand.Next(0, images.Length)]);
            _canvas = Graphics.FromImage(image);
            canvasContainer.Image = image;
        }

        private void loadDataSetBtn_Click(object sender, EventArgs e)
        {
            // open file dialog and select directory only
            using var fbd = new FolderBrowserDialog();
            fbd.Description = "Select the directory that contains the images";
            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            dataSetPath.Text = fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : string.Empty;
        }

        private async void stopTraining_Click(object sender, EventArgs e)
        {
            _ctsAuto?.Cancel();
            await Waiter.ForTrueAsync(() => _ctsAuto is null, 20);
            _trainTask?.Dispose();
            
            trainBtn.Enabled = true;
            resetPerceptronModel.Enabled = true;
            learningRateInput.Enabled = true;
            epochsInput.Enabled = true;
        }

        private void saveModelBtn_Click(object sender, EventArgs e)
        {
            // open file dialog to save the file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            string path = string.Empty;

            if(sfd.ShowDialog() == DialogResult.Cancel)
                return;
            
            path = Path.GetFullPath(sfd.FileName);

            NN.saveWeights(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var fbd = new OpenFileDialog();
            fbd.Filter = "txt files (*.txt)|*.txt";
            fbd.Title = "Select the weight txt file format";

            string path = fbd.ShowDialog() == DialogResult.OK ? fbd.FileName : string.Empty;

            if(path != string.Empty)
            {
                NN.loadWeights(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataSetPath.Text.Contains("No data set loaded"))
            {
                MessageBox.Show("Please select a data set first", "No data set loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            string promptVal = Prompt.ShowDialog("Correct output", "Update");
           
            if (promptVal != string.Empty)
            {
                double[] y_outputs = promptVal.Select(c => c == '1' ? 1.0 : 0.0).ToArray();

                var ms = new MemoryStream();

                canvasContainer.Image.Save(Path.Combine(dataSetPath.Text, $"original-{TimeStamp.GetUTCNow()}-{promptVal}.png"), ImageFormat.Png);
                
                pictureBox.Image.Save(Path.Combine(dataSetPath.Text, $"{TimeStamp.GetUTCNow()}-{promptVal}.png"), ImageFormat.Png);

                pictureBox.Image.Save(ms, ImageFormat.Png);

                NN.setInputs(DIP.GetBits<double>(ms));
                NN.setDesiredOutput(y_outputs);
                NN.learn();
            }
        }
    }
}