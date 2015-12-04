using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriqueLabyrinthe : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new Labyrinthe();
        }

        public override ZoneAbstraite CreerZone(int unePositionX, int unePositionY)
        {
            return new Case(unePositionX, unePositionY);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Adjacent(uneZoneOrigine, uneZoneDestination);
        }
    }
}
