using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriqueLabyrinthe : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new Labyrinthe();
        }

        public override ZoneAbstraite CreerZone(string unNom)
        {
            return new Case(unNom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Adjacent(uneZoneOrigine, uneZoneDestination);
        }
    }
}
