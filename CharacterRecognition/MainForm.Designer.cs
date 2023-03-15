namespace CharacterRecognition
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
            this.canvasContainer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.drawingArea = new CharacterRecognition.Components.TransparentPictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasContainer
            // 
            this.canvasContainer.BackColor = System.Drawing.Color.White;
            this.canvasContainer.Location = new System.Drawing.Point(12, 12);
            this.canvasContainer.Name = "canvasContainer";
            this.canvasContainer.Size = new System.Drawing.Size(250, 250);
            this.canvasContainer.TabIndex = 0;
            this.canvasContainer.TabStop = false;
            this.canvasContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseDown);
            this.canvasContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseMove);
            this.canvasContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasContainer_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recognized character";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputLabel.Location = new System.Drawing.Point(294, 68);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(84, 51);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "test";
            // 
            // drawingArea
            // 
            this.drawingArea.Enabled = false;
            this.drawingArea.Location = new System.Drawing.Point(24, 24);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(200, 200);
            this.drawingArea.TabIndex = 4;
            this.drawingArea.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(79, 268);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(110, 32);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 317);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvasContainer);
            this.Name = "MainForm";
            this.Text = "Character Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.canvasContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox canvasContainer;
        private Label label1;
        private Label outputLabel;
        private Components.TransparentPictureBox drawingArea;
        private Button clearButton;
    }
}