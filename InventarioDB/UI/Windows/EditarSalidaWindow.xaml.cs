using InventarioDB.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace InventarioDB.UI.Windows
{
    /// <summary>
    /// Interaction logic for EditarSalidaWindow.xaml
    /// </summary>
    public partial class EditarSalidaWindow : Window
    {
        private Salidum salidaEditar;
        private List<Producto> productos; // Colección de productos
        public EditarSalidaWindow(Salidum salida, List<Producto> productos)
        {
            InitializeComponent();
            salidaEditar = salida;
            this.productos = productos;

            ObservacionTextBox.Text = salida.Observacion;
            CantidadTextBox.Text = salida.Cantidad.ToString();
            ProductoComboBox.ItemsSource = productos;

            if (salida.ProductoId.HasValue)
            {
                ProductoComboBox.SelectedValue = salida.ProductoId;
            }


            if (salida.Fecha.HasValue)
            {
                FechaDatePicker.SelectedDate = salida.Fecha.Value;
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los valores ingresados por el usuario
            string observacion = ObservacionTextBox.Text;
            int cantidad;
            DateTime? fecha = FechaDatePicker.SelectedDate;
            DateTime? hora = HoraTimePicker.Value;
            int? productoid = ProductoComboBox.SelectedValue as int?;

            // Sí logra convertir los strings a int o decimal...
            if (int.TryParse(CantidadTextBox.Text, out cantidad))
            {
                // Actualiza los valores del producto en la base de datos utilizando Entity Framework
                using (var db = new InventarioDbContext())
                {
                    Salidum SalidaActualizada = db.Salida.Find(salidaEditar.SalidaId);

                    if (SalidaActualizada != null)
                    {
                        SalidaActualizada.Observacion = observacion;
                        SalidaActualizada.Cantidad = cantidad;
                        SalidaActualizada.ProductoId = productoid;

                        if (fecha.HasValue)
                        {
                            SalidaActualizada.Fecha = fecha.Value;
                        }

                        if (hora.HasValue)
                        {
                            // Combinar fecha y hora seleccionadas
                            DateTime fechaYHoraSeleccionada = fecha.Value.Date + hora.Value.TimeOfDay;
                            SalidaActualizada.Fecha = fechaYHoraSeleccionada;
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
