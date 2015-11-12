using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage.Fabrique
{
    public abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();

        public abstract ZoneAbstraite CreerZone(string unNom);

        public abstract AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination);
    }
}
