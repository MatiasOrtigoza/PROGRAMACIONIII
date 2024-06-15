using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.IO;

namespace CLASE10_PERSONA
{
    internal class ControladorPersona
    {
        List<Alumno> ListadoAlumnos;
        List<Profesor> ListadoProfesores;

        public ControladorPersona()
        {
            ListadoAlumnos = new List<Alumno>();
            ListadoProfesores = new List<Profesor>();
        }

        public string GuardarAlumnosCSV(string path)
        {
            string separador = ";";
            StringBuilder datos = new StringBuilder();
            string[] headers = {"Legajo", "Nombre", "Apellido", "Email", "Cuota", "CantMateriasAprobadas", "Beca"};

            datos.AppendLine(string.Join(separador,headers));

            foreach (Alumno alumno in ListadoAlumnos)
            {
                string[] data = { alumno.Legajo.ToString(), alumno.Nombre, alumno.Apellido, alumno.Email, Alumno.Cuota.ToString(), alumno.CantMateriasAprobadas.ToString(), alumno.Beca.ToString() };

                datos.AppendLine(string.Join(separador,data));
            }

            try
            {
                File.WriteAllText(path, datos.ToString());
                return "¡Guardado satisfactoriamente!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Alumno ExisteAlumno(uint Legajo)
        {
            int Indice = ListadoAlumnos.IndexOf(new Alumno(Legajo));

            if(Indice == -1)
            {
                return null;
            }

            return ListadoAlumnos[Indice];

        }
        public Profesor ExisteProfesor(uint Legajo)
        {
            int Indice = ListadoProfesores.IndexOf(new Profesor(Legajo));

            if (Indice == -1)
            {
                return null;
            }

            return ListadoProfesores[Indice];

        }

        public string MostrarListadoAlumnos()
        {
            string Datos = "";


            foreach(Alumno alumno in ListadoAlumnos)
            {
                Datos = Datos + alumno.MostrarDatos() + "\n";
            }

            return Datos;
        }

        public string MostrarListadoAlumnosOrdenado()
        {
            string Datos = "";
            List<Alumno> AUX = new List<Alumno>();

            AUX = ListadoAlumnos;

            AUX.Sort();

            foreach (Alumno alumno in AUX)
            {
                Datos = Datos + alumno.MostrarDatos() + "\n";
            }

            return Datos;
        }

        public string MostrarListadoProfesores()
        {
            string Datos = "";

            foreach (Profesor profesor in ListadoProfesores)
            {
                Datos = Datos + profesor.MostrarDatos() + "\n";
            }

            return Datos;
        }

        public string MostrarListadoProfesoresOrdenado()
        {
            string Datos = "";
            List<Profesor> AUX = new List<Profesor>();

            AUX = ListadoProfesores;

            AUX.Sort();

            foreach (Profesor profesor in AUX)
            {
                Datos = Datos + profesor.MostrarDatos() + "\n";
            }

            return Datos;
        }


        public bool AgregarAlumno(uint Legajo, string Nombre, string Apellido, string Email, float Beca, ushort CantMateriasAprobadas)
        {
            if(ExisteAlumno(Legajo) != null)
            {
                return false;
            }

            ListadoAlumnos.Add(new Alumno(Legajo, Nombre, Apellido, Email, Beca, CantMateriasAprobadas));
            return true;
        }

        

        public bool AgregarProfesor(uint Legajo, string Nombre, string Apellido, string Email, ushort Antiguedad)
        {
            if (ExisteProfesor(Legajo) != null)
            {
                return false;
            }

            ListadoProfesores.Add(new Profesor(Legajo, Nombre, Apellido, Email, Antiguedad));
            return true;
        }

    }
}
