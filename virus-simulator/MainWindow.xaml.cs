using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace virus_simulator

/*
 * 
 * TODOs:
 * 
 * - Stop timer if game ends
 * - Display population on xaml
 * - Only one counrty pressable at the beginning
 * - Use relative filePath to project folder BUT dont use System.IO (if so System.Windows.Shapes wouldnt work)
 * 
 */
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush brush;
        DispatcherTimer timer;
        XmlDocument doc = new XmlDocument();
        List<Country> countries = new List<Country>();

        float xRad = 1f;
        float yRad = 1f;
        float radius = 5f;
        float increase = 2f;
        /*

        !!! IMPORTANT !!!
        The following string filePath has to be adjusted!

        */
        string filePath = @"C:\xampp\htdocs\projects\virus-simulator\virus-simulator\worlddatabank.xml";

        public MainWindow()
        {
            InitializeComponent();
            brush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            doc.Load(filePath);

            // Try to create a class if in XAML there is a <Path /> with the same name as in the XML feed.
            // Add the population at the class initializing aswell.
            foreach (XmlNode row in doc.DocumentElement.GetElementsByTagName("row"))
            {
                Path path = (Path)FindName(row.SelectSingleNode("alpha2Code").InnerText);

                try
                {
                    countries.Add
                    (
                        new Country
                        (
                            path,
                            Convert.ToInt32(row.SelectSingleNode("population").InnerText),
                            Convert.ToInt32(row.SelectSingleNode("area").InnerText),
                            row.SelectSingleNode("name").InnerText
                        )
                    );
                }
                catch (Exception e)
                {
                }
            }

            // We have to fill all countries with color otherwise we will get problems with filling countries with color later on.
            foreach (var country in countries)
            {
                country.Path.Fill = brush;
            }

            // Timer which calls Update Method in 30 FPS (Frames per Seconds)
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 30);
        }

        private void Update(object sender, EventArgs e)
        {
            // Increase and repositioning infection zone
            if (radius <= Window.Width * 2)
            {
                radius += increase;
                xRad -= increase / 2;
                yRad -= increase / 2;
            }

            // Check every country if its in the infection zone
            for (int i = 0; i < countries.Count; i++)
            {
                if (xRad < countries[i].XPos &&
                    xRad + radius > countries[i].XPos &&
                    yRad < countries[i].YPos &&
                    yRad + radius > countries[i].YPos)
                {
                    countries[i].SetColor();
                    countries[i].NewInfection();
                    countries[i].NewDeath();
                }
            }
        }

        private void World_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            brush = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));

            // Check every country if mouse was over it at the pressing on the map
            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i] != null)
                {
                    if (countries[i].Path.IsMouseOver)
                    {
                        countries[i].Path.Fill = brush;
                        xRad = countries[i].XPos;
                        yRad = countries[i].YPos;
                        timer.Start();
                    }
                }
            }
        }
    }
}
