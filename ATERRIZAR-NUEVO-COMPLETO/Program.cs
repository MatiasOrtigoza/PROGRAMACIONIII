using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO_COMPLETO
{
    class Program
    {
        static Interfaz UI = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.White);
        static ControladorPaquetes Controlador = new ControladorPaquetes();

        static void Main(string[] args)
        {
            
            int Opcion;

            UI.MostrarMensaje("\nIngrese el impuesto en porcentaje que se aplicará a todos los paquetes: ");
            Controlador.CargarImpuesto(UI.SolicitarImpuesto());

            Opcion = UI.MostrarMenu();

            while (Opcion != 6)
            {
                switch (Opcion)
                {
                    case 1:
                        CargarPaquete();
                        break;
                    case 2:
                        MostrarPaquetes();
                        break;
                    case 3:
                        Modificacion();
                        break;
                    case 4:
                        Borrar();
                        break;
                    case 5:
                        PaqueteEconomico();
                        break;
                }
                UI.Pause();
                Opcion = UI.MostrarMenu();
            }

            UI.MostrarMensaje("\n\nSaliendo...");
            UI.Pause();
            
        }

        static void Borrar()
        {
            UI.MostrarMensaje("\nIngrese el numero del paquete que quiera borrar: ");
            int Numero = UI.SolicitarNumero();
            bool Operacion = Controlador.BorrarPaquete(Numero);

            if (Operacion)
            {
                UI.MostrarMensaje("\n¡El paquete fue borrado con éxito!");
            }
            else
            {
                UI.MostrarMensaje("\nEl paquete a eliminar no existe.");
            }
        }

        static void PaqueteEconomico()
        {
            CPaquete Economico = Controlador.PaqueteMasEconomico();

            if (Economico is null)
            {
                UI.MostrarMensaje("\nNo hay paquetes cargados.");
                return;
            }

            UI.MostrarMensaje(Economico.DarDatos());

        }

        static void Modificacion()
        {
            UI.MostrarMensaje("\nIngrese el número del paquete que quiere modificar: ");
            int Numero = UI.SolicitarNumero();
            bool Operacion = Controlador.ModificarPaquete(Numero);


            if (Operacion)
            {
                UI.MostrarMensaje("\n¡La modificación se realizó con éxito.!");
            }
            else
            {
                UI.MostrarMensaje("\nEl paquete ingresado no existe o el numero de paquete que se modificó ya existe.");
            }

        }

        static void MostrarPaquetes()
        {
            string Paquetes = Controlador.MostrarLista();

            if (Paquetes is null)
            {
                UI.MostrarMensaje("\nNo hay paquetes cargados.");
            }
            else
            {
                UI.MostrarMensaje(Paquetes);
            }
        }

        static void CargarPaquete()
        {
            int Numero;
            string Detalle;
            float Precio;

            UI.MostrarMensaje("Ingrese el numero del paquete (0-999): ");
            Numero = UI.SolicitarNumero();
            UI.MostrarMensaje("Ingrese el detalle del paquete: ");
            Detalle = UI.SolicitarDetalle();
            UI.MostrarMensaje("Ingrese el precio del paquete: ");
            Precio = UI.SolicitarPrecio();

            if (Controlador.AgregarPaquete(Numero, Detalle, Precio))
            {
                UI.MostrarMensaje("\n¡Paquete ingresado satisfactoriamente!");
            }
            else
            {
                UI.MostrarMensaje("\nEl paquete que quiere ingresar ya existe.");
            }
        }
    }
}
