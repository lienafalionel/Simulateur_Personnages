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
            return new Zone(unNom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(uneZoneOrigine, uneZoneDestination);
        }
    }
}
