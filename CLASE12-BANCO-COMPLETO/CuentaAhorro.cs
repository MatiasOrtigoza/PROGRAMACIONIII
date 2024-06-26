using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_BANCO_COMPLETO
{
    sealed class CuentaAhorro:Cuenta
    {
        static float interesRetorno;
        string planCuenta;
        ulong tarjetaVinculada;

        public string PlanCuenta { get => planCuenta; set => planCuenta = value; }
        public ulong TarjetaVinculada { get => tarjetaVinculada; set => tarjetaVinculada = value; }
        public static float InteresRetorno { get => interesRetorno; set => interesRetorno = value; }

        public CuentaAhorro(ulong CBU, string Cliente, float Saldo, string planCuenta, ulong tarjetaVinculada) : base(CBU, Cliente, Saldo)
{
            this.PlanCuenta = planCuenta;
            this.TarjetaVinculada = tarjetaVinculada;
        }

        public override string DarDatos()
        {
            return base.DarDatos() + $"\nPlan de cuenta: {PlanCuenta}\nTarjeta vinculada: {TarjetaVinculada}\nInterés: {InteresRetorno}";
        }

        public float CalcularInteres(int Meses)
        {
            return ManageSaldo + (ManageSaldo* (InteresRetorno * Meses));
        }

    }
}
