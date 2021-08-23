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

namespace Project_T
{
    /// <summary>
    /// Logica di interazione per finestra_trova_tata.xaml
    /// </summary>
    public partial class finestra_trova_tata : Window
    {
        DBConnect db;
        public finestra_trova_tata()
        {
            InitializeComponent();
            db = new DBConnect();
        }

        private void btn_cerca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string>[] tabella= db.Cerca(txt_zona.Text);
                if(tabella != null)
                {
                    List<Tata> tmp = new List<Tata>();

                    for (int i = 0; i < tabella[0].Count; i++)
                    {
                        Tata tm = new Tata();
                        tm.nome = tabella[0].ElementAt(i);
                        tm.cognome = tabella[1].ElementAt(i);
                        tm.email = tabella[2].ElementAt(i);
                        tm.zona_operativa = tabella[3].ElementAt(i);
                        tmp.Add(tm);
                    }
                    listPersone.ItemsSource = tmp;
                }
                else
                {
                    MessageBox.Show("Nessun operatore in servizio");
                }

            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_contatta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_zona_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_homePage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }
    }
}
