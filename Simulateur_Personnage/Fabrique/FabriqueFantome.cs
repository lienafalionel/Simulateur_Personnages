using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriqueFantome : FabriquePersonnage
    {
        public override Personnage CreerPersonnage(int unId)
        {
            return new Fantome(unId);
        }
    }
}
