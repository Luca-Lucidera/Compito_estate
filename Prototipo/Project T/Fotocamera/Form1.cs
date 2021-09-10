using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Fotocamera
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
        string nomeC = "";
        public Form1()
        {
            InitializeComponent();
            CaptureCamera();
            isCameraRunning = true;
        }
        public Form1(string nome_cognome)
        {
            InitializeComponent();
            CaptureCamera();
            isCameraRunning = true;
            nomeC = nome_cognome;
        }
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Take snapshot of the current image generate by OpenCV in the Picture Box
            Bitmap snapshot = new Bitmap(pictureBox1.Image);
            snapshot.Save(String.Format(@"../../../foto/{0}.png",nomeC));
            MessageBox.Show("Foto fatta con successo!");
            this.Hide();
        }
    }
}
