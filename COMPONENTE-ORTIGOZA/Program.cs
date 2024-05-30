using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace COMPONENTE_ORTIGOZA
{
    internal class CEjecutora
    {
        static void Main(string[] args)
        {
            
            ulong Serie = 0;
            string Detalle = "undefined";
            float CostoComponente = 0F;
            float CostoManoObra = 0F;
            int Cont = 0;

            CComponente[] VectorComponentes = new CComponente[20];



            Console.Write("\n\nIngrese el número de serie de 0 a 999.999.999.999 (0 para salir) : ");
            Serie = SolicitarSerie();

            //ITERAMOS Y SOLICITAMOS LOS DATOS CONTROLANDO QUE SERIE SEA MAYOR A 0 Y QUE CONT MENOR AL MÁXIMO DE COMPONENTES ADMITIDOS
            while (Serie > 0 && Cont < 20)
            {

                Console.Write("\nIngrese el detalle: ");
                Detalle = SolicitarString();

                Console.Write("\nIngrese el costo del componente: ");
                CostoComponente = SolicitarCosto();

                Console.Write("\nIngrese el costo de la mano de obra: ");
                CostoManoObra = SolicitarCosto();

                VectorComponentes[Cont] = new CComponente(Serie, Detalle, CostoComponente, CostoManoObra);
                Cont++;

                Console.Write("\n\nIngrese el número de serie 0 a 999.999.999.999 (0 para salir): ");
                Serie = SolicitarSerie();

            }

            Console.Write("\n\nINGRESO FINALIZADO...");


            //¿SE INGRESARON DATOS?
            if (Cont == 0)
            {
                Console.Write("\nNo se ingresaron datos");
                Console.ReadKey();
                return;
            }

            //MOSTRAMOS EL ARRAY E INDICAMOS MANO DE OBRA COSTOSA SEGÚN CORRESPONDA
            MostrarArray(VectorComponentes, Cont);

            //REALIZAMOS LA BUSQUEDA
            BusquedaDeComponentes(VectorComponentes, Cont);


            Console.Write("\n\nSaliendo del programa...\nPulsa una tecla para continuar");
            Console.ReadKey();

        }

        public static void BusquedaDeComponentes(CComponente[] Vector, int ValoresValidos)
        {
            int i;
            ulong Serie = 0;
            bool Encontrado = false;

            Console.Write("\n\nIngrese el número de serie a buscar (0 para salir): ");
            Serie = SolicitarSerie();

            while (Serie > 0)
            {
                Encontrado = false;

                for (i = 0; i < ValoresValidos; i++)
                {
                    if (Vector[i].ManageSerie == Serie)
                    {
                        Encontrado = true;
                        Vector[i].DarDatos();

                        ModificarCostos(Vector[i]);
                    }
                }

                if (!Encontrado)
                {
                    Console.Write("\nNo se encontró el componente...");
                }

                Console.Write("\n\nIngrese el número de serie a buscar (0 para salir): ");
                Serie = SolicitarSerie();

            }
            


        }

        public static void ModificarCostos(CComponente Componente)
        {
            int Eleccion = 0;
            bool resultado;
            float NuevoCostoComponente = 0F;
            float NuevoCostoManoObra= 0F;

            Console.Write("\n¿Desea modificar algún costo?\n1. Modificar el costo del componente\n2. Modificar el costo de la mano de obra\n0. Salir\nINGRESE: ");
            resultado = int.TryParse(Console.ReadLine(), out Eleccion);

            while (resultado == false || Eleccion > 2 || Eleccion < 0)
            {
                Console.Write("ERROR EN EL INGRESO\nIngrese una opción válida: ");
                resultado = int.TryParse(Console.ReadLine(), out Eleccion);
            }

            if (Eleccion == 1)
            {
                Console.Write($"\nCosto actual del componente: {Componente.ManageCostoComponente}\nNuevo costo del componente: ");
                resultado = float.TryParse(Console.ReadLine(), out NuevoCostoComponente);

                while (resultado == false || NuevoCostoComponente < 0 )
                {
                    Console.Write("\nERROR EN EL INGRESO\nIngrese un costo mayor a 0: ");
                    resultado = float.TryParse(Console.ReadLine(), out NuevoCostoComponente);
                }

                Componente.ManageCostoComponente = NuevoCostoComponente;
                Console.Write("\n¡EL COSTO DEL COMPONENTE FUE MODIFICADO CON ÉXITO!");
            }
            else if (Eleccion == 2)
            {
                Console.Write($"\nCosto actual de la mano de obra: {Componente.ManageCostoManoObra}\nNuevo costo de la mano de obra: ");
                resultado = float.TryParse(Console.ReadLine(), out NuevoCostoManoObra);

                while (resultado == false || NuevoCostoManoObra < 0)
                {
                    Console.Write("\nERROR EN EL INGRESO\nIngrese un costo mayor a 0: ");
                    resultado = float.TryParse(Console.ReadLine(), out NuevoCostoManoObra);
                }

                Componente.ManageCostoManoObra = NuevoCostoManoObra;
                Console.Write("\n¡EL COSTO DE LA MANO DE OBRA FUE MODIFICADA CON ÉXITO!");
            }
            else
            {
                Console.Write("\nSaliendo de la modificación de costos...\nPulsa una tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void MostrarArray(CComponente[] Componente, int ValoresValidos)
        {
            int i;

            for (i = 0; i < ValoresValidos; i++)
            {
                Console.Write("\n" + Componente[i].DarDatos());

                ManoObraCostosa(Componente[i]);
            }
        }

        public static void ManoObraCostosa(CComponente Componente)
        {
            if (Componente.ManageCostoManoObra > (Componente.ManageCostoComponente / 2))
            {
                Console.Write("\n¡MANO DE OBRA COSTOSA!\n-----------------------------------------------------------------------");
            }
        }

        public static float SolicitarCosto()
        {
            float Serie;
            bool resultado;

            resultado = float.TryParse(Console.ReadLine(), out Serie);

            while (resultado == false || Serie < 0 || Serie > 999999999999)
            {

                Console.Write("\n\nError en el ingreso\nIngrese nuevamente: ");
                resultado = float.TryParse(Console.ReadLine(), out Serie);
            }

            return Serie;
        }

        public static string SolicitarString()
        {
            string dato;

            return dato = Console.ReadLine();
            
        }

        public static ulong SolicitarSerie()
        {
            ulong Serie;
            bool resultado;

            resultado = ulong.TryParse(Console.ReadLine(), out Serie);

            while (resultado == false || Serie < 0)
            {

                Console.Write("\n\nError en el ingreso\nIngrese nuevamente: ");
                resultado = ulong.TryParse(Console.ReadLine(), out Serie);
            }

            return Serie;
        }
    }
}
