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
    /// Lógica de interacción para VentanaParametros.xaml
    /// </summary>
    public partial class VentanaParametros : Window
    {
        public VentanaParametros()
        {
            
            InitializeComponent();
            AlertaVP.Visibility = Visibility.Hidden;
            VP2_Label.Visibility = Visibility.Visible;
            VP1_Label.Visibility = Visibility.Visible;
            int w = 1;
            while (w != 25)
            {
                VP_CB.Items.Add(w.ToString());
                w++;
            }
            


        }

        private void VP_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Aceptar_VP_Click(object sender, RoutedEventArgs e)
        {
            int conf = 0;
            try
            {
                int horasFuncionamiento=int.Parse(VP_CB.Text.ToString());
                conf++;

            }
            catch
            {
                AlertaVP.Visibility = Visibility.Visible;
                VP_CB.Text = "";
            }
            try
            {
                int tarifaEstacionamiento=int.Parse(Tarifa_TB.Text);
                if (int.Parse(Tarifa_TB.Text) >= 0 )
                {
                    if (int.Parse(Tarifa_TB.Text) < 26)
                    {
                        conf++;
                    }
                    else
                    {
                        AlertaVP.Visibility = Visibility.Visible;
                        Tarifa_TB.Text = "";
                    }
                }
                else
                {
                    AlertaVP.Visibility = Visibility.Visible;
                    Tarifa_TB.Text = "";
                }
                


            }
            catch
            {
                AlertaVP.Visibility = Visibility.Visible;
                Tarifa_TB.Text = "";
            }
            try
            {
                int presupuestoInicial=int.Parse(Presupuesto_TB.Text);
                conf++;
            }
            catch
            {
                AlertaVP.Visibility = Visibility.Visible;
                Presupuesto_TB.Text = "";
            }
            try
            {
                int valorArriendo=int.Parse(Arriendo_TB.Text);
                if (int.Parse(Arriendo_TB.Text) >= 0)
                {
                    conf++;
                }
                else
                {
                    AlertaVP.Visibility = Visibility.Visible;
                    Arriendo_TB.Text = "";
                }
            }
            catch
            {
                AlertaVP.Visibility = Visibility.Visible;
                Arriendo_TB.Text = "";
            }
            try
            {
                int sueldo = int.Parse(SueldoTB.Text);
                if (int.Parse(SueldoTB.Text) >= 0)
                {
                    conf++;
                }
                else
                {
                    AlertaVP.Visibility = Visibility.Visible;
                    SueldoTB.Text = "";
                }
            }
            catch
            {
                AlertaVP.Visibility = Visibility.Visible;
                SueldoTB.Text = "";
            }
            if (conf == 5)
            {
                int horasFuncionamiento = int.Parse(VP_CB.Text.ToString());
                int tarifaEstacionamiento = int.Parse(Tarifa_TB.Text);
                int presupuestoInicial = int.Parse(Presupuesto_TB.Text);
                int valorArriendo = int.Parse(Arriendo_TB.Text);
                int sueldo = int.Parse(SueldoTB.Text);
                Estacionamiento estacionamiento = new Estacionamiento(tarifaEstacionamiento);
                Mall mall = new Mall();
                mall.SetSueldo(sueldo);
                mall.SetHorasDia(horasFuncionamiento);
                mall.varmoney(presupuestoInicial);
                mall.setValorArriendo(valorArriendo);
                CreacionMall creacionMall = new CreacionMall(mall,estacionamiento);
                creacionMall.Show();
                this.Close();
                
            }
        }
    }
}
