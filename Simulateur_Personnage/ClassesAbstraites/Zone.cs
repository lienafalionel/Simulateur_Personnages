using System.Collections.Generic;
using Simulateur_Personnage.Objets;

namespace Simulateur_Personnage.ClassesAbstraites
{
    public class Zone : ZoneAbstraite
    {
        public Zone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
            : base(unId, unePositionX, unePositionY, listObjets)
        {

        }
    }
}
