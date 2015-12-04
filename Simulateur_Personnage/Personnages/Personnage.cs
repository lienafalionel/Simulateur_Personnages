using Simulateur_Personnage.Comportements;

namespace Simulateur_Personnage.Personnages
{
    public abstract class Personnage
    {
        private int _id;
        public ComportementCombat _comportementCombat { get; set; }

    }
}
