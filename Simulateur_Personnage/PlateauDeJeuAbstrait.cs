using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulateur_Personnage
{
    abstract class PlateauDeJeuAbstrait
    {
        private List<ZoneAbstraite> zoneList;
        private List<AccesAbstraite> accesList;

        public PlateauDeJeuAbstrait()
        {
            zoneList = new List<ZoneAbstraite>();
            accesList = new List<AccesAbstraire>();
        }

        public void ajouteAcces(AccesAbstrait accesAbstrait)
        {
            accesList.Add(accesAbstrait);
        }

        public void ajouteZone(ZoneAbstraite zoneAbstraite)
        {
            zoneList.Add(zoneAbstraite);
        }
    }
}
