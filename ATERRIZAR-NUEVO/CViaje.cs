using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO
{
    internal class CViaje
    {
        string Codigo;
        string Origen;
        string Destino;
        float Precio;

        public float PrecioViaje { get => Precio; set => Precio = value; }

        public CViaje(string Codigo, string Origen, string Destino)
        {
            this.Codigo = Codigo;
            this.Origen = Origen;
            this.Destino = Destino;
        }

        public CViaje()
        {
            this.Codigo = "undefined";
            this.Origen = "undefined";
            this.Destino = "undefined";
            this.Precio = 0F;
        }

        public string GetOrigen()
        {
            return this.Origen;
        }

        public string GetDestino()
        {
            return this.Destino;
        }

        public string GetCodigo()
        {
            return this.Codigo;
        }

        public float DarPrecio(int Cuotas)
        {
            switch (Cuotas)
            {
                case 1:
                    return this.Precio;
                case 3:
                    return this.Precio * 1.1F;
                case 6:
                    return this.Precio * 1.2F;
                case 12:
                    return this.Precio * 1.4F;
                default:
                    return -1;
            }
        }

        public string DarDatos()
        {
            return $"\nCodigo: {this.Codigo}\nOrigen: {this.Origen}\nDestino: {this.Destino}\nPrecio base: {PrecioViaje}\n\n";
        }
    }
}
