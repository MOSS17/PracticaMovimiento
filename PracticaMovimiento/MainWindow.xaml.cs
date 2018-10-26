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

namespace PracticaMovimiento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            miCanvas.Focus();
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
