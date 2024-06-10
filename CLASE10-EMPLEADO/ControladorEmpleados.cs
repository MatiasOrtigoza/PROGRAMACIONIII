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

        public bool ListaVacia()
        {
            if (ListadoEmpleados.Count() == 0)
            {
                return true;
            }

            return false;
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
            string Datos = "";
            Obrero AUXO;
            Capataz AUXC;


            foreach (Empleado empleado in ListadoEmpleados)
            {
                if (empleado is Obrero)
                {
                    AUXO = (Obrero)empleado;
                    Datos = Datos + AUXO.MostrarDatos() + "\n";
                }
                else
                {
                    AUXC = (Capataz)empleado;
                    Datos = Datos + AUXC.MostrarDatos() + "\n";
                }
            }

            return Datos;
        }

        public string MostrarListadoOrdenado()
        {
            List<Empleado> AUXLISTA = ListadoEmpleados;
            AUXLISTA.Sort();
            string Datos = "";
            Obrero AUXO;
            Capataz AUXC;

            foreach(Empleado empleado in AUXLISTA)
            {
                if (empleado is Obrero)
                {
                    AUXO = (Obrero)empleado;
                    Datos = Datos + AUXO.MostrarDatos() + "\n";
                }
                else
                {
                    AUXC = (Capataz)empleado;
                    Datos = Datos + AUXC.MostrarDatos() + "\n";
                }
            }

            return Datos;
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
            if (ExisteEmpleado(DNI) != null)
            {
                return false;
            }

            ListadoEmpleados.Add(new Obrero(DNI, Nombre, Apellido, Especialidad));

            return true;
        }

        public bool AgregarCapataz(string DNI, string Nombre, string Apellido, uint NumeroMatricula)
        {
            if (ExisteEmpleado(DNI) != null)
            {
                return false;
            }

            ListadoEmpleados.Add(new Capataz(DNI, Nombre, Apellido, NumeroMatricula));

            return true;
        }


    }
}
