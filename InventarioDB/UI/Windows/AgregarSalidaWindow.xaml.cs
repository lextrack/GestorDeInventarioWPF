using InventarioDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace InventarioDB.UI.Windows
{
    /// <summary>
    /// Interaction logic for AgregarSalidaWindow.xaml
    /// </summary>
    public partial class AgregarSalidaWindow : Window
    {
        public AgregarSalidaWindow()
        {
            InitializeComponent();
            Loaded += AgregarSalidaWindow_Loaded;
        }

        private void AgregarSalidaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtén y asigna los productos al ComboBox
            using (var db = new InventarioDbContext())
            {
                List<Producto> listaProductos = db.Productos.ToList();
                ProductoComboBox.ItemsSource = listaProductos;
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los valores ingresados por el usuario
            int cantidad;
            string observacion = ObservacionTextBox.Text;
            Producto productoSeleccionado = (Producto)ProductoComboBox.SelectedItem;
            DateTime? fecha = FechaDatePicker.SelectedDate;
            DateTime? hora = HoraTimePicker.Value;

            if (fecha.HasValue && hora.HasValue && int.TryParse(CantidadTextBox.Text, out cantidad))
            {
                DateTime fechaYHoraSeleccionada = fecha.Value.Date + hora.Value.TimeOfDay;

                // Crea una nueva salida Salidum y asigna los valores
                Salidum nuevaSalida = new Salidum
                {
                    ProductoId = productoSeleccionado.ProductoId, // Asigna el ID del objeto Producto seleccionado
                    Observacion = observacion,
                    Cantidad = cantidad,
                    Fecha = fechaYHoraSeleccionada, // Asigna la fecha y hora seleccionadas
                };

                // Agrega la nueva salida a la base de datos utilizando Entity Framework
                using (var db = new InventarioDbContext())
                {
                    db.Salida.Add(nuevaSalida);
                    db.SaveChanges();
                }

                Close();
            }
            else
            {
                MessageBox.Show("Los valores ingresados no son válidos o has dejado algún campo en blanco.", "Error");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumericOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
