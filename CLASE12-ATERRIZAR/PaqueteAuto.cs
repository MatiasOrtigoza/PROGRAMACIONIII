using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_ATERRIZAR
{
    internal class PaqueteAuto:Paquete, IEquatable<PaqueteAuto>, IComparable<PaqueteAuto>
    {
        static float costoSeguro;
        string patente;
        bool contrataSeguro;
        uint cantidadDias;
        float costoPorDia;
        public static float CostoSeguro { get => costoSeguro; set => costoSeguro = value; }
        public string Patente { get => patente; set => patente = value; }
        public bool ContrataSeguro { get => contrataSeguro; set => contrataSeguro = value; }
        public uint CantidadDias { get => cantidadDias; set => cantidadDias = value; }
        public float CostoPorDia { get => costoPorDia; set => costoPorDia = value; }


        public PaqueteAuto(string codigo, string origen, string destino, float precio, string patente, bool contrataSeguro, uint cantidadDias, float costoPorDia) :base(codigo, origen,destino, precio)
        {
            this.patente = patente;
            this.contrataSeguro = contrataSeguro;
            this.cantidadDias   = cantidadDias;
            this.costoPorDia = costoPorDia;
        }

        public PaqueteAuto(string codigo):base(codigo)
        {
            
        }

        public override string DarDatos()
        {
            return base.DarDatos() + $"\nCosto del seguro: {PaqueteAuto.CostoSeguro}\nPatente: {Patente}\n¿Contrata seguro?: {ContrataSeguro}\nCantidad de días alquilado: {CantidadDias}\nCosto por día: {CostoPorDia}";
        }

        public override float DarPrecio(int cuotas)
        {
            float Precio = base.DarPrecio(cuotas);
            if (ContrataSeguro)
            {
                Precio += PaqueteAuto.CostoSeguro;
            }

            return Precio += CantidadDias * CostoPorDia;
        }

        public bool Equals(PaqueteAuto other)
        {
            return Codigo == other.Codigo;
        }

        public int CompareTo(PaqueteAuto other)
        {
            if(this.Precio < other.Precio)
            {
                return -1;
            }
            else if (this.Precio > other.Precio)
            {
                return 1;
            }

            return 0;
        }
    }
}
