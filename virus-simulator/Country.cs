﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows.Shapes;

namespace virus_simulator
{
    class Country
    {
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

        public Path Path { get => path; }
        public float XPos { get => xPos; }
        public float YPos { get => yPos; }
        public string CountryName { get => countryName; }
        public string CountryCode { get => countryCode; }
        public double InfectionRate { get => infectionRate; }
        public int Infections { get => infections; }
        public int Deaths { get => deaths; }
        public int Remaining { get => remaining; }

        public Country(Path land, int populationOfLand, int sizeOfLand, string nameOfLand, string codeOfLand)
        {
            path = land;
            path.Fill = brush;
            population = populationOfLand;
            countryName = nameOfLand;
            landArea = sizeOfLand;
            countryCode = codeOfLand;
            populationDensity = Convert.ToInt32(populationOfLand / sizeOfLand);

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
                    colorInfection += 1;
                }
            }

            if (deathRate % 1 == 0)
            {
                if (colorDeaths > 100 && colorDeaths <= 255)
                {
                    colorDeaths -= 1;
                }
            }

            if (countryCode == "DE")
            {
                float newF = ((infections / population) * 100);
                Console.WriteLine(newF);
            }

            brush = new SolidColorBrush(Color.FromArgb(colorInfection, colorDeaths, 0, 0));
            path.Fill = brush;

        }
        public void NewInfection()
        {
            infections += 1000;
            infectionRate = infections / population * 100;
        }
        public void NewDeath()
        {
            deaths += 1000;
            deathRate = deaths / population * 100;
        }

        public void NewPopulation()
        {
            remaining = population - deaths;
        }
    }
}
