using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulateur_Personnage
{
    abstract class ZoneAbstraite
    {
        private string nom;

        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
        }
    }
}
