using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO_COMPLETO
{
    class ControladorPaquetes
    {
        List<CPaquete> ListaPaquetes;

        public ControladorPaquetes()
        {
            this.ListaPaquetes = new List<CPaquete>();
        }

        public bool AgregarPaquete(int Numero, string Detalle, float Precio)
        {
            if (ExistePaquete(Numero) != null)
            {
                return false;
            }
            else
            {
                ListaPaquetes.Add(new CPaquete(Numero, Detalle, Precio));
                return true;
            }
        }

        public CPaquete ExistePaquete(int Numero)
        {
            int Indice = ListaPaquetes.IndexOf(new CPaquete(Numero));

            if (Indice == -1)
            {
                return null;
            }

            return ListaPaquetes[Indice];
        }

        public CPaquete PaqueteMasEconomico()
        {
            CPaquete PaqueteEconomico = new CPaquete();

            int Cont = 0;
            foreach (CPaquete Paquete in ListaPaquetes)
            {

                if (Cont == 0)
                {
                    PaqueteEconomico = Paquete;
                    Cont++;
                }

                if (Paquete.GetPrecio() < PaqueteEconomico.GetPrecio())
                {
                    PaqueteEconomico = Paquete;
                }
            }

            if (PaqueteEconomico.GetPrecio() == 0)
            {
                return null;
            }

            return PaqueteEconomico;
        } 

        public void CargarImpuesto(float Impuesto)
        {
            CPaquete.SetImpuesto(Impuesto);
        }

        public bool BorrarPaquete(int Numero)
        {
            CPaquete Paquete = ExistePaquete(Numero);

            if (Paquete is null)
            {
                return false;
            }
            ListaPaquetes.Remove(Paquete);
            return true;
        }

        public bool ModificarPaquete(int Numero)
        {
            Interfaz UI = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.White);
            CPaquete Paquete = ExistePaquete(Numero);

            if (Paquete is null)
            {
                return false;
            }

            UI.MostrarMensaje("\nIngrese la modificación que quiere realizar (NUMERO/DETALLE/PRECIO): ");
            string Mod = UI.SolicitarModificacion();

            if (Mod == "NUMERO")
            {
                int Num;

                UI.MostrarMensaje("\nIngrese el nuevo numero de paquete: ");
                Num = UI.SolicitarNumero();
                
                if (ExistePaquete(Num) is null)
                {
                    Paquete.ManageNumero = Num;
                }
                else
                {
                    return false;
                }
            }
            else if(Mod == "DETALLE")
            {
                Paquete.ManageDetalle = UI.SolicitarDetalle();
            }
            else
            {
                Paquete.SetPrecio(UI.SolicitarPrecio());
            }

            return true;
        }

        public string MostrarLista()
        {
            string Datos = "";

            foreach(CPaquete Paquete in ListaPaquetes)
            {
                Datos = Datos + Paquete.DarDatos() + "\n";
            }

            if (Datos == "")
            {
                return null;
            }

            return Datos;
        }



        
    }
}
