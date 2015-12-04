using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;

namespace Simulateur_Personnage.Fabrique
{
    public abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();

        public abstract ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets);

        public abstract AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination);
    }
}
