using Simulateur_Personnage.Personnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage.Fabrique
{
    public abstract class FabriquePersonnage
    {
        public abstract Personnage CreerPersonnage();
    }
}