using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_COMPONENTE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CargaDeMenu();

            int Opcion;

            Interfaz.MostrarMenu();
            Opcion = Interfaz.SolicitarOpcion();

            switch (Opcion)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                default:
                    break;
            }

            Interfaz.Pause();
        }

        static void CargaDeMenu()
        {
            List<string> ListaMenu = new List<string>
            {
                "Ingresar placa de vídeo",
                "Ingresar una CPU",
                "Mostrar datos de un componente",
                "Mostrar datos de todos los componentes",
                "Eliminar un componente",
                "Editar un componente",
                "Cargar placas de vídeo desde archivo",
                "Cargar CPUs desde archivo",
                "Salir"
            };

            Interfaz.CargarOpcion(ListaMenu);
        }


    }
}
