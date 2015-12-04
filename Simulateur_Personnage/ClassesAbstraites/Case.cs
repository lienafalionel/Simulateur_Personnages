using System.Collections.Generic;
using Simulateur_Personnage.Objets;
namespace Simulateur_Personnage.ClassesAbstraites
{
    public class Case : ZoneAbstraite
    {
        public Case(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
            : base(unId, unePositionX, unePositionY, listObjets)
        {

        }
    }
}
