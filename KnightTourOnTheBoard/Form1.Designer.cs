using System;

namespace KnightTourOnTheBoard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Info = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.PictureBox();
            this.buttonHolder = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.PictureBox();
            this.printButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(12, 21);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(530, 13);
            this.Info.TabIndex = 0;
            this.Info.Text = "In this app, a knight visits all squares only once by moving with its legal move." +
                             " Choose a random square to start.";
            // 
            // Grid
            // 
            this.Grid.BackColor = System.Drawing.Color.Brown;
            this.Grid.Image = ((System.Drawing.Image)(resources.GetObject("Grid.Image")));
            this.Grid.Location = new System.Drawing.Point(15, 54);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(400, 400);
            this.Grid.TabIndex = 4;
            this.Grid.TabStop = false;
            // 
            // pictureBox4
            // 
            this.buttonHolder.BackColor = System.Drawing.SystemColors.Window;
            this.buttonHolder.Location = new System.Drawing.Point(433, 54);
            this.buttonHolder.Name = "pictureBox4";
            this.buttonHolder.Size = new System.Drawing.Size(109, 400);
            this.buttonHolder.TabIndex = 12;
            this.buttonHolder.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.Location = new System.Drawing.Point(444, 65);
            this.startButton.Margin = new System.Windows.Forms.Padding(0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 90);
            this.startButton.TabIndex = 13;
            this.startButton.TabStop = false;
            this.startButton.Click += new System.EventHandler(this.start_Click);
            // 
            // resetButton
            // 
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.Location = new System.Drawing.Point(444, 197);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(87, 90);
            this.resetButton.TabIndex = 14;
            this.resetButton.TabStop = false;
            this.resetButton.Click += new System.EventHandler(this.reset_Click);
            // 
            // printButton
            // 
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.Location = new System.Drawing.Point(444, 343);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(87, 90);
            this.printButton.TabIndex = 15;
            this.printButton.TabStop = false;
            this.printButton.Click += new System.EventHandler(this.print_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(564, 460);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.buttonHolder);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.Info);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Knight Tour On the Board";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.PictureBox Grid;
        private System.Windows.Forms.PictureBox buttonHolder;
        private System.Windows.Forms.PictureBox startButton;
        private System.Windows.Forms.PictureBox resetButton;
        private System.Windows.Forms.PictureBox printButton;
    }
}

