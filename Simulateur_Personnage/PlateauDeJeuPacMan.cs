using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    public class PlateauDeJeuPacMan : PlateauDeJeuAbstrait
    {
        public PlateauDeJeuPacMan()
        {
            instance = this;
        }

        public static PlateauDeJeuAbstrait Instance()
        {
            if (instance == null)
            {
                instance = new PlateauDeJeuPacMan();
            }
            return instance;
        }
    }
}
