using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Simulateur_Personnage.Utilities;

namespace Simulateur_Personnage
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
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
        public ICommand StopCommand { get; set; }

        private void InitializeCommand()
        {
            QuitCommand = new RelayCommand(QuitExecuteCommand);
            SimulationPacManCommand = new RelayCommand(SimulationPacManExecuteCommand);
            StartCommand = new RelayCommand(StartExecuteCommand);
            StopCommand = new RelayCommand(StopExecuteCommand);
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
            IsEnabledStartCommand = true;
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
        }

        private void StopExecuteCommand()
        {
            _simulateur.ShouldStopThread = true;
        }
        #endregion

        private bool _isEnabledStartCommand;
        public bool IsEnabledStartCommand
        {
            get { return _isEnabledStartCommand; }
            set
            {
                _isEnabledStartCommand = value;
                OnPropertyChanged("IsEnabledStartCommand");
            }
        }

        #region INotifyPropertChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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
        ICommand StartCommand { get; set; }
    }

    public enum SimulationEnum
    {
        Pacman = 1,
        Stade = 2,
        Avion = 3
    }
}
