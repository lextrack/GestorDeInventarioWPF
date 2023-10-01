using InventarioDB.Properties;
using InventarioDB.UI.Animations;
using System.Windows;
using System.Windows.Media.Animation;

namespace InventarioDB.UI.Windows
{
    public partial class CambiarPassword : Window
    {
        string Pass = Settings.Default.enterpass;

        public CambiarPassword()
        {
            InitializeComponent();
        }

        private void CambiarPassbtn_Click(object sender, RoutedEventArgs e)
        {
            if (contraseñaActualBox.Password == Pass)
            {
                Settings.Default.enterpass = contraseñaNuevaBox.Password;
                Settings.Default.Save();
                MessageBox.Show("Tú contraseña ha sido cambiada con éxito", "Actualizar");

                Login login = new Login();
                login.Show();

                this.Close();
            }
            else if (string.IsNullOrEmpty(contraseñaActualBox.Password))
            {
                MessageBox.Show("Los campos no pueden quedar vacios", "Error");
            }
            else
            {
                MessageBox.Show("Ocurrio un error al realizar el cambio", "Error");
            }

        }

        private void VolverLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement targetElement = BotonesCambioPass;
            Storyboard animationStoryboard = DeslizamientoDerechaIzquierda.CreateFadeAndMoveAnimation(targetElement);
            animationStoryboard.Begin();
        }
    }
}
