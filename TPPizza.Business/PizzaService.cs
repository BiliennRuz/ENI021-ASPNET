namespace TPPizza.Business;
using TPPizza.Business.Models;

public class PizzaService
{
    private static List<Ingredient> ingredient = Pizza.IngredientsDisponibles;
    private static List<Pate> pates = Pizza.PatesDisponibles;
    private static List<Pizza> pizzas = new List<Pizza>();


    
    public List<Pizza> GetListPizzas()
    {
        var calzone = new Pizza { Id = 1,Nom = "Calzone"};
        pizzas.Add(calzone);
        return pizzas;
    }

    public List<Pate> GetListPate()
    {
        return pates;
    }

    public void AddPizza(Pizza pizza)
    {

        if (pizza.Id == 0 && pizzas.Any()) // cas ID non saisie (create) ou liste viide
        {
            pizza.Id = pizzas.Max(p => p.Id) + 1;
        } else
        {
            pizza.Id = 1;
        }
        pizzas.Add(pizza);
    }

    public void EditPizza(Pizza pizza, int pateId)
    {
        var pizzaEdit = pizzas.FirstOrDefault(p => p.Id == pizza.Id);
        pizzaEdit.Nom = pizza.Nom;
        var pate = pates.FirstOrDefault(pate => pate.Id == pateId);
        pizzaEdit.Pate = pate;
    }

    public void RemovePizza(int Id)
    {
        var pizzaRemove = pizzas.FirstOrDefault(p => p.Id == Id);
        pizzas.Remove(pizzaRemove);
    }

}
