using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;
using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Simulateur_Personnage.Comportements.Pacman
{
    public class ComportementFantomeAttaque : ComportementCombat
    {
        public ComportementFantomeAttaque(Personnage unPersonnage)
            : base(unPersonnage)
        {

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

            if (accesDisponibles.Count == 1 && accesDisponibles.First().ZoneOrigine.PersonnageList.Exists(a => a is Fantome)
                && accesDisponibles.First().ZoneDestination.PersonnageList.Exists(a => a is Fantome)
                && (accesDisponibles.First().ZoneOrigine.Id == 81 || accesDisponibles.First().ZoneDestination.Id == 81))
                return "";

            Personnage.ZoneAbstraite.Image = null;
            Personnage.LastPosition = Personnage.ZoneAbstraite;
            Personnage.LastPosition.PersonnageList.Remove(Personnage);

            Personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == Personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
            Personnage.ZoneAbstraite.PersonnageList.Add(Personnage);

            if (Personnage.ZoneAbstraite.PersonnageList.Exists(a => a is PacMan))
                return "PERDU";

            if (Personnage.LastPosition.ObjetList.Where(a => a != null).ToList().Exists(a => a != null && a.GetType() == typeof(PacGomme)))
                Personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\point.png", UriKind.Relative)));
            if (Personnage.LastPosition.ObjetList.Where(a => a != null).ToList().Exists(a => a != null && a.GetType() == typeof(SuperPacGomme)))
                Personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\pomme.png", UriKind.Relative)));


            Personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-bleu.png", UriKind.Relative)));

            return "";
        }
    }
}
