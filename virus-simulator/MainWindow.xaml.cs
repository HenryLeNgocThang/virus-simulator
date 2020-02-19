using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace virus_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names = new List<string>() { "AF", "AO", "AL", "AE", "AR", "AM", "AU", "AT", "AZ", "BI", "BE", "BJ", "BF", "BD", "BG", "BA", "BY", "BZ", "BO", "BR", "BN", "BT", "BW", "CF", "CA", "CH", "CL", "CN", "CI", "CM", "CD", "CG", "CO", "CR", "CU", "CZ", "DE", "DJ", "DK", "DO", "DZ", "EC", "EG", "ER", "EE", "ET", "FI", "FJ", "GA", "GB", "GE", "GH", "GN", "GM", "GW", "GQ", "GR", "GL", "GT", "GY", "HN", "HR", "HT", "HU", "ID", "IN", "IE", "IR", "IQ", "IS", "IL", "IT", "JM", "JO", "JP", "KZ", "KE", "KG", "KH", "KR", "XK", "KW", "LA", "LB", "LR", "LY", "LK", "LS", "LT", "LU", "LV", "MA", "MD", "MG", "MX", "MK", "ML", "MM", "ME", "MN", "MZ", "MR", "MW", "MY", "NA", "NE", "NG", "NI", "NL", "NO", "NP", "NZ", "OM", "PK", "PA", "PE", "PH", "PG", "PL", "KP", "PT", "PY", "PS", "QA", "RO", "RU", "RW", "EH", "SA", "SD", "SS", "SN", "SL", "SV", "RS", "SR", "SK", "SI", "SE", "SZ", "SY", "TD", "TG", "TH", "TJ", "TM", "TL", "TN", "TR", "TW", "TZ", "UG", "UA", "UY", "US", "UZ", "VE", "VN", "VU", "YE", "ZA", "ZM", "ZW", "SO", "GF", "FR", "ES", "AW", "AI", "AD", "AG", "BS", "BM", "BB", "KM", "CV", "KY", "DM", "FK", "FO", "GD", "HK", "KN", "LC", "LI", "MF", "MV", "MT", "MS", "MU", "NC", "NR", "PN", "PR", "PF", "SG", "SB", "ST", "SX", "SC", "TC", "TO", "TT", "VC", "VG", "VI", "CY", "RE", "YT", "MQ", "GP", "CW", "IC" };
        //List<Path> codes = new List<Path>() { AF, AO, AL, AE, AR, AM, AU, AT, AZ, BI, BE, BJ, BF, BD, BG, BA, BY, BZ, BO, BR, BN, BT, BW, CF, CA, CH, CL, CN, CI, CM, CD, CG, CO, CR, CU, CZ, DE, DJ, DK, DO, DZ, EC, EG, ER, EE, ET, FI, FJ, GA, GB, GE, GH, GN, GM, GW, GQ, GR, GL, GT, GY, HN, HR, HT, HU, ID, IN, IE, IR, IQ, IS, IL, IT, JM, JO, JP, KZ, KE, KG, KH, KR, XK, KW, LA, LB, LR, LY, LK, LS, LT, LU, LV, MA, MD, MG, MX, MK, ML, MM, ME, MN, MZ, MR, MW, MY, NA, NE, NG, NI, NL, NO, NP, NZ, OM, PK, PA, PE, PH, PG, PL, KP, PT, PY, PS, QA, RO, RU, RW, EH, SA, SD, SS, SN, SL, SV, RS, SR, SK, SI, SE, SZ, SY, TD, TG, TH, TJ, TM, TL, TN, TR, TW, TZ, UG, UA, UY, US, UZ, VE, VN, VU, YE, ZA, ZM, ZW, SO, GF, FR, ES, AW, AI, AD, AG, BS, BM, BB, KM, CV, KY, DM, FK, FO, GD, HK, KN, LC, LI, MF, MV, MT, MS, MU, NC, NR, PN, PR, PF, SG, SB, ST, SX, SC, TC, TO, TT, VC, VG, VI, CY, RE, YT, MQ, GP, CW, IC };
        //List<countries> countryCode = new List<countries>();
        List<Path> countryCode = new List<Path>();

        public MainWindow()
        {
            InitializeComponent();

            foreach (string name in names)
            {
                Path myTextBlock = (Path)this.FindName(name);
                countryCode.Add(myTextBlock);
            }

            Path path = new Path();
        }
    }
}
