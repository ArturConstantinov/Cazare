using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class prelungesteSejurul : Window
    {
        private inregistrareClient inregistrareClient;
        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;        
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;
        private prelungesteSejurul prelungeste;
        private ExpiratXML ExpiratXML;

        string connectionString;

        public prelungesteSejurul()
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
                conn.Close();
            }
        }

        private void BtPrelungeste_Click(object sender, RoutedEventArgs e)
        {
            connectionString = Properties.Settings.Default.CazareDBConnectionString;
            string quary;
            quary = "UPDATE Turisti SET ziuaP = @ziua, lunaP = @luna, anulP = @anul WHERE codT = @cod";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(quary, conn);
                    command.Parameters.AddWithValue("@ziua", tbZiua.Text);
                    command.Parameters.AddWithValue("@luna", tbLuna.Text);
                    command.Parameters.AddWithValue("@anul", tbAnul.Text);
                    command.Parameters.AddWithValue("@cod", tbCod.Text);

                    if (tbZiua.Text == "" || tbLuna.Text == "" || tbAnul.Text == "" || tbCod.Text == "")
                    {
                        MessageBox.Show("Introdu toate datele.");
                    }
                    else
                    {
                        dataGrid.ItemsSource = null;
                        conn.Open();
                        command.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Turisti", conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGrid.ItemsSource = dt.DefaultView;
                        conn.Close();
                        MessageBox.Show("Termenul a fost prelungit");
                        tbZiua.Text = "";
                        tbLuna.Text = "";
                        tbAnul.Text = "";
                        tbCod.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare! Incorect formatul de date.");
                prelungeste = new prelungesteSejurul();
                this.Close();
                prelungeste.Show();
            }
        }
    }
}
