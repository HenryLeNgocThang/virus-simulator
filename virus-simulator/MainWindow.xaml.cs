using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace virus_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<countries> countryCode = new List<countries>();

        public MainWindow()
        {
            InitializeComponent();

            // Insert the json files path to the variable
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "countries.json");

            // Read the file
            using (StreamReader r = new StreamReader(path))
            {
                string line;

                // Read and display lines from the file until the end of the file is reached
                while ((line = r.ReadLine()) != null)
                {
                    // Add only countryCode from the "json"
                    countryCode.Add(
                        new countries() {Name = Regex.Match(line, @"(?<="").*?(?="")").Value }
                    );
                }

                // Remove first and last brackets => {}
                countryCode.RemoveAt(0);
                countryCode.RemoveAt(countryCode.Count - 1);
            }

            // Set the listviews source to the country codes
            lvCountries.ItemsSource = countryCode;
        }
    }
}
