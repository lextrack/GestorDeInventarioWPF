using InventarioDB.Properties;
using InventarioDB.UI.Windows;
using Microsoft.Data.SqlClient;
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
using System.Windows.Shapes;

namespace InventarioDB
{
    public partial class ConfigWindow : Window
    {
        // Evento para notificar cuando la conexión ha sido configurada
        public event EventHandler<bool> ConnectionConfigured;

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string serverName = ServerNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(serverName))
            {
                MessageBox.Show("Por favor, ingrese el nombre del servidor.", "Error");
                return;
            }

            // Construir la cadena de conexión
            string connectionString = $"Server={serverName}; Database=InventarioDB; Trusted_Connection=True; Trust Server Certificate=True;";

            // Probar la conexión
            if (!TestConnection(connectionString))
            {
                MessageBox.Show("No se pudo conectar al servidor. Verifique el nombre del servidor e intente nuevamente.", "Error");
                return;
            }

            // Guardar la cadena de conexión
            App.ConnectionString = connectionString;
            Settings.Default.ConnectionString = connectionString;
            Settings.Default.Save();

            ConnectionConfigured?.Invoke(this, true);
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}