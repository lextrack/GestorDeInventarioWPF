﻿using InventarioDB.Models;
using InventarioDB.UI.Animations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace InventarioDB.UI
{
    public partial class Productos : Page
    {
        private int pageNumber = 1;
        private int pageSize = 20;

        public Productos()
        {
            InitializeComponent();
            ShowProducts();
        }

        // Mostrar el contenido de la db en el DataGrid con paginación
        private void ShowProducts(string searchQuery = "")
        {
            try
            {
                // Establece una conexión a la base de datos utilizando el contexto de la base de datos InventarioDbContext.
                using var db = new InventarioDbContext();

                // Intenta acceder a la base de datos para verificar la conexión.
                if (!db.Database.CanConnect())
                {
                    MessageBox.Show("No se pudo conectar a la base de datos.");
                    return; 
                }

                // Realiza una consulta a través de Entity Framework Core para recuperar datos de la tabla "Productos".
                var productoData = db.Productos
                    .Where(p => p.Nombre.Contains(searchQuery)) // Se indica que la busqueda se hará por el nombre del producto
                    .OrderByDescending(p => p.Fecha)  // Ordena los resultados por el campo "Fecha", aunque se puede usar el ID también.
                    .Skip((pageNumber - 1) * pageSize)  // Salta registros para llegar a la página deseada.
                    .Take(pageSize)  // Toma una cantidad específica de registros (tamaño de página).
                    .ToList();  // Ejecuta la consulta y obtiene los resultados en una lista.

                if (productoData != null)
                {
                    if (productoData.Count > 0)
                    {
                        DataGridView.ItemsSource = productoData;
                    }
                    else
                    {
                        DataGridView.ItemsSource = null;
                    }
                }

                // Calcular el número total de páginas
                int totalRecords = db.Productos.Count();
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Mostrar la información de la página actual
                PageInfoTextBlock.Text = $"Página {pageNumber} de {totalPages}";
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y muestra un mensaje de error.
                MessageBox.Show($"Error al acceder a la base de datos: {ex.Message}", "Error");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ShowProducts(SearchBox.Text);
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                ShowProducts();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            using var db = new InventarioDbContext();
            int totalRecords = db.Productos.Count();
            if ((pageNumber * pageSize) < totalRecords)
            {
                pageNumber++;
                ShowProducts();
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarProductoWindow agregarWindow = new AgregarProductoWindow();
            agregarWindow.ShowDialog();

            // Después de agregar el registro, refresca el DataGrid.
            ShowProducts();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si se ha seleccionado una fila en el DataGrid
            if (DataGridView.SelectedItem != null)
            {
                // Obtiene el objeto seleccionado desde el DataGrid
                Producto selectedProduct = (Producto)DataGridView.SelectedItem;

                // Abre la ventana para editar un producto, pasando el objeto Producto seleccionado
                EditarProductoWindow editarWindow = new EditarProductoWindow(selectedProduct);
                editarWindow.ShowDialog();

                // Después de editar el registro, refresca el DataGrid.
                ShowProducts();
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
                Producto selectedProduct = (Producto)DataGridView.SelectedItem;

                // Muestra un mensaje de confirmación antes de eliminar el registro
                MessageBoxResult result = MessageBox.Show("¿Seguro que quieres eliminar este producto?", "Eliminar", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    using var db = new InventarioDbContext();

                    // Elimina el registro de la base de datos
                    db.Productos.Remove(selectedProduct);
                    db.SaveChanges();

                    // Después de eliminar el registro, refresca el DataGrid.
                    ShowProducts();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.", "Error");
            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement targetElement = ProductoStack;
            Storyboard animationStoryboard = Deslizamientoabajo.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();
        }
    }
}

