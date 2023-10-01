using InventarioDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace InventarioDB.UI.Windows
{
    public partial class AgregarEntradaWindow : Window
    {
        public AgregarEntradaWindow()
        {
            InitializeComponent();
            Loaded += AgregarEntradaWindow_Loaded; // Asociar el evento Loaded
        }

        // Este método se ejecuta cuando la ventana se carga (evento Loaded).
        private void AgregarEntradaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtén y asigna los productos al ComboBox desde la base de datos.
            using (var db = new InventarioDbContext())
            {
                List<Producto> listaProductos = db.Productos.ToList();
                ProductoComboBox.ItemsSource = listaProductos;
            }
        }

        // Manejador de eventos para el botón "Guardar".
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los valores ingresados por el usuario.
            int cantidad;
            string observacion = ObservacionTextBox.Text;
            Producto productoSeleccionado = (Producto)ProductoComboBox.SelectedItem;
            DateTime? fecha = FechaDatePicker.SelectedDate;
            DateTime? hora = HoraTimePicker.Value;

            // Comprueba si se ingresaron valores válidos.
            if (fecha.HasValue && hora.HasValue && int.TryParse(CantidadTextBox.Text, out cantidad))
            {
                DateTime fechaYHoraSeleccionada = fecha.Value.Date + hora.Value.TimeOfDay;

                // Crea una nueva entrada Entradum y asigna los valores.
                Entradum nuevaEntrada = new Entradum
                {
                    ProductoId = productoSeleccionado.ProductoId, // Asigna el ID del objeto Producto seleccionado.
                    Observacion = observacion,
                    Cantidad = cantidad,
                    Fecha = fechaYHoraSeleccionada, // Asigna la fecha y hora seleccionadas.
                };

                // Agrega la nueva entrada a la base de datos utilizando Entity Framework.
                using (var db = new InventarioDbContext())
                {
                    db.Entrada.Add(nuevaEntrada);
                    db.SaveChanges();
                }

                // Cierra la ventana después de agregar la entrada.
                Close();
            }
            else
            {
                // Muestra un mensaje de error si los valores no son válidos.
                MessageBox.Show("Los valores ingresados no son válidos, el producto seleccionado ya no existe o no se ingresó una fecha y hora correctas.", "Error");
            }
        }

        // Manejador de eventos para el botón "Cancelar".
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cierra la ventana sin agregar la entrada.
            Close();
        }
    }
}


