using Simulateur_Personnage.Comportements;
namespace Simulateur_Personnage.Personnages
{
    public class Fantome : Personnage
    {
        public Fantome(int unId)
            : base(unId)
        {
            ComportementCombat = new ComportementAttaque();
            IdPersonnage = unId;
        }
    }
}
