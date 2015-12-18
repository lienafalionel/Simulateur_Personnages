using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.StadeSimulation;

namespace Simulateur_Personnage.Fabrique.FabriquePersonnageFolder
{
    public class FabriqueSupporteur : FabriquePersonnage
    {
        public override Personnage CreerPersonnage(int unId)
        {
            return new Supporteur(unId);
        }
    }
}
