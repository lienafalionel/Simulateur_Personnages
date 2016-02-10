using Simulateur_Personnage.Personnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Simulateur_Personnage.Comportements.Pacman
{
    class ComportementPacManAttaque : ComportementCombat
    {
        private int _numberOfTour;

        public ComportementPacManAttaque(Personnage unPersonnage) : base(unPersonnage)
        {
            _numberOfTour = 0;
        }

        public override string Combattre()
        {
            var accesDisponibles = PlateauDeJeuPacMan.Instance().AccesList.Where(
                a => a.ZoneDestination == Personnage.ZoneAbstraite || a.ZoneOrigine == Personnage.ZoneAbstraite).ToList();

            if (accesDisponibles.Count > 1 && accesDisponibles.Exists(a => a.ZoneDestination == Personnage.LastPosition || a.ZoneOrigine == Personnage.LastPosition))
            {
                accesDisponibles.RemoveAll(
                    a => a.ZoneDestination == Personnage.LastPosition || a.ZoneOrigine == Personnage.LastPosition);
            }

            var random = new Random();
            var res = random.Next(0, accesDisponibles.Count);

            Personnage.ZoneAbstraite.Image = null;
            Personnage.LastPosition = Personnage.ZoneAbstraite;
            Personnage.LastPosition.PersonnageList.Remove(Personnage);
            Personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == Personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
            Personnage.ZoneAbstraite.PersonnageList.Add(Personnage);
            Personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\r2d2.png", UriKind.Relative)));

            Personnage.ZoneAbstraite.PersonnageList.RemoveAll(a => a.ComportementCombat is ComportementFuite);
            _numberOfTour++;
            if (_numberOfTour >= 40)
            {
                Personnage.ComportementCombat = new ComportementPacManFuite(Personnage);
                _numberOfTour = 0;
                return "";
            }

            return "";
        }
    }
}
