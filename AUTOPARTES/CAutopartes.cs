using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AUTOPARTES
{
    internal class CAutopartes: IComparable, IEquatable<CAutopartes>
    {
        static float ganancia;
        int codigo;
        string descripcion;
        float costo;

        public static float Ganancia { get => ganancia; set => ganancia = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Costo { get => costo; set => costo = value; }

        public CAutopartes()
        {
            codigo = 0;
            descripcion = "";
            costo = 0F;
        }

        public CAutopartes(int codigo)
        {
            this.codigo = codigo;
            descripcion = "";
            costo = 0F;
        }

        public CAutopartes(int codigo, string descripcion, float costo)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.costo = costo;
        }

        public float DarPrecio(ushort Cuotas)
        {
            if (Cuotas == 1)
            {
                return PrecioEnVenta();
            }

            float Valor = costo + (costo * (ganancia / 100));

            int i;

            for(i = 1; i < Cuotas; i++)
            {
                Valor = Valor + (Valor * 0.10F);
            }

            return Valor;
        }

        public float PrecioEnVenta()
        {
            return costo + (costo * (ganancia / 100));
        }

        public string DarDatos()
        {
            return $"Ganancia: {ganancia}\nCodigo: {codigo}\nDescripción: {descripcion}\nCosto base: {costo}\nCosto a la venta: {PrecioEnVenta()}";
        }

        public int CompareTo(object obj)
        {
            if (!(obj is CAutopartes))
            {
                return int.MaxValue;
            }

            CAutopartes Autoparte2 = (CAutopartes)obj;

            if (this.Costo < Autoparte2.Costo)
            {
                return -1;
            }
            else if (this.Costo > Autoparte2.Costo)
            {
                return 1;
            }

            return 0;
        }

        public bool Equals(CAutopartes other)
        {
            return this.Codigo == other.Codigo;
        }
    }
}
