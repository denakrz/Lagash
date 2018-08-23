using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeniseLagash.Model.Interfaces
{
    public interface IParkingLot
    {
        #region Properties
        int CantidadEstacionados { get; set; }

        int EspaciosDisponibles { get; set; }

        int PrecioPorDia { get; set; }
        #endregion

        void IngresoDetectado();

        void EgresoDetectado();

        void FacturarEstadia(int PrecioPorDia);
    }
}
