using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class LocuriLibere : Window
    {
        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;
        private inregistrareClient inregistrareClient;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private ExpiratXML ExpiratXML;

        public LocuriLibere()
        {
            InitializeComponent();
        }

        private void btnUnitatiDisp_Click(object sender, RoutedEventArgs e)
        {
            unitatiDeCazareDisponibile = new unitatiDeCazareDisponibile();
            unitatiDeCazareDisponibile.Show();
            this.Close();
        }
        private void btnDelog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
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

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu = new Menu();
            Menu.Show();
            this.Close();
        }

        private void btnInregClient_Click(object sender, RoutedEventArgs e)
        {
            inregistrareClient = new inregistrareClient();
            inregistrareClient.Show();
            this.Close();
        }

        private void BtnExpirat_Click(object sender, RoutedEventArgs e)
        {
            ExpiratXML = new ExpiratXML();
            ExpiratXML.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionstring;
            connectionstring = Properties.Settings.Default.CazareDBConnectionString;
            string quary;
            quary = "SELECT * FROM Camere WHERE NOT EXISTS(SELECT * FROM Turisti WHERE Camere.codC = Turisti.codC) ORDER BY NP DESC";

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(quary, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            
        }
    }
}
