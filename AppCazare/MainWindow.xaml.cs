using System.Windows;
using System.Data.SqlClient;

namespace AppCazare
{
    public partial class MainWindow : Window
    {
        private Menu Menu;
        private _Menu _Menu;
        private createAccount createAccount;

        public MainWindow()
        {
            InitializeComponent();   
            
        }
          
        private void btnAtn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString = Properties.Settings.Default.UsersDBConnectionString;
            string quary;
            quary = "SELECT rang FROM Users WHERE username = '" + tbUsername.Text + "' AND password = '" + pbPass.Password + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(quary, connection);
                connection.Open();
                object ex = command.ExecuteScalar();
                if (ex == null)
                {
                    MessageBox.Show("Incorect Username or Password");
                }
                else
                {
                    string result = ex.ToString();
                    if (result == "1")
                    {
                        Menu = new Menu();
                        Menu.Show();
                        this.Close();
                    }
                    if (result == "2")
                    {
                        _Menu = new _Menu();
                        _Menu.Show();
                        this.Close();
                    }
                }
            }

                
        }

        private void btnCrUnCont_Click(object sender, RoutedEventArgs e)
        {
            createAccount = new createAccount();
            createAccount.Show();
            this.Close();
        }
    }
}
