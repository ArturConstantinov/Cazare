using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class scoateEvidenta : Window
    {
        private MainWindow MainWindow;        
        private prelungesteSejurul prelungesteSejurul;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;
        private inregistrareClient inregistrareClient;
        private scoateEvidenta scoate;
        private ExpiratXML ExpiratXML;

        public scoateEvidenta()
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

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu = new Menu();
            Menu.Show();
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
            quary = "SELECT * FROM Turisti";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(quary, conn);
                
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = Properties.Settings.Default.CazareDBConnectionString;
            string quary;
            quary = "DELETE FROM Turisti WHERE ziuaP = @ziua and lunaP = @luna and anulP = @anul or codT = @cod";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    dataGrid.ItemsSource = null;
                    int ziua;
                    int luna;
                    int anul;
                    if (tbZiua.Text == "" || tbLuna.Text == "" || tbAnul.Text == "")
                    {
                        ziua = 0;
                        luna = 0;
                        anul = 0;
                    }
                    else
                    {
                        ziua = int.Parse(tbZiua.Text);
                        luna = int.Parse(tbLuna.Text);
                        anul = int.Parse(tbAnul.Text);
                    }
                    SqlCommand command = new SqlCommand(quary, conn);
                    command.Parameters.AddWithValue("@ziua", ziua);
                    command.Parameters.AddWithValue("@luna", luna);
                    command.Parameters.AddWithValue("@anul", anul);
                    command.Parameters.AddWithValue("@cod", tbCod.Text);
                    conn.Open();
                    command.ExecuteNonQuery();
                    tbZiua.Text = "";
                    tbLuna.Text = "";
                    tbAnul.Text = "";
                    tbCod.Text = "";
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Turisti", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare! Incorect formatul de date.");
                scoate = new scoateEvidenta();
                this.Close();
                scoate.Show();
            }
        }
    }
}
