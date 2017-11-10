using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EntregaPOO
{
    /// <summary>
    /// Lógica de interacción para Informes.xaml
    /// </summary>
    public partial class Informes : Window
    {
        Mall ma;
        Estacionamiento es;
        Random random = new Random();
        int personasdia = 0;
        List<int> personasdialist = new List<int>();
        int areasuso = 0;
        public Informes(Mall mall, Estacionamiento est)
        {
            InitializeComponent();
            
            this.ma = mall;
            this.es = est;
            int porcentajeAuto = 1;
            dia.Content = ma.getDay();
            int cantpisos=ma.getCantPisos();
            int h = 1;
            BalanceMall.Content = mall.SeeWallet();
            while (h <= cantpisos)
            {
                PisoCB.Items.Add(h.ToString());
                
                for(int i = 0; i < ma.getfloor(h).GetCantTiendas(); i++)
                {
                    for(int j = 0; j <= 10; j++)
                    {
                        ma.getfloor(h).GetTienda(i).generateDayCmax(j+1);
                        ma.getfloor(h).GetTienda(i).generatedayclients(j+1);
                        int ganancia = ma.getfloor(h).GetTienda(i).getDayClients(j+1) * random.Next(ma.getfloor(h).GetTienda(i).getminp(), ma.getfloor(h).GetTienda(i).getmaxp() + 1);
                        ma.getfloor(h).GetTienda(i).AgregarGanancia(j+1, ganancia);
                        personasdialist.Add(ma.getfloor(h).GetTienda(i).getDayClients(j+1));
                        

                    }
                    personasdia += ma.getfloor(h).GetTienda(i).getDayClients(1);
                    areasuso += ma.getfloor(h).GetTienda(i).ReturnArea();
                    
                }

                
                
                h++;
            }
            IngresoEst.Content = personasdia * es.GetTarifa();
            mall.varmoney(areasuso * ma.GetValorArriendo());
            mall.varmoney(personasdia * es.GetTarifa());
            BalanceMall.Content = mall.SeeWallet();


        }

        private void botonpiso_Click(object sender, RoutedEventArgs e)
        {
            int canttiendas = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetCantTiendas();
            TiendaCb.Items.Clear();
            int h = 0;
            while (h < canttiendas)
            {
                TiendaCb.Items.Add(ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(h).ReturnName());
                h++;
            }
            
        }

        private void botontienda_Click(object sender, RoutedEventArgs e)
        {
            
            Categoria.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetCatName();
            cantemp.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp().ToString();
            pmin.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getminp().ToString();
            pmax.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getmaxp().ToString();
            costoemp.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp() * ma.GetSueldo();
            ingresodia.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetGananciaDia(ma.getDay());
            cantvisitas.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getDayClients(ma.getDay()).ToString();
            CostoArriendo.Content = (ma.GetValorArriendo() * ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).ReturnArea()).ToString();
            Totaldia.Content= ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetGananciaDia(ma.getDay())- ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp() * ma.GetSueldo()- ma.GetValorArriendo() * ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).ReturnArea();


        }

        private void NuevoDia_Click(object sender, RoutedEventArgs e)
        {
            ma.NewDay();
            if (ma.getDay() == 12)
            {
                System.Environment.Exit(1);
            }

            
            dia.Content = ma.getDay();
            int balance = int.Parse(BalanceMall.Content.ToString());
            int h = 1;
            while (h <= ma.getCantPisos())
            {
                for (int i = 1; i < ma.getfloor(h).GetCantTiendas(); i++)
                {

                    balance += ma.getfloor(h).GetTienda(i).GetGananciaDia(1);
                }
                h++;
            }
            ma.varmoney(areasuso * ma.GetValorArriendo());
            ma.varmoney(personasdialist[ma.getDay()-1] * es.GetTarifa());
            BalanceMall.Content = ma.SeeWallet();
            try
            {
                Categoria.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetCatName();
                cantemp.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp().ToString();
                pmin.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getminp().ToString();
                pmax.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getmaxp().ToString();
                costoemp.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp() * ma.GetSueldo();
                ingresodia.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetGananciaDia(ma.getDay());
                cantvisitas.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getDayClients(ma.getDay()).ToString();
                CostoArriendo.Content = (ma.GetValorArriendo() * ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).ReturnArea()).ToString();
                Totaldia.Content = ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).GetGananciaDia(ma.getDay()) - ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).getEmp() * ma.GetSueldo() - ma.GetValorArriendo() * ma.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).GetTienda(TiendaCb.SelectedIndex).ReturnArea();

            }
            catch
            {

            }
            IngresoEst.Content = personasdialist[ma.getDay()-1] * es.GetTarifa();
            
             if (ma.getDay() == 11)
            {
                System.Environment.Exit(1);
            }

        }
    }
}
