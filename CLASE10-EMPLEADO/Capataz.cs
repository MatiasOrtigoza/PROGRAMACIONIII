using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    sealed class Capataz:Empleado
    {
        uint numeroMatricula;

        public uint NumeroMatricula { get => numeroMatricula; set => numeroMatricula = value; }

        public Capataz(string DNI, string Nombre, string Apellido, uint NumeroMatricula):base(DNI, Nombre, Apellido)
        {
            this.NumeroMatricula = NumeroMatricula;
        }
    }
}
