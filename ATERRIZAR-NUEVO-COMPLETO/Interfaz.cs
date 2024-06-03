using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO_COMPLETO
{
    class Interfaz
    {

        public Interfaz(ConsoleColor BG, ConsoleColor TextColor)
        {
            Console.BackgroundColor = BG;
            Console.ForegroundColor = TextColor;
        }
        public int MostrarMenu()
        {
            Console.Clear();

            Console.WriteLine("\n-----------------------");
            Console.WriteLine("| Gestión de Paquetes |");
            Console.WriteLine("-----------------------");
            Console.WriteLine("\n[1] -> Agregar paquetes.");
            Console.WriteLine("[2] -> Ver lista de paquetes.");
            Console.WriteLine("[3] -> Modificar un paquete.");
            Console.WriteLine("[4] -> Borrar un paquete. (NO DISPONIBLE)");
            Console.WriteLine("[5] -> Mostrar el paquete más barato.");
            Console.WriteLine("[6] -> Salir.");
            Console.Write("Ingrese la opción: ");
            return SolicitarOpcion();
        }

        public float SolicitarImpuesto()
        {
            float Impuesto;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Impuesto);
            while (!Resultado || Impuesto < 0)
            {
                Console.Write("\nPorcentaje no válido.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Impuesto);
            }

            return Impuesto;
        }

        public string SolicitarModificacion()
        {
            string Mod = Console.ReadLine().ToUpper();

            while (Mod != "NUMERO" && Mod != "PRECIO" && Mod != "DETALLE" )
            {
                Console.Write("\nEl campo que ingresó no existe.\nIngrese nuevamente: ");
                Mod = Console.ReadLine().ToUpper();
            }

            return Mod;
        }
        
        public int SolicitarNumero()
        {
            int Numero;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Numero);
            while (!Resultado || Numero < 0 || Numero > 999)
            {
                Console.Write("\nNúmero de paquete inválido.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Numero);
            }

            return Numero;
        }

        public string SolicitarDetalle()
        {
            string Detalle = Console.ReadLine();

            while (Detalle == "")
            {
                Console.Write("\nEl detalle no puede estar vacío.\nIngrese nuevamente: ");
                Detalle = Console.ReadLine();
            }

            return Detalle;
        }

        public float SolicitarPrecio()
        {
            float Precio;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Precio);
            while (!Resultado || Precio < 0)
            {
                Console.Write("\nEl precio ingresado no es válido.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Precio);
            }

            return Precio;
        }


        public int SolicitarOpcion()
        {
            int Opcion;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < 1 || Opcion > 6)
            {
                Console.Write("\nIngresaste una opción inválida.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        }

        public void MostrarMensaje(string Mensaje)
        {
            Console.Write("\n" + Mensaje);
        }

        public void Pause()
        {
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    }
}
