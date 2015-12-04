using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriqueFourmiliere : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new Fourmiliere();
        }

        public override ZoneAbstraite CreerZone(int unePositionX, int unePositionY)
        {
            return new BoutTerrain(unePositionX, unePositionY);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Tunnel(uneZoneOrigine, uneZoneDestination);
        }
    }
}
