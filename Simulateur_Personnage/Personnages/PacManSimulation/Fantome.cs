using Simulateur_Personnage.Comportements;
using Simulateur_Personnage.Comportements.Pacman;

namespace Simulateur_Personnage.Personnages.PacManSimulation
{
    public class Fantome : Personnage
    {
        public Fantome(int unId)
            : base(unId)
        {
            ComportementCombat = new ComportementFantomeAttaque(this);
            IdPersonnage = unId;
        }
    }
}
