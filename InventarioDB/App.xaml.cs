using System.Windows;

namespace InventarioDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConnectionString = "Data Source=(local); Database=InventarioDB; Trusted_Connection=True; Trust Server Certificate=True;";
        }
    }

}
