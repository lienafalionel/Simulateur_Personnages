using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Fabrique;
using Simulateur_Personnage.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulateur_Personnage
{
    public class FabriqueLabyrinthePacMan : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new LabyrinthePacMan();
        }

        public override ZoneAbstraite CreerZone(int unePositionX, int unePositionY)
        {
            return new Case(unePositionX, unePositionY);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(uneZoneOrigine, uneZoneDestination);
        }
    }
}
