using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPPizza.Business.Models;

namespace TPPizza.Web.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public PateViewModel Pate { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }

        public static PizzaViewModel FromPizza(Pizza pizza)
        {
            if (pizza.Pate == null)
            {
                return new PizzaViewModel { Id = pizza.Id, Nom = pizza.Nom };
            }
            else
            {
                return new PizzaViewModel { Id = pizza.Id, Nom = pizza.Nom, Pate = PateViewModel.FromPate(pizza.Pate) };
            }
        }
    }
}
