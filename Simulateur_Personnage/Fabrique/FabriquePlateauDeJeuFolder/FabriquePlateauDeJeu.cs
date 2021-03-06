﻿using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder
{
    public class FabriquePlateauDeJeu : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new PlateauDeJeu();
        }

        public override ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            return new Zone(unId, unePositionX, unePositionY, listObjets);
        }

        public override AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(id, uneZoneOrigine, uneZoneDestination);
        }

        public override void LireXml(out List<ZoneAbstraite> listZone, out List<AccesAbstrait> listAcces, out List<Personnage> listPersonnage)
        {
            listZone = null;
            listAcces = null;
            listPersonnage = null;
        }
    }
}
