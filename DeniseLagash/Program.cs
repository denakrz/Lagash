using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeniseLagash.Model.Interfaces;
using DeniseLagash.Model.Classes;

namespace DeniseLagash
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanceo el objeto
            IParkingLot parkingLot = new ParkingLot();

            ShowMessages(parkingLot);

            var option = UserInput();

            while (option != 4)
            {
                switch (option)
                {
                    case 1:
                        parkingLot.IngresoDetectado();
                        break;

                    case 2:
                        parkingLot.EgresoDetectado();
                        break;

                    case 3:
                        Console.Write("\nIngresar precio por dia.\n");
                        int precio = UserInput();
                        parkingLot.PrecioPorDia = precio; //Se lo asigna a la propiedad PrecioPorDia
                        parkingLot.FacturarEstadia(precio); //Llama a FacturarEstadia
                        break;

                    default:
                        Console.Write("No se eligio una opción valida.");
                        break;
                }
                Console.Write("\nPresione una tecla para seguir.");
                Console.ReadKey(); //Para hacer STOP y ver lo que esta escrito en consola
                Console.Clear(); //Limpiar pantalla
                ShowMessages(parkingLot); 
                option = UserInput();
            }
        }

        /// <summary>
        /// Method to show options and parking lot properties
        /// </summary>
        /// <param name="parkingLot">the object ParkingLot</param>
        private static void ShowMessages(IParkingLot parkingLot)
        {
            Console.Write("\nBienvenidos a Parking System \n\n");
            Console.Write("\nCantidad de autos estacionados: " + parkingLot.CantidadEstacionados);
            Console.Write("\nCantidad de espacio disponible: " + parkingLot.EspaciosDisponibles);
            Console.Write("\n\nPor favor elija una opción: ");
            Console.Write("\n1. Ingresar Auto. \n2. Egresar Auto. \n3. Facturar. \n4. Cerrar programa.\n");
        }

        /// <summary>
        /// Reads user input and convert it to int
        /// </summary>
        /// <returns>Returns an integer</returns>
        private static int UserInput()
        {
            var input = Console.ReadLine();
            try
            {
                int option = Int32.Parse(input);

                return option;
            }
            catch (FormatException e)
            {
                Console.Write("Por favor ingresar una número valido\n");

                return UserInput();  // recursividad
            }
        }
    }
}
