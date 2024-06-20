using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_COMPONENTE
{
    internal class Componente:IEquatable<Componente>
    {
        ulong numeroDeSerie;
        string detalle;
        float costoComponente;
        float costoManoObra;

        public ulong NumeroDeSerie { get => numeroDeSerie; set => numeroDeSerie = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public float CostoComponente { get => costoComponente; set => costoComponente = value; }
        public float CostoManoObra { get => costoManoObra; set => costoManoObra = value; }

        public Componente(ulong numeroDeSerie, string detalle, float CostoComponente, float CostoManoObra)
        {
            this.numeroDeSerie = numeroDeSerie;
            this.detalle = detalle;
            this.costoComponente = CostoComponente;
            this.costoManoObra = CostoManoObra; 
        }

        public Componente(ulong numeroDeSerie)
        {
            this.NumeroDeSerie = numeroDeSerie;
        }

        public float DarPrecio()
        {
            return CostoComponente + CostoManoObra;
        }

        public virtual string DarDatos()
        {
            string Datos = $"Número de serie: {NumeroDeSerie}\nDetalle: {Detalle}\nCosto del componente: {CostoComponente}" +
                $"\nCosto de la mano de obra: {CostoManoObra}\nPrecio final: {DarPrecio()}";

            return Datos;
        }

        public bool Equals(Componente other)
        {
            return this.numeroDeSerie == other.NumeroDeSerie;
        }
    }
}
