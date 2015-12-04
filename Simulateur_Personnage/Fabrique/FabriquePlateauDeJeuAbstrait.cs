using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;

namespace Simulateur_Personnage.Fabrique
{
    public abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();

        public abstract ZoneAbstraite CreerZone(int unePositionX, int unePositionY);

        public abstract AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination);
    }
}
