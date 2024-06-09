using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_PERSONA
{
    sealed class Alumno:Persona, IComparable, IEquatable<Alumno>
    {
        static uint cuota;
        ushort cantMateriasAprobadas;
        float beca;

        public static uint Cuota { get => cuota; set => cuota = value; }
        public ushort CantMateriasAprobadas { get => cantMateriasAprobadas; set => cantMateriasAprobadas = value; }
        public float Beca { get => beca; set => beca = value; }

        public Alumno(uint Legajo, string Nombre, string Apellido, string Email, float Beca, ushort CantMateriasAprobadas):base(Legajo, Nombre, Apellido, Email)
        {
            this.Beca = Beca;
            this.CantMateriasAprobadas = CantMateriasAprobadas;
        }

        public Alumno(uint Legajo):base(Legajo)
        {
        }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"\nCantidad de materias aprobadas: {CantMateriasAprobadas}\nCuota base: ${Cuota}\nBeca: {Beca}" +
                $"\nCuota final: ${CalcularCuota()}";
        }

        public float CalcularCuota()
        {
            return cuota - (cuota * (beca / 100));
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Alumno))
            {
                return int.MaxValue;
            }

            Alumno Alumno2 = (Alumno)obj;

            if (this.CalcularCuota() < Alumno2.CalcularCuota())
            {
                return -1;
            }
            else if(this.CalcularCuota() > Alumno2.CalcularCuota())
            {
                return 1;
            }

            return 0;
        }

        public bool Equals(Alumno other)
        {
            return this.Legajo == other.Legajo;
        }
    }
}
