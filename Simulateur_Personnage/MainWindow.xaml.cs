﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simulateur_Personnage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SimulationJeu simulateur = new SimulationJeu();
            simulateur.CreerPlateauDeJeu();
            Console.WriteLine("test");
        }

        private void MenuItem_Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
