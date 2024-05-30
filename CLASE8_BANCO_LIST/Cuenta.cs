using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CLASE8_BANCO_LIST
{
    internal class Cuenta
    {
        ulong CBU;
        string Cliente;
        float Saldo;

        public ulong ManageCBU { get => CBU; set => CBU = value; }
        public string ManageCliente { get => Cliente; set => Cliente = value; }
        public float ManageSaldo { get => Saldo; set => Saldo = value; }


        public void Depositar(float deposito)
        {
            this.Saldo += deposito;
        }

        public bool Extraer(float monto)
        {
            if (monto <= this.Saldo)
            {
                this.Saldo -= monto;
                return true;
            }
            return false;
        }

        public string DarDatos()
        {
            string datos;

            datos = $"\nCBU: {this.CBU}\nCliente: {this.Cliente}\nSaldo: {this.Saldo}";

            return datos;
        }

        public Cuenta()
        {
            this.CBU = 0U;
            this.Cliente = "undefined";
            this.Saldo = 0F;
        }

        public Cuenta(ulong CBU, string Cliente, float Saldo)
        {
            this.CBU = CBU;
            this.Cliente = Cliente;
            this.Saldo = Saldo;
        }


    }
}
