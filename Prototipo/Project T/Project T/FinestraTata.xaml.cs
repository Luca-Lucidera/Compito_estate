using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Fotocamera;

namespace Project_T
{
    /// <summary>
    /// Logica di interazione per FinestraTata.xaml
    /// </summary>
    public partial class FinestraTata : Window
    {
        DBConnect db;
        string nome_cognome;
        public FinestraTata()
        {
            InitializeComponent();
            db = new DBConnect();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            if(db.loginTata(txt_email.Text,txt_password.Password))
            {
                //MessageBox.Show("login effettuato!");
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
            string path = String.Format(@"../../../Foto/{0}.png",nome_cognome);
            if (db.registrati(txt_nome.Text, txt_cognome.Text, txt_email.Text, txt_password.Password, txt_zona_operativa1.Text, path))
            {
                MessageBox.Show("Tata registrata, premere tasto login!");
            }
            else
            {
                MessageBox.Show("Utente già registrato! Fare il login");
            }
        }

        private void btn_homePage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn_registrati.IsEnabled = true;
            nome_cognome = txt_cognome.Text + "_" + txt_nome.Text;
            Form1 f = new Form1(nome_cognome);
            f.Show();
        }

        private void txt_cognome_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(txt_nome.Text != "" && txt_cognome.Text != "")
            {
                btn_foto.IsEnabled = true;
            }
            else
            {
                btn_foto.IsEnabled = false;
            }
        }
       
    }
}
