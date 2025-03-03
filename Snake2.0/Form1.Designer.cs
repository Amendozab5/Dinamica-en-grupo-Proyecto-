
namespace Snake2._0
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            tmTiempo = new System.Windows.Forms.Timer(components);
            lblPuntos = new Label();
            pnArriba = new Panel();
            pnIzquierda = new Panel();
            pnDerecha = new Panel();
            pnAbajo = new Panel();
            pnArriba.SuspendLayout();
            pnAbajo.SuspendLayout();
            SuspendLayout();
            // 
            // tmTiempo
            // 
            tmTiempo.Interval = 200;
            tmTiempo.Tick += tmTiempo_Tick;
            // 
            // lblPuntos
            // 
            lblPuntos.AutoSize = true;
            lblPuntos.BackColor = Color.Transparent;
            lblPuntos.Font = new Font("Unispace", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPuntos.Location = new Point(564, -6);
            lblPuntos.Name = "lblPuntos";
            lblPuntos.Size = new Size(31, 33);
            lblPuntos.TabIndex = 0;
            lblPuntos.Text = "0";
            // 
            // pnArriba
            // 
            pnArriba.BackColor = Color.Transparent;
            pnArriba.Controls.Add(pnIzquierda);
            pnArriba.Controls.Add(pnDerecha);
            pnArriba.Location = new Point(0, -1);
            pnArriba.Name = "pnArriba";
            pnArriba.Size = new Size(625, 27);
            pnArriba.TabIndex = 1;
            // 
            // pnIzquierda
            // 
            pnIzquierda.Location = new Point(0, 3);
            pnIzquierda.Name = "pnIzquierda";
            pnIzquierda.Size = new Size(19, 600);
            pnIzquierda.TabIndex = 3;
            // 
            // pnDerecha
            // 
            pnDerecha.Location = new Point(601, 3);
            pnDerecha.Name = "pnDerecha";
            pnDerecha.Size = new Size(21, 600);
            pnDerecha.TabIndex = 3;
            // 
            // pnAbajo
            // 
            pnAbajo.BackColor = Color.Transparent;
            pnAbajo.Controls.Add(lblPuntos);
            pnAbajo.Location = new Point(0, 575);
            pnAbajo.Name = "pnAbajo";
            pnAbajo.Size = new Size(625, 27);
            pnAbajo.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo;
            ClientSize = new Size(619, 602);
            Controls.Add(pnAbajo);
            Controls.Add(pnArriba);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            KeyDown += moverPieza;
            pnArriba.ResumeLayout(false);
            pnAbajo.ResumeLayout(false);
            pnAbajo.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Timer tmTiempo;
        private Label lblPuntos;
        private Panel pnArriba;
        private Panel pnIzquierda;
        private Panel pnDerecha;
        private Panel pnAbajo;
    }
}
