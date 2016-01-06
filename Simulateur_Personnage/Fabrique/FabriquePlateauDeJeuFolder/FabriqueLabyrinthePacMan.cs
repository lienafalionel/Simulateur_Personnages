using System.Linq;
using System.Xml;
using Simulateur_Personnage.ClassesAbstraites;
using Simulateur_Personnage.Objets;
using System.Collections.Generic;
using Simulateur_Personnage.Personnages;
using Simulateur_Personnage.Personnages.PacManSimulation;

namespace Simulateur_Personnage.Fabrique.FabriquePlateauDeJeuFolder
{
    public class FabriqueLabyrinthePacMan : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new LabyrinthePacMan();
        }

        public override ZoneAbstraite CreerZone(int unId, int unePositionX, int unePositionY, List<Objet> listObjets)
        {
            return new Case(unId, unePositionX, unePositionY, listObjets);
        }

        public override AccesAbstrait CreerAcces(int id, ZoneAbstraite uneZoneOrigine, ZoneAbstraite uneZoneDestination)
        {
            return new Acces(id, uneZoneOrigine, uneZoneDestination);
        }

        public override void LireXml(out List<ZoneAbstraite> listZone, out List<AccesAbstrait> listAcces, out List<Personnage> listPersonnage)
        {
            listZone = new List<ZoneAbstraite>();
            listAcces = new List<AccesAbstrait>();
            listPersonnage = new List<Personnage>();

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
                            case "PORTE":
                                objet = new Porte();
                                break;
                        }

                        listZone.Add(new Zone(id, positionX, positionY, new List<Objet> { objet }));
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

                        var entree = listZone.First(a => a.Id == idEntree);
                        var sortie = listZone.First(a => a.Id == idSortie);
                        listAcces.Add(new Acces(id, entree, sortie));
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

                        if (personnage != null) personnage.ZoneAbstraite = listZone.First(a => a.Id == position);

                        listPersonnage.Add(personnage);
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
