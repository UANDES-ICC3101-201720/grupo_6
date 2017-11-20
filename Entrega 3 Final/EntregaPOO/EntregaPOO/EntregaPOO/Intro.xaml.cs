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
    /// Lógica de interacción para Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Salir1_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Continuar1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            VentanaParametros VP = new VentanaParametros();
            VP.Show();
        }

        private void Cargar_Click(object sender, RoutedEventArgs e)
        {
            Cargar c = new Cargar();
            c.Show();
        }
    }
}
