using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mall
{
    class Mall
    {
        string name;
        List<Piso> floors;
        int money;
        int dia;

        public Mall(string name, int money)
        {
            this.name = name;
            this.money = money;
            this.floors = new List<Piso>();
            this.dia = 0;
        }

        public void varmoney(int variacion)
        {
            this.money +=variacion;
        }
        public void addfloor(Piso newfloor)
        {
            this.floors.Add(newfloor);
        }
        public void namechange(string name)
        {
            this.name = name;
        }
        public Piso getfloor(int planta)
        {
            return floors[planta-1];
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
    }
}
