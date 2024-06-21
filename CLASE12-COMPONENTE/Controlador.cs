using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CLASE12_COMPONENTE
{
    static class Controlador
    {
        static List<Componente> ListaComponentes = new List<Componente>();

        public static bool CargarGPU(ulong numeroDeSerie, string detalle, float CostoComponente, float CostoManoObra, uint ram, float frecuencia, MarcaGPU marca)
        {
            if (ExisteComponente(numeroDeSerie) != null)
            {
                return false;
            }

            ListaComponentes.Add(new PlacaDeVideo(numeroDeSerie, detalle, CostoComponente, CostoManoObra, ram, frecuencia, marca));
            return true;
        }

        public static bool CargarCPU(ulong numeroDeSerie, string detalle, float CostoComponente, float CostoManoObra, float Frecuencia, uint CantidadDeNucleos, MarcaCPU marca)
        {
            if (ExisteComponente(numeroDeSerie) != null)
            {
                return false;
            }

            ListaComponentes.Add(new Procesador(numeroDeSerie, detalle, CostoComponente, CostoManoObra, Frecuencia, CantidadDeNucleos, marca));
            return true;
        }

        public static bool ListaVacia()
        {
            if (ListaComponentes.Count == 0)
            {
                return true;
            }

            return false;
        }

        public static string MostrarLista()
        {
            string Datos = "";

            foreach(Componente componente in ListaComponentes)
            {
                if (componente is Procesador)
                {
                    Procesador cpu = componente as Procesador;

                    Datos = Datos + cpu.DarDatos() + "\n\n";
                }
                else
                {
                    PlacaDeVideo gpu = componente as PlacaDeVideo;
                    Datos = Datos + gpu.DarDatos() + "\n\n";
                }
            }

            return Datos;
        }
        public static string MostrarLista(List<Componente> Lista)
        {
            string Datos = "";

            foreach (Componente componente in Lista)
            {
                if (componente is Procesador)
                {
                    Procesador cpu = componente as Procesador;

                    Datos = Datos + cpu.DarDatos() + "\n\n";
                }
                else
                {
                    PlacaDeVideo gpu = componente as PlacaDeVideo;
                    Datos = Datos + gpu.DarDatos() + "\n\n";
                }
            }

            return Datos;
        }

        public static bool EliminarComponente(ulong NumeroDeSerie)
        {
            return ListaComponentes.Remove(new Componente(NumeroDeSerie));
        }

        public static bool EditarComponente(ulong NumeroDeSerie)
        {

            Componente componente = ExisteComponente(NumeroDeSerie);
            if (componente == null)
            {
                return false;
            }

            bool Resultado;

            Interfaz.Clear();
            Interfaz.Mensaje($"Vas a editar los datos del componente con número de serie {NumeroDeSerie}...");
            Interfaz.Pause();

            if (componente is PlacaDeVideo)
            {
                Resultado = Program.IngresarGPU();
            }
            else
            {
                Resultado = Program.IngresarCPU();
            }

            if (!Resultado)
            {
                return Resultado;
            }

            ListaComponentes.Remove(new Componente(NumeroDeSerie));
            return Resultado;

        }

        public static Componente ExisteComponente(ulong NumeroDeSerie)
        {
            if (ListaComponentes.Count == 0)
            {
                return null;
            }

            int Indice = ListaComponentes.IndexOf(new Componente(NumeroDeSerie));

            if (Indice == -1)
            {
                return null;
            }

            return ListaComponentes[Indice];
        }

        public static string LeerCSV(string path, int modo)
        {
            if (modo != 0 && modo != 1)
            {
                return "Error en el modo de lectura...";
            }

            List<Componente> ListaAUX = new List<Componente>();

            //LECTURA DE UN ARCHIVO DE PLACAS DE VIDEO


            if (modo == 0)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string Datos = "";
                        string header = sr.ReadLine();
                        char separador = ';';
                        while (!sr.EndOfStream)
                        {
                            string linea = sr.ReadLine();
                            string[] vals = linea.Split(separador);

                            ulong NumeroDeSerie = ulong.Parse(vals[0]);
                            string Detalle = vals[1];
                            float CostoComponente = float.Parse(vals[2]);
                            float CostoManoObra = float.Parse(vals[3]);
                            uint RAM = uint.Parse(vals[4]);
                            float Frecuencia = float.Parse(vals[5]);
                            MarcaGPU Marca = Interfaz.DevolverMarcaGPU(vals[6]);

                            ListaAUX.Add(new PlacaDeVideo(NumeroDeSerie, Detalle, CostoComponente, CostoManoObra, RAM, Frecuencia, Marca));
                        }

                        Datos = Controlador.MostrarLista(ListaAUX);
                        Interfaz.Clear();
                        Interfaz.Mensaje("Lista cargada del archivo:\n\n\n" + Datos + "\n\n¿Desea cargarla a la lista actual?\n1 -> Si\n2 -> No");
                        int Opcion = Interfaz.SolicitarOpcion(1, 2);
                        if (Opcion == 1)
                        {
                            foreach (PlacaDeVideo gpu in ListaAUX)
                            {
                                ListaComponentes.Add(gpu);
                            }
                            Interfaz.Clear();
                            return "¡Lista cargada satisfactoriamente!";
                        }

                        return "Finalizando la lectura";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else //LECTURA DE UN ARCHIVO DE PROCESADORES
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string Datos = "";
                        string header = sr.ReadLine();
                        char separador = ';';
                        while (!sr.EndOfStream)
                        {
                            string linea = sr.ReadLine();
                            string[] vals = linea.Split(separador);

                            ulong NumeroDeSerie = ulong.Parse(vals[0]);
                            string Detalle = vals[1];
                            float CostoComponente = float.Parse(vals[2]);
                            float CostoManoObra = float.Parse(vals[3]);
                            float Frecuencia= uint.Parse(vals[4]);
                            uint CantidadDeNucleos = uint.Parse(vals[5]);
                            MarcaCPU Marca = Interfaz.DevolverMarcaCPU(vals[6]);

                            ListaAUX.Add(new Procesador(NumeroDeSerie, Detalle, CostoComponente, CostoManoObra, Frecuencia, CantidadDeNucleos, Marca));
                        }

                        Datos = Controlador.MostrarLista(ListaAUX);
                        Interfaz.Clear();
                        Interfaz.Mensaje("Lista cargada del archivo:\n\n\n" + Datos + "\n\n¿Desea cargarla a la lista actual?\n1 -> Si\n2 -> No");
                        int Opcion = Interfaz.SolicitarOpcion(1, 2);
                        if (Opcion == 1)
                        {
                            foreach (Procesador cpu in ListaAUX)
                            {
                                ListaComponentes.Add(cpu);
                            }

                            Interfaz.Clear();
                            return "¡Lista cargada satisfactoriamente!";
                        }

                        return "Finalizando la lectura";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

        }
    }
}
