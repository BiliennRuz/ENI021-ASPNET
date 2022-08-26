using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.module02.Heritage
{
    internal class Carre : Forme
    {
        private int longueur;

        public Carre()
        {
        }

        public Carre(int longueur)
        {
            this.longueur = longueur;
        }

        public int Longueur { get; set; }

        public override double Aire => Longueur * Longueur;

        public override double Perimetre => 4 * Longueur;
        public override string ToString()
        {
            return "Carre de coté " + Longueur + " \nAire = " + Aire + " \nPérimètre = " + Perimetre + "\n";
        }
    }
}
