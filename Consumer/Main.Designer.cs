
namespace Consumer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.lblLives = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 30;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.Font = new System.Drawing.Font("Times New Roman" , 15.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte)(0)));
            this.lblLives.ForeColor = System.Drawing.Color.Coral;
            this.lblLives.Location = new System.Drawing.Point(101 , 169);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(21 , 24);
            this.lblLives.TabIndex = 7;
            this.lblLives.Text = "1";
            this.lblLives.Click += new System.EventHandler(this.lblLives_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman" , 16F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(82 , 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64 , 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lives";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman" , 15.75F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Coral;
            this.lblScore.Location = new System.Drawing.Point(101 , 107);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(21 , 24);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman" , 16F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(82 , 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64 , 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Score";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F , 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Consumer.Properties.Resources.background_1_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284 , 686);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
    }
}

