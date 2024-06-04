using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
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

        public void Depositar(ulong CBU, float Monto)
        {
             ExisteCBU(CBU).Depositar(Monto);
        }

        public bool Extraer(ulong CBU, float Monto)
        {
                return ExisteCBU(CBU).Extraer(Monto);
        }

        public string MostrarCuenta(ulong CBU)
        {
            return ExisteCBU(CBU).DarDatos();
        }

        public string MostrarLista()
        {
            ListaCuentas.Sort();

            string Datos = "";
            int i;

            for (i = 0; i < ListaCuentas.Count(); i++)
            {
                Datos = Datos + $"\nCUENTA NRO {i+1}:\n" + ListaCuentas[i].DarDatos() + "\n";
            }

            return Datos;

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
            int Indice = ListaCuentas.IndexOf(new Cuenta(CBU));

            if (Indice == -1)
            {
                return null;
            }

            return ListaCuentas[Indice];
        }

        public float CalcularInteres(ulong CBU, int Meses)
        {
            return ExisteCBU(CBU).CalcularInteres(Meses);
        }

    }
}
