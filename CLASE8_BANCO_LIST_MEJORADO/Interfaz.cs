using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CLASE8_BANCO_LIST
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
            Console.WriteLine(" ----------------------------------------------");
            Console.WriteLine("|        Sistema de Gestión de Cuentas         |");
            Console.WriteLine(" ----------------------------------------------");
            Console.WriteLine("\n[1] -> Agregar una cuenta.");
            Console.WriteLine("\n[2] -> Efectuar un depósito.");
            Console.WriteLine("\n[3] -> Efectuar una extracción.");
            Console.WriteLine("\n[4] -> Mostrar datos de una cuenta.");
            Console.WriteLine("\n[5] -> Listar los datos de todas las cuentas.");
            Console.WriteLine("\n[6] -> Remover una cuenta.");
            Console.WriteLine("\n[7] -> Simular saldo final después de X meses.");
            Console.WriteLine("\n[8] -> Salir de la aplicación.");
            Console.WriteLine("\n ----------------------------------------------");
            return SolicitarOpcion();
        }

        public int SolicitarMeses()
        {
            int Meses;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Meses);
            while (!Resultado || Meses < 0)
            {
                Console.Write("\nValor incorrecto.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Meses);
            }

            return Meses;
        }

        public int SolicitarOpcion()
        {
            int Opcion;
            bool Resultado;
            Console.Write("\nIngrese su opción: ");
            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (!Resultado || Opcion < 1 || Opcion > 8)
            {
                Console.Write("\nOpción inválida.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }

            return Opcion;
        }

        public ulong SolicitarCBU()
        {
            ulong CBU = 0;
            bool Resultado = ulong.TryParse(Console.ReadLine(), out CBU);

            while (CBU.ToString().Length != 9 || !Resultado)
            {
                Console.Write("\nCBU inválido. Solo números y debe contener 9 dígitos...\nIngrese nuevamente: ");
                Resultado = ulong.TryParse(Console.ReadLine(), out CBU);

            }
            

            return CBU;
        }

        public float SolicitarSaldo()
        {

            float Saldo = 0;
            bool Resultado = float.TryParse(Console.ReadLine(), out Saldo);

            while (!Resultado || Saldo < 0)
            {
                Console.Write("\nEl monto no puede contener letras o ser menor a 0...\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Saldo);

            }
            return Saldo;
        }

        public float SolicitarPorcentaje()
        {
            float Porcentaje;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Porcentaje);
            while (!Resultado || Porcentaje < 0)
            {
                Mensaje("\nPorcentaje inválido.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Porcentaje);
            }

            return Porcentaje;
        }

        public string SolicitarNombre()
        {
            string Nombre = Console.ReadLine();
            while (Nombre == "")
            {
                Nombre = Console.ReadLine();
            }
            return Nombre;

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
