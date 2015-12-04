using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriquePlateauDeJeu : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new PlateauDeJeu();
        }

        public override ZoneAbstraite CreerZone(int unePositionX, int unePositionY)
        {
            return new Zone(unePositionX, unePositionY);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(uneZoneOrigine, uneZoneDestination);
        }
    }
}
