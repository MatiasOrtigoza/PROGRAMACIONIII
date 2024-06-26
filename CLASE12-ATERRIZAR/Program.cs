using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_ATERRIZAR
{
    internal class Program
    {
        //VARIABLES PARA LA CLASE PADRE Paquete
        static string Codigo;
        static string Origen;
        static string Destino;
        static float Precio;

        static void Main(string[] args)
        {

            Interfaz.Clear();
            Paquete.Interes = Interfaz.SolicitarFloatPositivo("interés de los paquetes");
            PaqueteAuto.CostoSeguro = Interfaz.SolicitarFloatPositivo("costo del seguro de los autos");

            IngresoPaquetesEstadia();

            IngresoPaquetesAuto();

            Interfaz.Clear();
            Interfaz.Mensaje("LISTADO DE PAQUETES ESTADIA\n\n");
            Interfaz.Mensaje(Controlador.MostrarListaPaquetesEstadia());
            Interfaz.Pause();

            Interfaz.Clear();
            Interfaz.Mensaje("LISTADO DE PAQUETES AUTO\n\n");
            Interfaz.Mensaje(Controlador.MostrarListaPaquetesAuto());

            CargaCompartida();
            Interfaz.Mensaje(Controlador.MostrarListaPaquetesGeneral());

            Interfaz.Pause();
        }

        public static void IngresoPaquetesEstadia()
        {
            //VARIABLES PARA LA CLASE PaqueteEstadia
            string NombreHotel;
            uint CantidadNoches;
            float CostoHabitacion;

            ////VARIABLES PARA LA CLASE PADRE Paquete
            //static string Codigo;
            //static string Origen;
            //static string Destino;
            //static float Precio;


            Interfaz.Clear();
            Interfaz.Mensaje("\t\t\t\tINGRESO DE PAQUETE DE ESTADIA...");
            Interfaz.Pause();
            Codigo = Interfaz.SolicitarString("código");

            while (Codigo != "0")
            {
                if (Controlador.ExistePaqueteEstadia(Codigo) == null)
                {
                    Origen = Interfaz.SolicitarString("origen");
                    Destino = Interfaz.SolicitarString("destino");
                    Precio = Interfaz.SolicitarFloatPositivo("precio");
                    NombreHotel = Interfaz.SolicitarString("nombre del hotel");
                    CantidadNoches = Interfaz.SolicitarUInt("cantidad de noches");
                    CostoHabitacion = Interfaz.SolicitarFloatPositivo("costo de la habitación");

                    bool Operacion = Controlador.AgregarPaqueteEstadia(Codigo, Origen, Destino, Precio, NombreHotel, CantidadNoches, CostoHabitacion);

                    Interfaz.Clear();
                    if ( Operacion)
                    {
                        Interfaz.SuccessMensaje("¡Paquete cargado con éxito!");
                    }
                    else
                    {
                        Interfaz.ErrorMensaje("La carga del paquete falló...");
                    }

                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.ErrorMensaje("El código ingresado ya corresponde a otro paquete...");
                }

                Interfaz.Pause();

                Codigo = Interfaz.SolicitarString("código");

            }
        }

        public static void IngresoPaquetesAuto()
        {
            //VARIABLES PARA LA CLASE PaqueteAuto
            string Patente;
            bool ContrataSeguro;
            uint CantidadDias;
            float CostoPorDia;

            ////VARIABLES PARA LA CLASE PADRE Paquete
            //static string Codigo;
            //static string Origen;
            //static string Destino;
            //static float Precio;

            Interfaz.Clear();
            Interfaz.Mensaje("\t\t\t\tINGRESO DE PAQUETE DE AUTOS...");
            Interfaz.Pause();
            Codigo = Interfaz.SolicitarString("código");

            while (Codigo != "0")
            {
                if (Controlador.ExistePaqueteAuto(Codigo) == null)
                {
                    Origen = Interfaz.SolicitarString("origen");
                    Destino = Interfaz.SolicitarString("destino");
                    Precio = Interfaz.SolicitarFloatPositivo("precio");
                    Patente = Interfaz.SolicitarString("patente del auto");
                    ContrataSeguro = Interfaz.SolicitarBooleano("contrata seguro");
                    CantidadDias = Interfaz.SolicitarUInt("cantidad de días a utilizar el auto");
                    CostoPorDia = Interfaz.SolicitarFloatPositivo("costo por día");

                    bool Operacion = Controlador.AgregarPaqueteAuto(Codigo, Origen, Destino, Precio,Patente, ContrataSeguro, CantidadDias, CostoPorDia);

                    Interfaz.Clear();
                    if (Operacion)
                    {
                        Interfaz.SuccessMensaje("¡Paquete cargado con éxito!");
                    }
                    else
                    {
                        Interfaz.ErrorMensaje("La carga del paquete falló...");
                    }

                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.ErrorMensaje("El código ingresado ya corresponde a otro paquete...");
                }

                Interfaz.Pause();

                Codigo = Interfaz.SolicitarString("código");

            }
        }

        public static void CargaCompartida()
        {

            //VARIABLES PARA LA CLASE PaqueteEstadia
            string NombreHotel;
            uint CantidadNoches;
            float CostoHabitacion;

            ////VARIABLES PARA LA CLASE PADRE Paquete
            //static string Codigo;
            //static string Origen;
            //static string Destino;
            //static float Precio;


            Interfaz.Clear();
            Interfaz.Mensaje("\t\t\t\tINGRESO DE PAQUETE DE ESTADIA...");
            Interfaz.Pause();
            Codigo = Interfaz.SolicitarString("código");

            while (Codigo != "0")
            {
                if (Controlador.ExistePaquete(Codigo) == null)
                {
                    Origen = Interfaz.SolicitarString("origen");
                    Destino = Interfaz.SolicitarString("destino");
                    Precio = Interfaz.SolicitarFloatPositivo("precio");
                    NombreHotel = Interfaz.SolicitarString("nombre del hotel");
                    CantidadNoches = Interfaz.SolicitarUInt("cantidad de noches");
                    CostoHabitacion = Interfaz.SolicitarFloatPositivo("costo de la habitación");

                    bool Operacion = Controlador.AgregarPaqueteEstadiaGeneral(Codigo, Origen, Destino, Precio, NombreHotel, CantidadNoches, CostoHabitacion);

                    Interfaz.Clear();
                    if (Operacion)
                    {
                        Interfaz.SuccessMensaje("¡Paquete cargado con éxito!");
                    }
                    else
                    {
                        Interfaz.ErrorMensaje("La carga del paquete falló...");
                    }

                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.ErrorMensaje("El código ingresado ya corresponde a otro paquete...");
                }

                Interfaz.Pause();

                Codigo = Interfaz.SolicitarString("código");

            }

            //VARIABLES PARA LA CLASE PaqueteAuto
            string Patente;
            bool ContrataSeguro;
            uint CantidadDias;
            float CostoPorDia;

            ////VARIABLES PARA LA CLASE PADRE Paquete
            //static string Codigo;
            //static string Origen;
            //static string Destino;
            //static float Precio;

            Interfaz.Clear();
            Interfaz.Mensaje("\t\t\t\tINGRESO DE PAQUETE DE AUTOS...");
            Interfaz.Pause();
            Codigo = Interfaz.SolicitarString("código");

            while (Codigo != "0")
            {
                if (Controlador.ExistePaquete(Codigo) == null)
                {
                    Origen = Interfaz.SolicitarString("origen");
                    Destino = Interfaz.SolicitarString("destino");
                    Precio = Interfaz.SolicitarFloatPositivo("precio");
                    Patente = Interfaz.SolicitarString("patente del auto");
                    ContrataSeguro = Interfaz.SolicitarBooleano("contrata seguro");
                    CantidadDias = Interfaz.SolicitarUInt("cantidad de días a utilizar el auto");
                    CostoPorDia = Interfaz.SolicitarFloatPositivo("costo por día");

                    bool Operacion = Controlador.AgregarPaqueteAutoGeneral(Codigo, Origen, Destino, Precio, Patente, ContrataSeguro, CantidadDias, CostoPorDia);

                    Interfaz.Clear();
                    if (Operacion)
                    {
                        Interfaz.SuccessMensaje("¡Paquete cargado con éxito!");
                    }
                    else
                    {
                        Interfaz.ErrorMensaje("La carga del paquete falló...");
                    }

                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.ErrorMensaje("El código ingresado ya corresponde a otro paquete...");
                }

                Interfaz.Pause();

                Codigo = Interfaz.SolicitarString("código");

            }

        }
    }
}
