using Simulateur_Personnage.Fabrique;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public class EnvironnementDeJeu
    {
        private PlateauDeJeuAbstrait _plateauDeJeu;

        public PlateauDeJeuAbstrait CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            _plateauDeJeu = fabrique.CreerPlateauDeJeu();


            //var zone1 = fabrique.CreerZone("Zone d'origine");
            //var zone2 = fabrique.CreerZone("Zone de destination");
            //var acces1 = fabrique.CreerAcces(zone1, zone2);

            _plateauDeJeu.AjoutePersonnage(new PacMan(1));
            _plateauDeJeu.AjoutePersonnage(new Fantome(2));
            _plateauDeJeu.AjoutePersonnage(new Fantome(3));
            _plateauDeJeu.AjoutePersonnage(new Fantome(4)); // à recuperer les IDs depuis le XML
            //_plateauDeJeu.AjouteZone(zone1);
            //_plateauDeJeu.AjouteZone(zone2);
            //_plateauDeJeu.AjouteAcces(acces1);
            return _plateauDeJeu;
        }
    }
}
