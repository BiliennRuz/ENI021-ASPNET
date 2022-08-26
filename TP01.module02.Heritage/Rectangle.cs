using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.module02.Heritage
{
    internal class Rectangle : Forme
    {
        private int longueur;
        private int largeur;

        public Rectangle()
        {
        }

        public Rectangle(int longueur, int largeur)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        public int Longueur { get; set; }

        public int Largeur { get; set; }

        public override double Aire => Longueur * Largeur;

        public override double Perimetre => 2 * Longueur + 2 * Largeur;
        public override string ToString()
        {
            return "Rectangle de longueur " + Longueur + " et largueur " + Largeur + " \nAire = " + Aire + " \nPérimètre = " + Perimetre + "\n";
        }
    }
}
