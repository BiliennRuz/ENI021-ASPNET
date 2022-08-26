namespace TP01_module03_Linq.BO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Facture
    {
        public Facture(decimal montant, Auteur auteur)
        {
            this.Montant = montant;
            this.Auteur = auteur;
        }

        public decimal Montant { get; set; }

        public Auteur Auteur { get; set; }

        public override string ToString()
        {
            return $"Montant: {Montant} Auteur: {Auteur}" + Environment.NewLine;
        }
    }
}
