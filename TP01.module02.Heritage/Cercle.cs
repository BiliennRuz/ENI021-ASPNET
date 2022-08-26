using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.module02.Heritage
{
    internal class Cercle : Forme
    {
        private int rayon;

        public Cercle()
        {
        }

        public Cercle(int rayon)
        {
            this.rayon = rayon;
        }

        public int Rayon { get; set; }

        public override double Aire { get => Math.PI * this.Rayon * this.Rayon; }

        public override double Perimetre { get => 2 * Math.PI * this.Rayon; }

        public override string ToString()
        {
            return "Cercle de rayon " + Rayon + " \nAire = " + Aire + " \nPérimètre = " + Perimetre + "\n";
        }

    }
}
