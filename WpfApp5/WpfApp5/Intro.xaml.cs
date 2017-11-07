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
        List<Piso> l_piso = new List<Piso>();
        int i = 1;

        public Intro()
        {
            InitializeComponent();

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
                Continue4.Visibility = Visibility.Visible;
                CantPisos.Visibility = Visibility.Visible;
                CantPisosText.Visibility = Visibility.Visible;
               
            }
        }

        private void Continue4_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CantPisos.Text))
            {
                Continue4.Visibility = Visibility.Hidden;
                CantPisos.Visibility = Visibility.Hidden;
                CantPisosText.Visibility = Visibility.Hidden;
                PisoText.Visibility = Visibility.Visible;
                PisoNum.Visibility = Visibility.Visible;
                Continue4.Visibility = Visibility.Hidden;
                Continue5.Visibility = Visibility.Visible;
                AreaText.Visibility = Visibility.Visible;
                Area.Visibility = Visibility.Visible;
                PisoNum.Content = i;


                /*
                for (int i = 0; i < cantpisos && !button5wasclicked;i++)
                {
                    button5wasclicked = false;
                    PisoNum.Content = (i + 1).ToString() ;
                    if (button5wasclicked==true)
                    {
                        continue;
                    }
                }*/
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

        private void Continue5_Click(object sender, RoutedEventArgs e)
        {
            PisoNum.Content = i;
            if (i == 1)
            {
                Piso newfloor = new Piso(i, Convert.ToInt32(Area.Text));
                mall.addfloor(newfloor);
                i++;
            }
            else
            {
                if (Convert.ToInt32(Area.Text) <= mall.getfloor(i - 1).getArea())
                {
                    Piso newfloor = new Piso(i, Convert.ToInt32(Area.Text));
                    mall.addfloor(newfloor);
                    i++;
                }
                else
                {
                    MessageBox.Show("El area especificada no puede ser mayor a la del piso inferior", "Error Area", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Area.Clear();
            if (i == Convert.ToInt32(CantPisos.Text))
            {

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
