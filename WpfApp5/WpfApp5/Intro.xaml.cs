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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {

        Mall mall = new Mall("x", 0);
        List<object> l_piso = new List<object>(); //contiene la lista tiendas (se agregan tiendas)
        int i = 1;
        int horas; //horas de simulacion
        int tarifaEs; //tarifa del estacionamiento
        int metro_cuadrado; //precio del metro cuadrado
        int money; //presupuesto, en la 3ra ventana se agrega a la clase mall pero es un webeo sacarlo, te lo dejo aqui 
        List<object> tiendas = new List<object>(); //cada elemento contiene una tienda que tiene: piso, area, nombre, cantidadEmpleados, preciomin, preciomax, categoria, subcategoria



        public Intro()
        {
            InitializeComponent();
            PisoNum.Content = i;
        }
        //CHECK
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
        //CHECK
        private void Continue1_Click(object sender, RoutedEventArgs e)
        {
            IntroText.Content = "Necesitaremos que entregues\n algunos parametros";
            IntroText.FontSize = 16;
            Continue1.Visibility = Visibility.Hidden;
            Exit.Visibility = Visibility.Hidden;
            Continue2.Visibility = Visibility.Visible;
        }
        //CHECK
        private void Continue2_Click_1(object sender, RoutedEventArgs e)
        {
            IntroText.Visibility = Visibility.Hidden;
            HorasText.Visibility = Visibility.Visible;
            PresupuestoText.Visibility = Visibility.Visible;
            Horas.Visibility = Visibility.Visible;
            Presupuesto.Visibility = Visibility.Visible;
            TarifaEstacionamientoText.Visibility = Visibility.Visible;
            TarifaEstaiconamiento.Visibility = Visibility.Visible;
            PrecioArriendo.Visibility = Visibility.Visible;
            PrecioArriendoText.Visibility = Visibility.Visible;
            Continue2.Visibility = Visibility.Hidden;
            Continue3.Visibility = Visibility.Visible;
        }
        //CHECK
        private void Continue3_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Presupuesto.Text) && !string.IsNullOrEmpty(Horas.Text) && !string.IsNullOrEmpty(PrecioArriendo.Text)&& !string.IsNullOrEmpty(TarifaEstaiconamiento.Text))
            {
                int horas = Convert.ToInt32(Horas.Text);
                mall.varmoney(Convert.ToInt32(Presupuesto.Text));
                Presupuesto.Visibility = Visibility.Hidden;
                PresupuestoText.Visibility = Visibility.Hidden;
                Horas.Visibility = Visibility.Hidden;
                HorasText.Visibility = Visibility.Hidden;
                TarifaEstacionamientoText.Visibility = Visibility.Hidden;
                TarifaEstaiconamiento.Visibility = Visibility.Hidden;
                PrecioArriendo.Visibility = Visibility.Hidden;
                PrecioArriendoText.Visibility = Visibility.Hidden;
                Continue4.Visibility = Visibility.Visible;
                CantPisos.Visibility = Visibility.Visible;
                CantPisosText.Visibility = Visibility.Visible; //cantidad de pisos
                horas = Convert.ToInt32(Horas.Text);
                tarifaEs = Convert.ToInt32(TarifaEstaiconamiento.Text);
                metro_cuadrado = Convert.ToInt32(PrecioArriendo.Text);
                money = Convert.ToInt32(Presupuesto.Text);


            }
        }

        private void Continue4_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CantPisos.Text))
            {
                Continue4.Visibility = Visibility.Hidden;
                CantPisos.Visibility = Visibility.Hidden;
                CantPisosText.Visibility = Visibility.Hidden;
                PisoText.Visibility = Visibility.Visible; //numero del piso actual
                PisoNum.Visibility = Visibility.Visible;
                Continue4.Visibility = Visibility.Hidden;
                Continue5.Visibility = Visibility.Visible;
                AreaText.Visibility = Visibility.Visible;//consulta del area 
                Area.Visibility = Visibility.Visible;
                AreaAnttxt.Visibility = Visibility.Visible;
                AreaAnt.Visibility = Visibility.Visible;
                PisoNum.Content = i;

            }
        }

        private void CantPisos_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Horas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void Presupuesto_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Continue5_Click(object sender, RoutedEventArgs e)
        {
            
            string piso = "piso" + i.ToString();

            if (i == 1)
            {
                Piso newfloor = new Piso(i, Convert.ToInt32(Area.Text));
                mall.addfloor(newfloor);
                i++;
                AreaAnt.Content = Convert.ToInt32(Area.Text);
                Area.Clear();
                ComboPiso.Items.Add(piso);
            }
            else
            {
                if (Convert.ToInt32(Area.Text) <= mall.getfloor(i - 1).getArea())
                {
                    Piso newfloor = new Piso(i, Convert.ToInt32(Area.Text));
                    mall.addfloor(newfloor);
                    i++;
                    AreaAnt.Content = mall.getfloor(i - 1).getArea();
                    Area.Clear();
                    ComboPiso.Items.Add(piso);
                }
                else
                {
                    MessageBox.Show("El area especificada no puede ser mayor a la del piso inferior", "Error Area", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            PisoNum.Content = i;
            if (i == Convert.ToInt32(CantPisos.Text)+1)
            {
                PisoText.Visibility = Visibility.Hidden;
                PisoNum.Visibility = Visibility.Hidden;
                Continue3.Visibility = Visibility.Hidden;
                Continue4.Visibility = Visibility.Hidden;
                Continue5.Visibility = Visibility.Hidden;
                AreaText.Visibility = Visibility.Hidden;
                Area.Visibility = Visibility.Hidden;
                AreaAnttxt.Visibility = Visibility.Hidden;
                AreaAnt.Visibility = Visibility.Hidden;
                ComboPiso.Visibility = Visibility.Visible;
                SeleccionPisoText.Visibility = Visibility.Visible;
                Continue6.Visibility = Visibility.Visible;
                Terminar.Visibility = Visibility.Visible;
            }            
        }

        private void Continue6_Click(object sender, RoutedEventArgs e)
        {
            ComboPiso.Visibility = Visibility.Hidden;
            SeleccionPisoText.Visibility = Visibility.Hidden;
            Continue6.Visibility = Visibility.Hidden;
            Terminar.Visibility = Visibility.Hidden;
            CantLocales.Visibility = Visibility.Visible;
            CantLocalesText.Visibility = Visibility.Visible;
            Continue7.Visibility = Visibility.Visible;
            PisoText.Visibility = Visibility.Visible;
            PisoNum.Visibility = Visibility.Visible;
            PisoNum.Content = ComboPiso.SelectedItem;
        }

        private void Terminar_Click(object sender, RoutedEventArgs e)
        {
            //Comenzar Simulacion            
            this.Close();
        }
        private void Continue7_Click(object sender, RoutedEventArgs e)
        {
            ComboLocal.Visibility = Visibility.Visible;
            string locales = "local ";
            for (int i = 1; i <= Convert.ToInt32(CantLocales.Text); i++)
            {
                locales = "locales" + i.ToString();
                ComboLocal.Items.Add(locales);
            }
            Continue8.Visibility = Visibility.Visible;
            CantLocales.Visibility = Visibility.Hidden;
            CantLocalesText.Visibility = Visibility.Hidden;
            
        }

        private void ComboPiso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AreaPisoSelect.Visibility = Visibility.Visible;
            AreaPisoText.Visibility = Visibility.Visible;
            AreaPisoSelect.Content = mall.getfloor(ComboPiso.SelectedIndex + 1).getArea();
        }

        private void CantLocales_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Continue8_Click(object sender, RoutedEventArgs e)
        {
            PisoText.Visibility = Visibility.Hidden;
            PisoNum.Visibility = Visibility.Hidden;
            AreaPisoText.Visibility = Visibility.Hidden;
            AreaPisoSelect.Visibility = Visibility.Hidden;
            ComboLocal.Visibility = Visibility.Hidden;
            Continue8.Visibility = Visibility.Hidden;
            Continue9.Visibility = Visibility.Visible;
            AgregarTienda.Visibility = Visibility.Visible;
            AreaLocal.Visibility = Visibility.Visible;
            AreaLocalText.Visibility = Visibility.Visible;
            NombreLocal.Visibility = Visibility.Visible;
            NombreLocalText.Visibility = Visibility.Visible;
            CantidadEmpleados.Visibility = Visibility.Visible;
            CantidadEmpleadosText.Visibility = Visibility.Visible;
            PrecioMin.Visibility = Visibility.Visible;
            PrecioMinText.Visibility = Visibility.Visible;
            PrecioMax.Visibility = Visibility.Visible;
            PrecioMaxText.Visibility = Visibility.Visible;
            ComboCategoria.Visibility = Visibility.Visible;
            ComboSubCategoria.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Continue9_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AreaLocal.Text) && !string.IsNullOrEmpty(NombreLocal.Text) && !string.IsNullOrEmpty(CantidadEmpleados.Text) && !string.IsNullOrEmpty(PrecioMin.Text) && !string.IsNullOrEmpty(PrecioMax.Text))
            {
                List<object> lista = new List<object>();
                lista.Add(PisoNum.Content); 
                lista.Add(Convert.ToInt32(AreaLocal.Text));
                lista.Add(NombreLocal.Text);
                lista.Add(Convert.ToInt32(CantidadEmpleados.Text));
                lista.Add(Convert.ToInt32(PrecioMin));
                lista.Add(Convert.ToInt32(PrecioMax));
                lista.Add(ComboCategoria.SelectedItem);
                lista.Add(ComboSubCategoria.SelectedItem);
                tiendas.Add(lista);
                AreaLocal.Clear();
                NombreLocal.Clear();
                CantidadEmpleados.Clear();
                PrecioMin.Clear();
                PrecioMax.Clear();

            }
        }

        private void NombreLocal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboSubCategoria.Items.Clear();
            if (ComboCategoria.SelectedIndex == 0)
            {
                ComboSubCategoria.Items.Add("Ropa");
                ComboSubCategoria.Items.Add("Hogar");
                ComboSubCategoria.Items.Add("Alimento");
                ComboSubCategoria.Items.Add("Ferreteria");
                ComboSubCategoria.Items.Add("Tecnologia");
            }
            else if (ComboCategoria.SelectedIndex == 1)
            {
                ComboSubCategoria.Items.Add("Rapida");
                ComboSubCategoria.Items.Add("Restaurant");
            }
            else if (ComboCategoria.SelectedIndex == 2)
            {
                ComboSubCategoria.Items.Add("Cine");
                ComboSubCategoria.Items.Add("Juegos");
                ComboSubCategoria.Items.Add("Bowling");
            }
        }

        private void AgregarTienda_Click(object sender, RoutedEventArgs e)
        {
            l_piso.Add(tiendas);
            ComboPiso.Visibility = Visibility.Hidden;
            SeleccionPisoText.Visibility = Visibility.Hidden;
            Continue6.Visibility = Visibility.Hidden;
            Terminar.Visibility = Visibility.Hidden;
            CantLocales.Visibility = Visibility.Visible;
            CantLocalesText.Visibility = Visibility.Visible;
            Continue7.Visibility = Visibility.Visible;
            PisoText.Visibility = Visibility.Visible;
            PisoNum.Visibility = Visibility.Visible;
            PisoNum.Content = ComboPiso.SelectedItem;
        }
    }
}
