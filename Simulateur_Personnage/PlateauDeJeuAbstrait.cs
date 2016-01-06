using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public abstract class PlateauDeJeuAbstrait
    {
        public readonly List<ZoneAbstraite> ZoneList;
        public readonly List<AccesAbstrait> AccesList;
        public readonly List<Personnage> PersonnageList;

        public PlateauDeJeuAbstrait()
        {
            ZoneList = new List<ZoneAbstraite>();
            AccesList = new List<AccesAbstrait>();
            PersonnageList = new List<Personnage>();
        }

        public void AjouteAcces(AccesAbstrait accesAbstrait)
        {
            AccesList.Add(accesAbstrait);
        }

        public void AjouteZone(ZoneAbstraite zoneAbstraite)
        {
            ZoneList.Add(zoneAbstraite);
        }

        public void AjoutePersonnage(Personnage personnage)
        {
            PersonnageList.Add(personnage);
        }
    }
}
