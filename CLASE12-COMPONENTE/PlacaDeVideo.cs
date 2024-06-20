using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_COMPONENTE
{
    internal class PlacaDeVideo:Componente
    {
        uint ram;
        float frecuencia;
        MarcaGPU marca;

        public uint RAM { get => ram; set => ram = value; }
        public float Frecuencia { get => frecuencia; set => frecuencia = value; }
        internal MarcaGPU Marca { get => marca; set => marca = value; }

        public PlacaDeVideo(ulong numeroDeSerie, string detalle, float CostoComponente, float CostoManoObra, uint ram, float frecuencia, MarcaGPU marca):base(numeroDeSerie, detalle, CostoComponente, CostoManoObra)
        {
            this.ram = ram;
            this.frecuencia = frecuencia;
            this.marca = marca;
        }

        public override string DarDatos()
        {
            return base.DarDatos() + $"\nRAM: {RAM}\nFrecuencia: {Frecuencia}\nMarca: {Marca}";
        }
    }
}
