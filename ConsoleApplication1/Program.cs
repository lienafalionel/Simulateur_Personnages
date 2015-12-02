using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulateur_Personnage;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationJeu simulation = new SimulationJeu();
            simulation.creerFourmiliere();
            Console.ReadKey();
        }
    }
}
