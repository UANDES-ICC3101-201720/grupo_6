using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaPOO
{
    [Serializable]
    public class Estacionamiento
    {
        int capacidadmax;
        int uso;
        int tarifa;
        List<int> ingresosDia;

        public Estacionamiento(int tarifaHora)
        {
            this.uso = 0;
            this.tarifa = tarifaHora;
            this.ingresosDia = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public void DayParkingProfit(int day, int ingreso)
        {
            ingresosDia[day - 1] = ingreso;
        }
        public int GetTarifa()
        {
            return tarifa;
        }

    }
}
