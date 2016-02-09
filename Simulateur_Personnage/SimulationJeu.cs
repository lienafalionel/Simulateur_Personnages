using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Simulateur_Personnage.Comportements;
using Simulateur_Personnage.Fabrique;
using Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder;
using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;

namespace Simulateur_Personnage
{
    public class SimulationJeu
    {
        private readonly EnvironnementDeJeu _environnement = new EnvironnementDeJeu();
        private PlateauDeJeuAbstrait _plateauDeJeuAbstrait;

        public void CreerPlateauDeJeu()
        {
            var fabrique = new FabriquePlateauDeJeu();
            _environnement.CreerPlateauDeJeu(fabrique);
        }

        public void CreerFourmiliere()
        {
            var fabrique = new FabriqueVols();
            _environnement.CreerPlateauDeJeu(fabrique);
        }

        public void CreerLabyrinthe()
        {
            var fabrique = new FabriqueStade();
            _environnement.CreerPlateauDeJeu(fabrique);
        }

        public void CreerPacMan(out Grid grid)
        {
            var fabrique = new FabriqueLabyrinthePacMan();
            _plateauDeJeuAbstrait = _environnement.CreerPlateauDeJeu(fabrique);
            grid = _environnement.CreerTerrain();
        }

        public void LancerPacMan()
        {
            var returnValue = "";
            var thread = new Thread(() =>
                                        {
                                            while (returnValue != "PERDU")
                                            {
                                                foreach (var personnage in _plateauDeJeuAbstrait.PersonnageList)
                                                {
                                                    if (personnage.ZoneAbstraite == null) continue;
                                                    var personnage1 = personnage;
                                                    if (Application.Current == null) return;

                                                    Application.Current.Dispatcher.BeginInvoke(
                                                        DispatcherPriority.Normal,
                                                        (Action)
                                                        (() =>
                                                             {
                                                                 returnValue = personnage1.ComportementCombat.Combattre(personnage1, _plateauDeJeuAbstrait);
                                                             }));

                                                    Thread.Sleep(40);
                                                }
                                            }

                                            if (returnValue == "PERDU")
                                                MessageBox.Show("PERDU!");
                                        });

            thread.Start();
        }
    }
}
