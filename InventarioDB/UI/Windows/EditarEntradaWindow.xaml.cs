using InventarioDB.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace InventarioDB.UI.Windows
{
    public partial class EditarEntradaWindow : Window
    {
        private Entradum entradaEditar; // Una instancia de la clase "Entradum" que representa la entrada a editar.
        private List<Producto> productos; // Una colección de objetos "Producto".

        // Constructor de la ventana de edición de entrada.
        public EditarEntradaWindow(Entradum entrada, List<Producto> productos)
        {
            InitializeComponent();
            entradaEditar = entrada; // Asigna la entrada a editar.
            this.productos = productos; // Asigna la lista de productos.

            // Configura los campos de la ventana con los valores de la entrada existente.
            ObservacionTextBox.Text = entrada.Observacion;
            CantidadTextBox.Text = entrada.Cantidad.ToString();
            ProductoComboBox.ItemsSource = productos;

            // Establece el producto seleccionado en el ComboBox si la entrada tiene un ProductoId.
            if (entrada.ProductoId.HasValue)
            {
                ProductoComboBox.SelectedValue = entrada.ProductoId;
            }

            // Establece la fecha seleccionada si la entrada tiene una fecha válida.
            if (entrada.Fecha.HasValue)
            {
                FechaDatePicker.SelectedDate = entrada.Fecha.Value;
            }
        }

        // Manejador de eventos para el botón "Guardar".
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene los valores ingresados por el usuario.
            string observacion = ObservacionTextBox.Text;
            int cantidad;
            DateTime? fecha = FechaDatePicker.SelectedDate;
            DateTime? hora = HoraTimePicker.Value;
            int? productoid = ProductoComboBox.SelectedValue as int?;

            // Intenta convertir la cantidad ingresada a un entero.
            if (int.TryParse(CantidadTextBox.Text, out cantidad))
            {
                // Actualiza los valores de la entrada en la base de datos utilizando Entity Framework.
                using (var db = new InventarioDbContext())
                {
                    // Encuentra la entrada en la base de datos por su ID.
                    Entradum EntradaActualizada = db.Entrada.Find(entradaEditar.EntradaId);

                    if (EntradaActualizada != null)
                    {
                        // Actualiza los valores de la entrada con los nuevos valores.
                        EntradaActualizada.Observacion = observacion;
                        EntradaActualizada.Cantidad = cantidad;
                        EntradaActualizada.ProductoId = productoid;

                        if (fecha.HasValue)
                        {
                            EntradaActualizada.Fecha = fecha.Value;
                        }

                        if (hora.HasValue)
                        {
                            // Combina la fecha y la hora seleccionadas.
                            DateTime fechaYHoraSeleccionada = fecha.Value.Date + hora.Value.TimeOfDay;
                            EntradaActualizada.Fecha = fechaYHoraSeleccionada;
                        }

                        // Guarda los cambios en la base de datos.
                        db.SaveChanges();
                    }
                }

                // Cierra la ventana después de guardar.
                Close();
            }
            else
            {
                // Muestra un mensaje de error si la cantidad no es un número válido.
                MessageBox.Show("Los valores ingresados no son válidos.", "Error");
            }
        }

        // Manejador de eventos para el botón "Cancelar".
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cierra la ventana sin guardar cambios.
            Close();
        }
    }
}

