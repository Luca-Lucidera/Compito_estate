using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_T
{
    /// <summary>
    /// Logica di interazione per FinestraGestioneTata.xaml
    /// </summary>
    public partial class FinestraGestioneTata : Window
    {
        private Tata t;
        private DBConnect db;
        public FinestraGestioneTata()
        {
            InitializeComponent();
        }

        public FinestraGestioneTata(Tata t)
        {
            InitializeComponent();
            this.t = t;
            db = new DBConnect();
            AggiornaDati();
        }

        private void btn_cambia_email_Click(object sender, RoutedEventArgs e)
        {
            if (db.CambiaMail(txt_mail.Text, t.id))
            {
                MessageBox.Show("Cambio della mail avvenuto con successo!");
                AggiornaDati();
            }
            else
            {
                MessageBox.Show("Errore, impossibile collegarsi al server, riprovare più tardi");
            }
        }

        private void btn_cambia_pass_Click(object sender, RoutedEventArgs e)
        {

            if (db.CambiaPassword(txt_pass.Text, t.id))
            {
                MessageBox.Show("Cambio della password avvenuto con successo!");
                AggiornaDati();
            }
            else
            {
                MessageBox.Show("Errore, impossibile collegarsi al server, riprovare più tardi");
            }

        }

        private void btn_cambia_zo_Click(object sender, RoutedEventArgs e)
        {

            if (db.cambiaZonaOperativa(txt_zo.Text, t.id))
            {
                MessageBox.Show("Cambio della zona operativa avvenuto con successo!");
                AggiornaDati();
            }
            else
            {
                MessageBox.Show("Errore, impossibile collegarsi al server, riprovare più tardi");
            }

        }

        private void btn_cambia_occupazione_Click(object sender, RoutedEventArgs e)
        {
            if (db.CambiaOccupazione(t.id))
            {
                MessageBox.Show("Cambio di occupazione avvenuto con successo!");
                AggiornaDati();
            }
            else
            {
                MessageBox.Show("Errore, impossibile collegarsi al server, riprovare più tardi");
            }
        }
        public void AggiornaDati()
        {
            string email = db.getEmailById(t.id);
            List<string> tata = db.GetTata(email);
            t = new Tata(tata);
            Bitmap b = db.PrendiFotoDalBD(email);

            immagine_profilo.Source = Bitmap2BitmapImage(b);
            lbl_mail.Content = t.email;
            lbl_password.Content = t.psw;
            lbl_zona.Content = t.zona_operativa;
            if (t.occupata)
            {
                lbl_occupata.Content = "Occupata";
            }
            else
            {
                lbl_occupata.Content = "Libera";

            }
        }

        private void btn_homePage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
