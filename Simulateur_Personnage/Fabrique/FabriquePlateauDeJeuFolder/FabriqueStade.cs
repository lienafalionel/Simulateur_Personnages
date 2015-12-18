using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;

namespace Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder
{
    public class FabriqueStade : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new PlateauStade();
        }

        //TODO à modifier !
        public override ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            return new Case(unId, unePositionX, unePositionY, listObjets);
        }

        public override AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Adjacent(id, uneZoneOrigine, uneZoneDestination);
        }
        //FIN TODO
    }
}
