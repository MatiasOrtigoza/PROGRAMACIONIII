using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_PERSONA
{
    internal class Program
    {
        static ControladorPersona Controlador = new ControladorPersona();

        static void Main(string[] args)
        {
            Interfaz.Clear();

            Interfaz.CargarSalarioBasico(Interfaz.SolicitarFloat("salario básico de los profesores"));
            Interfaz.CargarCuota(Interfaz.SolicitarUInt("cuota base para los alumnos"));

            

            Interfaz.Clear();

            Interfaz.Mensaje("\t\t\t\t\t\tINGRESO DE ALUMNOS:\n\n Para finalizar el ingreso ingrese un legajo con valor 0.");
            Interfaz.Pause();
            CargarAlumnos();

            Interfaz.Clear();

            Interfaz.Mensaje("\t\t\t\t\t\tINGRESO DE PROFESORES:\n\n Para finalizar el ingreso ingrese un legajo con valor 0.");
            Interfaz.Pause();
            CargarProfesores();

            Interfaz.Clear();

            Interfaz.Mensaje("\nLISTADO DE ALUMNOS: \n\n");
            Interfaz.Mensaje(Controlador.MostrarListadoAlumnos());

            Interfaz.Mensaje("\nLISTADO DE PROFESORES: \n\n");
            Interfaz.Mensaje(Controlador.MostrarListadoProfesores());

            Interfaz.Mensaje("\nLISTADO DE ALUMNOS ORDENADO: \n\n");
            Interfaz.Mensaje(Controlador.MostrarListadoAlumnosOrdenado());


            Interfaz.Mensaje("\nLISTADO DE PROFESORES ORDENADO: \n\n");
            Interfaz.Mensaje(Controlador.MostrarListadoProfesoresOrdenado());

            Console.ReadKey();
        }

        public static void CargarAlumnos()
        {
            uint Legajo;
            string Nombre;
            string Apellido;
            string Email;
            float Beca;
            ushort CantMateriasAprobadas;

            Legajo = Interfaz.SolicitarUInt("legajo");
            
            while (Legajo != 0)
            {

                if (Controlador.ExisteAlumno(Legajo) == null)
                {
                    Nombre = Interfaz.SolicitarString("nombre");
                    Apellido = Interfaz.SolicitarString("apellido");
                    Email = Interfaz.SolicitarString("email");
                    Beca = Interfaz.SolicitarFloat("beca");
                    CantMateriasAprobadas = Interfaz.SolicitarUShort("cantidad de materias aprobadas");
                    Controlador.AgregarAlumno(Legajo, Nombre, Apellido, Email, Beca, CantMateriasAprobadas);
                }
                else
                {
                    Interfaz.Mensaje($"\nEl alumno con el legajo {Legajo} ya existe...");
                    Interfaz.Pause();
                }

                Interfaz.Clear();
                
                Legajo = Interfaz.SolicitarUInt("legajo");
            }

        }

        public static void CargarProfesores()
        {
            uint Legajo;
            string Nombre;
            string Apellido;
            string Email;
            ushort Antiguedad;

            Legajo = Interfaz.SolicitarUInt("legajo");

            while (Legajo != 0)
            {

                if (Controlador.ExisteProfesor(Legajo) == null)
                {
                    Nombre = Interfaz.SolicitarString("nombre");
                    Apellido = Interfaz.SolicitarString("apellido");
                    Email = Interfaz.SolicitarString("email");
                    Antiguedad = Interfaz.SolicitarUShort("Antigüedad");

                    Controlador.AgregarProfesor(Legajo, Nombre, Apellido, Email, Antiguedad);
                    
                }
                else
                {
                    Interfaz.Mensaje($"\nEl profesor con el legajo {Legajo} ya existe...");
                    Interfaz.Pause();
                }

                Interfaz.Clear();

                Legajo = Interfaz.SolicitarUInt("legajo");
            }

        }
    }
}
