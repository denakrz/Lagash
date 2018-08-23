using DeniseLagash.Model.Interfaces;
using System;

namespace DeniseLagash.Model.Classes
{
    public class ParkingLot : IParkingLot
    {
        public int CantidadEstacionados { get; set; }

        public int EspaciosDisponibles { get; set; }

        public int PrecioPorDia { get; set; }

        public ParkingLot()
        {
            CantidadEstacionados = 0;
            EspaciosDisponibles = 100;
        }

        /// <summary>
        /// Method to enter a car
        /// </summary>
        public void IngresoDetectado()
        {
            if (EspaciosDisponibles > 0)
            {
                CantidadEstacionados++;
                EspaciosDisponibles--;

                Console.Write("Auto ingresado correctamente");
            }
            else
                Console.Write("No hay más espacio disponible");
        }

        /// <summary>
        /// Method to exit a car
        /// </summary>
        public void EgresoDetectado()
        {
            if (CantidadEstacionados > 0)
            {
                CantidadEstacionados--;
                EspaciosDisponibles++;

                Console.Write("Auto egresado correctamente.");
            }
            else
                Console.Write("Actualmente no hay autos estacionados.");
        }

        /// <summary>
        /// Method to bill car's stay
        /// </summary>
        /// <param name="PrecioPorDia"></param>
        public void FacturarEstadia(int PrecioPorDia)
        {
            var facturacionTotal = PrecioPorDia * CantidadEstacionados;

            Console.Write("La cantidad de autos estacionados es " + CantidadEstacionados + " y el precio por dia es " + PrecioPorDia);
            Console.Write("\nFacturación total es " + facturacionTotal);

            ServicioExterno.EnviarMail("Facturacion", "La facturacion es " + facturacionTotal.ToString(), "mail@hotmail.com");
            Console.Write("\nSe mando mail indicando monto total de facturación");
        }
    }
}
