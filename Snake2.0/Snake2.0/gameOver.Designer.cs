namespace Snake2._0
{
    partial class gameOver
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
            panel1 = new Panel();
            btnSalir = new Panel();
            btnRestart = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackgroundImage = Properties.Resources.GAME_OVER;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnRestart);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 453);
            panel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackgroundImage = Properties.Resources.EXIT;
            btnSalir.BackgroundImageLayout = ImageLayout.Stretch;
            btnSalir.Location = new Point(307, 247);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(139, 54);
            btnSalir.TabIndex = 1;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnRestart
            // 
            btnRestart.BackgroundImage = Properties.Resources.RESTART;
            btnRestart.BackgroundImageLayout = ImageLayout.Stretch;
            btnRestart.Location = new Point(91, 247);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(139, 54);
            btnRestart.TabIndex = 0;
            btnRestart.Click += btnRestart_Click;
            // 
            // gameOver
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(535, 453);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "gameOver";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "gameOver";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel btnRestart;
        private Panel btnSalir;
    }
}