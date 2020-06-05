using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class _LocuriLibere : Window
    {
        private MainWindow MainWindow;
        private _pretulMediu pretulMediu;
        private _celScumpIeftinLoc celScumpIeftinLoc;
        private _Menu Menu;
        private _unitatiDeCazareDisponibile unitatiDeCazareDisponibile;

        public _LocuriLibere()
        {
            InitializeComponent();
        }
        
        
        private void btnUnitatiDisp_Click(object sender, RoutedEventArgs e)
        {
            unitatiDeCazareDisponibile = new _unitatiDeCazareDisponibile();
            unitatiDeCazareDisponibile.Show();
            this.Close();
        }
        private void btnDelog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }



        private void btnPretMed_Click(object sender, RoutedEventArgs e)
        {
            pretulMediu = new _pretulMediu();
            pretulMediu.Show();
            this.Close();
        }

        private void btnSILocCazare_Click(object sender, RoutedEventArgs e)
        {
            celScumpIeftinLoc = new _celScumpIeftinLoc();
            celScumpIeftinLoc.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu = new _Menu();
            Menu.Show();
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
