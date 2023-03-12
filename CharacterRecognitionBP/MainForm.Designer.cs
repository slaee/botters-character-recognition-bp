namespace CharacterRecognitionBP
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clearBtn = new System.Windows.Forms.Button();
            this.predictBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.canvasContainer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.epochsInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trainBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.predictedOutput = new System.Windows.Forms.Label();
            this.totalErrorLabel = new System.Windows.Forms.Label();
            this.dataSetsFeed = new System.Windows.Forms.ListBox();
            this.resetPerceptronModel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.randCharImageBtn = new System.Windows.Forms.Button();
            this.stopTraining = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.epochsLabel = new System.Windows.Forms.Label();
            this.loadDataSetBtn = new System.Windows.Forms.Button();
            this.dataSetPath = new System.Windows.Forms.Label();
            this.learningRateInput = new System.Windows.Forms.TextBox();
            this.saveModelBtn = new System.Windows.Forms.Button();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.drawingArea = new CharacterRecognitionBP.Components.TransparentPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 273);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(116, 34);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // predictBtn
            // 
            this.predictBtn.Location = new System.Drawing.Point(279, 127);
            this.predictBtn.Name = "predictBtn";
            this.predictBtn.Size = new System.Drawing.Size(85, 34);
            this.predictBtn.TabIndex = 2;
            this.predictBtn.Text = "Predict";
            this.predictBtn.UseVisualStyleBackColor = true;
            this.predictBtn.Click += new System.EventHandler(this.predictBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(279, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(85, 85);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // canvasContainer
            // 
            this.canvasContainer.BackColor = System.Drawing.Color.White;
            this.canvasContainer.Location = new System.Drawing.Point(12, 12);
            this.canvasContainer.Name = "canvasContainer";
            this.canvasContainer.Size = new System.Drawing.Size(250, 250);
            this.canvasContainer.TabIndex = 4;
            this.canvasContainer.TabStop = false;
            this.canvasContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseDown);
            this.canvasContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseMove);
            this.canvasContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "32x32";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Predicted Output";
            // 
            // epochsInput
            // 
            this.epochsInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.epochsInput.Location = new System.Drawing.Point(141, 465);
            this.epochsInput.Name = "epochsInput";
            this.epochsInput.Size = new System.Drawing.Size(119, 29);
            this.epochsInput.TabIndex = 7;
            this.epochsInput.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Epochs:";
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(21, 500);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(239, 34);
            this.trainBtn.TabIndex = 9;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Train Model";
            // 
            // predictedOutput
            // 
            this.predictedOutput.AutoSize = true;
            this.predictedOutput.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.predictedOutput.Location = new System.Drawing.Point(379, 39);
            this.predictedOutput.Name = "predictedOutput";
            this.predictedOutput.Size = new System.Drawing.Size(0, 37);
            this.predictedOutput.TabIndex = 11;
            // 
            // totalErrorLabel
            // 
            this.totalErrorLabel.AutoSize = true;
            this.totalErrorLabel.Location = new System.Drawing.Point(414, 326);
            this.totalErrorLabel.Name = "totalErrorLabel";
            this.totalErrorLabel.Size = new System.Drawing.Size(63, 15);
            this.totalErrorLabel.TabIndex = 12;
            this.totalErrorLabel.Text = "Total Error:";
            // 
            // dataSetsFeed
            // 
            this.dataSetsFeed.FormattingEnabled = true;
            this.dataSetsFeed.ItemHeight = 15;
            this.dataSetsFeed.Location = new System.Drawing.Point(279, 351);
            this.dataSetsFeed.Name = "dataSetsFeed";
            this.dataSetsFeed.Size = new System.Drawing.Size(320, 259);
            this.dataSetsFeed.TabIndex = 13;
            // 
            // resetPerceptronModel
            // 
            this.resetPerceptronModel.Location = new System.Drawing.Point(21, 578);
            this.resetPerceptronModel.Name = "resetPerceptronModel";
            this.resetPerceptronModel.Size = new System.Drawing.Size(239, 32);
            this.resetPerceptronModel.TabIndex = 14;
            this.resetPerceptronModel.Text = "Reset";
            this.resetPerceptronModel.UseVisualStyleBackColor = true;
            this.resetPerceptronModel.Click += new System.EventHandler(this.resetPerceptronModel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Learning Rate:";
            // 
            // randCharImageBtn
            // 
            this.randCharImageBtn.Location = new System.Drawing.Point(141, 273);
            this.randCharImageBtn.Name = "randCharImageBtn";
            this.randCharImageBtn.Size = new System.Drawing.Size(121, 34);
            this.randCharImageBtn.TabIndex = 18;
            this.randCharImageBtn.Text = "Rand Char Image";
            this.randCharImageBtn.UseVisualStyleBackColor = true;
            this.randCharImageBtn.Click += new System.EventHandler(this.randCharImageBtn_Click);
            // 
            // stopTraining
            // 
            this.stopTraining.Location = new System.Drawing.Point(21, 540);
            this.stopTraining.Name = "stopTraining";
            this.stopTraining.Size = new System.Drawing.Size(239, 32);
            this.stopTraining.TabIndex = 20;
            this.stopTraining.Text = "Stop training";
            this.stopTraining.UseVisualStyleBackColor = true;
            this.stopTraining.Click += new System.EventHandler(this.stopTraining_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(279, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Training Logs";
            // 
            // epochsLabel
            // 
            this.epochsLabel.AutoSize = true;
            this.epochsLabel.Location = new System.Drawing.Point(414, 283);
            this.epochsLabel.Name = "epochsLabel";
            this.epochsLabel.Size = new System.Drawing.Size(51, 15);
            this.epochsLabel.TabIndex = 22;
            this.epochsLabel.Text = "Epochs: ";
            // 
            // loadDataSetBtn
            // 
            this.loadDataSetBtn.Location = new System.Drawing.Point(21, 406);
            this.loadDataSetBtn.Name = "loadDataSetBtn";
            this.loadDataSetBtn.Size = new System.Drawing.Size(239, 34);
            this.loadDataSetBtn.TabIndex = 23;
            this.loadDataSetBtn.Text = "Load data set";
            this.loadDataSetBtn.UseVisualStyleBackColor = true;
            this.loadDataSetBtn.Click += new System.EventHandler(this.loadDataSetBtn_Click);
            // 
            // dataSetPath
            // 
            this.dataSetPath.AutoSize = true;
            this.dataSetPath.ForeColor = System.Drawing.Color.Gray;
            this.dataSetPath.Location = new System.Drawing.Point(29, 370);
            this.dataSetPath.MaximumSize = new System.Drawing.Size(200, 0);
            this.dataSetPath.Name = "dataSetPath";
            this.dataSetPath.Size = new System.Drawing.Size(106, 15);
            this.dataSetPath.TabIndex = 24;
            this.dataSetPath.Text = "No data set loaded";
            // 
            // learningRateInput
            // 
            this.learningRateInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.learningRateInput.Location = new System.Drawing.Point(21, 465);
            this.learningRateInput.Name = "learningRateInput";
            this.learningRateInput.Size = new System.Drawing.Size(114, 29);
            this.learningRateInput.TabIndex = 25;
            // 
            // saveModelBtn
            // 
            this.saveModelBtn.Location = new System.Drawing.Point(279, 223);
            this.saveModelBtn.Name = "saveModelBtn";
            this.saveModelBtn.Size = new System.Drawing.Size(320, 40);
            this.saveModelBtn.TabIndex = 26;
            this.saveModelBtn.Text = "Save model";
            this.saveModelBtn.UseVisualStyleBackColor = true;
            this.saveModelBtn.Click += new System.EventHandler(this.saveModelBtn_Click);
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Location = new System.Drawing.Point(414, 304);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(59, 15);
            this.accuracyLabel.TabIndex = 27;
            this.accuracyLabel.Text = "Accuracy:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(320, 40);
            this.button1.TabIndex = 28;
            this.button1.Text = "Load model";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // drawingArea
            // 
            this.drawingArea.Enabled = false;
            this.drawingArea.Location = new System.Drawing.Point(24, 24);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(200, 200);
            this.drawingArea.TabIndex = 29;
            this.drawingArea.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 634);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.saveModelBtn);
            this.Controls.Add(this.learningRateInput);
            this.Controls.Add(this.dataSetPath);
            this.Controls.Add(this.loadDataSetBtn);
            this.Controls.Add(this.epochsLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopTraining);
            this.Controls.Add(this.randCharImageBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resetPerceptronModel);
            this.Controls.Add(this.dataSetsFeed);
            this.Controls.Add(this.totalErrorLabel);
            this.Controls.Add(this.predictedOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.epochsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvasContainer);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.predictBtn);
            this.Controls.Add(this.clearBtn);
            this.Name = "MainForm";
            this.Text = "Vowel Recognition Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button clearBtn;
        private Button predictBtn;
        private PictureBox pictureBox;
        private PictureBox canvasContainer;
        private Label label1;
        private Label label2;
        private TextBox epochsInput;
        private Label label3;
        private Button trainBtn;
        private Label label4;
        private Label predictedOutput;
        private Label totalErrorLabel;
        private ListBox dataSetsFeed;
        private Button resetPerceptronModel;
        private Label label5;
        private Button randCharImageBtn;
        private Button stopTraining;
        private Label label6;
        private Label epochsLabel;
        private Button loadDataSetBtn;
        private Label dataSetPath;
        private TextBox learningRateInput;
        private Button saveModelBtn;
        private Label accuracyLabel;
        private Button button1;
        private Components.TransparentPictureBox drawingArea;
    }
}