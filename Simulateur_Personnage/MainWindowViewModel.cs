using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Utilities;

namespace Simulateur_Personnage
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel()
        {
            InitializeCommand();
        }

        #region ICommands
        public ICommand QuitCommand { get; set; }
        public ICommand SimulationPacManCommand { get; set; }

        private void InitializeCommand()
        {
            QuitCommand = new RelayCommand(QuitExecuteCommand);
            SimulationPacManCommand = new RelayCommand(SimulationPacManExecuteCommand);
        }

        #endregion

        #region Commands

        private void QuitExecuteCommand()
        {
            Application.Current.Shutdown();
        }

        private void SimulationPacManExecuteCommand()
        {
            Grid grid;
            var simulateur = new SimulationJeu();
            simulateur.CreerPacMan(out grid);

            EventAggregatorClass.EventAggregator.GetEvent<EventAggregatorLoadMapEvent>().Publish(grid); ;
        }

        #endregion
    }

    public class DesignMainWindowViewModel
    {
        public DesignMainWindowViewModel()
        {

        }
    }

    public interface IMainWindowViewModel
    {
        ICommand QuitCommand { get; set; }
        ICommand SimulationPacManCommand { get; set; }
    }
}
