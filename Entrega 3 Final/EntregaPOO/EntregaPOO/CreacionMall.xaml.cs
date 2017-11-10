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
    /// Lógica de interacción para CreacionMall.xaml
    /// </summary>
    public partial class CreacionMall : Window
    {
        Mall mall;
        Estacionamiento estacionamiento;

        public CreacionMall(Mall mall,Estacionamiento estacionamiento)
        {
            InitializeComponent();
            this.mall = mall;
            this.estacionamiento = estacionamiento;
            Error.Visibility = Visibility.Hidden;
            NubeCM.Visibility = Visibility.Hidden;
            PisoX.Visibility = Visibility.Hidden;
            AreaElec_Label.Visibility = Visibility.Hidden;
            AreaPiso_TB.Visibility = Visibility.Hidden;
            textoarriba.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Hidden;
            Finalizar.Visibility = Visibility.Hidden;
            PisoCB.Visibility = Visibility.Hidden;



        }

        private void Aceptar_CM_Click(object sender, RoutedEventArgs e)
        {
            int conf = 0;
            try
            {
                Nombre_TB.Text.ToString();
                int.Parse(CantidadPisos_TB.Text);
                if (int.Parse(CantidadPisos_TB.Text) > 0)
                {
                    conf++;
                }
                else
                {
                    NubeCM.Visibility = Visibility.Visible;
                    Error.Visibility = Visibility.Visible;
                    Nombre_TB.Text = "Nuevo Mall";
                    CantidadPisos_TB.Text = "Cantidad de Pisos";
                }
                
            }
            catch
            {
                NubeCM.Visibility = Visibility.Visible;
                Error.Visibility = Visibility.Visible;
                Nombre_TB.Text = "Nuevo Mall";
                CantidadPisos_TB.Text="Cantidad de Pisos";

            }
            if (conf == 1)
            {
                Error.Visibility = Visibility.Hidden;
                NubeCM.Visibility = Visibility.Hidden;
                CantidadPisos_TB.Visibility = Visibility.Hidden;
                Nombre_TB.Visibility = Visibility.Hidden;
                texto1.Visibility = Visibility.Hidden;
                texto2.Visibility = Visibility.Hidden;
                Aceptar_CM.Visibility = Visibility.Hidden;
                mall.ChangeName(Nombre_TB.Text);
                PisoX.Visibility = Visibility.Visible;
                AreaElec_Label.Visibility = Visibility.Visible;
                AreaPiso_TB.Visibility = Visibility.Visible;
                PisoCB.Visibility = Visibility.Visible;
                textoarriba.Visibility = Visibility.Visible;
                Finalizar.Visibility = Visibility.Visible;
                Guardar.Visibility = Visibility.Visible;
                for(int i = 1; i <= int.Parse(CantidadPisos_TB.Text); i++)
                {
                    Piso piso = new Piso(i, 0);
                    mall.addfloor(piso);
                    PisoCB.Items.Add(i.ToString());
                }

            }
            
        }

        private void Nombre_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            Nombre_TB.Text = "";
        }

        private void CantidadPisos_TB_GotFocus(object sender, RoutedEventArgs e)
        {
            CantidadPisos_TB.Text = "";

        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mall.getfloor(int.Parse(PisoCB.Text)).SetArea(int.Parse(AreaPiso_TB.Text));
                NubeCM.Visibility = Visibility.Hidden;
                Error.Visibility = Visibility.Hidden;
            }
            catch
            {
                NubeCM.Visibility = Visibility.Visible;
                Error.Visibility = Visibility.Visible;

            }
            
        }

        private void Finalizar_Click(object sender, RoutedEventArgs e)
        {
            int h = 0;
            for(int i = 1; i < int.Parse(CantidadPisos_TB.Text); i++)
            {
                if (mall.getfloor(i).getArea() >= mall.getfloor(i+1).getArea() )
                {
                    h++;
                }
            }
            if(h == -1 + int.Parse(CantidadPisos_TB.Text))
            {
                if (mall.getfloor(1).getArea() != 0)
                {
                    CreadorTiendas creadortiendas = new CreadorTiendas(mall,estacionamiento);
                    creadortiendas.Show();
                    this.Close();
                }
                else
                {
                    NubeCM.Visibility = Visibility.Visible;
                    Error.Visibility = Visibility.Visible;
                }

            }
            else
            {
                NubeCM.Visibility = Visibility.Visible;
                Error.Visibility = Visibility.Visible;
            }
        }

        private void PisoCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AreaPiso_TB.Text = mall.getfloor(int.Parse(PisoCB.SelectedItem.ToString())).getArea().ToString();
            PisoX.Content = "PISO: " + PisoCB.SelectedItem.ToString();
        }
    }
}
