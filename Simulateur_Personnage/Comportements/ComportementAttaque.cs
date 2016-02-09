using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;

namespace Simulateur_Personnage.Comportements
{
    public class ComportementAttaque : ComportementCombat
    {
        private int _numberOfTour;
        public override string Combattre(Personnage personnage, PlateauDeJeuAbstrait plateauDeJeuAbstrait)
        {
            var accesDisponibles = plateauDeJeuAbstrait.AccesList.Where(
                a => a.ZoneDestination == personnage.ZoneAbstraite || a.ZoneOrigine == personnage.ZoneAbstraite).ToList();

            if (accesDisponibles.Count > 1 && accesDisponibles.Exists(a => a.ZoneDestination == personnage.LastPosition || a.ZoneOrigine == personnage.LastPosition))
            {
                accesDisponibles.RemoveAll(
                    a => a.ZoneDestination == personnage.LastPosition || a.ZoneOrigine == personnage.LastPosition);
            }

            var random = new Random();
            var res = random.Next(0, accesDisponibles.Count);

            if (personnage.GetType() == typeof(PacMan))
            {
                personnage.ZoneAbstraite.Image = null;
                personnage.LastPosition = personnage.ZoneAbstraite;
                personnage.LastPosition.PersonnageList.Remove(personnage);
                personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
                personnage.ZoneAbstraite.PersonnageList.Add(personnage);
                personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\r2d2.png", UriKind.Relative)));

                personnage.ZoneAbstraite.PersonnageList.RemoveAll(a => a.ComportementCombat is ComportementFuite);
                _numberOfTour++;
                if (_numberOfTour >= 40)
                {
                    personnage.ComportementCombat = new ComportementFuite();
                    _numberOfTour = 0;
                    return "";
                }
            }
            else if (personnage.GetType() == typeof(Fantome))
            {
                if (accesDisponibles.Count == 1 && accesDisponibles.First().ZoneOrigine.PersonnageList.Exists(a => a is Fantome) && accesDisponibles.First().ZoneDestination.PersonnageList.Exists(a => a is Fantome))
                    return "";

                personnage.ZoneAbstraite.Image = null;
                personnage.LastPosition = personnage.ZoneAbstraite;
                personnage.LastPosition.PersonnageList.Remove(personnage);

                personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
                personnage.ZoneAbstraite.PersonnageList.Add(personnage);

                if (personnage.ZoneAbstraite.PersonnageList.Exists(a => a is PacMan))
                    return "PERDU";

                if (personnage.LastPosition.ObjetList.Where(a => a != null).ToList().Exists(a => a != null && a.GetType() == typeof(PacGomme)))
                    personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\point.png", UriKind.Relative)));
                if (personnage.LastPosition.ObjetList.Where(a => a != null).ToList().Exists(a => a != null && a.GetType() == typeof(SuperPacGomme)))
                    personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\pomme.png", UriKind.Relative)));


                personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-bleu.png", UriKind.Relative)));
            }

            return "";
        }
    }
}
