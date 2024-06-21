using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            while (Opcion != 9)
            {
                switch (Opcion)
                {
                    case 1:
                        if (IngresarGPU())
                        {
                            Interfaz.Clear();
                            Interfaz.SuccessMensaje("¡La carga de la GPU fue realizada con éxito!");
                        }
                        else
                        {
                            Interfaz.Clear();
                            Interfaz.ErrorMensaje("El número de serie ingresado ya existe...");
                        }
                        Interfaz.Pause();
                        break;
                    case 2:
                        Interfaz.Clear();
                        if (IngresarCPU())
                        {
                            Interfaz.Clear();
                            Interfaz.SuccessMensaje("¡La carga de la CPU fue realizada con éxito!");
                        }
                        else
                        {
                            Interfaz.Clear();
                            Interfaz.ErrorMensaje("El número de serie ingresado ya existe...");
                        }
                        Interfaz.Pause();
                        break;
                    case 3:
                        MostrarDatosDelComponente();
                        break;
                    case 4:
                        MostrarDatos();
                        break;
                    case 5:
                        EliminarComponente();
                        break;
                    case 6:
                        EditarComponente();
                        break;
                    case 7:
                        CargarArchivoDeGPUs();
                        break;
                    case 8:
                        break;
                    default:
                        break;
                }
                Interfaz.MostrarMenu();
                Opcion = Interfaz.SolicitarOpcion();
            }
            Interfaz.Clear();
            Interfaz.Mensaje("Saliendo...");
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

        public static bool IngresarGPU()
        {
            ulong NumeroDeSerie     = Interfaz.SolicitarULong("numero de serie");

            if (Controlador.ExisteComponente(NumeroDeSerie) != null)
            {
                return false;
            }

            string Detalle          = Interfaz.SolicitarString("detalle");
            float CostoComponente   = Interfaz.SolicitarFloatPositivo("costo del componente");
            float CostoManoObra     = Interfaz.SolicitarFloatPositivo("costo de la mano de obra");
            uint RAM                = Interfaz.SolicitarUInt("RAM");
            float Frecuencia        = Interfaz.SolicitarFloat("frecuencia");
            MarcaGPU Marca          = Interfaz.SolicitarMarcaGPU();

            return Controlador.CargarGPU(NumeroDeSerie, Detalle, CostoComponente, CostoManoObra, RAM, Frecuencia, Marca);
    }
        public static bool IngresarCPU()
        {
            ulong NumeroDeSerie = Interfaz.SolicitarULong("numero de serie");

            if (Controlador.ExisteComponente(NumeroDeSerie) != null)
            {
                return false;
            }

            string Detalle = Interfaz.SolicitarString("detalle");
            float CostoComponente = Interfaz.SolicitarFloatPositivo("costo del componente");
            float CostoManoObra = Interfaz.SolicitarFloatPositivo("costo de la mano de obra");
            uint CantidadDeNucleos = Interfaz.SolicitarUInt("cantidad de núcleos");
            float Frecuencia = Interfaz.SolicitarFloat("frecuencia");
            MarcaCPU Marca = Interfaz.SolicitarMarcaCPU();

            return Controlador.CargarCPU(NumeroDeSerie, Detalle, CostoComponente, CostoManoObra, Frecuencia, CantidadDeNucleos, Marca);
        }

        public static void MostrarDatosDelComponente()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("La lista está vacía.");
                Interfaz.Pause();
                return;
            }

            ulong NumeroDeSerie = Interfaz.SolicitarULong("número de serie");

            if (Controlador.ExisteComponente(NumeroDeSerie) == null)
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("El número de serie no corresponde a ningún componente registrado.");
                Interfaz.Pause();
                return;
            }

            Interfaz.Mensaje(Controlador.ExisteComponente(NumeroDeSerie).DarDatos());
            Interfaz.Pause();
            return;
        }
        public static void MostrarDatos()
        {
            string Datos = Controlador.MostrarLista();

            Interfaz.Clear();
            if (Datos == "")
            {
                Interfaz.ErrorMensaje("La lista está vacía.");
                Interfaz.Pause();
                return;
            }
            Interfaz.Mensaje(Datos);
            Interfaz.Pause();
        }

        public static void EliminarComponente()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("La lista está vacía.");
                Interfaz.Pause();
                return;
            }

            ulong NumeroDeSerie = Interfaz.SolicitarULong("número de serie");

            bool Resultado = Controlador.EliminarComponente(NumeroDeSerie);

            Interfaz.Clear();

            if (!Resultado)
            {
                Interfaz.ErrorMensaje("El número de serie ingresado no corresponde a ningún componente registrado...");
                Interfaz.Pause();
                return;
            }

            Interfaz.SuccessMensaje("¡Componente eliminado con éxito!");
            Interfaz.Pause();
        }

        public static void EditarComponente()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("La lista está vacía.");
                Interfaz.Pause();
                return;
            }

            ulong NumeroDeSerie = Interfaz.SolicitarULong("número de serie");

            if (Controlador.ExisteComponente(NumeroDeSerie) == null)
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("El número de serie ingresado no corresponde a ningún componente registrado...");
                Interfaz.Pause();
                return;
            }

            bool Resultado = Controlador.EditarComponente(NumeroDeSerie);

            Interfaz.Clear();
            if (!Resultado)
            {
                Interfaz.ErrorMensaje("El número de serie ingresado ya corresponde a otro componente registrado...");
                Interfaz.Pause();
                return;
            }

            Interfaz.SuccessMensaje("¡Componente editado con éxito!");
            Interfaz.Pause();
        }

        public static void CargarArchivoDeGPUs()
        {
            string path = Interfaz.SolicitarRuta();
            string Resultado;

            //El 0 es para indicar que se están leyendo placas de vídeo
            //1 es para indicar que se están leyendo procesadores.
            Resultado = Controlador.LeerCSV(path, 0);

            Interfaz.Clear();
            Interfaz.Mensaje(Resultado);
            Interfaz.Pause();
        }
    }
}
