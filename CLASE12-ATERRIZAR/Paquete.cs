using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_ATERRIZAR
{
    internal class Paquete: IComparable<Paquete>, IEquatable<Paquete>
    {
        static float interes;
        string codigo;
        string origen;
        string destino;
        float precio;


        public static float Interes { get => interes; set => interes = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }
        public float Precio { get => precio; set => precio = value; }

        public Paquete(string codigo, string origen, string destino, float precio)
        {
            this.codigo = codigo;
            this.origen = origen;
            this.destino = destino;
            this.precio = precio;
        }

        public Paquete(string codigo)
        {
            this.codigo = codigo;
        }

        public virtual float DarPrecio(int cuotas)
        {
            switch (cuotas)
            {
                case 1:
                    return Precio + (Precio * ((Paquete.Interes / 100) * 1));
                case 3:
                    return Precio + (Precio * ((Paquete.Interes / 100) * 3));
                case 6:
                    return Precio + (Precio * ((Paquete.Interes / 100) * 6));
                default:
                    return Precio + (Precio * ((Paquete.Interes / 100) * 12));
            }
        }

        public virtual string DarDatos()
        {
            return $"Código: {Codigo}\nOrigen: {Origen}\nDestino: {Destino}\nPrecio: {Precio}\nInterés: {Paquete.Interes}";
        }

        public int CompareTo(Paquete other)
        {
            if (this.Precio < other.Precio)
            {
                return -1;
            }
            else if(this.Precio > other.Precio)
            {
                return 1;
            }

            return 0;
        }

        public bool Equals(Paquete other)
        {
            return Codigo == other.Codigo;
        }
    }
}
