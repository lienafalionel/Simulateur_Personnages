using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class FabriqueFourmiliere: FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait creerPlateauDeJeu()
        {
            return new PlateauDeJeu();
        }

        public override ZoneAbstraite creerZone(string unNom)
        {
            return new BoutTerrain(unNom);
        }

        public override AccesAbstrait creerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Tunnel(uneZoneOrigine, uneZoneDestination);
        }
    }
}
