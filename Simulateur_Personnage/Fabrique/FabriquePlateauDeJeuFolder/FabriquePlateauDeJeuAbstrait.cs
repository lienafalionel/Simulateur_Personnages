using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder
{
    public abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();

        public abstract ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets);

        public abstract AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination);

        public abstract void LireXml(out List<ZoneAbstraite> listZone, out List<AccesAbstrait> listAcces, out List<Personnage> listPersonnage);
    }
}
