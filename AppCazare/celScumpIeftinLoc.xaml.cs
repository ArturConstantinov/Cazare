using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class celScumpIeftinLoc : Window
    {

        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private Menu Menu;
        private inregistrareClient inregistrareClient;
        private ExpiratXML ExpiratXML;

        public celScumpIeftinLoc()
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

        private void BtDetermina_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = Properties.Settings.Default.CazareDBConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter aMax = new SqlDataAdapter("SELECT MAX(pret) FROM Camere", conn);
                SqlDataAdapter aMin = new SqlDataAdapter("SELECT MIN(pret) FROM Camere", conn);
                DataTable dtMax = new DataTable();
                DataTable dtMin = new DataTable();
                aMax.Fill(dtMax);
                aMin.Fill(dtMin);
                conn.Close();
                string max = dtMax.Rows[0].ItemArray[0].ToString();
                string min = dtMin.Rows[0].ItemArray[0].ToString();
                tbScump.Text ="Cel mai scump loc = " + max + " lei";
                tbIeften.Text ="Cel mai Ieften loc = " + min + " lei";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionstring;
            connectionstring = Properties.Settings.Default.CazareDBConnectionString;
            string quary;
            quary = "SELECT * FROM Camere";

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
