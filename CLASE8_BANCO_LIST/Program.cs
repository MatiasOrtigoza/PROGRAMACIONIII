using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE8_BANCO_LIST
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int Opcion;
            float Saldo;
            float Monto;
            ulong CBU;
            string Cliente;
            bool Operacion;
            Interfaz UI = new Interfaz(ConsoleColor.DarkBlue, ConsoleColor.White);
            ControladorCuentas Control = new ControladorCuentas();

            Opcion = UI.MostrarMenu();

            while (Opcion != 7)
            {
                UI.Clear();
                if (Opcion == 1)
                {
                    UI.Mensaje("\nIngrese el CBU a crear: ");
                    CBU = UI.SolicitarCBU();
                    UI.Mensaje("\nIngrese el saldo inicial: ");
                    Saldo = UI.SolicitarSaldo();
                    UI.Mensaje("\nIngrese el nombre del cliente: ");
                    Cliente = UI.SolicitarNombre();
                    Operacion = Control.AgregarCuenta(CBU, Cliente, Saldo);
                    if (Operacion)
                    {
                        UI.Mensaje("\n¡Cuenta agregada satisfactoriamente!\n");
                    }
                    else
                    {
                        UI.Mensaje("\nLa cuenta ya existe...\n");
                    }
                }
                else if (Opcion == 2) {
                    if (!Control.ListaVacia())
                    {
                        UI.Mensaje("\nIngrese el CBU al que quiere depositar: ");
                        CBU = UI.SolicitarCBU();
                        if (Control.ExisteCBU(CBU) == null)
                        {
                            UI.Mensaje("\nNo existe el CBU al que quiere depositar");

                        }
                        else
                        {
                            UI.Mensaje("\nIngrese el monto a depositar: ");
                            Monto = UI.SolicitarSaldo();
                            Operacion = Control.Depositar(CBU, Monto);
                            UI.Mensaje("\n¡Depósito realizado con éxito!\n");
                        }
                    }
                    else
                    {
                        UI.Mensaje("\nNo hay cuentas cargadas.");
                    }
                    

                }
                else if (Opcion == 3)
                {
                    if (!Control.ListaVacia())
                    {
                        UI.Mensaje("\nIngrese el CBU del que quiere extraer: ");
                        CBU = UI.SolicitarCBU();
                        UI.Mensaje("\nIngrese el monto a extraer: ");
                        Monto = UI.SolicitarSaldo();
                        Operacion = Control.Extraer(CBU, Monto);
                        if (Operacion)
                        {
                            UI.Mensaje("\n¡La extracción fue realizada con éxito!\n");
                        }
                        else
                        {
                            UI.Mensaje("\nEl monto es insuficiente o la cuenta no existe...\n");

                        }
                    }
                    else
                    {
                        UI.Mensaje("\nNo hay cuentas cargadas.");
                    }
                    
                }
                else if (Opcion == 4)
                {
                    UI.Mensaje("\nIngrese el CBU para ver sus datos: ");
                    CBU = UI.SolicitarCBU();
                    UI.Mensaje(Control.MostrarCuenta(CBU));
                }
                else if (Opcion == 5)
                {
                    UI.Mensaje(Control.MostrarLista());
                }
                else if (Opcion == 6)
                {
                    if (!Control.ListaVacia())
                    {
                        UI.Mensaje("\nIngrese el CBU a remover: ");
                        CBU = UI.SolicitarCBU();
                        Operacion = Control.EliminarCuenta(CBU);
                        if (Operacion)
                        {
                            UI.Mensaje("\n¡Cuenta eliminada con éxito!\n");
                        }
                        else
                        {
                            UI.Mensaje("\nLa cuenta no existe.\n");
                        }
                    }
                    else
                    {
                        UI.Mensaje("\nNo hay cuentas cargadas.");
                    }
                }
                UI.PressKeyToContinue();
                Opcion = UI.MostrarMenu();
            }

            UI.Mensaje("\nSaliendo del programa.\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
