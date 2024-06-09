using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    internal class Empleado:IEquatable<Empleado>, IComparable<Empleado>
    {
        string dni;
        string nombre;
        string apellido;

        public string DNI { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Empleado(string DNI, string Nombre, string Apellido)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }

        public Empleado(string DNI)
        {
            this.DNI = DNI;
        }

        public bool Equals(Empleado other)
        {
            return this.DNI == other.DNI;
        }

        public int CompareTo(Empleado other)
        {
            if (int.Parse(this.DNI) < int.Parse(other.DNI))
            {
                return -1;
            }

            if (int.Parse(this.DNI) > int.Parse(other.DNI))
            {
                return 1;
            }

            return 0;
        }
    }
}
