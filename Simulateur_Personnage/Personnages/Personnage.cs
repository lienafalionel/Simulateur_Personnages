using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Comportements;

namespace Simulateur_Personnage.Personnages
{
    public abstract class Personnage
    {
        public int IdPersonnage { get; set; }
        public ComportementCombat ComportementCombat { get; set; }
        public ZoneAbstraite ZoneAbstraite { get; set; }
        public ZoneAbstraite LastPosition { get; set; }

        public Personnage(int unId)
        {

        }

        public string Combattre()
        {
            return ComportementCombat.Combattre();
        }

    }
}
