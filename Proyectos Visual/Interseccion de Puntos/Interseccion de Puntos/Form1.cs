using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interseccion_de_Puntos
{
    public partial class Form1 : Form
    {
        Pantallas pantallas;
        public Form1()
        {
            pantallas = new Pantallas();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtXPantalla.Text == "" ||
                txtYPantalla.Text == "" ||
                txtIPantalla.Text == "" ||
                txtJPantalla.Text == ""                
                )
            {
                MessageBox.Show("Rellene todos los datos");
            }
            else
            {
                float xPantalla = (float)Convert.ToDouble(txtXPantalla.Text.ToString());
                float yPantalla = (float)Convert.ToDouble(txtYPantalla.Text.ToString());
                float iPantalla = (float)Convert.ToDouble(txtIPantalla.Text.ToString());
                float jPantalla = (float)Convert.ToDouble(txtJPantalla.Text.ToString());

                pantallas.AgregarPantalla(xPantalla, yPantalla, iPantalla, jPantalla);

                MessageBox.Show("Pantalla Agregada");
                txtXPantalla.Text = "";
                txtYPantalla.Text = "";
                txtIPantalla.Text = "";                
                txtJPantalla.Text = "";
            }                 

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTocaPantalla_Click(object sender, EventArgs e)
        {
            if (txtXDatos.Text == "" ||
               txtYDatos.Text == "" ||
               txtIDatos.Text == "" ||
               txtJDatos.Text == ""
               )
            {
                MessageBox.Show("Rellene todos los datos");
            }
            else
            {
                // Cojer datos de los txtDatos
                bool tocaAlgunaPantalla = false;
                int IndicePantalla = 0;
                // Hacer la formula de excel recorriendo la lista de pantallas
                // si toca seteo true ^ y jalo su indice
                if (tocaAlgunaPantalla == false)
                    MessageBox.Show("No choca con ninguna pantalla");
                else
                    MessageBox.Show("Choca con la pantalla " + IndicePantalla.ToString() + " en el punto x: xResultado.ToString yResultado.ToString");
                
            }

        }
    }
}
