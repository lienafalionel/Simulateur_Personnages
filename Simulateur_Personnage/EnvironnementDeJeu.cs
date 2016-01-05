using System.Collections.Generic;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public class EnvironnementDeJeu
    {
        private PlateauDeJeuAbstrait _plateauDeJeu;

        public PlateauDeJeuAbstrait CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            _plateauDeJeu = fabrique.CreerPlateauDeJeu();

            List<ZoneAbstraite> listZones;
            List<AccesAbstrait> listAcces;
            List<Personnage> listPersonnage;
            fabrique.LireXml(out listZones, out listAcces, out listPersonnage);
            listZones.ForEach(a => _plateauDeJeu.AjouteZone(a));
            listAcces.ForEach(a => _plateauDeJeu.AjouteAcces(a));
            listPersonnage.ForEach(a => _plateauDeJeu.AjoutePersonnage(a));

            return _plateauDeJeu;
        }
    }
}
