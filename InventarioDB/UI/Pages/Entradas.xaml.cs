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
    public partial class Entradas : Page
    {
        private int pageNumber = 1;
        private int pageSize = 20;
        public Entradas()
        {
            InitializeComponent();
            ShowEntrada();
        }

        //Mostrar el contenido de la db en el DataGrid
        private void ShowEntrada()
        {
            using var db = new InventarioDbContext();

            //var EntradaData = db.Entrada.Include(e => e.Producto).ToList();
            var EntradaData = db.Entrada.Include(e => e.Producto)
                .OrderByDescending(p => p.Fecha)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            if (EntradaData != null)
            {
                if (EntradaData.Count() > 0)
                {
                    DataGridView.ItemsSource = EntradaData;
                }
                else
                {
                    DataGridView.ItemsSource = null;
                }
            }

            // Calcular el número total de páginas
            int totalRecords = db.Entrada.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Mostrar la información de la página actual
            PageInfoTextBlock.Text = $"Página {pageNumber} de {totalPages}";
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                ShowEntrada();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            using var db = new InventarioDbContext();
            int totalRecords = db.Entrada.Count();
            if ((pageNumber * pageSize) < totalRecords)
            {
                pageNumber++;
                ShowEntrada();
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana para agregar un producto
            AgregarEntradaWindow agregarEntradaWindow = new AgregarEntradaWindow();
            agregarEntradaWindow.ShowDialog();

            // Después de agregar el registro, refresca el DataGrid.
            ShowEntrada();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem != null)
            {
                // Obtiene el objeto seleccionado desde el DataGrid
                Entradum selectedEntrada = (Entradum)DataGridView.SelectedItem;

                // Crea una instancia de tu contexto de base de datos
                using (var db = new InventarioDbContext())
                {
                    // Obtiene la lista de productos desde la base de datos
                    List<Producto> listaProductos = db.Productos.ToList();

                    // Abre la ventana para editar un producto, pasando el objeto Producto seleccionado y la lista de productos
                    EditarEntradaWindow editarWindow = new EditarEntradaWindow(selectedEntrada, listaProductos);
                    editarWindow.ShowDialog();
                }

                // Después de editar el registro, refresca el DataGrid.
                ShowEntrada();
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
                Entradum selectedEntrada = (Entradum)DataGridView.SelectedItem;

                // Muestra un mensaje de confirmación antes de eliminar el registro
                MessageBoxResult result = MessageBox.Show("¿Seguro que quieres eliminar esta entrada?", "Eliminar", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    using var db = new InventarioDbContext();

                    // Elimina el registro de la base de datos
                    db.Entrada.Remove(selectedEntrada);
                    db.SaveChanges();

                    // Después de eliminar el registro, refresca el DataGrid.
                    ShowEntrada();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una entrada para eliminar.", "Error");
            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement targetElement = EntradaStack;
            Storyboard animationStoryboard = Deslizamientoabajo.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();
        }
    }
}
