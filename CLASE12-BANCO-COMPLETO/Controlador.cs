using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLASE12_BANCO_COMPLETO
{
    static class Controlador
    {
        //Instanciar listas estáticas
        static List<Cuenta> ListaCuentas = new List<Cuenta>();

        public static Cuenta ExisteCuenta(ulong CBU)
        {
            int indice = ListaCuentas.IndexOf(new Cuenta(CBU));
            if (indice == -1)
            {
                return null;
            }

            return ListaCuentas[indice];
        }

        public static bool AgregarCuentaAhorro(ulong CBU, string Cliente, float Saldo, string planCuenta, ulong tarjetaVinculada)
        {
            if (ExisteCuenta(CBU) != null)
            {
                return false;
            }

            ListaCuentas.Add(new CuentaAhorro(CBU, Cliente, Saldo, planCuenta, tarjetaVinculada));
            return true;
        }

        public static bool AgregarCuentaCorriente(ulong CBU, string Cliente, float Saldo,float interesDescubierto)
        {
            if (ExisteCuenta(CBU) != null)
            {
                return false;
            }

            ListaCuentas.Add(new CuentaCorriente(CBU, Cliente, Saldo, interesDescubierto));
            return true;
        }

        public static string MostrarListado()
        {
            string Datos = "";

            ListaCuentas.Sort();

            foreach (Cuenta cuenta in ListaCuentas)
            {
                if (cuenta is CuentaAhorro)
                {
                    Datos += (cuenta as CuentaAhorro).DarDatos() + "\n\n";
                }
                else
                {
                    Datos += (cuenta as CuentaCorriente).DarDatos() + "\n\n";
                }
            }

            return Datos;
        }

        public static string MostrarCuenta(ulong CBU)
        {
            Cuenta cuenta = ExisteCuenta(CBU);

            if (cuenta == null)
            {
                return "NOTFOUND";
            }

            if (cuenta is CuentaAhorro)
            {
                cuenta = (CuentaAhorro)cuenta;
            }
            else
            {
                cuenta = (CuentaCorriente)cuenta;
            }

            string Datos = cuenta.DarDatos();

            return Datos;
        }

        public static string GuardarXML(string path)
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

        public static string LeerXML(string path)
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

        public static string GuardarCSV(string path)
        {

            string separador = ";";
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] headers = { "CBU", "Cliente", "Saldo", "InteresDescubierto" };
                sb.AppendLine(string.Join(separador, headers));

                foreach (Cuenta cuenta in ListaCuentas)
                {
                    if (cuenta is CuentaCorriente)
                    {
                        string[] datos = {
                            cuenta.ManageCBU.ToString(),
                            cuenta.ManageCliente,
                            cuenta.ManageSaldo.ToString(),
                            (cuenta as CuentaCorriente).InteresDescubierto.ToString()
                        };

                        sb.AppendLine(string.Join(separador, datos));
                    }
                }

                File.WriteAllText(path + "\\ListaCuentaCorriente.csv", sb.ToString());

                sb.Clear();

                string[] headersAhorro = { "CBU", "Cliente", "Saldo", "PlanCuenta", "TarjetaVinculada" };
                sb.AppendLine(string.Join(separador, headersAhorro));

                foreach (Cuenta cuenta in ListaCuentas)
                {
                    if (cuenta is CuentaAhorro)
                    {
                        string[] datos = {
                            cuenta.ManageCBU.ToString(),
                            cuenta.ManageCliente,
                            cuenta.ManageSaldo.ToString(),
                            (cuenta as CuentaAhorro).PlanCuenta,
                            (cuenta as CuentaAhorro).TarjetaVinculada.ToString()
                        };

                        sb.AppendLine(string.Join(separador, datos));
                    }
                }

                File.WriteAllText(path + "\\ListaCuentaAhorro.csv", sb.ToString());

                return $"Archivos generados correctamente en {path}";
            }
            catch (Exception ex) {
                return ex.Message;
            }
            

        }

        public static string LeerCSV(string path)
        {
            return "";
        }
    }
}
