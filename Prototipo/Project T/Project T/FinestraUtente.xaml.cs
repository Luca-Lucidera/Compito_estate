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
    /// Logica di interazione per FinestraUtente.xaml
    /// </summary>
    public partial class FinestraUtente : Window
    {
        DBConnect db;
        public FinestraUtente()
        {
            InitializeComponent();
            db = new DBConnect();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (db.loginUtente(txt_email.Text, txt_password.Password))
            {
                MessageBox.Show("Login effettuato");
            }
            else
            {
                MessageBox.Show("Errore, utente non registrato o email/password errate");
            }
        }

        private void btn_registrati_Click(object sender, RoutedEventArgs e)
        {
            int nTelefono = -1;
            try
            {
                nTelefono = Convert.ToInt32(txt_nTelefono.Text);
                if (db.registraUtente(txt_nome.Text, txt_cognome.Text, txt_email.Text, txt_password.Password, nTelefono))
                {
                    MessageBox.Show("Registrazione effettuata");
                }
                else
                {
                    MessageBox.Show("Utente già registrato, premere il tasto login");
                }
            }
            catch
            {
                MessageBox.Show("Inserire solo numeri!!");
            }
        }
    }
}
