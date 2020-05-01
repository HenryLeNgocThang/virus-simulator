using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Shapes;

namespace virus_simulator
{
    class Country
    {
        // Private variables
        SolidColorBrush brush;
        Path path;
        int infections = 0;
        int deaths = 0;
        int population;
        int populationDensity;
        byte colorInfection = 0;
        byte colorDeaths = 255;
        double infectionRate;
        double deathRate;
        float xPos;
        float yPos;
        string countryName;
        int landArea;
        string countryCode;
        int remaining;
        int multiplier;

        // Getter and Setters
        public Path Path { get => path; }
        public float XPos { get => xPos; }
        public float YPos { get => yPos; }
        public string CountryName { get => countryName; }
        public double DeathRate { get => deathRate; }
        public double InfectionRate { get => infectionRate; }
        public int Infections { get => infections; }
        public int Deaths { get => deaths; }
        public int Remaining { get => remaining; }
        public int Population { get => population; }
        public int Multiplier
        {
            get => multiplier;
            set { multiplier = value; }
        }

        // Variables from other classes
        double contactigousnessIndex;
        double infectionDuration;
        double mortalityRate;

        public Country
        (
            Path land,
            int populationOfLand,
            int sizeOfLand,
            string nameOfLand,
            string codeOfLand,
            double publicContactigousnessIndex,
            double publicInfectionDuration,
            double publicMortalityRate
        )
        {
            path = land;
            path.Fill = brush;
            population = populationOfLand;
            countryName = nameOfLand;
            landArea = sizeOfLand;
            countryCode = codeOfLand;

            populationDensity = Convert.ToInt32(populationOfLand / sizeOfLand);
            contactigousnessIndex = publicContactigousnessIndex;
            infectionDuration = publicInfectionDuration;
            mortalityRate = publicMortalityRate;

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
        }

        public void SetColor()
        {
            if (infectionRate %1==0)
            {
                if (colorInfection < 255 && colorInfection >= 0)
                {
                    colorInfection = Convert.ToByte(infectionRate * 255 / 100);
                }
            }

            if (deathRate % 1 == 0)
            {
                if (colorDeaths > 100 && colorDeaths <= 255)
                {
                    colorDeaths = Convert.ToByte(255 - (deathRate * 155 / 100));
                }
            }

            brush = new SolidColorBrush(Color.FromArgb(colorInfection, colorDeaths, 0, 0));
            path.Fill = brush;

        }
        public void NewInfection()
        {
            /*
             
            Possible variables to calculate the new infections

            populationDensity
            contactigousnessIndex
            infectionDuration
            mortalityRate
             
             */

            if (infections <= population)
            {
                // Random number between parameter 1 and 2
                int randomInfection = RandomNumber(10, 100);

                // If the sum of randomInfection + infections is greater than the population it adds the rest of non infected population to the infected people.
                if (randomInfection + infections > population)
                {
                    infections = infections + (population - infections);
                }
                else
                {
                    // Increase the infected by randomInfection
                    infections += randomInfection;
                    infectionRate = infections * 100 / population;
                }
            }
            else
            {
                //Console.WriteLine("Every citizen in " + countryName + " is infected!");
            }
        }

        public void NewDeath()
        {
            if (deaths <= infections)
            {
                int randomDeaths = RandomNumber(1, 10);

                if (randomDeaths + deaths > infections)
                {
                    deaths = deaths + (infections - deaths);
                }
                else
                {
                    deaths += randomDeaths;
                    // Percentage of deaths from infections
                    deathRate = deaths * 100 / infections;
                }
            }
            else
            {
                //Console.WriteLine("Every citizen in " + countryName + " is dead!");
            }
        }

        public void NewPopulation()
        {
            remaining = population - deaths;
        }

        int RandomNumber(int min = 1, int max = 2)
        {
            Random random = new Random();
            int randomNumber = random.Next(min, max);

            return randomNumber;
        }
    }
}
