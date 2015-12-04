using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;
using System.Collections.Generic;
namespace Simulateur_Personnage.ClassesAbstraites
{
    public abstract class ZoneAbstraite
    {
        public int Id;
        private List<Objet> _objetList;
        private List<Personnage> _personnageList;
        private int _positionX;
        private int _positionY;

        private static int MAX_ID = 0;

        public ZoneAbstraite(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            Id = unId;
            _objetList = listObjets;
            _personnageList = new List<Personnage>();
            _positionX = unePositionX;
            _positionY = unePositionY;
        }

        public ZoneAbstraite(int unePositionX, int unePositionY)
        {
            Id = MAX_ID + 1;
            _objetList = new List<Objet>();
            _personnageList = new List<Personnage>();
            _positionX = unePositionX;
            _positionY = unePositionY;
        }
    }
}
