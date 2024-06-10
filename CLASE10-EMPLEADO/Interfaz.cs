using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    static class Interfaz
    {
        /// <summary>
        /// Solicita un numero de tipo ushort mostrando en pantalla el <paramref name="Campo"/> que ingreses por parámetro.
        /// </summary>
        /// <param name="Campo"></param>
        /// <returns>Devuelve el número verificando errores</returns>

        public static int MostrarMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue; 
            Console.ForegroundColor = ConsoleColor.White;

            Clear();

            Console.WriteLine("APLICACION CONSTRUCTORA\n");
            Console.WriteLine("[1] -> Listar obreros y capataces registrados:");
            Console.WriteLine("[2] -> Agregar un obrero.");
            Console.WriteLine("[3] -> Agregar un capataz");
            Console.WriteLine("[4] -> Remover a un obrero o capataz.");
            Console.WriteLine("[5] -> Editar un obrero.");
            Console.WriteLine("[6] -> Editar un capataz.");
            Console.WriteLine("[7] -> Salir");
            Console.Write(    "Su opción: ");
            return SolicitarOpcion();

        }

        public static Especialidad SolicitarEspecialidad()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            string Especialidad;

            Clear();
            Mensaje("Ingrese la especialidad del empleado(Albañil/Pintor/Plomero/Herrero/Electricista): ");
            Especialidad = Console.ReadLine().ToUpper();

            while (Especialidad == "" || !VerificarEspecialidad(Especialidad))
            {
                Mensaje("Error en el ingreso... Ingrese Albañil/Pintor/Plomero/Herrero/Electricista: ");
                Especialidad = Console.ReadLine().ToUpper();
            }

            switch (Especialidad)
            {
                case "ALBAÑIL":
                    return CLASE10_EMPLEADO.Especialidad.Albañil;
                case "PINTOR":
                    return CLASE10_EMPLEADO.Especialidad.Pintor;
                case "PLOMERO":
                    return CLASE10_EMPLEADO.Especialidad.Plomero;
                case "HERRERO":
                    return CLASE10_EMPLEADO.Especialidad.Herrero;
                default:
                    return CLASE10_EMPLEADO.Especialidad.Electricista;
            }
            
        }

        public static bool VerificarEspecialidad(string Especialidad)
        {
            if (Especialidad != "ALBAÑIL" && Especialidad != "PINTOR" && Especialidad != "PLOMERO" && Especialidad != "HERRERO" && Especialidad != "ELECTRICISTA")
            {
                return false;
            }

            return true;
        }

        public static int SolicitarOpcion()
        {
            int minOpcion = 1;
            int maxOpcion = 7;

            int Opcion;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < minOpcion || Opcion > maxOpcion)
            {
                Console.Write($"Error. Ingrese una opción válida entre {minOpcion} y {maxOpcion}: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        }

        public static int SolicitarTipoDeOrdenamiento()
        {
            int minOpcion = 1;
            int maxOpcion = 2;

            int Opcion;
            bool Resultado;

            Clear();
            Console.Write("¿Cómo desea ver la lista?\n");
            Console.Write("[1] -> Original.\n");
            Console.Write("[2] -> Ordenada.\n");
            Console.Write("Ingrese: ");

            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < minOpcion || Opcion > maxOpcion)
            {
                Console.Write($"Error. Ingrese una opción válida entre {minOpcion} y {maxOpcion}: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        }



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

        public static void Mensaje(string Mensaje)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Mensaje);
        }

        public static void Clear()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void Pause()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Mensaje("\n\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
