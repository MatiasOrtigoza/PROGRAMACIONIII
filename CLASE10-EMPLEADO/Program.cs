using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE10_EMPLEADO
{
    internal class Program
    {
        static ControladorEmpleados Controlador = new ControladorEmpleados();

        static void Main(string[] args)
        {
            Interfaz.Clear();

            int Opcion;

            Opcion = Interfaz.MostrarMenu();

            switch (Opcion)
            {
                case 1:
                    
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                default:
                    break;
            }


        }
    }
}
