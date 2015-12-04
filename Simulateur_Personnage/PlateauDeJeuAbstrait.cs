using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public abstract class PlateauDeJeuAbstrait
    {
        private readonly List<ZoneAbstraite> _zoneList;
        private readonly List<AccesAbstrait> _accesList;
        private List<Personnage> _personnageList;

        public PlateauDeJeuAbstrait()
        {
            _zoneList = new List<ZoneAbstraite>();
            _accesList = new List<AccesAbstrait>();
            _personnageList = new List<Personnage>();
        }

        public void AjouteAcces(AccesAbstrait accesAbstrait)
        {
            _accesList.Add(accesAbstrait);
        }

        public void AjouteZone(ZoneAbstraite zoneAbstraite)
        {
            _zoneList.Add(zoneAbstraite);
        }

        public void AjoutePersonnage(Personnage personnage)
        {
            _personnageList.Add(personnage);
        }
    }
}
