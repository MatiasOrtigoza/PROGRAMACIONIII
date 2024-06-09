using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_PERSONA
{
    abstract class Persona: IEquatable<Persona>
    {
        uint legajo;
        string nombre;
        string apellido;
        string email;

        public uint Legajo { get => legajo; set => legajo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }

        protected Persona(uint Legajo, string Nombre, string Apellido, string Email)
        {
            this.Legajo = Legajo;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Email = Email;
        }

        protected Persona(uint Legajo)
        {
            this.Legajo = Legajo;
        }

        public virtual string MostrarDatos()
        {
            return $"\nLegajo: {Legajo}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}";
        }
        public bool Equals(Persona other)
        {
            return Legajo == other.Legajo;
        }
    }
}
