using InventarioDB.UI.Windows;
using Microsoft.Data.SqlClient;
using System.Windows;
using InventarioDB.Properties;

namespace InventarioDB
{
    public partial class App : Application
    {
        public static string ConnectionString { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Cargar la cadena de conexión desde la configuración
            ConnectionString = Settings.Default.ConnectionString;

            // Verificar si la cadena de conexión está configurada y es válida
            if (string.IsNullOrEmpty(ConnectionString) || !TestConnection(ConnectionString))
            {
                // Mostrar la ventana de configuración de la conexión
                ConfigWindow configWindow = new ConfigWindow();
                configWindow.ConnectionConfigured += OnConnectionConfigured;
                configWindow.Show();
            }
            else
            {
                ShowLoginWindow();
            }
        }

        private void OnConnectionConfigured(object sender, bool success)
        {
            if (success)
            {
                ShowLoginWindow();
            }
            else
            {
                MessageBox.Show("No se configuró una conexión válida a la base de datos. La aplicación se cerrará.", "Error");
                Shutdown();
            }
        }

        private void ShowLoginWindow()
        {
            Login loginWindow = new Login();
            loginWindow.Show();

            foreach (Window window in Current.Windows)
            {
                if (window is ConfigWindow)
                {
                    window.Close();
                }
            }
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