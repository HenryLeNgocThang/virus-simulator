using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace virus_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names = new List<string>() { "AF", "AO", "AL", "AE", "AR", "AM", "AU", "AT", "AZ", "BI", "BE", "BJ", "BF", "BD", "BG", "BA", "BY", "BZ", "BO", "BR", "BN", "BT", "BW", "CF", "CA", "CH", "CL", "CN", "CI", "CM", "CD", "CG", "CO", "CR", "CU", "CZ", "DE", "DJ", "DK", "DO", "DZ", "EC", "EG", "ER", "EE", "ET", "FI", "FJ", "GA", "GB", "GE", "GH", "GN", "GM", "GW", "GQ", "GR", "GL", "GT", "GY", "HN", "HR", "HT", "HU", "ID", "IN", "IE", "IR", "IQ", "IS", "IL", "IT", "JM", "JO", "JP", "KZ", "KE", "KG", "KH", "KR", "KW", "LA", "LB", "LR", "LY", "LK", "LS", "LT", "LU", "LV", "MA", "MD", "MG", "MX", "MK", "ML", "MM", "ME", "MN", "MZ", "MR", "MW", "MY", "NA", "NE", "NG", "NI", "NL", "NO", "NP", "NZ", "OM", "PK", "PA", "PE", "PH", "PG", "PL", "KP", "PT", "PY", "PS", "QA", "RO", "RU", "RW", "EH", "SA", "SD", "SS", "SN", "SL", "SV", "RS", "SR", "SK", "SI", "SE", "SZ", "SY", "TD", "TG", "TH", "TJ", "TM", "TL", "TN", "TR", "TW", "TZ", "UG", "UA", "UY", "US", "UZ", "VE", "VN", "VU", "YE", "ZA", "ZM", "ZW", "SO", "GF", "FR", "ES", "AW", "AI", "AD", "AG", "BS", "BM", "BB", "KM", "CV", "KY", "DM", "FK", "FO", "GD", "HK", "KN", "LC", "LI", "MV", "MT", "MS", "MU", "NC", "NR", "PN", "PR", "PF", "SG", "SB", "ST", "SX", "SC", "TC", "TO", "TT", "VC", "VG", "VI", "CY", "RE", "YT", "MQ", "GP", "CW", "IC" };
        SolidColorBrush brush;
        DispatcherTimer timer;

        List<Country> countries = new List<Country>();
        float xRad = 1f;
        float yRad = 1f;
        float radius = 5;
        float increase = 50f;

        public MainWindow()
        {
            InitializeComponent();
            brush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            for (int i = 0; i < names.Count; i++)
            {
                Path path = (Path)FindName(names[i]);
                countries.Add(new Country(path, 0, 0, names[i]));
                countries[i].path.Fill = brush;
            }

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void Update(object sender, EventArgs e)
        {
            brush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            radius += increase;

            xRad -= increase / 2;
            yRad -= increase / 2;

            for (int i = 0; i < countries.Count; i++)
            {
                if (xRad < countries[i].xPos &&
                    xRad + radius > countries[i].xPos &&
                    yRad < countries[i].yPos &&
                    yRad + radius > countries[i].yPos)
                {
                    countries[i].path.Fill = brush;
                }
            }
        }

        private void World_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            brush = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));

            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i] != null)
                {
                    if (countries[i].path.IsMouseOver)
                    {
                        countries[i].path.Fill = brush;
                        xRad = countries[i].xPos;
                        yRad = countries[i].yPos;
                        timer.Start();
                    }
                }
            }
        }
    }
}
