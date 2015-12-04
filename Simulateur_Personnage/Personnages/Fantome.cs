using Simulateur_Personnage.Comportements;
namespace Simulateur_Personnage.Personnages
{
    public class Fantome : Personnage
    {
        public Fantome()
        {
            _comportementCombat = new ComportementAttaque();
        }
    }
}
