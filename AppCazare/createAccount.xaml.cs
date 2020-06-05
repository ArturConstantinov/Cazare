using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class createAccount : Window
    {
        private MainWindow MainWindow;

        public createAccount()
        {
            InitializeComponent();
        }

        private void btnInapoi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            UsersDBDataSet dBDataSet = new UsersDBDataSet();
            string connectionString;
            connectionString = Properties.Settings.Default.UsersDBConnectionString;

            if (pbPass.Password != pbPassRepeat.Password)
            {
                MessageBox.Show("Parola nu coincide!");
                return;
            }
            if (tbUsername.Text.Length < 4)
            {
                MessageBox.Show("User name este prea scurt");
                return;
            }
            if (pbPass.Password.Length < 4)
            {
                MessageBox.Show("Password este prea scurt");
                return;
            }

            string quary;
            quary = "SELECT * FROM Users";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(quary, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    DataRow nRow = dt.NewRow();
                    nRow["username"] = tbUsername.Text;
                    nRow["password"] = pbPass.Password;
                    nRow["rang"] = 2;
                    dt.Rows.Add(nRow);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                
                    tbUsername.Text = "";
                    pbPass.Password = "";
                    pbPassRepeat.Password = "";
                    MessageBox.Show("Utilizator nou este creat!");

                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exception!");
            }
}
    }
}
