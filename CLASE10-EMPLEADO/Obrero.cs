using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    sealed class Obrero : Empleado
    {
        Especialidad especialidad;

        public Especialidad Especialidad { get => especialidad; set => especialidad = value; }

        public Obrero(string DNI, string Nombre, string Apellido, Especialidad Especialidad):base(DNI, Nombre, Apellido)
        {
            this.Especialidad = Especialidad;
        }

        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"\nEspecialidad: {Especialidad}";
        }
    }
}
