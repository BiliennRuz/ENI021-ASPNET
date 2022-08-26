using System.Text.RegularExpressions;
using TP01_module03_Linq.BO;

List<Auteur> ListeAuteurs = new List<Auteur>();
List<Livre> ListeLivres = new List<Livre>();

void InitialiserDatas()
{
    ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
    ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
    ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
    ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
    ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
    ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
    ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
    ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
    ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
    ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
    ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
    ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
    ListeAuteurs.ElementAt(0).AddFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
    ListeAuteurs.ElementAt(0).AddFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
    ListeAuteurs.ElementAt(1).AddFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
    ListeAuteurs.ElementAt(2).AddFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
    ListeAuteurs.ElementAt(3).AddFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
}

InitialiserDatas();
Console.WriteLine(Environment.NewLine+"1) Afficher la liste des prénoms des auteurs dont le nom commence par \"G\" :");
var listeAuteursStartG = ListeAuteurs.Where(a => a.Nom[0] == 'G');
foreach (var auteur in listeAuteursStartG)
{
    Console.WriteLine(auteur.Prenom);
}

Console.WriteLine(Environment.NewLine+"2) Afficher l’auteur ayant écrit le plus de livres :");
var listeLivresCountAuteurs = ListeLivres.GroupBy(l => l.Auteur, (key, group) => new
{
    Auteur = key,
    Count = group.Count()
});

var auteurPlusEcrit = listeLivresCountAuteurs.FirstOrDefault();
Console.WriteLine(auteurPlusEcrit.Auteur);

//foreach (var auteur in listeLivresCountAuteurs)
//{
//    Console.WriteLine(auteur.Auteur);
//}


Console.WriteLine(Environment.NewLine+"3) Afficher le nombre moyen de pages par livre par auteur :");
//var listLivreByAuteur = ListeLivres.GroupBy(l => l.Auteur, (key, group) => new
//{
//    Auteur = $"{key.Nom}",
//    Avrage = group.Average(l => l.NbPages)
//});

//foreach (var auteur in listLivreByAuteur)
//{
//    Console.WriteLine(auteur);
//}


Console.WriteLine(Environment.NewLine+"4) Afficher le titre du livre avec le plus de pages :");
var listeLivresCountPages = ListeLivres.GroupBy(l => l.Titre, (key, group) => new
{
    NbPages = key,
    Count = group.Count()
});

//foreach (var livre in listeLivresCountPages)
//{
//    Console.WriteLine(livre.NbPages);
//}

var titrePlusPages = listeLivresCountPages.FirstOrDefault();
Console.WriteLine(titrePlusPages.NbPages);


Console.WriteLine(Environment.NewLine+"5) Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) :");
var moyenneFacture = ListeAuteurs.SelectMany(a => a.Factures).Average(f => f.Montant);
Console.WriteLine(moyenneFacture);


Console.WriteLine(Environment.NewLine+"6) Afficher les auteurs et la liste de leurs livres :");
foreach (var auteur in ListeAuteurs)
{
    Console.WriteLine(auteur);
    foreach (var livre in ListeLivres.Where(l => l.Auteur == auteur ))
    {
        Console.WriteLine(livre);
    }
}


Console.WriteLine(Environment.NewLine+"7) Afficher les titres de tous les livres triés par ordre alphabétique :");
var listeLivreesByTitreAlpha = ListeLivres.OrderBy(l => l.Titre).ToList();
foreach (var livre in listeLivreesByTitreAlpha)
{
    Console.WriteLine(livre.Titre);
}


Console.WriteLine(Environment.NewLine+"8) Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne");
//Livre listLivresMoyennePageSup = ListeLivres.Where(l => l.NbPages >= ListeLivres.Average(l => l.NbPages));

//foreach (var livre in listLivresMoyennePageSup)
//{
//    Console.WriteLine(livre);
//}


Console.WriteLine(Environment.NewLine+"9) Afficher l'auteur ayant écrit le moins de livres");
//var auteurMoinsEcrit = listeLivresCountAuteurs.LastOrDefault();
var auteurMoinsEcrit = ListeAuteurs.MinBy(a => ListeLivres.Count(l => l.Auteur == a));
Console.WriteLine(auteurMoinsEcrit);
