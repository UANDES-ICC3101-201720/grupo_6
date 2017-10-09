using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mall
{
    class Estacionamiento
    {
        int capacidadmax;
        int uso;
        int tarifa;
        List<int> ingresosDia;

        public Estacionamiento(int capacidad,int tarifaHora)
        {
            this.capacidadmax= capacidad;
            this.uso = 0;
            this.tarifa = tarifaHora;
            this.ingresosDia = new List<int>() {0,0,0,0,0,0,0,0,0,0};
        }

        public void DayParkingProfit(int day, int ingreso)
        {
            ingresosDia[day-1] = ingreso;
        }

    }
}
