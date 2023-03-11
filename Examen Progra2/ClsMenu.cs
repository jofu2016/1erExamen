using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progra2
{
    internal class ClsMenu
    {
        
        class Menu
        {
            static void Main(string[] args)
            {
                ClsTransacciones.Transacciones transacciones = new ClsTransacciones.Transacciones();

                int opcion;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Menú Principal del Sistema:");
                    Console.WriteLine("1. Inicializar Vectores");
                    Console.WriteLine("2. Ingresar Paso Vehicular");
                    Console.WriteLine("3. Consulta de vehículos x Número de Placa");
                    Console.WriteLine("4. Modificar Datos Vehículos x número de Placa");
                    Console.WriteLine("5. Reporte Todos los Datos de los vectores");
                    Console.WriteLine("6. Salir");
                    Console.Write("Escoja una opción: ");
                    Console.ResetColor();
                    opcion = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1:
                            transacciones.InicializarVectores();
                            Console.WriteLine("Vectores inicializados a cero.");
                            break;
                        case 2:
                            transacciones.IngresarTransaccion();
                            Console.WriteLine("Transacción registrada correctamente.");
                            break;
                        case 3:
                            Console.Write("Ingrese la placa a buscar: ");
                            string placaBuscar = Console.ReadLine().ToUpper();
                            transacciones.ConsultaPorPlaca(placaBuscar);
                            break;
                        case 4:
                            transacciones.Modificar();
                            break;
                        case 5:
                            transacciones.Reporte();
                            break;
                        case 6:
                            Console.WriteLine("Hasta luego.");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            break;
                    }

                    Console.WriteLine();
                } while (opcion != 6);
            }

           

        }
    }
}
