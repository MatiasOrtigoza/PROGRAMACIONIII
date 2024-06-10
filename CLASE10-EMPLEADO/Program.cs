using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    internal class Program
    {
        static ControladorEmpleados Controlador = new ControladorEmpleados();

        static void Main(string[] args)
        {
            int Opcion;

            Opcion = Interfaz.MostrarMenu();

            while(Opcion != 7)
            {
                switch (Opcion)
                {
                    case 1:
                        ListarEmpleados();
                        break;
                    case 2:
                        AgregarObrero();
                        break;
                    case 3:
                        AgregarCapataz();
                        break;
                    case 4:
                        RemoverEmpleado();
                        break;
                    case 5:
                        EditarObrero();
                        break;
                    case 6:
                        EditarCapataz();
                        break;
                    default:
                        break;
                }

                Opcion = Interfaz.MostrarMenu();
                
            }
                


        }

        public static void ListarEmpleados()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.Mensaje("La lista está vacía...");
                Interfaz.Pause();
                return;
            }

            int Opcion = Interfaz.SolicitarTipoDeOrdenamiento();

            Interfaz.Clear();

            if(Opcion == 1)
            {
                Interfaz.Mensaje(Controlador.MostrarListado());
                Interfaz.Pause();
            }
            else
            {
                Interfaz.Mensaje(Controlador.MostrarListadoOrdenado());
                Interfaz.Pause();
            }
        }

        public static void AgregarObrero()
        {
            string DNI;
            string Nombre;
            string Apellido;
            Especialidad Especialidad;

            Interfaz.Clear();
            Interfaz.Mensaje("REGISTRO DE OBREROS.\n\nIngrese un DNI con valor 0 para salir.");
            Interfaz.Pause();

            DNI = Interfaz.SolicitarString("DNI");

            while (DNI != "0")
            {

                if (Controlador.ExisteEmpleado(DNI) == null)
                {
                    Nombre = Interfaz.SolicitarString("nombre");
                    Apellido = Interfaz.SolicitarString("apellido");
                    Especialidad = Interfaz.SolicitarEspecialidad();

                    Controlador.AgregarObrero(DNI, Nombre, Apellido, Especialidad);

                    Interfaz.Clear();
                    Interfaz.Mensaje("¡Obrero registrado con éxito!");
                    Interfaz.Pause();
                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.Mensaje("El DNI ingresado ya pertenece a un obrero registrado...");
                    Interfaz.Pause();
                }
                

                Interfaz.Clear();
                DNI = Interfaz.SolicitarString("DNI");
            }

            Interfaz.Clear();
            Interfaz.Mensaje("Saliendo del registro de obreros...");
            Interfaz.Pause();

        }

        public static void AgregarCapataz()
        {
            string DNI;
            string Nombre;
            string Apellido;
            uint NumeroMatricula;

            Interfaz.Clear();
            Interfaz.Mensaje("REGISTRO DE CAPATACES.\n\nIngrese un DNI con valor 0 para salir.");
            Interfaz.Pause();

            DNI = Interfaz.SolicitarString("DNI");

            while (DNI != "0")
            {

                if (Controlador.ExisteEmpleado(DNI) == null)
                {
                    Nombre = Interfaz.SolicitarString("nombre");
                    Apellido = Interfaz.SolicitarString("apellido");
                    NumeroMatricula = Interfaz.SolicitarUInt("número de matrícula profesional");

                    Controlador.AgregarCapataz(DNI, Nombre, Apellido, NumeroMatricula);

                    Interfaz.Clear();
                    Interfaz.Mensaje("¡Capataz registrado con éxito!");
                    Interfaz.Pause();
                }
                else
                {
                    Interfaz.Clear();
                    Interfaz.Mensaje("El DNI ingresado ya pertenece a un capataz registrado...");
                    Interfaz.Pause();
                }


                Interfaz.Clear();
                DNI = Interfaz.SolicitarString("DNI");
            }

            Interfaz.Clear();
            Interfaz.Mensaje("Saliendo del registro de obreros...");
            Interfaz.Pause();

        }

        public static void RemoverEmpleado()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.Mensaje("La lista está vacía...");
                Interfaz.Pause();
                return;
            }

            Interfaz.Clear();
            Interfaz.Mensaje("SECCIÓN REMOVER UN EMPLEADO\n\nIngrese el DNI del empleado a remover.");
            Interfaz.Pause();

            string DNI = Interfaz.SolicitarString("DNI");

            if (Controlador.RemoverEmpleado(DNI))
            {
                Interfaz.Clear();
                Interfaz.Mensaje($"¡El empleado con DNI {DNI} ha sido removido con éxito del sistema!");
                Interfaz.Pause();
            }
            else
            {
                Interfaz.Clear();
                Interfaz.Mensaje($"El empleado con DNI {DNI} no está registrado en el sistema.");
                Interfaz.Pause();
            }
        }

        public static void EditarObrero()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.Mensaje("La lista está vacía...");
                Interfaz.Pause();
                return;
            }

            Interfaz.Clear();
            Interfaz.Mensaje("SECCIÓN EDITAR UN OBRERO\n\nIngrese el DNI del obrero a editar.");
            Interfaz.Pause();

            string DNI;
            string Nombre;
            string Apellido;
            Especialidad Especialidad;


            DNI = Interfaz.SolicitarString("DNI");

            if (Controlador.ExisteEmpleado(DNI) != null)
            {
                Nombre = Interfaz.SolicitarString("nombre");
                Apellido = Interfaz.SolicitarString("apellido");
                Especialidad = Interfaz.SolicitarEspecialidad();

                Controlador.EditarObrero(DNI, Nombre, Apellido, Especialidad);

                Interfaz.Clear();
                Interfaz.Mensaje("¡Obrero editado con éxito!");
                Interfaz.Pause();
            }
            else
            {
                Interfaz.Clear();
                Interfaz.Mensaje($"El empleado con DNI {DNI} no está registrado en el sistema.");
                Interfaz.Pause();
            }
        }

        public static void EditarCapataz()
        {
            if (Controlador.ListaVacia())
            {
                Interfaz.Clear();
                Interfaz.Mensaje("La lista está vacía...");
                Interfaz.Pause();
                return;
            }

            Interfaz.Clear();
            Interfaz.Mensaje("SECCIÓN EDITAR UN CAPATAZ\n\nIngrese el DNI del obrero a editar.");
            Interfaz.Pause();

            string DNI;
            string Nombre;
            string Apellido;
            uint NumeroMatricula;

            DNI = Interfaz.SolicitarString("DNI");

            if (Controlador.ExisteEmpleado(DNI) != null)
            {
                Nombre = Interfaz.SolicitarString("nombre");
                Apellido = Interfaz.SolicitarString("apellido");
                NumeroMatricula = Interfaz.SolicitarUInt("número de matrícula profesional");

                Controlador.EditarCapataz(DNI, Nombre, Apellido, NumeroMatricula);

                Interfaz.Clear();
                Interfaz.Mensaje("¡Capataz editado con éxito!");
                Interfaz.Pause();
            }
            else
            {
                Interfaz.Clear();
                Interfaz.Mensaje($"El empleado con DNI {DNI} no está registrado en el sistema.");
                Interfaz.Pause();
            }
        }
    }
}
