using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CLASE8_BANCO_LIST
{
    internal class ControladorCuentas
    {
        private List<Cuenta> ListaCuentas;

        public ControladorCuentas()
        {
            ListaCuentas = new List<Cuenta>();
        }

        public bool AgregarCuenta(ulong CBU, string Cliente, float Saldo)
        {
            if (ExisteCBU(CBU) == null)
            {
                ListaCuentas.Add(new Cuenta(CBU, Cliente, Saldo));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Depositar(ulong CBU, float Monto)
        {
            if (ExisteCBU(CBU) != null)
            {
                ExisteCBU(CBU).Depositar(Monto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Extraer(ulong CBU, float Monto)
        {
            if (ExisteCBU(CBU) != null)
            {
                return ExisteCBU(CBU).Extraer(Monto); 
            }

            return false;
        }

        public string MostrarCuenta(ulong CBU)
        {
            if (ExisteCBU(CBU) != null)
            {
                return ExisteCBU(CBU).DarDatos();
            }
            else
            {
                return "\nEl CBU no existe.\n";
            }
        }

        public string MostrarLista()
        {
            string Datos = "";
            int i;

            for (i = 0; i < ListaCuentas.Count(); i++)
            {
                Datos = Datos + $"\nCUENTA NRO {i+1}:\n" + ListaCuentas[i].DarDatos() + "\n";
            }

            if (Datos != "")
            {
                return Datos;
            }
            else
            {
                return "\nNo hay cuentas para mostrar.\n";
            }

        }

        public bool EliminarCuenta(ulong CBU)
        {
            if (ExisteCBU(CBU) != null)
            {
                ListaCuentas.Remove(ExisteCBU(CBU));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ListaVacia()
        {
            if (ListaCuentas.Count() == 0)
            {
                return true;
            }

            return false;
        }

        public Cuenta ExisteCBU(ulong CBU)
        {
            int i;

            for (i = 0; i < ListaCuentas.Count(); i++)
            {
                if (ListaCuentas[i].ManageCBU == CBU)
                {
                    return ListaCuentas[i];
                }
            }

            return null;
        }

    }
}
