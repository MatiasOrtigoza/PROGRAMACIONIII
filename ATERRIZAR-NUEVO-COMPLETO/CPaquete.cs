using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATERRIZAR_NUEVO_COMPLETO
{
    class CPaquete:IEquatable<CPaquete>
{
        static float Impuesto;
        int Numero;
        string Detalle;
        float Precio;

        public int ManageNumero { get => Numero; set => Numero = value; }
        public string ManageDetalle { get => Detalle; set => Detalle = value; }

        public static void SetImpuesto(float Impuesto)
        {
            CPaquete.Impuesto = Impuesto;
        }


        public CPaquete()
        {
            this.Detalle = "";
            this.Numero = 0;
            this.Precio = 0;
        }

        public CPaquete(int Numero)
        {
            this.Numero = Numero;
        }

        public CPaquete(int Numero, string Detalle, float Precio)
        {
            this.Numero = Numero;
            this.Detalle = Detalle;
            this.Precio = Precio;
        }

        public CPaquete(int Numero, string Detalle)
        {
            this.Numero = Numero;
            this.Detalle = Detalle;
        }

        public void SetPrecio(float Precio)
        {
            this.Precio = Precio;
        }

        public float GetPrecio()
        {
            return this.Precio;
        }

        public float DarMontoTotal()
        {
            return this.Precio + (this.Precio * (CPaquete.Impuesto / 100));
        }

        public string DarDatos()
        {
            string Datos = "";

            Datos = $"\nImpuesto: {CPaquete.Impuesto}\nNumero: {this.Numero}\nDetalle: {this.Detalle}\nPrecio base: {this.Precio}\nPrecio + impuestos: {this.DarMontoTotal()}";

            return Datos;
        }

        public bool EsMasBaratoQue(CPaquete Paquete2)
        {
            if (this.DarMontoTotal() < Paquete2.DarMontoTotal())
            {
                return true;
            }

            return false;
        }

        public bool Equals(CPaquete other)
        {
            return this.ManageNumero == other.ManageNumero;
        }
    }
}
