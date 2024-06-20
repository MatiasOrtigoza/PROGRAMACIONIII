using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_COMPONENTE
{
    /// <summary>
    /// Objeto estático utilizado para el manejo de entrada y salida de datos.
    /// </summary>

    static class Interfaz
    {
        static List <string> ListaMenu = new List <string>();

        public static void CargarOpcion(string Opcion)
        {
            ListaMenu.Add(Opcion);
        }
        public static void CargarOpcion(List<string> Opciones)
        {
            foreach (string opcion in Opciones)
            {
                ListaMenu.Add(opcion);
            }
        }

        /// <summary>
        /// Objeto estático utilizado para el manejo de entrada y salida de datos.
        /// </summary>
        /// <returns>Devuelve el número de opción elegido. Si la lista está vacía devuelve -1.</returns>

        public static void MostrarMenu()
        {
            int i = 1;

            Clear();

            Mensaje("MENÚ DE OPCIONES:\n");

            foreach(string opcion in ListaMenu)
            {
                Mensaje("\n[" + i + "] -> " + opcion);
                i++;
            }
        }

        /// <summary>
        /// Solicita 
        /// </summary>
        /// <returns>Devuelve el número de opción elegido. Si la lista está vacía devuelve -1.</returns
        public static int SolicitarOpcion()
        {

            int ListSize = ListaMenu.Count;

            if (ListSize == 0)
            {
                return -1;
            }

            int Opcion;
            bool Resultado;
            Mensaje("\nIngrese: ");
            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < 1 || Opcion > ListSize)
            {
                ErrorMensaje("\nError al ingresar opción.");
                Pause();
                Clear();
                MostrarMenu();
                Mensaje("\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        }


        /// <summary>
        /// Solicita un numero de tipo short mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static short SolicitarShort(string Campo)
        {
            short Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = short.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = short.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }
        
        /// <summary>
        /// Solicita un numero de tipo ushort mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static ushort SolicitarUShort(string Campo)
        {
            ushort Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = ushort.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = ushort.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Solicita un numero de tipo float mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static float SolicitarFloat(string Campo)
        {
            float Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = float.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = float.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Solicita un numero de tipo float mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificado solamente si es positivo.</returns>

        public static float SolicitarFloatPositivo(string Campo)
        {
            float Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = float.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado || Dato < 0)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = float.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Solicita un string mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve un string sin permitir que se ingrese un vacío</returns>

        public static string SolicitarString(string Campo)
        {
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            string Dato = Console.ReadLine();
            while (Dato == "")
            {
                Mensaje($"\nEl campo {Campo} no puede estar vacío.");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Solicita un numero de tipo uint mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static uint SolicitarUInt(string Campo)
        {
            uint Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = uint.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = uint.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Solicita un numero de tipo int mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static int SolicitarInt(string Campo)
        {
            int Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = int.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = int.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }


        /// <summary>
        /// Solicita un numero de tipo long mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static long SolicitarLong(string Campo)
        {
            long Dato;
            bool Resultado;
            Clear();
            Mensaje($"Por favor ingrese {Campo}: ");
            Resultado = long.TryParse(Console.ReadLine(), out Dato);
            while (!Resultado)
            {
                Mensaje($"\nError al ingresar {Campo}...");
                Pause();
                Clear();
                Mensaje($"Ingrese nuevamente el campo {Campo}: ");
                Resultado = long.TryParse(Console.ReadLine(), out Dato);
            }

            Clear();

            return Dato;
        }

        /// <summary>
        /// Muestra en pantalla lo que sea ingresado por el parámetro <paramref name="Mensaje"/>
        /// <param name="Mensaje"></param>
        /// </summary>
        public static void Mensaje(string Mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Mensaje);
        }

        /// <summary>
        /// Muestra en pantalla lo que sea ingresado por el parámetro <paramref name="Mensaje"/> con un color rojo.
        /// <param name="Mensaje"></param>
        /// </summary>

        public static void ErrorMensaje(string Mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Mensaje);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Muestra en pantalla lo que sea ingresado por el parámetro <paramref name="Mensaje"/> con un color verde.
        /// <param name="Mensaje"></param>
        /// </summary>
        public static void SuccessMensaje(string Mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Mensaje);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Limpia la consola.
        /// </summary>

        public static void Clear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        /// <summary>
        /// Realiza una pausa solicitando pulsar una tecla para continuar.
        /// </summary>

        public static void Pause()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Mensaje("\n\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
