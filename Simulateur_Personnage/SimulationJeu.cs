using System.Windows.Controls;
using Simulateur_Personnage.Fabrique;
using Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder;

namespace Simulateur_Personnage
{
    public class SimulationJeu
    {
        private readonly EnvironnementDeJeu _environnement = new EnvironnementDeJeu();

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
            _environnement.CreerPlateauDeJeu(fabrique);
            grid = _environnement.CreerTerrain();
        }
    }
}
