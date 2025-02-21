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
            LoginButton.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;

            try
            {
                // Se comprueba que la contraseña en el "combobox" coincida
                if (passwordBox.Password == Pass)
                {
                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error");
                    Vibracion.StartVibrationAnimation(passwordBox);
                    passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
                LoginButton.IsEnabled = true;
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
            UIElement targetElement = BotonesLogin;
            Storyboard animationStoryboard = DeslizamientoIzquierdaDerecha.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();

        }
    }
}
