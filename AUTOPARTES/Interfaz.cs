using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOPARTES
{
    internal class Interfaz
    {
        public Interfaz(ConsoleColor BG, ConsoleColor FG)
        {
            Console.BackgroundColor = BG;
            Console.ForegroundColor = FG;
        }

        public float SolicitarGanancia()
        {
            float Ganancia;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Ganancia);
            while (!Resultado || Ganancia < 0)
            {
                Mensaje("\nFormato incorrecto.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Ganancia);
            }

            return Ganancia;
        }

        public int SolicitarCodigo()
        {
            int Codigo;
            bool Resultado;

            Resultado = int.TryParse(Console.ReadLine(), out Codigo);
            while (!Resultado || Codigo < -1)
            {
                Mensaje("\nFormato incorrecto.\nIngrese nuevamente: ");
                Resultado = int.TryParse(Console.ReadLine(), out Codigo);
            }

            return Codigo;
        }

        public string SolicitarDescripcion()
        {
            string Descripcion = Console.ReadLine();
            while (Descripcion == "")
            {
                Mensaje("\nLa descripción no puede estar vacía...\nIngrese nuevamente: ");
                Descripcion = Console.ReadLine();
            }

            return Descripcion;
        }

        public float SolicitarCosto()
        {
            float Costo;
            bool Resultado;

            Resultado = float.TryParse(Console.ReadLine(), out Costo);
            while (!Resultado || Costo < 0)
            {
                Mensaje("\nFormato incorrecto.\nIngrese nuevamente: ");
                Resultado = float.TryParse(Console.ReadLine(), out Costo);
            }

            return Costo;
        }

        public ushort SolicitarCuotas()
        {
            ushort Cuotas;
            bool Resultado;

            Resultado = ushort.TryParse(Console.ReadLine(), out Cuotas);
            while (!Resultado || Cuotas < 0)
            {
                Mensaje("\nFormate incorrecto.\nIngrese nuevamente: ");
                Resultado = ushort.TryParse(Console.ReadLine(), out Cuotas);
            }

            return Cuotas;
        }

        public void Mensaje(string Mensaje)
        {
            Console.Write(Mensaje);
        }

        public void Pause()
        {
            Mensaje("\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
