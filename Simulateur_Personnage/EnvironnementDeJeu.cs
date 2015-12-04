using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Fabrique;
using Simulateur_Personnage.Objets;
using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage
{
    public class EnvironnementDeJeu
    {
        private PlateauDeJeuAbstrait _plateauDeJeu;

        public PlateauDeJeuAbstrait CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            _plateauDeJeu = fabrique.CreerPlateauDeJeu();

            LireXML();

            return _plateauDeJeu;
        }

        private void LireXML()
        {
            using (var reader = XmlReader.Create("Pacman.xml"))
            {
                reader.Read();
                while (!reader.EOF)
                {
                    if (reader.Name.ToLower() == "zone")
                    {
                        var stringId = reader["ID"];
                        if (stringId == null)
                        {
                            reader.Read();
                            continue;
                        }
                        var id = int.Parse(stringId);

                        reader.ReadToFollowing("POSITIONX");
                        reader.Read();
                        var positionX = int.Parse(reader.Value);

                        reader.ReadToFollowing("POSITIONY");
                        reader.Read();
                        var positionY = int.Parse(reader.Value);

                        reader.ReadToFollowing("VALUE");
                        reader.Read();
                        var valeur = reader.Value;

                        Objet objet = null;
                        switch (valeur)
                        {
                            case "NOURRITURE":
                                objet = new PacGomme();
                                break;
                            case "BONUS":
                                objet = new SuperPacGomme();
                                break;
                        }

                        _plateauDeJeu.AjouteZone(new Zone(id, positionX, positionY, new List<Objet> { objet }));
                    }
                    else if (reader.Name.ToLower() == "acces")
                    {
                        var stringId = reader["ID"];
                        if (stringId == null)
                        {
                            reader.Read();
                            continue;
                        }
                        var id = int.Parse(stringId);

                        reader.ReadToFollowing("ENTREE");
                        reader.Read();
                        var idEntree = int.Parse(reader.Value);

                        reader.ReadToFollowing("SORTIE");
                        reader.Read();
                        var idSortie = int.Parse(reader.Value);

                        var entree = _plateauDeJeu.ZoneList.ToList().First(a => a.Id == idEntree);
                        var sortie = _plateauDeJeu.ZoneList.ToList().First(a => a.Id == idSortie);
                        _plateauDeJeu.AjouteAcces(new Acces(id, entree, sortie));
                    }
                    else if (reader.Name.ToLower() == "personnage")
                    {
                        var stringId = reader["ID"];
                        if (stringId == null)
                        {
                            reader.Read();
                            continue;
                        }

                        var id = int.Parse(stringId);

                        reader.ReadToFollowing("POSITION");
                        reader.Read();
                        var position = int.Parse(reader.Value);

                        reader.ReadToFollowing("TYPE");
                        reader.Read();
                        var type = reader.Value;

                        Personnage personnage = null;
                        switch (type)
                        {
                            case "FANTOME":
                                personnage = new Fantome(id);
                                break;
                            case "PACMAN":
                                personnage = new PacMan(id);
                                break;
                        }

                        _plateauDeJeu.AjoutePersonnage(personnage);
                    }
                    else if (reader.Name.ToLower() == "configuration")
                    {
                        //A FAIRE
                        reader.Read();
                    }
                    else
                    {
                        reader.Read();
                    }
                }
            }
        }
    }
}
