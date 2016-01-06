using System.Windows.Controls;
using Simulateur_Personnage.Utilities;

namespace Simulateur_Personnage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = App.MainWindowViewModel;
            EventAggregatorClass.EventAggregator.GetEvent<EventAggregatorLoadMapEvent>().Subscribe(SimulationGridLoad);
        }

        private void SimulationGridLoad(object obj)
        {
            SimulationGrid.Children.Clear();
            SimulationGrid.Children.Add((Grid)obj);
        }
    }
}
