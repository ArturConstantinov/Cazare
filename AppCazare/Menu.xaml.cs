using System.Windows;

namespace AppCazare
{
    public partial class Menu : Window
    {
        private inregistrareClient inregistrareClient;
        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private ExpiratXML ExpiratXML;

        public Menu()
        {
            InitializeComponent();
        }

               
        private void btnDelog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void btnInregClient_Click_1(object sender, RoutedEventArgs e)
        {
            inregistrareClient = new inregistrareClient();
            inregistrareClient.Show();
            this.Close();
        }

        private void btnScEvidenta_Click(object sender, RoutedEventArgs e)
        {
            scoateEvidenta = new scoateEvidenta();
            scoateEvidenta.Show();
            this.Close();
        }

        private void btnPrelSej_Click(object sender, RoutedEventArgs e)
        {
            prelungesteSejurul = new prelungesteSejurul();
            prelungesteSejurul.Show();
            this.Close();
        }

        private void btnUnitatiDisp_Click(object sender, RoutedEventArgs e)
        {
            unitatiDeCazareDisponibile = new unitatiDeCazareDisponibile();
            unitatiDeCazareDisponibile.Show();
            this.Close();
        }

        private void btnLocLiber_Click(object sender, RoutedEventArgs e)
        {
            LocuriLibere = new LocuriLibere();
            LocuriLibere.Show();
            this.Close();
        }

        private void btnPretMed_Click(object sender, RoutedEventArgs e)
        {
            pretulMediu = new pretulMediu();
            pretulMediu.Show();
            this.Close();
        }

        private void btnSILocCazare_Click(object sender, RoutedEventArgs e)
        {
            celScumpIeftinLoc = new celScumpIeftinLoc();
            celScumpIeftinLoc.Show();
            this.Close();
        }

        private void BtnExpirat_Click(object sender, RoutedEventArgs e)
        {
            ExpiratXML = new ExpiratXML();
            ExpiratXML.Show();
            this.Close();
        }
    }
}
