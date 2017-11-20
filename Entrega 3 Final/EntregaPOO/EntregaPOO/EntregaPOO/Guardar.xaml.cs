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
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;

namespace EntregaPOO
{
    /// <summary>
    /// Lógica de interacción para Guardar.xaml
    /// </summary>
    public partial class Guardar : Window
    {
        Mall mal;
        public Guardar()
        {
            InitializeComponent();
        }
        public Guardar(Mall mall)
        {
            this.mal = mall;
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Guarda.Visibility = Visibility.Hidden;
            NombreArch.Visibility = Visibility.Visible;
            Nombretext.Visibility = Visibility.Visible;
            GuarSali.Visibility = Visibility.Visible;
            

            
        }

        private void GuarSali_Click(object sender, RoutedEventArgs e)
        {
            List<List<Tienda>> tiedas = new List<List<Tienda>>();
            List<Piso> piso = mal.GetPisos();
            for (int i = 0; i < piso.Count(); i++)
            {
                tiedas.Add(piso[i].GetListTiendas());
            }
            string nombre = Nombretext.Text;
            nombre = nombre + ".xml";
            FileStream Archivo = File.Create(nombre);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(Archivo, mal);
            formatter.Serialize(Archivo, piso);
            formatter.Serialize(Archivo, tiedas);
            Archivo.Close();
            System.Environment.Exit(1);
        }
    }
}
