using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOPARTES
{
    internal class ControladorAutopartes
    {
        List<CAutopartes> ListaAutopartes;

        public ControladorAutopartes()
        {
            ListaAutopartes = new List<CAutopartes>();
        }

        public CAutopartes ExisteAutoparte(int Codigo)
        {
            int Indice = ListaAutopartes.IndexOf(new CAutopartes(Codigo));

            if (Indice == -1)
            {
                return null;
            }

            return ListaAutopartes[Indice];
        }

        public void AgregarAutoparte(int Codigo, string Descripcion, float Costo)
        {
            //if (ExisteAutoparte(Codigo) != null)
            //{
            //    return false;
            //}

            ListaAutopartes.Add(new CAutopartes(Codigo, Descripcion, Costo));
        }

        public float CalcularCuotas(int Codigo,ushort Cuotas)
        {
            return ExisteAutoparte(Codigo).DarPrecio(Cuotas);
        }

        public string DarDatos(int Codigo)
        {
            return ExisteAutoparte(Codigo).DarDatos();
        }

        public string MostrarLista()
        {
            string Datos = "";

            foreach (CAutopartes Autoparte in ListaAutopartes)
            {
                Datos = Datos + Autoparte.DarDatos() + "\n\n";
            }

            return Datos;
        }

        public string MostrarListaOrdenada()
        {
            List<CAutopartes> ListaAUX = ListaAutopartes;
            ListaAUX.Sort();
            string Datos = "";

            foreach (CAutopartes Autoparte in ListaAUX)
            {
                Datos = Datos + Autoparte.DarDatos() + "\n\n";
            }

            return Datos;
        }

        public string MostrarListaReverse()
        {
            string Datos = "";

            foreach (CAutopartes Autoparte in ListaAutopartes)
            {
                Datos = Datos + Autoparte.DarDatos() + "\n\n";
            }

            return Datos;
        }

        public void AsignarGanancia(float Ganancia)
        {
            CAutopartes.Ganancia = Ganancia;
        }

    }
}
