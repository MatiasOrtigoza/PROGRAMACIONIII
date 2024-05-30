using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAQUETE_TURISTICO_ORTIGOZA
{
    internal class CEjecutora
    {
        static void Main(string[] args)
        {
            string Opcion;
            string Detalle;
            ushort NumeroPaquete;

            Console.Write("Establezca el impuesto que comparten todos los viajes (0% al 100%): ");
            CPaquete.SetImpuesto(SolicitarPorcentaje());

            Console.Write("\nElija la opción:\n1. Ingresar un solo paquete\n2. Ingresar una cantidad indeterminada de paquetes (limite 100)\n\nINGRESE: ");
            Opcion = Console.ReadLine();

            if(Opcion == "1")
            {
                Console.Write("\nIngresa el número de paquete (0-999): ");
                NumeroPaquete = SolicitarNumeroPaquete();

                Console.Write("\nIngresa el detalle del paquete: ");
                Detalle = Console.ReadLine();

                CPaquete Paquete = new CPaquete(NumeroPaquete, Detalle);

                Console.Write("\nIngresa el precio del paquete: ");
                Paquete.SetPrecio(SolicitarPrecio());

                Console.Write("\nDatos del paquete ingresado: " + Paquete.MostrarDatos());
            }
            else
            {
                CPaquete[] VectorPaquetes = new CPaquete[100];

                IngresarPaquetes(VectorPaquetes);


            }

            Console.Write("\nSaliendo... Presiona una tecla para continuar ");
            Console.ReadKey();
        }

        public static void IngresarPaquetes(CPaquete[] VectorPaquetes)
        {
            string Detalle;
            ushort NumeroPaquete;
            string Decision = "Y";
            int Cont = 0;

            CPaquete PaqueteEconomico = new CPaquete();

            while (Decision == "Y" && Cont < 100)
            {
                Console.Write("\nIngresa el número de paquete (0-999): ");
                NumeroPaquete = SolicitarNumeroPaquete();

                Console.Write("\nIngresa el detalle del paquete: ");
                Detalle = Console.ReadLine();

                VectorPaquetes[Cont] = new CPaquete(NumeroPaquete, Detalle);
                Console.Write("\nIngresa el precio del paquete: ");
                VectorPaquetes[Cont].SetPrecio(SolicitarPrecio());

                Cont++;

                Console.Write("\n\n¿Desea añadir otro paquete? (Y/N): ");
                Decision = SolicitarDecision();
            }

            Console.Write("\nIngreso finalizado.");

            PaqueteEconomico = PaqueteMasEconomico(VectorPaquetes, Cont);

            Console.Write($"\nEl paquete más económico es el siguiente:\n{PaqueteEconomico.MostrarDatos()}");

        }

        public static CPaquete PaqueteMasEconomico(CPaquete[] VectorPaquetes, int ValoresValidos)
        {
            int i;
            CPaquete AUX = new CPaquete();

            AUX = VectorPaquetes[0];

            for (i = 1; i < ValoresValidos; i++)
            {

                if (VectorPaquetes[i].GetPrecio() < AUX.GetPrecio())
                {
                    AUX = VectorPaquetes[i];
                }

            }

            return AUX;

        }

        public static string SolicitarDecision()
        {
            string Decision = Console.ReadLine().ToUpper();

            while (Decision != "Y" && Decision != "N")
            {
                Console.Write("\nERROR. Ingresa una opción válida.\nIngrese nuevamente: ");
                Decision = Console.ReadLine().ToUpper();
            }
            
            return Decision;
        }

        public static float SolicitarPrecio()
        {
            float Precio;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Precio);

            while (Resultado == false || Precio < 0 )
            {
                Console.Write("\nEl precio ingresado no es válido.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Precio);
            }

            return Precio;
        }

        public static ushort SolicitarNumeroPaquete()
        {
            ushort NumeroPaquete;
            bool Resultado;

            Resultado = ushort.TryParse(Console.ReadLine(), out NumeroPaquete);

            while (Resultado == false || NumeroPaquete < 0 || NumeroPaquete > 999)
            {
                Console.Write("\nERROR. Ingrese un número del 0 al 999\nIngrese nuevamente: ");
                Resultado = ushort.TryParse(Console.ReadLine(), out NumeroPaquete);
            }

            return NumeroPaquete;
        }

        public static string SolicitarOpcion()
        {
            string Opcion;

            Opcion = Console.ReadLine();

            while (Opcion != "1" && Opcion != "2")
            {
                Console.Write("\nIngrese una opción válida.\nIngrese nuevamente: ");
                Opcion = Console.ReadLine();
            }

            return Opcion;
        } 

        public static float SolicitarPorcentaje()
        {
            float Impuesto;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Impuesto);

            while (Resultado == false || Impuesto < 0 || Impuesto > 100)
            {
                Console.Write("\nError en el ingreso.\nIngrese nuevamente:");
                Resultado = float.TryParse(Console.ReadLine(), out Impuesto);
            }

            return Impuesto;

        }
    }
}
