using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;

namespace Simulateur_Personnage.Fabrique.FabriquePersonnageFolder
{
    public class FabriquePacMan : FabriquePersonnage
    {
        public override Personnage CreerPersonnage(int unId)
        {
            return new PacMan(unId);
        }
    }
}
