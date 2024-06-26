using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_BANCO_COMPLETO
{
    sealed class CuentaCorriente:Cuenta
    {
        static float montoDescubierto;
        float interesDescubierto;
        
        public static float MontoDescubierto { get => montoDescubierto; set => montoDescubierto = value; }
        public float InteresDescubierto { get => interesDescubierto; set => interesDescubierto = value; }

        public CuentaCorriente(ulong CBU, string Cliente, float Saldo, float interesDescubierto):base(CBU, Cliente, Saldo)  
        {
            this.interesDescubierto= interesDescubierto;
        }

        public override void Depositar(float deposito)
        {
            if (ManageSaldo < 0)
            {
                ManageSaldo += deposito - (deposito * (InteresDescubierto / 100));
                return;
            }

            ManageSaldo *= deposito;
        }

        public override bool Extraer(float monto)
        {
            float MontoRestado = ManageSaldo - monto;

            if (MontoRestado < CuentaCorriente.MontoDescubierto)
            {
                return false;
            }

            ManageSaldo -= monto;
            return true;
        }
    }
}
