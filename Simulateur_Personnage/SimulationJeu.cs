using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class SimulationJeu
    {
        private EnvironnementDeJeu environnement = new EnvironnementDeJeu();

        public void creerPlateauDeJeu()
        {
            FabriquePlateauDeJeu fabrique = new FabriquePlateauDeJeu();
            environnement.creerPlateauDeJeu(fabrique);
        }

        public void creerFourmiliere()
        {
            FabriqueFourmiliere fabrique = new FabriqueFourmiliere();
            environnement.creerPlateauDeJeu(fabrique);
        }

        public void creerLabyrinthe()
        {
            FabriqueLabyrinthe fabrique = new FabriqueLabyrinthe();
            environnement.creerPlateauDeJeu(fabrique);
        }
    }
}
