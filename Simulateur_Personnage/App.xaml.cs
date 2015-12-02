namespace Simulateur_Personnage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static MainWindowViewModel MainWindowViewModel { get; set; }

        public App()
        {
            MainWindowViewModel = new MainWindowViewModel();
        }
    }
}
