using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class _unitatiDeCazareDisponibile : Window
    {
        private MainWindow MainWindow;
        private _pretulMediu pretulMediu;
        private _celScumpIeftinLoc celScumpIeftinLoc;
        private _Menu Menu;
        private _LocuriLibere LocuriLibere;


        public _unitatiDeCazareDisponibile()
        {
            InitializeComponent();
        }

        private void btnDelog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void btnLocLiber_Click(object sender, RoutedEventArgs e)
        {
            LocuriLibere = new _LocuriLibere();
            LocuriLibere.Show();
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
