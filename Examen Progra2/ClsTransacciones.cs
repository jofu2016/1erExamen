using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Progra2
{
    internal class ClsTransacciones
    {

        public class Transacciones
        { 
        
    // Campos de la clase ClsTransacciones
            private int[] numFactura = new int[15];
            private string[] numPlaca = new string[15];
            private string[] fecha = new string[15];
            private string[] hora = new string[15];
            private int[] tipoVehiculo = new int[15];
            private int[] numCaseta = new int[15];
            private double[] montoPagar = new double[15];
            private double[] pagaCon = new double[15];
            private double[] vuelto = new double[15];
            private int contadorTransacciones = 0;

            // Método para inicializar los vectores a cero
            public void InicializarVectores()
            {
                numFactura = new int[15];
                numPlaca = new string[15];
                fecha = new string[15];
                hora = new string[15];
                tipoVehiculo = new int[15];
                numCaseta = new int[15];
                montoPagar = new double[15];
                pagaCon = new double[15];
                vuelto = new double[15];
                contadorTransacciones = 0;
            }

            // Método para ingresar los datos de una transacción
            public void IngresarTransaccion()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("REGISTRAR FLUJO VEHICULAR");
                Console.ResetColor();

                string respuesta = "S"; // Inicializar la variable respuesta con "S"

                do
                {
                    Console.Write("Número Factura: ");
                    numFactura[contadorTransacciones] = int.Parse(Console.ReadLine());

                    Console.Write("Número PLACA: ");
                    numPlaca[contadorTransacciones] = Console.ReadLine();

                    Console.Write("Fecha: ");
                    fecha[contadorTransacciones] = Console.ReadLine();

                    Console.Write("Hora: ");
                    hora[contadorTransacciones] = Console.ReadLine();

                    Console.Write("Tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
                    tipoVehiculo[contadorTransacciones] = int.Parse(Console.ReadLine());

                    Console.Write("Número caseta (1,2,3): ");
                    numCaseta[contadorTransacciones] = int.Parse(Console.ReadLine());

                    //monto a pagar 
                    switch (tipoVehiculo[contadorTransacciones])
                    {
                        case 1:
                            montoPagar[contadorTransacciones] = 500;
                            break;
                        case 2:
                            montoPagar[contadorTransacciones] = 700;
                            break;
                        case 3:
                            montoPagar[contadorTransacciones] = 2700;
                            break;
                        case 4:
                            montoPagar[contadorTransacciones] = 3700;
                            break;
                        default:
                            Console.WriteLine("Tipo de vehículo inválido");
                            continue;
                    }

                    Console.Write("Paga con: ");
                    pagaCon[contadorTransacciones] = double.Parse(Console.ReadLine());

                    //vuelto
                    vuelto[contadorTransacciones] = pagaCon[contadorTransacciones] - montoPagar[contadorTransacciones];

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("¿Desea continuar ingresando vehículos? (S/N): ");
                    Console.ResetColor();
                    respuesta = Console.ReadLine().ToUpper();

                    contadorTransacciones++;

                } while (respuesta == "S");
            }

            public void ConsultaPorPlaca(string placa)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Consulta de vehículos por número de placa");
                Console.Write("Ingrese la placa a buscar: ");
                Console.ResetColor();
                string placaBuscar = Console.ReadLine().ToUpper();

                bool encontrado = false;

                for (int i = 0; i < numPlaca.Length; i++)
                {
                    if (numPlaca[i] == placaBuscar)
                    {
                        Console.WriteLine("Número factura: {0}", numFactura[i]);
                        Console.WriteLine("Número de placa: {0}", numPlaca[i]);
                        Console.WriteLine("Fecha: {0}", fecha[i]);
                        Console.WriteLine("Hora: {0}", hora[i]);
                        Console.WriteLine("Tipo de vehículo: {0}", tipoVehiculo[i]);
                        Console.WriteLine("Número de caseta: {0}", numCaseta[i]);
                        Console.WriteLine("Monto a pagar: {0}", montoPagar[i]);
                        Console.WriteLine("Paga con: {0}", pagaCon[i]);
                        Console.WriteLine("Vuelto: {0}", vuelto[i]);
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("No se encontró información para la placa ingresada.");
                }
            }

            public void Modificar()
            {
                Console.WriteLine("Modificar vehículo por número de placa");
                Console.Write("Ingrese la placa a buscar: ");
                string placaBuscar = Console.ReadLine().ToUpper();

                bool encontrado = false;
                int indice = -1;

                // Buscamos el vehículo por número de placa
                for (int i = 0; i < numPlaca.Length; i++)
                {
                    if (numPlaca[i] == placaBuscar)
                    {
                        indice = i;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("No se encontró información para la placa ingresada.");
                    return;
                }

                // Mostramos los datos actuales del vehículo
                Console.WriteLine("Número factura: {0}", numFactura[indice]);
                Console.WriteLine("Número de placa: {0}", numPlaca[indice]);
                Console.WriteLine("Fecha: {0}", fecha[indice]);
                Console.WriteLine("Hora: {0}", hora[indice]);
                Console.WriteLine("Tipo de vehículo: {0}", tipoVehiculo[indice]);
                Console.WriteLine("Número de caseta: {0}", numCaseta[indice]);
                Console.WriteLine("Monto a pagar: {0}", montoPagar[indice]);
                Console.WriteLine("Paga con: {0}", pagaCon[indice]);
                Console.WriteLine("Vuelto: {0}", vuelto[indice]);

                // Mostramos el menú de opciones de modificación
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Seleccione la opción de modificación:");
                Console.WriteLine("1. Fecha");
                Console.WriteLine("2. Hora");
                Console.WriteLine("3. Tipo de vehículo");
                Console.WriteLine("4. Número de caseta");
                Console.ResetColor();

                // Procesamos la opción seleccionada por el usuario
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nueva fecha: ");
                        fecha[indice] = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Nueva hora: ");
                        hora[indice] = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Nuevo tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
                        tipoVehiculo[indice] = int.Parse(Console.ReadLine());

                        // Restar el pago anterior por el pagaCon y mostrar el pago
                        double pagoAnterior = montoPagar[indice];
                        double pago = pagaCon[indice] - pagoAnterior;
                        Console.WriteLine("Pago anterior: {0}", pago);

                        // Actualizar el monto a pagar según el nuevo tipo de vehículo
                        switch (tipoVehiculo[indice])
                        {
                            case 1:
                                montoPagar[indice] = 500;
                                break;
                            case 2:
                                montoPagar[indice] = 700;
                                break;
                            case 3:
                                montoPagar[indice] = 2700;
                                break;
                            case 4:
                                montoPagar[indice] = 3700;
                                break;
                            default:
                                Console.WriteLine("Tipo de vehículo inválido");
                                break;
                        }

                        // Mostrar el nuevo monto a pagar
                        Console.WriteLine("Nuevo monto a pagar: {0}", montoPagar[indice]);
                        break;

                    case 4:
                        Console.Write("Nuevo número de caseta (1,2,3): ");
                        numCaseta[indice] = int.Parse(Console.ReadLine());
                        break;
 
                }       
            }

            public void Reporte()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nLISTADO DE TRANSACCIONES REGISTRADAS");
                Console.ResetColor();
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}{7,-15}{8,-15}", "Número Factura", "Número PLACA", "Fecha", "Hora", "Tipo Vehículo", "Número Caseta", "Monto a Pagar", "Paga con", "Vuelto");

                for (int i = 0; i < contadorTransacciones; i++)
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}{7,-15}{8,-15}",
                        numFactura[i], numPlaca[i], fecha[i], hora[i], tipoVehiculo[i], numCaseta[i], montoPagar[i], pagaCon[i], vuelto[i]);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ResetColor();
                Console.ReadKey();

            }



        }
    }
}