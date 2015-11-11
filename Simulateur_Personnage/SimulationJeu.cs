using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class SimulationJeu
    {
        private EnvironnementDeJeu environnement;

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
