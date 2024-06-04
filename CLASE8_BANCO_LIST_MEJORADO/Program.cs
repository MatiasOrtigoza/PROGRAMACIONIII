using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLASE8_BANCO_LIST
{
    internal class Program
    {
        static Interfaz UI = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.White);
        static ControladorCuentas Control = new ControladorCuentas();
        static ulong CBU;

        static void Main(string[] args)
        {
            int Opcion; 

            UI.Mensaje("\nIngres el porcentaje de interés mensual: ");
            Cuenta.ManageInteresMensual = UI.SolicitarPorcentaje();

            Opcion = UI.MostrarMenu();

            while (Opcion != 8)
            {
                UI.Clear();
                if (Opcion == 1)
                {
                    AgregarCuenta();
                }
                else if (Opcion == 2) 
                {
                    Deposito();
                }
                else if (Opcion == 3)
                {
                    Extraccion();
                }
                else if (Opcion == 4)
                {
                    MostrarDatos();
                }
                else if (Opcion == 5)
                {
                    MostrarLista();
                }
                else if (Opcion == 6)
                {
                    RemoverCuenta();
                }
                else if (Opcion == 7)
                {
                    EstimarInteres();
                }
                UI.PressKeyToContinue();
                Opcion = UI.MostrarMenu();
            }

            UI.Mensaje("\nSaliendo del programa.\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void AgregarCuenta()
        {
            float Saldo;
            string Cliente;

            UI.Mensaje("\nIngrese el CBU a crear: ");
            CBU = UI.SolicitarCBU();
            UI.Mensaje("\nIngrese el saldo inicial: ");
            Saldo = UI.SolicitarSaldo();
            UI.Mensaje("\nIngrese el nombre del cliente: ");
            Cliente = UI.SolicitarNombre();
            
            if (!Control.AgregarCuenta(CBU, Cliente, Saldo))
            {
                UI.Mensaje("\nLa cuenta ya existe...\n");
                return;
            }
            UI.Mensaje("\n¡Cuenta agregada satisfactoriamente!\n");
        }

        static void Deposito()
        {
            float Monto;

            if (Control.ListaVacia())
            {
                UI.Mensaje("\nNo hay cuentas cargadas.");
                return;
            }

            UI.Mensaje("\nIngrese el CBU al que quiere depositar: ");
            CBU = UI.SolicitarCBU();
            if (Control.ExisteCBU(CBU) == null)
            {
                UI.Mensaje("\nNo existe el CBU al que quiere depositar");
                return;
            }

            UI.Mensaje("\nIngrese el monto a depositar: ");
            Monto = UI.SolicitarSaldo();
            Control.Depositar(CBU, Monto);
            UI.Mensaje("\n¡Depósito realizado con éxito!\n");
        }

        static void Extraccion()
        {
            float Monto;

            if (Control.ListaVacia())
            {
                UI.Mensaje("\nNo hay cuentas cargadas.");
                return;
            }

            UI.Mensaje("\nIngrese el CBU del que quiere extraer: ");
            CBU = UI.SolicitarCBU();

            if (Control.ExisteCBU(CBU) == null)
            {
                UI.Mensaje("\nEl CBU no existe...\n");
                return;
            }

            UI.Mensaje("\nIngrese el monto a extraer: ");
            Monto = UI.SolicitarSaldo();

            if (!Control.Extraer(CBU, Monto))
            {
                UI.Mensaje("\nEl monto es mayor al saldo disponible...");
                return;
            }

            UI.Mensaje("\n!La extracción fue realizada con éxito!");
        }

        static void MostrarDatos()
        {

            if (Control.ListaVacia())
            {
                UI.Mensaje("\nNo hay cuentas cargadas.");
                return;
            }

            UI.Mensaje("\nIngrese el CBU para ver sus datos: ");
            CBU = UI.SolicitarCBU();
            if (Control.ExisteCBU(CBU) == null)
            {
                UI.Mensaje("\nNo existe el CBU ingresado...");
                return;
            }

            UI.Mensaje(Control.MostrarCuenta(CBU));
        }

        static void MostrarLista()
        {
            if (Control.MostrarLista() == "")
            {
                UI.Mensaje("\nLa lista está vacía");
                return;
            }

            UI.Mensaje(Control.MostrarLista());
        }

        static void RemoverCuenta()
        {
            if (Control.ListaVacia())
            {
                UI.Mensaje("\nNo hay cuentas cargadas.");
                return;
            }

            UI.Mensaje("\nIngrese el CBU a remover: ");
            CBU = UI.SolicitarCBU();

            if (!Control.EliminarCuenta(CBU))
            {
                UI.Mensaje("\nLa cuenta no existe.\n");
                return;
            }

            UI.Mensaje("\n¡Cuenta eliminada con éxito!\n");

        }

        static void EstimarInteres()
        {

            if (Control.ListaVacia())
            {
                UI.Mensaje("\nLa lista está vacía");
                return;
            }

            UI.Mensaje("\nIngrese el CBU para calcular el interés: ");
            CBU = UI.SolicitarCBU();

            if (Control.ExisteCBU(CBU) == null)
            {
                UI.Mensaje("\nLa cuenta no existe.\n");
                return;
            }

            UI.Mensaje("\nIngrese la cantidad de meses que desea mantener el dinero en el banco: ");
            int Meses = UI.SolicitarMeses();

            UI.Mensaje($"\nSi usted mantiene el saldo durante {Meses} meses, su saldo final será de: {Control.CalcularInteres(CBU, Meses)}");
        }

    }
}
