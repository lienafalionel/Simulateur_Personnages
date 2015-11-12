using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class FabriquePlateauDeJeu : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait creerPlateauDeJeu()
        {
            return new PlateauDeJeu();
        }

        public override ZoneAbstraite creerZone(string unNom)
        {
            return new Zone(unNom);
        }

        public override AccesAbstrait creerAcces(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(uneZoneOrigine, uneZoneDestination);
        }
    }
}
