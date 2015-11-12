using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriqueFourmiliere : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new Fourmiliere();
        }

        public override ZoneAbstraite CreerZone(string unNom)
        {
            return new BoutTerrain(unNom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Tunnel(uneZoneOrigine, uneZoneDestination);
        }
    }
}
