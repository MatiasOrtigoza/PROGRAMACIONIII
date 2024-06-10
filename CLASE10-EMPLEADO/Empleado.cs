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

        public virtual string MostrarDatos()
        {
            return $"\nDNI: {DNI}\nNombre: {Nombre}\nApellido: {Apellido}";
        }

        public bool Equals(Empleado other)
        {
            return this.DNI == other.DNI;
        }

        public int CompareTo(Empleado other)
        {
            if (string.Compare(this.Apellido, other.Apellido) == -1 )
            {
                return -1;
            }

            if (string.Compare(this.Apellido, other.Apellido) == 1)
            {
                return 1;
            }

            return 0;
        }
    }
}
