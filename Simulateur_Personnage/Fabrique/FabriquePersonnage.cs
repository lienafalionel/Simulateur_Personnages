using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique
{
    public abstract class FabriquePersonnage
    {
        public abstract Personnage CreerPersonnage(int unId);
    }
}