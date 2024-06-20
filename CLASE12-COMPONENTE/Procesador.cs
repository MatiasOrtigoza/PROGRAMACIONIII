using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_COMPONENTE
{
    internal class Procesador:Componente
    {
        float frecuencia;
        uint cantidadDeNucleos;
        MarcaCPU marca;

        public Procesador(ulong numeroDeSerie, string detalle, float CostoComponente, float CostoManoObra, float frecuencia, uint cantidadDeNucleos, MarcaCPU marca):base(numeroDeSerie, detalle, CostoComponente, CostoManoObra)
        {
            this.Frecuencia = frecuencia;
            this.CantidadDeNucleos = cantidadDeNucleos;
            this.Marca = marca;
        }

        public float Frecuencia { get => frecuencia; set => frecuencia = value; }
        public uint CantidadDeNucleos { get => cantidadDeNucleos; set => cantidadDeNucleos = value; }
        internal MarcaCPU Marca { get => marca; set => marca = value; }

        public override string DarDatos()
        {
            return base.DarDatos() + $"\nFrecuencia: {Frecuencia}\nCantidad de núcleos: {CantidadDeNucleos}\nMarca: {Marca}";
        }
    }
}
