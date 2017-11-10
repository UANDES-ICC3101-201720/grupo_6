using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaPOO
{
    [Serializable]
    public class Tienda
    {
        
        string Nombre;
        int Area;
        int Categoria;
        int Cantidad_Employer;
        int Precio_minimo;
        int Precio_maximo;
        Piso piso;
        List<int> cantidadVisitasReal;
        List<int> cmaxday;
        List<int> gananciaDia;

        public Tienda(string Nombre, int Area, int Categoria, int Cantidad_Employer, int Precio_minimo, int Precio_maximo)
        {
            this.Nombre = Nombre;
            this.Area = Area;
            this.Categoria = Categoria;
            this.Cantidad_Employer = Cantidad_Employer;
            this.Precio_minimo = Precio_minimo;
            this.Precio_maximo = Precio_maximo;
            this.cantidadVisitasReal = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0};
            this.cmaxday = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,0,0,0};
            this.gananciaDia = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0 };
        }
        public int GetGananciaDia(int dia)
        {
            return gananciaDia[dia - 1];
        }
        public string ReturnName()
        {
            return this.Nombre;
        }
        public int ReturnArea()
        {
            return this.Area;
        }
        public string GetCatName()
        {
            if (this.Categoria == 1)
            {
                return "Ropa";
            }
            if (this.Categoria == 2)
            {
                return "Hogar";
            }
            if (this.Categoria == 3)
            {
                return "Alimento";
            }
            if (this.Categoria == 4)
            {
                return "Ferreteria";
            }
            if (this.Categoria == 5)
            {
                return "Tecnologia";
            }
            if (this.Categoria == 6)
            {
                return "Rapida";
            }
            if (this.Categoria == 7)
            {
                return "Restaurant";
            }
            if (this.Categoria == 8)
            {
                return "Cine";
            }
            if (this.Categoria == 9)
            {
                return "Juegos";
            }
            if (this.Categoria == 10)
            {
                return "Bowling";
            }
            else
            {
                return "";
            }
        }
        public int getDayClients(int dia)
        {
            return cantidadVisitasReal[dia - 1];
        }
        public int getdaycmax(int dia)
        {
            return cmaxday[dia - 1];
        }
        public void generateDayCmax(int dia)
        {
            int c = 0;
            if (dia != 1)
            {
                c += getDayClients(dia - 1);
            }
            int p = (int)((Precio_maximo + Precio_minimo) / 2.0);
            p = 100 - p;
            List<int> p2 = new List<int>();
            p2.Add(0);
            p2.Add(p);
            double cmax = c + (Area / 10) * (p2.Max() / 100.0) * Cantidad_Employer;
            cmaxday[dia - 1] = (int)cmax;
        }
        public void generatedayclients(int dia)
        {
            Random ran = new Random();
            this.cantidadVisitasReal[dia - 1] = ran.Next(0, cmaxday[dia - 1]);
        }
        public int getminp()
        {
            return Precio_minimo;
        }
        public int getmaxp()
        {
            return Precio_maximo;
        }
        public void AgregarGanancia(int dia, int cantidad)
        {
            gananciaDia[dia - 1] += cantidad;
        }
        public int getEmp()
        {
            return Cantidad_Employer;
        }
        public int PromedioGanancias(int dia)
        {
            return gananciaDia.Sum() / dia;
        }
        public int PromedioVisitas(int dia)
        {
            return cantidadVisitasReal.Sum() / dia;
        }
    }
}
