using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace virus_simulator
{
    class Country
    {
        int infections = 0;
        int deaths = 0;
        int einwohner;
        int bevDichte;
        byte colorInfection = 255;
        byte colorDeaths = 255;
        double infectionRate;
        double deathRate;

        public SolidColorBrush brush;


        Path path;

        public Country(Path land, int population, int dichte)
        {
            brush = new SolidColorBrush(Color.FromArgb(colorInfection, colorDeaths, 0, 0));
            path = land;
            path.Fill = brush;
            einwohner = (int)(population * Math.Pow(10, 6));
            bevDichte = dichte;

        }

        public void SetColor()
        {
            if (infectionRate %1==0)
            {
                colorInfection -= 1;
            }
            brush = new SolidColorBrush(Color.FromArgb(colorInfection, colorDeaths, 0, 0));
            path.Fill = brush;

        }
        public void NewInfection()
        {
            infections += 1;
            infectionRate = infections / einwohner * 100;

        }
        void NewDeath()
        {
            deaths += 1;
            deathRate = deaths / einwohner * 100;

        }
    }
}
