using InventarioDB.Models;
using System;
using System.Windows;

namespace InventarioDB.UI
{
    /// <summary>
    /// Lógica de interacción para EditarProductoWindow.xaml
    /// </summary>
    public partial class EditarProductoWindow : Window
    {
        private Producto productoEditar;

        public EditarProductoWindow(Producto producto)
        {
            InitializeComponent();
            productoEditar = producto;

            // Llena los campos con los valores actuales del producto selectedProductcionado
            NombreTextBox.Text = producto.Nombre;
            ResponsableTextBox.Text = producto.Responsable;
            SkuTextBox.Text = producto.Sku.ToString(); // Convierte el valor SKU a cadena
            ValorTextBox.Text = producto.Valor.ToString(); // Convierte el valor a cadena
            CantidadTextBox.Text = producto.Cantidad.ToString(); // Convierte cantidad a cadena
            StockMinimoTextBox.Text = producto.StockMinimo.ToString(); // Convierte stock en cadena

            if (producto.Fecha.HasValue)
            {
                FechaDatePicker.SelectedDate = producto.Fecha.Value;
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los valores ingresados por el usuario
            string nombre = NombreTextBox.Text;
            string responsable = ResponsableTextBox.Text;
            int sku;
            decimal valor;
            int cantidad;
            int stock;
            DateTime? fecha = FechaDatePicker.SelectedDate;
            DateTime? hora = HoraTimePicker.Value;

            // Sí logra convertir los strings a int o decimal...
            if (int.TryParse(StockMinimoTextBox.Text, out stock) && (int.TryParse(CantidadTextBox.Text, out cantidad) && (int.TryParse(SkuTextBox.Text, out sku) && decimal.TryParse(ValorTextBox.Text, out valor))))
            {
                // Actualiza los valores del producto en la base de datos utilizando Entity Framework
                using (var db = new InventarioDbContext())
                {
                    Producto productoActualizado = db.Productos.Find(productoEditar.ProductoId);

                    if (productoActualizado != null)
                    {
                        productoActualizado.Nombre = nombre;
                        productoActualizado.Responsable = responsable;
                        productoActualizado.Sku = sku;
                        productoActualizado.Valor = valor;
                        productoActualizado.Cantidad = cantidad;
                        productoActualizado.StockMinimo = stock;

                        if (fecha.HasValue)
                        {
                            productoActualizado.Fecha = fecha.Value;
                        }

                        if (hora.HasValue)
                        {
                            // Combina la fecha y la hora seleccionadas.
                            DateTime fechaYHoraSeleccionada = fecha.Value.Date + hora.Value.TimeOfDay;
                            productoActualizado.Fecha = fechaYHoraSeleccionada;
                        }

                        db.SaveChanges();
                    }
                }

                // Cierra la ventana
                Close();
            }
            else
            {
                MessageBox.Show("Los valores ingresados no son válidos.", "Error");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cierra la ventana sin guardar
            Close();
        }

    }
}
