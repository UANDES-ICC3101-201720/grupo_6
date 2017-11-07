using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    class Piso
    {
        int Planta;
        List<Tienda> tiendas;
        int Area;
        int Area_disponible;

        public Piso(int Planta, int Area)
        {
            this.Planta = Planta;
            this.Area = Area;
            this.Area_disponible = Area;
            this.tiendas = new List<Tienda>();
        }
        public int ShowAvaibleArea(Piso piso)
        {
            return piso.Area_disponible;
        }
        public int getArea()
        {
            return this.Area;
        }
        public void AgregarTienda(string Nombre, int t_Area, int Categoria, int Cantidad_Employer, int Precio_minimo, int Precio_maximo)
        {
            if (t_Area <= Area_disponible && t_Area <= 100 && t_Area >= 10)
            {
                tiendas.Add(new Tienda(Nombre, t_Area, Categoria, Cantidad_Employer, Precio_minimo, Precio_maximo));
                Area_disponible -= t_Area;
            }
            else
            {
                Console.WriteLine("El area no es valida");
            }
        }
        public void EliminarTienda(Tienda tienda)
        {
            int i = 0;
            while (i < tiendas.Count)
            {
                Tienda a = tiendas[i];
                if (a.ReturnName() == tienda.ReturnName())
                {
                    tiendas.Remove(tiendas[i]);
                    Area_disponible += a.ReturnArea();
                }
                i++;
            }
        }
        public int GetCantTiendas()
        {
            return tiendas.Count();
        }
        public Tienda GetTienda(int index)
        {
            return tiendas[index];
        }
    }
}
