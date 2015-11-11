using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    abstract class AccesAbstrait
    {
        private ZoneAbstraite zoneOrigine;
        private ZoneAbstraite zoneDestination;

        public AccesAbstrait(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            zoneOrigine = uneZoneOrigine;
            zoneDestination = uneZoneDestination;
        }
    }
}
