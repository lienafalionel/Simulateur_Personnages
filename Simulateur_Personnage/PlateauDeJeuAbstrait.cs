using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;

namespace Simulateur_Personnage
{
    public abstract class PlateauDeJeuAbstrait
    {
        private readonly List<ZoneAbstraite> _zoneList;
        private readonly List<AccesAbstrait> _accesList;

        public PlateauDeJeuAbstrait()
        {
            _zoneList = new List<ZoneAbstraite>();
            _accesList = new List<AccesAbstrait>();
        }

        public void AjouteAcces(AccesAbstrait accesAbstrait)
        {
            _accesList.Add(accesAbstrait);
        }

        public void AjouteZone(ZoneAbstraite zoneAbstraite)
        {
            _zoneList.Add(zoneAbstraite);
        }
    }
}
