using System.Windows;

namespace virus_simulator
{
    /// <summary>
    /// Interaktionslogik für pageLandInfo.xaml
    /// </summary>
    public partial class pageLandInfo : Window
    {
        public pageLandInfo(string name, string kuerzel, string infRate, string infAbs, string tote, string verbleibende)
        {
            InitializeComponent();
            tbName.Text = name;
            tbKuerzel.Text = kuerzel;
            tbRate.Text = infRate;
            tbInfectedabs.Text = infAbs;
            tbTote.Text = tote;
            tbVerbleibende.Text = verbleibende;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
