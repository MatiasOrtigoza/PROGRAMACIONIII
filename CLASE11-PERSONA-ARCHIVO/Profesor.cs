using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_PERSONA
{
    sealed class Profesor:Persona, IComparable, IEquatable<Profesor>
    {
        static float salarioBasico;
        ushort antiguedad;

        public static float SalarioBasico { get => salarioBasico; set => salarioBasico = value; }
        public ushort Antiguedad { get => antiguedad; set => antiguedad = value; }

        public Profesor(uint Legajo, string Nombre, string Apellido, string Email, ushort Antiguedad):base(Legajo, Nombre, Apellido, Email)
        {
            this.Antiguedad = Antiguedad;
        }

        public Profesor(uint Legajo):base(Legajo)
        {
            
        }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"\nSalario básico: ${salarioBasico}\nAntiguedad (años): {Antiguedad}\nSalario final: ${CalcularSalario()}";
        }
        public float CalcularSalario()
        {
            return SalarioBasico + (SalarioBasico * (0.03F * Antiguedad));
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Profesor))
            {
                return int.MaxValue;
            }

            Profesor Profesor2 = (Profesor)obj;

            if (this.CalcularSalario() < Profesor2.CalcularSalario())
            {
                return -1;
            }
            else if (this.CalcularSalario() > Profesor2.CalcularSalario())
            {
                return 1;
            }

            return 0;
        }

        public bool Equals (Profesor other)
        {
            return this.Legajo == other.Legajo;
        }
    }
}
