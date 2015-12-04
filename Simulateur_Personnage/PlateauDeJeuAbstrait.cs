using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public abstract class PlateauDeJeuAbstrait
    {
        public readonly List<ZoneAbstraite> ZoneList;
        private readonly List<AccesAbstrait> _accesList;
        private readonly List<Personnage> _personnageList;

        public PlateauDeJeuAbstrait()
        {
            ZoneList = new List<ZoneAbstraite>();
            _accesList = new List<AccesAbstrait>();
            _personnageList = new List<Personnage>();
        }

        public void AjouteAcces(AccesAbstrait accesAbstrait)
        {
            _accesList.Add(accesAbstrait);
        }

        public void AjouteZone(ZoneAbstraite zoneAbstraite)
        {
            ZoneList.Add(zoneAbstraite);
        }

        public void AjoutePersonnage(Personnage personnage)
        {
            _personnageList.Add(personnage);
        }
    }
}
