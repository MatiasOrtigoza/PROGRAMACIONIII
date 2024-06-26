using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_ATERRIZAR
{
    internal class PaqueteEstadia:Paquete, IEquatable<PaqueteEstadia>, IComparable<PaqueteEstadia>
    {
        string nombreHotel;
        uint cantidadNoches;
        float costoHabitacion;

        public string NombreHotel { get => nombreHotel; set => nombreHotel = value; }
        public uint CantidadNoches { get => cantidadNoches; set => cantidadNoches = value; }
        public float CostoHabitacion { get => costoHabitacion; set => costoHabitacion = value; }

        public PaqueteEstadia(string codigo, string origen, string destino, float precio, string nombreHotel, uint cantidadNoches, float costoHabitacion):base(codigo, origen, destino, precio)
        {
            this.nombreHotel = nombreHotel;
            this.cantidadNoches = cantidadNoches;
            this.costoHabitacion = costoHabitacion;
        }

        public PaqueteEstadia(string codigo):base(codigo)
        {
            
        }

        public override string DarDatos()
        {
            return base.DarDatos() + $"\nNombre del hotel: {NombreHotel}\nCantidad de noches: {CantidadNoches}\nCosto de la habitación: {CostoHabitacion}";
        }

        public override float DarPrecio(int cuotas)
        {
            return base.DarPrecio(cuotas) + (CantidadNoches * CostoHabitacion);
        }

        public bool Equals(PaqueteEstadia other)
        {
            return Codigo == other.Codigo;
        }

        public int CompareTo(PaqueteEstadia other)
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
    }
}
