namespace Simulateur_Personnage.ClassesAbstraites
{
    public abstract class AccesAbstrait
    {
        private ZoneAbstraite _zoneOrigine;
        private ZoneAbstraite _zoneDestination;

        public AccesAbstrait(ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            _zoneOrigine = uneZoneOrigine;
            _zoneDestination = uneZoneDestination;
        }
    }
}
