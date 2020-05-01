using System.Windows;

namespace virus_simulator
{
    /// <summary>
    /// Interaktionslogik für pageLandInfo.xaml
    /// </summary>
    public partial class pageLandInfo : Window
    {
        public pageLandInfo(string name, string sterbeRate, string infRate, string infAbs, string tote, string verbleibende, string bevölkerung)
        {
            InitializeComponent();
            tbName.Text = name;
            tbSterberate.Text = sterbeRate;
            tbRate.Text = infRate;
            tbInfectedabs.Text = infAbs;
            tbTote.Text = tote;
            tbVerbleibende.Text = verbleibende;
            tbBevölkerung.Text = bevölkerung;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
