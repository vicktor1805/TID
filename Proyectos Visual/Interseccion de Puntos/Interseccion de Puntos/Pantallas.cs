using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interseccion_de_Puntos
{
    class Pantallas
    {
        public List<float[]> ListaPantallas = new List<float[]>();

        public void AgregarPantalla(float x, float y, float i, float j)
        {
            float[] ListaDatos = new float[4];
            ListaDatos[0] = x;
            ListaDatos[1] = y;
            ListaDatos[2] = i;
            ListaDatos[3] = j;

            ListaPantallas.Add(ListaDatos);
        }
    }

    
}
