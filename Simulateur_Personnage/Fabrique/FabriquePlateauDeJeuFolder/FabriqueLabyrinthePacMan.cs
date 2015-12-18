using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;
using System.Collections.Generic;

namespace Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder
{
    public class FabriqueLabyrinthePacMan : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new LabyrinthePacMan();
        }

        public override ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            return new Case(unId, unePositionX, unePositionY, listObjets);
        }

        public override AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(id, uneZoneOrigine, uneZoneDestination);
        }
    }
}
