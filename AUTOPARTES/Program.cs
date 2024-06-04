using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AUTOPARTES
{
    internal class Program
    {
        static Interfaz UI = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.White);
        static ControladorAutopartes Control = new ControladorAutopartes();
        static void Main(string[] args)
        {
            UI.Clear();
            UI.Mensaje("\t\t\t\t\t\t¡Bienvenido usuario!");
            UI.Mensaje("\nAntes de comenzar a cargar sus autopartes, ingrese el porcentaje de la ganancia que desea para cada autoparte: ");
            Control.AsignarGanancia(UI.SolicitarGanancia());

            UI.Clear();
            CargarAutopartes();

            UI.Clear();
            Busqueda();

            UI.Clear();
            MostrarLista();

            UI.Mensaje("\n\nFinalizando el programa...");
            UI.Pause();
        }

        static void CargarAutopartes()
        {
            int Codigo;
            string Descripcion;
            float Costo;

            UI.Mensaje("\nIngrese el código de la autoparte [0-999.999.999] o -1 para salir: ");
            Codigo = UI.SolicitarCodigo();

            while (Codigo != -1)
            {
                UI.Mensaje("\nIngrese la descripción de la autoparte: ");
                Descripcion = UI.SolicitarDescripcion();
                UI.Mensaje("\nIngrese el costo de la autoparte: ");
                Costo = UI.SolicitarCosto();

                Control.AgregarAutoparte(Codigo, Descripcion, Costo);

                UI.Mensaje("\n¡Autoparte agregada satisfactoriamente!");
                UI.Pause();

                UI.Clear();

                UI.Mensaje("Ingrese el código de la autoparte [0-999.999.999] o -1 para salir: ");
                Codigo = UI.SolicitarCodigo();
                while (Control.ExisteAutoparte(Codigo) != null)
                {
                    UI.Mensaje("\nEl autoparte ingresado ya existe. Por favor ingrese otro: ");
                    Codigo = UI.SolicitarCodigo();
                }
            }
            UI.Clear();
            UI.Mensaje("\n\nFinalizando el ingreso de datos...");
            UI.Pause();
        }

        static void Busqueda()
        {
            int Codigo;
            ushort Cuotas;

            UI.Mensaje("\t\t\t\tBUSQUEDA DE AUTOPARTES:\n\n\n");
            UI.Mensaje("\nIngrese el número de autoparte que está buscando (-1 para salir): ");
            Codigo = UI.SolicitarCodigo();
            while (Codigo != -1)
            {
                if (Control.ExisteAutoparte(Codigo) != null)
                {
                    UI.Mensaje("\nIngrese la cantidad de cuotas para ver el precio final: ");
                    Cuotas = UI.SolicitarCuotas();


                    UI.Mensaje($"\nEl precio final pagado en {Cuotas} cuotas es de: {Control.CalcularCuotas(Codigo, Cuotas)}");
                }
                else
                {
                    UI.Mensaje("\nEl código de autoparte que está buscando no existe...");
                }

                UI.Pause();
                UI.Clear();


                UI.Mensaje("\nIngrese el número de autoparte que está buscando (-1 para salir): ");
                Codigo = UI.SolicitarCodigo();
            }
            UI.Clear();
            UI.Mensaje("\n\nFinalizando la búsqueda de datos.");
            UI.Pause();
        }

        static void MostrarLista()
        {
            UI.Mensaje("LISTA DE AUTOPARTES ORIGINAL:\n\n");
            UI.Mensaje(Control.MostrarLista());

            UI.Mensaje("\n\n\nLISTA DE AUTOPARTES ORDENADA: \n\n");
            UI.Mensaje(Control.MostrarListaOrdenada());

            UI.Mensaje("\n\n\nLISTA DE AUTOPARTES ORDENADA (REVERSED): \n\n");
            UI.Mensaje(Control.MostrarListaReverse());
        }
    }
}
