using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulateur_Personnage
{
    abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait creerPlateauDeJeu();

        public abstract ZoneAbstraite creerZone(string unNom);

        public abstract AccesAbstrait creerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination);
    }
}
