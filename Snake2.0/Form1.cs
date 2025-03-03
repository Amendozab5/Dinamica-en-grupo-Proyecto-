namespace Snake2._0
{
    public partial class Form1 : Form
    {
        List<PictureBox> Lista = new List<PictureBox>();
        int tamañoPiezaPrincipal = 26;
        PictureBox Comida = new PictureBox();
        string direccion = "right";
        string direccionAnterior = "right";

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
            Lista = new List<PictureBox>();

            for (int i = 2; i >= 0; i--)
            {
                int posX = (i * tamañoPiezaPrincipal) + 70;
                int posY = 80;

                posX = (posX / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;
                posY = (posY / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;

                crearSnake(Lista, this, posX, posY);
            }

            crearComida();
        }


        public void crearSnake(List<PictureBox> listaPelota, Form formulario, int posicionx, int posiciony)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(posicionx, posiciony);
            pb.Image = Properties.Resources.bodys;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            listaPelota.Add(pb);
            formulario.Controls.Add(pb);
        }

        private void crearComida()
        {
            Random rnd = new Random();

            int minX = tamañoPiezaPrincipal; 
            int maxX = (this.ClientSize.Width / tamañoPiezaPrincipal) * tamañoPiezaPrincipal - tamañoPiezaPrincipal;

            int minY = tamañoPiezaPrincipal;
            int maxY = (this.ClientSize.Height / tamañoPiezaPrincipal) * tamañoPiezaPrincipal - tamañoPiezaPrincipal;
            int enterox = rnd.Next(minX / tamañoPiezaPrincipal, maxX / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;
            int enteroy = rnd.Next(minY / tamañoPiezaPrincipal, maxY / tamañoPiezaPrincipal) * tamañoPiezaPrincipal;

            // Crear comida
            PictureBox pb = new PictureBox();
            pb.Location = new Point(enterox, enteroy);
            pb.Image = Properties.Resources.apple;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;

            // Eliminar y agregar comida nueva
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

            string direccionAnterior = direccion;

            for (int i = Lista.Count - 1; i > 0; i--)
            {
                Lista[i].Location = new Point(Lista[i - 1].Location.X, Lista[i - 1].Location.Y);
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

            verificarColisionCuerpoYBordes();

            verificarColisionCuerpo();

            verificarColisionComida();

            direccionAnterior = direccion;

            this.Refresh();
        }
        private void verificarColisionCuerpo()
        {
            if (Lista.Count < 4) return; // Para evitar falsos positivos uWu :)

            for (int i = 3; i < Lista.Count; i++) 
            {
                if (Lista[0].Bounds.IntersectsWith(Lista[i].Bounds))
                {
                    tmTiempo.Stop(); 

                    gameOver gameOverForm = new gameOver();
                    gameOverForm.ShowDialog();

                    return; 
                }
            }
        }

        private void verificarColisionComida()
        {
            if (Lista[0].Bounds.IntersectsWith(Comida.Bounds))
            {
                // Eliminar la comida actual
                this.Controls.Remove(Comida);

                // Aumentar la velocidad 
                if (tmTiempo.Interval > 50)
                {
                    tmTiempo.Interval -= 10;
                }

                // Actualizar el puntaje
                int puntos = Convert.ToInt32(lblPuntos.Text);
                lblPuntos.Text = (puntos + 1).ToString();

                crearComida();

                int nuevaX = Lista[Lista.Count - 1].Location.X;
                int nuevaY = Lista[Lista.Count - 1].Location.Y;

                if (Lista.Count > 1)
                {
                    int penultimaX = Lista[Lista.Count - 2].Location.X;
                    int penultimaY = Lista[Lista.Count - 2].Location.Y;

                    if (nuevaX < penultimaX) 
                        nuevaX -= tamañoPiezaPrincipal;
                    else if (nuevaX > penultimaX) 
                        nuevaX += tamañoPiezaPrincipal;
                    else if (nuevaY < penultimaY) 
                        nuevaY -= tamañoPiezaPrincipal;
                    else if (nuevaY > penultimaY) 
                        nuevaY += tamañoPiezaPrincipal;
                }

                // Crear el nuevo segmento
                crearSnake(Lista, this, nuevaX, nuevaY);

                System.Threading.Thread.Sleep(5);
            }
        }
        private void verificarColisionCuerpoYBordes()
        {
            if (Lista.Count < 4) return;

            for (int i = 3; i < Lista.Count; i++)
            {
                if (Lista[0].Bounds.IntersectsWith(Lista[i].Bounds))
                {
                    tmTiempo.Stop(); 
                    gameOver gameOverForm = new gameOver();
                    gameOverForm.ShowDialog(); 
                    return;
                }
            }

            if (Lista[0].Bounds.IntersectsWith(pnArriba.Bounds) ||
                Lista[0].Bounds.IntersectsWith(pnAbajo.Bounds) ||
                Lista[0].Bounds.IntersectsWith(pnIzquierda.Bounds) ||
                Lista[0].Bounds.IntersectsWith(pnDerecha.Bounds))
            {
                tmTiempo.Stop(); 
                gameOver gameOverForm = new gameOver();
                gameOverForm.ShowDialog(); 
                return;
            }
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
