using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ambulancia ambu = new Ambulancia();
            Perro perro = new Perro();

            Console.Write(perro.Alarma(3));
            Console.Write("\n" + ambu.Alarma(3));
            Console.Write("\n\n");

            Console.Write(MostrarAlarma(perro, 3));
            Console.Write("\n" + MostrarAlarma(ambu, 3));

            Console.ReadLine();

        }

        static string MostrarAlarma(IAlarma objeto, int repeticiones)
        {
            string alarma = objeto.Alarma(repeticiones);
            return alarma;
        }
    }
}
