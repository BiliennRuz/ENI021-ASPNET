using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.module02.Heritage
{
    internal class Triangle : Forme
    {
        private int a;
        private int b;
        private int c;
        public double demiP;

        public Triangle()
        {
        }
        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        private double P => (A + B + C) / 2d;

        //double p = (A + B + C) / 2;
        //    return Math.Sqrt(p* (p - A) * (p - B) * (p - C));

        public override double Aire => Math.Sqrt(P * (P - A) * (P - B) * (P - C));

        public override double Perimetre => A + B + C;

        public override string ToString()
        {
            return P + "Triangle de coté A= " + A + ", B= " + B + ", C=" + C + " \nAire = " + Aire + " \nPérimètre = " + Perimetre + "\n";
        }
    }
}
