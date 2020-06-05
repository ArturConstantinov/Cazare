using System.Windows;

namespace AppCazare
{
    public partial class _Menu : Window
    {
        private MainWindow MainWindow;
        private _pretulMediu pretulMediu;
        private _celScumpIeftinLoc celScumpIeftinLoc;
        private _LocuriLibere LocuriLibere;
        private _unitatiDeCazareDisponibile unitatiDeCazareDisponibile;

        public _Menu()
        {
            InitializeComponent();
        }

        private void btnDelog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }



        private void btnUnitatiDisp_Click(object sender, RoutedEventArgs e)
        {
            unitatiDeCazareDisponibile = new _unitatiDeCazareDisponibile();
            unitatiDeCazareDisponibile.Show();
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
    }
}
