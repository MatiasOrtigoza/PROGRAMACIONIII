using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASE12_BANCO_COMPLETO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CuentaAhorro.InteresRetorno = Interfaz.SolicitarFloatPositivo("interés mensual");
            CuentaCorriente.MontoDescubierto = Interfaz.SolicitarFloatPositivo("monto límite al descubierto");

            ArmarMenu();

            Interfaz.MostrarMenu();
            int Opcion = Interfaz.SolicitarOpcion();

            while (Opcion != 6)
            {
                switch (Opcion)
                {
                    case 1:
                        AgregarCuentaCorriente();
                        break; 
                    case 2:
                        AgregarCuentaAhorro();
                        break;
                    case 3:
                        GuardarCSV();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }

                Interfaz.Pause();

                Interfaz.MostrarMenu();
                Opcion = Interfaz.SolicitarOpcion();
            }


            Interfaz.Pause();

        }

        static void ArmarMenu()
        {
            List<string> lista = new List<string>
            {
                "Agregar una cuenta corriente",
                "Agregar una cuenta ahorro",
                "Guardar en archivo CSV",
                "Leer un archivo CSV de cuentas ahorro",
                "Leer un archivo CSV de cuentas corriente",
                "Salir"
            };

            Interfaz.CargarOpcion(lista);

        }

        static void AgregarCuentaCorriente()
        {
            //VARIABLES PARA LOS CAMPOS DE LA CLASE PADRE
            ulong CBU = Interfaz.SolicitarULong("CBU");

            if (Controlador.ExisteCuenta(CBU) != null)
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("El CBU ya pertenece a una cuenta registrada.");
                return;
            }
            string Cliente = Interfaz.SolicitarString("cliente");
            float Saldo = Interfaz.SolicitarFloatPositivo("saldo");

            //VARIABLES PARA LOS CAMPOS DE LA CLASE HIJA
            float InteresDescubierto = Interfaz.SolicitarFloatPositivo("interes descubierto");

            bool Operacion = Controlador.AgregarCuentaCorriente(CBU, Cliente, Saldo, InteresDescubierto);


            Interfaz.Clear();
            if (!Operacion)
            {
                Interfaz.ErrorMensaje("¡Error en el ingreso! Intente nuevamente...");
                return;
            }

            Interfaz.SuccessMensaje("¡Cuenta agregada satisfactoramiente!");
        }

        static void AgregarCuentaAhorro()
        {
            //VARIABLES PARA LOS CAMPOS DE LA CLASE PADRE
            ulong CBU = Interfaz.SolicitarULong("CBU");

            if (Controlador.ExisteCuenta(CBU) != null)
            {
                Interfaz.Clear();
                Interfaz.ErrorMensaje("El CBU ya pertenece a una cuenta registrada.");
                return;
            }
            string Cliente = Interfaz.SolicitarString("cliente");
            float Saldo = Interfaz.SolicitarFloatPositivo("saldo");

            //VARIABLES PARA LOS CAMPOS DE LA CLASE HIJA
            string PlanCuenta = Interfaz.SolicitarString("plan de la cuenta");
            ulong TarjetaVinculada = Interfaz.SolicitarULong("tarjeta vinculada");

            bool Operacion = Controlador.AgregarCuentaAhorro(CBU, Cliente, Saldo, PlanCuenta, TarjetaVinculada);

            Interfaz.Clear();
            if (!Operacion)
            {
                Interfaz.ErrorMensaje("¡Error en el ingreso! Intente nuevamente...");
                return;
            }

            Interfaz.SuccessMensaje("¡Cuenta agregada satisfactoramiente!");
        }

        static void GuardarCSV()
        {

            //RUTA: C:\Users\xxwan\Documents\FACULTAD\TERCER CUATRIMESTRE\PROGRAMACION III\repositorio-ejercicios\PROGRAMACIONIII\CLASE12-BANCO-COMPLETO\data
            string ruta = Interfaz.SolicitarRuta();

            Interfaz.Mensaje(Controlador.GuardarCSV(ruta));
        }



    }
}
