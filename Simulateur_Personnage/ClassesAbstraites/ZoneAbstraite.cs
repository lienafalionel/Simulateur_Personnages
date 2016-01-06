using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;
using System.Collections.Generic;
namespace Simulateur_Personnage.ClassesAbstraites
{
    public abstract class ZoneAbstraite
    {
        public int Id;
        public List<Objet> ObjetList { get; set; }
        public List<Personnage> PersonnageList { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        private static int MAX_ID = 0;

        public ZoneAbstraite(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            Id = unId;
            ObjetList = listObjets;
            PersonnageList = new List<Personnage>();
            PositionX = unePositionX;
            PositionY = unePositionY;
        }

        public ZoneAbstraite(int unePositionX, int unePositionY)
        {
            Id = MAX_ID + 1;
            ObjetList = new List<Objet>();
            PersonnageList = new List<Personnage>();
            PositionX = unePositionX;
            PositionY = unePositionY;
        }

        public bool HasObject
        {
            get { return ObjetList.Count > 0; }
        }

        public bool HasPersonnage
        {
            get { return PersonnageList.Count > 0; }
        }
    }
}
