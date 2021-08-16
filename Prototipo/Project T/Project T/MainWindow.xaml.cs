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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_T
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnect db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DBConnect();
        }

        private void btn_utente_Click(object sender, RoutedEventArgs e)
        {
            FinestraUtente u = new FinestraUtente();
            u.Show();
            this.Hide();
        }

        private void btn_tata_Click(object sender, RoutedEventArgs e)
        {
            FinestraTata t = new FinestraTata();
            this.Hide();
            t.Show();
        }
    }
}
