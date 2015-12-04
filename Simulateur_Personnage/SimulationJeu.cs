using Simulateur_Personnage.Fabrique;

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
            var fabrique = new FabriqueFourmiliere();
            _environnement.CreerPlateauDeJeu(fabrique);
        }

        public void CreerLabyrinthe()
        {
            var fabrique = new FabriqueLabyrinthe();
            _environnement.CreerPlateauDeJeu(fabrique);
        }

        public void CreerPacMan()
        {
            var fabrique = new FabriqueLabyrinthePacMan();
            _environnement.CreerPlateauDeJeu(fabrique);
        }
    }
}
