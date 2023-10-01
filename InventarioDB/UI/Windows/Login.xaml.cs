using InventarioDB.Properties;
using InventarioDB.UI.Animations;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace InventarioDB.UI.Windows
{
    public partial class Login : Window
    {
        string Pass = Settings.Default.enterpass;
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false; // Deshabilita el botón de inicio de sesión
            Mouse.OverrideCursor = Cursors.Wait; // Cambia el cursor a un indicador de espera

            try
            {
                // Resto del código de inicio de sesión
                if (passwordBox.Password == Pass)
                {
                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error");
                    Vibrations.StartVibrationAnimation(passwordBox);
                    passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            finally
            {
                Mouse.OverrideCursor = null; // Restaura el cursor al valor predeterminado
                LoginButton.IsEnabled = true; // Habilita nuevamente el botón de inicio de sesión
            }
        }

        private void CambiarPass_Click(object sender, RoutedEventArgs e)
        {
            CambiarPassword cambiarpass = new();
            cambiarpass.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UIElement targetElement = BotonesLogin; // Reemplaza esto con tu elemento de destino
            Storyboard animationStoryboard = DeslizamientoIzquierdaDerecha.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();

        }
    }
}
