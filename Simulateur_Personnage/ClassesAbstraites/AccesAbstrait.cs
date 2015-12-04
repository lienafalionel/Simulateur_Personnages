namespace Simulateur_Personnage.ClassesAbstraites
{
    public abstract class AccesAbstrait
    {
        private int _id;
        private ZoneAbstraite _zoneOrigine;
        private ZoneAbstraite _zoneDestination;

        public AccesAbstrait(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            _id = id;
            _zoneOrigine = uneZoneOrigine;
            _zoneDestination = uneZoneDestination;
        }
    }
}
