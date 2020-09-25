namespace Tetris_Game
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.instructionButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(266, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "TETRIS";
            // 
            // instructionButton
            // 
            this.instructionButton.BackColor = System.Drawing.Color.SkyBlue;
            this.instructionButton.Location = new System.Drawing.Point(93, 468);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(203, 48);
            this.instructionButton.TabIndex = 1;
            this.instructionButton.Text = "INSTRUCTIONS";
            this.instructionButton.UseVisualStyleBackColor = false;
            this.instructionButton.Click += new System.EventHandler(this.instructionButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.SpringGreen;
            this.playButton.Location = new System.Drawing.Point(444, 468);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(202, 48);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.label1);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(830, 977);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button instructionButton;
        private System.Windows.Forms.Button playButton;
    }
}
