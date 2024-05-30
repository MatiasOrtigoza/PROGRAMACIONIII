using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CLASE8_DICCIONARIO
{
    internal class Interfaz
    {
        public Interfaz(ConsoleColor Background, ConsoleColor TextColor)
        {
            Console.BackgroundColor = Background;
            Console.ForegroundColor = TextColor;
        }

        public int MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("|        Diccionario        |");
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("\n[1] -> Buscar una palabra.");
            Console.WriteLine("\n[2] -> Agregar una definición.");
            Console.WriteLine("\n[3] -> Modificar una definición.");
            Console.WriteLine("\n[4] -> Eliminar una definición.");
            Console.WriteLine("\n[5] -> Salir de la aplicación.");
            Console.WriteLine("\n ----------------------------------------------");
            return SolicitarOpcion();
        }

        public int SolicitarOpcion()
        {
            int Opcion;
            bool Resultado;
            Console.Write("\nIngrese su opción: ");
            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < 1 || Opcion > 5)
            {
                Console.Write("\nOpción inválida.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Mensaje(string Mensaje)
        {
            Console.Write(Mensaje);
            return;
        } 

        public void PressKeyToContinue()
        {
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    }
}