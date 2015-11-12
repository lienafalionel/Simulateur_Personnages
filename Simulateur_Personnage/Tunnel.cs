using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class Tunnel : AccesAbstrait
    {
        public Tunnel(ZoneAbstraite boutTerrainUn, ZoneAbstraite boutTerrainDeux)
            : base(boutTerrainUn, boutTerrainDeux)
        {

        }
    }
}
