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
    /// Logica di interazione per FinestraTata.xaml
    /// </summary>
    public partial class FinestraTata : Window
    {
        DBConnect db;
        public FinestraTata()
        {
            InitializeComponent();
            db = new DBConnect();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            if(db.loginTata(txt_email.Text,txt_password.Password))
            {
                MessageBox.Show("login effettuato!");
                List<string> tata = db.GetTata(txt_email.Text);
                Tata t = new Tata(tata);
                FinestraGestioneTata f = new FinestraGestioneTata(t);
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Attenzione, mail o password sbagliate!");
            }
            
           
        }

        private void btn_registrati_Click(object sender, RoutedEventArgs e)
        {
            string image_path = "alberto";
            if (db.registrati(txt_nome.Text, txt_cognome.Text, txt_email.Text, txt_password.Password, txt_zona_operativa1.Text, image_path))
            {
                MessageBox.Show("Registrazione completata!");
                
            }
            else
            {
                MessageBox.Show("Utente già registrato! Fare il login");
            }
        }

       
    }
}
