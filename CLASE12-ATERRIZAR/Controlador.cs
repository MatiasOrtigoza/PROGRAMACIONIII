using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLASE12_ATERRIZAR
{
    static class Controlador
    {

        static List<PaqueteAuto> ListaPaquetesAuto = new List<PaqueteAuto>();
        static List<PaqueteEstadia> ListaPaquetesEstadia = new List<PaqueteEstadia>();
        static List<Paquete> ListaPaquetes = new List<Paquete>();

        public static bool AgregarPaqueteEstadia(string codigo, string origen, string destino, float precio, string nombreHotel, uint cantidadNoches, float costoHabitacion)
        {

            if (ExistePaqueteEstadia(codigo) == null)
            {
                ListaPaquetesEstadia.Add(new PaqueteEstadia(codigo, origen, destino, precio, nombreHotel, cantidadNoches, costoHabitacion));
                return true;
            }

            return false;

        }

        public static bool AgregarPaqueteAuto(string codigo, string origen, string destino, float precio, string patente, bool contrataSeguro, uint cantidadDias, float costoPorDia)
        {

            if (ExistePaqueteAuto(codigo) == null)
            {
                ListaPaquetesAuto.Add(new PaqueteAuto(codigo, origen, destino, precio, patente, contrataSeguro, cantidadDias, costoPorDia));
                return true;
            }

            return false;

        }

        public static bool AgregarPaqueteEstadiaGeneral(string codigo, string origen, string destino, float precio, string nombreHotel, uint cantidadNoches, float costoHabitacion)
        {

            if (ExistePaquete(codigo) == null)
            {
                ListaPaquetes.Add(new PaqueteEstadia(codigo, origen, destino, precio, nombreHotel, cantidadNoches, costoHabitacion));
                return true;
            }

            return false;

        }

        public static string MostrarListaPaquetesGeneral()
        {
            List<Paquete> AUX = new List<Paquete>();
            AUX = ListaPaquetes;


            string Datos = "DATOS SIN ORDENAR\n\n";

            foreach (Paquete paquete in ListaPaquetes)
            {
                if (paquete is PaqueteEstadia)
                {
                    Datos += (paquete as PaqueteEstadia).DarDatos() + "\n\n";
                }
                else
                {
                    Datos += (paquete as PaqueteAuto).DarDatos() + "\n\n";
                }
            }

            Datos += "\n\nDATOS ORDENADOS\n\n";

            AUX.Sort();


            foreach (Paquete paquete in AUX)
            {
                if (paquete is PaqueteEstadia)
                {
                    Datos += (paquete as PaqueteEstadia).DarDatos() + "\n\n";
                }
                else
                {
                    Datos += (paquete as PaqueteAuto).DarDatos() + "\n\n";
                }
            }

            return Datos;
        }

        public static bool AgregarPaqueteAutoGeneral(string codigo, string origen, string destino, float precio, string patente, bool contrataSeguro, uint cantidadDias, float costoPorDia)
        {

            if (ExistePaquete(codigo) == null)
            {
                ListaPaquetes.Add(new PaqueteAuto(codigo, origen, destino, precio, patente, contrataSeguro, cantidadDias, costoPorDia));
                return true;
            }

            return false;

        }



        public static Paquete ExistePaquete(string Codigo)
        {
            int Indice = ListaPaquetes.IndexOf(new Paquete(Codigo));

            if (Indice == -1)
            {
                return null;
            }

            return ListaPaquetes[Indice];
        }

        public static PaqueteEstadia ExistePaqueteEstadia(string Codigo)
        {
            int Indice = ListaPaquetesEstadia.IndexOf(new PaqueteEstadia(Codigo));

            if (Indice == -1)
            {
                return null;
            }

            return ListaPaquetesEstadia[Indice];
        }

        public static PaqueteAuto ExistePaqueteAuto(string Codigo)
        {
            int Indice = ListaPaquetesAuto.IndexOf(new PaqueteAuto(Codigo));

            if (Indice == -1)
            {
                return null;
            }

            return ListaPaquetesAuto[Indice];
        }

        public static string MostrarListaPaquetesEstadia()
        {
            string Datos = "";

            List<PaqueteEstadia> AUX = ListaPaquetesEstadia;
            AUX.Sort();


            foreach (PaqueteEstadia pestadia in AUX)
            {
                Datos = Datos + pestadia.DarDatos() + "\n\n";
            }

            return Datos;
        }

        public static string MostrarListaPaquetesAuto()
        {
            string Datos = "";

            List<PaqueteAuto> AUX = ListaPaquetesAuto;

            AUX.Sort();

            foreach (PaqueteAuto pauto in AUX)
            {
                Datos = Datos + pauto.DarDatos() + "\n\n";
            }

            return Datos;
        }

        public static string GuardarCSVEstadia(string path)
        {
            string separador = ";";
            StringBuilder datos = new StringBuilder();

            string[] headers = { "Codigo", "Origen", "Destino", "Precio", "NombreHotel", "CantidadNoches", "CostoHabitacion"};

            datos.AppendLine(string.Join(separador, headers));

            
            foreach (PaqueteEstadia pEstadia in ListaPaquetesEstadia)
            {
                /*
                    EJEMPLO CREACION DE DATOS CSV
                 */

                //string[] data = { alumno.Legajo.ToString(), alumno.Nombre, alumno.Apellido, alumno.Email, alumno.CantMateriasAprobadas.ToString(), alumno.Beca.ToString() };
                string[] data = {pEstadia.Codigo, pEstadia.Origen, pEstadia.Destino, pEstadia.Precio.ToString(), pEstadia.NombreHotel, pEstadia.CantidadNoches.ToString(), pEstadia.CostoHabitacion.ToString()};

                datos.AppendLine(string.Join(separador, data));
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

        public static string LeerCSVEstadia(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    List<PaqueteEstadia> ListaAux = new List<PaqueteEstadia>();
                    string encabezado = sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] valores = linea.Split(';');


                        if (valores.Length == 7)
                        {
                            /*
                                EJEMPLO DE LECTURA CSV
                             */

                            //Alumno alumno = new Alumno(uint.Parse(valores[0]), valores[1], valores[2], valores[3], float.Parse(valores[5]), ushort.Parse(valores[4]));
                            PaqueteEstadia pEstadia = new PaqueteEstadia(valores[0], valores[1], valores[2], float.Parse(valores[3]), valores[4], uint.Parse(valores[5]), float.Parse(valores[6])); ;
                            
                            ListaAux.Add(pEstadia);
                        }
                    }

                    ListaPaquetesEstadia = ListaAux;
                    Interfaz.Clear();
                    return "¡Lista cargada con éxito!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
