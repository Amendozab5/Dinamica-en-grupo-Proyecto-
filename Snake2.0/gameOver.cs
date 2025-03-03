using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake2._0
{
    public partial class gameOver : Form
    {
        public gameOver()
        {
            InitializeComponent();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Form1 formPrincipal = Application.OpenForms["Form1"] as Form1;

            if (formPrincipal != null)
            {
                formPrincipal.reiniciarJuego();
            }

            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
