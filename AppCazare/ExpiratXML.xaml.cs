using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class ExpiratXML : Window
    {
        private inregistrareClient inregistrareClient;
        private MainWindow MainWindow;
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;

        public ExpiratXML()
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

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu = new Menu();
            Menu.Show();
            this.Close();
        }

        private void BtExpira_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = Properties.Settings.Default.CazareDBConnectionString;
            string query;
            query = "SELECT * FROM Turisti WHERE ziuaP = @ziua and lunaP = @luna and anulP = @anul";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ziua", tbZiua.Text);
                    command.Parameters.AddWithValue("@luna", tbLuna.Text);
                    command.Parameters.AddWithValue("@anul", tbAnul.Text);
                    if (tbZiua.Text == "" || tbLuna.Text == "" || tbAnul.Text == "")
                    {
                        MessageBox.Show("Eroare! Introdu datele");
                    }
                    else
                    {
                        command.ExecuteScalar();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet ds = new DataSet("Turisti");
                        DataTable dt = new DataTable("Turist");
                        ds.Tables.Add(dt);
                        adapter.Fill(ds.Tables["Turist"]);
                        ds.WriteXml("Expirat.xml");
                        MessageBox.Show("Datele a fost salvate in fisierul Expirat.xml");
                        tbZiua.Text = "";
                        tbLuna.Text = "";
                        tbAnul.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Introdu datele corecte");
                tbZiua.Text = "";
                tbLuna.Text = "";
                tbAnul.Text = "";
            }
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
    }
}
