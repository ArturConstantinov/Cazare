using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class unitatiDeCazareDisponibile : Window
    {
        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;
        private inregistrareClient inregistrareClient;
        private ExpiratXML ExpiratXML;

        public unitatiDeCazareDisponibile()
        {
            InitializeComponent();
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
            string connectionString;
            connectionString = Properties.Settings.Default.CazareDBConnectionString;
            string quary;
            quary = "SELECT * FROM Unitati";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(quary, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
        }
        
    }
}
