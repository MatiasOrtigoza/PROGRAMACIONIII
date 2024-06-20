using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLASE12_COMPONENTE
{
    internal class Controlador
    {
        //Instanciar listas

        List<Componente> ListaComponentes;

        //Crear constructor

        public string GuardarXML(string path)
        {
            try
            {
                XmlDocument Document = new XmlDocument();
                XmlDeclaration Declaration = Document.CreateXmlDeclaration("1.0", "UTF-8", null);
                Document.AppendChild(Declaration);

                //Cambiar el nombre de los elementos
                XmlElement raiz = Document.CreateElement("Alumnos");
                Document.AppendChild(raiz);

               // Cambiar la lista
               // foreach (Alumno alumno in ListadoAlumnos)
                {
                    /*
                        EJEMPLO DE CARGA DE DATOS XML
                     */

                    //XmlElement Objeto = Document.CreateElement("Alumno");

                    //XmlElement Legajo = Document.CreateElement("Legajo");
                    //Legajo.InnerText = alumno.Legajo.ToString();
                    //Objeto.AppendChild(Legajo);

                    //raiz.AppendChild(Objeto);
                }

                Document.Save(path);
                return "¡Archivo guardado con éxito!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string LeerXML(string path)
        {
            try
            {
                string Datos = "";
                XmlDocument Document = new XmlDocument();
                Document.Load(path);

                //Cambiar el nombre de los nodos a seleccionar.
                XmlNodeList Nodos = Document.SelectNodes("//Alumno");

                foreach (XmlNode Nodo in Nodos)
                {
                    /*
                        EJEMPLO DE LECTURA DE DATOS XML
                     */

                    //uint Legajo = uint.Parse(Nodo.SelectSingleNode("Legajo").InnerText;

                    //Alumno alumno = new Alumno(Legajo, Nombre, Apellido, Email, Beca, CantMaterias);
                    //Datos = Datos + alumno.MostrarDatos() + "\n";

                    //ListaAux.Add(alumno);
                }

                Interfaz.Mensaje("\n\nEl archivo contiene los siguientes datos: \n\n" + Datos);
                Interfaz.Mensaje("\n\n1 para cargar este archivo a la lista actual.\n2 para salir.\nIngrese: ");
                int Option = int.Parse(Console.ReadLine());
                if (Option == 1)
                {
                    //ListadoAlumnos = ListaAux;
                    return "¡Lista cargada satisfactoriamente!";
                }

                return "¡Lectura finalizada con éxito!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GuardarCSV(string path)
        {
            string separador = ";";
            StringBuilder datos = new StringBuilder();

            //Cambiar headers
            //string[] headers = { "Legajo", "Nombre", "Apellido", "Email", "CantMateriasAprobadas", "Beca" };

            //datos.AppendLine(string.Join(separador, headers));

            //Cambiar el tipo de lista
            //foreach (Alumno alumno in ListadoAlumnos)
            {
                /*
                    EJEMPLO CREACION DE DATOS CSV
                 */

                //string[] data = { alumno.Legajo.ToString(), alumno.Nombre, alumno.Apellido, alumno.Email, alumno.CantMateriasAprobadas.ToString(), alumno.Beca.ToString() };

                //datos.AppendLine(string.Join(separador, data));
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

        public string LeerCSV(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string separador = ";";
                    sb.AppendLine(string.Join(separador, sr.ReadLine().Split(';')));

                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] valores = linea.Split(';');

                        //Depende de la cantidad de datos esperados.
                        //if (valores.Length == 6)
                        {
                            /*
                                EJEMPLO DE LECTURA CSV
                             */

                            //Alumno alumno = new Alumno(uint.Parse(valores[0]), valores[1], valores[2], valores[3], float.Parse(valores[5]), ushort.Parse(valores[4]));
                            //ListaAux.Add(alumno);
                            sb.AppendLine(string.Join(separador, linea.Split(';')));
                        }
                    }

                    Interfaz.Mensaje(sb.ToString() + "\n1 para cargar este archivo de alumnos a la lista actual.\n2 para salir.\nIngrese: ");
                    int Option = int.Parse(Console.ReadLine());

                    if (Option == 1)
                    {
                        //ListadoAlumnos = ListaAux;
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
    }
}
