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
using System.Threading;
using System.Diagnostics;

namespace PracticaMovimiento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch;
        TimeSpan tiempoAnterior;

        public MainWindow()
        {
            InitializeComponent();
            miCanvas.Focus();

            stopwatch = new Stopwatch();
            stopwatch.Start();
            tiempoAnterior = stopwatch.Elapsed;

            //1.- Establecer instrucciones
            ThreadStart threadStart = new ThreadStart(moverEnemigos);
            //2.- Inicializar el Thread
            Thread threadMoverEnemigos = new Thread(threadStart);
            //3.- Ejecutar el Thread
            threadMoverEnemigos.Start();
        }

        void moverEnemigos()
        {
            while (true)
            {
                Dispatcher.Invoke(
                () =>
                {
                    var tiempoActual = stopwatch.Elapsed;
                    var deltaTime =
                        tiempoActual - tiempoAnterior;

                    double leftCarroActual =
                        Canvas.GetLeft(imgCarro);
                    Canvas.SetLeft(
                        imgCarro, leftCarroActual - (200 * deltaTime.TotalSeconds));
                    if (Canvas.GetLeft(imgCarro) <= -100)
                    {
                        Canvas.SetLeft(imgCarro, 800);
                    }
                    tiempoAnterior = tiempoActual;
                }
                );
            }

        }

        private void miCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            double topCatActual = Canvas.GetTop(imgCat);
            double leftCatActual = Canvas.GetLeft(imgCat);
            if (e.Key == Key.Up)
            {
                Canvas.SetTop(imgCat, topCatActual - 10);
            }
            if (e.Key == Key.Down)
            {
                Canvas.SetTop(imgCat, topCatActual + 10);
            }
            if (e.Key == Key.Left)
            {
                Canvas.SetLeft(imgCat, leftCatActual - 10);
            }
            if (e.Key == Key.Right)
            {
                Canvas.SetLeft(imgCat, leftCatActual + 10);
            }
        }
    }
}
