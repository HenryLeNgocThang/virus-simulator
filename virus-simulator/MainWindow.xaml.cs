using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace virus_simulator
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

        bool gameStarted = false;
        float xRad;
        float yRad;
        float radius = 2f;
        float increase = 1f;
        string filePath = "worlddatabank.xml";

        public MainWindow()
        {
            MenuVirus menuVirus = new MenuVirus();
            menuVirus.ShowDialog();

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
                            row.SelectSingleNode("name").InnerText,
                            row.SelectSingleNode("alpha2Code").InnerText,
                            menuVirus.GetKontagiositätsindex,
                            menuVirus.GetInfektionsdauer,
                            menuVirus.GetMortalitaetsrate
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
                    countries[i].NewPopulation();
                }
            }
        }

        public void SSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxtSliderValue.Text = sSlider.Value.ToString();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / (int)sSlider.Value);
        }

        private void World_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Check every country if mouse was over it at the pressing on the map
            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i] != null)
                {
                    if (countries[i].Path.IsMouseOver)
                    {
                        if (!gameStarted)
                        {
                            countries[i].Path.Fill = brush;
                            xRad = countries[i].XPos;
                            yRad = countries[i].YPos;
                            timer.Start();
                            gameStarted = true;
                        }
                        else
                        {
                            pageLandInfo info = new pageLandInfo
                            (
                                countries[i].CountryName,
                                countries[i].DeathRate.ToString("F"),
                                countries[i].InfectionRate.ToString("F"),
                                countries[i].Infections.ToString(),
                                countries[i].Deaths.ToString(),
                                countries[i].Remaining.ToString(),
                                countries[i].Population.ToString()
                            );

                            info.ShowDialog();
                            break;
                        }
                    }
                }
            }
        }
    }
}
