using System;
using System.Windows;

namespace virus_simulator
{
    /// <summary>
    /// Interaktionslogik für MenuVirus.xaml
    /// </summary>
    public partial class MenuVirus : Window
    {
        double kontagiositätsindex;
        double infektionsdauer;
        double mortalitaetsrate;

        public double GetKontagiositätsindex { get => kontagiositätsindex; }
        public double GetInfektionsdauer { get => infektionsdauer; }
        public double GetMortalitaetsrate { get => mortalitaetsrate; }

        public MenuVirus()
        {
            InitializeComponent();
        }

        void KIndex_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KIndexSliderValue.Text = Kontagiositätsindex.Value.ToString();
            kontagiositätsindex = Kontagiositätsindex.Value;
        }

        void InfDauer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            InfDauerSliderValue.Text = Infektionsdauer.Value.ToString();
            infektionsdauer = Infektionsdauer.Value;
        }

        void Mortalitaet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MortalitaetSliderValue.Text = Mortalitaetsrate.Value.ToString();
            mortalitaetsrate = Mortalitaetsrate.Value;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
