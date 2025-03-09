using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake2._0
{
    public partial class Form1 : Form
    {
        List<PictureBox> Lista = new List<PictureBox>();
        int tamañoPiezaPrincipal = 26;
        PictureBox Comida = new PictureBox();
        string direccion = "right";

        public Form1()
        {
            InitializeComponent();
            iniciarJuego();
            tmTiempo.Start();
        }

        public void iniciarJuego()
        {
            direccion = "right";
            tmTiempo.Interval = 200;
            lblPuntos.Text = "0";
            Lista.Clear();

            for (int i = 2; i >= 0; i--)
            {
                int posX = (i * tamañoPiezaPrincipal) + 70;
                int posY = 80;

                crearSnake(Lista, this, posX, posY);
            }

            crearComida();
        }

        public void crearSnake(List<PictureBox> listaPelota, Form formulario, int posicionx, int posiciony)
        {
            PictureBox pb = new PictureBox
            {
                Location = new Point(posicionx, posiciony),
                Image = Properties.Resources.bodys,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            listaPelota.Add(pb);
            formulario.Controls.Add(pb);
        }

        private void crearComida()
        {
            Random rnd = new Random();
            int maxX = (this.ClientSize.Width / tamañoPiezaPrincipal) * tamañoPiezaPrincipal - tamañoPiezaPrincipal;
            int maxY = (this.ClientSize.Height / tamañoPiezaPrincipal) * tamañoPiezaPrincipal - tamañoPiezaPrincipal;

            int enterox = rnd.Next(0, maxX / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;
            int enteroy = rnd.Next(0, maxY / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;

            PictureBox pb = new PictureBox
            {
                Location = new Point(enterox, enteroy),
                Image = Properties.Resources.apple,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            if (Comida != null)
            {
                this.Controls.Remove(Comida);
            }

            Comida = pb;
            this.Controls.Add(pb);
        }

        private void tmTiempo_Tick(object sender, EventArgs e)
        {
            int nx = Lista[0].Location.X;
            int ny = Lista[0].Location.Y;

            for (int i = Lista.Count - 1; i > 0; i--)
            {
                Lista[i].Location = Lista[i - 1].Location;
            }

            switch (direccion)
            {
                case "right":
                    nx += tamañoPiezaPrincipal;
                    Lista[0].Image = Properties.Resources.headright;
                    break;
                case "left":
                    nx -= tamañoPiezaPrincipal;
                    Lista[0].Image = Properties.Resources.headleft;
                    break;
                case "up":
                    ny -= tamañoPiezaPrincipal;
                    Lista[0].Image = Properties.Resources.headup;
                    break;
                case "down":
                    ny += tamañoPiezaPrincipal;
                    Lista[0].Image = Properties.Resources.headdown;
                    break;
            }

            Lista[0].Location = new Point(nx, ny);

            verificarColision();
            verificarColisionComida();

            this.Refresh();
        }

        private void verificarColision()
        {
      
            if (Lista.Count >= 4)
            {
                for (int i = 3; i < Lista.Count; i++)
                {
                    if (Lista[0].Bounds.IntersectsWith(Lista[i].Bounds))
                    {
                        gameOver();
                        return;
                    }
                }
            }

            if (Lista[0].Left < 0 ||
                Lista[0].Right > this.ClientSize.Width ||
                Lista[0].Top < 0 ||
                Lista[0].Bottom > this.ClientSize.Height)
            {
                gameOver();
                return;
            }
        }

        private void verificarColisionComida()
        {
            if (Lista[0].Bounds.IntersectsWith(Comida.Bounds))
            {
                this.Controls.Remove(Comida);

                if (tmTiempo.Interval > 50)
                {
                    tmTiempo.Interval -= 10;
                }

                int puntos = Convert.ToInt32(lblPuntos.Text);
                lblPuntos.Text = (puntos + 1).ToString();

                crearComida();

                int nuevaX = Lista[Lista.Count - 1].Location.X;
                int nuevaY = Lista[Lista.Count - 1].Location.Y;

                crearSnake(Lista, this, nuevaX, nuevaY);
            }
        }

        private void gameOver()
        {
            tmTiempo.Stop();
            gameOver gameOverForm = new gameOver();
            gameOverForm.ShowDialog();
        }

        public void reiniciarJuego()
        {
            tmTiempo.Stop();

            foreach (var segmento in Lista.ToList())
            {
                if (this.Controls.Contains(segmento))
                {
                    this.Controls.Remove(segmento);
                }
            }

            Lista.Clear();

            if (Comida != null && this.Controls.Contains(Comida))
            {
                this.Controls.Remove(Comida);
                Comida.Dispose();
            }

            iniciarJuego();
            tmTiempo.Start();
        }

        private void moverPieza(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && direccion != "down")
            {
                direccion = "up";
            }
            else if (e.KeyCode == Keys.Down && direccion != "up")
            {
                direccion = "down";
            }
            else if (e.KeyCode == Keys.Left && direccion != "right")
            {
                direccion = "left";
            }
            else if (e.KeyCode == Keys.Right && direccion != "left")
            {
                direccion = "right";
            }
        }
    }
}
