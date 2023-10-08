using InventarioDB.Models;
using InventarioDB.UI.Animations;
using InventarioDB.UI.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace InventarioDB.UI
{
    public partial class Salidas : Page
    {
        private int pageNumber = 1;
        private int pageSize = 20;

        public Salidas()
        {
            InitializeComponent();
            ShowSalida();
        }

        //Mostrar el contenido de la db en el DataGrid
        private void ShowSalida()
        {
            using var db = new InventarioDbContext();

            //var SalidaData = db.Salida.Include(e => e.Producto).ToList();
            var SalidaData = db.Salida.Include(e => e.Producto)
               .OrderByDescending(p => p.Fecha)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToList();

            if (SalidaData != null)
            {
                if (SalidaData.Count() > 0)
                {
                    DataGridView.ItemsSource = SalidaData;
                }
                else
                {
                    MessageBox.Show("No hay datos de salida.", "Información");
                    DataGridView.ItemsSource = null;
                }
            }

            // Calcular el número total de páginas
            int totalRecords = db.Salida.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Mostrar la información de la página actual
            PageInfoTextBlock.Text = $"Página {pageNumber} de {totalPages}";
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                ShowSalida();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            using var db = new InventarioDbContext();
            int totalRecords = db.Salida.Count();
            if ((pageNumber * pageSize) < totalRecords)
            {
                pageNumber++;
                ShowSalida();
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana para agregar un producto
            AgregarSalidaWindow agregarSalidaWindow = new AgregarSalidaWindow();
            agregarSalidaWindow.ShowDialog();

            // Después de agregar el registro, refresca el DataGrid.
            ShowSalida();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem != null)
            {
                // Obtiene el objeto seleccionado desde el DataGrid
                Salidum selectedSalida = (Salidum)DataGridView.SelectedItem;

                // Crea una instancia de tu contexto de base de datos
                using (var db = new InventarioDbContext())
                {
                    // Obtiene la lista de productos desde la base de datos
                    List<Producto> listaProductos = db.Productos.ToList();

                    // Abre la ventana para editar un producto, pasando el objeto Producto seleccionado y la lista de productos
                    EditarSalidaWindow editarWindow = new EditarSalidaWindow(selectedSalida, listaProductos);
                    editarWindow.ShowDialog();
                }

                // Después de editar el registro, refresca el DataGrid.
                ShowSalida();
            }
            else
            {
                MessageBox.Show("Selecciona un producto para editar.", "Error");
            }
        }


        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGrid
            if (DataGridView.SelectedItem != null)
            {
                // Obtiene el objeto seleccionado desde el DataGrid
                Salidum selectedSalida = (Salidum)DataGridView.SelectedItem;

                // Muestra un mensaje de confirmación antes de eliminar el registro
                MessageBoxResult result = MessageBox.Show("¿Seguro que quieres eliminar esta salida?", "Eliminar", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    using var db = new InventarioDbContext();

                    // Elimina el registro de la base de datos
                    db.Salida.Remove(selectedSalida);
                    db.SaveChanges();

                    // Después de eliminar el registro, refresca el DataGrid.
                    ShowSalida();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una salida para eliminar.", "Error");
            }
        }

        private void Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement targetElement = SalidaStack;
            Storyboard animationStoryboard = Deslizamientoabajo.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();
        }
    }
}
