using Simulateur_Personnage.Comportements;
namespace Simulateur_Personnage.Personnages
{
    public class PacMan : Personnage
    {
        public PacMan(int unId)
            : base(unId)
        {
            ComportementCombat = new ComportementFuite();
            IdPersonnage = unId;
        }
    }
}
