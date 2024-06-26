using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ambulancia:IAlarma
    {
        public Ambulancia()
        {
            
        }

        public string Alarma(int repeticiones)
        {
            string ruido = "";

            for (int i = 0; i < repeticiones; i++)
            {
                ruido += "wiiii ";
            }

            return ruido;
        }


    }
}
