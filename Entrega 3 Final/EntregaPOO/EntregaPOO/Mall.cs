using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaPOO
{
    [Serializable]
    public class Mall
    {       
        List<Piso> floors;
        int money;
        int dia;
        string nombre;
        int horasDia;
        int valorArriendo;
        int sueldoPromedio;

        public Mall()
        {
            this.floors = new List<Piso>();
            this.dia = 1;

        }
        public void SetHorasDia(int horasDia)
        {
            this.horasDia = horasDia;
        }
        public void varmoney(int variacion)
        {
            this.money += variacion;
        }
        public void addfloor(Piso newfloor)
        {
            this.floors.Add(newfloor);
        }
        public Piso getfloor(int planta)
        {
            return floors[planta - 1];
        }
        public int getCantPisos()
        {
            return floors.Count();

        }
        public int getDay()
        {
            return dia;
        }
        public void NewDay()
        {
            this.dia++;
        }
        public int SeeWallet()
        {
            return money;
        }
        public void ChangeName(string newname)
        {
            this.nombre = newname;
        }
        public void setValorArriendo(int valor)
        {
            this.valorArriendo = valor;
        }
        public void SetSueldo(int sueldo)
        {
            this.sueldoPromedio = sueldo;
        }
        public int GetSueldo()
        {
            return sueldoPromedio;
        }
        public int GetValorArriendo()
        {
            return valorArriendo;
        }
        public List<Piso> GetPisos()
        {
            return floors;
        }
    }
}
