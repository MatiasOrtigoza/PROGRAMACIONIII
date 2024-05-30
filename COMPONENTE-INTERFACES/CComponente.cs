using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPONENTE_INTERFACES
{
    internal class CComponente : IEquatable<CComponente>
    {
        ulong Serie;
        string Detalle;
        float CostoComponente;
        float CostoManoObra;

        public CComponente()
        {
            this.Detalle = "A Definir";
        }

        public CComponente(ulong Serie)
        {
            this.Serie = Serie;
        }

        public CComponente(ulong Serie, string Detalle, float CostoComponente, float CostoManoObra)
        {
            this.Serie = Serie;
            this.Detalle = Detalle;
            this.CostoComponente = CostoComponente; 
            this.CostoManoObra = CostoManoObra;
        }

        public ulong ManageSerie { get => Serie; set => Serie = value; }
        public string ManageDetalle { get => Detalle; set => Detalle = value; }
        public float ManageCostoComponente { get => CostoComponente; set => CostoComponente = value; }
        public float ManageCostoManoObra { get => CostoManoObra; set => CostoManoObra = value; }

        public float DarPrecio()
        {
            return CostoComponente + CostoManoObra;
        }

        public string DarDatos()
        {
            return $"\nNúmero de serie: {this.Serie}\nDetalle: {this.Detalle}\nCosto del componente: {this.CostoComponente}\nCosto de la mano de obra: {this.CostoManoObra}";
        }

        public bool Equals(CComponente other)
        {
            return this.ManageSerie == other.ManageSerie;
        }
    }
}
