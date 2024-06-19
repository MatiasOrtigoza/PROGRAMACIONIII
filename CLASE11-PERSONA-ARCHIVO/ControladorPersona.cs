using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

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

        public string GuardarAlumnosXML(string path)
        {
            try
            {
                XmlDocument Document = new XmlDocument();
                XmlDeclaration Declaration = Document.CreateXmlDeclaration("1.0", "UTF-8", null);
                Document.AppendChild(Declaration);

                XmlElement raiz = Document.CreateElement("Alumnos");
                Document.AppendChild(raiz);

                foreach (Alumno alumno in ListadoAlumnos)
                {
                    XmlElement Objeto = Document.CreateElement("Alumno");

                    XmlElement Legajo = Document.CreateElement("Legajo");
                    Legajo.InnerText = alumno.Legajo.ToString();
                    Objeto.AppendChild(Legajo);

                    XmlElement Nombre = Document.CreateElement("Nombre");
                    Nombre.InnerText = alumno.Nombre;
                    Objeto.AppendChild(Nombre);

                    XmlElement Apellido = Document.CreateElement("Apellido");
                    Apellido.InnerText = alumno.Apellido;
                    Objeto.AppendChild(Apellido);

                    XmlElement Email = Document.CreateElement("Email");
                    Email.InnerText = alumno.Email;
                    Objeto.AppendChild(Email);

                    XmlElement CantMaterias = Document.CreateElement("CantMateriasAprobadas");
                    CantMaterias.InnerText = alumno.CantMateriasAprobadas.ToString();
                    Objeto.AppendChild(CantMaterias);

                    XmlElement Beca = Document.CreateElement("Beca");
                    Beca.InnerText = alumno.Beca.ToString();
                    Objeto.AppendChild(Beca);

                    raiz.AppendChild(Objeto);
                }

                Document.Save(path);
                return "¡Archivo guardado con éxito!";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string LeerAlumnosXML(string path)
        {
            try
            {
                List <Alumno> ListaAux = new List<Alumno>();
                string Datos = "";
                XmlDocument Document = new XmlDocument();
                Document.Load(path);


                XmlNodeList Nodos = Document.SelectNodes("//Alumno");

                foreach(XmlNode Nodo in Nodos)
                {
                    uint Legajo = uint.Parse(Nodo.SelectSingleNode("Legajo").InnerText);
                    string Nombre = Nodo.SelectSingleNode("Nombre").InnerText;
                    string Apellido = Nodo.SelectSingleNode("Apellido").InnerText;
                    string Email = Nodo.SelectSingleNode("Email").InnerText;
                    ushort CantMaterias = ushort.Parse(Nodo.SelectSingleNode("CantMateriasAprobadas").InnerText);
                    float Beca = float.Parse(Nodo.SelectSingleNode("Beca").InnerText);

                    

                    Alumno alumno = new Alumno(Legajo, Nombre, Apellido, Email, Beca, CantMaterias);
                    Datos = Datos + alumno.MostrarDatos() + "\n";

                    ListaAux.Add(alumno);
                }

                Interfaz.Mensaje("\n\nEl archivo contiene los siguientes datos: \n\n" + Datos);
                Interfaz.Mensaje("\n\n1 para cargar este archivo a la lista actual.\n2 para salir.\nIngrese: ");
                int Option = int.Parse(Console.ReadLine());
                if (Option == 1)
                {
                    ListadoAlumnos = ListaAux;
                    return "¡Lista cargada satisfactoriamente!";
                }

                return "¡Lectura finalizada con éxito!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GuardarAlumnosCSV(string path)
        {
            string separador = ";";
            StringBuilder datos = new StringBuilder();
            string[] headers = {"Legajo", "Nombre", "Apellido", "Email","CantMateriasAprobadas", "Beca"};

            datos.AppendLine(string.Join(separador,headers));

            foreach (Alumno alumno in ListadoAlumnos)
            {
                string[] data = { alumno.Legajo.ToString(), alumno.Nombre, alumno.Apellido, alumno.Email,alumno.CantMateriasAprobadas.ToString(), alumno.Beca.ToString() };

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

        public string LeerAlumnosCSV(string path)
        {
            try
            {
                List <Alumno> ListaAux = new List<Alumno>();

                using (StreamReader sr = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string separador = ";";
                    sb.AppendLine(string.Join(separador, sr.ReadLine().Split(';')));

                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] valores = linea.Split(';');

                        if (valores.Length == 6)
                        {
                            Alumno alumno = new Alumno(uint.Parse(valores[0]), valores[1], valores[2], valores[3], float.Parse(valores[5]), ushort.Parse(valores[4]));
                            ListaAux.Add(alumno);
                            sb.AppendLine(string.Join(separador,linea.Split(';')));
                        }
                    }

                    Interfaz.Mensaje(sb.ToString() + "\n1 para cargar este archivo de alumnos a la lista actual.\n2 para salir.\nIngrese: ");
                    int Option = int.Parse(Console.ReadLine());

                    if (Option == 1)
                    {
                        ListadoAlumnos = ListaAux;
                        return "¡Lista cargada satisfactoriamente!";
                    }

                    return "¡Lectura finalizada con éxito!";


                }
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
