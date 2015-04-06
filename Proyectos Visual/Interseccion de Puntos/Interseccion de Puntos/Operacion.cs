using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interseccion_de_Puntos
{
    public class Operacion
    {
        private readonly float EPS = 1 * 10 ^ -7;
        private float[] Datos = new float[4];
        private Punto puntoInterseccion = null;

        public Punto PuntoInterseccion
        {
            get { return puntoInterseccion; }
            set { puntoInterseccion = value; }
        }

        public void agregarDatos(float x,float y, float i, float j)
        {
            Datos[0] = x;
            Datos[1] = y;
            Datos[2] = i;
            Datos[3] = j;

        }
        public bool chocoPantalla(List<float[]> Pantallas)
        {
            bool choco = false;
            bool dentro = false;
            float m = 0f;
            if(Datos[2] != 0)
                m =  Datos[3] / Datos[2];
            Linea dato = PuntoPendienteALinea(new Punto(Datos[0], Datos[1]),m);
            foreach(float[] pantalla in Pantallas)
            {
                Linea pant = PuntoALinea(new Punto(pantalla[0],pantalla[1]),new Punto(pantalla[2],pantalla[3]));
                puntoInterseccion = Interseccion(pant, dato);
                if (puntoInterseccion != null)
                {
                    dentro = DentroDeLaPantalla(new Punto(pantalla[0], pantalla[1]), new Punto(pantalla[2], pantalla[3]));
                    break;
                }
            }

            if(dentro)
                choco = true;

            return choco;
        }

        public float[] ObtenerPuntoInterseccion()
        {
            if (puntoInterseccion == null)
                return null;

            float[] punto = new float[2];
            punto[0] = puntoInterseccion.X;
            punto[1] = puntoInterseccion.Y;

            return punto;
        }
        private Linea PuntoALinea(Punto punto1, Punto punto2)
        {
            Linea linea = new Linea();

            if (punto1.X == punto2.X)
            {
                linea.X = 1;
                linea.Y = 0;
                linea.Z = -punto1.X;
            }
            else
            {
                linea.X = -(punto1.Y - punto2.Y) / (punto1.X - punto2.X);
                linea.Y = 1;
                linea.Z = -(linea.X * punto1.X) - (linea.Y * punto1.Y);
            }

            return linea;
        }

        private Linea PuntoPendienteALinea(Punto p,float m)
        {
            Linea linea = new Linea();

            linea.X = -m;
            linea.Y = 1;
            linea.Z = -((linea.X*p.X)+(linea.Y*p.Y));

            return linea;
        }
        private bool SonParalelas(Linea lineaEstatica,Linea lineaDinamica)
        {
            return ((Math.Abs(lineaEstatica.X-lineaDinamica.X) <= EPS) && Math.Abs(lineaEstatica.Y-lineaDinamica.Y) <= EPS) ;
        }

        private bool SonIguales(Linea lineaEstatica, Linea lineaDinamica)
        {
            return (SonParalelas(lineaEstatica,lineaDinamica) && (Math.Abs(lineaEstatica.Z-lineaDinamica.Z) <= EPS));
        }

        public Punto Interseccion(Linea lineaEstatica,Linea lineaDinamica)
        {
            Punto p = new Punto();
            if(SonParalelas(lineaEstatica,lineaDinamica))
                p = null;

            if(SonIguales(lineaEstatica,lineaDinamica))
                p = null;

            p.X = (lineaDinamica.Y*lineaEstatica.Z - lineaEstatica.Y*lineaDinamica.Z)/(lineaDinamica.X*lineaEstatica.Y - lineaEstatica.X*lineaDinamica.Y);
            if(Math.Abs(lineaEstatica.Y) > EPS )
                p.Y = - (lineaEstatica.X*p.X + lineaEstatica.Z)/(lineaEstatica.Y);
            else
                p.Y = - (lineaDinamica.X*p.X + lineaDinamica.Z)/(lineaDinamica.Y);

            return p;
        }

        private bool DentroDeLaPantalla(Punto punto1, Punto punto2)
        {
            float Xmayor = 0;
            float Xmenor = 100;
            float Ymayor = 0;
            float Ymenor = 100;

            if (punto1.X > Xmayor)
                Xmayor = punto1.X;
            if (punto2.X > Xmayor)
                Xmayor = punto2.X;
            if (punto1.Y > Ymayor)
                Ymayor = punto1.Y;
            if (punto2.Y > Ymayor)
                Ymayor = punto2.Y;

            if (punto1.X < Xmenor)
                Xmenor = punto1.X;
            if (punto2.X < Xmenor)
                Xmenor = punto2.X;
            if (punto1.Y < Ymenor)
                Ymenor = punto1.Y;
            if (punto2.Y < Ymenor)
                Ymenor = punto2.Y;

            return ((puntoInterseccion.X<=Xmayor && puntoInterseccion.X>=Xmenor) && (puntoInterseccion.Y<=Ymayor && puntoInterseccion.Y>=Ymenor));


        }
    }
}
