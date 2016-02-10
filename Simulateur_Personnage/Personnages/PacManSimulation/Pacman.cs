using Simulateur_Personnage.Comportements;
using Simulateur_Personnage.Comportements.Pacman;

namespace Simulateur_Personnage.Personnages.PacManSimulation
{
    public class PacMan : Personnage
    {
        public PacMan(int unId)
            : base(unId)
        {
            ComportementCombat = new ComportementPacManFuite(this);
            IdPersonnage = unId;
        }
    }
}
