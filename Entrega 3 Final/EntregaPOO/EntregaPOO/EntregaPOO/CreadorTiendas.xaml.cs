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
    /// Lógica de interacción para CreadorTiendas.xaml
    /// </summary>
    public partial class CreadorTiendas : Window
    {
        Mall m;
        Estacionamiento es;
        public CreadorTiendas(Mall mall, Estacionamiento estacionamiento )
        {

            InitializeComponent();
            this.m = mall;
            this.es = estacionamiento;
            TBnombre.Visibility = Visibility.Hidden;
            CBTiendas.Visibility = Visibility.Hidden;
            TBCantidadEmp.Visibility = Visibility.Hidden;
            TBcategoria.Visibility = Visibility.Hidden;
            TBPrecioMax.Visibility = Visibility.Hidden;
            TBPrecioMin.Visibility = Visibility.Hidden;
            TextoNombre.Visibility = Visibility.Hidden;
            TextoCategoria.Visibility = Visibility.Hidden;
            TextoCantidadEmp.Visibility = Visibility.Hidden;
            TextoPmax.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
            TextoPMin.Visibility = Visibility.Hidden;
            textoAreaDisp.Visibility = Visibility.Hidden;
            CBPisos.Visibility = Visibility.Hidden;
            AreaDisponibleText.Visibility = Visibility.Hidden;
            textoAreaDisp.Visibility = Visibility.Hidden;
            Textpiso.Visibility = Visibility.Hidden;
            TextoAreaTienda.Visibility = Visibility.Hidden;
            Guardar.Visibility = Visibility.Hidden;
            EliminarTienda.Visibility = Visibility.Hidden;
            TBArea.Visibility = Visibility.Hidden;
            TextoEliminarTienda.Visibility = Visibility.Hidden;
            int h = 1;
            while (h <= m.getCantPisos())
            {
                CBPisos.Items.Add(h.ToString());
                h++;
            }
            TBcategoria.Items.Add(1.ToString());
            TBcategoria.Items.Add(2.ToString());
            TBcategoria.Items.Add(3.ToString());
            TBcategoria.Items.Add(4.ToString());
            TBcategoria.Items.Add(5.ToString());
            TBcategoria.Items.Add(6.ToString());
            TBcategoria.Items.Add(7.ToString());
            TBcategoria.Items.Add(8.ToString());
            TBcategoria.Items.Add(9.ToString());
            TBcategoria.Items.Add(10.ToString());



        }

        private void BotonAgregarTienda_Click(object sender, RoutedEventArgs e)
        {
            BotonAgregarTienda.Visibility = Visibility.Hidden;
            BotonComenzarSimulacion.Visibility = Visibility.Hidden;
            BotonEliminarTienda.Visibility = Visibility.Hidden;
            TBnombre.Visibility = Visibility.Visible;
            TBCantidadEmp.Visibility = Visibility.Visible;
            TBcategoria.Visibility = Visibility.Visible;
            TBPrecioMax.Visibility = Visibility.Visible;
            TBPrecioMin.Visibility = Visibility.Visible;
            TextoNombre.Visibility = Visibility.Visible;
            TextoCategoria.Visibility = Visibility.Visible;
            TextoCantidadEmp.Visibility = Visibility.Visible;
            TextoPmax.Visibility = Visibility.Visible;
            TextoPMin.Visibility = Visibility.Visible;
            textoAreaDisp.Visibility = Visibility.Visible;
            CBPisos.Visibility = Visibility.Visible;
            AreaDisponibleText.Visibility = Visibility.Visible;
            textoAreaDisp.Visibility = Visibility.Visible;
            Textpiso.Visibility = Visibility.Visible;
            TextoAreaTienda.Visibility = Visibility.Visible;
            TBArea.Visibility = Visibility.Visible;
            Guardar.Visibility = Visibility.Visible;
            int totaltiendas = 0;
            for (int i = 1; i <= CBPisos.Items.Count; i++)
            {
                totaltiendas += m.getfloor(i).GetCantTiendas();
            }
            CantidadTIendas.Content = totaltiendas.ToString();

        }

        private void BotonEliminarTienda_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BotonAgregarTienda.Visibility = Visibility.Hidden;
                Refresh.Visibility = Visibility.Visible;
                BotonComenzarSimulacion.Visibility = Visibility.Hidden;
                BotonEliminarTienda.Visibility = Visibility.Hidden;
                CBPisos.Visibility = Visibility.Visible;
                Guardar.Visibility = Visibility.Hidden;
                EliminarTienda.Visibility = Visibility.Visible;

                CBTiendas.Visibility = Visibility.Visible;
                int totaltiendas = 0;
                for (int i = 1; i <= CBPisos.Items.Count; i++)
                {
                    totaltiendas += m.getfloor(i).GetCantTiendas();

                }
                CantidadTIendas.Content = totaltiendas.ToString();
            }
            catch
            {

            }
            

        }


        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(TBPrecioMax.Text) >= int.Parse(TBPrecioMin.Text))
                {
                    if (int.Parse(TBPrecioMin.Text)<250 && int.Parse(TBPrecioMax.Text)<100000)
                    {
                        m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).AgregarTienda(TBnombre.Text, int.Parse(TBArea.Text), int.Parse(TBcategoria.SelectedItem.ToString()), int.Parse(TBCantidadEmp.Text), int.Parse(TBPrecioMin.Text), int.Parse(TBPrecioMax.Text));
                        TBnombre.Text = "";
                        TBcategoria.SelectedItem = "";
                        TBCantidadEmp.Text = "";
                        TBPrecioMax.Text = "";
                        TBPrecioMin.Text = "";
                        TBArea.Text = "";
                        TBnombre.Visibility = Visibility.Hidden;
                        TBCantidadEmp.Visibility = Visibility.Hidden;
                        TBcategoria.Visibility = Visibility.Hidden;
                        TBPrecioMax.Visibility = Visibility.Hidden;
                        TBPrecioMin.Visibility = Visibility.Hidden;
                        TextoNombre.Visibility = Visibility.Hidden;
                        TextoCategoria.Visibility = Visibility.Hidden;
                        TextoCantidadEmp.Visibility = Visibility.Hidden;
                        TextoPmax.Visibility = Visibility.Hidden;
                        TextoPMin.Visibility = Visibility.Hidden;
                        textoAreaDisp.Visibility = Visibility.Hidden;
                        CBPisos.Visibility = Visibility.Hidden;
                        AreaDisponibleText.Visibility = Visibility.Hidden;
                        textoAreaDisp.Visibility = Visibility.Hidden;
                        Textpiso.Visibility = Visibility.Hidden;
                        TextoAreaTienda.Visibility = Visibility.Hidden;
                        TBArea.Visibility = Visibility.Hidden;
                        BotonEliminarTienda.Visibility = Visibility.Visible;
                        BotonComenzarSimulacion.Visibility = Visibility.Visible;
                        BotonAgregarTienda.Visibility = Visibility.Visible;
                        Guardar.Visibility = Visibility.Hidden;
                    }



                }

            }
            catch
            {
                TBnombre.Text = "";
                TBcategoria.SelectedItem = "";
                TBCantidadEmp.Text = "";
                TBPrecioMax.Text = "";
                TBPrecioMin.Text = "";
                TBArea.Text = "";
                CBPisos.Text = "";


            }
            
            int totaltiendas = 0;
            for(int i =1; i <= CBPisos.Items.Count; i++)
            {
                totaltiendas += m.getfloor(i).GetCantTiendas();
            }
            CantidadTIendas.Content = totaltiendas.ToString();
        }

        private void CBPisos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                CBTiendas.Items.Clear();
                AreaDisponibleText.Content = m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).ShowAvaibleArea().ToString();
                int totaltiendas = 0;
                for (int i = 1; i <= CBPisos.Items.Count; i++)
                {
                    totaltiendas += m.getfloor(i).GetCantTiendas();
                }
                CantidadTIendas.Content = totaltiendas.ToString();
                for (int i = 0; i <= m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).GetCantTiendas(); i++)
                {
                    CBTiendas.Items.Add(m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).GetTienda(i).ReturnName());
                }
            }
            catch
            {

            }


        }

        private void EliminarTienda_Click(object sender, RoutedEventArgs e)
        {
            int totaltiendas = 0;
            for (int i = 1; i <= CBPisos.Items.Count; i++)
            {
                totaltiendas += m.getfloor(i).GetCantTiendas();
            }

            if (totaltiendas <= 0)
            {
                try
                {

                    m.getfloor(int.Parse(CBPisos.SelectedValue.ToString())).EliminarTienda(m.getfloor(int.Parse(CBPisos.SelectedValue.ToString())).GetTienda(CBTiendas.SelectedIndex));
                    CBTiendas.Items.RemoveAt(CBTiendas.SelectedIndex);
                    EliminarTienda.Visibility = Visibility.Hidden;
                    CBTiendas.Visibility = Visibility.Hidden;
                    CBPisos.Visibility = Visibility.Hidden;
                    TextoEliminarTienda.Visibility = Visibility.Hidden;
                    BotonEliminarTienda.Visibility = Visibility.Visible;
                    BotonComenzarSimulacion.Visibility = Visibility.Visible;
                    BotonAgregarTienda.Visibility = Visibility.Visible;
                    Refresh.Visibility = Visibility.Hidden;
                }
                catch
                {
                    EliminarTienda.Visibility = Visibility.Hidden;
                    CBTiendas.Visibility = Visibility.Hidden;
                    CBPisos.Visibility = Visibility.Hidden;
                    TextoEliminarTienda.Visibility = Visibility.Hidden;
                    BotonEliminarTienda.Visibility = Visibility.Visible;
                    BotonComenzarSimulacion.Visibility = Visibility.Visible;
                    BotonAgregarTienda.Visibility = Visibility.Visible;
                    Refresh.Visibility = Visibility.Hidden;
                }
            }
           
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            CBTiendas.Items.Clear();
            AreaDisponibleText.Content = m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).ShowAvaibleArea().ToString();
            int totaltiendas = 0;
            for (int i = 1; i <= CBPisos.Items.Count; i++)
            {
                totaltiendas += m.getfloor(i).GetCantTiendas();
            }
            CantidadTIendas.Content = totaltiendas.ToString();
            try
            {
                for (int i = 0; i <= m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).GetCantTiendas(); i++)
                {
                    CBTiendas.Items.Add(m.getfloor(int.Parse(CBPisos.SelectedItem.ToString())).GetTienda(i).ReturnName());
                }
            }
            catch
            {

            }
        }

        private void BotonComenzarSimulacion_Click(object sender, RoutedEventArgs e)
        {
            Informes inf = new Informes(m,es);
            inf.Show();
            this.Close();
        }
    }
}
