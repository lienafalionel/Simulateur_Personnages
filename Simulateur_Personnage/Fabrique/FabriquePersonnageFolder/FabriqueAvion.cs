using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.AvionSimulation;

namespace Simulateur_Personnage.Fabrique.FabriquePersonnageFolder
{
    public class FabriqueAvion : FabriquePersonnage
    {
        public override Personnage CreerPersonnage(int unId)
        {
            return new Avion(unId);
        }
    }
}
