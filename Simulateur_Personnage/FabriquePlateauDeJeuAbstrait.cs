using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulateur_Personnage
{
    abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait creerPlateauDeJeu();

        public abstract Zone creerZone();

        public abstract Acces creerAcces(Zone zoneUn, Zone zoneDeux);
    }
}
