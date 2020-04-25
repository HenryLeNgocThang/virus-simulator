using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Path path;

        public float xPos;
        public float yPos;

        public string myName;

        public Country(Path land, int population, int dichte, string countryCode)
        {
            path = land;
            path.Fill = brush;
            einwohner = (int)(population * Math.Pow(10, 6));
            bevDichte = dichte;

            myName = countryCode;

            // GET DATA
            string data = Convert.ToString(path.Data);

            // REMOVE CHARS BUT NOT ,.;0123456789
            Regex rgx = new Regex("[^.0-9;,]");
            string str = rgx.Replace(data, ";");

            // SEPERATOR
            string delimStr = ";";
            char[] delimiter = delimStr.ToCharArray();

            // SPLIT DATA STRING AT THE SEPERATOR AND ASSIGN FIRST TWO NUMBERS
            xPos = float.Parse(str.Split(delimiter)[1]);
            yPos = float.Parse(str.Split(delimiter)[2]);

            //Console.WriteLine(xPos);
            //Console.WriteLine(yPos);
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
