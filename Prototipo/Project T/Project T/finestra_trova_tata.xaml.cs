using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        List<Tata> tmp;

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
                    tmp = new List<Tata>();

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
            int x = 1;
            if(x == 1)
            {
                MessageBox.Show("Pulsante disabilitato");
            }
            else
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("email del server smtp", "passowrd"),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("inserire l'email di partenza"),
                    Subject = "oggetto della mail",
                    Body = "Corpo dell mail",
                    IsBodyHtml = false,
                };
                var attachment = new Attachment(/*Allegati*/"");
                mailMessage.Attachments.Add(attachment);
                mailMessage.To.Add("Mail del destinatario");
                smtpClient.Send(mailMessage);
            }
            
        }

        private void btn_homePage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }

        private void listPersone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string email = tmp.ElementAt(listPersone.SelectedIndex).email;
            Bitmap b = db.PrendiFotoDalBD(email);
            img_tata.Source = Bitmap2BitmapImage(b);
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
