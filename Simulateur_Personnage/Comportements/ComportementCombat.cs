using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Comportements
{
    public abstract class ComportementCombat
    {
        public abstract string Combattre(Personnage personnage, PlateauDeJeuAbstrait plateauDeJeuAbstrait);
    }
}
