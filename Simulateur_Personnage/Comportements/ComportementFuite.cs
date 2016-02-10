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
    public class ComportementFuite : ComportementCombat
    {

        public ComportementFuite(Personnage unPersonnage)
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
            Personnage.ZoneAbstraite.Image = null;
            Personnage.LastPosition = Personnage.ZoneAbstraite;
            Personnage.LastPosition.PersonnageList.Remove(Personnage);

            Personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == Personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
            Personnage.ZoneAbstraite.PersonnageList.Add(Personnage);

            if (Personnage.GetType() == typeof(PacMan))
            {
                if (Personnage.ZoneAbstraite.ObjetList.Where(a => a != null).ToList().Exists(a => a.GetType() == typeof(SuperPacGomme)))
                {
                    Personnage.ComportementCombat = new ComportementAttaque(Personnage);
                    Personnage.ZoneAbstraite.ObjetList.RemoveAll(a => a is SuperPacGomme);
                }
                if (Personnage.ZoneAbstraite.PersonnageList.Exists(a => a is Fantome))
                    return "PERDU";

                Personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\pacman.png", UriKind.Relative)));
            }
            else
            {
                if (Personnage.ZoneAbstraite.PersonnageList.Exists(a => a is PacMan))
                {
                    //TODO FAIRE QUELQUE CHOSE POUR QUE LE PACMAN ARRIVE A BOUFFER LES FANTOMES !
                }
                if (Personnage.LastPosition.ObjetList.Exists(a => a.GetType() == typeof(PacGomme) || a.GetType() == typeof(SuperPacGomme)))
                    Personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\point.png", UriKind.Relative)));

                Personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-bleu.png", UriKind.Relative)));
            }
            return "";
        }
    }
}
