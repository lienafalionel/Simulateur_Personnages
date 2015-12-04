using Simulateur_Personnage.Comportements;

namespace Simulateur_Personnage.Personnages
{
    public abstract class Personnage
    {
        public int IdPersonnage { get; set; }
        public ComportementCombat ComportementCombat { get; set; }

        public Personnage(int unId)
        {

        }

    }
}
