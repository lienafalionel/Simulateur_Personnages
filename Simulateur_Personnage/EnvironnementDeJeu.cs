using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulateur_Personnage
{
    class EnvironnementDeJeu
    {
        private PlateauDeJeuAbstrait plateauDeJeu;

        public PlateauDeJeuAbstrait creerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            PlateauDeJeuAbstrait unPlateauDeJeu = fabrique.creerPlateauDeJeu();
            ZoneAbstraite zone1 = fabrique.creerZone("Zone d'origine");
            ZoneAbstraite zone2 = fabrique.creerZone("Zone de destination");
            AccesAbstrait acces1 = fabrique.creerAcces(zone1, zone2);
            unPlateauDeJeu.ajouteZone(zone1);
            unPlateauDeJeu.ajouteZone(zone2);
            unPlateauDeJeu.ajouteAcces(acces1);
            return unPlateauDeJeu;
        }

        /*public virtual Zone creerZone()
        {

        }

        public virtual Acces creerAcces()
        {

        }*/
    }
}
