using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;

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

        public Grid CreerTerrain()
        {
            var grid = new Grid();

            for (int x = 0; x < 17; x++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < 20; y++)
                grid.RowDefinitions.Add(new RowDefinition());

            for (int x = 0; x < 20; x++)
                for (int y = 0; y < 17; y++)
                {
                    var childrenGrid = new Grid();
                    var border = new Border();

                    if (_plateauDeJeu.ZoneList.Exists(a => a.PositionX == x && a.PositionY == y))
                    {
                        var zone = _plateauDeJeu.ZoneList.First(a => a.PositionX == x && a.PositionY == y);

                        childrenGrid.DataContext = zone;

                        foreach (var objet in zone.ObjetList)
                        {
                            var binding = new Binding("Image");
                            border.SetBinding(Border.BackgroundProperty, binding);

                            if (objet is PacGomme)
                                zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\point.png", UriKind.Relative)));
                            if (objet is SuperPacGomme)
                                zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\pomme.png", UriKind.Relative)));
                            if (objet is Porte)
                                zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\porte.png", UriKind.Relative)));
                        }
                        childrenGrid.Children.Add(border);
                    }
                    else
                    {
                        border.Background = new SolidColorBrush(Colors.Red);
                        childrenGrid.Children.Add(border);
                    }

                    if (_plateauDeJeu.PersonnageList.Any(a => a.ZoneAbstraite.PositionX == x && a.ZoneAbstraite.PositionY == y))
                    {
                        var zone = _plateauDeJeu.ZoneList.First(a => a.PositionX == x && a.PositionY == y);
                        var personnage = _plateauDeJeu.PersonnageList.FirstOrDefault(a => a.ZoneAbstraite.PositionX == x && a.ZoneAbstraite.PositionY == y);
                        {
                            if (personnage is PacMan)
                                zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman.png", UriKind.Relative)));
                            if (personnage is Fantome)
                            {
                                var random = new Random();
                                var res = random.Next(1, 3);
                                switch (res)
                                {
                                    case 1:
                                        zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-bleu.png", UriKind.Relative)));
                                        break;
                                    case 2:
                                        zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-rose.png", UriKind.Relative)));
                                        break;
                                    case 3:
                                        zone.Image = new ImageBrush(new BitmapImage(new Uri("..\\Debug\\Ressources\\Pacman\\Pacman-rouge.png", UriKind.Relative)));
                                        break;
                                }
                            }
                        }
                    }

                    childrenGrid.SetValue(Grid.RowProperty, x);
                    childrenGrid.SetValue(Grid.ColumnProperty, y);
                    grid.Children.Add(childrenGrid);
                }
            return grid;
        }
    }
}
