﻿using Simulateur_Personnage.Personnages;

namespace Simulateur_Personnage.Fabrique
{
    public class FabriquePacMan : FabriquePersonnage
    {
        public override Personnage CreerPersonnage(int unId)
        {
            return new PacMan(unId);
        }
    }
}
