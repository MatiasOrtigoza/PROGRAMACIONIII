using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CLASE8_DICCIONARIO
{
    internal class Diccionario
    {
        Hashtable Definiciones;

        public Diccionario(string Palabra, string Definicion)
        {
            Definiciones = new Hashtable();
            Definiciones.Add(Palabra.ToUpper(), Definicion);
        }

        public Diccionario()
        {
            Definiciones = new Hashtable();
        }

        public string GetDefinicion(string Palabra)
        {
            return Definiciones[Palabra.ToUpper()].ToString();
        }

        public bool EliminarPalabra(string Palabra)
        {
            if (Definiciones.ContainsKey(Palabra.ToUpper()))
            {
                Definiciones.Remove(Palabra.ToUpper());
                return true;
            }

            return false;
        }

        public bool ModificarDefinicion(string Palabra)
        {
            if (Definiciones.ContainsKey(Palabra.ToUpper()))
            {
                Console.Write($"\nDefinición actual de {Palabra}: {Definiciones[Palabra.ToUpper()]}\nAgrega la nueva definición: ");
                Definiciones.Remove(Palabra.ToUpper());
                Definiciones.Add(Palabra.ToUpper(), Console.ReadLine());
                return true;    
            }
            return false;
        }

        public bool AgregarPalabra()
        {
            Console.Write("\n¿Cuál es la palabra que querés agregar? ");
            string Palabra = Console.ReadLine();

            if (!Definiciones.ContainsKey(Palabra.ToUpper()))
            {
                Console.Write($"\nIngresa la definición de la palabra {Palabra}: ");
                string Definicion = Console.ReadLine().ToUpper();

                Definiciones.Add(Palabra, Definicion);

                return true;
            }
            else
            {
                return false;
            }

        }

        public string BuscarPalabra(string Palabra)
        {
            Palabra = Palabra.ToUpper();

            if (Definiciones.ContainsKey(Palabra))
            {
                return this.Definiciones[Palabra].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
