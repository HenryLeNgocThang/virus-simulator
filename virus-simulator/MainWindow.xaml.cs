using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace virus_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names = new List<string>() { "AF", "AO", "AL", "AE", "AR", "AM", "AU", "AT", "AZ", "BI", "BE", "BJ", "BF", "BD", "BG", "BA", "BY", "BZ", "BO", "BR", "BN", "BT", "BW", "CF", "CA", "CH", "CL", "CN", "CI", "CM", "CD", "CG", "CO", "CR", "CU", "CZ", "DE", "DJ", "DK", "DO", "DZ", "EC", "EG", "ER", "EE", "ET", "FI", "FJ", "GA", "GB", "GE", "GH", "GN", "GM", "GW", "GQ", "GR", "GL", "GT", "GY", "HN", "HR", "HT", "HU", "ID", "IN", "IE", "IR", "IQ", "IS", "IL", "IT", "JM", "JO", "JP", "KZ", "KE", "KG", "KH", "KR", "XK", "KW", "LA", "LB", "LR", "LY", "LK", "LS", "LT", "LU", "LV", "MA", "MD", "MG", "MX", "MK", "ML", "MM", "ME", "MN", "MZ", "MR", "MW", "MY", "NA", "NE", "NG", "NI", "NL", "NO", "NP", "NZ", "OM", "PK", "PA", "PE", "PH", "PG", "PL", "KP", "PT", "PY", "PS", "QA", "RO", "RU", "RW", "EH", "SA", "SD", "SS", "SN", "SL", "SV", "RS", "SR", "SK", "SI", "SE", "SZ", "SY", "TD", "TG", "TH", "TJ", "TM", "TL", "TN", "TR", "TW", "TZ", "UG", "UA", "UY", "US", "UZ", "VE", "VN", "VU", "YE", "ZA", "ZM", "ZW", "SO", "GF", "FR", "ES", "AW", "AI", "AD", "AG", "BS", "BM", "BB", "KM", "CV", "KY", "DM", "FK", "FO", "GD", "HK", "KN", "LC", "LI", "MF", "MV", "MT", "MS", "MU", "NC", "NR", "PN", "PR", "PF", "SG", "SB", "ST", "SX", "SC", "TC", "TO", "TT", "VC", "VG", "VI", "CY", "RE", "YT", "MQ", "GP", "CW", "IC" };
        List<Path> codes = new List<Path>();
        Country deutschland;
        byte infection = 170;
        byte deathrate = 120;
        SolidColorBrush brush;
        Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            brush = new SolidColorBrush(Color.FromArgb(infection, deathrate, 0, 0));
            foreach (string name in names)
            {
                Path path = (Path)FindName(name);
                codes.Add(path);
            }

            // Fill all countries with color
            foreach (Path code in codes)
            {
                if (code != null)
                {
                    code.Fill = brush;
                }
            }

            deutschland = new Country(codes[36], 80, 13);

            // Change brush color
            //brush = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));

            //// Deutschland ist an der 37 stelle
            //codes[36].Fill = brush;

            //lvCountries.ItemsSource = codes;

            //Country Deutschland = new Country()
            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            
            deutschland.NewInfection();
            deutschland.SetColor();
        }

        private void DE_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {



        }

        private void World_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            brush = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));
            foreach (Path path in codes)
            {
                if (path != null)
                {
                    if (path.IsMouseOver)
                    {
                        path.Fill = brush;
                    }
                }

            }
        }
    }
}
