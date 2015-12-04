using Simulateur_Personnage.Comportements;
namespace Simulateur_Personnage.Personnages
{
    public class PacMan : Personnage
    {
        public PacMan()
        {
            _comportementCombat = new ComportementFuite();
        }
    }
}
