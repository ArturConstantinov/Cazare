using System;
using System.Windows;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class inregistrareClient : Window
    {
        private MainWindow MainWindow;        
        private scoateEvidenta scoateEvidenta;
        private prelungesteSejurul prelungesteSejurul;
        private unitatiDeCazareDisponibile unitatiDeCazareDisponibile;
        private LocuriLibere LocuriLibere;
        private pretulMediu pretulMediu;
        private celScumpIeftinLoc celScumpIeftinLoc;
        private Menu Menu;
        private ExpiratXML ExpiratXML;

        public inregistrareClient()
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

        private void BtInregestrare_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = Properties.Settings.Default.CazareDBConnectionString;
            string sql;
            sql = "INSERT INTO Turisti (numeT, prenumeT, SB, NB, ziuaC, lunaC, anulC, ziuaP, lunaP, anulP, codC) " +
                  "VALUES (@numeT, @prenumeT, @SB, @NB, @ziuaC, @lunaC, @anulC, @ziuaP, @lunaP, @anulP, @codC)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@numeT", tbNumeT.Text);
                    command.Parameters.AddWithValue("@prenumeT", tbPrenumeT.Text);
                    command.Parameters.AddWithValue("@SB", tbSB.Text);
                    command.Parameters.AddWithValue("@NB", tbNB.Text);
                    command.Parameters.AddWithValue("@ziuaC", tbZiuaC.Text);
                    command.Parameters.AddWithValue("@lunaC", tbLunaC.Text);
                    command.Parameters.AddWithValue("@anulC", tbAnulC.Text);
                    command.Parameters.AddWithValue("@ziuaP", tbZiuaP.Text);
                    command.Parameters.AddWithValue("@lunaP", tbLunaP.Text);
                    command.Parameters.AddWithValue("@anulP", tbAnulP.Text);
                    command.Parameters.AddWithValue("@codC", tbCodC.Text);

                    if (tbNumeT.Text == "" || tbPrenumeT.Text == "" || tbSB.Text == "" || tbNB.Text == "" || tbZiuaC.Text == "" ||
                        tbLunaC.Text == "" || tbAnulC.Text == "" || tbZiuaP.Text == "" || tbLunaP.Text == "" || tbAnulP.Text == "" ||
                        tbCodC.Text == "")
                    {
                        MessageBox.Show("Va rugam introduceti toate datele.");
                    }
                    else
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Turistul a fost inregestrat.");
                        conn.Close();
                        tbNumeT.Text = "";
                        tbPrenumeT.Text = "";
                        tbSB.Text = "";
                        tbNB.Text = "";
                        tbZiuaC.Text = "";
                        tbLunaC.Text = "";
                        tbAnulC.Text = "";
                        tbZiuaP.Text = "";
                        tbLunaP.Text = "";
                        tbAnulP.Text = "";
                        tbCodC.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare! Va rugam introduceti toate datele corect.");
                tbNumeT.Text = "";
                tbPrenumeT.Text = "";
                tbSB.Text = "";
                tbNB.Text = "";
                tbZiuaC.Text = "";
                tbLunaC.Text = "";
                tbAnulC.Text = "";
                tbZiuaP.Text = "";
                tbLunaP.Text = "";
                tbAnulP.Text = "";
                tbCodC.Text = "";
            }
        }
    }
}
