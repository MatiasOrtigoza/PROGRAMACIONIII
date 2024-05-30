using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PAQUETE_TURISTICO_ORTIGOZA
{
    internal class CPaquete
    {
        static float Impuesto; // VALOR DEL 0 AL 100
        ushort NumeroPaquete;
        string Detalle;
        float Precio;

        public static void SetImpuesto(float Porcentaje)
        {
            CPaquete.Impuesto = Porcentaje;
        }

        public CPaquete()
        {
            NumeroPaquete = 0;
            Detalle = "undefined";
            Precio = 0F;
        }

        public CPaquete(ushort NumeroPaquete, string Detalle)
        {
            this.Detalle = Detalle;
            this.NumeroPaquete = NumeroPaquete;
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
            return Precio + (Precio * (Impuesto / 100));
        }

        public string MostrarDatos()
        {
            return $"\nImpuesto: {Impuesto}\nNúmero de paquete: {NumeroPaquete}\nDetalle: {Detalle}\nPrecio: {Precio}\nMonto total por pasajero: {DarMontoTotal()}";
        }

        public bool EsMasBaratoQue(CPaquete Paquete2)
        {
            if (this.Precio < Paquete2.Precio)
            {
                return true;
            }

            return false;
        }
    }
}
