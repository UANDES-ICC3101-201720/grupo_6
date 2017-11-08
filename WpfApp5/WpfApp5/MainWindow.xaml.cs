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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Media;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    using System.Collections.ObjectModel;
    public partial class MainWindow : Window
    {
        private Intro intro =  new Intro();
        public MainWindow()
        {
            
            InitializeComponent();
            this.Close();
            intro.Show();

            /*
            string[] lines = { "" };
            System.IO.File.WriteAllLines(@"reporte.txt", lines);

            Mall mall = new Mall("x", 0);
                Console.WriteLine("Bienvenido al Simulador de Mall");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Necesitaremos que entregues algunos parametros");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Ingrese la cantidad de horas al día en que el mall estara funcionando(<=24):");
                int hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el presupuesto inicial del Mall:");
                int money = Convert.ToInt32(Console.ReadLine());
                mall.varmoney(money);
                Console.WriteLine("Ingrese la tarifa de estacionamiento:");
                int parkingtoll = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el costo de construir un metro cuadrado:");
                int precioConstruccion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el valor del arriendo por Metro Cuadrado:");
                int precioArriendo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad de pisos que tendra el mall");
                int pisos = Convert.ToInt32(Console.ReadLine());
                int t = 1;
                while (t <= pisos)
                {
                    Console.WriteLine("Indique la cantidad de Metros cuadrados mayor a 10 para el piso " + t);
                    int areainput = Convert.ToInt32(Console.ReadLine());
                    if (t == 1)
                    {
                        Piso newfloor = new Piso(t, areainput);
                        mall.addfloor(newfloor);
                        t++;
                        mall.varmoney(-areainput * precioConstruccion);
                    }
                    else
                    {
                        if (areainput <= mall.getfloor(t - 1).getArea())
                        {
                            Piso newfloor = new Piso(t, areainput);
                            mall.addfloor(newfloor);
                            t++;
                            mall.varmoney(-areainput * precioConstruccion);
                        }
                        else
                        {
                            Console.WriteLine("El area especificada no puede ser mayor a la del piso inferior");
                        }
                    }
                }

            Console.WriteLine("Ahora debemos arrendar los pisos y sus locales");
            int internaluse = 1;
            int internaluse2 = 1;
            while (internaluse == 1)
            {
                internaluse2 = 1;
                int cantTiendas = 0;
                while (internaluse2 <= mall.getCantPisos())
                {
                    cantTiendas += mall.getfloor(internaluse2).GetCantTiendas();
                    internaluse2++;
                }

                Console.WriteLine("Su mall tiene " + cantTiendas.ToString() + " tiendas.");
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("Agregar Tienda [1]");
                Console.WriteLine("Comenzar la simulacion[2]");
                int selection = Convert.ToInt32(Console.ReadLine());
                if (selection == 2)
                {
                    internaluse = 0;
                }
                if (selection == 1)
                {
                    Console.WriteLine("Indique el piso en el que desea crear la tienda");
                    int floor = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Indique el nombre de la tienda");
                    string nameInput = Console.ReadLine();
                    Console.WriteLine("Indique el area de la tienda");
                    int areat = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Indique la categoria de la tienda");
                    Console.WriteLine("Comercial:\nRopa[1]\nHogar[2]\nAlimento[3]\nFerreteria[4]\nTecnologia[5]");
                    Console.WriteLine("Comida:\nRapida[6]\nRestaurant[7]");
                    Console.WriteLine("Entretencion:\nCine[8]\nJuegos[9]\nBowling[10]");
                    int Category = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Indique la cantidad de empleados de la tienda");
                    string EmpInput = Console.ReadLine();
                    int empint = int.Parse(EmpInput);
                    Console.WriteLine("Indique el monto minimo de compra");
                    int pmin = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Indique el monto maximo de compra");
                    int pmax = Convert.ToInt32(Console.ReadLine());

                    mall.getfloor(floor).AgregarTienda(nameInput, areat, Category, empint, pmin, pmax);
                }

            }
            Console.WriteLine("Por ultimo, dale un nombre a tu Mall y comenzara la simulacion");
            string nameinput = Console.ReadLine();
            mall.namechange(nameinput);
            Console.WriteLine("Felicidades,el mall '" + nameinput + "' ha sido creado\n\n\n\n");
            mall.NewDay();

            while (mall.getDay() != 11)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Dia: " + mall.getDay().ToString());
                Console.WriteLine("----------------------------------");
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"reporte.txt", true))
                {
                    file.WriteLine("");
                    file.WriteLine("Dia: " + mall.getDay().ToString());
                }
                System.Threading.Thread.Sleep(1000);
                int ingresoEstacionamiento = 0;
                int mindiag = 1000000000;
                int maxdiag = -1000000000;
                int mindiav = 1000000000;
                int maxdiav = -1000000000;
                string mindiagn = "";
                string maxdiagn = "";
                string mindiavn = "";
                string maxdiavn = "";
                int ingresoarriendo = 0;

                for (int i = 1; i < mall.getCantPisos() + 1; i++)
                {
                    for (int j = 0; j < mall.getfloor(i).GetCantTiendas(); j++)
                    {
                        mall.getfloor(i).GetTienda(j).generateDayCmax(mall.getDay());
                        mall.getfloor(i).GetTienda(j).generatedayclients(mall.getDay());
                        int pago = 0;

                        for (int k = 1; k <= mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay()); k++)
                        {
                            Random ran = new Random();
                            pago += ran.Next(mall.getfloor(i).GetTienda(j).getminp(), mall.getfloor(i).GetTienda(j).getmaxp() + 1);
                            Comprador persona = new Comprador();
                            System.Threading.Thread.Sleep(101);
                            ingresoEstacionamiento += parkingtoll * persona.Auto();

                        }

                        int costotienda = mall.getfloor(i).GetTienda(j).getEmp() + mall.getfloor(i).GetTienda(j).ReturnArea() * precioArriendo;
                        int gananciadiaria = pago - costotienda;
                        mall.getfloor(i).GetTienda(j).AgregarGanancia(mall.getDay(), gananciadiaria);

                        string string1 = "La Tienda " + mall.getfloor(i).GetTienda(j).ReturnName() + " recaudó: $" + mall.getfloor(i).GetTienda(j).GetGananciaDia(mall.getDay()) + ". Tuvo " + mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay()).ToString() + " visitas hoy.";
                        Console.WriteLine(string1);
                        Console.WriteLine("El promedio de ingresos a la tienda es: " + mall.getfloor(i).GetTienda(j).PromedioGanancias(mall.getDay()));
                        Console.WriteLine("El promedio de visitas a la tienda es: " + mall.getfloor(i).GetTienda(j).PromedioVisitas(mall.getDay()));
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"reporte.txt", true))
                        {
                            file.WriteLine(string1);
                            file.WriteLine("El promedio de ingresos a la tienda es: " + mall.getfloor(i).GetTienda(j).PromedioGanancias(mall.getDay()));
                            file.WriteLine("El promedio de visitas a la tienda es: " + mall.getfloor(i).GetTienda(j).PromedioVisitas(mall.getDay()));
                        }
                        ingresoarriendo += mall.getfloor(i).GetTienda(j).ReturnArea() * precioArriendo;
                        if (mall.getfloor(i).GetTienda(j).GetGananciaDia(mall.getDay()) >= maxdiag)
                        {
                            maxdiag = mall.getfloor(i).GetTienda(j).GetGananciaDia(mall.getDay());
                            maxdiagn = mall.getfloor(i).GetTienda(j).ReturnName();
                        }
                        if (mall.getfloor(i).GetTienda(j).GetGananciaDia(mall.getDay()) <= mindiag)
                        {
                            mindiag = mall.getfloor(i).GetTienda(j).GetGananciaDia(mall.getDay());
                            mindiagn = mall.getfloor(i).GetTienda(j).ReturnName();
                        }
                        if (mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay()) >= maxdiav)
                        {
                            maxdiav = mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay());
                            maxdiavn = mall.getfloor(i).GetTienda(j).ReturnName();
                        }
                        if (mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay()) <= mindiav)
                        {
                            mindiav = mall.getfloor(i).GetTienda(j).getDayClients(mall.getDay());
                            mindiavn = mall.getfloor(i).GetTienda(j).ReturnName();
                        }

                    }
                }
                Console.WriteLine("El mayor ingreso del dia fue: $" + maxdiag.ToString() + ". De la tienda: " + maxdiagn);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("El menor ingreso del dia fue: $" + mindiag.ToString() + ". De la tienda: " + mindiagn);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("La mayor cantidad de visitas fue: " + maxdiav.ToString() + ". De la tienda: " + maxdiavn);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("La menor cantidad de visitas fue: " + mindiav.ToString() + ". De la tienda: " + mindiavn);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("El Ingreso de estacionamiento fue: $" + ingresoEstacionamiento.ToString());
                mall.varmoney(ingresoEstacionamiento);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("El Ingreso por Arriendo de locales fue: $" + ingresoarriendo.ToString());
                mall.varmoney(ingresoarriendo);
                System.Threading.Thread.Sleep(650);
                Console.WriteLine("El saldo total del mall es: " + mall.SeeWallet().ToString());
                using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"reporte.txt", true))
                {
                    file.WriteLine("El mayor ingreso del dia fue: $" + maxdiag.ToString() + ". De la tienda: " + maxdiagn);
                    file.WriteLine("El menor ingreso del dia fue: $" + mindiag.ToString() + ". De la tienda: " + mindiagn);
                    file.WriteLine("La mayor cantidad de visitas fue: " + maxdiav.ToString() + ". De la tienda: " + maxdiavn);
                    file.WriteLine("La menor cantidad de visitas fue: " + mindiav.ToString() + ". De la tienda: " + mindiavn);
                    file.WriteLine("El Ingreso de estacionamiento fue: $" + ingresoEstacionamiento.ToString());
                    file.WriteLine("El Ingreso por Arriendo de locales fue: $" + ingresoarriendo.ToString());
                    file.WriteLine("El Ingreso por Arriendo de locales fue: $" + ingresoarriendo.ToString());
                    file.WriteLine("El saldo total del mall es: " + mall.SeeWallet().ToString());
                }


                Console.WriteLine("pulse [P] para pausar");
                System.Threading.Thread.Sleep(750);
                Console.WriteLine("nuevo dia en: 5");
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("nuevo dia en: 4");
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("nuevo dia en: 3");
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("nuevo dia en: 2");
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("nuevo dia en: 1");
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                System.Threading.Thread.Sleep(1000);
                if (Console.KeyAvailable == true)
                {
                    Console.WriteLine("simulacion pausada, presione [P] para continuar");
                    Console.ReadKey();
                    Console.ReadKey();
                }
                mall.NewDay();
            }
            Console.WriteLine("Simulacion finalizada, apretar cualquier tecla.");
            Console.ReadKey();*/
        }
        
    }
}
