namespace Simulateur_Personnage.ClassesAbstraites
{
    public abstract class AccesAbstrait
    {
        private int _id;
        public ZoneAbstraite ZoneOrigine { get; set; }
        public ZoneAbstraite ZoneDestination { get; set; }

        public AccesAbstrait(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            _id = id;
            ZoneOrigine = uneZoneOrigine;
            ZoneDestination = uneZoneDestination;
        }
    }
}
