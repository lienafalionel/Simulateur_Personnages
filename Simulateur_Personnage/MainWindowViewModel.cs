using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Simulateur_Personnage.Utilities;

namespace Simulateur_Personnage
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly SimulationJeu _simulateur;

        public MainWindowViewModel()
        {
            InitializeCommand();
            _simulateur = new SimulationJeu();
        }

        private SimulationEnum _actualSimulation;

        #region ICommands

        public ICommand QuitCommand { get; set; }
        public ICommand SimulationPacManCommand { get; set; }
        public ICommand StartCommand { get; set; }

        private void InitializeCommand()
        {
            QuitCommand = new RelayCommand(QuitExecuteCommand);
            SimulationPacManCommand = new RelayCommand(SimulationPacManExecuteCommand);
            StartCommand = new RelayCommand(StartExecuteCommand);
        }

        #endregion

        #region Commands

        private void QuitExecuteCommand()
        {
            Application.Current.Shutdown();
        }

        private void SimulationPacManExecuteCommand()
        {
            _actualSimulation = SimulationEnum.Pacman;
            Grid grid;
            _simulateur.CreerPacMan(out grid);

            EventAggregatorClass.EventAggregator.GetEvent<EventAggregatorLoadMapEvent>().Publish(grid);
            ;
        }

        private void StartExecuteCommand()
        {
            switch (_actualSimulation)
            {
                case SimulationEnum.Pacman:
                    _simulateur.LancerPacMan();
                    break;

                case SimulationEnum.Avion:
                    break;

                case SimulationEnum.Stade:
                    break;
            }

        #endregion
        }
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
        ICommand StartCommand { get; set; }
    }

    public enum SimulationEnum
    {
        Pacman = 1,
        Stade = 2,
        Avion = 3
    }
}
