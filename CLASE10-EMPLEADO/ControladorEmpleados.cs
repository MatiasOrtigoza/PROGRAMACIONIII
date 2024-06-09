using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    internal class ControladorEmpleados
    {
        List<Empleado> ListadoEmpleados;

        public ControladorEmpleados()
        {
            ListadoEmpleados = new List<Empleado>();
        }

        public Empleado ExisteEmpleado(string DNI)
        {
            int Indice = ListadoEmpleados.IndexOf(new Empleado(DNI));

            if(Indice == -1)
            {
                return null;
            }
            
            return ListadoEmpleados[Indice];

        }

        public string MostrarListado()
        {
            string Datos;

            foreach (Empleado empleado in ListadoEmpleados)
            {
                if (empleado is Obrero)
                {

                }
            }
        }

        public string MostrarListadoOrdenado()
        {

        }

        public bool RemoverEmpleado(string DNI)
        {
            Empleado empleado = ExisteEmpleado(DNI);

            if (empleado == null)
            {
                return false;
            }

            ListadoEmpleados.Remove(empleado);

            return true;
        }

        public bool EditarObrero(string DNI, string Nombre, string Apellido, Especialidad Especialidad)
        {
            Obrero obrero = (Obrero)ExisteEmpleado(DNI);

            if (obrero == null)
            {
                return false;
            }

            obrero.DNI = DNI;
            obrero.Nombre = Nombre;
            obrero.Apellido = Apellido;
            obrero.Especialidad = Especialidad;

            return true;
        }

        public bool EditarCapataz(string DNI, string Nombre, string Apellido, uint NumeroMatricula)
        {
            Capataz capataz = (Capataz)ExisteEmpleado(DNI);

            if (capataz == null)
            {
                return false;
            }

            capataz.DNI = DNI;
            capataz.Nombre = Nombre;
            capataz.Apellido = Apellido;
            capataz.NumeroMatricula = NumeroMatricula;

            return true;
        }

        public bool AgregarObrero(string DNI, string Nombre, string Apellido, Especialidad Especialidad)
        {
            if (ExisteEmpleado(DNI) == null)
            {
                return false;
            }

            ListadoEmpleados.Add(new Obrero(DNI, Nombre, Apellido, Especialidad));

            return true;
        }

        public bool AgregarCapataz(string DNI, string Nombre, string Apellido, uint NumeroMatricula)
        {
            if (ExisteEmpleado(DNI) == null)
            {
                return false;
            }

            ListadoEmpleados.Add(new Capataz(DNI, Nombre, Apellido, NumeroMatricula));

            return true;
        }


    }
}
