using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique.FabriquePersonnageFolder
{
    public abstract class FabriquePersonnage
    {
        public abstract Personnage CreerPersonnage(int unId);
    }
}