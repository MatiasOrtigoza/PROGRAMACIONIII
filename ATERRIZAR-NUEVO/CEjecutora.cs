using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO
{
    internal class CEjecutora
    {
        static int TamañoVector = 5;

        static void Main(string[] args)
        {
            CViaje[] VectorViajes = new CViaje[TamañoVector];
            int Opcion = 0;

            CargarVector(VectorViajes);

            Opcion = MostrarMenu();
            if (Opcion == 1)
            {
                BuscarViajePorCodigo(VectorViajes);
            }
            else if(Opcion == 2)
            {
                Console.Write("\nIngrese el origen para ver los viajes que lo comparten: ");
                VuelosOrigenCompartido(VectorViajes, Console.ReadLine());
            }
            else if (Opcion == 3)
            {
                Console.Write("\nIngrese el destino para ver los viajes que lo comparten: ");
                VuelosDestinoCompartido(VectorViajes, Console.ReadLine());
            }

            Console.Write("\n\nSaliendo...Presione una tecla para continuar.");
            Console.ReadKey();

        }

        static void VuelosDestinoCompartido(CViaje[] VectorViajes, string Destino)
        {
            int i;
            int CantidadEncontrada = 0;

            for (i = 0; i < VectorViajes.Length; i++)
            {
                if (VectorViajes[i].GetDestino() == Destino)
                {
                    CantidadEncontrada++;
                    Console.Write(VectorViajes[i].DarDatos());
                }
            }

            CasosCompartidos(Destino, CantidadEncontrada);
        }

        static void VuelosOrigenCompartido(CViaje[] VectorViajes, string Origen)
        {
            int i;
            int CantidadEncontrada = 0;

            for (i = 0; i < VectorViajes.Length; i++)
            {
                if (VectorViajes[i].GetOrigen() == Origen)
                {
                    CantidadEncontrada++;
                    Console.Write(VectorViajes[i].DarDatos());
                }
            }

            CasosCompartidos(Origen, CantidadEncontrada);
        }

        static void CasosCompartidos(string Dato, int CantidadEncontrada)
        {
            switch (CantidadEncontrada)
            {
                case 0:
                    Console.Write("\nNo existen viajes que hayan tenido ese origen/destino...");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.Write("\nHay un solo viaje que haya tenido ese origen/destino, el cual no lo comparte con nadie...");
                    Console.ReadKey();
                    break;
                default:
                    Console.Write($"\nHay {CantidadEncontrada} viajes que comparten el origen/destino {Dato}...");
                    Console.ReadKey();
                    break;
            }
        }

        static void BuscarViajePorCodigo(CViaje[] VectorViajes)
        {
            string Codigo;
            int i;
            int Cuotas;

            Console.Write("\nIngresa el código del viaje: ");
            Codigo = Console.ReadLine();

            for (i = 0; i < VectorViajes.Length; i++)
            {
                if (Codigo == VectorViajes[i].GetCodigo())
                {
                    Console.Write(VectorViajes[i].DarDatos());

                    Console.Write("Ingrese la cantidad de cuotas a pagar el viaje (1-3-6-12): ");
                    Cuotas = SolicitarCuotas();
                    Console.Write($"\nEl total a pagar en {Cuotas} cuotas es: ${VectorViajes[i].DarPrecio(Cuotas)}...");
                    Console.ReadKey();

                    i = VectorViajes.Length + 1;
                }
            }

            if (i != VectorViajes.Length + 1)
            {
                Console.Write("\n\nNo existe el viaje que está buscando...");
                Console.ReadKey();
            }

        }
        static void CargarVector(CViaje[] VectorViajes)
        {
            int Cont = 0;
            string Origen;
            string Destino;
            string Codigo;
            float Precio;

            while (Cont < VectorViajes.Length)
            {
                Console.Write("\nIngresa el código del viaje: ");
                Codigo = Console.ReadLine();
                Console.Write("Ingresa el origen del viaje: ");
                Origen = Console.ReadLine();
                Console.Write("Ingresa el destino del viaje: ");
                Destino = Console.ReadLine();
                Console.Write("Ingresa el precio del viaje: ");
                Precio = SolicitarPrecio();

                VectorViajes[Cont] = new CViaje(Codigo, Origen, Destino);
                VectorViajes[Cont].PrecioViaje = Precio;
                Cont++;
            }
            
        }

        static int MostrarMenu()
        {
            int Opcion = 0;
            Console.Write("\n\n\t\tMENU:\n\n1.Buscar un viaje por código\n2.Ingrese un origen para ver los vuelos que lo comparten.\n3. Ingrese un destino para ver los vuelos que lo comparten\n4.Salir\nIngrese: ");
            return Opcion = SolicitarOpcion();
        }


        static int SolicitarOpcion()
        {
            int Opcion = 0;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            while (Resultado == false || OpcionInvalida(Opcion))
            {
                Console.Write($"\n{Opcion} no es una opción válida...\nIngrese nuevamente (1-4): ");
                Resultado = int.TryParse(Console.ReadLine(), out Opcion);
            }
            return Opcion;
        }


        static float SolicitarPrecio()
        {
            float Precio = 0;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Precio);
            while (Resultado == false || Precio < 0)
            {
                Console.Write("El dato ingresado no es válido...\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Precio);
            }

            return Precio;
        }

        static int SolicitarCuotas()
        {
            int Cuotas = 0;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine() , out Cuotas);
            while (!Resultado || CuotaInvalida(Cuotas))
            {
                Console.Write("\nLa cuota ingresada no es válida...\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Cuotas);
            }

            return Cuotas;
        }

        static bool CuotaInvalida(int Cuotas)
        {
            if (Cuotas != 1 && Cuotas != 3 && Cuotas != 6 && Cuotas != 12)
            {
                return true;
            }
            return false;
        }

        static bool OpcionInvalida(int Opcion)
        {
            if (Opcion < 1 || Opcion > 4)
            {
                return true;
            }
            return false;
        }
    }
}
