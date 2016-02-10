using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Comportements
{
    public abstract class ComportementCombat
    {
        public Personnage Personnage { get; set; }

        public ComportementCombat(Personnage unPersonnage)
        {
            Personnage = unPersonnage;
        }

        public abstract string Combattre();

    }
}
