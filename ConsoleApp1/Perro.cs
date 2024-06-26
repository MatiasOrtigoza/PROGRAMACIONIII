using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Perro:IAlarma

    {
        public Perro()
        {
        }

        public string Alarma(int repeticiones)
        {
            string ladrido = "";

            for (int i = 0; i < repeticiones; i++)
            {
                ladrido += "guau ";
            }

            return ladrido;
        }
    }
}
