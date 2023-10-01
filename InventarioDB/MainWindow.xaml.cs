using InventarioDB.UI;
using InventarioDB.UI.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace InventarioDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string IconPath { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            comboBoxPaginas.ItemsSource = new List<ComboBoxItem>
            {
                new ComboBoxItem { Text = "Productos", IconPath = "Resources/producto.png" },
                new ComboBoxItem { Text = "Entradas", IconPath = "Resources/entrada.png" },
                new ComboBoxItem { Text = "Salidas", IconPath = "Resources/salida.png" }
            };

            frame.NavigationService.Navigate(new Productos());
        }

        private void ComboBoxPaginas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem itemSeleccionado = (ComboBoxItem)comboBoxPaginas.SelectedItem;

            if (itemSeleccionado != null)
            {
                string paginaSeleccionada = itemSeleccionado.Text;

                switch (paginaSeleccionada)
                {
                    case "Productos":

                        Storyboard sb1 = (Storyboard)this.Resources["PageTransition"];
                        Storyboard.SetTarget(sb1, frame);
                        sb1.Begin();

                        frame.NavigationService.Navigate(new Productos());
                        break;

                    case "Entradas":

                        Storyboard sb2 = (Storyboard)this.Resources["PageTransition"];
                        Storyboard.SetTarget(sb2, frame);
                        sb2.Begin();

                        frame.NavigationService.Navigate(new Entradas());
                        break;

                    case "Salidas":

                        Storyboard sb3 = (Storyboard)this.Resources["PageTransition"];
                        Storyboard.SetTarget(sb3, frame);
                        sb3.Begin();

                        frame.NavigationService.Navigate(new Salidas());
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }
    }
}
