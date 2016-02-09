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
            personnage.ZoneAbstraite.Image = null;
            personnage.LastPosition = personnage.ZoneAbstraite;
            personnage.LastPosition.PersonnageList.Remove(personnage);

            personnage.ZoneAbstraite = accesDisponibles[res].ZoneOrigine == personnage.ZoneAbstraite ? accesDisponibles[res].ZoneDestination : accesDisponibles[res].ZoneOrigine;
            personnage.ZoneAbstraite.PersonnageList.Add(personnage);

            if (personnage.GetType() == typeof(PacMan))
            {
                if (personnage.ZoneAbstraite.ObjetList.Where(a => a != null).ToList().Exists(a => a.GetType() == typeof(SuperPacGomme)))
                {
                    personnage.ComportementCombat = new ComportementAttaque();
                    personnage.ZoneAbstraite.ObjetList.RemoveAll(a => a is SuperPacGomme);
                }
                if (personnage.ZoneAbstraite.PersonnageList.Exists(a => a is Fantome))
                    return "PERDU";

                personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\pacman.png", UriKind.Relative)));
            }
            else
            {
                if (personnage.ZoneAbstraite.PersonnageList.Exists(a => a is PacMan))
                {
                    //TODO FAIRE QUELQUE CHOSE POUR QUE LE PACMAN ARRIVE A BOUFFER LES FANTOMES !
                }
                if (personnage.LastPosition.ObjetList.Exists(a => a.GetType() == typeof(PacGomme) || a.GetType() == typeof(SuperPacGomme)))
                    personnage.LastPosition.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\point.png", UriKind.Relative)));

                personnage.ZoneAbstraite.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-bleu.png", UriKind.Relative)));
            }
            return "";
        }
    }
}
